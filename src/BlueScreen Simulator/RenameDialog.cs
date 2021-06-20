using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueScreen_Simulator
{
    public partial class RenameDialog : Form
    {
        BSODControl control;
        BatchResource res;
        public RenameDialog(BSODControl control)
        {
            this.control = control;
            InitializeComponent();
            textBox1.Text = control.name;
        }

        public RenameDialog(BatchResource res)
        {
            this.res = res;
            InitializeComponent();
            textBox1.Text = res.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (control != null)
            {
                if (BSODData.GetControlByName(textBox1.Text) != null)
                {
                    MessageBox.Show("Already exists");
                    return;
                }
                control.name = textBox1.Text;
                this.Close();
            }
            if (res != null)
            {
                if (BSODData.GetResource(textBox1.Text) != null)
                {
                    MessageBox.Show("Already exists");
                    return;
                }
                res.name = textBox1.Text;
                this.Close();
            }
        }
    }
}
