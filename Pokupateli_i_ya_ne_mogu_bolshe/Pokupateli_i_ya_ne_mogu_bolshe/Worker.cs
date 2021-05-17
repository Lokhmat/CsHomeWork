using System;
using System.Collections.Generic;
using System.Text;

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    /// <summary>
    /// Class for workers accounts.
    /// </summary>
    [Serializable]
    public class Worker
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public Worker(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
