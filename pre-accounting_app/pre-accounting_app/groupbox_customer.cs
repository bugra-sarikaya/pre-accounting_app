using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class groupbox_customer : GroupBox {
        internal label_text label_text_name_value, label_text_surname_value, label_text_personal_id_value, label_text_tel_value, label_text_email_value;
        internal groupbox_customer(int width, int height, int x, int y, int vertical_gap, int horizantal_gap) { // Construstor.
            Size = new Size(width, height);
            Location = new Point(x, y);
            BackColor = Color.Transparent;
            Text = "Customer";
            Font = new Font(Font.FontFamily, 14);
            ForeColor = Color.FromArgb(255, 173, 16, 23);
            label_text label_text_name_title = new label_text((int)(Width * 0.28f), 20, 4, 30, "Name:", ContentAlignment.MiddleLeft);
            label_text_name_value = new label_text(Width - label_text_name_title.Width - vertical_gap - 6, label_text_name_title.Height, label_text_name_title.Location.X + label_text_name_title.Width + vertical_gap, label_text_name_title.Location.Y, "", ContentAlignment.MiddleLeft);
            label_text label_text_surname_title = new label_text(label_text_name_title.Width, label_text_name_title.Height, label_text_name_title.Location.X, label_text_name_title.Location.Y + horizantal_gap, "Surname:", ContentAlignment.MiddleLeft);
            label_text_surname_value = new label_text(label_text_name_value.Width, label_text_name_value.Height, label_text_name_value.Location.X, label_text_name_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_personal_id_title = new label_text(label_text_surname_title.Width, label_text_surname_title.Height, label_text_surname_title.Location.X, label_text_surname_title.Location.Y + horizantal_gap, "Personal ID:", ContentAlignment.MiddleLeft);
            label_text_personal_id_value = new label_text(label_text_surname_value.Width, label_text_surname_value.Height, label_text_surname_value.Location.X, label_text_surname_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_tel_title = new label_text(label_text_personal_id_title.Width, label_text_personal_id_title.Height, label_text_personal_id_title.Location.X, label_text_personal_id_title.Location.Y + horizantal_gap, "Tel:", ContentAlignment.MiddleLeft);
            label_text_tel_value = new label_text(label_text_personal_id_value.Width, label_text_personal_id_value.Height, label_text_personal_id_value.Location.X, label_text_personal_id_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            label_text label_text_email_title = new label_text(label_text_tel_title.Width, label_text_tel_title.Height, label_text_tel_title.Location.X, label_text_tel_title.Location.Y + horizantal_gap, "E-mail:", ContentAlignment.MiddleLeft);
            label_text_email_value = new label_text(label_text_tel_value.Width, label_text_tel_value.Height, label_text_tel_value.Location.X, label_text_tel_value.Location.Y + horizantal_gap, "", ContentAlignment.MiddleLeft);
            Height = label_text_email_value.Location.Y + label_text_email_value.Height + 4;
            Controls.Add(label_text_name_title);
            Controls.Add(label_text_name_value);
            Controls.Add(label_text_surname_title);
            Controls.Add(label_text_surname_value);
            Controls.Add(label_text_personal_id_title);
            Controls.Add(label_text_personal_id_value);
            Controls.Add(label_text_tel_title);
            Controls.Add(label_text_tel_value);
            Controls.Add(label_text_email_title);
            Controls.Add(label_text_email_value);
        }
    }
}