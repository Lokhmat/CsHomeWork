using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger
{
    /// <summary>
    /// Class for user implementation.
    /// </summary>
    public class User
    {
        static int count = 0;
        public string UserName { get; private set; }
        public string Email { get; private set; }

        public int Id { get; private set; }
        public User(string userName, string email)
        {
            Id = count++;
            UserName = userName;
            Email = email;
        }
    }
}
