using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class textbox_input : TextBox { // Constructor
        String placeholder_text;
        internal textbox_input(int width, int height, int x, int y, String placeholder_text) {
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Multiline = true;
            Font = new Font(Font.FontFamily, (int)(Height / 1.75f));
            Text = this.placeholder_text = placeholder_text;
            ForeColor = Color.Silver;
            BorderStyle = BorderStyle.None;
            Enter += enter_text_event;
            Leave += leave_text_event;
        }
        private void enter_text_event(object sender, EventArgs e) { // Enabling focusing effects.
            if (!String.IsNullOrWhiteSpace(Text) && ForeColor != Color.Black) {
                Text = "";
                if (placeholder_text == "Password") PasswordChar = '●';
                ForeColor = Color.Black;
            }
        }
        private void leave_text_event(object sender, EventArgs e) { // Disabling focusing effects.
            if (String.IsNullOrWhiteSpace(Text)) {
                ForeColor = Color.Silver;
                if (placeholder_text == "Password") PasswordChar = '\0';
                Text = placeholder_text;
            }
        }
    }
}