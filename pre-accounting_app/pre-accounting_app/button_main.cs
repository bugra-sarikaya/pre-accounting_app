using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_main : Button {
        String name_panel_destination;
        internal button_main(int width, int height, int x, int y, String text) { // Constructor.
            Width = width;
            Height = height;
            Location = new Point(x, y);
            Text = name_panel_destination = text;
            if (text == "Customers") name_panel_destination = "customers";
            else if (text == "Products") name_panel_destination = "products";
            else if (text == "Receipts") name_panel_destination = "receipts";
            Font = new Font(Font.FontFamily, (int)(Height * 0.13f));
            ForeColor = Color.Black;
            Click += event_handler_click;
        }
        private void event_handler_click(object sender, EventArgs e) { // Calling main form method for changing panel.
            ((form_main)Parent.Parent).open_new_panel((Panel)Parent, name_panel_destination);
        }
    }
}