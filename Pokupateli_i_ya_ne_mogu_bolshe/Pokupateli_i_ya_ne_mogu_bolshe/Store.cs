using System;
using System.Collections.Generic;
using System.Text;

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    /// <summary>
    /// Class for full store so we could serialize easier.
    /// </summary>
    [Serializable]
    public class Store
    {
        public List<Product> Products { get; private set; } = new List<Product>();
        public List<Customer> Customers { get; private set; } = new List<Customer>();
        public List<Order> Orders { get; private set; } = new List<Order>();
        public List<Worker> Workers { get; private set; } = new List<Worker>();
        public int LastOrderId { get; set; }


        public Store(List<Customer> customers, List<Order> orders, List<Worker> workers, int id)
        {
            this.Customers = customers;
            this.Orders = orders;
            this.Workers = workers;
            Products = new List<Product>();
            LastOrderId = id;
        }
    }
}
