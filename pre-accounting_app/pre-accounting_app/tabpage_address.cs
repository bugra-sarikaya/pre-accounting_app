using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_address : TabPage {
        form_main form_main;
        Pen pen_textbox_input_country, pen_textbox_input_state, pen_textbox_input_city, pen_textbox_input_street, pen_textbox_input_postal_code, pen_textbox_input_postal_address;
        internal textbox_input textbox_input_country, textbox_input_state, textbox_input_city, textbox_input_street, textbox_postal_code, textbox_postal_address;
        int limit_down, limit_up;
        int width_pen = 6;
        int transition_value = 1;
        Color color_focus_textbox = Color.FromArgb(255, 173, 16, 23);
        internal tabpage_address(form_main form_main, TabControl tabcontrol) { // Constructor.
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
            Text = "Address";
            textbox_input_country = new textbox_input(200, 30, (Width - 200) / 2, vertical_gap_0, "Country");
            textbox_input_state = new textbox_input(textbox_input_country.Width, textbox_input_country.Height, textbox_input_country.Location.X, textbox_input_country.Location.Y + vertical_gap_1, "State");
            textbox_input_city = new textbox_input(textbox_input_state.Width, textbox_input_state.Height, textbox_input_state.Location.X, textbox_input_state.Location.Y + vertical_gap_2, "City");
            textbox_input_street = new textbox_input(textbox_input_city.Width, textbox_input_city.Height, textbox_input_city.Location.X, textbox_input_city.Location.Y + vertical_gap_3, "Street");
            textbox_postal_code = new textbox_input(textbox_input_street.Width, textbox_input_street.Height, textbox_input_street.Location.X, textbox_input_street.Location.Y + vertical_gap_4, "Postal Code");
            textbox_postal_address = new textbox_input(textbox_postal_code.Width, textbox_postal_code.Height, textbox_postal_code.Location.X, textbox_postal_code.Location.Y + vertical_gap_5, "Address");
            pen_textbox_input_country = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_state = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_city = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_street = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_postal_code = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_postal_address = new Pen(color_focus_textbox, width_pen);
            Controls.Add(textbox_input_country);
            Controls.Add(textbox_input_state);
            Controls.Add(textbox_input_city);
            Controls.Add(textbox_input_street);
            Controls.Add(textbox_postal_code);
            Controls.Add(textbox_postal_address);
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
            e.Graphics.DrawRectangle(pen_textbox_input_country, new Rectangle(textbox_input_country.Location.X, textbox_input_country.Location.Y, textbox_input_country.Width, textbox_input_country.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_state, new Rectangle(textbox_input_state.Location.X, textbox_input_state.Location.Y, textbox_input_state.Width, textbox_input_state.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_city, new Rectangle(textbox_input_city.Location.X, textbox_input_city.Location.Y, textbox_input_city.Width, textbox_input_city.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_street, new Rectangle(textbox_input_street.Location.X, textbox_input_street.Location.Y, textbox_input_street.Width, textbox_input_street.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_postal_code, new Rectangle(textbox_postal_code.Location.X, textbox_postal_code.Location.Y, textbox_postal_code.Width, textbox_postal_code.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_postal_address, new Rectangle(textbox_postal_address.Location.X, textbox_postal_address.Location.Y, textbox_postal_address.Width, textbox_postal_address.Height));
        }
        private void event_handler_timer(object sender, EventArgs e) { // Changing rectangle color smoothly.
            if (textbox_input_country.Focused) {
                if (pen_textbox_input_country.Width <= limit_up) {
                    pen_textbox_input_country.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_country.Width > limit_down) {
                    pen_textbox_input_country.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_input_state.Focused) {
                if (pen_textbox_input_state.Width <= limit_up) {
                    pen_textbox_input_state.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_state.Width > limit_down) {
                    pen_textbox_input_state.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_input_city.Focused) {
                if (pen_textbox_input_city.Width <= limit_up) {
                    pen_textbox_input_city.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_city.Width > limit_down) {
                    pen_textbox_input_city.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_input_street.Focused) {
                if (pen_textbox_input_street.Width <= limit_up) {
                    pen_textbox_input_street.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_street.Width > limit_down) {
                    pen_textbox_input_street.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_postal_code.Focused) {
                if (pen_textbox_input_postal_code.Width <= limit_up) {
                    pen_textbox_input_postal_code.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_postal_code.Width > limit_down) {
                    pen_textbox_input_postal_code.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_postal_address.Focused) {
                if (pen_textbox_input_postal_address.Width <= limit_up) {
                    pen_textbox_input_postal_address.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_postal_address.Width > limit_down) {
                    pen_textbox_input_postal_address.Width -= transition_value;
                    Refresh();
                }
            }
        }
    }
}