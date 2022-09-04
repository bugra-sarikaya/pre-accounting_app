using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_main : Panel {
        internal panel_main(form_main form_main, panel_top panel_top) { // Constructor.
            int horizantal_gap_0, horizantal_gap_1;
            horizantal_gap_0 = (int)(panel_top.Height * 5.5f);
            horizantal_gap_1 = (int)(horizantal_gap_0 * 0.3f);
            Width = form_main.Width;
            Height = form_main.Height - panel_top.Height;
            Location = new Point(0, panel_top.Height);
            Name = "main";
            button_main_customers button_main_customers = new button_main_customers((Width - button_main.width) / 2, horizantal_gap_0, form_main, this, panel_top);
            button_main_products button_main_products = new button_main_products((Width - button_main.width) / 2, button_main_customers.Location.Y + button_main_customers.Height + horizantal_gap_1, form_main, this, panel_top);
            button_main_receipts button_main_receipts = new button_main_receipts((Width - button_main.width) / 2, button_main_products.Location.Y + button_main_products.Height + horizantal_gap_1, form_main, this, panel_top);
            Controls.Add(button_main_customers);
            Controls.Add(button_main_products);
            Controls.Add(button_main_receipts);
        }
    }
}