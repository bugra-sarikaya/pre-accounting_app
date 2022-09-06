using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class label_text : Label {
        internal label_text(int width, int height, int x, int y, string text, ContentAlignment alignment_text_value) { // Constructor.
            Size = new Size(width, height);
            Location = new Point(x, y);
            BackColor = Color.Transparent;
            Font = new Font(Font.FontFamily, (int)(Height / 1.75f));
            Text = text;
            TextAlign = alignment_text_value;
            ForeColor = Color.Black;
        }
    }
}