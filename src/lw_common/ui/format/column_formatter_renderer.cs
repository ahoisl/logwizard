﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace lw_common.ui.format {
    class column_formatter_renderer : BaseRenderer {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private log_view parent_;
        private log_view_item_draw_ui drawer_ = null;
        private solid_brush_list brush_ = new solid_brush_list();
        private column_formatter_array formatter_;
        private formatted_text  override_print_ = null;
        text_part default_ = new text_part(0, 0);
        private Color bg_color_ = util.transparent;
        private ObjectListView list_;

        public column_formatter_renderer(log_view parent, ObjectListView list) {
            parent_ = parent;
            list_ = list;
            drawer_ = new log_view_item_draw_ui(parent_);
            formatter_ = parent.formatter;
        }

        public column_formatter_array formatter {
            get { return formatter_; }
            set {
                formatter_ = value; 
            }
        }

        private void draw_sub_string(int left, string sub, Graphics g, Brush b, Rectangle r, StringFormat fmt, text_part print) {
            int width = drawer_.text_width(g, sub, drawer_.font(print));
            Color print_bg = drawer_.print_bg_color(ListItem, print);
            if (print_bg.ToArgb() != bg_color_.ToArgb()) {
                Rectangle here = new Rectangle(r.Location, r.Size);
                here.X += left;
                here.Width = width + 1;
                g.FillRectangle( brush_.brush( print_bg) , here);
            }

            Rectangle sub_r = new Rectangle(r.Location, r.Size);
            sub_r.X += left;
            sub_r.Width -= left;
            g.DrawString(sub, drawer_.font(print), brush_.brush( drawer_.print_fg_color(ListItem, print)) , sub_r, fmt);
        }


        private void draw_string(int left, string s, Graphics g, Brush b, Rectangle r, StringFormat fmt) {
            var prints = override_print_.parts(default_);
            foreach (var part in prints) {
                int left_offset = left + drawer_.text_offset(g, s.Substring(0, part.start), drawer_.font(part) );
                draw_sub_string(left_offset, part.text, g, b, r, fmt, part);
            }
        }

        // for each character of the printed text, see how many pixels it takes
        public List<int> text_widths(Graphics g ,string text) {
            List<int> widths = new List<int>();
            for ( int i = 0; i < text.Length; ++i)
                widths.Add( i > 0 ? drawer_.text_width(g, text.Substring(0, i)) : 0);
            return widths;
        }

        // 1.7.15 - make sure the line cell is fully drawn (height wize)
        protected override void DrawBackground(Graphics g, Rectangle r) {
            if (!this.IsDrawBackground)
                return;
            int PAD = 2;
            Color backgroundColor = this.GetBackgroundColor();
            using (Brush brush = new SolidBrush(backgroundColor)) {
                g.FillRectangle(brush, r.X - PAD, r.Y - PAD, r.Width + 2 * PAD, r.Height + 2 * PAD);
            }
        }

        private int top_idx() {
            int PAD = 5;
            var top = list_.GetItemAt(PAD, list_.HeaderControl.GetItemRect(0).Height + PAD);
            if (top == null)
                return 0;

            int top_idx = top.Index;
            if (top_idx < 0)
                top_idx = 0;

            return top_idx;
        }

        // IMPORTANT: here, when doing preview, we don't show any results from find/find-as-you-type/running filters
        private formatted_text override_print(match_item i, string text, int col_idx, column_formatter_base.format_cell.location_type location) {
            int row_idx = list_.IndexOf(i);
            Debug.Assert(row_idx >= 0);

            int top_row_idx = top_idx();
            string prev_text = "";
            if (row_idx > 0)
                prev_text = log_view_cell.cell_value( list_.GetItem(row_idx - 1).RowObject as match_item , col_idx);

            int sel_index = parent_.sel_row_idx_ui_thread;
            bool is_bokmark = parent_.has_bookmark(i.line_idx);

            var cell = new column_formatter_base.format_cell(i, parent_, col_idx, log_view_cell.cell_idx_to_type(col_idx), new formatted_text(text),
                row_idx, top_row_idx, sel_index, is_bokmark, prev_text, location);
            formatter_.format_before(cell);
            formatter_.format_after(cell);
            return cell.format_text;
        } 


        public override void Render(Graphics g, Rectangle r) {
            DrawBackground(g, r);

            var i = ListItem.RowObject as match_item;
            if (i == null)
                return;

            var col_idx = Column.fixed_index();
            string text = GetText();
            override_print_ = override_print(i, text, col_idx, column_formatter_base.format_cell.location_type.view);

            var type = log_view_cell.cell_idx_to_type(col_idx);
            if (info_type_io.can_be_multi_line(type)) 
                override_print_ = override_print_.get_most_important_single_line();
            text = override_print_.text;

            bg_color_ = drawer_.bg_color(ListItem, col_idx, override_print_);
            Brush brush = brush_.brush( bg_color_);
            g.FillRectangle(brush, r);

            StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap);
            fmt.LineAlignment = StringAlignment.Center;
            fmt.Trimming = override_print_.align == HorizontalAlignment.Left ? StringTrimming.EllipsisCharacter : StringTrimming.None;
            fmt.Alignment = StringAlignment.Near;

            int left = 0;
            if (override_print_.align != HorizontalAlignment.Left) {
                var full_text_size = drawer_.text_width(g, text, drawer_.font(override_print_.merge_parts));
                int width = r.Width;
                int extra = width - full_text_size;
                left = override_print_.align == HorizontalAlignment.Right ? extra - 5 : extra / 2;
            }

            draw_string(left, text, g, brush, r, fmt);
            draw_image(g, r);
        }

        private int image_width() {
            return override_print_.image != null ? override_print_.image.Width : 0;
        }

        private void draw_image(Graphics g, Rectangle r) {
            if (override_print_.image == null)
                return;

            string text = override_print_.text;
            int left = 0;
            if (override_print_.align != HorizontalAlignment.Left) {
                var full_text_size = drawer_.text_width(g, text, drawer_.font(override_print_.merge_parts)) + image_width();
                int width = r.Width;
                int extra = width - full_text_size;
                left = override_print_.align == HorizontalAlignment.Right ? extra - 5 : extra / 2;
            }
            g.DrawImage( override_print_.image, new Point(r.X + left, r.Y ));
        }

    }
}
