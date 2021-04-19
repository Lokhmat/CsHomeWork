using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Text;

namespace StorageClassifier
{
    /// <summary>
    /// Sub class so TreeView also could contain products.
    /// </summary>
    [Serializable]
    public class MyTreeViewItem : TreeViewItem
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
