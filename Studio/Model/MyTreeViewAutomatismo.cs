using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Studio.Model
{
    public class MyTreeViewAutomatismo : TreeViewItem
    {
        public MyTreeViewAutomatismo(Automatismo Auto, TextBox textBox) : base()
        {
            this.Auto = Auto;
            this.textBox = textBox;
            textBox.BorderBrush = Brushes.Transparent;
            this.Header = textBox;
        }

        public Automatismo Auto { get; set; }
        public TextBox textBox { get; set; }

    }
}
