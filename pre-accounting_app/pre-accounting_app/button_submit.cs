using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_submit : Button {
        internal button_submit(int width, int height, int x, int y, String text_submit) { // Constructor
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Font = new Font (Font.FontFamily, (int)(Height * 0.25f));
            Text = text_submit;
            ForeColor = Color.Black;
        }
    }
}