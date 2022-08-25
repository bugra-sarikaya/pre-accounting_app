using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_main : Panel {
        internal panel_main(form_main form_main) { // Constructor.
            int button_width, button_height, horizantal_gap;
            button_width = button_height = 140;
            horizantal_gap = (int)(button_width * 0.4f);
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Name = "main";
            button_main button_main_products = new button_main(button_width, button_height, (form_main.Width - button_width) / 2, (form_main.Height - button_height) / 2, "Products", form_main, this);
            button_main button_main_customers = new button_main(button_width, button_height, button_main_products.Location.X - button_main_products.Width - horizantal_gap, button_main_products.Location.Y, "Customers", form_main, this);
            button_main button_main_reports = new button_main(button_width, button_height, button_main_products.Location.X + button_main_products.Width + horizantal_gap, button_main_products.Location.Y, "Receipts", form_main, this);
            Controls.Add(button_main_products);
            Controls.Add(button_main_customers);
            Controls.Add(button_main_reports);
        }
    }
}