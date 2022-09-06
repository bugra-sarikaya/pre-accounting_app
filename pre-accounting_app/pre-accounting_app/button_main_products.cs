using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_main_products : button_main {
        Bitmap bitmap_icon_customers;
        Panel panel_current, panel_next;
        panel_top panel_top;
        form_main form_current;
        Timer timer;
        bool mouse_down;
        int color_red, color_red_0;
        int limit_red = 250;
        int limit_reducer = 0;
        int transition_value = 20;
        internal button_main_products(int x, int y, form_main form_current, Panel panel_current, panel_top panel_top) : base(x, y) { // Constructor.
            this.form_current = form_current;
            this.panel_current = panel_current;
            this.panel_top = panel_top;
            mouse_down = false;
            float scale = 0.075f;
            Location = new Point(x, y);
            string address_icon_customers = "pictures\\icon_products.png";
            Image icon_customers = Image.FromFile(address_icon_customers);
            bitmap_icon_customers = new Bitmap(icon_customers, new Size((int)(icon_customers.Width * scale), (int)(icon_customers.Height * scale)));
            PictureBox picturebox_icon = new PictureBox();
            picturebox_icon.Image = bitmap_icon_customers;
            picturebox_icon.Size = new Size(Height, Height);
            picturebox_icon.SizeMode = PictureBoxSizeMode.CenterImage;
            picturebox_icon.Location = new Point((Height - picturebox_icon.Height) / 2, (Height - picturebox_icon.Height) / 2);
            picturebox_icon.BackColor = Color.Transparent;
            picturebox_icon.MouseClick += event_handler_mouse_click_picturebox;
            picturebox_icon.MouseEnter += event_handler_mouse_enter_picturebox;
            picturebox_icon.MouseDown += event_handler_mouse_down_picturebox;
            picturebox_icon.MouseUp += event_handler_mouse_up_picturebox;
            Label label_text = new Label();
            label_text.Size = new Size(Width - picturebox_icon.Width - 2, picturebox_icon.Height);
            label_text.Location = new Point(picturebox_icon.Width, picturebox_icon.Location.Y);
            label_text.Text = "Products";
            label_text.TextAlign = ContentAlignment.MiddleCenter;
            label_text.Font = new Font(Font.FontFamily, (int)(Height * 0.19f));
            label_text.ForeColor = Color.White;
            label_text.BackColor = Color.Transparent;
            label_text.MouseClick += event_handler_mouse_click_label_text;
            label_text.MouseEnter += event_handler_mouse_enter_label_text;
            label_text.MouseDown += event_handler_mouse_down_label_text;
            label_text.MouseUp += event_handler_mouse_up_label_text;
            BackColor = Color.FromArgb(255, 173, 16, 23);
            color_red = color_red_0 = BackColor.R;
            TabStop = false;
            Controls.Add(picturebox_icon);
            Controls.Add(label_text);
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
        private void event_handler_mouse_click(object sender, MouseEventArgs e) { // Calling main form method for changing panel.
            panel_next = new panel_products(form_current, panel_top);
            ((form_main)Parent.Parent).open_new_panel(panel_current, panel_next);
        }
        private void event_handler_mouse_click_picturebox(object sender, MouseEventArgs e) {
            OnMouseClick(e);
        }
        private void event_handler_mouse_click_label_text(object sender, MouseEventArgs e) {
            OnMouseClick(e);
        }
        private void event_handler_mouse_enter_picturebox(object sender, EventArgs e) {
            OnMouseEnter(e);
        }
        private void event_handler_mouse_enter_label_text(object sender, EventArgs e) {
            OnMouseEnter(e);
        }
        private void event_handler_mouse_down_picturebox(object sender, MouseEventArgs e) {
            event_handler_mouse_down(sender, e);
        }
        private void event_handler_mouse_down_label_text(object sender, MouseEventArgs e) {
            event_handler_mouse_down(sender, e);
        }
        private void event_handler_mouse_up_picturebox(object sender, MouseEventArgs e) {
            event_handler_mouse_up(sender, e);
        }
        private void event_handler_mouse_up_label_text(object sender, MouseEventArgs e) {
            event_handler_mouse_up(sender, e);
        }
        private bool mouse_is_over_button(button_main button) { // Detecting situation of hovering mouse cursor over button.
            return button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
        }
        private void event_handler_timer(object sender, EventArgs e) { // Enabling hovering mouse cursor effect smoothly.
            if (mouse_is_over_button(this) && color_red <= limit_red - transition_value - limit_reducer) {
                color_red += transition_value;
                BackColor = change_red_color(BackColor, color_red);
                Refresh();
            } else if (!mouse_is_over_button(this) && color_red >= transition_value) {
                color_red -= transition_value;
                BackColor = change_red_color(BackColor, color_red);
                Refresh();
            }
            if (color_red > limit_red) color_red = limit_red;
            if (color_red < color_red_0) color_red = color_red_0;
            if (!mouse_is_over_button(this) && !mouse_down && color_red == color_red_0) timer.Enabled = false;
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            mouse_down = true;
            if (mouse_is_over_button(this) && e.Button == MouseButtons.Left) {
                BackColor = change_red_color(BackColor, color_red - transition_value);
                Refresh();
                limit_reducer = transition_value;
            }
        }
        private void event_handler_mouse_up(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            mouse_down = false;
            if (mouse_is_over_button(this) && e.Button == MouseButtons.Left) event_handler_mouse_click(this, e);
        }
        private void event_handler_mouse_leave(object sender, EventArgs e) { // Disabling pressing button effect.
            limit_reducer = 0;
        }
        private Color change_red_color(Color color, int color_red) { // Changing red color value of button.
            if (color_red <= limit_red && color_red >= color_red_0) color = Color.FromArgb(color.A, color_red, color.G, color.B);
            return color;
        }
    }
}