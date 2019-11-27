namespace BlueScreen_Simulator
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmax = new System.Windows.Forms.NumericUpDown();
            this.tmin = new System.Windows.Forms.NumericUpDown();
            this.cmax = new System.Windows.Forms.NumericUpDown();
            this.cmin = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.EFont = new System.Windows.Forms.NumericUpDown();
            this.QRFont = new System.Windows.Forms.NumericUpDown();
            this.MFont = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.unsmode = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmin)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MFont)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-23, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(553, 302);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tmax);
            this.tabPage1.Controls.Add(this.tmin);
            this.tabPage1.Controls.Add(this.cmax);
            this.tabPage1.Controls.Add(this.cmin);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(545, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "      Percent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(130, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(130, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "max";
            // 
            // tmax
            // 
            this.tmax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tmax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tmax.Location = new System.Drawing.Point(183, 129);
            this.tmax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tmax.Name = "tmax";
            this.tmax.Size = new System.Drawing.Size(75, 16);
            this.tmax.TabIndex = 14;
            // 
            // tmin
            // 
            this.tmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tmin.Location = new System.Drawing.Point(183, 107);
            this.tmin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tmin.Name = "tmin";
            this.tmin.Size = new System.Drawing.Size(75, 16);
            this.tmin.TabIndex = 13;
            // 
            // cmax
            // 
            this.cmax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmax.Location = new System.Drawing.Point(183, 68);
            this.cmax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cmax.Name = "cmax";
            this.cmax.Size = new System.Drawing.Size(75, 16);
            this.cmax.TabIndex = 12;
            // 
            // cmin
            // 
            this.cmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmin.Location = new System.Drawing.Point(183, 46);
            this.cmin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cmin.Name = "cmin";
            this.cmin.Size = new System.Drawing.Size(75, 16);
            this.cmin.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(20, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(336, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(130, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "min";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(130, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(33, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Delay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(33, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Percent";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.EFont);
            this.tabPage2.Controls.Add(this.QRFont);
            this.tabPage2.Controls.Add(this.MFont);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.unsmode);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(545, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Other";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(245, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 30);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Close BSOD after \r\nexecution";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(257, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Visible = false;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button6.Location = new System.Drawing.Point(245, 46);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 22);
            this.button6.TabIndex = 13;
            this.button6.Text = "TEST EXECUTE";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button5.Location = new System.Drawing.Point(245, 74);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 22);
            this.button5.TabIndex = 12;
            this.button5.Text = "Select file to execute";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(242, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Command to execute";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(29, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 60);
            this.label7.TabIndex = 9;
            this.label7.Text = "Main Font\r\nQR Text Font\r\nEmoticon Font";
            // 
            // EFont
            // 
            this.EFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EFont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EFont.Location = new System.Drawing.Point(157, 111);
            this.EFont.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.EFont.Name = "EFont";
            this.EFont.Size = new System.Drawing.Size(54, 16);
            this.EFont.TabIndex = 8;
            // 
            // QRFont
            // 
            this.QRFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.QRFont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QRFont.Location = new System.Drawing.Point(157, 88);
            this.QRFont.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.QRFont.Name = "QRFont";
            this.QRFont.Size = new System.Drawing.Size(54, 16);
            this.QRFont.TabIndex = 7;
            // 
            // MFont
            // 
            this.MFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MFont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MFont.Location = new System.Drawing.Point(157, 65);
            this.MFont.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.MFont.Name = "MFont";
            this.MFont.Size = new System.Drawing.Size(54, 16);
            this.MFont.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button3.Location = new System.Drawing.Point(31, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 36);
            this.button3.TabIndex = 5;
            this.button3.Text = "Generate BSOD Run file";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(21, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button2_Click);
            // 
            // unsmode
            // 
            this.unsmode.AutoSize = true;
            this.unsmode.Checked = true;
            this.unsmode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.unsmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unsmode.Location = new System.Drawing.Point(138, 35);
            this.unsmode.Name = "unsmode";
            this.unsmode.Size = new System.Drawing.Size(84, 17);
            this.unsmode.TabIndex = 0;
            this.unsmode.Text = "unsafe mode";
            this.unsmode.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(318, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 20);
            this.button4.TabIndex = 15;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(339, 201);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmin)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MFont)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown tmax;
        public System.Windows.Forms.NumericUpDown tmin;
        public System.Windows.Forms.NumericUpDown cmax;
        public System.Windows.Forms.NumericUpDown cmin;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown EFont;
        public System.Windows.Forms.NumericUpDown QRFont;
        public System.Windows.Forms.NumericUpDown MFont;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.CheckBox unsmode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}