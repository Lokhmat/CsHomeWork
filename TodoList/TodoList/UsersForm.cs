using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TodoList
{
    public partial class UsersForm : Form
    {
        public List<string> users = new List<string>();
        Form1 parent;
        public UsersForm(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void UsersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.CatchUsers(usersListBox.Items);
            parent.Enabled = true;
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            if (!usersListBox.Items.Contains(addUserTextBox.Text))
                usersListBox.Items.Add(addUserTextBox.Text, false);
            else
                MessageBox.Show("Имена пользователей должны быть различны");
        }

        private void deleteSelectedUsers_Click(object sender, EventArgs e)
        {
            for (int i = usersListBox.CheckedItems.Count; i >0; i--)
            {
                usersListBox.Items.Remove(usersListBox.CheckedItems[i-1]);
            }
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            parent.Users.ForEach(e => usersListBox.Items.Add(e.Name));
        }
    }
}
