using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_summary : TabPage {
        internal datagridview_product datagridview_order;
        internal textbox textbox_total_cost;
        form_main form_main;
        TabControl tabcontrol;
        internal tabpage_summary(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            this.tabcontrol = tabcontrol;
            int vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3, vertical_gap_4;
            vertical_gap_0 = 100;
            vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_4 = vertical_gap_3 = vertical_gap_2 = vertical_gap_1;
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            Text = "Summary";
            datagridview_order = new datagridview_product(400, 300, 50, 100);
            Controls.Add(datagridview_order);
            textbox_total_cost = new textbox(60, 20, 50 + 400 - 60, 100 + 300 + 10, "");
            Controls.Add(textbox_total_cost);
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
            //datagridview_product.Refresh();
        }
    }
}