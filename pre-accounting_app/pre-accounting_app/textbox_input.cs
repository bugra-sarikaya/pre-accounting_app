using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class textbox_input : TextBox {
        string placeholder_text;
        internal textbox_input(int width, int height, int x, int y, string placeholder_text) { // Constructor.
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Multiline = true;
            Font = new Font(Font.FontFamily, (int)(Height / 1.75f));
            Text = this.placeholder_text = placeholder_text;
            ForeColor = Color.Silver;
            BorderStyle = BorderStyle.None;
            Enter += event_handler_enter;
            Leave += event_handler_leave;
            KeyDown += event_handler_key_down;
            KeyPress += event_handler_key_press;
        }
        private void event_handler_enter(object sender, EventArgs e) { // Enabling focusing effects.
            if (!string.IsNullOrWhiteSpace(Text) && ForeColor != Color.Black) {
                Text = "";
                if (placeholder_text == "Password") PasswordChar = '●';
                ForeColor = Color.Black;
            }
        }
        private void event_handler_leave(object sender, EventArgs e) { // Disabling focusing effects.
            if (string.IsNullOrWhiteSpace(Text)) {
                ForeColor = Color.Silver;
                if (placeholder_text == "Password") PasswordChar = '\0';
                Text = placeholder_text;
            }
        }
        private void event_handler_key_down(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
            }
        }
        private void event_handler_key_press(object sender, KeyPressEventArgs e) {
            if (placeholder_text == "Personal ID" || placeholder_text == "Telephone" || placeholder_text == "Postal Code" || placeholder_text == "Card Number" || placeholder_text == "Expiry Month" || placeholder_text == "Expiry Year" || placeholder_text == "CVV") {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            } else if (placeholder_text == "Price") {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar != ','))) e.Handled = true;
            }
        }
    }
}