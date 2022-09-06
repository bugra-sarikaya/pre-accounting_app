using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class form_main : Form {
        internal form_main() { // Constructor.
            Width = 1000;
            Height = 800;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            form_main form_main = this;
            panel_top panel_top = new panel_top(form_main);
            panel_main panel_main = new panel_main(form_main, panel_top);
            Controls.Add(panel_top);
            Controls.Add(panel_main);
            MouseDown += event_handler_mouse_down;
        }
        protected override void OnPaint(PaintEventArgs e) { // Drawing rectangle.
            base.OnPaint(e);
            GraphicsPath graphicspath = create_rounded_rectangle(new RectangleF(0, 0, Width, Height), 16);
            Region = new Region(graphicspath);
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 173, 16, 23), 7.0f), graphicspath);
        }
        internal void event_handler_mouse_down(object sender, MouseEventArgs e) { // Disabling focusing after pressing on form.
            ActiveControl = null;
        }
        internal void open_new_panel(Panel panel_current, Panel panel_new) { // Changing panels.
            Controls.Remove(panel_current);
            Controls.Add(panel_new);
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