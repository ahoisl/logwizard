﻿/* 
 * Copyright (C) 2014-2016 John Torjo
 *
 * This file is part of LogWizard
 *
 * LogWizard is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * LogWizard is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * If you wish to use this code in a closed source application, please contact john.code@torjo.com 
 *
 * **** Get Latest version at https://github.com/jtorjo/logwizard **** 
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using lw_common.parse.parsers;
using LogWizard;

namespace lw_common.parse.parsers {

    /*  reads everything in the log FILE, and allows easy access to its lines

        parses the syntax line-by-line - we assume a single line contains a full log entry
    */
    internal class text_file_line_by_line : log_parser_base {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private class syntax_info {
            internal static readonly Tuple<int, int>[] line_contains_msg_only_ = new Tuple<int, int>[(int) info_type.max];
            static syntax_info() {
                for (int i = 0; i < line_contains_msg_only_.Length; ++i)
                    line_contains_msg_only_[i] = i == (int)info_type.msg ? new Tuple<int, int>(0, -1) : new Tuple<int, int>(-1, -1);
            }

            public syntax_info() {
            }
            
            // if true, each line needs to be parsed (the positions of each part are relative)
            public bool relative_syntax_ = false;

            // [index, length]
            public Tuple<int,int>[] idx_in_line_ = new Tuple<int, int>[ (int)info_type.max];

            public class relative_pos {
                public info_type type = info_type.max;
                // if >= 0, they are fixed
                public int start = -1, len = -1;
                // if != null, we find the start via the finding a string, or end via finding of a string
                public string start_str = null, end_str = null;

                // if > 0, we only start searching after this many chars from start
                public int min_chars = 0;

                // if not empty, the alias given to this column
                public string column_alias = "";

                public bool is_end_of_string {
                    get { return start < 0 && len < 0 && start_str == null && end_str == null; }
                }
            }

            // if true, I can find this part 
            public bool can_find(info_type part) {
                if (relative_syntax_) {
                    var pos = relative_idx_in_line_.FirstOrDefault(x => x.type == part);
                    return (pos != null);
                } else
                    return idx_in_line_[(int) part].Item1 >= 0;
            }

            // readonly - set in constructor
            public List<relative_pos> relative_idx_in_line_ = new List<relative_pos>();
        }

        private List<syntax_info> syntaxes_ = new List<syntax_info>();

        // FIXME not a good idea
        private const int CACHE_LAST_INCOMPLETE_LINE_MS = 50000;

        private readonly file_text_reader_base reader_ = null;

        // this is probably far from truth (probably the avg line is much smaller), but it's good to have a good starting capacity, to minimizes resizes
        private const int CHARS_PER_AVG_LINE = 384;


        private large_string string_ = new large_string();
        private memory_optimized_list<line> lines_ = new memory_optimized_list<line>() { name = "parser-lbl"};

        private DateTime was_last_line_incomplete_ = DateTime.MinValue;

        // if true, we've been fully read (thus, we're up to date)
        private bool up_to_date_ = false;

        private bool lines_min_capacity_updated_ = false;

        // if true, if a line does not match the syntax, assume it's from previous line
        // 1.4.8+ - not used yet
        private bool if_line_does_not_match_syntax_assume_from_prev_line = false;
        // 1.8.4+
        private bool if_line_starts_with_tab_assume_from_prev_line = false;

        public text_file_line_by_line(file_text_reader_base reader) : base(reader.settings) {
            string syntax_str = lw_common.parse_syntax.parse(reader.settings.syntax);
            if_line_does_not_match_syntax_assume_from_prev_line = reader.settings.line_if_line_does_not_match_syntax;
            if_line_starts_with_tab_assume_from_prev_line = reader.settings.line_if_line_starts_with_tab;
            logger.Debug("[parse] parsing syntax " + syntax_str);

            Debug.Assert(reader != null);
            parse_syntax(syntax_str);
            reader_ = reader;
            
            lines_.name = "parser " + reader_.name;
            var file = reader as file_text_reader;
            if (file != null)
                lines_.name = "parser " + new FileInfo(file.name).Name;
            
            var full_len = reader_.try_guess_full_len;            
            if (full_len != ulong.MaxValue) {
                string_.expect_bytes(full_len);
                lines_.min_capacity = (int)(full_len / CHARS_PER_AVG_LINE);
            }
            // otherwise, it would get overridden in log_parser's constructor (force_reload())
            util.postpone(() => {
                // 1.8.13+ only if within our syntax, we have some aliases. If so, we force them
                var aliases = suggested_syntax_aliases;
                if (aliases.Count > 0)
                    column_names_to_info_type = aliases;
            }, 1);
        }

        private List<Tuple<string, info_type>> suggested_syntax_aliases {
            get {
                var aliases = new List<Tuple<string, info_type>>();
                foreach (var syntax in syntaxes_) 
                    if ( syntax.relative_syntax_) {
                        aliases.Clear();
                        bool has_any_alias = syntax.relative_idx_in_line_.Any(x => x.column_alias != "");
                        if ( has_any_alias)
                            foreach ( var rel in syntax.relative_idx_in_line_)
                                aliases.Add(new Tuple<string, info_type>(rel.column_alias != "" ? rel.column_alias : rel.type.ToString(), rel.type));
                    }
                return aliases;
            }
        } 

        private  List<string> syntax_to_column_names {
            get {
                // syntax is like $name1[...] $name2[...] ...
                string syntax = sett_.syntax;

                var names = syntax.Split('$');
                List<string> result = new List<string>();
                foreach (var name in names) {
                    int type = name.IndexOf('[');
                    string column;
                    if (type >= 0)
                        column = name.Substring(0, type).Trim();
                    else
                        column = name.Trim();
                    if (column != "")
                        result.Add(column);
                }

                return result;
            }
        }

        protected override void on_updated_settings() {
            base.on_updated_settings();

            var aliases = suggested_syntax_aliases;
            if (aliases.Count > 0)
                column_names_to_info_type = aliases;
            else 
                column_names = syntax_to_column_names;
        }

        private void update_log_lines_capacity() {
            if (lines_min_capacity_updated_)
                return;

            // wait until we read a bit until we can guess the average length
            if (string_.line_count < large_string.COMPUTE_AVG_LINE_AFTER)
                return;
            lines_min_capacity_updated_ = true;
            int avg_line = string_.char_count / string_.line_count ;

            var full_len = reader_.try_guess_full_len;
            if (full_len != ulong.MaxValue) 
                lines_.min_capacity = (int)(full_len / (ulong)avg_line);            
        }


        public override int line_count {
            get {
                lock (this) {
                    int count = lines_.Count;
                    if ( was_last_line_incomplete_ != DateTime.MinValue)
                        if (was_last_line_incomplete_.AddMilliseconds(CACHE_LAST_INCOMPLETE_LINE_MS) > DateTime.Now)
                            // we're not sure if the last line was fully read - assume not...
                            --count;
                    return count;
                }
            }
        }

        public string name {
            get { return reader_.name; }
        }

        public override bool up_to_date {
            get { return up_to_date_;  }
        }

        public override bool has_multi_line_columns {
            get { return false; }
        }

        public override  line line_at(int idx) {
            lock (this) {
                if (idx < lines_.Count)
                    return lines_[idx];
                else {
                    // this can happen, when the log has been re-written, and everything is being refreshed
                    throw new line.exception("invalid line request " + idx + " / " + lines_.Count);
                }
            }
        }


        private Tuple<int, int> parse_syntax_pos(string syntax, string prefix) {
            try {
                int start_idx = syntax.IndexOf(prefix);
                if (start_idx >= 0) {
                    start_idx += prefix.Length;
                    int end_idx = syntax.IndexOf("]", start_idx);
                    string positions = syntax.Substring(start_idx, end_idx - start_idx);
                    int separator = positions.IndexOf(",");
                    if (separator >= 0) {
                        string[] pos = positions.Split(',');
                        return new Tuple<int, int>( int.Parse(pos[0]), int.Parse(pos[1]) );
                    }
                    else 
                        return new Tuple<int, int>( int.Parse(positions), -1 );
                }
            } catch {}

            return new Tuple<int, int>(prefix.StartsWith("msg") ? 0 : -1, -1);
        }

        private syntax_info parse_relative_syntax(string syntax) {
            syntax_info si = new syntax_info();
            si.relative_syntax_ = true;
            si.relative_idx_in_line_.Clear();

            // Example: "$time[0,12] $ctx1['[','-'] $func[' ',']'] $ctx2['[[',' ] ]'] $msg"
            syntax = syntax.Trim();
            while (syntax.Length > 0) {
                if (syntax[0] != '$')
                    // invalid syntax
                    break;

                syntax = syntax.Substring(1);
                string type_str = syntax.Split('[')[0];
                string column_alias = "";
                if (type_str.Contains("{")) {
                    column_alias = type_str.Substring(type_str.IndexOf("{") + 1).Trim();
                    column_alias = column_alias.Substring(0, column_alias.Length - 1); // ignore ending }
                    // note: we can't have an alias match a logwizard existing column type - like, "line". That would interfere with how we process the columns
                    if (info_type_io.from_str(column_alias) != info_type.max)
                        column_alias = "_" + column_alias;
                    type_str = type_str.Substring(0, type_str.IndexOf("{")).Trim();
                }
                info_type type = info_type_io.from_str(type_str);
                if (type == info_type.max)
                    // invalid syntax
                    break;
                int bracket = syntax.IndexOf("[");
                syntax = bracket >= 0 ? syntax.Substring(bracket + 1).Trim() : "";
                if (syntax == "") {
                    // this was the last item (the remainder of the string)
                    si.relative_idx_in_line_.Add( new syntax_info.relative_pos {
                        type = type, start = -1, start_str = null, len = -1, end_str = null, column_alias = column_alias
                    });
                    break;
                }

                var start = parse_sub_relative_syntax(ref syntax);
                syntax = syntax.Length > 0 ? syntax.Substring(1) : syntax; // ignore the delimeter after the number
                var end = parse_sub_relative_syntax(ref syntax);
                bool has_min_chars = syntax.StartsWith(";");
                syntax = syntax.Length > 0 ? syntax.Substring(1) : syntax; // ignore the delimeter after the number
                int min_chars = 0;
                if (has_min_chars) {
                    int idx_next = syntax.IndexOf("]");
                    if (idx_next >= 0) {
                        int.TryParse(syntax.Substring(0, idx_next), out min_chars);
                        syntax = syntax.Substring(idx_next + 1);
                    }
                }
                si.relative_idx_in_line_.Add( new syntax_info.relative_pos {
                    type = type, start = start.Item1, start_str = start.Item2, len = end.Item1, end_str = end.Item2, column_alias = column_alias, min_chars = min_chars
                });

                syntax = syntax.Trim();
            }
            return si;
        }

        private syntax_info parse_single_syntax(string syntax) {
            try {
                if (syntax.Contains("'")) 
                    return parse_relative_syntax(syntax);

                syntax_info si = new syntax_info();
                si.idx_in_line_[(int) info_type.time] = parse_syntax_pos(syntax, "time[");
                si.idx_in_line_[(int) info_type.date] = parse_syntax_pos(syntax, "date[");
                si.idx_in_line_[(int) info_type.level] = parse_syntax_pos(syntax, "level[");
                si.idx_in_line_[(int) info_type.msg] = parse_syntax_pos(syntax, "msg[");
                si.idx_in_line_[(int) info_type.class_] = parse_syntax_pos(syntax, "class[");
                si.idx_in_line_[(int) info_type.file] = parse_syntax_pos(syntax, "file[");

                si.idx_in_line_[(int) info_type.func] = parse_syntax_pos(syntax, "func[");
                si.idx_in_line_[(int) info_type.ctx1] = parse_syntax_pos(syntax, "ctx1[");
                si.idx_in_line_[(int) info_type.ctx2] = parse_syntax_pos(syntax, "ctx2[");
                si.idx_in_line_[(int) info_type.ctx3] = parse_syntax_pos(syntax, "ctx3[");

                si.idx_in_line_[(int) info_type.ctx4] = parse_syntax_pos(syntax, "ctx4[");
                si.idx_in_line_[(int) info_type.ctx5] = parse_syntax_pos(syntax, "ctx5[");
                si.idx_in_line_[(int) info_type.ctx6] = parse_syntax_pos(syntax, "ctx6[");
                si.idx_in_line_[(int) info_type.ctx7] = parse_syntax_pos(syntax, "ctx7[");
                si.idx_in_line_[(int) info_type.ctx8] = parse_syntax_pos(syntax, "ctx8[");
                si.idx_in_line_[(int) info_type.ctx9] = parse_syntax_pos(syntax, "ctx9[");
                si.idx_in_line_[(int) info_type.ctx10] = parse_syntax_pos(syntax, "ctx10[");

                si.idx_in_line_[(int) info_type.ctx11] = parse_syntax_pos(syntax, "ctx11[");
                si.idx_in_line_[(int) info_type.ctx12] = parse_syntax_pos(syntax, "ctx12[");
                si.idx_in_line_[(int) info_type.ctx13] = parse_syntax_pos(syntax, "ctx13[");
                si.idx_in_line_[(int) info_type.ctx14] = parse_syntax_pos(syntax, "ctx14[");
                si.idx_in_line_[(int) info_type.ctx15] = parse_syntax_pos(syntax, "ctx15[");

                si.idx_in_line_[(int) info_type.thread] = parse_syntax_pos(syntax, "thread[");

                Debug.Assert(si.idx_in_line_.Length == syntax_info.line_contains_msg_only_.Length);
                return si;
            } catch {
                // invalid syntax
                return null;
            }
        }

        private void parse_syntax(string syntax) {
            try {
                // 1.8.4+ - make the syntax separator rather impossible to occur as a separator in the log itself (#78)
                string[] several = syntax.Split(new string[] {"|syntax|"}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string single in several) {
                    var parsed = parse_single_syntax(single);
                    if ( parsed != null)
                        syntaxes_.Add(parsed);
                }
            } catch {
                // invalid syntax - use whatever works
            }
            if ( syntaxes_.Count < 1)
                // in this case - can't parse syntax - treat each line as msg-only
                syntaxes_.Add(new syntax_info());
        }

        // it can be a number (index) or a string (to search for)
        private Tuple<int, string> parse_sub_relative_syntax(ref string syntax) {
            if ( syntax == "")
                // invalid syntax
                return new Tuple<int, string>(-1,null);

            // 1.7.35 - allow spaces in between
            syntax = syntax.Trim();
            if (Char.IsDigit(syntax[0])) {
                int end = 1;
                while (Char.IsDigit(syntax[end]) && end < syntax.Length)
                    ++end;
                int number = int.Parse(syntax.Substring(0, end));
                syntax = syntax.Substring(end);
                return new Tuple<int, string>(number,null);
            }
            else if (syntax[0] == '\'') {
                syntax = syntax.Substring(1);
                // at this point, we assume we're not searching for ' inside the string (which would be double-quoted or something)
                int end = syntax.IndexOf('\'');
                if (end != -1) {
                    string str = syntax.Substring(0, end);
                    syntax = syntax.Substring(end + 1);
                    return new Tuple<int, string>(-1, str);
                }
            } 

            // invalid syntax
            syntax = "";
            return new Tuple<int, string>(-1, null);            
        }


        // forces the WHOLE FILE to be reloaded
        //
        // be VERY careful calling this - I should call this only when the syntax has changed
        public override void force_reload() {
            lock (this) {
                was_last_line_incomplete_ = DateTime.MinValue;
                lines_.Clear();
                up_to_date_ = false;
            }
            string_.clear();
        }


        public override void read_to_end() {
            ulong old_len = reader_.full_len;
            reader_.compute_full_length();
            ulong new_len = reader_.full_len;
            // when reader's position is zero -> it's either the first time, or file was re-rewritten
            if (old_len > new_len || reader_.pos == 0) 
                // file got re-written
                force_reload();

            bool fully_read = old_len == new_len && reader_.is_up_to_date();

            if ( !reader_.has_more_cached_text()) {
                lock (this) {
                    up_to_date_ = fully_read;
                    if ( up_to_date_)
                        // at this point, we're sure we read everything
                        was_last_line_incomplete_ = DateTime.MinValue;
                }
                return;
            }
            
            lock (this)
                up_to_date_ = false;

            string text = reader_.read_next_text();
            int added_line_count = 0;
            bool was_last_line_incomplete = false, is_last_line_incomplete = false;
            int old_line_count = string_.line_count;
            string_.add_lines(text, ref added_line_count, ref was_last_line_incomplete, ref is_last_line_incomplete);

            if (added_line_count < 1)
                return;

            bool needs_reparse_last_line;
            lock (this)
                needs_reparse_last_line = lines_.Count > 0 && was_last_line_incomplete;
            int start_idx = old_line_count - (was_last_line_incomplete ? 1 : 0);
            int end_idx = string_.line_count;
            List<line> now = new List<line>(end_idx - start_idx);
            int merged_line_count = 0;
            for (int i = start_idx; i < end_idx; ++i) {
                var cur_line = new sub_string(string_, i - merged_line_count);
                bool is_from_prev_line = false;
                if ( if_line_starts_with_tab_assume_from_prev_line)
                    if (cur_line.msg.StartsWith("\t"))
                        is_from_prev_line = true;
                if (i == 0)
                    is_from_prev_line = false; // there's no previous line

                if (!is_from_prev_line)
                    now.Add(parse_line(cur_line));
                else {
                    string_.merge_line_into_previous_line(i - merged_line_count);
                    ++merged_line_count;
                }
            }

            lock (this) {
                if (needs_reparse_last_line) {
                    // we re-parse the last line (which was previously incomplete)
                    logger.Debug("[line] reparsed line " + (old_line_count-1) );
                    lines_.RemoveAt( lines_.Count - 1);
                }

                int old_count = lines_.Count;
                lines_.AddRange(now);
                // in order to adjust time, we have to have at least one syntax in which we find it
                bool can_find_time = syntaxes_.FirstOrDefault(x => x.can_find(info_type.time)) != null;
                if ( can_find_time)
                    for ( int idx = old_count; idx < lines_.Count; ++idx)
                        adjust_line_time(idx);
                was_last_line_incomplete_ = was_last_line_incomplete ? DateTime.Now : DateTime.MinValue;
            }
            //Debug.Assert( lines_.Count == string_.line_count);

            update_log_lines_capacity();
        }

        // if the time isn't set - try to use it from the surroundings
        private void adjust_line_time(int idx) {
            if (lines_[idx].time != DateTime.MinValue)
                return;

            int src_idx = idx - 1;
            for ( ; src_idx >= 0; --src_idx)
                if (lines_[src_idx].time != DateTime.MinValue) {
                    lines_[idx].time = lines_[src_idx].time;
                    return;
                }

            for ( src_idx = idx + 1; src_idx < lines_.Count; ++src_idx)
                if (lines_[src_idx].time != DateTime.MinValue) {
                    lines_[idx].time = lines_[src_idx].time;
                    return;                    
                }
        }

        private bool parse_time(string line, Tuple<int,int> idx) {
            if (idx == null)
                return false;

            if (idx.Item1 < 0)
                return true;
            if (line.Length < idx.Item1 + idx.Item2)
                // we don't have enough line to hold the time/date/level
                return false;
            string sub = line.Substring(idx.Item1, idx.Item2);
            int max = Math.Min(idx.Item2, 8); // ignore milis
            bool ok = true;
            for ( int i = 0; i < max; ++i)
                if ((i + 1) % 3 == 0)
                    ok = ok && sub[i] == ':';
                else
                    ok = Char.IsDigit(sub[i]);
            return ok;
        }
        private bool parse_date(string line, Tuple<int,int> idx) {
            if (idx.Item1 < 0)
                return true;
            if (line.Length < idx.Item1 + idx.Item2)
                // we don't have enough line to hold the time/date/level
                return false;

            string sub = line.Substring(idx.Item1, idx.Item2);
            int digits = 0, sep = 0;
            foreach ( char c in sub)
                if (Char.IsDigit(c) || Char.IsWhiteSpace(c))
                    ++digits;
                else if (c == '-' || c == '/')
                    ++sep;
                else
                    return false;
            return sep == 2;
        }

        private bool parse_level(string line, Tuple<int,int> idx) {
            if (idx.Item1 < 0)
                return true;
            if (line.Length < idx.Item1 + idx.Item2)
                // we don't have enough line to hold the time/date/level
                return false;
            
            string sub = line.Substring(idx.Item1, idx.Item2).TrimEnd();
            return sub == "INFO" || sub == "ERROR" || sub == "FATAL" || sub == "DEBUG" || sub == "WARN";
        }


        // if at exit of function, idx < 0, the line could not be parsed
        private Tuple<int, int> parse_relative_part(string l, syntax_info.relative_pos part, ref int idx) {
            if (part.is_end_of_string) {
                // return remainder of the string
                int at = idx;
                idx = l.Length;
                //return new Tuple<int, int>(at, l.Length - at);
                // 1.8.4+ - this way, I can merge a consecutive line into this one
                return new Tuple<int, int>(at, -1);
            }

            int start = -1, end = -1;
            if (part.start >= 0)
                start = part.start;
            else {
                if ( idx >= l.Length)
                    // passed the end of string
                    return null;

                start = l.IndexOf(part.start_str, idx);
                idx = start >= 0 ? start + part.start_str.Length : -1;
                if (start >= 0)
                    start += part.start_str.Length;
            }

            if ( idx >= 0)
                if (part.len >= 0) {
                    end = start + part.len;
                    idx = end;
                } else {
                    if (part.end_str != null)
                        // 1.8.12 - care about min chars
                        end = l.IndexOf(part.end_str, idx + part.min_chars);
                    else {
                        end = l.Length;
                        if ( part.start_str != null)
                            start -= part.start_str.Length;
                    }
                    idx = end >= 0 ? end + (part.end_str != null ? part.end_str.Length : 0) : -1;
                }

            return ( start < l.Length && end <= l.Length) ? new Tuple<int, int>(start, end - start) : null;
        }

        private line parse_relative_line(sub_string l, syntax_info si) {
            List< Tuple<int,int> > indexes = new List<Tuple<int, int>>();
            for ( int i = 0; i < (int)info_type.max; ++i)
                indexes.Add(new Tuple<int,int>(-1,-1));

            string sub = l.msg;
            int cur_idx = 0;
            int correct_count = 0;
            foreach (var rel in si.relative_idx_in_line_) {
                if (cur_idx < 0)
                    break;
                var index = parse_relative_part(sub, rel, ref cur_idx);
                if (index == null)
                    return null;
                if (index.Item1 >= 0 ) {
                    indexes[(int) rel.type] = index;
                    ++correct_count;
                }
            }

            // if we could parse time or date, we consider it an OK line
            bool normal_line = correct_count == si.relative_idx_in_line_.Count;
            return normal_line ? new line(l, indexes.ToArray()) : null ;
        }

        // returns null if it can't parse
        private line parse_line_with_syntax(sub_string l, syntax_info si) {
            if (si.relative_syntax_)
                return parse_relative_line(l, si);

            try {
                string sub = l.msg;
                bool normal_line = parse_time(sub, si.idx_in_line_[(int) info_type.time]) && parse_date(sub, si.idx_in_line_[(int) info_type.date]);
                if (si.idx_in_line_[(int) info_type.time].Item1 < 0 && si.idx_in_line_[(int) info_type.date].Item1 < 0)
                    // in this case, we don't have time & date - see that the level matches
                    // note: we can't rely on level too much, since the user might have additional levels that our defaults - so we could get false negatives
                    normal_line = parse_level(sub, si.idx_in_line_[(int) info_type.level]);

                return normal_line ? new line(l, si.idx_in_line_) : null;
            } catch(Exception e) {
                logger.Error("invalid line: " + l + " : " + e.Message);
                //return new line(pos_in_log, l, line_contains_msg_only_);
                return null;
            }
        }

        private line parse_line(sub_string l) {
            Debug.Assert(syntaxes_.Count > 0);

            foreach (var si in syntaxes_) {
                line result = null;
                if (si.relative_syntax_)
                    result = parse_relative_line(l, si);
                else
                    result = parse_line_with_syntax(l, si);

                if (result != null)
                    return result;
            }

            // in this case, we can't parse the line at all - use default
            return new line(l, syntax_info.line_contains_msg_only_);
        }

    }

}
