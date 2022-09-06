using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_summary : TabPage {
        internal datagridview_products_preview datagridview_order;
        internal groupbox_customer groupbox_customer;
        internal groupbox_address groupbox_address;
        internal groupbox_payment groupbox_payment;
        internal label_text label_text_total_cost_value;
        form_main form_main;
        TabControl tabcontrol;
        internal tabpage_summary(form_main form_main, Panel panel_current, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            this.tabcontrol = tabcontrol;
            int horizantal_gap_0, horizantal_gap_1, horizantal_gap_2, horizantal_gap_3, vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3;
            vertical_gap_0 = horizantal_gap_0 = tabcontrol.ItemSize.Height;
            vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_2 = (int)(vertical_gap_1 * 0.65f);
            vertical_gap_3 = (int)(vertical_gap_2 * 0.1f);
            horizantal_gap_3 = horizantal_gap_2 = horizantal_gap_1 = (int)(horizantal_gap_0 * 0.8f);
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            BackColor = Color.Transparent;
            Text = "Summary";
            datagridview_order = new datagridview_products_preview((Width - vertical_gap_1 - vertical_gap_0 * 2) / 2, 300, vertical_gap_0, horizantal_gap_0);
            groupbox_customer = new groupbox_customer(400, 0, datagridview_order.Location.X + datagridview_order.Width + vertical_gap_1, datagridview_order.Location.Y, vertical_gap_2, horizantal_gap_1);
            groupbox_address = new groupbox_address(400, 0, datagridview_order.Location.X + datagridview_order.Width + vertical_gap_1, groupbox_customer.Location.Y + groupbox_customer.Height + horizantal_gap_2, vertical_gap_2, horizantal_gap_1);
            label_text_total_cost_value = new label_text(100, 20, datagridview_order.Location.X + datagridview_order.Width - 100, datagridview_order.Location.Y + datagridview_order.Height + horizantal_gap_2, "", ContentAlignment.MiddleCenter);
            groupbox_payment = new groupbox_payment(400, 0, datagridview_order.Location.X, label_text_total_cost_value.Location.Y + label_text_total_cost_value.Height + horizantal_gap_3, vertical_gap_2, horizantal_gap_1);
            Controls.Add(datagridview_order);
            Controls.Add(label_text_total_cost_value);
            Controls.Add(new label_text(100, 20, label_text_total_cost_value.Location.X - vertical_gap_3 - 100, label_text_total_cost_value.Location.Y, "Total Cost:", ContentAlignment.MiddleCenter)); Controls.Add(groupbox_customer);
            Controls.Add(groupbox_address);
            Controls.Add(groupbox_payment);
            Controls.Add(new button_submit_receipt_add(form_main, panel_current, tabcontrol));
            MouseDown += event_handler_mouse_down;
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Disabling focusing after pressing on form.
            form_main.event_handler_mouse_down(sender, e);
        }
    }
}