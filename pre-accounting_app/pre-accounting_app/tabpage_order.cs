using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_order : TabPage {
        internal datagridview_products_preview datagridview_product_list;
        internal label_text label_text_total_cost;
        form_main form_main;
        internal tabpage_order(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            int horizantal_gap_0, horizantal_gap_1, horizantal_gap_2, vertical_gap_0, vertical_gap_2, vertical_gap_3;
            horizantal_gap_0 = tabcontrol.ItemSize.Height;
            horizantal_gap_1 = (int)(horizantal_gap_0 * 0.7f);
            horizantal_gap_2 = horizantal_gap_1;
            vertical_gap_0 = horizantal_gap_0;
            vertical_gap_2 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_3 = (int)(vertical_gap_2 * 0.1f);
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            BackColor = Color.Transparent;
            Text = "Order";
            combobox_product combobox_product = new combobox_product(100, 30, vertical_gap_0, horizantal_gap_0, form_main);
            datagridview_products_preview datagridview_product = new datagridview_products_preview((Width - vertical_gap_0 * 2 - vertical_gap_2) / 2, 0, combobox_product.Location.X, combobox_product.Location.Y + combobox_product.Height + horizantal_gap_1);
            datagridview_product.Height = datagridview_product.RowTemplate.Height * 2;
            combobox_product.datagridview_product = datagridview_product;
            numericupdown numericupdown = new numericupdown(50, 10, datagridview_product.Location.X + datagridview_product.Width - 50, combobox_product.Location.Y);
            datagridview_product_list = new datagridview_products_preview(datagridview_product.Width, 0, datagridview_product.Location.X + datagridview_product.Width + vertical_gap_2, datagridview_product.Location.Y);
            datagridview_product_list.Height = datagridview_product_list.RowTemplate.Height * 17;
            label_text_total_cost = new label_text(100, 20, datagridview_product_list.Location.X + datagridview_product_list.Width - 100, datagridview_product_list.Location.Y + datagridview_product_list.Height + horizantal_gap_2, "", ContentAlignment.MiddleCenter);
            Controls.Add(combobox_product);
            Controls.Add(datagridview_product);
            Controls.Add(datagridview_product_list);
            Controls.Add(numericupdown);
            Controls.Add(new button_add_product((datagridview_product.Width - 80) / 2 + vertical_gap_0, datagridview_product.Location.Y + datagridview_product.Height + horizantal_gap_2, datagridview_product, datagridview_product_list, form_main, numericupdown, label_text_total_cost));
            Controls.Add(label_text_total_cost);
            Controls.Add(new label_text(100, 20, label_text_total_cost.Location.X - vertical_gap_3 - 100, label_text_total_cost.Location.Y, "Total Cost:", ContentAlignment.MiddleCenter));
            Controls.Add(new button_next(form_main, tabcontrol));
            MouseDown += event_handler_mouse_down;
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Disabling focusing after pressing on form.
            form_main.event_handler_mouse_down(sender, e);
        }
    }
}