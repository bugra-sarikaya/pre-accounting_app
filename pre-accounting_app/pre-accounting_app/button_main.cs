using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_main : Button {
        Panel panel_current, panel_next;
        panel_top panel_top;
        form_main form_current;
        internal button_main(int width, int height, int x, int y, string text, form_main form_current, Panel panel_current, panel_top panel_top) { // Constructor.
            this.form_current = form_current;
            this.panel_current = panel_current;
            this.panel_top = panel_top;
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Text = text;
            Font = new Font(Font.FontFamily, (int)(Height * 0.13f));
            ForeColor = Color.Black;
            Click += event_handler_click;
        }
        private void event_handler_click(object sender, EventArgs e) { // Calling main form method for changing panel.
            if (Text == "Customers") panel_next = new panel_customers(form_current, panel_top);
            else if (Text == "Products") panel_next = new panel_products(form_current, panel_top);
            else if (Text == "Receipts") panel_next = new panel_receipts(form_current, panel_top);
            ((form_main)Parent.Parent).open_new_panel(panel_current, panel_next);
        }
    }
}