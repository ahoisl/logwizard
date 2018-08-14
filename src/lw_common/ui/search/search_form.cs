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
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using log4net.Repository.Hierarchy;
using LogWizard;

namespace lw_common.ui {
    public partial class search_form : Form {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // re-showing rows is VERY expensive - so, we want to allow just a few - the user will get it if he's got the right search or not
        private const int MAX_SHOW_ROWS = 20;

        private search_for search_ = new search_for();

        private List<int> column_indexes_ = null; 
        private List< List<string>> preview_items_ = new List<List<string>>();
        // contains the rows that match
        private List<int> matches_ = new List<int>();

        private search_for prev_search_ = null;
        private search_renderer render_ = null;

        private List<int> searchable_columns_ = new List<int>();
        private List<int> searchable_columns_msg_only_ = new List<int>();

        public search_for running_search {
            get { return prev_search_; }
        }

        private class item {
            public List<string> parts = new List<string>();

            public item(List<string> parts) {
                this.parts = parts;
            }

            public string part(int i) {
                return parts.Count > i ? parts[i] : "";
            }

            public string t0 { get { return part(0); }}
            public string t1 { get { return part(1); }}
            public string t2 { get { return part(2); }}
            public string t3 { get { return part(3); }}
            public string t4 { get { return part(4); }}
            public string t5 { get { return part(5); }}
            public string t6 { get { return part(6); }}
            public string t7 { get { return part(7); }}
            public string t8 { get { return part(8); }}
            public string t9 { get { return part(9); }}

            public string t10 { get { return part(10); }}
            public string t11 { get { return part(11); }}
            public string t12 { get { return part(12); }}
            public string t13 { get { return part(13); }}
            public string t14 { get { return part(14); }}
            public string t15 { get { return part(15); }}
            public string t16 { get { return part(16); }}
            public string t17 { get { return part(17); }}
            public string t18 { get { return part(18); }}
            public string t19 { get { return part(19); }}

            public string t20 { get { return part(20); }}
            public string t21 { get { return part(21); }}
            public string t22 { get { return part(22); }}
            public string t23 { get { return part(23); }}
            public string t24 { get { return part(24); }}
            public string t25 { get { return part(25); }}
            public string t26 { get { return part(26); }}
            public string t27 { get { return part(27); }}
            public string t28 { get { return part(28); }}
            public string t29 { get { return part(29); }}

            public string t30 { get { return part(30); }}
            public string t31 { get { return part(31); }}
            public string t32 { get { return part(32); }}
            public string t33 { get { return part(33); }}
            public string t34 { get { return part(34); }}
            public string t35 { get { return part(35); }}
            public string t36 { get { return part(36); }}
            public string t37 { get { return part(37); }}
            public string t38 { get { return part(38); }}
            public string t39 { get { return part(39); }}

            public string t40 { get { return part(40); }}
            public string t41 { get { return part(41); }}
            public string t42 { get { return part(42); }}
            public string t43 { get { return part(43); }}
            public string t44 { get { return part(44); }}
            public string t45 { get { return part(45); }}
            public string t46 { get { return part(46); }}
            public string t47 { get { return part(47); }}
            public string t48 { get { return part(48); }}
            public string t49 { get { return part(49); }}

            public string t50 { get { return part(50); }}
        }

        private log_view lv_;
        private List<string> last_view_names_ = new List<string>();
        private int unique_search_id_ = 0;

        private List<search_for> history_;

        private bool dropped_first_time_ = false;

        private font_list fonts_ = new font_list();

        private bool closed_ = false;

        private bool wants_to_filter_ = false;

        /* Edit mode:
           1. if more than 1 entry, the combo is dropped down by default
           2. if you type any letter while the combo is first dropped down (or paste something), it will auto close the dropdown
           3. if you select any entry from the combo, you are EDITING that entry. If you don't select anything, you are ADDING
        */
        // 1.2.7+ if there's something selected by the user, override what we had
        public search_form(Form parent, log_view lv, string smart_edit_search_for_text) {
            InitializeComponent();
            TopMost = parent.TopMost;
            result.Font = lv.list.Font;

            lv_ = lv;
            render_ = new search_renderer(lv, this);
            history_ = search_form_history.inst.all_searches_cur_view_first(lv.name);
            // use the last ones...
            fg.BackColor = history_[0].fg;
            bg.BackColor = history_[0].bg;
            allColumns.Checked = history_[0].all_columns;
            load_combo();

            find_result_columns(lv);
            if (smart_edit_search_for_text != "") {
                combo.Text = smart_edit_search_for_text;
                radioText.Checked = true;
            }
            update_autorecognize_radio();
            update_negate();
            update_to_filter_button();
            prev_search_ = current_search();

            util.postpone(() => {
                combo.Focus();                
                if (combo.Items.Count > 1) {
                    dropped_first_time_ = true;
                    combo.DroppedDown = true;
                }
            },1);

            new Thread(do_searches_thread) {IsBackground = true }.Start();
        }

        private void load_combo() {
            foreach (var search in history_) {
                string text = search.text;
                if (search.use_regex && search.friendly_regex_name != "")
                    text = "[ " + search.friendly_regex_name + " ]";
                combo.Items.Add(text);
            }
        }

        private void load_from_search(search_for search) {
            unique_search_id_ = search.unique_id;
            last_view_names_ = search.last_view_names.ToList();

            fg.BackColor = search.fg;
            bg.BackColor = search.bg;

            caseSensitive.Checked = search.case_sensitive;
            fullWord.Checked = search.full_word;
            friendlyRegexName.Text = search.friendly_regex_name;
            switch (search.type) {
            case 0:
                radioAutoRecognize.Checked = true;
                break;
            case 1:
                radioText.Checked = true;
                break;
            case 2:
                radioRegex.Checked = true;
                break;
                default: Debug.Assert(false);
                break;
            }

            combo.Text = search.text;
            allColumns.Checked = search.all_columns;
            update_autorecognize_radio();
            update_negate();
            update_to_filter_button();
        }

        private void find_result_columns(log_view lv) {
            // see which columns actually have useful data
            List< Tuple<int,int>> columns_and_displayidx = new List<Tuple<int,int>>();
            var available_columns = lv.available_columns; // ... getting available columns: time-consuming
            for (int col_idx = 0; col_idx < lv.list.AllColumns.Count; ++col_idx) {
                if ( lv.list.AllColumns[col_idx].Width > 0)
                    if ( col_idx != lv.viewCol.fixed_index() && available_columns.Contains(log_view_cell.cell_idx_to_type(col_idx)))
                        columns_and_displayidx.Add( new Tuple<int, int>(col_idx, lv.list.AllColumns[col_idx].DisplayIndex ));
            }
            column_indexes_ = columns_and_displayidx.OrderBy(x => x.Item2).Select(x => x.Item1).ToList();

            searchable_columns_.Clear();
            searchable_columns_msg_only_.Clear();
            int preview_col_idx = 0;
            foreach (int col_idx in column_indexes_) {
                result.AllColumns[preview_col_idx].Width = lv.list.AllColumns[col_idx].Width;
                result.AllColumns[preview_col_idx].Text = lv.list.AllColumns[col_idx] != lv.msgCol ? lv.list.AllColumns[col_idx].Text : "Message";
                result.AllColumns[preview_col_idx].FillsFreeSpace = lv.list.AllColumns[col_idx].FillsFreeSpace;
                // note: the line column never enters the search
                bool is_searchable = info_type_io.is_searchable(log_view_cell.cell_idx_to_type(col_idx));
                if (is_searchable)
                    searchable_columns_.Add(preview_col_idx);
                if ( lv.msgCol == lv.list.AllColumns[col_idx])
                    searchable_columns_msg_only_.Add(preview_col_idx);

                if (lv.lineCol != lv.list.AllColumns[col_idx])
                    result.AllColumns[preview_col_idx].Renderer = render_;
                ++preview_col_idx;
            }
            for (; preview_col_idx < result.AllColumns.Count; ++preview_col_idx)
                result.AllColumns[preview_col_idx].IsVisible = false;
            result.RebuildColumns();            
        }

        private void load_surrounding_rows(log_view lv) {
            int sel = lv.sel_row_idx;
            if (sel < 0)
                sel = 0;
            // get as many rows as possible, in both directions
            int max_count = Math.Min(app.inst.look_around_find, lv.item_count);
            var surrounding = util.surrounding(sel, max_count, 0, lv.item_count);
            int min = surrounding.Item1, max = surrounding.Item2;
            // at this point, we know the start and end
            for (int idx = min; idx < max; ++idx) {
                var i = lv.item_at(idx);
                List<string> row = new List<string>();
                foreach (int col_idx in column_indexes_)
                    row.Add(log_view_cell.cell_value(i, col_idx));
                preview_items_.Add(row);
            }

            for ( int match_idx = 0; match_idx < preview_items_.Count; ++match_idx)
                matches_.Add(match_idx);
        }

        private void rebuild_result() {
            result.Freeze();
            result.ClearObjects();
            int add_count = 0;
            foreach (var match_idx in matches_) {
                result.AddObject(new item(preview_items_[match_idx]));
                if (++add_count >= MAX_SHOW_ROWS)
                    break;
            }
            result.Unfreeze();
            result.Refresh();
        }

        public static search_for default_search {
            get { return search_form_history.inst.default_search; }
        }

        public search_for search {
            get { return search_; }
        }

        public bool wants_to_filter {
            get { return wants_to_filter_; }
        }

        private void fg_Click(object sender, EventArgs e) {
            var sel = new select_color_form("Foreground Color", fg.BackColor);
            if (sel.ShowDialog() == DialogResult.OK) {
                fg.BackColor = sel.SelectedColor;
                update_to_filter_button();
            }
        }

        private void bg_Click(object sender, EventArgs e) {
            var sel = new select_color_form("Background Color", fg.BackColor);
            if (sel.ShowDialog() == DialogResult.OK) {
                bg.BackColor = sel.SelectedColor;
                update_to_filter_button();
            }
        }

        private search_for current_search() {
            int type = 0;
            if (radioAutoRecognize.Checked) type = 0;
            else if (radioText.Checked) type = 1;
            else if (radioRegex.Checked) type = 2;
            else Debug.Assert(false);

            var last_view_names = last_view_names_.ToList();
            if ( !last_view_names.Contains(lv_.name))
                last_view_names.Add(lv_.name);
            while ( last_view_names.Count > search_for.MAX_LAST_VIEW_NAMES)
                last_view_names_.RemoveAt(0);

            return new search_for() {
                bg = bg.BackColor, 
                fg = fg.BackColor, 
                case_sensitive = caseSensitive.Checked,
                full_word = fullWord.Checked, 
                mark_lines_with_color = mark.Checked, 
                text = combo.Text, 
                type = type,
                friendly_regex_name = friendlyRegexName.Text,
                last_view_names = last_view_names.ToArray(),
                all_columns = allColumns.Checked
            };
        }

        private void ok_Click(object sender, EventArgs e) {
            if (combo.Text != "") {
                search_ = current_search();
                if ( markAsNewEntry.Checked)
                    unique_search_id_ = 0;
                search_.unique_id = unique_search_id_;
                search_form_history.inst.save_last_search( search_);
                DialogResult = DialogResult.OK;
            }
        }

        private void cancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }


        private static bool is_auto_regex(string text) {
            return search_for.is_auto_regex(text);
        }

        private void update_autorecognize_radio() {
            radioAutoRecognize.Text = "Auto recognized (" + (is_auto_regex(combo.Text) ? "Regex" : "Text") + ")";
        }

        private void update_negate() {
            bool is_regex = (radioAutoRecognize.Checked && is_auto_regex(combo.Text)) || radioRegex.Checked;
            negate.Enabled = !is_regex;
        }

        private void update_to_filter_button() {
            var filt = current_search().to_filter();
            toFilter.ForeColor = filt.fg.ToArgb() != util.transparent.ToArgb() ? filt.fg: Color.Black;
            toFilter.BackColor = filt.bg;
        }

        private void do_searches_thread() {
            load_surrounding_rows(lv_);

            try {
                do_searches_thread_impl();
            } catch (ObjectDisposedException) {
                // main thread ended
            } catch (Exception e) {
                logger.Fatal("error on searches " + e);
            }
        }


        private void do_searches_thread_impl() {
            // first time, show all
            run_search();
            this.async_call_and_wait(() => {
                rebuild_result();
                update_preview_text();
            });

            while (!closed_) {
                Thread.Sleep(250);
                search_for cur = null;
                this.async_call_and_wait(() => {                    
                    if (combo.DroppedDown)
                        return;

                    var cur_search = current_search();
                    if (prev_search_ == cur_search)
                        // nothing changed
                        return;

                    cur = cur_search;
                    prev_search_ = cur;
                    preview.Text = "Computing [" + prev_search_ + "]";
                });

                if (cur == null)
                    continue;

                logger.Info("[search] searching: " + cur.text);
                run_search();
                this.async_call_and_wait(() => {
                    rebuild_result();
                    update_preview_text();
                });
                logger.Info("[search] searching: " + cur.text  + " - complete");
            }
        }

        private void update_preview_text() {
            bool no_matches = prev_search_.text == "" || (prev_search_.use_regex && prev_search_.regex == null);
            preview.Text = "Previewing surrounding " + preview_items_.Count + " rows. ";
            if (no_matches) {
                preview.Text += " NO MATCHES.";
                return;
            }
            preview.Text += "" + matches_.Count + " matches";
            if (matches_.Count > MAX_SHOW_ROWS)
                preview.Text += ", showing only " + result.GetItemCount();
        }

        private void load_all_matches() {
            matches_.Clear();
            for ( int match_idx = 0; match_idx < preview_items_.Count; ++match_idx)
                matches_.Add(match_idx);            
        }

        private void run_search() {
            if (prev_search_.text == "") {
                // nothing to search for
                load_all_matches();
                return;
            }
            if ( prev_search_.use_regex)
                if (prev_search_.regex == null) {
                    // in this case, the regex is invalid
                    load_all_matches();
                    return;
                }

            List<int> matches = new List<int>();
            for (int idx = 0; idx < preview_items_.Count; ++idx) {
                var to_search = searchable_columns().Select(col => preview_items_[idx][col]);
                bool matches_now = string_search.matches(to_search, prev_search_);
                if ( matches_now)
                    matches.Add(idx);
            }
            matches_ = matches;
        }

        private List<int> searchable_columns() {
            return prev_search_.all_columns ? searchable_columns_ : searchable_columns_msg_only_;
        } 

        private void search_form_FormClosed(object sender, FormClosedEventArgs e) {
            closed_ = true;
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e) {
            if (combo.DroppedDown)
                return;

            Debug.Assert(!dropped_first_time_);

            int sel = combo.SelectedIndex;
            if (sel >= 0) {
                unique_search_id_ = history_[sel].unique_id;
                markAsNewEntry.Checked = false;
                markAsNewEntry.Enabled = true;
                load_from_search(history_[sel]);
                // at this point, properly set_aliases the combo text
                util.postpone(() => combo.Text = history_[sel].text, 1);
            } else {
                markAsNewEntry.Checked = true;
                markAsNewEntry.Enabled = false;
                combo.Text = "";
            }

        }

        private void combo_TextUpdate(object sender, EventArgs e) {
            update_autorecognize_radio();
            update_negate();
            if (combo.Text != "" && dropped_first_time_) {
                string old = combo.Text;
                dropped_first_time_ = false;
                combo.DroppedDown = false;
                // typing something could be default select something - we don't want that
                combo.Text = old;
                combo.SelectionStart = old.Length;
            }
        }

        private void combo_DrawItem(object sender, DrawItemEventArgs e) {
            Debug.Assert(e.Index >= 0);
            // Draw the background 
            e.DrawBackground();        

            // Get the item text    
            string text = ((ComboBox)sender).Items[e.Index].ToString();

            // Determine the forecolor based on whether or not the item is selected    
            Brush brush;
            if ( history_[e.Index].friendly_regex_name != "" )
                brush = Brushes.Red;
            else
                brush = Brushes.Black;

            bool italic = false;
            bool bold = history_[e.Index].last_view_names.Contains(lv_.name);

            // Draw the text    
            e.Graphics.DrawString(text, fonts_.get_font( ((Control)sender).Font, bold, italic, false), brush, e.Bounds.X, e.Bounds.Y);

        }

        private void radioAutoRecognize_CheckedChanged(object sender, EventArgs e) {
            if (radioAutoRecognize.Checked)
                friendlyRegexName.Enabled = is_auto_regex(combo.Text);
            update_negate();
        }

        private void radioText_CheckedChanged(object sender, EventArgs e) {
            if (radioText.Checked)
                friendlyRegexName.Enabled = false;
            update_negate();
        }

        private void radioRegex_CheckedChanged(object sender, EventArgs e) {
            if (radioRegex.Checked)
                friendlyRegexName.Enabled = true;
            update_negate();
        }

        private void combo_DropDownClosed(object sender, EventArgs e) {
            dropped_first_time_ = false;
            combo_SelectedIndexChanged(null, null);
        }

        private void negate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void filterHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/habjoc/logwizard/wiki/Filters");
        }

        private void toFilter_Click(object sender, EventArgs e) {
            search_ = current_search();

            if (search_.fg == util.transparent) {
                var sel = new select_color_form("Filter Foreground Color", Color.Red);
                if (sel.ShowDialog() == DialogResult.OK) {
                    fg.BackColor = sel.SelectedColor;
                    search_ = current_search();
                    Debug.Assert(search_.fg != util.transparent);
                } else
                    // user did not select a foreground - this is required
                    return;
            }

            if ( markAsNewEntry.Checked)
                unique_search_id_ = 0;
            search_.unique_id = unique_search_id_;
            wants_to_filter_ = true;
            DialogResult = DialogResult.OK;
        }
    }

}
