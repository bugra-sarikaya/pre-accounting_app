using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_receipt_add : Panel {
        form_main form_main;
        internal panel_receipt_add(form_main form_main, panel_top panel_top) { // Constructor.
            this.form_main = form_main;
            int vertical_gap_0, horizantal_gap_0;
            vertical_gap_0 = horizantal_gap_0 = (int)(panel_top.Height * 0.7f);
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Location = new Point(0, panel_top.Height);
            Name = "add_receipt";
            Controls.Add(new button_return(form_main, this, panel_top));
            Controls.Add(new tabcontrol(Width - vertical_gap_0 * 2, Height - horizantal_gap_0 * 2, vertical_gap_0, horizantal_gap_0, form_main));
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}