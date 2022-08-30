using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre_accounting_app {
    internal class numericupdown : NumericUpDown {
        internal numericupdown (int width, int height, int x, int y) { // Constructor.
            Size = new Size(width, height);
            Location = new Point(x, y);
            Minimum = 1;
            Maximum = 100;
        }
    }
}