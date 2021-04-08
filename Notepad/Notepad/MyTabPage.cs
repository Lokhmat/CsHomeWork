using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    /// <summary>
    /// My class that enchances functionality of usuall TabPage. Inherited from TabPage;
    /// </summary>
    class MyTabPage : TabPage
    {

        public bool Unsaved { get; set; }
        // Path to the file in tab;
        public string TabPath { get; set; }
        // Int that represents type of content in tab. 1 - txt 2 - rtf 3 - c# code file;
        public int contentId;
        // Stack for ctrl+z;
        public Stack<string> UndoContainer { get; set; }
        // Stack for ctrl+shift+z;
        public Stack<string> RedoContainer { get; set; }
        /// <summary>
        /// Constructor of MyTabPage;
        /// </summary>
        /// <param name="name"> Text for the tab;</param>
        /// <param name="path"> Path to the file in the tab;</param>
        /// <param name="theme"> Theme type of application;</param>
        public MyTabPage(string name, string path, Theme theme) : base(name)
        {
            UndoContainer = new Stack<string>();
            RedoContainer = new Stack<string>();
            ContextMenuStrip = ContextMenuStrip;
            Unsaved = true;
            TabPath = path;
            contentId = (path.Split('.')[^1] == "rtf" ? 2 : path.Split('.')[^1] == "cs" ? 3 : 1);
        }
        /// <summary>
        /// Saving file that is open in tab;
        /// </summary>
        /// <param name="fileName"> Full absolute name of file we want to save;</param>
        public void SaveTab(string fileName)
        {
            try
            {
                if (Controls.Count <= 0)
                    return;
                RichTextBox t = (RichTextBox)Controls[0];
                if (contentId == 2)
                    File.WriteAllText(fileName, t.Rtf);
                else
                    File.WriteAllText(fileName, t.Text);
                Unsaved = false;
                TabPath = fileName;
                Text = fileName.Split(Path.DirectorySeparatorChar)[^1];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            };
        }
        /// <summary>
        /// Logging file that is open in tab. Unlike the SaveTab does not change path and name;
        /// </summary>
        /// <param name="fileName"> Full absolute name of file we want to save;</param>
        public void SaveTabIntoLogs(string fileName)
        {
            try
            {
                if (Controls.Count <= 0)
                    return;
                RichTextBox t = (RichTextBox)Controls[0];
                if (contentId == 2)
                    File.WriteAllText(fileName, t.Rtf);
                else
                    File.WriteAllText(fileName, t.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            };
        }

    }
    /// <summary>
    /// Enum for application theme;
    /// </summary>
    enum Theme
    {
        Light,
        Dark
    }
    /// <summary>
    /// Enum for saving/logging frequency;
    /// </summary>
    enum Frequency
    {
        QarterMinute,
        HalfMinute,
        Minute,
        FiveMinute,
        TenMinute,
        Never
    }
}
