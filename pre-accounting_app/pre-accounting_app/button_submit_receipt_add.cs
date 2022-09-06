using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_submit_receipt_add : Button{
        form_main form_main;
        Panel panel_current;
        TabControl tabcontrol;
        Timer timer;
        bool mouse_down;
        int color_red, color_red_0;
        int limit_red = 250;
        int limit_reducer = 0;
        int transition_value = 20;
        internal button_submit_receipt_add(form_main form_main, Panel panel_current, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            this.panel_current = panel_current;
            this.tabcontrol = tabcontrol;
            int vertical_gap_0, horizantal_gap_0;
            mouse_down = false;
            vertical_gap_0 = horizantal_gap_0 = 30;
            Size = new Size(90, 40);
            Location = new Point(tabcontrol.Width - Width - vertical_gap_0, tabcontrol.Height - Height - horizantal_gap_0 - tabcontrol.ItemSize.Height);
            Text = "Accept";
            Font = new Font(Font.FontFamily, (int)(Height * 0.4f));
            ForeColor = Color.White;
            BackColor = Color.FromArgb(255, 173, 16, 23);
            color_red = color_red_0 = BackColor.R;
            TabStop = false;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            Region = new Region(create_rounded_rectangle(new RectangleF(0, 0, Width, Height), 24));
            timer = new Timer();
            timer.Enabled = false;
            timer.Tick += event_handler_timer;
            MouseClick += event_handler_mouse_click;
            MouseDown += event_handler_mouse_down;
            MouseUp += event_handler_mouse_up;
            MouseLeave += event_handler_mouse_leave;
        }
        protected override void OnMouseEnter(EventArgs e) {
            timer.Enabled = true;
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            event_handler_mouse_down(this, e);
        }
        private void event_handler_mouse_click(object sender, EventArgs e) { // Inserting a new row to "product" table.
            if (!check_inputs()) {
                MessageBox.Show("Inputs are missing.");
                return;
            }
            try {
                SqlConnection sql_connection = new SqlConnection("Data Source = DESKTOP-2GM0F2J; Initial Catalog = paa_db; Integrated Security = True ");
                sql_connection.Open();
                SqlCommand sql_command_insert_customers = new SqlCommand("INSERT INTO customers VALUES ('" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_name_value.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_surname_value.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_personal_id_value.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_tel_value.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_email_value.Text + "')", sql_connection);
                sql_command_insert_customers.ExecuteNonQuery();
                SqlCommand sql_command_insert_addresses = new SqlCommand("INSERT INTO addresses VALUES ('" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_country_value.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_state_value.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_city_value.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_street_value.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_postal_code_value.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_postal_address_value.Text + "')", sql_connection);
                sql_command_insert_addresses.ExecuteNonQuery();
                SqlCommand sql_command_insert_payments = new SqlCommand("INSERT INTO payments VALUES ('" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_card_name_value.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_card_number_value.Text + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_expiry_month_value.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_expiry_year_value.Text + "' , '" + ((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_cvv_value.Text + "')", sql_connection);
                sql_command_insert_payments.ExecuteNonQuery();
                SqlCommand sql_command_insert_orders = new SqlCommand("INSERT INTO orders VALUES((SELECT MAX(id) FROM customers), (SELECT MAX(id) FROM addresses), (SELECT MAX(id) FROM payments))", sql_connection);
                sql_command_insert_orders.ExecuteNonQuery();
                SqlCommand sql_command_insert_order_items;
                for (int i = 0; i < ((tabpage_summary)tabcontrol.TabPages[4]).datagridview_order.RowCount; i++) {
                    sql_command_insert_order_items = new SqlCommand("INSERT INTO order_items VALUES ((SELECT MAX(id) FROM orders), '" + ((tabpage_summary)tabcontrol.TabPages[4]).datagridview_order.Rows[i].Cells[0].Value + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).datagridview_order.Rows[i].Cells[3].Value + "', '" + ((tabpage_summary)tabcontrol.TabPages[4]).datagridview_order.Rows[i].Cells[4].Value.ToString().Replace(",", ".") + "')", sql_connection);
                    sql_command_insert_order_items.ExecuteNonQuery();
                }
                SqlCommand sql_command_insert_receitps = new SqlCommand("INSERT INTO receipts VALUES((SELECT MAX(id) FROM orders), '" + ((tabpage_summary)tabcontrol.TabPages[4]).label_text_total_cost_value.Text.Replace(",", ".").Replace(" TL", "") + "', '" + DateTime.Now + "')", sql_connection);
                sql_command_insert_receitps.ExecuteNonQuery();
                sql_connection.Close();
            } catch (SqlException) {
                MessageBox.Show("Insertion failed.");
                return;
            }
            form_main.open_new_panel(panel_current, new panel_receipts(form_main, (panel_top)(form_main.Controls[0])));
        }
        private bool mouse_is_over_button(Button button) { // Detecting situation of hovering mouse cursor over button.
            return button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
        }
        private void event_handler_timer(object sender, EventArgs e) { // Enabling hovering mouse cursor effect smoothly.
            if (mouse_is_over_button(this) && color_red <= limit_red - transition_value - limit_reducer) {
                color_red += transition_value;
                BackColor = change_red_color(BackColor, color_red);
                Refresh();
            } else if (!mouse_is_over_button(this) && color_red >= transition_value) {
                color_red -= transition_value;
                BackColor = change_red_color(BackColor, color_red);
                Refresh();
            }
            if (color_red > limit_red) color_red = limit_red;
            if (color_red < color_red_0) color_red = color_red_0;
            if (!mouse_is_over_button(this) && !mouse_down && color_red == color_red_0) timer.Enabled = false;
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            mouse_down = true;
            if (mouse_is_over_button(this) && e.Button == MouseButtons.Left) {
                BackColor = change_red_color(BackColor, color_red - transition_value);
                Refresh();
                limit_reducer = transition_value;
            }
        }
        private void event_handler_mouse_up(object sender, MouseEventArgs e) { // Enabling pressing button effect.
            mouse_down = false;
            if (mouse_is_over_button(this) && e.Button == MouseButtons.Left) event_handler_mouse_click(this, e);
        }
        private void event_handler_mouse_leave(object sender, EventArgs e) { // Disabling pressing button effect.
            limit_reducer = 0;
        }
        private Color change_red_color(Color color, int color_red) { // Changing red color value of button.
            if (color_red <= limit_red && color_red >= color_red_0) color = Color.FromArgb(color.A, color_red, color.G, color.B);
            return color;
        }
        private GraphicsPath create_rounded_rectangle(RectangleF rectanglef, int r, bool fill = false) { // Creating rounded rectangle.
            GraphicsPath path = new GraphicsPath();
            var r2 = r / 2;
            var fix = fill ? 1 : 0;
            rectanglef.Location = new Point((int)(rectanglef.X - 1), (int)(rectanglef.Y - 1));
            if (!fill) rectanglef.Size = new Size((int)(rectanglef.Width - 1), (int)(rectanglef.Height - 1));
            path.AddArc(rectanglef.Left, rectanglef.Top, r, r, 180, 90);
            path.AddLine(rectanglef.Left + r2, rectanglef.Top, rectanglef.Right - r2 - fix, rectanglef.Top);
            path.AddArc(rectanglef.Right - r - fix, rectanglef.Top, r, r, 270, 90);
            path.AddLine(rectanglef.Right, rectanglef.Top + r2, rectanglef.Right, rectanglef.Bottom - r2);
            path.AddArc(rectanglef.Right - r - fix, rectanglef.Bottom - r - fix, r, r, 0, 90);
            path.AddLine(rectanglef.Right - r2, rectanglef.Bottom, rectanglef.Left + r2, rectanglef.Bottom);
            path.AddArc(rectanglef.Left, rectanglef.Bottom - r - fix, r, r, 90, 90);
            path.AddLine(rectanglef.Left, rectanglef.Bottom - r2, rectanglef.Left, rectanglef.Top + r2);
            return path;
        }
        private bool check_inputs() {
            if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_name_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_surname_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_personal_id_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_tel_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_customer.label_text_email_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_country_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_state_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_city_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_street_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_postal_code_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_address.label_text_postal_address_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_card_name_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_card_number_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_expiry_month_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_expiry_month_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).groupbox_payment.label_text_cvv_value.Text)) return false;
            else if (string.IsNullOrEmpty(((tabpage_summary)tabcontrol.TabPages[4]).label_text_total_cost_value.Text)) return false;
            return true;
        }
    }
}