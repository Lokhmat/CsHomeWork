using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    /// <summary>
    /// Class with all order data.
    /// </summary>
    [Serializable]
    public class Order
    {
        public List<Piece> OrderedProducts { get; private set; }
        public int Number { get; private set; }
        public DateTime DateTime { get; private set; }

        public double Price { get { return OrderedProducts.Select(x => x.Price).Sum(); } }
        public Customer Cust { get; private set; }
        public Status? Status { get; set; } = null;

        public Order(List<Piece> orderedProducts, int number, DateTime dateTime, Customer cust)
        {
            OrderedProducts = orderedProducts;
            Number = number;
            DateTime = dateTime;
            Cust = cust;
        }
    }
    [Serializable]
    [Flags]
    public enum Status
    {
        Processed = 1,
        Payed = 2,
        Shipped = 4,
        Done = 8
    }
}
