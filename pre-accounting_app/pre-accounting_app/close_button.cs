using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    public class close_button : Button {
        static int alpha, red, green, blue;
        Bitmap bitmap_close_symbol;
        public close_button(top_panel top_panel) {
            alpha = red = green = blue = 0;
            float scale = 0.7f;
            Width = (int)(top_panel.Height * scale);
            Height = Width;
            int gap = (top_panel.Height - Height) / 2;
            Location = new Point(top_panel.Width - Width - gap, gap);
            string address_close_symbol = "pictures\\close_symbol.png";
            Image close_symbol = Image.FromFile(address_close_symbol);
            Size image_size = new Size((int)(Width * scale), (int)(Height * scale));
            bitmap_close_symbol = new Bitmap(close_symbol, image_size);
            Image = change_pixel_color(bitmap_close_symbol, red);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;  //Color.FromArgb(255, Color.Red);
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            //BackColor = Color.Transparent;
            //MouseHover += mouse_hover_event;
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Tick += timer_event;
            MouseClick += mouse_clicked_event;

        }
        private bool MouseIsOverControl(close_button button) {
            Image = change_pixel_color(bitmap_close_symbol, red);
            return button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
        }
        private void timer_event(object sender, EventArgs e) {
            if (MouseIsOverControl(this) && red <= 255 - 17 * 3) {
                red += 17 * 3;
            }
            else if (!MouseIsOverControl(this) && red >= 17 * 3) {
                red -= 17 * 3;
            }
            Image = change_pixel_color(bitmap_close_symbol, red);
            this.Refresh();

        }
        private void mouse_clicked_event(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) System.Windows.Forms.Application.Exit();
        }
        public Bitmap change_pixel_color(Bitmap bitmap_image, int red) {
            Color color_pixel;
            for (int i = 0; i < bitmap_image.Width; i++) {
                for (int j = 0; j < bitmap_image.Height; j++) {
                    color_pixel = bitmap_image.GetPixel(i, j);
                    if(color_pixel.A != 0 && red <= 255) color_pixel = Color.FromArgb(color_pixel.A, red, color_pixel.G, color_pixel.B);
                    bitmap_image.SetPixel(i, j, color_pixel);
                }
            }
            return bitmap_image;
        }
    }
}

