using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class textbox_input : TextBox { // Constructor
        string placeholder_text;
        internal textbox_input(int width, int height, int x, int y, string placeholder_text) {
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Multiline = true;
            Font = new Font(Font.FontFamily, (int)(Height / 1.75f));
            Text = this.placeholder_text = placeholder_text;
            ForeColor = Color.Silver;
            BorderStyle = BorderStyle.None;
            Enter += event_handler_enter_text;
            Leave += event_handler_leave_text;
        }
        private void event_handler_enter_text(object sender, EventArgs e) { // Enabling focusing effects.
            if (!string.IsNullOrWhiteSpace(Text) && ForeColor != Color.Black) {
                Text = "";
                if (placeholder_text == "Password") PasswordChar = '●';
                ForeColor = Color.Black;
            }
        }
        private void event_handler_leave_text(object sender, EventArgs e) { // Disabling focusing effects.
            if (string.IsNullOrWhiteSpace(Text)) {
                ForeColor = Color.Silver;
                if (placeholder_text == "Password") PasswordChar = '\0';
                Text = placeholder_text;
            }
        }
    }
}