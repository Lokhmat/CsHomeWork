using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListTypes
{
    /// <summary>
    /// Class that represents user.
    /// </summary>
    public class User
    {
        public string Name { get; private set; }
        /// <summary>
        /// Usual constructor.
        /// </summary>
        /// <param name="name"> Name of user.</param>
        public User(string name)
        {
            Name = name;
        }
    }
}
