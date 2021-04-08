using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListTypes
{
    /// <summary>
    /// Class that represents project.
    /// </summary>
    public class Project
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; private set; }
        public int MaxTasks { get; private set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"> Name of project.</param>
        /// <param name="tasks"> Tasks of project.</param>
        /// <param name="maxTasks"> Maximum amount of tasks.</param>
        public Project(string name, List<Task> tasks, int maxTasks)
        {
            Name = name;
            Tasks = tasks;
            MaxTasks = maxTasks;
        }
        /// <summary>
        /// Add task to Project.
        /// </summary>
        /// <param name="task"> Task to add.</param>
        public void AddTask(Task task)
        {
            if (Tasks.Count < MaxTasks)
                Tasks.Add(task);
            else
                throw new ArgumentException("Превышено максимальное количество задач");
        }


    }
}
