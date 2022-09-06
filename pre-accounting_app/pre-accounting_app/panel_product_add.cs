using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_product_add : Panel {
        button_return button_return;
        button_submit_product_add button_submit_product_add;
        form_main form_main;
        Pen pen_textbox_input_name, pen_textbox_input_price;
        textbox_input textbox_input_name, textbox_input_price;
        int limit_down, limit_up;
        int width_pen = 6;
        int transition_value = 1;
        Color color_focus_textbox = Color.FromArgb(255, 173, 16, 23);
        internal panel_product_add(form_main form_main, panel_top panel_top) { // Constructor.
            this.form_main = form_main;
            int vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3;
            vertical_gap_0 = 100;
            vertical_gap_2 = vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_3 = (int)(vertical_gap_2 * 1.5f);
            limit_down = width_pen;
            limit_up = (int)(limit_down * 1.5f);
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Location = new Point(0, panel_top.Height);
            BackColor = Color.Transparent;
            Name = "add_product";
            textbox_input_name = new textbox_input(200, 30, (Width - 200) / 2, vertical_gap_0, "Name");
            textbox_input_price = new textbox_input(textbox_input_name.Width, textbox_input_name.Height, textbox_input_name.Location.X, textbox_input_name.Location.Y + vertical_gap_1, "Price");
            pen_textbox_input_name = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_price = new Pen(color_focus_textbox, width_pen);
            button_return = new button_return(form_main, this, panel_top);
            button_submit_product_add = new button_submit_product_add(150, 40, (Width - 150) / 2, textbox_input_price.Location.Y + vertical_gap_3, textbox_input_name, textbox_input_price, button_return);
            Controls.Add(textbox_input_name);
            Controls.Add(textbox_input_price);
            Controls.Add(button_submit_product_add);
            Controls.Add(button_return);
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Tick += event_handler_timer;
            MouseDown += event_handler_mouse_down;
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Disabling focusing after pressing on form.
            form_main.event_handler_mouse_down(sender, e);
        }
        protected override void OnPaint(PaintEventArgs e) { // Drawing rectangle.
            base.OnPaint(e);
            e.Graphics.DrawRectangle(pen_textbox_input_name, new Rectangle(textbox_input_name.Location.X, textbox_input_name.Location.Y, textbox_input_name.Width, textbox_input_name.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_price, new Rectangle(textbox_input_price.Location.X, textbox_input_price.Location.Y, textbox_input_price.Width, textbox_input_price.Height));
        }
        private void event_handler_timer(object sender, EventArgs e) { // Changing rectangle color smoothly.
            if (textbox_input_name.Focused) {
                if (pen_textbox_input_name.Width <= limit_up) {
                    pen_textbox_input_name.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_name.Width > limit_down) {
                    pen_textbox_input_name.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_input_price.Focused) {
                if (pen_textbox_input_price.Width <= limit_up) {
                    pen_textbox_input_price.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_price.Width > limit_down) {
                    pen_textbox_input_price.Width -= transition_value;
                    Refresh();
                }
            }
        }
    }
}