using System;
using System.Collections.Generic;
using System.Text;

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    /// <summary>
    /// Class for multiple orders(how they packed in cart).
    /// </summary>
    [Serializable]
    public class Piece : Product
    {
        public int Amount { get; private set; }

        public Piece(string name, double price, int amount) : base(name, price)
        {
            Amount = amount;
        }
    }
}
