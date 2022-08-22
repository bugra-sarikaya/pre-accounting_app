﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class close_button : Button {
        int red = 0;
        int limit_reducer = 0;
        int transition_value = 17 * 5; // 17 is a divisor of 255.
        internal int gap;
        Bitmap bitmap_close_symbol;
        internal close_button(top_panel top_panel) { // Constructor.
            float scale = 0.75f;
            Width = (int)(top_panel.Height * scale);
            Height = Width;
            gap = (top_panel.Height - Height) / 2;
            Location = new Point(top_panel.Width - Width - gap, gap);
            string address_close_symbol = "pictures\\close_symbol.png";
            Image close_symbol = Image.FromFile(address_close_symbol);
            Size image_size = new Size((int)(Width * scale), (int)(Height * scale));
            bitmap_close_symbol = new Bitmap(close_symbol, image_size);
            Image = bitmap_close_symbol;
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
        private bool mouse_is_over_button(close_button button) { // Detecting situation of hovering mouse cursor over button.
            return button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
        }
        private void timer_event(object sender, EventArgs e) { // Enabling hovering mouse cursor effect smoothly.
            if (mouse_is_over_button(this) && red <= 255 - transition_value - limit_reducer) {
                red += transition_value;
                Image = change_red_color(bitmap_close_symbol, red);
                Refresh();
            }
            else if (!mouse_is_over_button(this) && red >= transition_value) {
                red -= transition_value;
                Image = change_red_color(bitmap_close_symbol, red);
                Refresh();
            }
        }
        private void mouse_clicked_event(object sender, MouseEventArgs e) { // Closing application if button is clicked with left mouse button.
            if (e.Button == MouseButtons.Left) Application.Exit();
        }
        private void mouse_down_event(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            if (mouse_is_over_button(this) && e.Button == MouseButtons.Left) {
                Image = change_red_color(bitmap_close_symbol, red - transition_value);
                Refresh();
                limit_reducer = transition_value;
            }
        }
        private void mouse_leave_event(object sender, EventArgs e) { // Disabling pressing button effect.
            limit_reducer = 0;
        }
        internal Bitmap change_red_color(Bitmap bitmap_image, int red) { // Changing red color value of image.
            Color color_pixel;
            for (int i = 0; i < bitmap_image.Width; i++) {
                for (int j = 0; j < bitmap_image.Height; j++) {
                    color_pixel = bitmap_image.GetPixel(i, j);
                    if (color_pixel.A != 0 && red <= 255 && red >= 0) color_pixel = Color.FromArgb(color_pixel.A, red, color_pixel.G, color_pixel.B);
                    bitmap_image.SetPixel(i, j, color_pixel);
                }
            }
            return bitmap_image;
        }
    }
}