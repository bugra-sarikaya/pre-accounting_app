using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_customer : TabPage {
        form_main form_main;
        Pen pen_textbox_input_name, pen_textbox_input_surname, pen_textbox_input_personal_id, pen_textbox_input_tel, pen_textbox_input_email;
        internal textbox_input textbox_input_name, textbox_input_surname, textbox_input_personal_id, textbox_input_tel, textbox_input_email;
        int limit_down, limit_up;
        int width_pen = 6;
        int transition_value = 1;
        Color color_focus_textbox = Color.FromArgb(255, 173, 16, 23);
        internal tabpage_customer(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            int vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3, vertical_gap_4;
            vertical_gap_0 = 100;
            vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_4 = vertical_gap_3 = vertical_gap_2 = vertical_gap_1;
            limit_down = width_pen;
            limit_up = (int)(limit_down * 1.5f);
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            BackColor = Color.Transparent;
            Text = "Customer";
            textbox_input_name = new textbox_input(200, 30, (Width - 200) / 2, vertical_gap_0, "Name");
            textbox_input_surname = new textbox_input(textbox_input_name.Width, textbox_input_name.Height, textbox_input_name.Location.X, textbox_input_name.Location.Y + vertical_gap_1, "Surname");
            textbox_input_personal_id = new textbox_input(textbox_input_surname.Width, textbox_input_surname.Height, textbox_input_surname.Location.X, textbox_input_surname.Location.Y + vertical_gap_2, "Personal ID");
            textbox_input_tel = new textbox_input(textbox_input_personal_id.Width, textbox_input_personal_id.Height, textbox_input_personal_id.Location.X, textbox_input_personal_id.Location.Y + vertical_gap_3, "Telephone");
            textbox_input_email = new textbox_input(textbox_input_tel.Width, textbox_input_tel.Height, textbox_input_tel.Location.X, textbox_input_tel.Location.Y + vertical_gap_4, "E-mail");
            pen_textbox_input_name = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_surname = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_personal_id = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_tel = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_email = new Pen(color_focus_textbox, width_pen);
            Controls.Add(textbox_input_name);
            Controls.Add(textbox_input_surname);
            Controls.Add(textbox_input_personal_id);
            Controls.Add(textbox_input_tel);
            Controls.Add(textbox_input_email);
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
            e.Graphics.DrawRectangle(pen_textbox_input_name, new Rectangle(textbox_input_name.Location.X, textbox_input_name.Location.Y, textbox_input_name.Width, textbox_input_name.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_surname, new Rectangle(textbox_input_surname.Location.X, textbox_input_surname.Location.Y, textbox_input_surname.Width, textbox_input_surname.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_personal_id, new Rectangle(textbox_input_personal_id.Location.X, textbox_input_personal_id.Location.Y, textbox_input_personal_id.Width, textbox_input_personal_id.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_tel, new Rectangle(textbox_input_tel.Location.X, textbox_input_tel.Location.Y, textbox_input_tel.Width, textbox_input_tel.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_email, new Rectangle(textbox_input_email.Location.X, textbox_input_email.Location.Y, textbox_input_email.Width, textbox_input_email.Height));
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
            if (textbox_input_surname.Focused) {
                if (pen_textbox_input_surname.Width <= limit_up) {
                    pen_textbox_input_surname.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_surname.Width > limit_down) {
                    pen_textbox_input_surname.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_input_personal_id.Focused) {
                if (pen_textbox_input_personal_id.Width <= limit_up) {
                    pen_textbox_input_personal_id.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_personal_id.Width > limit_down) {
                    pen_textbox_input_personal_id.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_input_tel.Focused) {
                if (pen_textbox_input_tel.Width <= limit_up) {
                    pen_textbox_input_tel.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_tel.Width > limit_down) {
                    pen_textbox_input_tel.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_input_email.Focused) {
                if (pen_textbox_input_email.Width <= limit_up) {
                    pen_textbox_input_email.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_email.Width > limit_down) {
                    pen_textbox_input_email.Width -= transition_value;
                    Refresh();
                }
            }
        }
    }
}