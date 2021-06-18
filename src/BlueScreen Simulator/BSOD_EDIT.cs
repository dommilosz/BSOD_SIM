using ControlManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace BlueScreen_Simulator
{
    public partial class BSOD_EDIT : Form
    {
        string savepatch = "not saved";
        public readonly List<string> args = new List<string>();
        bool preview = false;
        Size thissize;
        public SizeF scalefactor;
        public ContextMenuStrip strip;
        public static string SaveSequence = "{##BSOD##-##Save##}".Replace("#", "");
        public static string TemplateSequence = "{##BSOD##-##Template##}".Replace("#", "");
        public static byte[] SaveSequenceB = Encoding.ASCII.GetBytes(SaveSequence);
        public static byte[] TemplateSequenceB = Encoding.ASCII.GetBytes(TemplateSequence);

        public BSOD_EDIT()
        {
            InitializeComponent();
            strip = contextMenuStrip1;
            BSODData.form = this;
            thissize = this.Size;
            ThisScale();
            InitResourceSave("win10");

            ToLog("----NEW-RUN----");

            nbx_posX.Minimum = int.MinValue;
            nbx_posX.Maximum = int.MaxValue;

            nbx_posY.Minimum = int.MinValue;
            nbx_posY.Maximum = int.MaxValue;

            nbx_sizeH.Maximum = int.MaxValue;
            nbx_sizeW.Maximum = int.MaxValue;

            args = Environment.GetCommandLineArgs().ToList();
            ToLog(string.Join(" ", args));
            try
            {
                var txt = File.ReadAllText(Application.ExecutablePath);
                if (txt.Contains(SaveSequence))
                {
                    LoadFile(Application.ExecutablePath, true); if (BSODData.data.AutoStart)
                        BSOD_Start();
                }
            }
            catch { }
            CursorShown = true;
            try
            {
                if (args.Count > 1)
                {
                    try
                    {
                        var tmpvar = args.ToArray().ToList();
                        tmpvar.RemoveAt(0);
                        ToLog(string.Join(" ", tmpvar).TrimStart(' '));
                        LoadFile(string.Join(" ", tmpvar).TrimStart(' '));
                        if (BSODData.data.AutoStart)
                            BSOD_Start();
                    }
                    catch (Exception ex) { this.Close(); ToLog(ex.ToString()); }
                }
            }
            catch (Exception ex) { ToLog(ex.ToString()); }


            templatesToolStripMenuItem.DropDownItems.Clear();
            foreach (PropertyInfo property in typeof(Properties.Resources).GetProperties
    (BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            {
                try
                {
                    var data = (byte[])Properties.Resources.ResourceManager.GetObject(property.Name);
                    if (Utils.FindPosition(new MemoryStream(data), TemplateSequenceB) >= 0)
                    {
                        var item = new ToolStripMenuItem(property.Name);
                        item.Click += Item_Click;
                        templatesToolStripMenuItem.DropDownItems.Add(item);
                    }
                }
                catch { }
            }
        }

        private void InitResourceSave(string name)
        {
            BSODData.LoadData((byte[])Properties.Resources.ResourceManager.GetObject(name), "template");
        }

        private void addTextBox(Point location, Size size, String text, Font f = null)
        {
            var label = new BSODLabel(location, size, text, f);
        }
        private void addImageBox(Point location, Size size)
        {
            var bp = new BSODImage(location, size);
        }
        private void addPanel(Point location, Size size, Color c)
        {
            var bp = new BSODPanel(location, size, c);
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
            //File.AppendAllText("log.log", log + "\n");
        }

        int pr = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            pr += rnd.Next(BSODData.data.cmin, BSODData.data.cmax);
            if (pr >= 100) { pr = 100; RunCmd(BSODData.data.cmd); Perc_Timer.Stop(); if (BSODData.data.closeAfterCmd) { password_in.Text = BSODData.data.password; this.Close(); } }
            Perc_Timer.Interval = rnd.Next(BSODData.data.tmin, BSODData.data.tmax);

        }

        private void BSOD_Start(object sender, EventArgs e)
        {
            BSOD_Start();
        }
        public void BSOD_Start()
        {
            BSODData.HideHidden(true);
            BSODLabel.FormatAll();

            ToLog("BSOD START");
            btn_start.Visible = false;
            btn_preview.Visible = false;
            btn_settings.Visible = false;
            Perc_Timer.Start();
            BSOD_Timer.Start();
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

            btn_start.Scale(sizeF);
            btn_preview.Scale(sizeF);
            btn_settings.Scale(sizeF);
            design_helper.Scale(sizeF);

            ToLog("Scaling factor " + tmp + " " + tmp2 + " (" + Screen.GetBounds(Point.Empty).Size + "/" + thissize);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (password_in.Text.Contains(BSODData.data.password))
            {

                btn_start.Visible = true;
                btn_preview.Visible = true;
                btn_settings.Visible = true;
                Perc_Timer.Stop();
                BSOD_Timer.Stop();
                BSODLabel.UndoAll();
                BSODData.HideHidden(false);

                pr = 0;
                CursorShown = true;
                this.TopMost = false;
                this.Select();
                password_in.Text = "";
            }
            else
            {
                password_in.Select();
                if (BSODData.data.hideCursor)
                {
                    CursorShown = false;
                }

                this.TopMost = true;
                FormatTexts();
            }
        }

        public void FormatTexts()
        {
            BSODLabel.UndoAll();

            BSODLabel.FormatVarAll("p", pr);
            BSODLabel.FormatVarAll("pass", BSODData.data.password);
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

        private void LoadFile(string path, bool autorun = false)
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
                var fileContent = File.OpenRead(openFileDialog1.FileName);
                BSODData.LoadData(fileContent);
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
            stream.Write(SaveSequenceB, 0, SaveSequenceB.Length);
            stream.Write(dane, 0, dane.Length);
            stream.Flush();
            stream.Close();
        }
        private void SaveSave(string path, byte[] dane)
        {
            if (File.Exists(path))
                File.Delete(path);
            var stream = File.OpenWrite(path);
            stream.Write(SaveSequenceB, 0, SaveSequenceB.Length);
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
            if (password_in.Text != BSODData.data.password && BSOD_Timer.Enabled && BSODData.data.unsafeMode) e.Cancel = true;
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
            btn_settings.BackColor = colorDialog1.Color;
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
            TogglePreviewMode();
        }

        private void rESETToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            InitResourceSave("win10");
        }

        public bool editing = false;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToggleDesignMode();
        }

        public void TogglePreviewMode()
        {
            preview = !preview;
            btn_start.Enabled = !preview;
            btn_settings.Enabled = !preview;
            BSODData.HideHidden(preview);
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

        public void ToggleDesignMode()
        {
            editing = !editing;
            toolStripMenuItem1.Checked = editing;
            design_helper.Visible = editing;
            BSODLabel.SetReadOnly(editing);
            if (editing)
            {
                foreach (var item in BSODData.data.labels)
                {
                    ControlMoverOrResizer.Init(item.control);
                    item.control.BorderStyle = BorderStyle.FixedSingle;
                }
                foreach (var item in BSODData.data.images)
                {
                    ControlMoverOrResizer.Init(item.control);
                    item.control.BorderStyle = BorderStyle.FixedSingle;
                }
                foreach (var item in BSODData.data.panels)
                {
                    ControlMoverOrResizer.Init(item.control);
                    item.control.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            if (!editing)
            {
                foreach (var item in BSODData.data.labels)
                {
                    ControlMoverOrResizer.Unload(item.control);
                    item.control.Cursor = Cursors.IBeam;
                    item.control.BorderStyle = BorderStyle.None;
                }
                foreach (var item in BSODData.data.images)
                {
                    ControlMoverOrResizer.Unload(item.control);
                    item.control.BorderStyle = BorderStyle.None;
                }
                foreach (var item in BSODData.data.panels)
                {
                    ControlMoverOrResizer.Unload(item.control);
                    item.control.BorderStyle = BorderStyle.None;
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
            hELPERToolStripMenuItem.Visible = editing;
            hELPERToolStripMenuItem.Checked = design_helper.Visible;
            _sourceControl = contextMenuStrip1.SourceControl;
            lABELToolStripMenuItem1.Visible = false;
            iMAGEToolStripMenuItem1.Visible = false;
            iTEMToolStripMenuItem.Visible = false;
            pANELToolStripMenuItem.Visible = false;
            foreach (var item in BSODData.data.labels)
            {
                if (item.control == _sourceControl)
                {
                    lABELToolStripMenuItem1.Visible = true;
                    iTEMToolStripMenuItem.Visible = true;
                    hIDDENToolStripMenuItem.Checked = item.hidden;
                }
            }
            foreach (var item in BSODData.data.images)
            {
                if (item.control == _sourceControl)
                {
                    iMAGEToolStripMenuItem1.Visible = true;
                    iTEMToolStripMenuItem.Visible = true;
                    hIDDENToolStripMenuItem.Checked = item.hidden;
                }
            }
            foreach (var item in BSODData.data.panels)
            {
                if (item.control == _sourceControl)
                {
                    pANELToolStripMenuItem.Visible = true;
                    iTEMToolStripMenuItem.Visible = true;
                    hIDDENToolStripMenuItem.Checked = item.hidden;
                }
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            InitResourceSave(((ToolStripMenuItem)sender).Text);
        }

        private void lABELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTextBox(new Point(0, 0), new Size(100, 100), "Label");
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
                if (item.control == _sourceControl)
                {
                    BSODData.data.labels.Remove(item);
                    break;
                }
            }
            foreach (var item in BSODData.data.images)
            {
                if (item.control == _sourceControl)
                {
                    BSODData.data.images.Remove(item);
                    break;
                }
            }
            foreach (var item in BSODData.data.panels)
            {
                if (item.control == _sourceControl)
                {
                    BSODData.data.panels.Remove(item);
                    BSODData.data.allItems.Remove(item);
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
            return BSOD_Timer.Enabled || preview;
        }

        internal void updateElements()
        {

        }

        private void mOVETOFRONTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sourceControl.BringToFront();
        }

        private void mOVETOBACKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sourceControl.SendToBack();
        }

        private void rELOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BSODData.SyncSettings();
            BSODData.Clean();
            BSODData.Apply();
        }

        private void cOLORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _sourceControl.ForeColor;
            var dialog = colorDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                _sourceControl.BackColor = colorDialog1.Color;
            }
        }

        private void pANELToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addPanel(new Point(0, 0), new Size(100, 100), Color.Black);
            if (editing)
            {
                ToggleDesignMode();
                ToggleDesignMode();
            }
        }

        private void DesignTimer_Tick(object sender, EventArgs e)
        {
            if (BSODActive()) return;
            btn_preview.BringToFront();
            btn_start.BringToFront();
            btn_settings.BringToFront();
        }

        private void hIDEBUTTONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hIDEBUTTONSToolStripMenuItem.Checked = !hIDEBUTTONSToolStripMenuItem.Checked;
            btn_start.Visible = !hIDEBUTTONSToolStripMenuItem.Checked;
            btn_settings.Visible = !hIDEBUTTONSToolStripMenuItem.Checked;
            btn_preview.Visible = !hIDEBUTTONSToolStripMenuItem.Checked;
        }

        private void hIDDENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in BSODData.data.allItems)
            {
                if (item.control == _sourceControl)
                {
                    item.hidden = !item.hidden;
                    hIDDENToolStripMenuItem.Checked = item.hidden;
                    break;
                }
            }
        }

        public Control selectedControl;
        public bool HelperListening = true;
        private void nbx_posX_ValueChanged(object sender, EventArgs e)
        {
            if (!editing || !HelperListening) return;
            if (selectedControl == null) return;
            selectedControl.Location = new Point((int)nbx_posX.Value, (int)nbx_posY.Value);
            selectedControl.Size = new Size((int)nbx_sizeW.Value, (int)nbx_sizeH.Value);

            BSODData.SaveTransformEntry(selectedControl);
        }

        public void UpdateSelectedControl(object sender, EventArgs e)
        {
            HelperListening = false;
            var control = (Control)sender;
            selectedControl = control;
            nbx_posX.Value = control.Location.X;
            nbx_posY.Value = control.Location.Y;

            nbx_sizeW.Value = control.Size.Width;
            nbx_sizeH.Value = control.Size.Height;
            HelperListening = true;
        }

        public void UpdateSelectedControl()
        {
            if (selectedControl==null) return;
            HelperListening = false;
            nbx_posX.Value = selectedControl.Location.X;
            nbx_posY.Value = selectedControl.Location.Y;

            nbx_sizeW.Value = selectedControl.Size.Width;
            nbx_sizeH.Value = selectedControl.Size.Height;
            HelperListening = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BSODData.Undo(selectedControl);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            BSODData.Redo(selectedControl);
        }

        private void hELPERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hELPERToolStripMenuItem.Checked = !hELPERToolStripMenuItem.Checked;
            design_helper.Visible = hELPERToolStripMenuItem.Checked;
        }
    }

    [Serializable]
    public class BSODControl
    {
        [NonSerialized]
        public Control control;
        public Point location;
        public Size size;
        public int zIndex = 0;
        public bool hidden = false;
        [NonSerialized]
        List<TransformEntry> TransformHistory = new List<TransformEntry>();
        [NonSerialized]
        public int TransformHistoryIndex = 0;
        public BSODControl(Point location,Size size)
        {
            this.location = location;
            this.size = size;
            SaveTransformEntry();
        }
        public void SaveTransformEntry()
        {
            if (TransformHistory == null) TransformHistory = new List<TransformEntry>();
            var entry = new TransformEntry(control.Location, control.Size);
            if (TransformHistory.Count >0&& entry != TransformHistory[TransformHistory.Count - 1 - TransformHistoryIndex])
            {
                while (TransformHistoryIndex > 0)
                {
                    TransformHistory.RemoveAt(0);
                    TransformHistoryIndex--;
                }
                TransformHistory.Add(entry);
            }
            if(TransformHistory.Count<=0) TransformHistory.Add(entry);

        }
        public void UpdateIndexes()
        {
            BSODData.form.Controls.SetChildIndex(control, zIndex);
        }

        public void UndoTransform()
        {
            if (TransformHistoryIndex >= TransformHistory.Count - 1) return;
            TransformHistoryIndex += 1;
            control.Location = TransformHistory[TransformHistory.Count-1-TransformHistoryIndex].Location;
            control.Size = TransformHistory[TransformHistory.Count-1 - TransformHistoryIndex].Size;
            BSODData.form.UpdateSelectedControl();
        }

        public void RedoTransform()
        {
            if (TransformHistoryIndex <= 0) return;
            TransformHistoryIndex -= 1;
            control.Location = TransformHistory[TransformHistory.Count-1 - TransformHistoryIndex].Location;
            control.Size = TransformHistory[TransformHistory.Count -1- TransformHistoryIndex].Size;
            BSODData.form.UpdateSelectedControl();
        }

        public virtual void SyncSettings()
        {
            
        }

        public virtual void CreateControl()
        {
            control.Scale(BSODData.form.scalefactor);
            SaveTransformEntry();
        }
    }

    [Serializable]
    public class BSODPanel : BSODControl
    {
        new public Panel control
        {
            get { return (Panel)base.control; }
            set { base.control = value; }
        }
        Color c;
        public BSODPanel(Point location, Size size, Color c) : base(location, size)
        {
            this.c = c;
            BSODData.data.panels.Add(this);
            CreateControl();
        }

        override public void CreateControl()
        {
            control = new Panel();
            control.BackColor = c;
            control.Location = location;
            control.Size = size;
            BSODData.form.Controls.Add(control);
            control.ContextMenuStrip = BSODData.form.strip;
            control.Click += BSODData.form.UpdateSelectedControl;
            control.Show();

            base.CreateControl();
        }
        override public void SyncSettings()
        {
            var scaleFactor = BSODData.form.scalefactor;
            control.Scale(new SizeF(1 / scaleFactor.Width, 1 / scaleFactor.Height));
            c = control.BackColor;
            location = control.Location;
            size = control.Size;
            zIndex = BSODData.form.Controls.GetChildIndex(control);
            control.Scale(scaleFactor);
        }

    }

    [Serializable]
    public class BSODImage : BSODControl
    {
        new public PictureBox control
        {
            get { return (PictureBox)base.control; }
            set { base.control = value; }
        }
        Image image;
        public BSODImage(Point location, Size size, Image img = null) : base(location, size)
        {
            image = img;
            BSODData.data.images.Add(this);
            CreateControl();
        }
        override public void CreateControl()
        {
            control = new PictureBox();
            if (image == null)
            {
                image = BlueScreen_Simulator.Properties.Resources.QR;
            }
            control.ContextMenuStrip = BSODData.form.strip;
            control.Image = image;
            control.SizeMode = PictureBoxSizeMode.Zoom;
            control.Location = location;
            control.Size = size;
            control.Click += BSODData.form.UpdateSelectedControl;
            BSODData.form.Controls.Add(control);
            control.Show();

            base.CreateControl();
        }
        override public void SyncSettings()
        {
            var scaleFactor = BSODData.form.scalefactor;
            control.Scale(new SizeF(1 / scaleFactor.Width, 1 / scaleFactor.Height));
            image = control.Image;
            location = control.Location;
            size = control.Size;
            zIndex = BSODData.form.Controls.GetChildIndex(control);
            control.Scale(scaleFactor);
        }
    }
    [Serializable]
    public class BSODLabel : BSODControl
    {
        new public RichTextBox control
        {
            get { return (RichTextBox)base.control; }
            set { base.control = value; }
        }
        public string oldTxt;
        public String text;
        public Font f = null;
        Color foreColor = Color.WhiteSmoke;

        public BSODLabel(Point location, Size size, String text, Font f = null) : base(location, size)
        {
            if (f == null)
            {
                f = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
            this.text = text;
            this.f = f;
            BSODData.data.labels.Add(this);
            CreateControl();
        }

        override public void CreateControl()
        {
            control = new RichTextBox();
            control.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            control.BorderStyle = System.Windows.Forms.BorderStyle.None;
            control.ContextMenuStrip = BSODData.form.strip;
            control.DetectUrls = false;
            control.Font = f;
            control.ForeColor = foreColor;
            control.Location = location;
            control.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            control.Size = size;
            control.TabIndex = 1;
            control.Text = text;
            BSODData.form.Controls.Add(control);
            control.Click += BSODData.form.UpdateSelectedControl;
            control.Show();

            control.Enter += TextBox_Enter;

            base.CreateControl();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (BSODData.form.BSODActive())
            {
                BSODData.form.ActiveControl = null;
            }
        }

        override public void SyncSettings()
        {
            var scaleFactor = BSODData.form.scalefactor;
            control.Scale(new SizeF(1 / scaleFactor.Width, 1 / scaleFactor.Height));
            location = control.Location;
            size = control.Size;
            text = control.Text;
            foreColor = control.ForeColor;
            f = control.Font;
            zIndex = BSODData.form.Controls.GetChildIndex(control);
            control.Scale(scaleFactor);
        }

        public void Format()
        {
            this.control.FormatTxt();
            this.control.ReadOnly = true;
        }

        public void FormatVar(string var, string val)
        {
            this.control.FormatVar(var, val);
        }

        public void Undo()
        {
            this.control.Text = this.oldTxt;
            this.control.ReadOnly = false;
            this.control.SelectAll(); this.control.SelectionColor = Color.WhiteSmoke;
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
                item.control.BackColor = c;
            }

        }

        public static void SaveOldTxts()
        {
            foreach (var item in BSODData.data.labels)
            {
                item.oldTxt = item.control.Text;
            }
        }

        internal static void SetReadOnly(bool readOnly)
        {
            foreach (var item in BSODData.data.labels)
            {
                if (item != null&&item.control!=null)
                    item.control.ReadOnly = readOnly;
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
            public List<BSODPanel> panels = new List<BSODPanel>();

            public List<BSODControl> allItems
            {
                get
                {
                    var all = new List<BSODControl>();
                    all.AddRange(labels);
                    all.AddRange(images);
                    all.AddRange(panels);
                    return all;
                }
            }

            public int cmin = 1, cmax = 8, tmin = 1000, tmax = 3500;
            public Color bc = Color.FromArgb(0, 120, 215);
            public string password = "1234", cmd = "";
            public bool unsafeMode = true, closeAfterCmd, hideCursor = true, AutoStart = true;
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
            if (BSODData.data.images == null)
            {
                BSODData.data.images = new List<BSODImage>();
            }
            if (BSODData.data.panels == null)
            {
                BSODData.data.panels = new List<BSODPanel>();
            }
            if (BSODData.data.labels == null)
            {
                BSODData.data.labels = new List<BSODLabel>();
            }
            Apply();
            s.Close();
        }

        internal static void SyncSettings()
        {
            foreach (var item in data.allItems)
            {
                item.SyncSettings();
            }
            data.bc = form.BackColor;
        }

        public static void CreateAll()
        {
            foreach (var item in data.allItems)
            {
                item.CreateControl();
            }
        }

        public static void UpdateZAll()
        {
            foreach (var item in data.allItems)
            {
                item.UpdateIndexes();
            }
        }

        public static void Apply()
        {
            if (BSODData.form.editing)
            {
                BSODData.form.ToggleDesignMode();
            }
            Clean();
            CreateAll();
            UpdateZAll();
            form.changeBColor(data.bc);
            form.updateElements();
        }
        public static void Clean()
        {
            if (BSODData.form.editing)
            {
                BSODData.form.ToggleDesignMode();
            }
            foreach (var item in data.allItems)
            {
                if (item.control != null)
                    item.control.Dispose();
            }
        }
        public static void Clear()
        {
            Clean();
            data.labels.Clear();
            data.images.Clear();
            data.panels.Clear();
            data = new Data();
        }

        internal static void HideHidden(bool hidden)
        {
            foreach (var item in data.allItems)
            {
                if (item.hidden)
                    item.control.Visible = !hidden;
            }
        }

        public static void LoadData(Stream stream, string type = "save")
        {
            byte[] target;
            switch (type)
            {

                case "template": { target = BSOD_EDIT.TemplateSequenceB; break; }
                default:
                case "save": { target = BSOD_EDIT.SaveSequenceB; break; }
            }


            var pos = Utils.FindPosition(stream, target);
            stream.Position = pos + target.Length;
            BSODData.Deserialize(Utils.ReadToEnd(stream, false));
            stream.Close();
        }

        public static void LoadData(byte[] bytes, string type = "save")
        {
            Stream s = new MemoryStream(bytes);
            LoadData(s, type);
        }

        public static void SaveTransformEntry(Control selectedControl)
        {
            foreach (var item in data.allItems)
            {
                if (item.control == selectedControl)
                    item.SaveTransformEntry();
            }
        }

        internal static void Undo(Control selectedControl)
        {
            foreach (var item in data.allItems)
            {
                if (item.control == selectedControl)
                    item.UndoTransform();
            }
        }

        internal static void Redo(Control selectedControl)
        {
            foreach (var item in data.allItems)
            {
                if (item.control == selectedControl)
                    item.RedoTransform();
            }
        }
    }

    public class TransformEntry
    {
        public Size Size;
        public Point Location;

        public TransformEntry(Point location, Size size)
        {
            Location = location;
            Size = size;
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

            BufferedStream bufStream = new BufferedStream(stream, byteSequence.Length);
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
