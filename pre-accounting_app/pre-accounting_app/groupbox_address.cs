using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class groupbox_address : GroupBox {
        internal label_text label_text_country_value, label_text_state_value, label_text_city_value, label_text_street_value, label_text_postal_code_value, label_text_postal_address_value;
        internal groupbox_address(int width, int height, int x, int y, int vertical_gap, int horizantal_gap) { // Construstor.
            Size = new Size(width, height);
            Location = new Point(x, y);
            BackColor = Color.Transparent;
            Text = "Address";
            Font = new Font(Font.FontFamily, 14);
            ForeColor = Color.FromArgb(255, 173, 16, 23);
            label_text label_text_country_title = new label_text((int)(Width * 0.28f), 20, 4, 30, "Country:", ContentAlignment.MiddleLeft);
            label_text_country_value = new label_text(Width - label_text_country_title.Width - vertical_gap - 6, label_text_country_title.Height, label_text_country_title.Location.X + label_text_country_title.Width + vertical_gap, label_text_country_title.Location.Y, "", ContentAlignment.MiddleLeft);
            label_text label_text_state_title = new label_text(label_text_country_title.Width, label_text_country_title.Height, label_text_country_title.Location.X, label_text_country_title.Location.Y + horizantal_gap, "State:", ContentAlignment.MiddleLeft);
            label_text_state_value = new label_text(label_text_country_value.Width, label_text_country_value.Height, label_text_country_value.Location.X, label_text_country_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_city_title = new label_text(label_text_state_title.Width, label_text_state_title.Height, label_text_state_title.Location.X, label_text_state_title.Location.Y + horizantal_gap, "City:", ContentAlignment.MiddleLeft);
            label_text_city_value = new label_text(label_text_state_value.Width, label_text_state_value.Height, label_text_state_value.Location.X, label_text_state_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_street_title = new label_text(label_text_city_title.Width, label_text_city_title.Height, label_text_city_title.Location.X, label_text_city_title.Location.Y + horizantal_gap, "Street:", ContentAlignment.MiddleLeft);
            label_text_street_value = new label_text(label_text_city_value.Width, label_text_city_value.Height, label_text_city_value.Location.X, label_text_city_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_postal_code_title = new label_text(label_text_street_title.Width, label_text_street_title.Height, label_text_street_title.Location.X, label_text_street_title.Location.Y + horizantal_gap, "Postal Code:", ContentAlignment.MiddleLeft);
            label_text_postal_code_value = new label_text(label_text_street_value.Width, label_text_street_value.Height, label_text_street_value.Location.X, label_text_street_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_postal_address_title = new label_text(label_text_postal_code_title.Width, label_text_postal_code_title.Height, label_text_postal_code_title.Location.X, label_text_postal_code_title.Location.Y + horizantal_gap, "Postal Address:", ContentAlignment.MiddleLeft);
            label_text_postal_address_value = new label_text(label_text_postal_code_value.Width, label_text_postal_code_value.Height, label_text_postal_code_value.Location.X, label_text_postal_code_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            Height = label_text_postal_address_value.Location.Y + label_text_postal_address_value.Height + 4;
            Controls.Add(label_text_country_title);
            Controls.Add(label_text_country_value);
            Controls.Add(label_text_state_title);
            Controls.Add(label_text_state_value);
            Controls.Add(label_text_city_title);
            Controls.Add(label_text_city_value);
            Controls.Add(label_text_street_title);
            Controls.Add(label_text_street_value);
            Controls.Add(label_text_postal_code_title);
            Controls.Add(label_text_postal_code_value);
            Controls.Add(label_text_postal_address_title);
            Controls.Add(label_text_postal_address_value);
        }
    }
}