using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_summary : TabPage {
        internal datagridview_product datagridview_order;
        internal textbox textbox_total_cost, textbox_name, textbox_surname, textbox_personal_id, textbox_tel, textbox_email, textbox_country, textbox_state, textbox_city, textbox_street, textbox_postal_code, textbox_postal_address, textbox_card_name, textbox_card_number, textbox_expiry_month, textbox_expiry_year, textbox_cvv;
        form_main form_main;
        TabControl tabcontrol;
        internal tabpage_summary(form_main form_main, Panel panel_current, TabControl tabcontrol) { // Constructor.
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
            textbox_name = new textbox(100, 20, datagridview_order.Location.X + datagridview_order.Width + 10, 100, "");
            textbox_surname = new textbox(100, 20, datagridview_order.Location.X + datagridview_order.Width + 10, 130, "");
            textbox_personal_id = new textbox(100, 20, datagridview_order.Location.X + datagridview_order.Width + 10, 160, "");
            textbox_tel = new textbox(100, 20, datagridview_order.Location.X + datagridview_order.Width + 10, 190, "");
            textbox_email = new textbox(100, 20, datagridview_order.Location.X + datagridview_order.Width + 10, 220, "");
            textbox_country = new textbox(100, 20, textbox_name.Location.X + textbox_name.Width + 10, 100, "");
            textbox_state = new textbox(100, 20, textbox_name.Location.X + textbox_name.Width + 10, 130, "");
            textbox_city = new textbox(100, 20, textbox_name.Location.X + textbox_name.Width + 10, 160, "");
            textbox_street= new textbox(100, 20, textbox_name.Location.X + textbox_name.Width + 10, 190, "");
            textbox_postal_code = new textbox(100, 20, textbox_name.Location.X + textbox_name.Width + 10, 220, "");
            textbox_postal_address = new textbox(100, 20, textbox_name.Location.X + textbox_name.Width + 10, 250, "");
            textbox_card_name = new textbox(100, 20, textbox_country.Location.X + textbox_country.Width + 10, 100, "");
            textbox_card_number = new textbox(100, 20, textbox_country.Location.X + textbox_country.Width + 10, 130, "");
            textbox_expiry_month = new textbox(100, 20, textbox_country.Location.X + textbox_country.Width + 10, 160, "");
            textbox_expiry_year = new textbox(100, 20, textbox_country.Location.X + textbox_country.Width + 10, 190, "");
            textbox_cvv = new textbox(100, 20, textbox_country.Location.X + textbox_country.Width + 10, 220, "");
            Controls.Add(textbox_total_cost);
            Controls.Add(textbox_name);
            Controls.Add(textbox_surname);
            Controls.Add(textbox_personal_id);
            Controls.Add(textbox_tel);
            Controls.Add(textbox_email);
            Controls.Add(textbox_country);
            Controls.Add(textbox_state);
            Controls.Add(textbox_city);
            Controls.Add(textbox_street);
            Controls.Add(textbox_postal_code);
            Controls.Add(textbox_postal_address);
            Controls.Add(textbox_card_name);
            Controls.Add(textbox_card_number);
            Controls.Add(textbox_expiry_month);
            Controls.Add(textbox_expiry_year);
            Controls.Add(textbox_cvv);
            Controls.Add(new button_submit_receipt_add(form_main, panel_current, tabcontrol));
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}