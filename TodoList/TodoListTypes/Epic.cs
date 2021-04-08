using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TodoListTypes
{
    public class Epic : Task
    {
        // List of tasks that are assigned to this Epic.
        public List<Task> Tasks { get; private set; } = new List<Task>();

        public Epic(string name) : base(name) { }

        /// <summary>
        /// Constructor for JSON deserialization.
        /// </summary>
        /// <param name="name"> Name of task.</param>
        /// <param name="createTime"> Time of creation.</param>
        /// <param name="status"> Status of task.</param>
        /// <param name="users"> Users who are assigned to task.</param>
        /// <param name="tasks"> Tasks that are assigned to this Epic.</param>
        [JsonConstructor]
        public Epic(string name, DateTime createTime, string status, User users, List<Task> tasks) : this(name)
        {
            CreateTime = createTime;
            this.status = status;
            this.users = users;
            Tasks = tasks;
        }
        /// <summary>
        /// Assignes task to this epic.
        /// </summary>
        /// <param name="task"> Task to assign.</param>
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }
    }
}
