using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_receipts : Panel {
        form_main form_main;
        internal panel_receipts(form_main form_main, panel_top panel_top) { // Constructor.
            this.form_main = form_main;
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Location = new Point(0, panel_top.Height);
            Name = "receipts";
            Panel panel_current = this;
            Controls.Add(new button_add(form_main, this, panel_top));
            Controls.Add(new button_return(form_main, panel_current, panel_top));
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}