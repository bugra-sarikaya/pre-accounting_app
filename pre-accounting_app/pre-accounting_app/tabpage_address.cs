using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_address : TabPage {
        form_main form_main;
        internal tabpage_address(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            textbox_input textbox_input_country, textbox_input_state, textbox_input_city, textbox_input_street, textbox_postal_code, textbox_postal_address;
            int vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3, vertical_gap_4, vertical_gap_5;
            vertical_gap_0 = 100;
            vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_5 = vertical_gap_4 = vertical_gap_3 = vertical_gap_2 = vertical_gap_1;
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            Text = "Address";
            textbox_input_country = new textbox_input(200, 30, (Width - 200) / 2, vertical_gap_0, "Country");
            textbox_input_state = new textbox_input(textbox_input_country.Width, textbox_input_country.Height, textbox_input_country.Location.X, textbox_input_country.Location.Y + vertical_gap_1, "State");
            textbox_input_city = new textbox_input(textbox_input_state.Width, textbox_input_state.Height, textbox_input_state.Location.X, textbox_input_state.Location.Y + vertical_gap_2, "City");
            textbox_input_street = new textbox_input(textbox_input_city.Width, textbox_input_city.Height, textbox_input_city.Location.X, textbox_input_city.Location.Y + vertical_gap_3, "Street");
            textbox_postal_code = new textbox_input(textbox_input_street.Width, textbox_input_street.Height, textbox_input_street.Location.X, textbox_input_street.Location.Y + vertical_gap_4, "Postal Code");
            textbox_postal_address = new textbox_input(textbox_postal_code.Width, textbox_postal_code.Height, textbox_postal_code.Location.X, textbox_postal_code.Location.Y + vertical_gap_5, "Address");
            Controls.Add(textbox_input_country);
            Controls.Add(textbox_input_state);
            Controls.Add(textbox_input_city);
            Controls.Add(textbox_input_street);
            Controls.Add(textbox_postal_code);
            Controls.Add(textbox_postal_address);
            Controls.Add(new button_next(form_main, tabcontrol));
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}