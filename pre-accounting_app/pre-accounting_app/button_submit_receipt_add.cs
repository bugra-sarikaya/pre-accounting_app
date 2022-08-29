using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_submit_receipt_add : Button{
        button_return button_return;
        form_main form_main;
        TabControl tabcontrol;
        textbox_input textbox_input_name, textbox_input_price;
        internal button_submit_receipt_add(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
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
            SqlCommand sql_command_insert = new SqlCommand("INSERT INTO products VALUES ('" + textbox_input_name.Text + "', '" + textbox_input_price.Text.Replace(",", ".") + "')", sql_connection);
            sql_command_insert.ExecuteNonQuery();
            sql_connection.Close();
            MessageBox.Show("Insertion succeeded.");
            button_return.event_handler_click(sender, e);
        }
    }
}
