namespace GolfScore
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelBet = new System.Windows.Forms.ToolStripLabel();
            this.TextBoxBet = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripStatButton = new System.Windows.Forms.ToolStripButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxP1score = new System.Windows.Forms.ComboBox();
            this.comboBoxP4score = new System.Windows.Forms.ComboBox();
            this.comboBoxP3score = new System.Windows.Forms.ComboBox();
            this.comboBoxP2score = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.YellowGreen;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripSeparator2,
            this.toolStripLabelBet,
            this.TextBoxBet,
            this.toolStripSeparator1,
            this.toolStripStatButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(317, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 30);
            this.toolStripButtonSave.Text = "toolStripButton1";
            this.toolStripButtonSave.ToolTipText = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripLabelBet
            // 
            this.toolStripLabelBet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabelBet.Name = "toolStripLabelBet";
            this.toolStripLabelBet.Size = new System.Drawing.Size(30, 30);
            this.toolStripLabelBet.Text = "Bet:";
            // 
            // TextBoxBet
            // 
            this.TextBoxBet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxBet.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.TextBoxBet.Name = "TextBoxBet";
            this.TextBoxBet.Size = new System.Drawing.Size(23, 23);
            this.TextBoxBet.Text = "10";
            this.TextBoxBet.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripStatButton
            // 
            this.toolStripStatButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatButton.Image = global::GolfScore.Properties.Resources._1477521928_10_icon_icons_com_74620;
            this.toolStripStatButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStatButton.Name = "toolStripStatButton";
            this.toolStripStatButton.Size = new System.Drawing.Size(23, 30);
            this.toolStripStatButton.Text = "toolStripButton2";
            this.toolStripStatButton.ToolTipText = "Statistic";
            this.toolStripStatButton.Click += new System.EventHandler(this.ToolStripStatButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.TextChanged += new System.EventHandler(this.ComboBoxPlayers_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 184);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Players";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(16, 57);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(160, 24);
            this.comboBox2.TabIndex = 12;
            this.comboBox2.TextChanged += new System.EventHandler(this.ComboBoxPlayers_TextChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.Enabled = false;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(16, 141);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(160, 24);
            this.comboBox4.TabIndex = 4;
            this.comboBox4.TextChanged += new System.EventHandler(this.ComboBoxPlayers_TextChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(16, 98);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(160, 24);
            this.comboBox3.TabIndex = 4;
            this.comboBox3.TextChanged += new System.EventHandler(this.ComboBoxPlayers_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.comboBoxP1score);
            this.groupBox2.Controls.Add(this.comboBoxP4score);
            this.groupBox2.Controls.Add(this.comboBoxP3score);
            this.groupBox2.Controls.Add(this.comboBoxP2score);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(218, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 184);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Strokes";
            // 
            // comboBoxP1score
            // 
            this.comboBoxP1score.Enabled = false;
            this.comboBoxP1score.FormattingEnabled = true;
            this.comboBoxP1score.Location = new System.Drawing.Point(16, 19);
            this.comboBoxP1score.Name = "comboBoxP1score";
            this.comboBoxP1score.Size = new System.Drawing.Size(40, 24);
            this.comboBoxP1score.TabIndex = 6;
            this.comboBoxP1score.Text = "0";
            this.comboBoxP1score.TextChanged += new System.EventHandler(this.ComboBox_score_TextChanged);
            // 
            // comboBoxP4score
            // 
            this.comboBoxP4score.Enabled = false;
            this.comboBoxP4score.FormattingEnabled = true;
            this.comboBoxP4score.Location = new System.Drawing.Point(16, 141);
            this.comboBoxP4score.Name = "comboBoxP4score";
            this.comboBoxP4score.Size = new System.Drawing.Size(40, 24);
            this.comboBoxP4score.TabIndex = 9;
            this.comboBoxP4score.Text = "0";
            this.comboBoxP4score.TextChanged += new System.EventHandler(this.ComboBox_score_TextChanged);
            // 
            // comboBoxP3score
            // 
            this.comboBoxP3score.Enabled = false;
            this.comboBoxP3score.FormattingEnabled = true;
            this.comboBoxP3score.Location = new System.Drawing.Point(16, 98);
            this.comboBoxP3score.Name = "comboBoxP3score";
            this.comboBoxP3score.Size = new System.Drawing.Size(40, 24);
            this.comboBoxP3score.TabIndex = 8;
            this.comboBoxP3score.Text = "0";
            this.comboBoxP3score.TextChanged += new System.EventHandler(this.ComboBox_score_TextChanged);
            // 
            // comboBoxP2score
            // 
            this.comboBoxP2score.Enabled = false;
            this.comboBoxP2score.FormattingEnabled = true;
            this.comboBoxP2score.Location = new System.Drawing.Point(16, 57);
            this.comboBoxP2score.Name = "comboBoxP2score";
            this.comboBoxP2score.Size = new System.Drawing.Size(40, 24);
            this.comboBoxP2score.TabIndex = 7;
            this.comboBoxP2score.Text = "0";
            this.comboBoxP2score.TextChanged += new System.EventHandler(this.ComboBox_score_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBox1.Location = new System.Drawing.Point(12, 234);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 114);
            this.textBox1.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(127, 36);
            this.dateTimePicker1.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(61, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.ToolStripStatButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GolfScore.Properties.Resources.golf1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(321, 360);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(337, 399);
            this.MinimumSize = new System.Drawing.Size(337, 399);
            this.Name = "Form1";
            this.Text = "Golf";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxP1score;
        private System.Windows.Forms.ComboBox comboBoxP4score;
        private System.Windows.Forms.ComboBox comboBoxP3score;
        private System.Windows.Forms.ComboBox comboBoxP2score;
        private System.Windows.Forms.ToolStripTextBox TextBoxBet;
        private System.Windows.Forms.ToolStripLabel toolStripLabelBet;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripStatButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

