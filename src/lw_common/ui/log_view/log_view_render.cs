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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using lw_common;
using lw_common.ui.format;

namespace lw_common.ui {
    class log_view_render : BaseRenderer {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private log_view parent_;
        private log_view_item_draw_ui drawer_ = null;

        public log_view_render(log_view parent) {
            parent_ = parent;
            drawer_ = new log_view_item_draw_ui(parent_);            
        }

        public void set_font(Font f) {
            drawer_.set_font(f);
        }

        private formatted_text  override_print_ = null;
        text_part default_ = new text_part(0, 0);

        private void draw_sub_string(int left, string sub, Graphics g, Brush b, Rectangle r, StringFormat fmt, text_part print) {
            int width = text_width(g, sub);
            if (print != default_) {
                Rectangle here = new Rectangle(r.Location, r.Size);
                here.X += left;
                here.Width = width + 1;
                g.FillRectangle( drawer_.print_bg_brush(ListItem, print) , here);
            }

            Rectangle sub_r = new Rectangle(r.Location, r.Size);
            sub_r.X += left;
            sub_r.Width -= left;
            g.DrawString(sub, drawer_.font(print), drawer_.print_fg_brush(ListItem, print) , sub_r, fmt);
        }


        private void draw_string(int left, string s, Graphics g, Brush b, Rectangle r, StringFormat fmt) {
            var prints = override_print_.parts(default_);
            string prev_text = "";
            foreach (var part in prints) {
                int left_offset = left + text_width(g, s.Substring(0, part.start) );
                if (part.start > 0)
                    // 1.7.8+ a few pixels are simply ignored when starting to draw. However, when drawing one thing after another, we don't want gaps
                    left_offset -= 4;
                draw_sub_string(left_offset, part.text, g, b, r, fmt, part);
            }
        }

        private int text_width(Graphics g, string text) {
            return drawer_.text_width(g, text);
        }


        private int char_size(Graphics g) {
            return drawer_.char_size(g);
        }

        // for each character of the printed text, see how many pixels it takes
        public List<int> text_widths(Graphics g ,string text) {
            List<int> widths = new List<int>();
            for ( int i = 0; i < text.Length; ++i)
                widths.Add( i > 0 ? text_width(g, text.Substring(0, i)) : 0);
            return widths;
        } 

        public override void Render(Graphics g, Rectangle r) {
            // 1.3.30+ solved rendering issue :)
            DrawBackground(g, r);

            var i = ListItem.RowObject as match_item;
            if (i == null)
                return;

            var col_idx = Column.fixed_index();
            string text = GetText();
            override_print_ = i.override_print(parent_, text, col_idx);

            var type = log_view_cell.cell_idx_to_type(col_idx);
            if (info_type_io.can_be_multi_line(type)) 
                override_print_ = override_print_.get_most_important_single_line();
            text = override_print_.text;

            Brush brush = drawer_.bg_brush(ListItem, col_idx);
            g.FillRectangle(brush, r);

            StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap);
            fmt.LineAlignment = StringAlignment.Center;
            fmt.Trimming = StringTrimming.EllipsisCharacter;
            switch (this.Column.TextAlign) {
                case HorizontalAlignment.Center: fmt.Alignment = StringAlignment.Center; break;
                case HorizontalAlignment.Left: fmt.Alignment = StringAlignment.Near; break;
                case HorizontalAlignment.Right: fmt.Alignment = StringAlignment.Far; break;
            }

            draw_string(0, text, g, brush, r, fmt);
        }
    }

}
