using System;
using Newtonsoft.Json;
using System.Text;

namespace TodoListTypes
{
    /// <summary>
    /// Class that displays bug.
    /// </summary>
    public class Bug : Task
    {
        /// <summary>
        /// Constructor for new task.
        /// </summary>
        /// <param name="name"> Name of task.</param>
        public Bug(string name) : base(name) { }

        /// <summary>
        /// Constructor for JSON deserialization.
        /// </summary>
        /// <param name="name"> Name of task.</param>
        /// <param name="createTime"> Time of creation.</param>
        /// <param name="status"> Status of task.</param>
        /// <param name="users"> Users who are assigned to task.</param>
        [JsonConstructor]
        public Bug(string name, DateTime createTime, string status, User users) : this(name)
        {
            CreateTime = createTime;
            this.status = status;
            this.users = users;
        }
    }
}
