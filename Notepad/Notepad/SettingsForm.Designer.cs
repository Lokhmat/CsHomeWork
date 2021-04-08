
namespace Notepad
{
    partial class SettingsForm
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
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.frequencyComboBox = new System.Windows.Forms.ComboBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.themeLabel = new System.Windows.Forms.Label();
            this.themeComboBox = new System.Windows.Forms.ComboBox();
            this.logsLabel = new System.Windows.Forms.Label();
            this.logsBox = new System.Windows.Forms.ComboBox();
            this.logsHelpLabel = new System.Windows.Forms.Label();
            this.logsHelpLabel2 = new System.Windows.Forms.Label();
            this.csCompilerPathLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.compilerPathBox = new System.Windows.Forms.TextBox();
            this.submitCompilerPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(12, 9);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(261, 15);
            this.frequencyLabel.TabIndex = 0;
            this.frequencyLabel.Text = "Частота автоматического сохранения файлов";
            // 
            // frequencyComboBox
            // 
            this.frequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frequencyComboBox.FormattingEnabled = true;
            this.frequencyComboBox.Items.AddRange(new object[] {
            "15 сек.",
            "30 сек.",
            "1 мин.",
            "5 мин.",
            "10 мин.",
            "Никогда"});
            this.frequencyComboBox.Location = new System.Drawing.Point(296, 6);
            this.frequencyComboBox.Name = "frequencyComboBox";
            this.frequencyComboBox.Size = new System.Drawing.Size(121, 23);
            this.frequencyComboBox.TabIndex = 1;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(696, 403);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(92, 35);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "OK";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.themeLabel.Location = new System.Drawing.Point(12, 49);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(34, 15);
            this.themeLabel.TabIndex = 3;
            this.themeLabel.Text = "Тема";
            // 
            // themeComboBox
            // 
            this.themeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeComboBox.FormattingEnabled = true;
            this.themeComboBox.Items.AddRange(new object[] {
            "Светлая",
            "Тёмная"});
            this.themeComboBox.Location = new System.Drawing.Point(296, 41);
            this.themeComboBox.Name = "themeComboBox";
            this.themeComboBox.Size = new System.Drawing.Size(121, 23);
            this.themeComboBox.TabIndex = 4;
            // 
            // logsLabel
            // 
            this.logsLabel.AutoSize = true;
            this.logsLabel.Location = new System.Drawing.Point(12, 82);
            this.logsLabel.Name = "logsLabel";
            this.logsLabel.Size = new System.Drawing.Size(203, 15);
            this.logsLabel.TabIndex = 5;
            this.logsLabel.Text = "Интервал журналирования файлов";
            // 
            // logsBox
            // 
            this.logsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logsBox.FormattingEnabled = true;
            this.logsBox.Items.AddRange(new object[] {
            "15 сек.",
            "30 сек.",
            "1 мин.",
            "5 мин.",
            "10 мин.",
            "Никогда"});
            this.logsBox.Location = new System.Drawing.Point(296, 82);
            this.logsBox.Name = "logsBox";
            this.logsBox.Size = new System.Drawing.Size(121, 23);
            this.logsBox.TabIndex = 6;
            // 
            // logsHelpLabel
            // 
            this.logsHelpLabel.AutoSize = true;
            this.logsHelpLabel.Location = new System.Drawing.Point(12, 120);
            this.logsHelpLabel.Name = "logsHelpLabel";
            this.logsHelpLabel.Size = new System.Drawing.Size(366, 15);
            this.logsHelpLabel.TabIndex = 7;
            this.logsHelpLabel.Text = "Предыдущие версии файлов можете найти в скрытой папке logs";
            // 
            // logsHelpLabel2
            // 
            this.logsHelpLabel2.AutoSize = true;
            this.logsHelpLabel2.Location = new System.Drawing.Point(12, 135);
            this.logsHelpLabel2.Name = "logsHelpLabel2";
            this.logsHelpLabel2.Size = new System.Drawing.Size(416, 15);
            this.logsHelpLabel2.TabIndex = 8;
            this.logsHelpLabel2.Text = "Включение журналирования осуществляется в контекстном меню файла";
            // 
            // csCompilerPathLabel
            // 
            this.csCompilerPathLabel.AutoSize = true;
            this.csCompilerPathLabel.Location = new System.Drawing.Point(12, 175);
            this.csCompilerPathLabel.Name = "csCompilerPathLabel";
            this.csCompilerPathLabel.Size = new System.Drawing.Size(137, 15);
            this.csCompilerPathLabel.TabIndex = 9;
            this.csCompilerPathLabel.Text = "Путь к C# компилятору";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // compilerPathBox
            // 
            this.compilerPathBox.Location = new System.Drawing.Point(155, 175);
            this.compilerPathBox.Name = "compilerPathBox";
            this.compilerPathBox.ReadOnly = true;
            this.compilerPathBox.Size = new System.Drawing.Size(262, 23);
            this.compilerPathBox.TabIndex = 10;
            // 
            // submitCompilerPath
            // 
            this.submitCompilerPath.Location = new System.Drawing.Point(423, 175);
            this.submitCompilerPath.Name = "submitCompilerPath";
            this.submitCompilerPath.Size = new System.Drawing.Size(75, 23);
            this.submitCompilerPath.TabIndex = 11;
            this.submitCompilerPath.Text = "Поменять";
            this.submitCompilerPath.UseVisualStyleBackColor = true;
            this.submitCompilerPath.Click += new System.EventHandler(this.submitCompilerPath_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.submitCompilerPath);
            this.Controls.Add(this.compilerPathBox);
            this.Controls.Add(this.csCompilerPathLabel);
            this.Controls.Add(this.logsHelpLabel2);
            this.Controls.Add(this.logsHelpLabel);
            this.Controls.Add(this.logsBox);
            this.Controls.Add(this.logsLabel);
            this.Controls.Add(this.themeComboBox);
            this.Controls.Add(this.themeLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.frequencyComboBox);
            this.Controls.Add(this.frequencyLabel);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.ComboBox frequencyComboBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.ComboBox themeComboBox;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.ComboBox logsBox;
        private System.Windows.Forms.Label logsHelpLabel;
        private System.Windows.Forms.Label logsHelpLabel2;
        private System.Windows.Forms.Label csCompilerPathLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox compilerPathBox;
        private System.Windows.Forms.Button submitCompilerPath;
    }
}