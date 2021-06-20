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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chk_AutoStart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.chk_hide_cursor = new System.Windows.Forms.CheckBox();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.p_batchModeOff = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.chk_batchMode = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.lbl_resInfo = new System.Windows.Forms.Label();
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
            this.tabPage3.SuspendLayout();
            this.p_batchModeOff.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.tabPage2.Controls.Add(this.chk_AutoStart);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txt_password);
            this.tabPage2.Controls.Add(this.chk_hide_cursor);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(405, 311);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CUSTOMIZATION";
            // 
            // chk_AutoStart
            // 
            this.chk_AutoStart.AutoSize = true;
            this.chk_AutoStart.Location = new System.Drawing.Point(157, 141);
            this.chk_AutoStart.Name = "chk_AutoStart";
            this.chk_AutoStart.Size = new System.Drawing.Size(188, 17);
            this.chk_AutoStart.TabIndex = 41;
            this.chk_AutoStart.Text = "Automaticly start after opening exe";
            this.toolTip1.SetToolTip(this.chk_AutoStart, "If saved as .exe file it will automaticly start the BSOD");
            this.chk_AutoStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Password:";
            this.toolTip1.SetToolTip(this.label1, "Password required to close BSOD after starting\r\nSimply start typing characters");
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(102, 162);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(100, 20);
            this.txt_password.TabIndex = 37;
            // 
            // chk_hide_cursor
            // 
            this.chk_hide_cursor.AutoSize = true;
            this.chk_hide_cursor.Location = new System.Drawing.Point(9, 142);
            this.chk_hide_cursor.Name = "chk_hide_cursor";
            this.chk_hide_cursor.Size = new System.Drawing.Size(114, 17);
            this.chk_hide_cursor.TabIndex = 36;
            this.chk_hide_cursor.Text = "Hide mouse cursor";
            this.chk_hide_cursor.UseVisualStyleBackColor = true;
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
            this.groupBox3.Controls.Add(this.chk_batchMode);
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
            this.unsmode.Text = "Unsafe Mode";
            this.toolTip1.SetToolTip(this.unsmode, "Blocks use of alt f4");
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
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage3.Controls.Add(this.lbl_resInfo);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.p_batchModeOff);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(405, 311);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "BATCH RESOURCES";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(9, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(138, 303);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Location = new System.Drawing.Point(153, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 22);
            this.button1.TabIndex = 31;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button3.Location = new System.Drawing.Point(153, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 22);
            this.button3.TabIndex = 32;
            this.button3.Text = "REMOVE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button5.Location = new System.Drawing.Point(153, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 22);
            this.button5.TabIndex = 33;
            this.button5.Text = "RENAME";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // p_batchModeOff
            // 
            this.p_batchModeOff.Controls.Add(this.button7);
            this.p_batchModeOff.Controls.Add(this.label4);
            this.p_batchModeOff.Location = new System.Drawing.Point(286, 7);
            this.p_batchModeOff.Name = "p_batchModeOff";
            this.p_batchModeOff.Size = new System.Drawing.Size(111, 121);
            this.p_batchModeOff.TabIndex = 34;
            this.p_batchModeOff.Visible = false;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 69);
            this.label4.TabIndex = 0;
            this.label4.Text = "WARNING\r\nBatch mode is off. Resources are only available in batch mode";
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button7.ForeColor = System.Drawing.Color.Lime;
            this.button7.Location = new System.Drawing.Point(3, 76);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(101, 36);
            this.button7.TabIndex = 35;
            this.button7.Text = "ENABLE BATCH MODE";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // chk_batchMode
            // 
            this.chk_batchMode.AutoSize = true;
            this.chk_batchMode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chk_batchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batchMode.Location = new System.Drawing.Point(3, 219);
            this.chk_batchMode.Name = "chk_batchMode";
            this.chk_batchMode.Size = new System.Drawing.Size(118, 17);
            this.chk_batchMode.TabIndex = 34;
            this.chk_batchMode.Text = "Batch Mode";
            this.toolTip1.SetToolTip(this.chk_batchMode, "Batch mode - command is executed as batch file so you can use labels/goto\r\nIt ext" +
        "racts command and resources to temp folder");
            this.chk_batchMode.UseVisualStyleBackColor = true;
            this.chk_batchMode.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(150, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 145);
            this.label7.TabIndex = 35;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button8.Location = new System.Drawing.Point(153, 35);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(87, 22);
            this.button8.TabIndex = 36;
            this.button8.Text = "CHANGE";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // lbl_resInfo
            // 
            this.lbl_resInfo.AutoSize = true;
            this.lbl_resInfo.Location = new System.Drawing.Point(153, 131);
            this.lbl_resInfo.Name = "lbl_resInfo";
            this.lbl_resInfo.Size = new System.Drawing.Size(56, 13);
            this.lbl_resInfo.TabIndex = 37;
            this.lbl_resInfo.Text = "Resource:";
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
            this.tabPage2.PerformLayout();
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.p_batchModeOff.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox chk_hide_cursor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.CheckBox chk_AutoStart;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel p_batchModeOff;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.CheckBox chk_batchMode;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label lbl_resInfo;
    }
}