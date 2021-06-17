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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmax = new System.Windows.Forms.NumericUpDown();
            this.tmin = new System.Windows.Forms.NumericUpDown();
            this.cmax = new System.Windows.Forms.NumericUpDown();
            this.cmin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.unsmode = new System.Windows.Forms.CheckBox();
            this.chk_close_after_exec = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmin)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(413, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(413, 337);
            this.tabControl1.TabIndex = 34;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(405, 311);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CUSTOMIZATION";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tmax);
            this.groupBox2.Controls.Add(this.tmin);
            this.groupBox2.Controls.Add(this.cmax);
            this.groupBox2.Controls.Add(this.cmin);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 132);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "step min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "step max";
            // 
            // tmax
            // 
            this.tmax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tmax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tmax.Location = new System.Drawing.Point(99, 105);
            this.tmax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tmax.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tmax.Name = "tmax";
            this.tmax.Size = new System.Drawing.Size(75, 16);
            this.tmax.TabIndex = 37;
            this.tmax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tmin
            // 
            this.tmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tmin.Location = new System.Drawing.Point(99, 83);
            this.tmin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tmin.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tmin.Name = "tmin";
            this.tmin.Size = new System.Drawing.Size(75, 16);
            this.tmin.TabIndex = 36;
            this.tmin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmax
            // 
            this.cmax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmax.Location = new System.Drawing.Point(99, 44);
            this.cmax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cmax.Name = "cmax";
            this.cmax.Size = new System.Drawing.Size(75, 16);
            this.cmax.TabIndex = 35;
            // 
            // cmin
            // 
            this.cmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmin.Location = new System.Drawing.Point(99, 22);
            this.cmin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cmin.Name = "cmin";
            this.cmin.Size = new System.Drawing.Size(75, 16);
            this.cmin.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(12, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "time min";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(12, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "time max";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(405, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "EXECUTION";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 305);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(269, 286);
            this.textBox1.TabIndex = 32;
            this.textBox1.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.unsmode);
            this.groupBox3.Controls.Add(this.chk_close_after_exec);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(272, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 286);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EXECUTION";
            // 
            // unsmode
            // 
            this.unsmode.AutoSize = true;
            this.unsmode.Checked = true;
            this.unsmode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.unsmode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.unsmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unsmode.Location = new System.Drawing.Point(3, 236);
            this.unsmode.Name = "unsmode";
            this.unsmode.Size = new System.Drawing.Size(118, 17);
            this.unsmode.TabIndex = 33;
            this.unsmode.Text = "unsafe mode";
            this.unsmode.UseVisualStyleBackColor = true;
            // 
            // chk_close_after_exec
            // 
            this.chk_close_after_exec.AutoSize = true;
            this.chk_close_after_exec.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chk_close_after_exec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_close_after_exec.Location = new System.Drawing.Point(3, 253);
            this.chk_close_after_exec.Name = "chk_close_after_exec";
            this.chk_close_after_exec.Size = new System.Drawing.Size(118, 30);
            this.chk_close_after_exec.TabIndex = 32;
            this.chk_close_after_exec.Text = "Close BSOD\r\nafter execution";
            this.chk_close_after_exec.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button6.Location = new System.Drawing.Point(3, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(118, 22);
            this.button6.TabIndex = 30;
            this.button6.Text = "< TEST CMD";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(391, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 18);
            this.button4.TabIndex = 15;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(413, 360);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmin)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown tmax;
        public System.Windows.Forms.NumericUpDown tmin;
        public System.Windows.Forms.NumericUpDown cmax;
        public System.Windows.Forms.NumericUpDown cmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox unsmode;
        public System.Windows.Forms.CheckBox chk_close_after_exec;
        private System.Windows.Forms.Button button6;
    }
}