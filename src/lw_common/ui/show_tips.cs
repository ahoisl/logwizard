﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lw_common.ui {
    public class show_tips {
        private status_ctrl status_;

        private string[] tips_ = new[] {
            "LogWizard can be even faster! Here's how to use <a https://github.com/habjoc/logwizard/wiki/Hotkeys>Hotkeys</a>.",
            "Wanna edit filters? <a https://github.com/habjoc/logwizard/wiki/Filters>Here's a bit more info about it</a>.",
            "You can resize/move the columns around to suit your needs. Just right click on any column header!",
            "To open the Last Log, just do <b>Ctrl-H, Enter</b>",

            "Do you have columns that are multi-line? Just toggle the 'Details' pane on! <b>(Ctrl-D)</b>.\r\n." +
            "You can also edit which columns you want in the 'Details' pane - just right click it.",
            "Wanna open the Last Log? Do <b>Ctrl-H, Enter</b>!",
            "Want Pretty Formatting? Right click on Any column header, and select 'Edit Column Formatting'. Here's a bit of <a https://github.com/habjoc/logwizard/wiki/Formatters>help</a>",
        };

        private string[] tips_beginner_ = new[] {
            // 1.5.5 - at this time, we can't handle several links in one line
            "Drag and drop a file in order to view it in LogWizard. It's that easy :)",
            "Want to turn tips off? Go to Preferences -> top/right.",
            "Want to know more about the features implemented in the latest versions? Check out 'What's up' >> About page.",
            "You can toggle the Status pane on/off - just use Alt-S. However, at the beginning, I recommend you leave it on :P",
            "You can add notes to lines, and share them with your colleagues. <a http://www.github.com/habjoc/logwizard/Notes>Here's how</a>.",

            "Creating filters is a bliss. Select some text, and right click! More details <a http://www.github.com/habjoc/logwizard/Filters>here</a>",
            "You can easily view Windows Event Log(s)! Just hit Ctrl-O, and select 'Windows Event Log'...",

            "You can tweak your Description Pane to show <b>just what you want, the way you want it</b>. Right click on top-left, and select 'Edit Description Layout'.",

            "Want to filter in/out? Easy peasy! Select some text, and right click! More details <a http://www.github.com/habjoc/logwizard/Filters>here</a>",
            "Want to add a new view? Hover the top header - where 'Message X of Y' is written, and you'll see the '+' and '-' buttons, to add/remove views.",

            "Do you have columns that are multi-line? Just toggle the 'Details' pane on! <b>(Ctrl-D)</b>.\r\n." +
            "You can also edit which columns you want in the 'Details' pane - just right click it.",

            "You can just drop a file in order to view it in LogWizard. Or, you can <i>File >> Open Log</i>, if you want to tweak the Log Settings...",
            "You can at any time tweak the current Log Settings. Right click the top header (where Columns are shown), and select <i>Edit Log Settings</i>",

            "Want to have several Logs open at the same time?\r\n" +
            "You can open a new LogWizard window at any time by doing <i>File >> New LogWizard Window</i> or <b>Ctrl-N</b>.\r\n" +
            "Just open any Log in the newly opened Window. You can even access the History (Ctrl-H), as you normally would.",
            "Want Pretty Formatting? Right click on Any column header, and select 'Edit Column Formatting'. Here's a bit of <a https://github.com/habjoc/logwizard/wiki/Formatters>help</a>",
        };

        private const int MAX_BEGINNER_TIPS = 20;
        private readonly int AVG_TIP_INTERVAL_SECS = util.is_debug ? 30 : 15 * 60;
        private readonly int SHOW_TIP_SECS = util.is_debug ? 10 : 45;
        
        private DateTime show_tip_next_ = DateTime.MinValue;

        private Random random_ = new Random( (int)DateTime.Now.Ticks);

        public show_tips(status_ctrl status) {
            status_ = status;
            // wait just a short while, for the log status to be shown
            show_tip_next_ = DateTime.Now.AddSeconds(5);
        }

        // call this as many times as possible - it will show tips when it deems necessary
        public void handle_tips() {
            if (!app.inst.show_tips)
                return;

            if (DateTime.Now < show_tip_next_)
                return;
            // show tip now
            show_tip_next_ = DateTime.Now.AddSeconds( AVG_TIP_INTERVAL_SECS / 2 + random_.Next(AVG_TIP_INTERVAL_SECS / 2));

            var source = app.inst.run_count <= MAX_BEGINNER_TIPS ? tips_beginner_ : tips_;
            string tip = source[random_.Next(source.Length)];
            status_.set_status(" <b>Tip:</b> " + tip.Replace("\r\n", "\r\n <b>Tip:</b> "), status_ctrl.status_type.msg, SHOW_TIP_SECS * 1000);
        }
    }
}
