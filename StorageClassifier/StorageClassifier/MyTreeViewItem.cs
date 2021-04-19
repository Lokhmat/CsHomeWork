using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Text;

namespace StorageClassifier
{
    [Serializable]
    class MyTreeViewItem : TreeViewItem
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
