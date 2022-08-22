using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace pre_accounting_app {
    internal class button_minimize : Button {
        int blue = 0;
        int limit_reducer = 0;
        int transition_value = 17 * 5; // 17 is a divisor of 255.
        Bitmap bitmap_minimize_symbol;
        internal button_minimize(button_close button_close) { // Constructor
            float scale = 0.75f;
            Width = button_close.Height;
            Height = Width;
            Location = new Point(button_close.Location.X - Width - button_close.gap, button_close.Location.Y);
            string address_minimize_symbol = "pictures\\minimize_symbol.png";
            Image minimize_symbol = Image.FromFile(address_minimize_symbol);
            bitmap_minimize_symbol = new Bitmap(minimize_symbol, new Size((int)(Width * scale), (int)(Height * scale)));
            Image = bitmap_minimize_symbol;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Tick += timer_event;
            MouseClick += mouse_clicked_event;
            MouseDown += mouse_down_event;
            MouseLeave += mouse_leave_event;
        }
        private bool mouse_is_over_button(button_minimize button) { // Detecting situation of hovering mouse cursor over button.
            return button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
        }
        private void timer_event(object sender, EventArgs e) { // Enabling hovering mouse cursor effect smoothly.
            if (mouse_is_over_button(this) && blue < 255 - transition_value - limit_reducer) {
                blue += transition_value;
                Image = change_blue_color(bitmap_minimize_symbol, blue);
                Refresh();
            } else if (!mouse_is_over_button(this) && blue >= transition_value) {
                blue -= transition_value;
                Image = change_blue_color(bitmap_minimize_symbol, blue);
                Refresh();
            }
        }
        private void mouse_clicked_event(object sender, MouseEventArgs e) { // Minimizing applicaiton if button is clicked with left mouse button.
            ((Form)Parent.Parent).WindowState = FormWindowState.Minimized;
        }
        private void mouse_down_event(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            if (mouse_is_over_button(this) && e.Button == MouseButtons.Left) {
                Image = change_blue_color(bitmap_minimize_symbol, blue - transition_value);
                Refresh();
                limit_reducer = transition_value;
            }
        }
        private void mouse_leave_event(object sender, EventArgs e) { //Disabling pressing button effect.
            limit_reducer = 0;
        }
        private Bitmap change_blue_color(Bitmap bitmap_image, int blue) { // Changing blue color value of image.
            Color color_pixel;
            for (int i = 0; i < bitmap_image.Width; i++) {
                for (int j = 0; j < bitmap_image.Height; j++) {
                    color_pixel = bitmap_image.GetPixel(i, j);
                    if (color_pixel.A != 0 && blue <= 255 && blue >= 0) color_pixel = Color.FromArgb(color_pixel.A, color_pixel.R, color_pixel.G, blue);
                    bitmap_image.SetPixel(i, j, color_pixel);
                }
            }
            return bitmap_image;
        }
    }
}