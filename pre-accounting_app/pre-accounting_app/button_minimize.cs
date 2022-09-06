using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_minimize : Button {
        bool mouse_down;
        int color_pixel_blue = 0;
        int limit_reducer = 0;
        int transition_value = 17 * 5; // 17 is a divisor of 255.
        Bitmap bitmap_minimize_symbol;
        Timer timer;
        internal button_minimize(button_close button_close) { // Constructor
            float scale = 0.75f;
            mouse_down = false;
            Width = button_close.Height;
            Height = Width;
            Location = new Point(button_close.Location.X - Width - button_close.gap, button_close.Location.Y);
            BackColor = Color.Transparent;
            string address_minimize_symbol = "pictures\\minimize_symbol.png";
            Image minimize_symbol = Image.FromFile(address_minimize_symbol);
            bitmap_minimize_symbol = new Bitmap(minimize_symbol, new Size((int)(Width * scale), (int)(Height * scale)));
            Image = bitmap_minimize_symbol;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            TabStop = false;
            timer = new Timer();
            timer.Enabled = false;
            timer.Tick += event_handler_timer;
            MouseClick += event_handler_mouse_click;
            MouseDown += event_handler_mouse_down;
            MouseUp += event_handler_mouse_up;
            MouseLeave += event_handler_mouse_leave;
        }
        protected override void OnMouseEnter(EventArgs e) {
            timer.Enabled = true;
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            event_handler_mouse_down(this, e);
        }
        private bool mouse_is_over_button(button_minimize button) { // Detecting situation of hovering mouse cursor over button.
            return button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
        }
        private void event_handler_timer(object sender, EventArgs e) { // Enabling hovering mouse cursor effect smoothly.
            if (mouse_is_over_button(this) && color_pixel_blue < 255 - transition_value - limit_reducer) {
                color_pixel_blue += transition_value;
                Image = change_blue_color(bitmap_minimize_symbol, color_pixel_blue);
                Refresh();
            } else if (!mouse_is_over_button(this) && color_pixel_blue >= transition_value) {
                color_pixel_blue -= transition_value;
                Image = change_blue_color(bitmap_minimize_symbol, color_pixel_blue);
                Refresh();
            }
            if (!mouse_is_over_button(this) && !mouse_down && color_pixel_blue == 0) timer.Enabled = false;
        }
        private void event_handler_mouse_click(object sender, MouseEventArgs e) { // Minimizing applicaiton if button is clicked with left mouse button.
            ((Form)Parent.Parent).WindowState = FormWindowState.Minimized;
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            mouse_down = true;
            if (mouse_is_over_button(this) && e.Button == MouseButtons.Left) {
                Image = change_blue_color(bitmap_minimize_symbol, color_pixel_blue - transition_value);
                Refresh();
                limit_reducer = transition_value;
            }
        }
        private void event_handler_mouse_up(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            mouse_down = false;
            if (mouse_is_over_button(this) && e.Button == MouseButtons.Left) event_handler_mouse_click(this, e);
        }
        private void event_handler_mouse_leave(object sender, EventArgs e) { //Disabling pressing button effect.
            limit_reducer = 0;
        }
        private Bitmap change_blue_color(Bitmap bitmap_image, int color_pixel_blue) { // Changing blue color value of image.
            Color color_pixel;
            for (int i = 0; i < bitmap_image.Width; i++) {
                for (int j = 0; j < bitmap_image.Height; j++) {
                    color_pixel = bitmap_image.GetPixel(i, j);
                    if (color_pixel.A != 0 && color_pixel_blue <= 255 && color_pixel_blue >= 0) color_pixel = Color.FromArgb(color_pixel.A, color_pixel.R, color_pixel.G, color_pixel_blue);
                    bitmap_image.SetPixel(i, j, color_pixel);
                }
            }
            return bitmap_image;
        }
    }
}