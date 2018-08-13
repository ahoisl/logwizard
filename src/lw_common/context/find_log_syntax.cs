/* 
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
using SyntaxDetector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace lw_common {
    public class find_log_syntax {
        // 1.4.8+ the "syntax" applied only to line-by-line log files
        //        other types of logs can return "" if they can't find it
        public const string UNKNOWN_SYNTAX = "$msg[0]";

        public const int READ_TO_GUESS_SYNTAX = 8192;

        public string try_find_log_syntax_file(string file) {
            try {
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                    string found = try_find_log_syntax(fs);
                    if (found != UNKNOWN_SYNTAX)
                        return  found;
                }
            } catch {
            }            
            return UNKNOWN_SYNTAX;
        }

        public string try_find_log_syntax(FileStream fs) {
            try {
                var encoding = util.file_encoding(fs);
                if (encoding == null)
                    encoding = Encoding.Default;
                long pos = fs.Position;
                fs.Seek(0, SeekOrigin.Begin);
            
                // read a few lines from the beginning
                byte[] readBuffer = new byte[READ_TO_GUESS_SYNTAX];
                int bytes = fs.Read(readBuffer, 0, READ_TO_GUESS_SYNTAX);
                string now = encoding.GetString(readBuffer, 0, bytes);
                string[] lines = now.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                
                // go back to where we were
                fs.Seek(pos, SeekOrigin.Begin);
                string found = try_find_log_syntax(lines);
                return found;
            } catch {
                return UNKNOWN_SYNTAX;
            }
        }

        public string try_find_log_syntax(string[] lines) {
            return new SyntaxDetector.SyntaxDetector().DetectSyntax(lines);
        }

    }
}
