using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_add_product : Button {
        DataGridView datagridview_list;
        DataGridView datagridview_single;
        form_main form_main;
        numericupdown numericupdown;
        label_text label_text_total_cost;
        Timer timer;
        bool mouse_down;
        int color_red, color_red_0;
        int limit_red = 250;
        int limit_reducer = 0;
        int transition_value = 20;
        internal button_add_product(int x, int y, DataGridView datagridview_single, DataGridView datagridview_list, form_main form_main, numericupdown numericupdown, label_text label_text_total_cost) { // Constructor.
            this.datagridview_list = datagridview_list;
            this.datagridview_single = datagridview_single;
            this.form_main = form_main;
            this.numericupdown = numericupdown;
            this.label_text_total_cost = label_text_total_cost;
            mouse_down = false;
            Size = new Size(80, 40);
            Location = new Point(x, y);
            Text = "Add";
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
        private void event_handler_mouse_click(object sender, EventArgs e) {
            if (datagridview_single.RowCount != 0) {
                if (datagridview_list.RowCount == 0) {
                    int i;
                    datagridview_list.ColumnCount = datagridview_single.ColumnCount + 2;
                    for (i = 0; i < datagridview_single.ColumnCount; i++) datagridview_list.Columns[i].Name = datagridview_single.Columns[i].Name;
                    datagridview_list.Columns[i].Name = "count";
                    datagridview_list.Columns[i + 1].Name = "cost";
                } 
                int index_row = search_product();
                if (index_row == -1) {
                    int i;
                    DataGridViewRow row_temp = (DataGridViewRow)datagridview_single.Rows[0].Clone();
                    for (i = 0; i < datagridview_single.Rows[0].Cells.Count; i++) row_temp.Cells[i].Value = datagridview_single.Rows[datagridview_single.Rows.Count - 1].Cells[i].Value;
                    row_temp.Cells.Add(new DataGridViewTextBoxCell());
                    row_temp.Cells.Add(new DataGridViewTextBoxCell());
                    row_temp.Cells[i].Value = Convert.ToInt32(numericupdown.Value);
                    row_temp.Cells[i + 1].Value = row_temp.Cells[i - 1].Value;
                    datagridview_list.Rows.Add(row_temp);
                } else {
                    datagridview_list.Rows[index_row].Cells["count"].Value = (int)(datagridview_list.Rows[index_row].Cells["count"].Value) + Convert.ToInt32(numericupdown.Value);
                    datagridview_list.Rows[index_row].Cells["cost"].Value = Convert.ToSingle(datagridview_list.Rows[index_row].Cells["price"].Value) * Convert.ToSingle(datagridview_list.Rows[index_row].Cells["count"].Value);
                }
                float total_cost = 0;
                foreach (DataGridViewRow row in datagridview_list.Rows) total_cost += Convert.ToSingle(row.Cells["cost"].Value);
                label_text_total_cost.Text = total_cost.ToString() + " TL";
            }
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
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
        private int search_product() {
            for (int i = 0; i < datagridview_list.Rows.Count; i++) if (datagridview_single.Rows[0].Cells[0].Value.Equals(datagridview_list.Rows[i].Cells[0].Value)) return i;
            return -1;
        }
    }
}