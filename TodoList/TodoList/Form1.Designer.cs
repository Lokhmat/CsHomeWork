
namespace TodoList
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.userButton = new System.Windows.Forms.ToolStripButton();
            this.helpButton = new System.Windows.Forms.ToolStripButton();
            this.projectsView = new System.Windows.Forms.DataGridView();
            this.projectLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.projectTextBox = new System.Windows.Forms.TextBox();
            this.addProjectButton = new System.Windows.Forms.Button();
            this.deleteSelected = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.renameButton = new System.Windows.Forms.Button();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumOfTasksColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userButton,
            this.helpButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // userButton
            // 
            this.userButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.userButton.Image = ((System.Drawing.Image)(resources.GetObject("userButton.Image")));
            this.userButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(89, 22);
            this.userButton.Text = "Пользователи";
            this.userButton.Click += new System.EventHandler(this.ShowUsers);
            // 
            // helpButton
            // 
            this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(86, 22);
            this.helpButton.Text = "О программе";
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // projectsView
            // 
            this.projectsView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.projectsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectsView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.projectsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.NumOfTasksColumn,
            this.buttonColumn});
            this.projectsView.Location = new System.Drawing.Point(0, 56);
            this.projectsView.Name = "projectsView";
            this.projectsView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.projectsView.RowTemplate.Height = 25;
            this.projectsView.Size = new System.Drawing.Size(364, 382);
            this.projectsView.TabIndex = 1;
            this.projectsView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectsView_CellClick);
            // 
            // projectLabel
            // 
            this.projectLabel.AutoSize = true;
            this.projectLabel.Location = new System.Drawing.Point(13, 35);
            this.projectLabel.Name = "projectLabel";
            this.projectLabel.Size = new System.Drawing.Size(91, 15);
            this.projectLabel.TabIndex = 2;
            this.projectLabel.Text = "Ваши проекты:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            // 
            // projectTextBox
            // 
            this.projectTextBox.Location = new System.Drawing.Point(473, 56);
            this.projectTextBox.Name = "projectTextBox";
            this.projectTextBox.Size = new System.Drawing.Size(100, 23);
            this.projectTextBox.TabIndex = 4;
            // 
            // addProjectButton
            // 
            this.addProjectButton.Location = new System.Drawing.Point(580, 52);
            this.addProjectButton.Name = "addProjectButton";
            this.addProjectButton.Size = new System.Drawing.Size(173, 23);
            this.addProjectButton.TabIndex = 5;
            this.addProjectButton.Text = "Добавить";
            this.addProjectButton.UseVisualStyleBackColor = true;
            this.addProjectButton.Click += new System.EventHandler(this.addProjectButton_Click);
            // 
            // deleteSelected
            // 
            this.deleteSelected.Location = new System.Drawing.Point(619, 415);
            this.deleteSelected.Name = "deleteSelected";
            this.deleteSelected.Size = new System.Drawing.Size(169, 23);
            this.deleteSelected.TabIndex = 6;
            this.deleteSelected.Text = "Удалить выбранные";
            this.deleteSelected.UseVisualStyleBackColor = true;
            this.deleteSelected.Click += new System.EventHandler(this.deleteSelected_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Новое название";
            // 
            // newNameTextBox
            // 
            this.newNameTextBox.Location = new System.Drawing.Point(473, 104);
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.newNameTextBox.TabIndex = 8;
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(580, 104);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(173, 23);
            this.renameButton.TabIndex = 9;
            this.renameButton.Text = "Переименовать выбранный";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Название";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NumOfTasksColumn
            // 
            this.NumOfTasksColumn.HeaderText = "Кол-во задач";
            this.NumOfTasksColumn.Name = "NumOfTasksColumn";
            this.NumOfTasksColumn.ReadOnly = true;
            this.NumOfTasksColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonColumn
            // 
            this.buttonColumn.HeaderText = "Открыть";
            this.buttonColumn.Name = "buttonColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.newNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteSelected);
            this.Controls.Add(this.addProjectButton);
            this.Controls.Add(this.projectTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectLabel);
            this.Controls.Add(this.projectsView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Project manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView projectsView;
        private System.Windows.Forms.Label projectLabel;
        private System.Windows.Forms.ToolStripButton userButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projectTextBox;
        private System.Windows.Forms.Button addProjectButton;
        private System.Windows.Forms.Button deleteSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newNameTextBox;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.ToolStripButton helpButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumOfTasksColumn;
        private System.Windows.Forms.DataGridViewButtonColumn buttonColumn;
    }
}

