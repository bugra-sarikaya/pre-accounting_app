using System;
using System.Drawing;
using System.Windows.Forms;
namespace pre_accounting_app {
    internal class tabpage_payment : TabPage {
        form_main form_main;
        Pen pen_textbox_input_name, pen_textbox_input_card_number, pen_textbox_input_expiry_month, pen_textbox_input_expiry_year, pen_textbox_input_cvv;
        internal textbox_input textbox_input_card_name, textbox_input_card_number, textbox_input_expiry_month, textbox_input_expiry_year, textbox_postal_cvv;
        int limit_down, limit_up;
        int width_pen = 6;
        int transition_value = 1;
        Color color_focus_textbox = Color.FromArgb(255, 173, 16, 23);
        internal tabpage_payment(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            int vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3, vertical_gap_4, vertical_gap_5;
            vertical_gap_0 = 100;
            vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_5 = vertical_gap_4 = vertical_gap_3 = vertical_gap_2 = vertical_gap_1;
            limit_down = width_pen;
            limit_up = (int)(limit_down * 1.5f);
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            BackColor = Color.Transparent;
            Text = "Payment";
            textbox_input_card_name = new textbox_input(200, 30, (Width - 200) / 2, vertical_gap_0, "Name");
            textbox_input_card_number = new textbox_input(textbox_input_card_name.Width, textbox_input_card_name.Height, textbox_input_card_name.Location.X, textbox_input_card_name.Location.Y + vertical_gap_1, "Card Number");
            textbox_input_expiry_month = new textbox_input(textbox_input_card_number.Width, textbox_input_card_number.Height, textbox_input_card_number.Location.X, textbox_input_card_number.Location.Y + vertical_gap_2, "Expiry Month");
            textbox_input_expiry_year = new textbox_input(textbox_input_expiry_month.Width, textbox_input_expiry_month.Height, textbox_input_expiry_month.Location.X, textbox_input_expiry_month.Location.Y + vertical_gap_3, "Expiry Year");
            textbox_postal_cvv = new textbox_input(textbox_input_expiry_year.Width, textbox_input_expiry_year.Height, textbox_input_expiry_year.Location.X, textbox_input_expiry_year.Location.Y + vertical_gap_4, "CVV");
            pen_textbox_input_name = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_card_number = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_expiry_month = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_expiry_year = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_cvv = new Pen(color_focus_textbox, width_pen);
            Controls.Add(textbox_input_card_name);
            Controls.Add(textbox_input_card_number);
            Controls.Add(textbox_input_expiry_month);
            Controls.Add(textbox_input_expiry_year);
            Controls.Add(textbox_postal_cvv);
            Controls.Add(new button_next(form_main, tabcontrol));
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
            e.Graphics.DrawRectangle(pen_textbox_input_name, new Rectangle(textbox_input_card_name.Location.X, textbox_input_card_name.Location.Y, textbox_input_card_name.Width, textbox_input_card_name.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_card_number, new Rectangle(textbox_input_card_number.Location.X, textbox_input_card_number.Location.Y, textbox_input_card_number.Width, textbox_input_card_number.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_expiry_month, new Rectangle(textbox_input_expiry_month.Location.X, textbox_input_expiry_month.Location.Y, textbox_input_expiry_month.Width, textbox_input_expiry_month.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_expiry_year, new Rectangle(textbox_input_expiry_year.Location.X, textbox_input_expiry_year.Location.Y, textbox_input_expiry_year.Width, textbox_input_expiry_year.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_cvv, new Rectangle(textbox_postal_cvv.Location.X, textbox_postal_cvv.Location.Y, textbox_postal_cvv.Width, textbox_postal_cvv.Height));
        }
        private void event_handler_timer(object sender, EventArgs e) { // Changing rectangle color smoothly.
            if (textbox_input_card_name.Focused) {
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
            if (textbox_input_card_number.Focused) {
                if (pen_textbox_input_card_number.Width <= limit_up) {
                    pen_textbox_input_card_number.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_card_number.Width > limit_down) {
                    pen_textbox_input_card_number.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_input_expiry_month.Focused) {
                if (pen_textbox_input_expiry_month.Width <= limit_up) {
                    pen_textbox_input_expiry_month.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_expiry_month.Width > limit_down) {
                    pen_textbox_input_expiry_month.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_input_expiry_year.Focused) {
                if (pen_textbox_input_expiry_year.Width <= limit_up) {
                    pen_textbox_input_expiry_year.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_expiry_year.Width > limit_down) {
                    pen_textbox_input_expiry_year.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_postal_cvv.Focused) {
                if (pen_textbox_input_cvv.Width <= limit_up) {
                    pen_textbox_input_cvv.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_cvv.Width > limit_down) {
                    pen_textbox_input_cvv.Width -= transition_value;
                    Refresh();
                }
            }
        }
    }
}