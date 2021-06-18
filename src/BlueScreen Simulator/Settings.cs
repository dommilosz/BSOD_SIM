using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        }
        public BSODData.Data data;
        public Settings(BSODData.Data data, string savepath)
        {
            InitializeComponent();
            this.data = data;
            unsmode.Checked = data.unsafeMode;
            textBox1.Text = data.cmd;
            chk_close_after_exec.Checked = data.closeAfterCmd;
            cmin.Value = data.cmin;
            tmin.Value = data.tmin;
            cmax.Value = data.cmax;
            tmax.Value = data.tmax;
            chk_hide_cursor.Checked = data.hideCursor;
            txt_password.Text = data.password;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Process Process1 = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {textBox1.Text.Replace("\n", "&")}");
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process1.StartInfo = startInfo;
            try { Process1.Start(); } catch { }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            data.unsafeMode = unsmode.Checked;
            data.cmd = textBox1.Text;
            data.closeAfterCmd = chk_close_after_exec.Checked;
            data.cmin = (int)cmin.Value;
            data.tmin = (int)tmin.Value;
            data.cmax = (int)cmax.Value;
            data.tmax = (int)tmax.Value;
            data.hideCursor = chk_hide_cursor.Checked;
            data.password = txt_password.Text;
            BSODData.Apply();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
