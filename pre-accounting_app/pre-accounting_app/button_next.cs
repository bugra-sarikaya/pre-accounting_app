using pre_accounting_app;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_next : Button {
        form_main form_main;
        TabControl tabcontrol;
        internal button_next(form_main form_main, TabControl tabcontrol) {
            this.form_main = form_main;
            this.tabcontrol = tabcontrol;
            int vertical_gap_0, horizantal_gap_0;
            vertical_gap_0 = horizantal_gap_0 = 30;
            Size = new Size(80, 50);
            Location = new Point(tabcontrol.Width - Width - vertical_gap_0, tabcontrol.Height - Height - horizantal_gap_0 - tabcontrol.ItemSize.Height);
            Text = "Next";
            Font = new Font(Font.FontFamily, (int)(Height * 0.25f));
            Click += click_event_handler_button;
        }
        private void click_event_handler_button(object sender, EventArgs e) {
            tabcontrol.SelectedIndex++;
            form_main.event_handler_mouse_down(sender, (MouseEventArgs)e);
        }
    }
}