
namespace TodoList
{
    partial class UsersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.usersListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addUserTextBox = new System.Windows.Forms.TextBox();
            this.addUserButton = new System.Windows.Forms.Button();
            this.deleteSelectedUsers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущие пользователи:";
            // 
            // usersListBox
            // 
            this.usersListBox.CheckOnClick = true;
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.Location = new System.Drawing.Point(13, 32);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(232, 274);
            this.usersListBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя:";
            // 
            // addUserTextBox
            // 
            this.addUserTextBox.Location = new System.Drawing.Point(292, 32);
            this.addUserTextBox.Name = "addUserTextBox";
            this.addUserTextBox.Size = new System.Drawing.Size(124, 23);
            this.addUserTextBox.TabIndex = 3;
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(423, 32);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(75, 23);
            this.addUserButton.TabIndex = 4;
            this.addUserButton.Text = "Добавить пользователя";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // deleteSelectedUsers
            // 
            this.deleteSelectedUsers.Location = new System.Drawing.Point(292, 282);
            this.deleteSelectedUsers.Name = "deleteSelectedUsers";
            this.deleteSelectedUsers.Size = new System.Drawing.Size(206, 23);
            this.deleteSelectedUsers.TabIndex = 5;
            this.deleteSelectedUsers.Text = "Удалить выбранных";
            this.deleteSelectedUsers.UseVisualStyleBackColor = true;
            this.deleteSelectedUsers.Click += new System.EventHandler(this.deleteSelectedUsers_Click);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteSelectedUsers);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.addUserTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usersListBox);
            this.Controls.Add(this.label1);
            this.Name = "UsersForm";
            this.Text = "Пользователи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UsersForm_FormClosing);
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox usersListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addUserTextBox;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Button deleteSelectedUsers;
    }
}