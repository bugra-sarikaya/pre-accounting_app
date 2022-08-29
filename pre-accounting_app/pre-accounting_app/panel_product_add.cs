using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_product_add : Panel {
        button_submit_product_add button_submit_product_add;
        form_main form_main;
        textbox_input textbox_input_name, textbox_code_product, textbox_input_price;
        internal panel_product_add(form_main form_main, panel_top panel_top) { // Constructor.
           this.form_main = form_main;
            int vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3;
            vertical_gap_0 = 100;
            vertical_gap_2 = vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_3 = (int)(vertical_gap_2 * 1.5f);
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Name = "add_product";
            textbox_input_name = new textbox_input(200, 30, (Width - 200) / 2, vertical_gap_0, "Name");
            textbox_code_product = new textbox_input(textbox_input_name.Width, textbox_input_name.Height, textbox_input_name.Location.X, textbox_input_name.Location.Y + vertical_gap_1, "Product Code");
            textbox_input_price = new textbox_input(textbox_code_product.Width, textbox_code_product.Height, textbox_code_product.Location.X, textbox_code_product.Location.Y + vertical_gap_2, "Price");
            button_return button_return = new button_return(form_main, this, panel_top);
            button_submit_product_add = new button_submit_product_add(textbox_input_price.Width, textbox_input_price.Height, (Width - textbox_input_price.Width) / 2, textbox_input_price.Location.Y + vertical_gap_3, textbox_input_name, textbox_code_product, textbox_input_price, button_return);
            form_main.assign_button_submit(button_submit_product_add);
            Controls.Add(textbox_input_name);
            Controls.Add(textbox_code_product);
            Controls.Add(textbox_input_price);
            Controls.Add(button_submit_product_add);
            Controls.Add(button_return);
            Click += click_event_handler_button;
            MouseDown += event_handler_mouse_down;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Disabling focusing after pressing on form.
            form_main.event_handler_mouse_down(sender, e);
        }
    }
}