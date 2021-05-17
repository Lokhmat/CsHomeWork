using System;
using System.Collections.Generic;
using System.Text;

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    /// <summary>
    /// Class for Customers accounts.
    /// </summary>
    [Serializable]
    public class Customer
    {
        public string Login { get; private set; }
        public string Name { get; set; }
        public string Password { get; private set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        public Customer(string login, string name, string password, string phone, string adress)
        {
            Login = login;
            Name = name;
            Password = password;
            Phone = phone;
            Adress = adress;
        }
    }
}
