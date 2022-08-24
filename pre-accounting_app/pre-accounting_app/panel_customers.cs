using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_customers : Panel {
        internal panel_customers(form_main form_main, Panel previous_panel) { // Constructor.
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Name = "customers";
            //Button button_customers_add = new Button();
            Controls.Add(new button_return(previous_panel));
            
        }
    }
}