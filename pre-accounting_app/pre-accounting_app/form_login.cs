using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class form_login : Form {
        internal textbox_input textbox_username, textbox_password;
        Pen pen_textbox_username, pen_textbox_password;
        int alpha_username, alpha_password;
        int limit_reducer = 0;
        int transition_value = 17 * 5; // 17 is a divisor of 255.
        int width_pen = 4;
        Color color_focus_texbox = Color.FromArgb(255, 255, 255, 255);
        internal form_login() { // Constructor.
            alpha_username = alpha_password = 0;
            int initial_gap = 30;
            int second_gap = (int)(initial_gap * 1.5f);
            int third_gap = second_gap / 2;
            int fourth_gap = third_gap * 2;
            int final_gap = initial_gap;
            Width = 400;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            PictureBox logo_box = new PictureBox();
            string logo_address = "pictures\\logo.png";
            Image logo_image = Image.FromFile(logo_address);
            logo_box.Image = logo_image;
            float picturebox_width = Width * 0.64f;
            float scale = picturebox_width / logo_image.Width;
            logo_box.Size = new Size((int)picturebox_width, (int)(logo_image.Height * scale));
            logo_box.SizeMode = PictureBoxSizeMode.StretchImage;
            logo_box.Location = new Point((Width - logo_box.Width) / 2, initial_gap);
            textbox_username = new textbox_input((int)(logo_box.Width * 0.85f), 24, (Width - (int)(logo_box.Width * 0.85f)) / 2, logo_box.Location.Y + logo_box.Height + second_gap, "Username");
            textbox_password = new textbox_input(textbox_username.Width, textbox_username.Height, textbox_username.Location.X, textbox_username.Location.Y + textbox_username.Height + third_gap, "Password");
            pen_textbox_username = new Pen(Color.FromArgb(alpha_username, 255, 0, 0), width_pen);
            pen_textbox_password = new Pen(Color.FromArgb(alpha_password, 255, 0, 0), width_pen);
            button_submit_login button_submit = new button_submit_login((int)(textbox_password.Width * 0.7f), (int)(logo_box.Height * 0.8f), (Width - (int)(textbox_password.Width * 0.7f)) / 2, textbox_password.Location.Y + textbox_password.Height + fourth_gap, "Login", this);
            Height = button_submit.Location.Y + button_submit.Height + initial_gap;
            Controls.Add(new panel_top(this));
            Controls.Add(logo_box);
            Controls.Add(textbox_username);
            Controls.Add(textbox_password);
            Controls.Add(button_submit);
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Tick += event_handler_timer;
            MouseDown += event_handler_mouse_down;
            AcceptButton = button_submit; 
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Disabling focusing after pressing on form.
            ActiveControl = null;
        }
        protected override void OnPaint(PaintEventArgs e) { // Drawing rectangle.
            base.OnPaint(e);
            e.Graphics.DrawRectangle(pen_textbox_username, new Rectangle(textbox_username.Location.X, textbox_username.Location.Y, textbox_username.Width, textbox_username.Height));
            e.Graphics.DrawRectangle(pen_textbox_password, new Rectangle(textbox_password.Location.X, textbox_password.Location.Y, textbox_password.Width, textbox_password.Height));
        }
        private void event_handler_timer(object sender, EventArgs e) { // Changing rectangle color smoothly.
            if (textbox_username.Focused) {
                if (alpha_username <= 255 - transition_value - limit_reducer) {
                    alpha_username += transition_value;
                    pen_textbox_username.Color = Color.FromArgb(alpha_username, color_focus_texbox);
                    Refresh();
                }
            } else {
                if (alpha_username >= transition_value) {
                    alpha_username -= transition_value;
                    pen_textbox_username.Color = Color.FromArgb(alpha_username, color_focus_texbox);
                    Refresh();
                }
            }
            if (textbox_password.Focused) {
                if (alpha_password <= 255 - transition_value - limit_reducer) {
                    alpha_password += transition_value;
                    pen_textbox_password.Color = Color.FromArgb(alpha_password, color_focus_texbox);
                    Refresh();
                }
            } else {
                if (alpha_password >= transition_value) {
                    alpha_password -= transition_value;
                    pen_textbox_password.Color = Color.FromArgb(alpha_password, color_focus_texbox);
                    Refresh();
                }
            }
        }
    }
}