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
            chk_AutoStart.Checked = data.AutoStart;
            chk_batchMode.Checked = data.batchMode;

            p_batchModeOff.Visible = !data.batchMode;
            UpdateListBox();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            data.cmd = textBox1.Text;
            BSODData.RunCmd();
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
            data.AutoStart = chk_AutoStart.Checked;
            BSODData.Apply();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var bytes = File.ReadAllBytes(openFileDialog1.FileName);
                BSODData.AddResource(openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Length - 1], bytes);
            }
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (var item in data.resources)
            {
                listBox1.Items.Add(item.name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >=0)
            {
                BSODData.DeleteResource(listBox1.SelectedItem.ToString());
            }
            UpdateListBox();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            data.batchMode = true;
            p_batchModeOff.Visible = false;
            chk_batchMode.Checked = data.batchMode;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            data.batchMode = chk_batchMode.Checked;
            p_batchModeOff.Visible = !data.batchMode;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                new RenameDialog(BSODData.GetResource(listBox1.SelectedItem.ToString())).ShowDialog();
            }
            UpdateListBox();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var res = BSODData.GetResource(listBox1.SelectedItem.ToString());

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var bytes = File.ReadAllBytes(openFileDialog1.FileName);
                    BSODData.AddResource(openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Length - 1], bytes, res);
                }
            }
            UpdateListBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_resInfo.Text = "Resource: ";
            if (listBox1.SelectedIndex >= 0)
            {
                var res = BSODData.GetResource(listBox1.SelectedItem.ToString());
                lbl_resInfo.Text += res.data.Length + "B";
            }
        }
    }
}
