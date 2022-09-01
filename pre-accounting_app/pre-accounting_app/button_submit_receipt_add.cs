using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_submit_receipt_add : Button{
        form_main form_main;
        Panel panel_current;
        TabControl tabcontrol;
        //textbox_input textbox_input_name, textbox_input_price;
        internal button_submit_receipt_add(form_main form_main, Panel panel_current, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            this.panel_current = panel_current;
            this.tabcontrol = tabcontrol;
            int vertical_gap_0, horizantal_gap_0;
            vertical_gap_0 = horizantal_gap_0 = 30;
            Size = new Size(80, 50);
            Location = new Point(tabcontrol.Width - Width - vertical_gap_0, tabcontrol.Height - Height - horizantal_gap_0 - tabcontrol.ItemSize.Height);
            Text = "Accept";
            Font = new Font(Font.FontFamily, (int)(Height * 0.25f));
            Click += event_handler_click;
        }
        private void event_handler_click(object sender, EventArgs e) { // Inserting a new row to "product" table.
            SqlConnection sql_connection = new SqlConnection("Data Source = DESKTOP-2GM0F2J; Initial Catalog = paa_db; Integrated Security = True ");
            sql_connection.Open();
            SqlCommand sql_command_insert_customers = new SqlCommand("INSERT INTO customers VALUES ('" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_name.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_surname.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_personal_id.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_tel.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_email.Text + "')", sql_connection);
            sql_command_insert_customers.ExecuteNonQuery();
            SqlCommand sql_command_insert_addresses = new SqlCommand("INSERT INTO addresses VALUES ('" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_country.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_state.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_city.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_street.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_postal_code.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_postal_address.Text + "')", sql_connection);
            sql_command_insert_addresses.ExecuteNonQuery();
            SqlCommand sql_command_insert_payments = new SqlCommand("INSERT INTO payments VALUES ('" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_card_name.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_card_number.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_expiry_month.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_expiry_year.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).textbox_cvv.Text + "')", sql_connection);
            sql_command_insert_payments.ExecuteNonQuery();
            SqlCommand sql_command_insert_orders = new SqlCommand("INSERT INTO orders VALUES((SELECT MAX(id) FROM customers), (SELECT MAX(id) FROM addresses), (SELECT MAX(id) FROM payments))", sql_connection);
            sql_command_insert_orders.ExecuteNonQuery();
            SqlCommand sql_command_insert_order_items;
            for (int i = 0; i < ((tabpage_summary)tabcontrol.TabPages[4]).datagridview_order.RowCount; i++) {
                sql_command_insert_order_items = new SqlCommand("INSERT INTO order_items VALUES ((SELECT MAX(id) FROM orders), '" + ((tabpage_summary)tabcontrol.TabPages[4]).datagridview_order.Rows[i].Cells[0].Value + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).datagridview_order.Rows[i].Cells[3].Value + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).datagridview_order.Rows[i].Cells[4].Value.ToString().Replace(",", ".") + "')", sql_connection);
                sql_command_insert_order_items.ExecuteNonQuery();
            }
            SqlCommand sql_command_insert_receitps = new SqlCommand("INSERT INTO receipts VALUES((SELECT MAX(id) FROM orders), '"+ ((tabpage_summary)tabcontrol.TabPages[4]).textbox_total_cost.Text.Replace(",", ".") + "', '" + DateTime.Now + "')", sql_connection);
            sql_command_insert_receitps.ExecuteNonQuery();
            sql_connection.Close();
            MessageBox.Show("Insertion succeeded.");
            form_main.open_new_panel(panel_current, new panel_receipts(form_main, (panel_top)(form_main.Controls[0])));
        }
    }
}
