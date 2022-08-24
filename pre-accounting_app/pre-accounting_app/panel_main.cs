using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_main : Panel {
        internal panel_main(form_main form) { // Constructor.
            int button_width, button_height, horizantal_gap;
            button_width = button_height = 140;
            horizantal_gap = (int)(button_width * 0.4f);
            Width = form.Width;
            Height = form.Height - panel_top.height;
            Name = "main";
            button_main button_main_products = new button_main(button_width, button_height, (form.Width - button_width) / 2, (form.Height - button_height) / 2, "Products");
            button_main button_main_customers = new button_main(button_width, button_height, button_main_products.Location.X - button_main_products.Width - horizantal_gap, button_main_products.Location.Y, "Customers");
            button_main button_main_reports = new button_main(button_width, button_height, button_main_products.Location.X + button_main_products.Width + horizantal_gap, button_main_products.Location.Y, "Receipts");
            Controls.Add(button_main_products);
            Controls.Add(button_main_customers);
            Controls.Add(button_main_reports);
        }
    }
}