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

namespace BlueScreen_Simulator
{
    public partial class BSOD_EDIT : Form
    {
        string savepatch = "not saved";
        int cmin = 1;
        int cmax = 8;
        int tmin = 1000;
        int tmax = 3500;
        bool unsafemode = true;
        string[] dane = new string[100];
        readonly string[] args = new string[100];
        string cmd = "";
        bool closeaftercmd = false;
        Size thissize;
        public BSOD_EDIT()
        {
            InitializeComponent();

            thissize = this.Size;
            ToLog("----NEW-RUN----");
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            //ThisScale();
            Directory.CreateDirectory(Application.StartupPath + @"\Data");
            args = Environment.GetCommandLineArgs();
            ToLog(string.Join(" ", args));

            try
            {
                if (args.Length > 1)
                {
                    if (args[1] == "loadfile")
                    {
                        try
                        {
                            string[] tmpvar = args;
                            tmpvar[0] = null;
                            tmpvar[1] = null;
                            ToLog(string.Join(" ", tmpvar).TrimStart(' '));
                            LoadFile(string.Join(" ", tmpvar));

                            pictureBox3.Dock = DockStyle.Fill;
                            timer3.Start();
                            pictureBox3.BackColor = this.BackColor;
                            BSOD_Start(new object(), new EventArgs());
                        }
                        catch (Exception ex) { this.Close(); ToLog(ex.ToString()); }
                    }
                }
                }
            catch (Exception ex) { ToLog(ex.ToString()); }
        }

        public void RunCmd(string command)
        {
            Process Process1 = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo(cmd);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process1.StartInfo = startInfo;
            try { Process1.Start(); } catch { }
        }

        private void ToLog(string log)
        {
            string toadd = "\r\n" + DateTime.Now + " : " + log;
            File.AppendAllText(Application.StartupPath + @"\Data\log.txt",toadd);
        }

        int pr = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            pr += rnd.Next(cmin,cmax);
            if (pr >= 100) { pr = 100; RunCmd(cmd); timer1.Stop(); if (closeaftercmd) password_in.Text = textBox7.Text; }
            textBox2.Text = (pr + "% " + label1.Text);
            timer1.Interval = rnd.Next(tmin, tmax);
            
        }

        private void BSOD_Start(object sender, EventArgs e)
        {
            ToLog("BSOD START");
            textBox1.ReadOnly = true;
            button1.Visible = false;
            timer1.Start();
            timer2.Start();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            label2.Visible = false;
            textBox7.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            textBox2.Visible = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            label1.Text = textBox2.Text;
            label1.Visible = false;
            textBox2.Location = new Point(125,379);
            ThisScale();
        }

        private void ThisScale()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            float tmp = bounds.Width;
            float tmp2 = bounds.Height;
            float tmp3 = thissize.Width;
            float tmp4 = thissize.Height;
            tmp = tmp / tmp3;
            tmp2 = tmp2 / tmp4;
            SizeF sizeF = new SizeF(tmp, tmp2);
            label1.Scale(sizeF);
            this.WindowState = FormWindowState.Maximized;

            textBox1.Scale(sizeF);
            textBox2.Scale(sizeF);
            textBox3.Scale(sizeF);
            textBox4.Scale(sizeF);
            textBox5.Scale(sizeF);
            textBox6.Scale(sizeF);
            textBox7.Scale(sizeF);
            textBox8.Scale(sizeF);
            textBox9.Scale(sizeF);

            label1.Scale(sizeF);
            pictureBox1.Scale(sizeF);
            ToLog("Scaling factor " + tmp + " " + tmp2 + " (" + Screen.GetBounds(Point.Empty).Size + "/" + thissize);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            password_in.Select();
            Cursor.Hide();
            this.TopMost = true;
            if (password_in.Text == textBox7.Text) this.Close();
            if (password_in.Text.Length >= textBox7.Text.Length) password_in.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SaveFile("dialog");
        }

        private void SaveFile(string patch)
        {
            try
            {
                dane[0] = textBox1.Text;
                dane[1] = textBox2.Text;
                dane[2] = textBox3.Text;
                dane[3] = textBox4.Text;
                dane[4] = textBox5.Text;
                dane[5] = textBox6.Text;
                dane[6] = "//timer settings";
                dane[7] = cmin.ToString();
                dane[8] = cmax.ToString();
                dane[9] = tmin.ToString();
                dane[10] = tmax.ToString();
                dane[11] = "//color settings";
                dane[12] = this.BackColor.R.ToString();
                dane[13] = this.BackColor.G.ToString();
                dane[14] = this.BackColor.B.ToString();
                dane[15] = this.ForeColor.R.ToString();
                dane[16] = this.ForeColor.G.ToString();
                dane[17] = this.ForeColor.B.ToString();
                dane[18] = "//password settings";
                dane[19] = textBox7.Text;
                dane[20] = "//image settings";
                dane[21] = "default";
                dane[22] = unsafemode.ToString();
                dane[23] = textBox1.Font.Size.ToString();
                dane[24] = textBox3.Font.Size.ToString();
                dane[25] = textBox6.Font.Size.ToString();
                dane[26] = textBox8.Text;
                dane[27] = textBox9.Text;
                dane[28] = cmd;
                dane[29] = closeaftercmd.ToString();

                saveFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
                var dialog = DialogResult.None;

                if (patch == "dialog")
                {
                    dialog = saveFileDialog1.ShowDialog();
                }
                else
                {
                    saveFileDialog1.FileName = patch;
                    dialog = DialogResult.OK;
                }

                if (dialog == DialogResult.OK)
                {
                    Random rnd = new Random();
                    var tmp = saveFileDialog1.FileName;
                    if (pictureBox1.Image != pictureBox2.Image)
                    {
                        string[] tmp2 = tmp.Split('.');
                        pictureBox1.Image.Save(tmp2[0]+".QR");
                        dane[21] = tmp2[0] + ".QR";
                    }
                    File.WriteAllLines(saveFileDialog1.FileName, dane);

                    savepatch = saveFileDialog1.FileName;
                }
                saveFileDialog1.FileName = "";
                openFileDialog1.FileName = "";
                ToLog("Saved dir " + savepatch);
            }
            catch(Exception ex) {ToLog(ex.ToString());}
        }

        private void LoadFile(string patch)
        {

            openFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
            var dialog = DialogResult.None;

            if (patch == "dialog")
            {
                dialog = openFileDialog1.ShowDialog();
            }
            else
            {
                openFileDialog1.FileName = patch;
                dialog = DialogResult.OK;
            }

            openFileDialog1.Filter = "Save Files (.txt)|*.txt";
            openFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
            if (dialog == DialogResult.OK)
            {
                try
                {
                    dane = File.ReadAllLines(openFileDialog1.FileName);
                    textBox1.Text = dane[0];
                    textBox2.Text = dane[1];
                    textBox3.Text = dane[2];
                    textBox4.Text = dane[3];
                    textBox5.Text = dane[4];
                    textBox6.Text = dane[5];
                    textBox8.Text = dane[26];
                    textBox9.Text = dane[27];
                    dane[6] = "//timer settings";
                    cmin = Convert.ToInt32(dane[7]);
                    cmax = Convert.ToInt32(dane[8]);
                    tmin = Convert.ToInt32(dane[9]);
                    tmax = Convert.ToInt32(dane[10]);
                    dane[11] = "//color settings";
                    colorDialog1.Color = Color.FromArgb(Convert.ToInt32(dane[12]), Convert.ToInt32(dane[13]), Convert.ToInt32(dane[14]));
                    this.BackColor = colorDialog1.Color;
                    textBox1.BackColor = colorDialog1.Color;
                    textBox2.BackColor = colorDialog1.Color;
                    textBox3.BackColor = colorDialog1.Color;
                    textBox4.BackColor = colorDialog1.Color;
                    textBox5.BackColor = colorDialog1.Color;
                    textBox6.BackColor = colorDialog1.Color;
                    textBox8.BackColor = colorDialog1.Color;
                    textBox9.BackColor = colorDialog1.Color;
                    colorDialog1.Color = Color.White;
                    colorDialog1.Color = Color.FromArgb(Convert.ToInt32(dane[15]), Convert.ToInt32(dane[16]), Convert.ToInt32(dane[17]));
                    this.ForeColor = colorDialog1.Color;
                    textBox1.ForeColor = colorDialog1.Color;
                    textBox2.ForeColor = colorDialog1.Color;
                    textBox3.ForeColor = colorDialog1.Color;
                    textBox4.ForeColor = colorDialog1.Color;
                    textBox5.ForeColor = colorDialog1.Color;
                    textBox6.ForeColor = colorDialog1.Color;
                    textBox8.ForeColor = colorDialog1.Color;
                    textBox9.ForeColor = colorDialog1.Color;
                    textBox7.Text = dane[19];
                    if (dane[21] != "default")
                    {
                        pictureBox1.Image = Image.FromFile(dane[21]);
                    }

                    unsafemode = Convert.ToBoolean(dane[22]);
                    savepatch = openFileDialog1.FileName;

                    float MF = (float)Convert.ToDouble(dane[23]);
                    Font font = new Font("Microsoft JhengHei UI Light", MF);
                    textBox1.Font = font;
                    textBox8.Font = font;
                    textBox9.Font = font;
                    textBox2.Font = font;
                    label1.Font = font;
                    float QF = (float)Convert.ToDouble(dane[24]);
                    font = new Font("Microsoft JhengHei UI Light", QF);
                    textBox3.Font = font;
                    textBox4.Font = font;
                    textBox5.Font = font;
                    float EF = (float)Convert.ToDouble(dane[25]);
                    font = new Font("Microsoft YaHei UI", EF);
                    textBox6.Font = font;
                    saveFileDialog1.FileName = "";
                    openFileDialog1.FileName = "";
                    cmd = dane[28];
                    closeaftercmd = Convert.ToBoolean(dane[29]);
                }
                catch(Exception ex) {ToLog(ex.ToString());}
            }
            saveFileDialog1.FileName = "";
            openFileDialog1.FileName = "";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            LoadFile("dialog");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                textBox1.BackColor = colorDialog1.Color;
                textBox2.BackColor = colorDialog1.Color;
                textBox3.BackColor = colorDialog1.Color;
                textBox4.BackColor = colorDialog1.Color;
                textBox5.BackColor = colorDialog1.Color;
                textBox6.BackColor = colorDialog1.Color;
                            textBox8.BackColor = colorDialog1.Color;
            textBox9.BackColor = colorDialog1.Color;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.FromArgb(0, 120, 215);
            this.BackColor = colorDialog1.Color;
            textBox1.BackColor = colorDialog1.Color;
            textBox2.BackColor = colorDialog1.Color;
            textBox3.BackColor = colorDialog1.Color;
            textBox4.BackColor = colorDialog1.Color;
            textBox5.BackColor = colorDialog1.Color;
            textBox6.BackColor = colorDialog1.Color;
            textBox8.BackColor = colorDialog1.Color;
            textBox9.BackColor = colorDialog1.Color;
        }

        private void BSOD_EDIT_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (password_in.Text != textBox7.Text&&timer2.Enabled&&unsafemode) e.Cancel = true;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files|*.*";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try { pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); } catch(Exception ex) {ToLog(ex.ToString());}
            }
            saveFileDialog1.FileName = "";
            openFileDialog1.FileName = "";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = colorDialog1.Color;
                textBox1.ForeColor = colorDialog1.Color;
                textBox2.ForeColor = colorDialog1.Color;
                textBox3.ForeColor = colorDialog1.Color;
                textBox4.ForeColor = colorDialog1.Color;
                textBox5.ForeColor = colorDialog1.Color;
                textBox6.ForeColor = colorDialog1.Color;
                textBox8.ForeColor = colorDialog1.Color;
                textBox9.ForeColor = colorDialog1.Color;
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.White;
            this.ForeColor = colorDialog1.Color;
            textBox1.ForeColor = colorDialog1.Color;
            textBox2.ForeColor = colorDialog1.Color;
            textBox3.ForeColor = colorDialog1.Color;
            textBox4.ForeColor = colorDialog1.Color;
            textBox5.ForeColor = colorDialog1.Color;
            textBox6.ForeColor = colorDialog1.Color;
            textBox8.ForeColor = colorDialog1.Color;
            textBox9.ForeColor = colorDialog1.Color;
            label1.ForeColor = colorDialog1.Color;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(0,cmin,cmax,tmin,tmax);
            if(settings.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cmin = Convert.ToInt32(settings.cmin.Value);
                    tmin = Convert.ToInt32(settings.tmin.Value);
                    cmax = Convert.ToInt32(settings.cmax.Value);
                    tmax = Convert.ToInt32(settings.tmax.Value);
                }
                catch(Exception ex) {ToLog(ex.ToString());}
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(1,unsafemode,!label1.Visible,!pictureBox1.Visible,savepatch,textBox1.Font.Size, textBox3.Font.Size, textBox6.Font.Size,cmd,closeaftercmd);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                unsafemode = settings.unsmode.Checked;
                float MF = (float)settings.MFont.Value;
                Font font = new Font("Microsoft JhengHei UI Light", MF);
                textBox1.Font = font;
                textBox2.Font = font;
                textBox8.Font = font;
                textBox9.Font = font;
                label1.Font = font;
                float QF = (float)settings.QRFont.Value;
                font = new Font("Microsoft JhengHei UI Light", QF);
                textBox3.Font = font;
                textBox4.Font = font;
                textBox5.Font = font;
                float EF = (float)settings.EFont.Value;
                font = new Font("Microsoft YaHei UI", EF);
                textBox6.Font = font;
                cmd = settings.textBox1.Text;
                closeaftercmd = settings.checkBox1.Checked;
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            timer3.Stop();
        }
    }
}
