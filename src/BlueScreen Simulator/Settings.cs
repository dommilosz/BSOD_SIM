using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace BlueScreen_Simulator
{
    public partial class Settings : Form
    {
        string savepatch;
        //public DialogResult DialogResult = DialogResult.None;
        public Settings()
        {
            InitializeComponent();
            this.Opacity = 0;
            tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y-30);
            this.Height -= 30;
        }
        public Settings(int tab)
        {
            InitializeComponent();
            tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y - 30);
            tabControl1.SelectTab(tab);
            this.Height -= 30;
        }
        public Settings(int tab,bool us,bool hqr,bool hpr,string savepatch2,float MF, float QF, float EF,string cmd,bool cac)
        {
            InitializeComponent();
            this.Height -= 30;
            tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y - 30);
            tabControl1.SelectTab(tab);
            unsmode.Checked = us;
            savepatch = savepatch2;
            MFont.Value = Convert.ToDecimal( MF);
            QRFont.Value = Convert.ToDecimal(QF);
            EFont.Value = Convert.ToDecimal(EF);
            textBox1.Text = cmd;
            checkBox1.Checked = cac;
        }
        public Settings(int tab,int cmin2,int cmax2,int tmin2,int tmax2)
        {
            InitializeComponent();
            this.Height -= 30;
            tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y - 30);
            tabControl1.SelectTab(tab);
            cmin.Value = cmin2;
            tmin.Value = tmin2;
            cmax.Value = cmax2;
            tmax.Value = tmax2;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (savepatch != "not saved")
            {
                saveFileDialog1.Filter = "Shortcut (.lnk)|*.lnk|Bat file (.bat)|*.bat";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileName.Contains(".bat"))
                    {
                        string[] tmp = new string[100];
                        char tmp2 = '"';
                        tmp[0] = "cd " + Application.StartupPath;
                        tmp[1] = tmp2 + "BlueScreen Simulator" + tmp2 + " loadfile " + savepatch;
                        File.WriteAllLines(saveFileDialog1.FileName, tmp);
                    }
                    else
                    {
                        string[] tmp = new string[100];
                        char tmp2 = '"';
                        tmp[0] = "cd " + Application.StartupPath;
                        tmp[1] = tmp2 + "BlueScreen Simulator" + tmp2 + " loadfile " + savepatch;
                        if (saveFileDialog1.FileName.Contains(".lnk")) { } else { saveFileDialog1.FileName += ".lnk"; }

                        object shDesktop = (object)"Desktop";
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(saveFileDialog1.FileName);
                        shortcut.TargetPath = Application.ExecutablePath;
                        shortcut.Arguments = " loadfile " + savepatch;
                        shortcut.Save();

                        saveFileDialog1.FileName = "";
                        openFileDialog1.FileName = "";
                    }
                }
            }
            else { MessageBox.Show("Load or Save first"); }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) { this.Opacity += 0.02; }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            timer2.Start();
            
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0) { this.Opacity -= 0.05; }
            if (this.Opacity <= 0) this.Close();
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Process Process1 = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo(textBox1.Text);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process1.StartInfo = startInfo;
            try { Process1.Start(); } catch { }
        }
    }
}
