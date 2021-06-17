using ControlManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace BlueScreen_Simulator
{
    public partial class BSOD_EDIT : Form
    {
        string savepatch = "not saved";
        readonly string[] args = new string[100];
        bool preview = false;
        Size thissize;
        public SizeF scalefactor;
        public ContextMenuStrip strip;

        public BSOD_EDIT()
        {
            InitializeComponent();
            strip = contextMenuStrip1;
            BSODData.form = this;
            thissize = this.Size;
            ThisScale();
            InitDefault();
            
            ToLog("----NEW-RUN----");
            
            args = Environment.GetCommandLineArgs();
            ToLog(string.Join(" ", args));
            try
            {
                var txt = File.ReadAllText(Application.ExecutablePath);
                if (txt.Contains("{BSOD-Save}")) { LoadFile(Application.ExecutablePath); BSOD_Start(); }
            }
            catch { }
            CursorShown = true;
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

                            BSOD_Start();
                        }
                        catch (Exception ex) { this.Close(); ToLog(ex.ToString()); }
                    }
                }
            }
            catch (Exception ex) { ToLog(ex.ToString()); }
        }

        private void InitDefault()
        {
            BSODData.Clear();
            addTextBox(new Point(124, 250), new Size(1000, 124), "Your PC ran into a problem and needs to restart.We\'re\njust collecting some error info, and then we\'ll restart for\nyou", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))));
            addTextBox(new Point(124, 69), new Size(1000, 170), ":(", this.contextMenuStrip1, new System.Drawing.Font("Microsoft YaHei UI", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2))));
            addTextBox(new Point(201, 475), new Size(1000, 16), "If you call a support person, give them this info:", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            addTextBox(new Point(201, 436), new Size(1000, 33), "For more information about this issue and possible fixes, visit https://windows.com/stopcode", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            addTextBox(new Point(124, 380), new Size(441, 33), "{p}% complete", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 18F));
            addTextBox(new Point(201, 497), new Size(1000, 137), "Stop code: CRITICAL PROCESS DIED", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            addImageBox(new Point(117, 436), new Size(88, 75));
            BSODData.Apply();
        }

        private void InitDemo()
        {
            BSODData.Clear();
            addTextBox(new Point(124, 200), new Size(1000, 154), "{p}         - %                                            {width}       - width of this screen\n{pass}    - password                                 {height}      - height of this screen\n{cmd}     - command to run 100%           {tmin} {tmax} {cmin} {cmax} - percent step time and count\n{scale-x} - scale width on this screen        {unsmode} - is unsafemode checked (settings)\n{scale-y} - scale height on this screen      {closecmd} - is close after execution checked (settings)", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))));
            addTextBox(new Point(124, 69), new Size(1000, 170), ":DEMO:", this.contextMenuStrip1, new System.Drawing.Font("Microsoft YaHei UI", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2))));
            addTextBox(new Point(201, 475), new Size(1000, 16), "If you call a support person, give them this info:", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            addTextBox(new Point(201, 436), new Size(1000, 33), "&11 &22 &33 &44 &55 &66 &77 &88 &99 &00 &aa &bb &cc &dd &ee &ff", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            addTextBox(new Point(124, 380), new Size(441, 33), "CLICK PREVIEW TO SEE", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 18F));
            addTextBox(new Point(201, 497), new Size(1000, 137), "Stop code: CRITICAL PROCESS DIED", this.contextMenuStrip1, new System.Drawing.Font("Microsoft JhengHei UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            addImageBox(new Point(117, 436), new Size(88, 75));
            BSODData.Apply();
        }

        private void addTextBox(Point location, Size size, String text, ContextMenuStrip strip, Font f = null)
        {
            var label = new BSODLabel(location, size, text, f);
        }
        private void addImageBox(Point location, Size size)
        {
            var bp = new BSODImage(location, size);
        }

        public static RichTextBox createTextBox(Point location, Size size, String text, ContextMenuStrip strip, Font f = null)
        {
            if (f == null)
            {
                f = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
            var txt_2 = new RichTextBox();
            txt_2.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            txt_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt_2.ContextMenuStrip = strip;
            txt_2.DetectUrls = false;
            txt_2.Font = f;
            txt_2.ForeColor = Color.WhiteSmoke;
            txt_2.Location = location;
            txt_2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            txt_2.Size = size;
            txt_2.TabIndex = 1;
            txt_2.Text = text;
            return txt_2;
        }

        private bool _CursorShown = true;
        public bool CursorShown
        {
            get
            {
                return _CursorShown;
            }
            set
            {
                if (value == _CursorShown)
                {
                    return;
                }

                if (value)
                {
                    System.Windows.Forms.Cursor.Show();
                }
                else
                {
                    System.Windows.Forms.Cursor.Hide();
                }

                _CursorShown = value;
            }
        }
        public void RunCmd(string command)
        {
            Process Process1 = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {BSODData.data.cmd.Replace("\n", "&")}");
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process1.StartInfo = startInfo;
            try { Process1.Start(); } catch { }
        }

        private void ToLog(string log)
        {

        }

        int pr = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            pr += rnd.Next(BSODData.data.cmin, BSODData.data.cmax);
            if (pr >= 100) { pr = 100; RunCmd(BSODData.data.cmd); Perc_Timer.Stop(); if (BSODData.data.closeAfterCmd) { password_in.Text = txt_password.Text; this.Close(); } }
            Perc_Timer.Interval = rnd.Next(BSODData.data.tmin, BSODData.data.tmax);

        }

        private void BSOD_Start(object sender, EventArgs e)
        {
            BSOD_Start();
        }
        public void BSOD_Start()
        {
            BSODLabel.FormatAll();

            ToLog("BSOD START");
            btn_start.Visible = false;
            btn_preview.Visible = false;
            Perc_Timer.Start();
            BSOD_Timer.Start();
            lbl_password.Visible = false;
            txt_password.Visible = false;
            BSODLabel.SaveOldTxts();
            FormatTexts();
            //ThisScale();
        }
        private void ThisScale()
        {
            this.WindowState = FormWindowState.Maximized;
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            float tmp = bounds.Width;
            float tmp2 = bounds.Height;
            float tmp3 = thissize.Width;
            float tmp4 = thissize.Height;
            tmp = tmp / tmp3;
            tmp2 = tmp2 / tmp4;
            SizeF sizeF = new SizeF(tmp, tmp2);
            scalefactor = sizeF;

            txt_password.Scale(sizeF);

            lbl_password.Scale(sizeF);

            btn_start.Scale(sizeF);
            btn_preview.Scale(sizeF);

            ToLog("Scaling factor " + tmp + " " + tmp2 + " (" + Screen.GetBounds(Point.Empty).Size + "/" + thissize);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (password_in.Text.Contains(txt_password.Text))
            {

                btn_start.Visible = true;
                btn_preview.Visible = true;
                Perc_Timer.Stop();
                BSOD_Timer.Stop();
                BSODLabel.UndoAll();
                lbl_password.Visible = true;
                txt_password.Visible = true;

                pr = 0;
                CursorShown = true;
                this.TopMost = false;
                this.Select();
                password_in.Text = "";
            }
            else
            {
                password_in.Select();
                CursorShown = false;
                this.TopMost = true;
                FormatTexts();
            }
        }

        public void FormatTexts()
        {
            BSODLabel.UndoAll();

            BSODLabel.FormatVarAll("p", pr);
            BSODLabel.FormatVarAll("pass", txt_password.Text);
            BSODLabel.FormatVarAll("cmd", BSODData.data.cmd);
            BSODLabel.FormatVarAll("scale-x", scalefactor.Width);
            BSODLabel.FormatVarAll("scale-y", scalefactor.Height);
            BSODLabel.FormatVarAll("width", Bounds.Width);
            BSODLabel.FormatVarAll("height", Bounds.Height);
            BSODLabel.FormatVarAll("tmin", BSODData.data.tmin);
            BSODLabel.FormatVarAll("tmax", BSODData.data.tmax);
            BSODLabel.FormatVarAll("cmin", BSODData.data.cmin);
            BSODLabel.FormatVarAll("cmax", BSODData.data.cmax);
            BSODLabel.FormatVarAll("unsmode", BSODData.data.unsafeMode);
            BSODLabel.FormatVarAll("closecmd", BSODData.data.closeAfterCmd);

            BSODLabel.FormatAll();

        }

        private void SaveFile(string path)
        {
            try
            {


                saveFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
                var dialog = DialogResult.None;

                if (path == "dialog")
                {
                    dialog = saveFileDialog1.ShowDialog();
                }
                else
                {
                    saveFileDialog1.FileName = path;
                    dialog = DialogResult.OK;
                }

                if (dialog == DialogResult.OK)
                {
                    var dane = BSODData.Serialize();
                    if (saveFileDialog1.FileName.EndsWith(".exe"))
                    {
                        CloneExeWithSave(saveFileDialog1.FileName, dane);
                    }
                    else
                    {
                        SaveSave(saveFileDialog1.FileName, dane);
                    }

                    //File.WriteAllLines(saveFileDialog1.FileName, dane);

                    savepatch = saveFileDialog1.FileName;
                }
                saveFileDialog1.FileName = "";
                openFileDialog1.FileName = "";
                ToLog("Saved dir " + savepatch);
            }
            catch (Exception ex) { ToLog(ex.ToString()); }
        }

        private void LoadFile(string path)
        {

            openFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
            var dialog = DialogResult.None;

            if (path == "dialog")
            {
                dialog = openFileDialog1.ShowDialog();
            }
            else
            {
                openFileDialog1.FileName = path;
                dialog = DialogResult.OK;
            }

            openFileDialog1.Filter = "Binary (.exe)|*.exe|BSOD save file|*.bsod";
            openFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
            if (dialog == DialogResult.OK)
            {
                try
                {
                    var fileContent = File.OpenRead(openFileDialog1.FileName);
                    var target = System.Text.Encoding.ASCII.GetBytes("{#BSOD#-#Save#}".Replace("#", ""));
                    var pos = Utils.FindPosition(fileContent, target);
                    fileContent.Close();
                    fileContent = File.OpenRead(openFileDialog1.FileName);
                    fileContent.Position = pos + 11;
                    BSODData.Deserialize(Utils.ReadToEnd(fileContent, false));
                    fileContent.Close();
                }
                catch (Exception ex) { ToLog(ex.ToString()); }
            }
            saveFileDialog1.FileName = "";
            openFileDialog1.FileName = "";
        }
        private void CloneExeWithSave(string path, byte[] dane)
        {
            if (File.Exists(path))
                File.Delete(path);
            var exec = File.ReadAllBytes(Application.ExecutablePath);
            var stream = File.OpenWrite(path);
            stream.Write(exec, 0, exec.Length);
            stream.Write(System.Text.Encoding.ASCII.GetBytes("{#BSOD#-#Save#}".Replace("#", "")), 0, 11);
            stream.Write(dane, 0, dane.Length);
            stream.Flush();
            stream.Close();
        }
        private void SaveSave(string path, byte[] dane)
        {
            if (File.Exists(path))
                File.Delete(path);
            var stream = File.OpenWrite(path);
            stream.Write(System.Text.Encoding.ASCII.GetBytes("{#BSOD#-#Save#}".Replace("#", "")), 0, 11);
            stream.Write(dane, 0, dane.Length);
            stream.Flush();
            stream.Close();
        }
        private string[] ReadExeWithSave(string patch)
        {
            List<string> data = new List<string>();
            data = File.ReadAllLines(patch).ToList();
            List<string> newdata = new List<string>();
            newdata.AddRange(data);
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] != @"======[SAVE]======")
                {
                    newdata.RemoveAt(0);
                }
                else { newdata.RemoveAt(0); break; }
            }
            return newdata.ToArray();
        }

        private void BSOD_EDIT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (password_in.Text != txt_password.Text && BSOD_Timer.Enabled && BSODData.data.unsafeMode) e.Cancel = true;
            if (preview) e.Cancel = true;
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile("dialog");
        }

        private void lOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile("dialog");
        }

        private void cHANGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                changeBColor(colorDialog1.Color);
            }
        }

        public void changeBColor(Color c)
        {
            colorDialog1.Color = c;
            this.BackColor = colorDialog1.Color;
            BSODLabel.changeBackColorAll(colorDialog1.Color);
            btn_start.BackColor = colorDialog1.Color;
            btn_preview.BackColor = colorDialog1.Color;
        }

        private void rESETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeBColor(Color.FromArgb(0, 120, 215));
        }

        private void sETTINGSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(BSODData.data, savepatch);
            settings.ShowDialog();
        }
        Control _sc = null;
        private void cHANGEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _sc.ForeColor = colorDialog1.Color;
            }
        }

        private void rESETToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.White;
            _sc.ForeColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            preview = !preview;
            btn_start.Enabled = !preview;
            txt_password.Enabled = !preview;
            if (preview)
            {
                btn_preview.BackColor = Color.Green;
                BSODLabel.SaveOldTxts();
                FormatTexts();
            }
            else
            {
                btn_preview.BackColor = this.BackColor;
                BSODLabel.UndoAll();
            }
        }

        private void rESETToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            InitDefault();
        }

        private void lOADDEMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDemo();
        }

        public bool editing = false;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToggleDesignMode();
        }

        public void ToggleDesignMode()
        {
            editing = !editing;
            toolStripMenuItem1.Checked = editing;
            if (editing)
            {
                foreach (var item in BSODData.data.labels)
                {
                    ControlMoverOrResizer.Init(item.textBox);
                    item.textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                foreach (var item in BSODData.data.images)
                {
                    ControlMoverOrResizer.Init(item.pb);
                    item.pb.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            if (!editing)
            {
                foreach (var item in BSODData.data.labels)
                {
                    ControlMoverOrResizer.Unload(item.textBox);
                    item.textBox.Cursor = Cursors.IBeam;
                    item.textBox.BorderStyle = BorderStyle.None;
                }
                foreach (var item in BSODData.data.images)
                {
                    ControlMoverOrResizer.Unload(item.pb);
                    item.pb.BorderStyle = BorderStyle.None;
                }
                this.CreateGraphics().Clear(this.BackColor);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (BSOD_Timer.Enabled || preview) e.Cancel = true;
        }
        Control _sourceControl = null;
        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            _sourceControl = contextMenuStrip1.SourceControl;
            lABELToolStripMenuItem1.Visible = false;
            iMAGEToolStripMenuItem1.Visible = false;
            iTEMToolStripMenuItem.Visible = false;
            foreach (var item in BSODData.data.labels)
            {
                if (item.textBox == _sourceControl)
                {
                    lABELToolStripMenuItem1.Visible = true;
                    iTEMToolStripMenuItem.Visible = true;
                }
            }
            foreach (var item in BSODData.data.images)
            {
                if (item.pb == _sourceControl)
                {
                    iMAGEToolStripMenuItem1.Visible = true;
                    iTEMToolStripMenuItem.Visible = true;
                }
            }
        }

        private void win7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile("win7.txt{resource/txt/prop}");
        }

        private void lABELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTextBox(new Point(0, 0), new Size(100, 100), "Label", this.contextMenuStrip1);
            if (editing)
            {
                ToggleDesignMode();
                ToggleDesignMode();
            }
        }

        private void iMAGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addImageBox(new Point(0, 0), new Size(100, 100));
            if (editing)
            {
                ToggleDesignMode();
                ToggleDesignMode();
            }
        }

        private void rEMOVEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (var item in BSODData.data.labels)
            {
                if (item.textBox == _sourceControl)
                {
                    BSODData.data.labels.Remove(item);
                    break;
                }
            }
            foreach (var item in BSODData.data.images)
            {
                if (item.pb == _sourceControl)
                {
                    BSODData.data.images.Remove(item);
                    break;
                }
            }
            _sourceControl.Dispose();

        }

        private void dEFAULTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((PictureBox)_sourceControl).Image = BlueScreen_Simulator.Properties.Resources.QR;
        }

        private void cHANGEToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try { ((PictureBox)_sourceControl).Image = Image.FromFile(openFileDialog1.FileName); } catch (Exception ex) { ToLog(ex.ToString()); }
            }
            saveFileDialog1.FileName = "";
            openFileDialog1.FileName = "";
        }

        private void cHANGEFONTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = _sourceControl.Font;
            var dialog = fontDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                _sourceControl.Font = fontDialog1.Font;
            }
        }

        private void cHANGECOLORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _sourceControl.ForeColor;
            var dialog = colorDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                _sourceControl.ForeColor = colorDialog1.Color;
            }
        }

        public bool BSODActive()
        {
            return BSOD_Timer.Enabled||preview;
        }

        internal void updateElements()
        {
            txt_password.Text = BSODData.data.password;
        }

        private void mOVETOFRONTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in BSODData.data.labels)
            {
                if (item.textBox == _sourceControl)
                {
                    var tmp = BSODData.data.labels[0];
                    BSODData.data.labels.Remove(item);
                    BSODData.data.labels.Add(tmp);
                    BSODData.data.labels[0] = item;
                    break;
                }
            }
            foreach (var item in BSODData.data.images)
            {
                if (item.pb == _sourceControl)
                {
                    var tmp = BSODData.data.images[0];
                    BSODData.data.images.Remove(item);
                    BSODData.data.images.Add(tmp);
                    BSODData.data.images[0] = item;
                    break;
                }
            }
            _sourceControl.BringToFront();
        }

        private void mOVETOBACKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in BSODData.data.labels)
            {
                if (item.textBox == _sourceControl)
                {
                    BSODData.data.labels.Remove(item);
                    BSODData.data.labels.Add(item);
                    break;
                }
            }
            foreach (var item in BSODData.data.images)
            {
                if (item.pb == _sourceControl)
                {
                    BSODData.data.images.Remove(item);
                    BSODData.data.images.Add(item);
                    break;
                }
            }
            _sourceControl.SendToBack();
        }

        private void rELOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BSODData.SyncSettings();
            BSODData.Clean();
            BSODData.Apply();
        }
    }
    [Serializable]
    public class BSODImage
    {
        [NonSerialized]
        public PictureBox pb;
        Image image;
        public Point location;
        public Size size;
        public BSODImage(Point location, Size size, Image img = null)
        {
            image = img;
            this.location = location;
            this.size = size;
            BSODData.data.images.Add(this);
            CreatePictureBox();
        }
        public void CreatePictureBox()
        {
            pb = new PictureBox();
            if (image == null)
            {
                image = BlueScreen_Simulator.Properties.Resources.QR;
            }
            pb.Image = image;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Location = location;
            pb.Size = size;
            BSODData.form.Controls.Add(pb);
            pb.Show();
        }
        public void SyncSettings()
        {
            var scaleFactor = BSODData.form.scalefactor;
            pb.Scale(new SizeF(1 / scaleFactor.Width, 1 / scaleFactor.Height));
            image = pb.Image;
            location = pb.Location;
            size = pb.Size;
            pb.Scale(scaleFactor);
        }
    }
    [Serializable]
    public class BSODLabel
    {
        [NonSerialized]
        public RichTextBox textBox;
        public string oldTxt;
        public Point location;
        public Size size;
        public String text;
        public Font f = null;
        Color foreColor = Color.WhiteSmoke;

        public BSODLabel(Point location, Size size, String text, Font f = null)
        {
            if (f == null)
            {
                f = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
            this.location = location;
            this.size = size;
            this.text = text;
            this.f = f;
            BSODData.data.labels.Add(this);
            CreateTextBox();
        }

        public void CreateTextBox()
        {
            textBox = new RichTextBox();
            textBox.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox.ContextMenuStrip = BSODData.form.strip;
            textBox.DetectUrls = false;
            textBox.Font = f;
            textBox.ForeColor = foreColor;
            textBox.Location = location;
            textBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            textBox.Size = size;
            textBox.TabIndex = 1;
            textBox.Text = text;
            BSODData.form.Controls.Add(textBox);
            textBox.Show();

            textBox.Enter += TextBox_Enter;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (BSODData.form.BSODActive())
            {
                BSODData.form.ActiveControl = null;
            }
        }

        public void SyncSettings()
        {
            var scaleFactor = BSODData.form.scalefactor;
            textBox.Scale(new SizeF(1 / scaleFactor.Width, 1 / scaleFactor.Height));
            location = textBox.Location;
            size = textBox.Size;
            text = textBox.Text;
            foreColor = textBox.ForeColor;
            f = textBox.Font;
            textBox.Scale(scaleFactor);
        }

        public void Format()
        {
            this.textBox.FormatTxt();
            this.textBox.ReadOnly = true;
        }

        public void FormatVar(string var, string val)
        {
            this.textBox.FormatVar(var, val);
        }

        public void Undo()
        {
            this.textBox.Text = this.oldTxt;
            this.textBox.ReadOnly = false;
            this.textBox.SelectAll(); this.textBox.SelectionColor = Color.WhiteSmoke;
        }

        public static void FormatAll()
        {
            foreach (var item in BSODData.data.labels)
            {
                item.Format();
            }
        }

        public static void FormatVarAll(string var, string val)
        {
            foreach (var item in BSODData.data.labels)
            {
                item.FormatVar(var, val);
            }
        }
        public static void FormatVarAll(string var, object val)
        {
            FormatVarAll(var, val.ToString());
        }

        public static void UndoAll()
        {
            foreach (var item in BSODData.data.labels)
            {
                item.Undo();
            }
        }

        public static void changeBackColorAll(Color c)
        {
            foreach (var item in BSODData.data.labels)
            {
                item.textBox.BackColor = c;
            }

        }

        public static void SaveOldTxts()
        {
            foreach (var item in BSODData.data.labels)
            {
                item.oldTxt = item.textBox.Text;
            }
        }
    }
    public static class BSODData
    {
        public static BSOD_EDIT form;
        [Serializable]
        public class Data
        {
            public List<BSODLabel> labels = new List<BSODLabel>();
            public List<BSODImage> images = new List<BSODImage>();

            public int cmin = 1, cmax = 8, tmin = 1000, tmax = 3500;
            public Color bc = Color.FromArgb(0, 120, 215);
            public string password = "1234", cmd = "";
            public bool unsafeMode=true, closeAfterCmd;
        }
        public static Data data = new Data();
        public static byte[] Serialize()
        {
            SyncSettings();

            Stream s = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, data);
            s.Position = 0;
            return Utils.ReadToEnd(s);
        }
        public static void Deserialize(byte[] data)
        {
            Stream s = new MemoryStream();
            s.Write(data, 0, data.Length);
            s.Position = 0;
            BinaryFormatter b = new BinaryFormatter();
            Clear();
            BSODData.data = (Data)b.Deserialize(s);
            Apply();
            s.Close();
        }

        internal static void SyncSettings()
        {
            foreach (var item in data.images)
            {
                item.SyncSettings();
            }
            foreach (var item in data.labels)
            {
                item.SyncSettings();
            }
            data.password = form.txt_password.Text;
            data.bc = form.BackColor;
        }

        public static void Apply()
        {
            Clean();
            foreach (var item in data.labels)
            {
                item.CreateTextBox();
                item.textBox.Scale(BSODData.form.scalefactor);
            }
            foreach (var item in data.images)
            {
                item.CreatePictureBox();
                item.pb.Scale(BSODData.form.scalefactor);
            }
            form.changeBColor(data.bc);
            form.updateElements();
        }
        public static void Clean()
        {
            foreach (var item in data.labels)
            {
                if (item.textBox != null)
                    item.textBox.Dispose();
            }
            foreach (var item in data.images)
            {
                if (item.pb != null)
                    item.pb.Dispose();
            }
        }
        public static void Clear()
        {
            foreach (var item in data.labels)
            {
                if (item.textBox != null)
                    item.textBox.Dispose();
            }
            foreach (var item in data.images)
            {
                if (item.pb != null)
                    item.pb.Dispose();
            }
            data.labels.Clear();
            data.images.Clear();
            data = new Data();
        }
    }

    public static class Utils
    {
        public static byte[] ReadToEnd(System.IO.Stream stream, bool resetPos = true)
        {
            long originalPosition = 0;

            if (stream.CanSeek && resetPos)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        public static long FindPosition(Stream stream, byte[] byteSequence)
        {
            if (byteSequence.Length > stream.Length)
                return -1;

            byte[] buffer = new byte[byteSequence.Length];

            using (BufferedStream bufStream = new BufferedStream(stream, byteSequence.Length))
            {
                int i;
                while ((i = bufStream.Read(buffer, 0, byteSequence.Length)) == byteSequence.Length)
                {
                    if (byteSequence.SequenceEqual(buffer))
                        return bufStream.Position - byteSequence.Length;
                    else
                        bufStream.Position -= byteSequence.Length - PadLeftSequence(buffer, byteSequence);
                }
            }

            return -1;
        }
        private static int PadLeftSequence(byte[] bytes, byte[] seqBytes)
        {
            int i = 1;
            while (i < bytes.Length)
            {
                int n = bytes.Length - i;
                byte[] aux1 = new byte[n];
                byte[] aux2 = new byte[n];
                Array.Copy(bytes, i, aux1, 0, n);
                Array.Copy(seqBytes, aux2, n);
                if (aux1.SequenceEqual(aux2))
                    return i;
                i++;
            }
            return i;
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        public static void FormatTxt(this RichTextBox r)
        {
            r.SelectAll();
            r.SelectionColor = Color.WhiteSmoke;
            Color DecodeCode(char code)
            {
                Color color = Color.White;
                switch (code)
                {
                    case '0': color = Color.Black; break;
                    case '1': color = Color.DarkBlue; break;
                    case '2': color = Color.DarkGreen; break;
                    case '3': color = Color.DarkCyan; break;
                    case '4': color = Color.DarkRed; break;
                    case '5': color = Color.DarkMagenta; break;
                    case '6': color = Color.Gold; break;
                    case '7': color = Color.Gray; break;
                    case '8': color = Color.DarkGray; break;
                    case '9': color = Color.Blue; break;

                    case 'a': color = Color.Green; break;
                    case 'b': color = Color.Cyan; break;
                    case 'c': color = Color.Red; break;
                    case 'd': color = Color.Magenta; break;
                    case 'e': color = Color.Yellow; break;
                    case 'f': color = Color.White; break;
                }
                return color;
            }
            void WriteTxt(string txt)
            {
                txt += "    ";
                Color c = DecodeCode('f');
                string codes = "0123456789abcdef";
                for (int i = 0; i < txt.Length; i++)
                {
                    if (i >= 0 && txt[i] == '@' && txt[i + 1] == '&' && codes.Contains(txt[i + 2]))
                    {
                        c = DecodeCode(txt[i + 2]);
                        txt = txt.Remove(i + 2, 1);
                        txt = txt.Remove(i + 1, 1);
                        txt = txt.Remove(i, 1);
                    }
                    if (txt.Length - 1 > i + 1 && txt[i] == '&' && codes.Contains(txt[i + 1]))
                    {
                        if (i - 1 >= 0 && txt[i - 1] == @"\"[0])
                        {
                            if (i < txt.Length - 4)
                            {
                                AppChar(txt[i], c);
                            }
                        }
                        else { c = DecodeCode(txt[i + 1]); txt = txt.Remove(i + 1, 1); }
                    }
                    else { bool tmp = (i < txt.Length - 4); if (txt[i] == '@' && txt[i + 1] == '&') tmp = false; if (txt[i] == '&' && codes.Contains(txt[i + 1])) tmp = false; if (txt[i] == @"\"[0] && txt[i + 1] == '&' && codes.Contains(txt[i + 2])) tmp = false; if (tmp) { AppChar(txt[i], c); } }

                }
                c = Color.White;
            }
            void AppChar(char c, Color c2)
            {
                //int selectStart = r.SelectionStart;
                //r.Text += (c);
                //r.SelectionColor = c2;
                //r.Select(r.Text.Length - 1, 1); 
                //r.SelectionColor = c2;
                //r.Select(selectStart, 0);
                //r.SelectionColor = ForeColor;
                r.AppendText(c.ToString(), c2);
            }
            string tmptxt = r.Text;
            r.Text = "";
            WriteTxt(tmptxt);

        }
        public static void FormatTxtNORemoveCodes(this RichTextBox r)
        {
            r.SelectAll();
            r.SelectionColor = Color.WhiteSmoke;
            Color DecodeCode(char code)
            {
                Color color = Color.White;
                switch (code)
                {
                    case '0': color = Color.Black; break;
                    case '1': color = Color.DarkBlue; break;
                    case '2': color = Color.DarkGreen; break;
                    case '3': color = Color.DarkCyan; break;
                    case '4': color = Color.DarkRed; break;
                    case '5': color = Color.DarkMagenta; break;
                    case '6': color = Color.Gold; break;
                    case '7': color = Color.Gray; break;
                    case '8': color = Color.DarkGray; break;
                    case '9': color = Color.Blue; break;

                    case 'a': color = Color.Green; break;
                    case 'b': color = Color.Cyan; break;
                    case 'c': color = Color.Red; break;
                    case 'd': color = Color.Magenta; break;
                    case 'e': color = Color.Yellow; break;
                    case 'f': color = Color.White; break;
                }
                return color;
            }
            void WriteTxt(string txt)
            {
                txt += "    ";
                Color c = DecodeCode('f');
                string codes = "0123456789abcdef";
                for (int i = 0; i < txt.Length; i++)
                {
                    if (i >= 0 && txt[i] == '@' && txt[i + 1] == '&' && codes.Contains(txt[i + 2]))
                    {
                        c = DecodeCode(txt[i + 2]);
                    }
                    if (txt.Length - 1 > i + 1 && txt[i] == '&' && codes.Contains(txt[i + 1]))
                    {
                        if (i - 1 >= 0 && txt[i - 1] == @"\"[0])
                        {
                            if (i < txt.Length - 4)
                            {
                                AppChar(txt[i], c);
                            }
                        }
                        else { c = DecodeCode(txt[i + 1]); txt = txt.Remove(i + 1, 1); }
                    }
                    else { bool tmp = (i < txt.Length - 4); if (tmp) { AppChar(txt[i], c); } }

                }
                c = Color.White;
            }
            void AppChar(char c, Color c2)
            {
                //int selectStart = r.SelectionStart;
                //r.Text += (c);
                //r.SelectionColor = c2;
                //r.Select(r.Text.Length - 1, 1); 
                //r.SelectionColor = c2;
                //r.Select(selectStart, 0);
                //r.SelectionColor = ForeColor;
                r.AppendText(c.ToString(), c2);
            }
            string tmptxt = r.Text;
            r.Text = "";
            WriteTxt(tmptxt);

        }
        public static void FormatVar(this RichTextBox r, string var, object value)
        {
            string vl = value.ToString();
            var = "{" + var + "}";
            string txt = r.Text.Replace(var, vl);
            r.Text = txt;
        }
    }
}
