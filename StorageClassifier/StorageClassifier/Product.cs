using System;
using System.Collections.Generic;
using System.Text;

namespace StorageClassifier
{
    /// <summary>
    /// Class for product realization.
    /// </summary>
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int Left { get; set; }
        public string Path { get; set; }
    }
}
