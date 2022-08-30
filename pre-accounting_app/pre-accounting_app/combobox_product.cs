using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class combobox_product : ComboBox {
        datagridview_product datagridview_product;
        form_main form_main;
        internal combobox_product(int width, int height, int x, int y, datagridview_product datagridview_product, form_main form_main) {  // Constructor.
            this.datagridview_product = datagridview_product;
            this.form_main = form_main;
            Size = new Size(width, height);
            Location = new Point(x, y);
            TabIndex = 0;
            Text = "Product Code";
            SqlConnection sql_connection = new SqlConnection("Data Source = DESKTOP-2GM0F2J; Initial Catalog = paa_db; Integrated Security = True ");
            sql_connection.Open();
            SqlCommand sql_command_select = new SqlCommand("SELECT code_product FROM products", sql_connection);
            sql_command_select.ExecuteNonQuery();
            SqlDataAdapter sql_data_adapter = new SqlDataAdapter(sql_command_select);
            DataTable data_table = new DataTable();
            sql_data_adapter.Fill(data_table);
            List<string> list_product = new List<string>();
            for (int i = 0; i < data_table.Rows.Count; i++) list_product.Add((string)data_table.Rows[i][0]);
            Items.AddRange(list_product.ToArray());
            sql_connection.Close();
            DropDownClosed += event_handler_drop_down_closed;
        }
        private void event_handler_drop_down_closed(object sender, EventArgs e) {
            datagridview_product.show_product((string)SelectedItem);
        }
    }
}