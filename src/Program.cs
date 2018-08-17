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
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using log4net;
using lw_common;

namespace LogWizard
{
    static class Program
    {

        public static string open_file_name {
            get { return open_file_name_; }
        }


        private static string open_file_name_ = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            //util.test_normalized_times();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // uncomment this to test how we'd behave in release
            // util.is_debug = false;

            util.set_current_dir();
            util.init_log();
            string sett_file = util.is_debug ? "logwizard_debug" : "logwizard_user";
            util.create_backup(sett_file, ".txt", 15);
            app.inst.init( new settings_file(sett_file + ".txt") );

            util.force_break_into_debugger();
            util.init_exceptions();

            // if "Open With" and LogWizard is already running -> send this to the existing running application
            // the reason for this: if multiple instances running, they can mess up the settings file - we don't want that!
            if (!util.is_debug) {
                var running_already = Process.GetProcessesByName("LogWizard").ToDictionary(x => x.Id, x => x);
                running_already.Remove(Process.GetCurrentProcess().Id);
                if (running_already.Count > 0) {
                    // there's another instance running
                    if (args.Length == 0)
                        // just let the other instance run
                        return;
                    // for the other instance - what to open
                    string open = args[0];

                    var cds = new win32.COPYDATASTRUCT {
                        dwData = new IntPtr(0),
                        cbData = open.Length * 2 + 1,
                        lpData = open
                    };
                    var handle = running_already.First().Value.MainWindowHandle;
                    win32.SendMessage(handle, win32.WM_COPYDATA, IntPtr.Zero, ref cds);
                    return;
                }
            }

            if ( args.Length > 0 && File.Exists(args[0]))
                open_file_name_ = args[0];

            if (open_file_name_ != null)
                wait_for_setup_kit_to_complete();

            Application.Run(new Dummy());
        }

        private static void wait_for_setup_kit_to_complete() {
            Process setup = find_kit("Log Wizard Setup");
            while ( setup != null && !setup.HasExited)
                Thread.Sleep(100);
        }

        private static Process find_kit(string title) {
            foreach (Process p in Process.GetProcesses())
                if (p.MainWindowTitle.StartsWith(title)) 
                    return p;
            return null;
        }
    }
}
