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
    /// Parent form so we could run multiple windows of notepad;
    /// </summary>
    public partial class ParentForm : Form
    {
        // Number of opened notepad forms so we could close parentform when its 0;
        public int numOfForms = 1;
        public ParentForm()
        {
            InitializeComponent();
            this.Opacity = 0;
            Form1 form = new Form1(this);
            form.parent = this;
            form.Show();
        }
        /// <summary>
        /// Open new blank notepad form by hotkeys;
        /// </summary>
        public void OpenNewForm()
        {
            Form1 form = new Form1(this);
            form.parent = this;
            form.OpenNewTab(null, null);
            form.Show();
            numOfForms++;
        }
        /// <summary>
        /// Open new blank notepad form by button;
        /// </summary>
        public void OpenNewForm(object sender, EventArgs e)
        {
            if (numOfForms > 99)
                return;
            Form1 form = new Form1(this);
            form.parent = this;
            form.OpenNewTab(null, null);
            form.Show();
            numOfForms++;
        }
        /// <summary>
        /// Checking if we should close parent form;
        /// </summary>
        public void ValidateForm()
        {
            if (numOfForms == 0)
            {
                Close();
            }
        }
    }
}
