using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class textbox : TextBox {
        internal textbox(int width, int height, int x, int y, string text) { // Constructor.
            Size = new Size(width, height);
            Location = new Point(x, y);
            Multiline = true;
            Font = new Font(Font.FontFamily, (int)(Height / 1.75f));
            Text = text;
            ReadOnly = true;
            //ForeColor = Color.Silver;
            //BorderStyle = BorderStyle.None;
        }
    }
}