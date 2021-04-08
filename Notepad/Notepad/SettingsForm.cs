using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    /// <summary>
    /// Form for settings window;
    /// </summary>
    public partial class SettingsForm : Form
    {
        Form1 form;
        public SettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Connect with notepad form so it could change settings;
        /// </summary>
        /// <param name="form"> Notepad form that we want to connect with settings form; </param>
        public void ConnectForm(Form1 form)
        {
            this.form = form;
            ReviewSettings();
            form.ValidateSettings();
        }
        /// <summary>
        /// Setuping settings to their current condition;
        /// </summary>
        public void ReviewSettings()
        {
            try
            {
                themeComboBox.SelectedIndex = (int)form.theme;
                frequencyComboBox.SelectedIndex = (int)form.frequency;
                compilerPathBox.Text = form.CompilerPath;
                logsBox.SelectedIndex = (int)form.logsFrequency;
            }
            catch
            {
                themeComboBox.SelectedIndex = (int)Theme.Light;
                frequencyComboBox.SelectedIndex = (int)Frequency.Never;
                compilerPathBox.Text = "";
                logsBox.SelectedIndex = (int)Frequency.Never;
                MessageBox.Show("Похоже был сломан файл с настройками. Поменяйте их и перезапустите программу");
            }
        }
        // Activate notepad form when settings are closed;
        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Enabled = true;
        }
        /// <summary>
        /// Applying and writing logs to file;
        /// </summary>
        /// <param name="sender"> SubmitButton;</param>
        /// <param name="e"> EventArgs of the delegate;</param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            form.theme = (Theme)themeComboBox.SelectedIndex;
            form.frequency = (Frequency)frequencyComboBox.SelectedIndex;
            form.CompilerPath = compilerPathBox.Text;
            form.logsFrequency = (Frequency)logsBox.SelectedIndex;
            form.Enabled = true;
            form.WriteLogs();
            form.ValidateSettings();
            Close();
        }
        /// <summary>
        /// Applying changes to C# compiler path;
        /// </summary>
        /// <param name="sender"> SubmitCompilerPath Button;</param>
        /// <param name="e"> EventArgs of the delegate;</param>
        private void submitCompilerPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                compilerPathBox.Text = openFileDialog1.FileName;
            }
        }
    }
}
