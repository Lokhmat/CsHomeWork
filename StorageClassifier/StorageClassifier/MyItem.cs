using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace StorageClassifier
{
    class MyItem
    {
        public List<MyItem> Items { get; set; } = new List<MyItem>();
        public List<Product> Products { get; set; } = new List<Product>();
        public string Header { get; set; }
        [JsonIgnore]
        public MyTreeViewItem prototype;
    }
}
