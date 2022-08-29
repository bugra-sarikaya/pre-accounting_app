using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_customers : Panel {
        internal panel_customers(form_main form_main, panel_top panel_top) { // Constructor.
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Location = new Point(0, panel_top.Height);
            Name = "customers";
            Controls.Add(new button_return(form_main, this, panel_top));
            
        }
    }
}