using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_product_add : Panel {
        Button button_submit;
        textbox_input textbox_input_name, textbox_input_price;
        internal panel_product_add(form_main form_main) { // Constructor.
            int inital_vertical_gap, second_vertical_gap, third_vertical_gap;
            inital_vertical_gap = 100;
            second_vertical_gap = (int)(inital_vertical_gap * 0.7f);
            third_vertical_gap = (int)(second_vertical_gap * 1.5f);
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Name = "add_product";
            textbox_input_name = new textbox_input(200, 30, (Width - 200) / 2, inital_vertical_gap, "Name");
            textbox_input_price = new textbox_input(textbox_input_name.Width, textbox_input_name.Height, textbox_input_name.Location.X, textbox_input_name.Location.Y +second_vertical_gap, "Price");
            button_submit = new button_submit(textbox_input_price.Width, textbox_input_price.Height, (Width - textbox_input_price.Width) / 2, textbox_input_price.Height + third_vertical_gap, "Accept");
            form_main.assign_button_submit(button_submit);
            Controls.Add(textbox_input_name);
            Controls.Add(textbox_input_price);
            Controls.Add(new button_return(form_main, this));
        }
    }
}