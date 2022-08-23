using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_main : Button { // Constructor.
        internal button_main(int width, int height, int x, int y, String text) {
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Text = text;
            Font = new Font(Font.FontFamily, (int)(Height * 0.13f));
            ForeColor = Color.Black;
            Click += event_handler_click;
        }
        private void event_handler_click(object sender, EventArgs e) { // Calling main form method for changing panel.
            ((form_main)Parent.Parent).open_new_panel((Panel)Parent, Text);
        }
    }
}