using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_add : Button {
        form_main form_main;
        Panel panel_current, panel_next;
        panel_top panel_top;
        internal button_add(form_main form_main, Panel panel_current, panel_top panel_top) { // Constructor.
            this.form_main = form_main;
            this.panel_current = panel_current;
            this.panel_top = panel_top;
            int vertical_gap = (int)(panel_top.height * 1.2f);
            Width = 150;
            Height = 30;
            Location = new Point((panel_top.width - Width) / 2, panel_top.height + vertical_gap);
            if (panel_current.Name == "customers") Text = "Add Customer";
            else if (panel_current.Name == "products") Text = "Add Products";
            else if (panel_current.Name == "receipts") Text = "Add Receipts";
            Font = new Font(Font.FontFamily, (int)(Height * 0.4f));
            Click += event_handler_click;
        }
        private void event_handler_click(object sender, EventArgs e) {  // Calling main form method for changing panel.
            if (panel_current.Name == "products") panel_next = new panel_product_add(form_main, panel_top);
            else if (panel_current.Name == "receipts") panel_next = new panel_receipt_add(form_main, panel_top);
            ((form_main)Parent.Parent).open_new_panel(panel_current, panel_next);
        }
    }
}