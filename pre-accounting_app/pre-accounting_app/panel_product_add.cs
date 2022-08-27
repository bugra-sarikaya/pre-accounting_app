using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_product_add : Panel {
        button_submit_product_add button_submit_product_add;
        form_main form_main;
        textbox_input textbox_input_name, textbox_input_price;
        internal panel_product_add(form_main form_main) { // Constructor.
           this.form_main = form_main;
            int inital_vertical_gap, second_vertical_gap, third_vertical_gap;
            inital_vertical_gap = 100;
            second_vertical_gap = (int)(inital_vertical_gap * 0.7f);
            third_vertical_gap = (int)(second_vertical_gap * 1.5f);
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Name = "add_product";
            textbox_input_name = new textbox_input(200, 30, (Width - 200) / 2, inital_vertical_gap, "Name");
            textbox_input_price = new textbox_input(textbox_input_name.Width, textbox_input_name.Height, textbox_input_name.Location.X, textbox_input_name.Location.Y +second_vertical_gap, "Price");
            button_return button_return = new button_return(form_main, this);
            button_submit_product_add = new button_submit_product_add(textbox_input_price.Width, textbox_input_price.Height, (Width - textbox_input_price.Width) / 2, textbox_input_price.Location.Y + third_vertical_gap, "Accept", textbox_input_name, textbox_input_price, button_return);
            form_main.assign_button_submit(button_submit_product_add);
            Controls.Add(textbox_input_name);
            Controls.Add(textbox_input_price);
            Controls.Add(button_submit_product_add);
            Controls.Add(button_return);
            MouseDown += event_handler_mouse_down;
        }
        private void event_handler_mouse_down(object sender, MouseEventArgs e) { // Disabling focusing after pressing on form.
            form_main.event_handler_mouse_down(sender, e);
        }
    }
}