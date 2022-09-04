using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_close : Button {
        bool mouse_down;
        int color_pixel_red = 0;
        int limit_reducer = 0;
        int transition_value = 17 * 5; // 17 is a divisor of 255.
        internal int gap;
        Bitmap bitmap_close_symbol;
        Timer timer;
        internal button_close(panel_top top_panel) { // Constructor.
            float scale = 0.75f;
            mouse_down = false;
            Width = (int)(top_panel.Height * scale);
            Height = Width;
            gap = (top_panel.Height - Height) / 2;
            Location = new Point(top_panel.Width - Width - gap, gap);
            string address_close_symbol = "pictures\\close_symbol.png";
            Image close_symbol = Image.FromFile(address_close_symbol);
            bitmap_close_symbol = new Bitmap(close_symbol, new Size((int)(Width * scale), (int)(Height * scale)));
            Image = bitmap_close_symbol;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            timer = new Timer();
            timer.Enabled = false;
            timer.Tick += event_handler_timer;
            MouseClick += event_handler_mouse_clicked;
            MouseDown += event_handler_mouse_down;
            MouseUp += event_handler_mouse_up;
            MouseLeave += event_handler_mouse_leave;
        }
        protected override void OnMouseEnter(EventArgs e) {
            timer.Enabled = true;
        }
        private bool mouse_is_over_button(button_close button) { // Detecting situation of hovering mouse cursor over button.
            return button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
        }
        private void event_handler_timer(object sender, EventArgs e) { // Enabling hovering mouse cursor effect smoothly.
            if (mouse_is_over_button(this) && color_pixel_red <= 255 - transition_value - limit_reducer) {
                color_pixel_red += transition_value;
                Image = change_red_color(bitmap_close_symbol, color_pixel_red);
                Refresh();
            }
            else if (!mouse_is_over_button(this) && color_pixel_red >= transition_value) {
                color_pixel_red -= transition_value;
                Image = change_red_color(bitmap_close_symbol, color_pixel_red);
                Refresh();
            }
            if(!mouse_is_over_button(this) && !mouse_down && color_pixel_red == 0) timer.Enabled = false;
        }
        private void event_handler_mouse_clicked(object sender, MouseEventArgs e) { // Closing application if button is clicked with left mouse button.
            if (e.Button == MouseButtons.Left) Application.Exit();
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            mouse_down = true;
            if (mouse_is_over_button(this) && e.Button == MouseButtons.Left) {
                Image = change_red_color(bitmap_close_symbol, color_pixel_red - transition_value);
                Refresh();
                limit_reducer = transition_value;
            }
        }
        private void event_handler_mouse_up(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            mouse_down = false;
        }
        private void event_handler_mouse_leave(object sender, EventArgs e) { // Disabling pressing button effect.
            limit_reducer = 0;
        }
        private Bitmap change_red_color(Bitmap bitmap_image, int color_pixel_red) { // Changing red color value of image.
            Color color_pixel;
            for (int i = 0; i < bitmap_image.Width; i++) {
                for (int j = 0; j < bitmap_image.Height; j++) {
                    color_pixel = bitmap_image.GetPixel(i, j);
                    if (color_pixel.A != 0 && color_pixel_red <= 255 && color_pixel_red >= 0) color_pixel = Color.FromArgb(color_pixel.A, color_pixel_red, color_pixel.G, color_pixel.B);
                    bitmap_image.SetPixel(i, j, color_pixel);
                }
            }
            return bitmap_image;
        }
    }
}