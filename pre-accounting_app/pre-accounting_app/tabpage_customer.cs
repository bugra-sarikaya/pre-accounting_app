using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class tabpage_customer : TabPage {
        form_main form_main;
        internal tabpage_customer(form_main form_main, TabControl tabcontrol) { // Constructor.
            this.form_main = form_main;
            textbox_input textbox_input_name, textbox_input_surname, textbox_input_personal_id, textbox_input_tel, textbox_input_email;
            int vertical_gap_0, vertical_gap_1, vertical_gap_2, vertical_gap_3, vertical_gap_4;
            vertical_gap_0 = 100;
            vertical_gap_1 = (int)(vertical_gap_0 * 0.7f);
            vertical_gap_4 = vertical_gap_3 = vertical_gap_2 = vertical_gap_1;
            Width = tabcontrol.Width;
            Height = tabcontrol.Height - tabcontrol.ItemSize.Height;
            Text = "Customer";
            textbox_input_name = new textbox_input(200, 30, (Width - 200) / 2, vertical_gap_0, "Name");
            textbox_input_surname = new textbox_input(textbox_input_name.Width, textbox_input_name.Height, textbox_input_name.Location.X, textbox_input_name.Location.Y + vertical_gap_1, "Surname");
            textbox_input_personal_id = new textbox_input(textbox_input_surname.Width, textbox_input_surname.Height, textbox_input_surname.Location.X, textbox_input_surname.Location.Y + vertical_gap_2, "Personal ID");
            textbox_input_tel = new textbox_input(textbox_input_personal_id.Width, textbox_input_personal_id.Height, textbox_input_personal_id.Location.X, textbox_input_personal_id.Location.Y + vertical_gap_3, "Telephone");
            textbox_input_email = new textbox_input(textbox_input_tel.Width, textbox_input_tel.Height, textbox_input_tel.Location.X, textbox_input_tel.Location.Y + vertical_gap_4, "E-mail");
            Controls.Add(textbox_input_name);
            Controls.Add(textbox_input_surname);
            Controls.Add(textbox_input_personal_id);
            Controls.Add(textbox_input_tel);
            Controls.Add(textbox_input_email);
            Controls.Add(new button_next(form_main, tabcontrol));
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}