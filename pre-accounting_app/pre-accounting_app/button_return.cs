using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class button_return : Button {
        Panel panel_previous;
        internal button_return(Panel panel_previous) { // Constructor.
            int vertical_gap, horizantal_gap;
            vertical_gap = (int)(panel_top.height * 1.2f);
            horizantal_gap = vertical_gap;
            this.panel_previous = panel_previous;
            Width = 120;
            Height = (int)(Width * 0.33f);
            Location = new Point(panel_top.width - horizantal_gap - Width, panel_top.height + vertical_gap);
            Text = "Return";
            Font = new Font(Font.FontFamily, (int)(Height * 0.4f));
            Click += event_handler_click;
        }
        private void event_handler_click(object sender, EventArgs e) { // Calling main form method for changing panel.
            ((form_main)Parent.Parent).open_new_panel((Panel)Parent, panel_previous.Name);
        }
    }
}
