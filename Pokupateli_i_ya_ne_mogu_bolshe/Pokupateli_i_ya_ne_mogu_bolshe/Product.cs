using System;
using System.Collections.Generic;
using System.Text;

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    [Serializable]
    public class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
