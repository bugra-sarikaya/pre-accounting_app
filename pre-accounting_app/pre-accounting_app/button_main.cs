using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_main : Button {
        Bitmap bitmap_icon_customers;
        internal static int width = 230;
        internal static int height = 100;
        internal button_main(int x, int y) { // Constructor.
            float scale = 0.75f;
            Width = width;
            Height = 100;
            Location = new Point(x, y);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            Region = new Region(create_rounded_rectangle(new RectangleF(0, 0, Width, Height), 36));
        }
        private GraphicsPath create_rounded_rectangle(RectangleF rectanglef, int r, bool fill = false) { // Creating rounded rectangle.
            GraphicsPath path = new GraphicsPath();
            var r2 = r / 2;
            var fix = fill ? 1 : 0;
            rectanglef.Location = new Point((int)(rectanglef.X - 1), (int)(rectanglef.Y - 1));
            if (!fill) rectanglef.Size = new Size((int)(rectanglef.Width - 1), (int)(rectanglef.Height - 1));
            path.AddArc(rectanglef.Left, rectanglef.Top, r, r, 180, 90);
            path.AddLine(rectanglef.Left + r2, rectanglef.Top, rectanglef.Right - r2 - fix, rectanglef.Top);
            path.AddArc(rectanglef.Right - r - fix, rectanglef.Top, r, r, 270, 90);
            path.AddLine(rectanglef.Right, rectanglef.Top + r2, rectanglef.Right, rectanglef.Bottom - r2);
            path.AddArc(rectanglef.Right - r - fix, rectanglef.Bottom - r - fix, r, r, 0, 90);
            path.AddLine(rectanglef.Right - r2, rectanglef.Bottom, rectanglef.Left + r2, rectanglef.Bottom);
            path.AddArc(rectanglef.Left, rectanglef.Bottom - r - fix, r, r, 90, 90);
            path.AddLine(rectanglef.Left, rectanglef.Bottom - r2, rectanglef.Left, rectanglef.Top + r2);
            return path;
        }
    }
}