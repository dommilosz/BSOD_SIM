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

namespace FTPRun
{
    public partial class FTPRun : Form
    {
        string lines = "";
        bool enabled = false;
        public FTPRun()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try { lines = ReadFTP(@"ftp://ftpopen.keep.pl/FTPRUN.txt", "ftpopen@keep.pl", "miloszek5"); } catch { }
            enabled = checkBox1.Checked;
            if (lines.Length > 0)
            {
                label1.Text = lines;
                if (lines.Contains("True") && enabled) { Button2_Click(new object(), new EventArgs()); this.Close(); }
            }
            notifyIcon1.Text = label1.Text;
        }

        private string ReadFTP(string url,string login,string password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(login, password);


            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string tmp = (reader.ReadToEnd());
            reader.Close();
            response.Close();
            return tmp;
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

        private void WriteFTP(string url, string login, string password,string lines)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(login, password);

            // Copy the contents of the file to the request stream.
            byte[] fileContents;

            fileContents = Encoding.UTF8.GetBytes(lines);

            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {

            }
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            lines = "True";
            try {WriteFTP(@"ftp://ftpopen.keep.pl/FTPRUN.txt", "ftpopen@keep.pl", "miloszek5",lines); } catch { }
            timer2.Start();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            lines = "False";
            try { WriteFTP(@"ftp://ftpopen.keep.pl/FTPRUN.txt", "ftpopen@keep.pl", "miloszek5", lines); } catch { }
            timer2.Stop();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value;
        }
    }
}
