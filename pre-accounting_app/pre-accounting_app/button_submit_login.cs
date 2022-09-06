using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_submit_login : Button {
        Thread thread;
        form_login form_login;
        System.Windows.Forms.Timer timer;
        bool mouse_down;
        int color_red, color_red_0;
        int limit_red = 250;
        int limit_reducer = 0;
        int transition_value = 20;
        internal button_submit_login(int width, int height, int x, int y, string text_submit, form_login form_login) { // Constructor.
            this.form_login = form_login;
            mouse_down = false;
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Font = new Font (Font.FontFamily, (int)(Height * 0.25f));
            Text = text_submit;
            Font = new Font(Font.FontFamily, (int)(Height * 0.4f));
            ForeColor = Color.White;
            BackColor = Color.FromArgb(255, 173, 16, 23);
            color_red = color_red_0 = BackColor.R;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            Region = new Region(create_rounded_rectangle(new RectangleF(0, 0, Width, Height), 24));
            TabStop = false;
            timer = new System.Windows.Forms.Timer();
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
        private bool mouse_is_over_button(Button button) { // Detecting situation of hovering mouse cursor over button.
            return button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
        }
        private void event_handler_mouse_click(object sender, EventArgs e) { // Checking user information to access next form.
            try {
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
                } else {
                    sql_connection.Close();
                    MessageBox.Show("Access denied.");
                }
            } catch (SqlException) {
                MessageBox.Show("Selection failed.");
                return;
            }
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
        private void open_new_form(object sender) { // Opening new form.
            Application.Run(new form_main());
        }
    }
}