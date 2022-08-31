using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_order : TabPage {
        internal datagridview_product datagridview_product_list;
        internal textbox textbox_total_cost;
        form_main form_main;
        internal tabpage_order(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            int horizantal_gap_0, horizantal_gap_1, horizantal_gap_2, vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3, vertical_gap_4;
            int location_x_combobox, location_y_combobox;
            location_y_combobox = horizantal_gap_0 = 50;
            horizantal_gap_1 = (int)(horizantal_gap_0 * 0.7f);
            horizantal_gap_2 = (int)(horizantal_gap_0 * 0.9f);
            location_x_combobox = vertical_gap_0 = 50;
            vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_4 = vertical_gap_3 = vertical_gap_2 = vertical_gap_1;
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            Text = "Order";
            datagridview_product datagridview_product = new datagridview_product(400, 50, location_x_combobox, location_y_combobox + horizantal_gap_1);
            combobox_product combobox_product = new combobox_product(100, 30, location_x_combobox, location_y_combobox, datagridview_product, form_main);
            numericupdown numericupdown = new numericupdown(50, 10, combobox_product.Location.X + combobox_product.Width + horizantal_gap_1, combobox_product.Location.Y);
            datagridview_product_list = new datagridview_product(400, 400, Width - 400 - vertical_gap_0, datagridview_product.Location.Y);
            textbox_total_cost = new textbox(60, 20, Width - 50 - 10, datagridview_product_list.Location.Y + datagridview_product_list.Height + 20, "");
            Controls.Add(combobox_product);
            Controls.Add(datagridview_product);
            Controls.Add(datagridview_product_list);
            Controls.Add(numericupdown);
            Controls.Add(new button_add_product(100, 50, (datagridview_product.Width - 100) / 2 + vertical_gap_0, datagridview_product.Location.Y + datagridview_product.Height + horizantal_gap_2, datagridview_product, datagridview_product_list, form_main, numericupdown, textbox_total_cost));
            Controls.Add(textbox_total_cost);
            Controls.Add(new button_next(form_main, tabcontrol));
            Click += click_event_handler_button;
            
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}