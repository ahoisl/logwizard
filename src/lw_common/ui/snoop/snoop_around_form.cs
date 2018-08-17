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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lw_common.ui.snoop;

namespace lw_common.ui {
    // note: the reason this is a form is that we should not tie it to a control - it might end up exceeding the control's boundaries
    public partial class snoop_around_form : Form {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // the control this form conceptually belongs to - the coordinates we relate to are always given relative to this
        private Control logical_parent_ = null;

        private Rectangle logical_parent_rect_ = new Rectangle();

        // the expander form
        private readonly snoop_around_expander_ctrl expander_;

        private bool expanded_ = false;

        // if selection is empty -> no selection
        // if used = true -> use selection; if used = false -> selection is not used (filter is not applied)
        //
        // note: we send the selection, even if it's unused (so that it can be cached and reused)
        public delegate void on_apply_func(snoop_around_form self, List<string> selection, bool used);

        public on_apply_func on_apply;

        // this contains the "visible" property of the whole form + expander form 
        //
        // when we're collapsed, we're partially visible (this form is invisible, but the expander is visible)
        // when this is set to false, both form+explaner form are invisible, regardless of expanded/collapsed
        private bool is_visible_ = true;

        private readonly int min_width_;

        //             the keep_running=false can happen when the user goes somewhere else, while we're snooping (thus, we're collapsed)
        public delegate void on_snoop_func(snoop_around_form self, ref bool keep_running);

        public on_snoop_func on_snoop;

        // how many values do we allow? (we don't visually show more than this)

        private bool too_many_distinct_values_ = false;

        private bool finished_ = false;
        private bool snooped_all_rows_ = false;

        private DateTime deactivated_time_ = DateTime.MinValue;

        private int ignore_change_ = 0;

        private class bool_box {
            public bool keep_running = true;
        }
        // signal the snoop function to stop
        private bool_box stop_snoop_ = new bool_box();

        private class snoop_item {
            public int number { get; set; } = 0;

            public string value { get; set; } = "";

            public string count { get; set; } = "";

            public bool is_checked { get; set; } = false;
        }

        public snoop_around_form() {
            InitializeComponent();
            expander_ = new snoop_around_expander_ctrl(this) { BorderStyle = BorderStyle.None };

            min_width_ = clearFilter.Right - all.Left;

            // I need to force this form to be visible for a bit, so that the handle is created, so that .Invoke works correctly
            Location = new Point(-100000, -100000);
            Visible = true;
            util.postpone(() => Visible = false, 1);

            is_visible = true;
        }

        public Rectangle logical_parent_rect => logical_parent_rect_;

        // this way, I can change the parent as well!
        public void set_parent_rect(Control logical_parent, Rectangle rect) {
            if (logical_parent != logical_parent_) {
                if (logical_parent_ != null) {
                    logical_parent_.Move -= Logical_parent_on_move;
                    logical_parent_.Resize -= Logical_parent_on_move;
                    logical_parent_.VisibleChanged -= Logical_parent_on_visible_changed;
                }
                expander_.Parent = logical_parent;
                logical_parent_ = logical_parent;
                logical_parent_.Move += Logical_parent_on_move;
                logical_parent_.Resize += Logical_parent_on_move;
                logical_parent_.VisibleChanged += Logical_parent_on_visible_changed;
            }

            if (logical_parent_rect_ != rect) {
                logical_parent_rect_ = rect;
                // basically, any time we're moved to another position - we'll hide - it means only the expander will be shown
                expanded = false;
                update_pos();
            }
        }

        private void Logical_parent_on_visible_changed(object sender, EventArgs event_args) {
            update_visible();
        }

        private void Logical_parent_on_move(object sender, EventArgs event_args) {
            on_parent_move();
        }

        public Rectangle screen_logical_parent_rect => logical_parent_ != null && logical_parent_rect_.Width > 0 && logical_parent_rect_.Height > 0
                                                       ? logical_parent_.RectangleToScreen(logical_parent_rect_)
                                                       : Rectangle.Empty;

        public bool expanded {
            get => expanded_;
            set {
                if (expanded_ == value)
                    return;
                expanded_ = value;
                expander_.show_filter = !expanded_ && can_apply_filter();
                do_snoop(expanded_);
                update_pos();
            }
        }

        public bool is_visible {
            get => is_visible_;
            set {
                is_visible_ = value;
                update_visible();
            }
        }

        public int max_distinct_values_count { get; set; } = 50;

        protected override bool ShowWithoutActivation => true; // stops the window from stealing focus

        const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams {
            get {
                var Params = base.CreateParams;
                Params.ExStyle |= WS_EX_NOACTIVATE;
                return Params;
            }
        }

        private void do_snoop(bool start) {
            if (snooped_all_rows_)
                // at this point, we know all rows have been snooped, so there's no point in ever snooping again
                return;

            if (start) {
                finished_ = false;
                // ... just in case
                stop_snoop_.keep_running = false;
                // we're starting a new snoop
                stop_snoop_ = new bool_box();
                Task.Run(() => on_snoop(this, ref stop_snoop_.keep_running));
            } else
                // force stop snooping - user has collapsed us
                stop_snoop_.keep_running = false;
        }

        // ... just in case we need to reuse this for another filter or so
        public void clear() {
            stop_snoop_.keep_running = false;
            snooped_all_rows_ = false;
            list.Items.Clear();
        }

        private bool can_apply_filter() {
            if (list.GetItemCount() < 1)
                return false; // nothing to filter

            int is_checked = 0, is_unchecked = 0;
            for (int idx = 0; idx < list.GetItemCount(); ++idx) {
                var i = list.GetItem(idx).RowObject as snoop_item;
                if (i.is_checked)
                    is_checked++;
                else
                    is_unchecked++;
            }
            int all = is_checked + is_unchecked;
            // at least one needs to be checked, and at least one needs to unchecked
            return is_checked > 0 && is_checked < all;
        }

        private void update_visible() {
            Visible = is_visible_ && expanded_ && logical_parent_ != null && logical_parent_.Visible && logical_parent_.Width > 0;
            expander_.Visible = is_visible_ && logical_parent_ != null && logical_parent_.Visible && logical_parent_.Width > 0;
        }

        public void set_values(Dictionary<string, int> values, bool finished, bool snooped_all_rows) {
            if (snooped_all_rows)
                Debug.Assert(finished);
            this.async_call(() => set_values_impl(values, finished, snooped_all_rows));
        }

        public void reuse_last_values() {
            finished_ = true;
        }

        // important: we visually sort them!
        private void set_values_impl(Dictionary<string, int> values, bool finished, bool snooped_all_rows) {
            too_many_distinct_values_ = values.Count > max_distinct_values_count;
            finished_ = finished;
            snooped_all_rows_ = snooped_all_rows;

            while (values.Count > max_distinct_values_count) {
                int min = values.Values.Min();
                var erase = values.First(x => x.Value == min).Key;
                values.Remove(erase);
            }

            list.SuspendLayout();

            int sel = list.SelectedIndex;
            string former_sel = "";
            if (sel >= 0)
                former_sel = (list.GetItem(sel).RowObject as snoop_item).value;

            // find out the existing items 
            SortedDictionary<string, int> value_to_index = new SortedDictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
            // just in case we're snooping, and there was a former snoop - we keep existing entries...
            // but, when the snoop is over, anything that found 0 results, is removed from the list
            int values_contain_existing_count = 0;
            for (int idx = 0; idx < list.GetItemCount(); ++idx) {
                var value = (list.GetItem(idx).RowObject as snoop_item).value;
                if (values.ContainsKey(value))
                    ++values_contain_existing_count;
                value_to_index.Add(value, idx);
            }
            if (finished && values.Count > values_contain_existing_count) {
                // there were some rows with "zero" count - remove them completely
                list.Items.Clear();
                value_to_index.Clear();
            }

            foreach (string value in values.Keys)
                if (!value_to_index.ContainsKey(value))
                    value_to_index.Add(value, -1);

            // snooped_all_rows - if false, we always append "+" to the count. Otherwise, we print only the count
            int offset = 0;
            int new_sel_idx = -1;
            foreach (var val_and_idx in value_to_index) {
                string value = val_and_idx.Key;
                int count = values.ContainsKey(value) ? values[value] : 0;
                if (val_and_idx.Value < 0)
                    list.InsertObjects(offset, new[] { new snoop_item() });
                var i = list.GetItem(offset).RowObject as snoop_item;
                i.number = offset + 1;
                i.value = value;
                i.count = "" + count + (finished && snooped_all_rows ? "" : "+");
                if (value == former_sel)
                    new_sel_idx = offset;
                list.RefreshObject(i);
                ++offset;
            }

            if (new_sel_idx >= 0)
                list.SelectedIndex = new_sel_idx;

            list.ResumeLayout(true);
        }

        private void update_pos() {
            if (!is_visible_) {
                Debug.Assert(!Visible && !expander_.Visible);
                return;
            }

            update_visible();
            // update position of expander as well
            expander_.update_pos();

            var above = screen_logical_parent_rect;
            int left = above.Left;
            int top = above.Bottom;
            Location = new Point(left, top);
            Size = new Size(Math.Max(above.Width, min_width_), Height);

            if (expanded && Visible) {
                BringToFront();
                list.Focus();
            }
        }

        private void on_parent_move() {
            Visible = false;
        }

        private void snoop_around_form_VisibleChanged(object sender, EventArgs e) {
        }

        internal void on_click_expand() {
            if (deactivated_time_.AddMilliseconds(250) > DateTime.Now)
                // user clicked on "Expanded" button to actually collapse us - but we also received the "Deactivate" event
                return;
            expanded = !expanded;
            // need to figure a way to continue an existing process or re-start a new one
        }

        internal void on_click_apply() {
            if (ignore_change_ > 0)
                return;
            expanded = false;
            List<string> is_checked = new List<string>(), is_unchecked = new List<string>();
            for (int idx = 0; idx < list.GetItemCount(); ++idx) {
                var i = list.GetItem(idx).RowObject as snoop_item;
                if (i.is_checked)
                    is_checked.Add(i.value);
                else
                    is_unchecked.Add(i.value);
            }
            int all = is_checked.Count + is_unchecked.Count;
            // if all checked or all unchecked, nothing is selected
            bool any_selection = (is_checked.Count < all && is_unchecked.Count < all);
            bool used = expander_.filter_pressed;
            if (!any_selection)
                used = false;

            logger.Debug("snoop filter: [" + util.concatenate(is_checked, ",") + "]");
            if (on_apply != null)
                on_apply(this, is_checked, used);
        }

        private void snoop_around_form_Deactivate(object sender, EventArgs e) {
            deactivated_time_ = DateTime.Now;
            util.postpone(() => expanded = false, 10);
        }

        private void updateStatus_Tick(object sender, EventArgs e) {
            if (!expanded)
                return;

            List<string> is_checked = new List<string>(), is_unchecked = new List<string>();
            for (int idx = 0; idx < list.GetItemCount(); ++idx) {
                var i = list.GetItem(idx).RowObject as snoop_item;
                if (i.is_checked)
                    is_checked.Add(i.value);
                else
                    is_unchecked.Add(i.value);
            }

            string status_text = too_many_distinct_values_ ? "Too Many Values! " : "";
            string status_tip = "";
            if (finished_) {
                status_text += "Filtering by: ";
                int all = is_checked.Count + is_unchecked.Count;
                if (is_checked.Count < all && is_unchecked.Count < all) {
                    status_text += is_checked.Count < is_unchecked.Count
                        ? (is_checked.Count == 1 ? "Value is " : "Any of ") + util.concatenate(is_checked, ", ") :
                          (is_unchecked.Count == 1 ? "Value is NOT " : "None of ") + util.concatenate(is_unchecked, ", ");
                    status_tip = is_checked.Count < is_unchecked.Count
                        ? "Any of \r\n" + util.concatenate(is_checked, "\r\n") : "None of \r\n" + util.concatenate(is_unchecked, "\r\n");
                    int max_chars = 400;
                    status_tip = status_tip.Length > max_chars ? status_tip.Substring(0, max_chars) : status_tip;
                } else
                    status_text += "Nothing yet";
            } else
                status_text += "Snooping around" + util.ellipsis_suffix();
            status.Text = status_text;
            if (status_tip == "")
                status_tip = status_text;
            tip.SetToolTip(status, status_tip);
        }

        private void all_Click(object sender, EventArgs e) {
            for (int idx = 0; idx < list.GetItemCount(); ++idx) {
                var i = list.GetItem(idx).RowObject as snoop_item;
                i.is_checked = true;
                list.RefreshObject(i);
            }
        }

        private void none_Click(object sender, EventArgs e) {
            for (int idx = 0; idx < list.GetItemCount(); ++idx) {
                var i = list.GetItem(idx).RowObject as snoop_item;
                i.is_checked = false;
                list.RefreshObject(i);
            }
        }

        private void negate_Click(object sender, EventArgs e) {
            for (int idx = 0; idx < list.GetItemCount(); ++idx) {
                var i = list.GetItem(idx).RowObject as snoop_item;
                i.is_checked = !i.is_checked;
                list.RefreshObject(i);
            }
        }

        private void clear_Click(object sender, EventArgs e) {
            // clears the filter - shows all items
            Visible = false;
            ++ignore_change_;
            expander_.filter_pressed = false;
            --ignore_change_;
            on_click_apply();
        }

        private void run_Click(object sender, EventArgs e) {
            // applies the current filter
            ++ignore_change_;
            expander_.filter_pressed = true;
            --ignore_change_;
            on_click_apply();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.F4 | Keys.Alt))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
