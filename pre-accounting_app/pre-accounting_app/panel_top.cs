using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    public class panel_top : Panel {
        internal static int height = 30;
        internal static int width;
        Point mouse_location_first, mouse_location_last;
        internal panel_top(Form form) { // Constructor.
            Width = width = form.Width;
            Height = height;
            button_close button_close = new button_close(this);
            Controls.Add(button_close);
            Controls.Add(new button_minimize(button_close));
            MouseDown += event_handler_mouse_down;
            MouseMove += new MouseEventHandler((sender, e) => event_handler_mouse_move(sender, e, form));
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Detecting mouse cursor location when left mouse button is pressed.
            if (e.Button == MouseButtons.Left) mouse_location_first = new Point(-e.X, -e.Y);
        }
        private void event_handler_mouse_move(object sender, MouseEventArgs e, Form form) { // Moving the form according to mouse cursor location.
            if (e.Button == MouseButtons.Left) {
                mouse_location_last = Control.MousePosition;
                mouse_location_last.Offset(mouse_location_first.X, mouse_location_first.Y);
                form.Location = mouse_location_last;
            }
        }
    }
}