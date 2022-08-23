using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class form_main : Form {
        internal form_main() { // Constructor.
            Width = 1000;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            Controls.Add(new panel_top(this));
            Controls.Add(new panel_main(this));
            ControlRemoved += event_handler_control_removed;
        }
        private void event_handler_control_removed(object sender, ControlEventArgs e) {
            //MessageBox.Show(""+e.Control.Text);
        }
        internal void open_new_panel(Panel panel, String name_panel) { // Changing panels.
            Controls.Remove(panel);
            Controls.Add(new panel_main(this));
        }
    }
}