using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class form_login : Form {
        Pen pen_logo_box, pen_textbox_input_username, pen_textbox_input_password;
        PictureBox logo_box;
        internal textbox_input textbox_username, textbox_password;
        int limit_down, limit_up;
        int width_pen = 6;
        int transition_value = 1;
        Color color_focus_textbox = Color.FromArgb(255, 173, 16, 23);
        internal form_login() { // Constructor.
            int initial_gap = 50;
            int second_gap = (int)(initial_gap * 1.0f);
            int third_gap = second_gap / 2;
            int fourth_gap = third_gap * 2;
            int final_gap = initial_gap;
            limit_down = width_pen;
            limit_up = (int)(limit_down * 1.3f);
            Width = 400;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            logo_box = new PictureBox();
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
            pen_logo_box = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_username = new Pen(color_focus_textbox, width_pen);
            pen_textbox_input_password = new Pen(color_focus_textbox, width_pen);
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
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Disabling focusing after pressing on form.
            ActiveControl = null;
        }
        protected override void OnPaint(PaintEventArgs e) { // Drawing rectangle.
            base.OnPaint(e);
            GraphicsPath graphicspath = create_rounded_rectangle(new RectangleF(0, 0, Width, Height), 16);
            Region = new Region(graphicspath);
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 173, 16, 23), 7.0f), graphicspath);
            e.Graphics.DrawRectangle(pen_logo_box, new Rectangle(logo_box.Location.X, logo_box.Location.Y, logo_box.Width, logo_box.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_username, new Rectangle(textbox_username.Location.X, textbox_username.Location.Y, textbox_username.Width, textbox_username.Height));
            e.Graphics.DrawRectangle(pen_textbox_input_password, new Rectangle(textbox_password.Location.X, textbox_password.Location.Y, textbox_password.Width, textbox_password.Height));
        }
        private void event_handler_timer(object sender, EventArgs e) { // Changing rectangle color smoothly.
            if (textbox_username.Focused) {
                if (pen_textbox_input_username.Width <= limit_up) {
                    pen_textbox_input_username.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_username.Width > limit_down) {
                    pen_textbox_input_username.Width -= transition_value;
                    Refresh();
                }
            }
            if (textbox_password.Focused) {
                if (pen_textbox_input_password.Width <= limit_up) {
                    pen_textbox_input_password.Width += transition_value;
                    Refresh();
                }
            } else {
                if (pen_textbox_input_password.Width > limit_down) {
                    pen_textbox_input_password.Width -= transition_value;
                    Refresh();
                }
            }
        }
        private GraphicsPath create_rounded_rectangle(RectangleF rectanglef, int r, bool fill = false) { // Creating rounded rectangle.
            GraphicsPath path = new GraphicsPath();
            var r2 = r / 2;
            var fix = fill ? 1 : 0;
            rectanglef.Location = new Point((int)(rectanglef.X - 1), (int)(rectanglef.Y - 1));
            if (!fill) rectanglef.Size = new Size((int)(rectanglef.Width - 1), (int)(rectanglef.Height - 1));
            path.AddArc(rectanglef.Left, rectanglef.Top, r, r, 180, 90);
            path.AddLine(rectanglef.Left + r2, rectanglef.Top, rectanglef.Right - r2 - fix, rectanglef.Top);
            path.AddArc(rectanglef.Right - r - fix, rectanglef.Top, r, r, 270, 90);
            path.AddLine(rectanglef.Right, rectanglef.Top + r2, rectanglef.Right, rectanglef.Bottom - r2);
            path.AddArc(rectanglef.Right - r - fix, rectanglef.Bottom - r - fix, r, r, 0, 90);
            path.AddLine(rectanglef.Right - r2, rectanglef.Bottom, rectanglef.Left + r2, rectanglef.Bottom);
            path.AddArc(rectanglef.Left, rectanglef.Bottom - r - fix, r, r, 90, 90);
            path.AddLine(rectanglef.Left, rectanglef.Bottom - r2, rectanglef.Left, rectanglef.Top + r2);
            return path;
        }
    }
}