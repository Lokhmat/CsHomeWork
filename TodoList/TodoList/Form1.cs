using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TodoListTypes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    /// <summary>
    /// Main form of todolist.
    /// </summary>
    public partial class Form1 : Form
    {
        // List of avaible projects.
        List<Project> projects;
        // List of avaible users.
        internal List<User> Users { get; private set; }
        /// <summary>
        /// Constructor. Initializing grid and reading users and projects from files.
        /// </summary>
        public Form1()
        {


            RecoverUsers();
            RecoverProjects();
            InitializeComponent();
            ValidateGrid();
        }
        /// <summary>
        /// Recovers users from file into programm.
        /// </summary>
        void RecoverUsers()
        {
            try
            {
                Users = new List<User>();
                foreach (var user in File.ReadAllLines("users.txt"))
                {
                    Users.Add(new User(user));
                }
            }
            catch
            {
                Users = new List<User>();
            }
        }
        /// <summary>
        /// Recovers projects from files into programm.
        /// </summary>
        void RecoverProjects()
        {
            try
            {
                projects = new List<Project>();
                foreach (var file in (new DirectoryInfo("projects")).GetFiles())
                {
                    var newProj = new Project(file.Name[..^4], new List<TodoListTypes.Task>(), 30);
                    foreach (var line in File.ReadAllLines($"projects{Path.DirectorySeparatorChar}{file.Name}"))
                    {
                        switch (line.Split(' ')[0])
                        {
                            case "TodoListTypes.Story":
                                newProj.AddTask(JsonConvert.DeserializeObject<Story>(string.Join(" ", line.Split(' ')[1..])));
                                break;
                            case "TodoListTypes.Task":
                                newProj.AddTask(JsonConvert.DeserializeObject<TodoListTypes.Task>(string.Join(" ", line.Split(' ')[1..])));
                                break;
                            case "TodoListTypes.Bug":
                                newProj.AddTask(JsonConvert.DeserializeObject<Bug>(string.Join(" ", line.Split(' ')[1..])));
                                break;
                            case "TodoListTypes.Epic":
                                Epic epic = MakeEpic(line);
                                newProj.AddTask(epic);
                                break;
                        }
                    }
                    projects.Add(newProj);
                }
            }
            catch { }
        }
        /// <summary>
        /// Assembles epic task from file.
        /// </summary>
        /// <param name="line"> Text from file that displays Epic task.</param>
        /// <returns> Deserialized Epic task.</returns>
        private static Epic MakeEpic(string line)
        {
            Epic epic = JsonConvert.DeserializeObject<Epic>(string.Join(" ", line.Split(' ')[1..]));
            if (File.Exists($"{epic.Name}.txt"))
            {
                foreach (var subLine in File.ReadAllLines($"{epic.Name}.txt"))
                {
                    switch (subLine.Split(' ')[0])
                    {
                        case "TodoListTypes.Story":
                            epic.AddTask(JsonConvert.DeserializeObject<Story>(string.Join(" ", subLine.Split(' ')[1..])));
                            break;
                        case "TodoListTypes.Task":
                            epic.AddTask(JsonConvert.DeserializeObject<TodoListTypes.Task>(string.Join(" ", subLine.Split(' ')[1..])));
                            break;
                    }
                }
            }

            return epic;
        }
        /// <summary>
        /// Handler of users button. Allows to change users in projects.
        /// </summary>
        void ShowUsers(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm(this);
            usersForm.Show();
            Enabled = false;
        }
        /// <summary>
        /// Re-assembles avaible users after changes made in usersForm.
        /// </summary>
        /// <param name="users"> List of avaible users.</param>
        public void CatchUsers(CheckedListBox.ObjectCollection users)
        {
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(new User(user.ToString()));
            }
        }
        /// <summary>
        /// Serializes projects and users into multiple files in JSON format.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.WriteAllLines("users.txt", Users.Select(x => x.Name).ToArray());
                Clear("projects");
                foreach (var project in projects)
                {
                    File.WriteAllText($"projects{Path.DirectorySeparatorChar}{project.Name}.txt", "");
                    foreach (var task in project.Tasks)
                    {
                        if (task is Epic epic)
                        {
                            var tasks = (epic.Tasks.ToArray().Clone() as TodoListTypes.Task[]).ToList();
                            epic.Tasks.Clear();
                            File.AppendAllText($"projects{Path.DirectorySeparatorChar}{project.Name}.txt", $"{task.GetType()} {JsonConvert.SerializeObject(task)}{Environment.NewLine}");
                            if (tasks != null)
                            {
                                File.WriteAllText($"{epic.Name}.txt", "");
                                foreach (var subTask in tasks)
                                {
                                    File.AppendAllText($"{epic.Name}.txt", $"{subTask.GetType()} {JsonConvert.SerializeObject(subTask)}{Environment.NewLine}");
                                }
                                File.AppendAllText($"{epic.Name}.txt", $"{Environment.NewLine}");
                            }
                        }
                        else
                            File.AppendAllText($"projects{Path.DirectorySeparatorChar}{project.Name}.txt", $"{task.GetType()} {JsonConvert.SerializeObject(task)}{Environment.NewLine}");
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Clears specified directory.
        /// </summary>
        /// <param name="path"> Directory to clear.</param>
        private void Clear(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
        /// <summary>
        /// Handler of adding projects to todolist.
        /// </summary>
        private void addProjectButton_Click(object sender, EventArgs e)
        {
            projects.Add(new Project(projectTextBox.Text, new List<TodoListTypes.Task>(), 30));
            ValidateGrid();
        }
        /// <summary>
        /// Redraws grid in order to show current info.
        /// </summary>
        private void ValidateGrid()
        {
            projectsView.Rows.Clear();
            foreach (var project in projects)
            {
                projectsView.Rows.Add(project.Name, project.Tasks.Count, "Открыть");
            }
        }
        /// <summary>
        /// Delete selected projects.
        /// </summary>
        private void deleteSelected_Click(object sender, EventArgs e)
        {
            for (int i = projects.Count - 1; i >= 0; i--)
            {
                if (projectsView.Rows[i].Selected)
                    projects.RemoveAt(i);
            }
            ValidateGrid();

        }
        /// <summary>
        /// Rename selected project.
        /// </summary>
        private void renameButton_Click(object sender, EventArgs e)
        {
            if (projectsView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Должна быть выбрана только одна строка таблицы.(Только один проект)", "Ошибка");
                return;
            }
            projects[projectsView.SelectedRows[0].Index].Name = newNameTextBox.Text;
            ValidateGrid();
        }
        /// <summary>
        /// Opens clicked project.
        /// </summary>
        private void projectsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex < projectsView.RowCount - 1)
            {
                Enabled = false;
                ProjectForm curProj = new ProjectForm(projects[e.RowIndex], Users);
                curProj.FormClosing += new FormClosingEventHandler((sender, e) => { Enabled = true; ValidateGrid(); });
                curProj.Show();

            }
        }
        /// <summary>
        /// Shows FAQ.
        /// </summary>
        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Для выбора проекта/задачи необходимо выбрать всю строку таблицы{Environment.NewLine}" +
                $"Для добавления подзадачи нужно выбрать тему к которой вы хотите её добавить{Environment.NewLine}" +
                $"Для изменения пользователей гажмите на ячейку пользователя потом в верхнем окне поменяйте выделение и сохраните{Environment.NewLine}" +
                $"Реализован весь базовый функционал из задания{Environment.NewLine}" +
                $"Чтобы сгруппировать задачи отсортируйте их по статусу" +
                "" +
                "" +
                "");
        }


    }
}

