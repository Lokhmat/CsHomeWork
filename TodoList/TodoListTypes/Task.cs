using System;
using Newtonsoft.Json;
using System.Text;

namespace TodoListTypes
{
    /// <summary>
    /// Class that represents Task.
    /// </summary>
    public class Task
    {
        public string Name { get; protected set; }
        public DateTime CreateTime { get; protected set; }
        public string status;
        public User users = new User("");
        /// <summary>
        /// Usual Constructor.
        /// </summary>
        /// <param name="name"> Name of Task.</param>
        public Task(string name)
        {
            CreateTime = DateTime.Now;
            status = "Открыто";
            Name = name;
        }
        /// <summary>
        /// Constructor for JSON deserialization.
        /// </summary>
        /// <param name="name"> Name of task.</param>
        /// <param name="createTime"> Time of creation.</param>
        /// <param name="status"> Status of task.</param>
        /// <param name="users"> Users who are assigned to task.</param>
        [JsonConstructor]
        public Task(string name, DateTime createTime, string status, User users) : this(name)
        {
            CreateTime = createTime;
            this.status = status;
            this.users = users;
        }
    }
}
