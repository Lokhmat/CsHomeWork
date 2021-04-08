using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using TodoListTypes;
using System.Windows.Forms;

namespace TodoList
{
    /// <summary>
    /// Form for one project.
    /// </summary>
    partial class ProjectForm : Form
    {
        // Link to project that is displayed.
        Project CurProject { get; set; }
        // Field to display tasks in dataGridView.
        Task curTask = null;
        // List of avaible users.
        List<User> users;
        /// <summary>
        /// Constructor. Fills checkboxes of users and initialises grid.
        /// </summary>
        /// <param name="project"> Link to project that is displayed.</param>
        /// <param name="users"> List of avaible users.</param>
        public ProjectForm(Project project, List<User> users)
        {
            Text = project.Name;
            this.users = users;
            CurProject = project;
            InitializeComponent();
            FillCheckBox();
            ValidateGrid();

        }
        /// <summary>
        /// Fills users checkbox.
        /// </summary>
        private void FillCheckBox()
        {
            usersCheckedListBox.Items.Clear();
            foreach (var user in users)
            {
                usersCheckedListBox.Items.Add(user.Name, false);
                changesCheckBox.Items.Add(user.Name, false);
            }
        }
        /// <summary>
        /// Handler of adding task button.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (typeComboBox.SelectedIndex)
                {
                    case 0:
                        if (usersCheckedListBox.CheckedItems.Count != 0)
                        {
                            MessageBox.Show("У темы не должно быть выбранных пользователей");
                            return;
                        }
                        CurProject.AddTask(new Epic(nameTextBox.Text));
                        break;
                    case 1:
                        MakeNewStory(CurProject);
                        break;
                    case 2 when usersCheckedListBox.CheckedItems.Count <= 1:
                        MakeNewTask(CurProject);
                        break;
                    case 3 when usersCheckedListBox.CheckedItems.Count <= 1:
                        MakeNewBug(CurProject);
                        break;
                    default:
                        MessageBox.Show("Либо вы не выбрали тип задачи. Либо задаче которую вы пытаетесь создать можно присвоить только одного исполнителя");
                        break;
                }
                ValidateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Adding story to current project or to Epic.
        /// </summary>
        /// <param name="place"> Epic or Project that Story is adding to.</param>
        private void MakeNewStory(object place)
        {
            Story newStory = new Story(nameTextBox.Text);
            foreach (var user in usersCheckedListBox.CheckedItems)
                newStory.users.Add(new User(user.ToString()));
            if (place is Project project)
            {
                if(project.Tasks.Select(x => x.Name).Contains(nameTextBox.Text))
                {
                    MessageBox.Show("У задач должны быть уникальные имена");
                    return;
                }
                CurProject.AddTask(newStory);
            }
            else
                ((Epic)place).AddTask(newStory);
        }
        /// <summary>
        /// Adding Bug to current project or to Epic.
        /// </summary>
        /// <param name="place"> Epic or Project that Bug is adding to.</param>
        private void MakeNewBug(object place)
        {
            Bug newBug = new Bug(nameTextBox.Text);
            if (usersCheckedListBox.CheckedItems.Count != 0)
                newBug.users = new User(usersCheckedListBox.CheckedItems[0].ToString());
            if (place is Project project)
            {
                if (project.Tasks.Select(x => x.Name).Contains(nameTextBox.Text))
                {
                    MessageBox.Show("У задач должны быть уникальные имена");
                    return;
                }
                CurProject.AddTask(newBug);
            }
            else
                ((Epic)place).AddTask(newBug);
        }
        /// <summary>
        /// Adding task to current project or to Epic.
        /// </summary>
        /// <param name="place"> Epic or Project that Task is adding to.</param>
        private void MakeNewTask(object place)
        {
            Task newTask = new Task(nameTextBox.Text);
            if (usersCheckedListBox.CheckedItems.Count != 0)
                newTask.users = new User(usersCheckedListBox.CheckedItems[0].ToString());
            if (place is Project project)
            {
                if (project.Tasks.Select(x => x.Name).Contains(nameTextBox.Text))
                {
                    MessageBox.Show("У задач должны быть уникальные имена");
                    return;
                }
                CurProject.AddTask(newTask);
            }
            else
                ((Epic)place).AddTask(newTask);
        }
        /// <summary>
        /// Redrawing dataGridView in order to handle changes in struct of project.
        /// </summary>
        private void ValidateGrid()
        {
            tasksView.Rows.Clear();
            foreach (var task in CurProject.Tasks)
            {
                if (task is Epic epic)
                {
                    tasksView.Rows.Add(task.Name, task.CreateTime, "Тема", "", task.status);
                    tasksView.Rows[tasksView.RowCount - 2].DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 12f);
                    foreach (Task subTask in epic.Tasks)
                    {
                        if (subTask is Story story)
                        {
                            tasksView.Rows.Add(subTask.Name, subTask.CreateTime, "История", string.Join(',', story.users.Select(x => x.Name)), subTask.status);
                            tasksView.Rows[tasksView.RowCount - 2].DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 6.5f);
                        }
                        else if (subTask is Bug bug)
                        {
                            tasksView.Rows.Add(subTask.Name, subTask.CreateTime, "Ошибка", bug.users != null ? bug.users.Name : "", subTask.status);
                            tasksView.Rows[tasksView.RowCount - 2].DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 6.5f);
                        }
                        else
                        {
                            tasksView.Rows.Add(subTask.Name, subTask.CreateTime, "Задача", subTask.users != null ? subTask.users.Name : "", subTask.status);
                            tasksView.Rows[tasksView.RowCount - 2].DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 6.5f);
                        }
                    }
                }
                else if (task is Story story)
                    tasksView.Rows.Add(task.Name, task.CreateTime, "История", string.Join(',', story.users.Select(x => x.Name)), task.status);
                else if (task is Bug bug)
                    tasksView.Rows.Add(task.Name, task.CreateTime, "Ошибка", bug.users != null ? bug.users.Name : "", task.status);
                else
                    tasksView.Rows.Add(task.Name, task.CreateTime, "Задача", task.users != null ? task.users.Name : "", task.status);

            }
        }
        /// <summary>
        /// Handler of adding subTask to selected Epic.
        /// </summary>
        private void addSubTask_Click(object sender, EventArgs e)
        {
            if (typeComboBox.SelectedIndex != 0 && tasksView.SelectedRows.Count == 1)
            {
                string curDate = tasksView.SelectedRows[0].Cells[1].Value.ToString();
                foreach (Task task in CurProject.Tasks)
                {
                    if (task is Epic epic && epic.CreateTime.ToString() == curDate)
                    {
                        try
                        {
                            switch (typeComboBox.SelectedIndex)
                            {
                                case 1:
                                    MakeNewStory(epic);
                                    break;
                                case 2 when usersCheckedListBox.CheckedItems.Count <= 1:
                                    MakeNewTask(epic);
                                    break;
                                default:
                                    MessageBox.Show("Либо вы выбрали не тот тип задачи. Либо задаче которую вы пытаетесь создать можно присвоить только одного исполнителя");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                ValidateGrid();
                return;
            }
            MessageBox.Show("Для того чтобы добавить подзадачу выберете одну строку таблицы, соответсвующую теме. И выберете тип добавляемой задачи - тема.");
        }
        /// <summary>
        /// Handler of deletion of selected tasks.
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tasksView.SelectedRows)
            {
                string curr = row.Cells[1].Value.ToString();
                foreach (var task in CurProject.Tasks)
                {
                    if (task.CreateTime.ToString() == curr)
                    {
                        CurProject.Tasks.Remove(task);
                        break;
                    }
                    else if (task is Epic epic)
                    {
                        foreach (var subTask in epic.Tasks)
                        {
                            if (subTask.CreateTime.ToString() == curr)
                            {
                                epic.Tasks.Remove(subTask);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            ValidateGrid();
        }
        /// <summary>
        /// Fills listCheckBox so user could change users assigned to task.
        /// </summary>
        /// <param name="task"> Task where users are reassigned.</param>
        private void FillChangesBox(Task task)
        {
            curTask = task;
            changesCheckBox.Items.Clear();
            if (task is Story story)
            {
                foreach (var user in users)
                {
                    if (story.users.Select(x => x.Name).Contains(user.Name))
                        changesCheckBox.Items.Add(user.Name, true);
                    else
                        changesCheckBox.Items.Add(user.Name, false);

                }
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.Name == task.users.Name)
                        changesCheckBox.Items.Add(user.Name, true);
                    else
                        changesCheckBox.Items.Add(user.Name, false);

                }
            }
        }
        /// <summary>
        /// Handler of changes in status of task.
        /// </summary>
        private void tasksView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                string curr = tasksView.Rows[e.RowIndex].Cells[1].Value.ToString();
                foreach (var task in CurProject.Tasks)
                {
                    if (task.CreateTime.ToString() == curr)
                    {
                        task.status = tasksView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    }
                    else if (task is Epic epic)
                    {
                        foreach (var subTask in epic.Tasks)
                        {
                            if (subTask.CreateTime.ToString() == curr)
                            {
                                subTask.status = tasksView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Re-assignes users in selected task.
        /// </summary>
        private void saveChanges_Click(object sender, EventArgs e)
        {
            if(curTask != null)
            {
                if (curTask is Story story)
                {
                    story.users = new List<User>();
                    foreach (var user in changesCheckBox.CheckedItems)
                    {
                        story.users.Add(new User(user.ToString()));
                    }
                }
                else if (changesCheckBox.CheckedItems.Count == 1)
                {
                    curTask.users = new User(changesCheckBox.CheckedItems[0].ToString());
                }
                else if (changesCheckBox.CheckedItems.Count == 0)
                    curTask.users = new User("");
                else
                    MessageBox.Show("Проверьте корректность выбора пользователей");
            }
            ValidateGrid();
            curTask = null;
        }
        /// <summary>
        /// Handler of selection task where users should be reassigned.
        /// </summary>
        private void tasksView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                string curr = tasksView.Rows[e.RowIndex].Cells[1].Value.ToString();
                foreach (var task in CurProject.Tasks)
                {
                    if (task.CreateTime.ToString() == curr)
                    {
                        FillChangesBox(task);
                        break;
                    }
                    else if (task is Epic epic)
                    {
                        foreach (var subTask in epic.Tasks)
                        {
                            if (subTask.CreateTime.ToString() == curr)
                            {
                                FillChangesBox(subTask);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}
