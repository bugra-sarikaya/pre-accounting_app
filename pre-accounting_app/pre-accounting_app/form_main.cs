using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class form_main : Form {
        panel_main panel_main;
        internal form_main() { // Constructor.
            Width = 1000;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            panel_main = new panel_main(this);
            Controls.Add(new panel_top(this));
            Controls.Add(panel_main);
        }
        internal void open_new_panel(Panel panel_current, String name_panel_destination) { // Changing panels.
            Controls.Remove(panel_current);
            if (name_panel_destination == "main") Controls.Add(new panel_main(this));
            else if (name_panel_destination == "customers") Controls.Add(new panel_customers(this, panel_current));
            else if (name_panel_destination == "products") Controls.Add(new panel_products(this, panel_current));
            else if (name_panel_destination == "receipts") Controls.Add(new panel_receipts(this, panel_current));
        }
    }
}