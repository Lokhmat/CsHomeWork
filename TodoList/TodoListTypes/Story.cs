using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TodoListTypes
{
    /// <summary>
    /// Class that represents Story.
    /// </summary>
    public class Story : Task
    {
        public new List<User> users = new List<User>();
        /// <summary>
        /// Usual constructor.
        /// </summary>
        /// <param name="name"> Name of Story.</param>
        public Story(string name) : base(name) { }

        /// <summary>
        /// Constructor for JSON deserialization.
        /// </summary>
        /// <param name="name"> Name of task.</param>
        /// <param name="createTime"> Time of creation.</param>
        /// <param name="status"> Status of task.</param>
        /// <param name="users"> Users who are assigned to task.</param>
        [JsonConstructor]
        public Story(string name, DateTime createTime, string status, List<User> users) : this(name)
        {
            CreateTime = createTime;
            this.status = status;
            this.users = users;
        }
    }
}
