using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabcontrol : TabControl {
        internal tabcontrol(int width, int height, int x, int y, form_main form_main) { // Constructor.
            Size = new Size(width, height);
            Location = new Point(x, y);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(60, 30);
            TabPages.Add(new tabpage_order(form_main, this));
            TabPages.Add(new tabpage_customer(form_main, this));
            TabPages.Add(new tabpage_address(form_main, this));
            TabPages.Add(new tabpage_payment(form_main, this));
            TabPages.Add(new tabpage_summary(form_main, this));
            SelectedIndexChanged += selected_index_changed_event_handler;
        }
        private void selected_index_changed_event_handler(object sender, EventArgs e) {
            datagridview_product data_order = ((tabpage_order)TabPages[0]).datagridview_product_list;
            datagridview_product data_summary = ((tabpage_summary)TabPages[4]).datagridview_order;
            textbox total_cost_order = ((tabpage_order)TabPages[0]).textbox_total_cost;
            textbox total_cost_summary = ((tabpage_summary)TabPages[4]).textbox_total_cost;
            data_summary.Rows.Clear();
            data_summary.Columns.Clear();
            data_summary.ColumnCount = data_order.ColumnCount;
            for (int i = 0; i < data_order.ColumnCount; i++) data_summary.Columns[i].Name = data_order.Columns[i].Name;
            for (int i = 0; i < data_order.RowCount; i++) {
                data_summary.Rows.Add(data_order.Rows[i].Clone());
                for (int j = 0; j < data_order.ColumnCount; j++) {
                    data_summary.Rows[i].Cells[j].Value = data_order.Rows[i].Cells[j].Value;
                }
            }
            total_cost_summary.Text = total_cost_order.Text;
        }
    }
}