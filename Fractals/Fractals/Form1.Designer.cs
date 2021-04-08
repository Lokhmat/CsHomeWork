namespace Fractals
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
            this.components = new System.ComponentModel.Container();
            this.paintTimer = new System.Windows.Forms.Timer(this.components);
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.comboLabel = new System.Windows.Forms.Label();
            this.recurLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.recurDepth = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.supLabel3 = new System.Windows.Forms.Label();
            this.supLabel2 = new System.Windows.Forms.Label();
            this.supLabel1 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.helpButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.resizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Обдуваемое ветром фрактальное дерево",
            "Кривая Коха",
            "Ковер Серпинского",
            "Треугольник Серпинского",
            "Множество Кантора"});
            this.comboBox.Location = new System.Drawing.Point(12, 57);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(329, 23);
            this.comboBox.TabIndex = 0;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboLabel
            // 
            this.comboLabel.AutoSize = true;
            this.comboLabel.Location = new System.Drawing.Point(12, 39);
            this.comboLabel.Name = "comboLabel";
            this.comboLabel.Size = new System.Drawing.Size(85, 15);
            this.comboLabel.TabIndex = 1;
            this.comboLabel.Text = "Тип фрактала:";
            // 
            // recurLabel
            // 
            this.recurLabel.AutoSize = true;
            this.recurLabel.Location = new System.Drawing.Point(12, 93);
            this.recurLabel.Name = "recurLabel";
            this.recurLabel.Size = new System.Drawing.Size(111, 15);
            this.recurLabel.TabIndex = 2;
            this.recurLabel.Text = "Глубина рекурсии:";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 152);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(962, 416);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // recurDepth
            // 
            this.recurDepth.Location = new System.Drawing.Point(13, 111);
            this.recurDepth.Name = "recurDepth";
            this.recurDepth.Size = new System.Drawing.Size(328, 23);
            this.recurDepth.TabIndex = 5;
            this.recurDepth.Text = "0";
            this.recurDepth.TextChanged += new System.EventHandler(this.recurDepth_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(717, 111);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 23);
            this.textBox1.TabIndex = 7;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(717, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(257, 23);
            this.textBox2.TabIndex = 8;
            this.textBox2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(717, 53);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(257, 23);
            this.textBox3.TabIndex = 9;
            this.textBox3.Visible = false;
            // 
            // supLabel3
            // 
            this.supLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supLabel3.AutoSize = true;
            this.supLabel3.Location = new System.Drawing.Point(691, 35);
            this.supLabel3.Name = "supLabel3";
            this.supLabel3.Size = new System.Drawing.Size(259, 15);
            this.supLabel3.TabIndex = 10;
            this.supLabel3.Text = "Отношение длин отрезков(этот/следующий):";
            this.supLabel3.Visible = false;
            // 
            // supLabel2
            // 
            this.supLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supLabel2.AutoSize = true;
            this.supLabel2.Location = new System.Drawing.Point(581, 82);
            this.supLabel2.Name = "supLabel2";
            this.supLabel2.Size = new System.Drawing.Size(123, 15);
            this.supLabel2.TabIndex = 11;
            this.supLabel2.Text = "Угол наклона левого";
            this.supLabel2.Visible = false;
            // 
            // supLabel1
            // 
            this.supLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supLabel1.AutoSize = true;
            this.supLabel1.Location = new System.Drawing.Point(581, 111);
            this.supLabel1.Name = "supLabel1";
            this.supLabel1.Size = new System.Drawing.Size(130, 15);
            this.supLabel1.TabIndex = 12;
            this.supLabel1.Text = "Угол наклона правого";
            this.supLabel1.Visible = false;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(365, 54);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(210, 71);
            this.buttonReset.TabIndex = 13;
            this.buttonReset.Text = "Обновить фрактал";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.helpButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(986, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.Control;
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(70, 22);
            this.saveButton.Text = "Сохранить";
            this.saveButton.Click += new System.EventHandler(this.SaveFract);
            // 
            // helpButton
            // 
            this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(60, 22);
            this.helpButton.Text = "Помощь";
            this.helpButton.Click += new System.EventHandler(this.ShowHelp);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "images|*.jpg";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(333, 575);
            this.trackBar1.Maximum = 3;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(653, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // resizeLabel
            // 
            this.resizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resizeLabel.Location = new System.Drawing.Point(254, 584);
            this.resizeLabel.Name = "resizeLabel";
            this.resizeLabel.Size = new System.Drawing.Size(73, 15);
            this.resizeLabel.TabIndex = 16;
            this.resizeLabel.Text = "Увеличение";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 620);
            this.Controls.Add(this.resizeLabel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.supLabel1);
            this.Controls.Add(this.supLabel2);
            this.Controls.Add(this.supLabel3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.recurDepth);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.recurLabel);
            this.Controls.Add(this.comboLabel);
            this.Controls.Add(this.comboBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fractals";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer paintTimer;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label comboLabel;
        private System.Windows.Forms.Label recurLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox recurDepth;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label supLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label supLabel2;
        private System.Windows.Forms.Label supLabel3;
        private System.Windows.Forms.Label supLabel;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton helpButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label resizeLabel;
    }
}

