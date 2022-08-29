using System;
using System.Drawing;
using System.Windows.Forms;
namespace pre_accounting_app {
    internal class tabpage_payment : TabPage {
        form_main form_main;
        internal tabpage_payment(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            textbox_input textbox_input_name, textbox_input_card_number, textbox_input_expiry_month, textbox_input_expiry_year, textbox_postal_cvv;
            int vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3, vertical_gap_4, vertical_gap_5;
            vertical_gap_0 = 100;
            vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_5 = vertical_gap_4 = vertical_gap_3 = vertical_gap_2 = vertical_gap_1;
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            Text = "Payment";
            textbox_input_name = new textbox_input(200, 30, (Width - 200) / 2, vertical_gap_0, "Name");
            textbox_input_card_number = new textbox_input(textbox_input_name.Width, textbox_input_name.Height, textbox_input_name.Location.X, textbox_input_name.Location.Y + vertical_gap_1, "Card Number");
            textbox_input_expiry_month = new textbox_input(textbox_input_card_number.Width, textbox_input_card_number.Height, textbox_input_card_number.Location.X, textbox_input_card_number.Location.Y + vertical_gap_2, "Expiry Month");
            textbox_input_expiry_year = new textbox_input(textbox_input_expiry_month.Width, textbox_input_expiry_month.Height, textbox_input_expiry_month.Location.X, textbox_input_expiry_month.Location.Y + vertical_gap_3, "Expiry Year");
            textbox_postal_cvv = new textbox_input(textbox_input_expiry_year.Width, textbox_input_expiry_year.Height, textbox_input_expiry_year.Location.X, textbox_input_expiry_year.Location.Y + vertical_gap_4, "CVV");
            button_submit_receipt_add button_submit_receipt_add = new button_submit_receipt_add(form_main, tabcontrol);
            form_main.assign_button_submit(button_submit_receipt_add);
            Controls.Add(textbox_input_name);
            Controls.Add(textbox_input_card_number);
            Controls.Add(textbox_input_expiry_month);
            Controls.Add(textbox_input_expiry_year);
            Controls.Add(textbox_postal_cvv);
            Controls.Add(button_submit_receipt_add);
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}