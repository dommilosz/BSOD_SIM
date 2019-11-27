using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerRun
{
    public partial class Form1 : Form
    {
        DateTime date = DateTime.Now;
        int s = 0;
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = date.Hour+1;
            numericUpDown2.Value = date.Minute;
            numericUpDown3.Value = date.Second;
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            date = DateTime.Now;
            
            s = Convert.ToInt32( numericUpDown1.Value * 3600 + numericUpDown2.Value * 60 + numericUpDown3.Value);
            s -= date.Hour * 3600;
            s -= date.Minute * 60;
            s -= date.Second;
            if (s <= 0)
            {
                Button2_Click(new object(), new EventArgs());
                this.Close();
            }
            int h = s / 3600;
            s -= h * 3600;
            int m = s / 60;
            s -= m * 60;
            label1.Text = "Remaining : " + h + " h " + m + " m " + s + " s";
            notifyIcon1.Text = label1.Text;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = openFileDialog1.FileName;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process Process1 = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo(label2.Text);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process1.StartInfo = startInfo;
            try { Process1.Start(); } catch { }
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
