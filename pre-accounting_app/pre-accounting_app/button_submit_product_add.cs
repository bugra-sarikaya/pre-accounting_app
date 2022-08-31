using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_submit_product_add : Button {
        button_return button_return;
        textbox_input textbox_input_name, textbox_input_price;
        internal button_submit_product_add(int width, int height, int x, int y, textbox_input textbox_input_name, textbox_input textbox_input_price, button_return button_return) { // Constructor.
            this.button_return = button_return;
            this.textbox_input_name = textbox_input_name;
            this.textbox_input_price = textbox_input_price;
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Font = new Font(Font.FontFamily, (int)(Height * 0.25f));
            Text = "Accept";
            ForeColor = Color.Black;
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