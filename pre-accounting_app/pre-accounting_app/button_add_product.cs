using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_add_product : Button {
        DataGridView datagridview_list;
        DataGridView datagridview_single;
        form_main form_main;
        numericupdown numericupdown;
        TextBox textbox_total_cost;
        internal button_add_product(int width, int height, int x, int y, DataGridView datagridview_single, DataGridView datagridview_list, form_main form_main, numericupdown numericupdown, TextBox textbox_total_cost) { // Constructor.
            this.datagridview_list = datagridview_list;
            this.datagridview_single = datagridview_single;
            this.form_main = form_main;
            this.numericupdown = numericupdown;
            this.textbox_total_cost = textbox_total_cost;
            Size = new Size(width, height);
            Location = new Point(x, y);
            Text = "Add";
            textbox_total_cost.Text = "0";
            Font = new Font(Font.FontFamily, (int)(Height * 0.25f));
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
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
                textbox_total_cost.Text = total_cost.ToString();
            }
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
        private int search_product() {
            for (int i = 0; i < datagridview_list.Rows.Count; i++) if (datagridview_single.Rows[0].Cells[1].Value.Equals(datagridview_list.Rows[i].Cells[1].Value)) return i;
            return -1;
        }
    }
}
