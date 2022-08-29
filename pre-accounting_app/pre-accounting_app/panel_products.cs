using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_products : Panel {
        internal panel_products(form_main form_main, panel_top panel_top) { // Constructor.
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Location = new Point(0, panel_top.Height);
            Name = "products";
            Controls.Add(new button_add(form_main, this, panel_top));
            Controls.Add(new button_return(form_main, this, panel_top));
        }
    }
}