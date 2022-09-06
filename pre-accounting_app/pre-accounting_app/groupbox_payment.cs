using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class groupbox_payment : GroupBox {
        internal label_text label_text_card_name_value, label_text_card_number_value, label_text_expiry_month_value, label_text_expiry_year_value, label_text_cvv_value;
        internal groupbox_payment(int width, int height, int x, int y, int vertical_gap, int horizantal_gap) { // Construstor.
            Size = new Size(width, height);
            Location = new Point(x, y);
            BackColor = Color.Transparent;
            Text = "Payment";
            Font = new Font(Font.FontFamily, 14);
            ForeColor = Color.FromArgb(255, 173, 16, 23);
            label_text label_text_card_name_title = new label_text((int)(Width * 0.28f), 20, 4, 30, "Card Name:", ContentAlignment.MiddleLeft);
            label_text_card_name_value = new label_text(Width - label_text_card_name_title.Width - vertical_gap - 6, label_text_card_name_title.Height, label_text_card_name_title.Location.X + label_text_card_name_title.Width + vertical_gap, label_text_card_name_title.Location.Y, "", ContentAlignment.MiddleLeft);
            label_text label_text_card_number_title = new label_text(label_text_card_name_title.Width, label_text_card_name_title.Height, label_text_card_name_title.Location.X, label_text_card_name_title.Location.Y + horizantal_gap, "Card Number:", ContentAlignment.MiddleLeft);
            label_text_card_number_value = new label_text(label_text_card_name_value.Width, label_text_card_name_value.Height, label_text_card_name_value.Location.X, label_text_card_name_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_expiry_month_title = new label_text(label_text_card_number_title.Width, label_text_card_number_title.Height, label_text_card_number_title.Location.X, label_text_card_number_title.Location.Y + horizantal_gap, "Expiry Month:", ContentAlignment.MiddleLeft);
            label_text_expiry_month_value = new label_text(label_text_card_number_value.Width, label_text_card_number_value.Height, label_text_card_number_value.Location.X, label_text_card_number_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_expiry_year_title = new label_text(label_text_expiry_month_title.Width, label_text_expiry_month_title.Height, label_text_expiry_month_title.Location.X, label_text_expiry_month_title.Location.Y + horizantal_gap, "Expiry Year:", ContentAlignment.MiddleLeft);
            label_text_expiry_year_value = new label_text(label_text_expiry_month_value.Width, label_text_expiry_month_value.Height, label_text_expiry_month_value.Location.X, label_text_expiry_month_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_cvv_title = new label_text(label_text_expiry_year_title.Width, label_text_expiry_year_title.Height, label_text_expiry_year_title.Location.X, label_text_expiry_year_title.Location.Y + horizantal_gap, "CVV:", ContentAlignment.MiddleLeft);
            label_text_cvv_value = new label_text(label_text_expiry_year_value.Width, label_text_expiry_year_value.Height, label_text_expiry_year_value.Location.X, label_text_expiry_year_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            Height = label_text_cvv_value.Location.Y + label_text_cvv_value.Height + 4;
            Controls.Add(label_text_card_name_title);
            Controls.Add(label_text_card_name_value);
            Controls.Add(label_text_card_number_title);
            Controls.Add(label_text_card_number_value);
            Controls.Add(label_text_expiry_month_title);
            Controls.Add(label_text_expiry_month_value);
            Controls.Add(label_text_expiry_year_title);
            Controls.Add(label_text_expiry_year_value);
            Controls.Add(label_text_cvv_title);
            Controls.Add(label_text_cvv_value);
        }
    }
}