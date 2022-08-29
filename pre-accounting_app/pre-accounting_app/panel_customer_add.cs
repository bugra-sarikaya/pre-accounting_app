using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class panel_customer_add : Panel {
        internal panel_customer_add(form_main form_main, panel_top panel_top) {
            Width = form_main.Width;
            Height = form_main.Height - panel_top.height;
        }
    }
}