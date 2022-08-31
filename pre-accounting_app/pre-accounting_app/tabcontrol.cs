using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabcontrol : TabControl {
        internal tabcontrol(int width, int height, int x, int y, form_main form_main) { // Constructor.
            Size = new Size(width, height);
            Location = new Point(x, y);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(60, 30);
            TabPages.Add(new tabpage_order(form_main, this));
            TabPages.Add(new tabpage_customer(form_main, this));
            TabPages.Add(new tabpage_address(form_main, this));
            TabPages.Add(new tabpage_payment(form_main, this));
            TabPages.Add(new tabpage_summary(form_main, this));
            SelectedIndexChanged += selected_index_changed_event_handler;
        }
        private void selected_index_changed_event_handler(object sender, EventArgs e) {
            ((tabpage_summary)TabPages[4]).datagridview_order.Rows.Clear();
            ((tabpage_summary)TabPages[4]).datagridview_order.Columns.Clear();
            ((tabpage_summary)TabPages[4]).datagridview_order.ColumnCount = ((tabpage_order)TabPages[0]).datagridview_product_list.ColumnCount;
            for (int i = 0; i < ((tabpage_order)TabPages[0]).datagridview_product_list.ColumnCount; i++) ((tabpage_summary)TabPages[4]).datagridview_order.Columns[i].Name = ((tabpage_order)TabPages[0]).datagridview_product_list.Columns[i].Name;
            for (int i = 0; i < ((tabpage_order)TabPages[0]).datagridview_product_list.RowCount; i++) {
                ((tabpage_summary)TabPages[4]).datagridview_order.Rows.Add(((tabpage_order)TabPages[0]).datagridview_product_list.Rows[i].Clone());
                for (int j = 0; j < ((tabpage_order)TabPages[0]).datagridview_product_list.ColumnCount; j++) ((tabpage_summary)TabPages[4]).datagridview_order.Rows[i].Cells[j].Value = ((tabpage_order)TabPages[0]).datagridview_product_list.Rows[i].Cells[j].Value;
            }
            ((tabpage_summary)TabPages[4]).textbox_total_cost.Text = ((tabpage_order)TabPages[0]).textbox_total_cost.Text;
            if (!((tabpage_customer)TabPages[1]).textbox_input_name.Text.Equals("Name")) ((tabpage_summary)TabPages[4]).textbox_name.Text = ((tabpage_customer)TabPages[1]).textbox_input_name.Text;
            if (!((tabpage_customer)TabPages[1]).textbox_input_surname.Text.Equals("Surname")) ((tabpage_summary)TabPages[4]).textbox_surname.Text = ((tabpage_customer)TabPages[1]).textbox_input_surname.Text;
            if (!((tabpage_customer)TabPages[1]).textbox_input_personal_id.Text.Equals("Personal ID")) ((tabpage_summary)TabPages[4]).textbox_personal_id.Text = ((tabpage_customer)TabPages[1]).textbox_input_personal_id.Text;
            if (!((tabpage_customer)TabPages[1]).textbox_input_tel.Text.Equals("Telephone")) ((tabpage_summary)TabPages[4]).textbox_tel.Text = ((tabpage_customer)TabPages[1]).textbox_input_tel.Text;
            if (!((tabpage_customer)TabPages[1]).textbox_input_email.Text.Equals("E-mail")) ((tabpage_summary)TabPages[4]).textbox_email.Text = ((tabpage_customer)TabPages[1]).textbox_input_email.Text;            
            if (!((tabpage_address)TabPages[2]).textbox_input_country.Text.Equals("Country")) ((tabpage_summary)TabPages[4]).textbox_country.Text = ((tabpage_address)TabPages[2]).textbox_input_country.Text;
            if (!((tabpage_address)TabPages[2]).textbox_input_state.Text.Equals("State")) ((tabpage_summary)TabPages[4]).textbox_state.Text = ((tabpage_address)TabPages[2]).textbox_input_state.Text;
            if (!((tabpage_address)TabPages[2]).textbox_input_city.Text.Equals("City")) ((tabpage_summary)TabPages[4]).textbox_city.Text = ((tabpage_address)TabPages[2]).textbox_input_city.Text;
            if (!((tabpage_address)TabPages[2]).textbox_input_street.Text.Equals("Street")) ((tabpage_summary)TabPages[4]).textbox_street.Text = ((tabpage_address)TabPages[2]).textbox_input_street.Text;
            if (!((tabpage_address)TabPages[2]).textbox_postal_code.Text.Equals("Postal Code")) ((tabpage_summary)TabPages[4]).textbox_postal_code.Text = ((tabpage_address)TabPages[2]).textbox_postal_code.Text;
            if (!((tabpage_address)TabPages[2]).textbox_postal_address.Text.Equals("Address")) ((tabpage_summary)TabPages[4]).textbox_postal_address.Text = ((tabpage_address)TabPages[2]).textbox_postal_address.Text;
            if (!((tabpage_payment)TabPages[3]).textbox_input_name.Text.Equals("Name")) ((tabpage_summary)TabPages[4]).textbox_card_name.Text = ((tabpage_payment)TabPages[3]).textbox_input_name.Text;
            if (!((tabpage_payment)TabPages[3]).textbox_input_card_number.Text.Equals("Card Number")) ((tabpage_summary)TabPages[4]).textbox_card_number.Text = ((tabpage_payment)TabPages[3]).textbox_input_card_number.Text;
            if (!((tabpage_payment)TabPages[3]).textbox_input_expiry_month.Text.Equals("Expiry Month")) ((tabpage_summary)TabPages[4]).textbox_expiry_month.Text = ((tabpage_payment)TabPages[3]).textbox_input_expiry_month.Text;
            if (!((tabpage_payment)TabPages[3]).textbox_input_expiry_year.Text.Equals("Expiry Year")) ((tabpage_summary)TabPages[4]).textbox_expiry_year.Text = ((tabpage_payment)TabPages[3]).textbox_input_expiry_year.Text;
            if (!((tabpage_payment)TabPages[3]).textbox_postal_cvv.Text.Equals("CVV")) ((tabpage_summary)TabPages[4]).textbox_cvv.Text = ((tabpage_payment)TabPages[3]).textbox_postal_cvv.Text;
        }
    }
}