using System.Windows.Forms;
namespace Notepad
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

        public void Close(object sender, System.EventArgs e)
        {
            Close();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolFileButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.newFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.compileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolEditButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.undoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.copyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.removeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFormatButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.fontChangingButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSettingsButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBoxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllButton = new System.Windows.Forms.ToolStripMenuItem();
            this.cutSelectedButton = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedButton = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteSelectedButton = new System.Windows.Forms.ToolStripMenuItem();
            this.formatSelectedButton = new System.Windows.Forms.ToolStripMenuItem();
            this.logsTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.richTextBoxContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 424);
            this.tabControl1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFileButton,
            this.toolEditButton,
            this.toolFormatButton,
            this.toolSettingsButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolFileButton
            // 
            this.toolFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolFileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileButton,
            this.newWindowButton,
            this.openFileButton,
            this.toolStripSeparator4,
            this.compileButton,
            this.saveFileButton,
            this.saveAsFileButton,
            this.closeTabButton,
            this.toolStripSeparator1,
            this.exitButton});
            this.toolFileButton.Image = ((System.Drawing.Image)(resources.GetObject("toolFileButton.Image")));
            this.toolFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileButton.Name = "toolFileButton";
            this.toolFileButton.Size = new System.Drawing.Size(49, 22);
            this.toolFileButton.Text = "Файл";
            // 
            // newFileButton
            // 
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(273, 22);
            this.newFileButton.Text = "Новый - CTRL+N";
            this.newFileButton.Click += new System.EventHandler(this.OpenNewTab);
            // 
            // newWindowButton
            // 
            this.newWindowButton.Name = "newWindowButton";
            this.newWindowButton.Size = new System.Drawing.Size(273, 22);
            this.newWindowButton.Text = "Файл в новом окне - CTRL+SHIFT+N";
            this.newWindowButton.Click += new System.EventHandler(this.newWindowButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(273, 22);
            this.openFileButton.Text = "Открыть";
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(270, 6);
            // 
            // compileButton
            // 
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(273, 22);
            this.compileButton.Text = "Скомпилировать C#";
            this.compileButton.Click += new System.EventHandler(this.CompileCode);
            // 
            // saveFileButton
            // 
            this.saveFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(273, 22);
            this.saveFileButton.Text = "Сохранить - CTRL+S";
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // saveAsFileButton
            // 
            this.saveAsFileButton.Name = "saveAsFileButton";
            this.saveAsFileButton.Size = new System.Drawing.Size(273, 22);
            this.saveAsFileButton.Text = "Сохранить как - CTRL+SHIFT+S";
            this.saveAsFileButton.Click += new System.EventHandler(this.saveAsFileButton_Click);
            // 
            // closeTabButton
            // 
            this.closeTabButton.Name = "closeTabButton";
            this.closeTabButton.Size = new System.Drawing.Size(273, 22);
            this.closeTabButton.Text = "Закрыть вкладку";
            this.closeTabButton.Click += new System.EventHandler(this.closeTabButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(270, 6);
            // 
            // exitButton
            // 
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(273, 22);
            this.exitButton.Text = "Выход - CTRL+SHIFT+E";
            this.exitButton.Click += new System.EventHandler(this.Close);
            // 
            // toolEditButton
            // 
            this.toolEditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolEditButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.toolStripSeparator2,
            this.cutButton,
            this.copyButton,
            this.removeButton,
            this.toolStripSeparator3,
            this.selectAll});
            this.toolEditButton.Image = ((System.Drawing.Image)(resources.GetObject("toolEditButton.Image")));
            this.toolEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditButton.Name = "toolEditButton";
            this.toolEditButton.Size = new System.Drawing.Size(60, 22);
            this.toolEditButton.Text = "Правка";
            // 
            // undoButton
            // 
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(200, 22);
            this.undoButton.Text = "Отменить - CTRL+Z";
            this.undoButton.Click += new System.EventHandler(this.ProcessFormatButtons);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // cutButton
            // 
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(200, 22);
            this.cutButton.Text = "Вырезать - CTRL+X";
            this.cutButton.Click += new System.EventHandler(this.ProcessFormatButtons);
            // 
            // copyButton
            // 
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(200, 22);
            this.copyButton.Text = "Скопировать - CTRL+C";
            this.copyButton.Click += new System.EventHandler(this.ProcessFormatButtons);
            // 
            // removeButton
            // 
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(200, 22);
            this.removeButton.Text = "Удалить - DEL";
            this.removeButton.Click += new System.EventHandler(this.ProcessFormatButtons);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(197, 6);
            // 
            // selectAll
            // 
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(200, 22);
            this.selectAll.Text = "Выбрать всё - CTRL+A";
            this.selectAll.Click += new System.EventHandler(this.ProcessFormatButtons);
            // 
            // toolFormatButton
            // 
            this.toolFormatButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolFormatButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontChangingButton});
            this.toolFormatButton.Image = ((System.Drawing.Image)(resources.GetObject("toolFormatButton.Image")));
            this.toolFormatButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFormatButton.Name = "toolFormatButton";
            this.toolFormatButton.Size = new System.Drawing.Size(63, 22);
            this.toolFormatButton.Text = "Формат";
            // 
            // fontChangingButton
            // 
            this.fontChangingButton.Name = "fontChangingButton";
            this.fontChangingButton.Size = new System.Drawing.Size(122, 22);
            this.fontChangingButton.Text = "Шрифт...";
            this.fontChangingButton.Click += new System.EventHandler(this.ChangeFont);
            // 
            // toolSettingsButton
            // 
            this.toolSettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("toolSettingsButton.Image")));
            this.toolSettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSettingsButton.Name = "toolSettingsButton";
            this.toolSettingsButton.Size = new System.Drawing.Size(71, 22);
            this.toolSettingsButton.Text = "Настройки";
            this.toolSettingsButton.Click += new System.EventHandler(this.toolSettingsButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Txt files (*.txt)|*.txt|Rich text files (*.rtf)|*.rtf|C# code files (*.cs)|*.cs";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Txt files (*.txt)|*.txt|Rich text files (*.rtf)|*.rtf|C# code files (*.cs)|*.cs";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // richTextBoxContextMenu
            // 
            this.richTextBoxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllButton,
            this.cutSelectedButton,
            this.copySelectedButton,
            this.pasteSelectedButton,
            this.formatSelectedButton});
            this.richTextBoxContextMenu.Name = "richTextBoxContextMenu";
            this.richTextBoxContextMenu.Size = new System.Drawing.Size(143, 114);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(142, 22);
            this.selectAllButton.Text = "Выбрать всё";
            this.selectAllButton.Click += new System.EventHandler(this.ProcessSelection);
            // 
            // cutSelectedButton
            // 
            this.cutSelectedButton.Name = "cutSelectedButton";
            this.cutSelectedButton.Size = new System.Drawing.Size(142, 22);
            this.cutSelectedButton.Text = "Вырезать";
            this.cutSelectedButton.Click += new System.EventHandler(this.ProcessSelection);
            // 
            // copySelectedButton
            // 
            this.copySelectedButton.Name = "copySelectedButton";
            this.copySelectedButton.Size = new System.Drawing.Size(142, 22);
            this.copySelectedButton.Text = "Копировать";
            this.copySelectedButton.Click += new System.EventHandler(this.ProcessSelection);
            // 
            // pasteSelectedButton
            // 
            this.pasteSelectedButton.Name = "pasteSelectedButton";
            this.pasteSelectedButton.Size = new System.Drawing.Size(142, 22);
            this.pasteSelectedButton.Text = "Вставить";
            this.pasteSelectedButton.Click += new System.EventHandler(this.ProcessSelection);
            // 
            // formatSelectedButton
            // 
            this.formatSelectedButton.Name = "formatSelectedButton";
            this.formatSelectedButton.Size = new System.Drawing.Size(142, 22);
            this.formatSelectedButton.Text = "Формат";
            this.formatSelectedButton.Click += new System.EventHandler(this.ProcessSelection);
            // 
            // logsTimer
            // 
            this.logsTimer.Tick += new System.EventHandler(this.logsTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Блокнот+";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessHotkeys);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.richTextBoxContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void OpenFileButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolFileButton;
        private System.Windows.Forms.ToolStripMenuItem openFileButton;
        private System.Windows.Forms.ToolStripDropDownButton toolEditButton;
        private System.Windows.Forms.ToolStripDropDownButton toolFormatButton;
        private System.Windows.Forms.ToolStripButton toolSettingsButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem newFileButton;
        private System.Windows.Forms.ToolStripMenuItem saveAsFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem fontChangingButton;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem saveFileButton;
        private ToolStripMenuItem newWindowButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitButton;
        private ToolStripMenuItem closeTabButton;
        private ContextMenuStrip richTextBoxContextMenu;
        private ToolStripMenuItem selectAllButton;
        private ToolStripMenuItem cutSelectedButton;
        private ToolStripMenuItem copySelectedButton;
        private ToolStripMenuItem pasteSelectedButton;
        private ToolStripMenuItem formatSelectedButton;
        private ToolStripMenuItem undoButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem cutButton;
        private ToolStripMenuItem copyButton;
        private ToolStripMenuItem removeButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem selectAll;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem compileButton;
        private Timer logsTimer;
    }
}

