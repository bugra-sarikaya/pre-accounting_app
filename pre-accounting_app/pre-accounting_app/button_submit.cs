using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_submit : Button {
        Thread thread;
        internal button_submit(int width, int height, int x, int y, String text_submit) { // Constructor.
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Font = new Font (Font.FontFamily, (int)(Height * 0.25f));
            Text = text_submit;
            ForeColor = Color.Black;
            Click += event_handler_click;
           
        }
        private void event_handler_click(object sender, EventArgs e) { // Checking user information to access next form.
            SqlConnection sql_connection = new SqlConnection("Data Source = DESKTOP-2GM0F2J; Initial Catalog = paa_db; Integrated Security = True ");
            sql_connection.Open();
            SqlCommand sql_command_login = new SqlCommand("SELECT * FROM users WHERE username = '" + form_login.textbox_username.Text + "' AND password = '" + form_login.textbox_password.Text + "'", sql_connection);
            SqlDataAdapter sql_data_adapter = new SqlDataAdapter(sql_command_login);
            DataTable data_table = new DataTable();
            sql_data_adapter.Fill(data_table);
            if (data_table.Rows.Count == 1) {
                sql_connection.Close();
                ((Form)Parent).Close();
                thread = new Thread(open_new_form);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            } else MessageBox.Show("Access denied.");
            sql_connection.Close();
        }
        private void open_new_form(object sender) { // Opening new form.
            Application.Run(new Form());
        }
    }
}