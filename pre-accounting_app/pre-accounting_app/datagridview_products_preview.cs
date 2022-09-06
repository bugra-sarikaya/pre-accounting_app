using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class datagridview_products_preview : DataGridView {
        internal datagridview_products_preview(int width, int height, int x, int y) { // Constructor.
            Size = new Size(width, height);
            Location = new Point(x, y);
            AllowUserToAddRows = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        internal void show_product(string id) {
            SqlConnection sql_connection = new SqlConnection("Data Source = DESKTOP-2GM0F2J; Initial Catalog = paa_db; Integrated Security = True ");
            sql_connection.Open();
            SqlCommand sql_command_select = new SqlCommand("SELECT * FROM products WHERE id = '" + id + "'", sql_connection);
            sql_command_select.ExecuteNonQuery();
            SqlDataAdapter sql_data_adapter = new SqlDataAdapter(sql_command_select);
            DataTable data_table = new DataTable();
            sql_data_adapter.Fill(data_table);
            DataSource = data_table;
            sql_connection.Close();
        }
    }
}