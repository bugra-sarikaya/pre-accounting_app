using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_products : Panel {
        form_main form_main;
        internal panel_products(form_main form_main, panel_top panel_top) { // Constructor.
            this.form_main = form_main;
            int horizantal_gap, vertical_gap;
            horizantal_gap = vertical_gap = panel_top.height * 2;
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Location = new Point(0, panel_top.Height);
            BackColor = Color.Transparent;
            Name = "products";
            Controls.Add(new button_return(form_main, this, panel_top));
            Controls.Add(new button_add(form_main, this, panel_top));
            Controls.Add(new datagridview_products(Width - vertical_gap * 2, Height - horizantal_gap * 2, vertical_gap, horizantal_gap));
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}