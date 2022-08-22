using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    public class panel_top : Panel {
        Point mouse_location_first, mouse_location_last;
        internal panel_top(Form form) { // Constructor.
            Width = form.Width;
            Height = 30;
            button_close button_close = new button_close(this);
            Controls.Add(button_close);
            Controls.Add(new button_minimize(button_close));
            MouseDown += mouse_down_event;
            MouseMove += new MouseEventHandler((sender, e) => mouse_move_event(sender, e, form));
        }
        private void mouse_down_event(object sender, MouseEventArgs e) { // Detecting mouse cursor location when left mouse button is pressed.
            if (e.Button == MouseButtons.Left) mouse_location_first = new Point(-e.X, -e.Y);
        }
        private void mouse_move_event(object sender, MouseEventArgs e, Form form) { // Moving the form according to mouse cursor location.
            if (e.Button == MouseButtons.Left) {
                mouse_location_last = Control.MousePosition;
                mouse_location_last.Offset(mouse_location_first.X, mouse_location_first.Y);
                form.Location = mouse_location_last;
            }
        }
    }
}