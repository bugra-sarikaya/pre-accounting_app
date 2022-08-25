using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_receipt_add : Panel {
        internal panel_receipt_add(form_main form_main) {
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
        }
    }
}
