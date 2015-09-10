﻿/* 
 * Copyright (C) 2014-2015 John Torjo
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
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using LogWizard.readers;

namespace LogWizard
{
    /*
    1.0.14+ now, the file_text_reader can handle logs that are being appended to, and that are re-written

    1.0.41 made thread-safe

    1.0.72
    - decrease memory footprint
    - very important assumption: we always assume that when the file is "encoding-complete" - in other words,
      we never end up in the scenario where a character (that can occupy several bytes) is not fully written into the file
    */
    class file_text_reader : text_reader
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string file_;

        // 1.0.72+ note: for now, assume the encoding is 4-padded, and we never end up splitting a char in the middle
        //private const ulong MAX_READ_IN_ONE_GO = 16 * 1024 * 1024;
        private readonly ulong MAX_READ_IN_ONE_GO = (ulong) (util.is_debug ? 128 * 1024 : 16 * 1024 * 1024);

        private byte[] buffer_ = null;

        private string last_part_ = "";

        private ulong full_len_now_ = 0;

        private ulong offset_ = 0;
        private ulong read_byte_count_ = 0;

        private string cached_syntax_ = "";

        private bool has_it_been_rewritten_ = false;

        private Encoding file_encoding_ = null;
        
        public file_text_reader(string file) {
            buffer_ = new byte[MAX_READ_IN_ONE_GO];
            try {
                // get absolute path - normally, this should be the absolute path, but just to be sure
                file_ = new FileInfo(file).FullName;
            } catch {
                file_ = file;
            }
            new Thread(read_all_file_thread) {IsBackground = true}.Start();
        }

        private void read_all_file_thread() {
            while (!disposed) {
                Thread.Sleep(100);
                read_file_block();
            }
        }

        public override string name {
            get { return file_; }
        }

        // this should read all text, returns it, and reset our buffer - len is not needed
        public override string read_next_text() {
            lock (this) {
                string now = last_part_;
                last_part_ = "";
                offset_ = read_byte_count_;
                return now;
            }
        }

        public override void compute_full_length() {
            ulong full;
            try {
                full = (ulong)new FileInfo(file_).Length;
            } catch (FileNotFoundException e) {
                full = 0;
            }
            catch(Exception e) {
                // if we can't read the file length, something probably happened - either it got re-written, or locked
                // wait until next time
                return;
            }

            lock (this) 
                full_len_now_ = Math.Min( read_byte_count_ + MAX_READ_IN_ONE_GO, full); 
        }

        public override ulong full_len {
            get { lock(this) return full_len_now_; }
        }
        
        public override ulong pos {
            get { lock(this) return offset_;  }
        }

        public override void force_reload() {
            lock (this) 
                if (offset_ == 0)
                    // we're already at beginning of file
                    return;
            on_rewritten_file();
        }


        // reads a file block from the file (as much as we can, in a single go)
        private void read_file_block() {
            try {
                if (file_encoding_ == null) {
                    var encoding = util.file_encoding(file_);
                    if ( encoding != null)
                        lock (this)
                            file_encoding_ = encoding;
                }

                long len = new FileInfo(file_).Length;
                bool file_rewritten = false;
                long offset;
                lock (this) offset = (long) read_byte_count_;
                using (var fs = new FileStream(file_, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    if (len > offset) {
                        long read_now = Math.Min( (long)MAX_READ_IN_ONE_GO, len - offset);
                        logger.Debug("[file] reading file " + file_ + " at " + offset + ", " + read_now  + " bytes.");
                        fs.Seek(offset, SeekOrigin.Begin);
                        int read_bytes = fs.Read(buffer_, 0, (int)read_now);
                        if (read_bytes >= 0) {
                            string now = file_encoding_.GetString(buffer_, 0, read_bytes);
                            lock (this) {
                                read_byte_count_ += (ulong) read_bytes;
                                last_part_ += now;
                            }
                        }
                    }
                    else if (len == offset) {
                        // file not changed - nothing to do
                    } else
                        file_rewritten = true;
                if ( file_rewritten)
                    on_rewritten_file();
            } catch(Exception e) {
                logger.Error("[file] can't read file - " + file_ + " : " + e.Message);
            }
        }

        public override bool is_up_to_date() {
            try {
                long len = new FileInfo(file_).Length;
                lock (this)
                    return read_byte_count_ == (ulong) len;
            } catch (FileNotFoundException fe) {
                // file may have been erased
                lock (this)
                    return read_byte_count_ == 0;
            }             
            catch (Exception e) {
                // in this case, maybe the file is locked - we'll try again next time
                return true;
            }
        }

        public override bool has_it_been_rewritten {
            get {
                bool has;
                lock (this) {
                    has = has_it_been_rewritten_;
                    has_it_been_rewritten_ = false;
                }
                return has;
            }
        }

        // file got rewritten from scratch - note: we preserve the log syntax
        private void on_rewritten_file() {
            logger.Info("[file] file rewritten - " + file_);
            lock (this) {
                // restart from beginning
                has_it_been_rewritten_ = true;
                read_byte_count_ = 0;
                offset_ = 0;
            }
            read_file_block();
        }

        public override string try_to_find_log_syntax() {
            if (cached_syntax_ != "")
                return cached_syntax_;

            try {
                using (var fs = new FileStream(file_, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                    string found = new find_log_syntax().try_find_log_syntax(fs);
                    if (found != UNKNOWN_SYNTAX)
                        cached_syntax_ = found;
                    return found;
                }
            } catch {
                return UNKNOWN_SYNTAX;
            }
        }


    }
}
