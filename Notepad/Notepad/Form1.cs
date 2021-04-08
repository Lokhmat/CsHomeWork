using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{

    /// <summary>
    /// Main notepad form;
    /// </summary>
    public partial class Form1 : Form
    {
        // Link to the parent form;
        public ParentForm parent;
        // Counter for the new files;
        int lastDocId = 1;
        // Link to the settings form;
        SettingsForm settingsForm;
        // Flag to see when changes applied to RTB in tab is made by code;
        bool secureChange = false;
        internal Theme theme;
        internal Frequency frequency;
        internal Frequency logsFrequency;
        // Current tabControl;
        public TabControl TabControl1 { get { return tabControl1; } }
        internal string CompilerPath { get; set; }
        /// <summary>
        /// Constructor of notepad form. Reading settings, applying them;
        /// </summary>
        /// <param name="parent"> Link to hidden parent form;</param>
        public Form1(ParentForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            GetSettingsFromLogs();
            ValidateSettings();
            OpenFromLogs();
        }
        /// <summary>
        /// Universal methode to open new blank tab;
        /// </summary>
        /// <param name="name"> Name of the tab;</param>
        /// <param name="filename"> Absolute path to file;</param>
        /// <returns></returns>
        private MyTabPage MakeNewTab(string name, string filename)
        {
            MyTabPage newTab = new MyTabPage(name, filename, theme);
            RichTextBox newRichTextBox = new RichTextBox();
            newRichTextBox.ContextMenuStrip = richTextBoxContextMenu;
            newRichTextBox.Dock = DockStyle.Fill;
            newRichTextBox.BackColor = (theme == Theme.Light ? SystemColors.Control : ColorTranslator.FromHtml("#424242"));
            newRichTextBox.ForeColor = (theme == Theme.Light ? Color.Black : Color.White);
            newTab.Controls.Add(newRichTextBox);
            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectTab(newTab);
            newRichTextBox.TextChanged += new EventHandler(TextBoxListen);
            return newTab;
        }
        /// <summary>
        /// Open files which were open in previous usage;
        /// </summary>
        private void OpenFromLogs()
        {
            if (parent.numOfForms == 1)
            {

                try
                {
                    string[] settings = File.ReadAllLines("settings.txt")[2..];
                    foreach (var filename in settings)
                    {
                        MyTabPage newTab = MakeNewTab(filename.Split(Path.DirectorySeparatorChar)[^1], filename);
                        newTab.Unsaved = false;
                        RichTextBox newRichTextBox = (RichTextBox)newTab.Controls[0];
                        newRichTextBox.Text = File.ReadAllText(filename);
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// Restore settings from file;
        /// </summary>
        public void GetSettingsFromLogs()
        {
            try
            {
                string[] settings = File.ReadAllLines("settings.txt");
                theme = (Theme)int.Parse(settings[0].Split(' ')[0]);
                frequency = (Frequency)int.Parse(settings[0].Split(' ')[1]);
                logsFrequency = (Frequency)int.Parse(settings[0].Split(' ')[2]);
                CompilerPath = settings[1];
            }
            catch
            {
                theme = Theme.Light;
                frequency = Frequency.Never;
                CompilerPath = "";
                logsFrequency = Frequency.Never;
            }
        }


        /// <summary>
        /// Opens file by user's choice;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                MyTabPage newTab = InitializeNewTab(out string filename, out RichTextBox newRichTextBox);
                switch (openFileDialog1.FilterIndex)
                {
                    case 1:
                        newRichTextBox.Text = File.ReadAllText(filename);
                        break;
                    case 2:
                        newRichTextBox.Rtf = File.ReadAllText(filename);
                        break;
                    case 3:
                        newRichTextBox.Text = File.ReadAllText(filename);
                        break;
                }
                newTab.Unsaved = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка{Environment.NewLine}{ex.Message}");
            }

        }
        /// <summary>
        /// Initializes new tab;
        /// </summary>
        /// <param name="filename"> Absolute path to file;</param>
        /// <param name="newRichTextBox"> New RTB that is created in tab;</param>
        /// <returns> Created tab;</returns>
        private MyTabPage InitializeNewTab(out string filename, out RichTextBox newRichTextBox)
        {
            openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
            MyTabPage newTab = MakeNewTab(openFileDialog1.SafeFileName, filename);
            newRichTextBox = (RichTextBox)newTab.Controls[0];
            return newTab;
        }
        /// <summary>
        /// Initializes new blank tab;
        /// </summary>
        internal void OpenNewTab(object sender, EventArgs e)
        {
            string fileName = $"New document{lastDocId++}.txt";
            MyTabPage newTab = MakeNewTab(fileName, fileName);
        }
        /// <summary>
        /// Saves file as specified by user;
        /// </summary>
        private void saveAsFileButton_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab != null)
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    try
                    {
                        ((MyTabPage)tabControl1.SelectedTab).contentId = saveFileDialog1.FilterIndex;
                        ((MyTabPage)tabControl1.SelectedTab).SaveTab(saveFileDialog1.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка{Environment.NewLine}{ex.Message}");
                    }
                }
            }
        }
        /// <summary>
        /// Saves current file;
        /// </summary>
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
                ((MyTabPage)tabControl1.SelectedTab).SaveTab(((MyTabPage)tabControl1.SelectedTab).TabPath);
        }
        /// <summary>
        /// Before closing form writes settings and saves file;
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteLogs();
            // Checking if we have to close parent form also;
            parent.numOfForms--;
            if (tabControl1.TabPages.Count == 0)
                parent.ValidateForm();
            foreach (MyTabPage tab in tabControl1.TabPages)
            {
                if (tab.Unsaved == true)
                {
                    var result = MessageBox.Show("У вас есть несохранённые вкладки. Сохранить всё перед выходом?", "Выход", MessageBoxButtons.YesNoCancel);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            SaveAll();
                            parent.ValidateForm();
                            return;
                        case DialogResult.No:
                            parent.ValidateForm();
                            return;
                        case DialogResult.Cancel:
                            parent.numOfForms++;
                            e.Cancel = true;
                            return;
                    }
                }
                parent.ValidateForm();
            }

        }
        /// <summary>
        /// Saves all files that are currently open;
        /// </summary>
        private void SaveAll()
        {
            foreach (MyTabPage tab in tabControl1.TabPages)
            {
                tab.SaveTab(tab.TabPath);
            }
        }
        /// <summary>
        /// Changing font in selected tab by button;
        /// </summary>
        private void ChangeFont(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (tabControl1.SelectedTab != null)
                {
                    RichTextBox currentBox = ((RichTextBox)tabControl1.SelectedTab.Controls[0]);
                    currentBox.Font = fontDialog?.Font;
                }
            }
        }
        /// <summary>
        /// Opens settings form and connects with it;
        /// </summary>
        private void toolSettingsButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            settingsForm = new SettingsForm();
            settingsForm.ConnectForm(this);
            settingsForm.Show();


        }
        /// <summary>
        /// Applying settings to notepad form. Changing theme, start/stop saving timer;
        /// </summary>
        public void ValidateSettings()
        {
            timer1.Enabled = true;
            logsTimer.Enabled = true;
            toolStrip1.BackColor = Color.White;
            BackColor = (theme == Theme.Light ? SystemColors.Control : ColorTranslator.FromHtml("#424242"));

            foreach (MyTabPage tab in tabControl1.TabPages)
            {
                ((RichTextBox)tab.Controls[0]).BackColor = (theme == Theme.Light ? SystemColors.Control : ColorTranslator.FromHtml("#424242"));
                ((RichTextBox)tab.Controls[0]).ForeColor = (theme == Theme.Light ? Color.Black : Color.White);
            }
            tabControl1.BackColor = (theme == Theme.Light ? SystemColors.Control : ColorTranslator.FromHtml("#424242"));
            SetupLogsFrequency();
            switch (frequency)
            {
                case Frequency.QarterMinute:
                    timer1.Interval = 15000;
                    break;
                case Frequency.HalfMinute:
                    timer1.Interval = 30000;
                    break;
                case Frequency.Minute:
                    timer1.Interval = 60000;
                    break;
                case Frequency.FiveMinute:
                    timer1.Interval = 300000;
                    break;
                case Frequency.TenMinute:
                    timer1.Interval = 600000;
                    break;
                default:
                    timer1.Enabled = false;
                    break;
            }
        }
        /// <summary>
        /// Apply settings for logging files;
        /// </summary>
        private void SetupLogsFrequency()
        {
            logsTimer.Enabled = true;
            switch (logsFrequency)
            {
                case Frequency.QarterMinute:
                    logsTimer.Interval = 15000;
                    break;
                case Frequency.HalfMinute:
                    logsTimer.Interval = 30000;
                    break;
                case Frequency.Minute:
                    logsTimer.Interval = 60000;
                    break;
                case Frequency.FiveMinute:
                    logsTimer.Interval = 300000;
                    break;
                case Frequency.TenMinute:
                    logsTimer.Interval = 600000;
                    break;
                default:
                    logsTimer.Enabled = false;
                    break;
            }
        }
        /// <summary>
        /// Save all files according to settings;
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            SaveAll();
        }
        /// <summary>
        /// Handler of opening new window with notepad;
        /// </summary>
        private void newWindowButton_Click(object sender, EventArgs e)
        {
            parent.OpenNewForm();
        }
        /// <summary>
        /// Handler of hotkeys in the app;
        /// </summary>
        private void ProcessHotkeys(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.N)
            {
                parent.OpenNewForm();
            }
            if (e.Control && !e.Shift && e.KeyCode == Keys.N)
            {
                OpenNewTab(sender, e);
                return;
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                SaveAll();
                return;
            }
            if (e.Control && !e.Shift && e.KeyCode == Keys.S)
            {
                if (tabControl1.SelectedTab != null)
                    ((MyTabPage)tabControl1.SelectedTab).SaveTab(((MyTabPage)tabControl1.SelectedTab).TabPath);
                return;
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.E)
            {
                Close();
                return;
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.Z)
            {
                if (tabControl1.SelectedTab != null)
                    Redo((MyTabPage)tabControl1.SelectedTab);
                return;
            }
            if (e.Control && !e.Shift && e.KeyCode == Keys.Z)
            {
                if (tabControl1.SelectedTab != null)
                    Undo((MyTabPage)tabControl1.SelectedTab);
                return;
            }

        }
        /// <summary>
        /// Writes logs into settings file; Specifies theme,frequency of logs and savings and all opened files;
        /// </summary>
        public void WriteLogs()
        {
            StringBuilder settings = new StringBuilder($"{(int)theme} {(int)frequency} {(int)logsFrequency}{Environment.NewLine}{CompilerPath}{Environment.NewLine}");
            foreach (MyTabPage tab in tabControl1.TabPages)
            {
                settings.Append($"{tab.TabPath}{Environment.NewLine}");
            }
            try
            {
                File.WriteAllText("settings.txt", settings.ToString());
            }
            catch { }
        }
        /// <summary>
        /// Handler of closing tab;
        /// </summary>
        private void closeTabButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count != 0)
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }
        /// <summary>
        /// Handler of selection and selection RBM;
        /// </summary>
        private void ProcessSelection(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (tabControl1.SelectedTab == null)
                return;
            RichTextBox currentRtb = (RichTextBox)(tabControl1.SelectedTab.Controls[0]);
            switch (item.Name.ToString())
            {
                case "selectAllButton":
                    currentRtb.SelectAll();
                    break;
                case "cutSelectedButton":
                    currentRtb.Cut();
                    break;
                case "copySelectedButton":
                    currentRtb.Copy();
                    break;
                case "pasteSelectedButton":
                    currentRtb.Paste();
                    break;
                case "formatSelectedButton":
                    FontDialog fontDialog = new FontDialog();
                    if (fontDialog.ShowDialog() == DialogResult.OK)
                        currentRtb.SelectionFont = fontDialog.Font;
                    break;
            }
        }
        /// <summary>
        /// Handler of full format button in toolstrip;
        /// </summary>
        private void ProcessFormatButtons(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (tabControl1.SelectedTab == null)
                return;
            RichTextBox currentRtb = (RichTextBox)(tabControl1.SelectedTab.Controls[0]);
            switch (item.Name.ToString())
            {
                case "selectAll":
                    currentRtb.SelectAll();
                    break;
                case "cutButton":
                    currentRtb.Cut();
                    break;
                case "copyButton":
                    currentRtb.Copy();
                    break;
                case "removeButton":
                    currentRtb.SelectedText = "";
                    break;
                default:
                    Undo((MyTabPage)tabControl1.SelectedTab);
                    break;
            }
        }
        /// <summary>
        /// Handler of changes in current RTB so we could undo redo and track if it is unsaved;
        /// </summary>
        private void TextBoxListen(object sender, EventArgs e)
        {
            RichTextBox textBox = (RichTextBox)sender;

            MyTabPage newTab = (MyTabPage)textBox.Parent;
            newTab.Unsaved = true;
            if (!secureChange)
            {
                newTab.UndoContainer.Push(newTab.contentId == 2 ? textBox.Rtf : textBox.Text);
            }

        }
        /// <summary>
        /// Implementation of ctrl+Z;
        /// </summary>
        /// <param name="tab"> Currently opened tab;</param>
        private void Undo(MyTabPage tab)
        {
            if (tab == null || tab.UndoContainer.Count == 0)
                return;
            var lastChange = tab.UndoContainer.Pop();
            secureChange = true;
            switch (tab.contentId)
            {
                case 2:
                    ((RichTextBox)tab.Controls[0]).Rtf = lastChange;
                    tab.RedoContainer.Push(lastChange);
                    break;
                default:

                    ((RichTextBox)tab.Controls[0]).Text = lastChange;
                    tab.RedoContainer.Push(lastChange);
                    break;
            }
            secureChange = false;
        }
        /// <summary>
        /// Inplementation of ctrl+shift+z;
        /// </summary>
        /// <param name="tab"> Currently opened tab;</param>
        private void Redo(MyTabPage tab)
        {
            if (tab == null || tab.RedoContainer.Count == 0)
                return;
            var lastChange = tab.RedoContainer.Pop();
            secureChange = true;
            switch (tab.contentId)
            {
                case 2:
                    ((RichTextBox)tab.Controls[0]).Rtf = lastChange;
                    tab.UndoContainer.Push(lastChange);
                    break;
                default:
                    ((RichTextBox)tab.Controls[0]).Text = lastChange;
                    tab.UndoContainer.Push(lastChange);
                    break;
            }
            secureChange = false;
        }
        /// <summary>
        /// Compiles code into folder that is specified by user;
        /// </summary>
        private void CompileCode(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            try
            {
                SaveFileDialog saveFileDialogComp = new SaveFileDialog();
                saveFileDialogComp.Title = "Куда скомпилировать проект";
                saveFileDialogComp.Filter = "Executable files|*.exe";
                if (CompilerPath == "")
                {
                    MessageBox.Show("Заполните путь к компилятору в настройках", "Ошибка");
                    return;
                }
                if (saveFileDialogComp.ShowDialog() == DialogResult.Cancel || tabControl1.SelectedTab == null)
                    return;
                string output = ((MyTabPage)tabControl1.SelectedTab).TabPath;
                string command = $"/C {CompilerPath} -out:{saveFileDialogComp.FileName} {output} ";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = command;
                process.Start();
                process.WaitForExit();
                MessageBox.Show(process.StandardOutput.ReadToEnd(), "Компиляция успешна!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Компиляция не удалась");
            }

        }
        /// <summary>
        /// Logs files as specified in settings;
        /// </summary>
        private void logsTimer_Tick(object sender, EventArgs e)
        {
            foreach (MyTabPage tab in tabControl1.TabPages)
            {
                tab.SaveTabIntoLogs($"logs{Path.DirectorySeparatorChar}{(DateTime.Now.ToString()).Replace(" ", string.Empty).Replace(".", "_").Replace(":", "_")}{tab.TabPath.Split(Path.DirectorySeparatorChar)[^1]}");
            }
        }
    }
}
