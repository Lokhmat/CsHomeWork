using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Text;

namespace StorageClassifier
{
    class MyTreeViewItem : TreeViewItem
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
