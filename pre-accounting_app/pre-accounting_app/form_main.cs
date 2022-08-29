using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class form_main : Form {
        panel_main panel_main;
        internal form_main() { // Constructor.
            Width = 1000;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            form_main form_main = this;
            panel_top panel_top = new panel_top(form_main);
            panel_main = new panel_main(form_main, panel_top);
            Controls.Add(panel_top);
            Controls.Add(panel_main);
            MouseDown += event_handler_mouse_down;
        }
        internal void event_handler_mouse_down(object sender, MouseEventArgs e) { // Disabling focusing after pressing on form.
            ActiveControl = null;
        }
        internal void assign_button_submit(Button button_submit) { // Setting passed button as accept button.
            AcceptButton = button_submit;
        }
        internal void open_new_panel(Panel panel_current, Panel panel_new) { // Changing panels.
            Controls.Remove(panel_current);
            Controls.Add(panel_new);
        }
    }
}