using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_product : TabPage {
        form_main form_main;
        internal tabpage_product(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            textbox_input textbox_input_name, textbox_input_surname, textbox_input_personal_id, textbox_input_tel, textbox_input_email;
            int horizantal_gap_0, horizantal_gap_1, vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3, vertical_gap_4;
            int location_x_combobox, location_y_combobox;
            location_y_combobox = horizantal_gap_0 = 50;
            horizantal_gap_1 = (int)(horizantal_gap_0 * 0.7f);
            location_x_combobox = vertical_gap_0 = 50;
            vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_4 = vertical_gap_3 = vertical_gap_2 = vertical_gap_1;
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            Text = "Product";
            datagridview datagridview = new datagridview(410, 100, location_x_combobox, location_y_combobox + horizantal_gap_1, form_main, tabcontrol);
            combobox_product combobox_product = new combobox_product(100, 30, location_x_combobox, location_y_combobox, datagridview, form_main);
            Controls.Add(combobox_product);
            Controls.Add(datagridview);
            Controls.Add(new button_next(form_main, tabcontrol));
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}