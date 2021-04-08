
namespace TodoList
{
    partial class ProjectForm
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
            this.tasksView = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.usersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.addSubTask = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changesCheckBox = new System.Windows.Forms.CheckedListBox();
            this.saveChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasksView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ваш проект:";
            // 
            // tasksView
            // 
            this.tasksView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tasksView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tasksView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tasksView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tasksView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.DateColumn,
            this.TaskType,
            this.UsersColumn,
            this.StatusColumn});
            this.tasksView.Location = new System.Drawing.Point(13, 32);
            this.tasksView.Name = "tasksView";
            this.tasksView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tasksView.RowTemplate.Height = 25;
            this.tasksView.Size = new System.Drawing.Size(542, 406);
            this.tasksView.TabIndex = 1;
            this.tasksView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tasksView_CellClick);
            this.tasksView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tasksView_CellValueChanged);
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Название";
            this.TaskName.Name = "TaskName";
            this.TaskName.ReadOnly = true;
            // 
            // DateColumn
            // 
            this.DateColumn.HeaderText = "Дата создания";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            this.DateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TaskType
            // 
            this.TaskType.HeaderText = "Тип задачи";
            this.TaskType.Name = "TaskType";
            this.TaskType.ReadOnly = true;
            this.TaskType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TaskType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UsersColumn
            // 
            this.UsersColumn.HeaderText = "Исполнители";
            this.UsersColumn.Name = "UsersColumn";
            this.UsersColumn.ReadOnly = true;
            this.UsersColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UsersColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Статус";
            this.StatusColumn.Items.AddRange(new object[] {
            "Открыто",
            "В работе",
            "Завершено"});
            this.StatusColumn.Name = "StatusColumn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(566, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Название";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(670, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Тип";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(761, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Пользователи";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(566, 215);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(98, 23);
            this.nameTextBox.TabIndex = 9;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Тема",
            "История",
            "Задача",
            "Ошибка"});
            this.typeComboBox.Location = new System.Drawing.Point(670, 216);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(79, 23);
            this.typeComboBox.TabIndex = 13;
            // 
            // usersCheckedListBox
            // 
            this.usersCheckedListBox.FormattingEnabled = true;
            this.usersCheckedListBox.Location = new System.Drawing.Point(761, 217);
            this.usersCheckedListBox.Name = "usersCheckedListBox";
            this.usersCheckedListBox.Size = new System.Drawing.Size(120, 112);
            this.usersCheckedListBox.TabIndex = 14;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(887, 215);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(91, 23);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // addSubTask
            // 
            this.addSubTask.Location = new System.Drawing.Point(887, 244);
            this.addSubTask.Name = "addSubTask";
            this.addSubTask.Size = new System.Drawing.Size(91, 38);
            this.addSubTask.TabIndex = 16;
            this.addSubTask.Text = "Добавить подзадачу";
            this.addSubTask.UseVisualStyleBackColor = true;
            this.addSubTask.Click += new System.EventHandler(this.addSubTask_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(561, 32);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(103, 41);
            this.deleteButton.TabIndex = 18;
            this.deleteButton.Text = "Удалить выбранные";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // changesCheckBox
            // 
            this.changesCheckBox.FormattingEnabled = true;
            this.changesCheckBox.Location = new System.Drawing.Point(761, 32);
            this.changesCheckBox.Name = "changesCheckBox";
            this.changesCheckBox.Size = new System.Drawing.Size(120, 112);
            this.changesCheckBox.TabIndex = 19;
            // 
            // saveChanges
            // 
            this.saveChanges.Location = new System.Drawing.Point(887, 32);
            this.saveChanges.Name = "saveChanges";
            this.saveChanges.Size = new System.Drawing.Size(163, 66);
            this.saveChanges.TabIndex = 20;
            this.saveChanges.Text = "Сохранить изменения в пользователях";
            this.saveChanges.UseVisualStyleBackColor = true;
            this.saveChanges.Click += new System.EventHandler(this.saveChanges_Click);
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1135, 450);
            this.Controls.Add(this.saveChanges);
            this.Controls.Add(this.changesCheckBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addSubTask);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.usersCheckedListBox);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tasksView);
            this.Controls.Add(this.label1);
            this.Name = "ProjectForm";
            this.Text = "ProjectForm";
            ((System.ComponentModel.ISupportInitialize)(this.tasksView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tasksView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.CheckedListBox usersCheckedListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button addSubTask;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsersColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatusColumn;
        private System.Windows.Forms.CheckedListBox changesCheckBox;
        private System.Windows.Forms.Button saveChanges;
    }
}