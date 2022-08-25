using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_receipts : Panel {
        internal panel_receipts(form_main form_main) { // Constructor.
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
            Name = "receipts";
            Panel panel_current = this;
            Controls.Add(new button_return(form_main, panel_current));
        }
    }
}