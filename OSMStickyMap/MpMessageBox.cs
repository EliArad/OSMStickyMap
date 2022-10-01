using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSMStickyMap
{
    public partial class MpMessageBox : Form
    {
        
        public MpMessageBox(string text, int errorNumber = 0)
        {
            InitializeComponent();

            this.TopLevel = true;
            this.TopMost = true;
            this.KeyPreview = true;
            
            if (errorNumber > 0)
            {
                this.Text = "#Error: " + errorNumber;
            }
            LoadForm(text);
        }
        public void SmallSize()
        {
            this.Width = this.Width / 2;
            btnOk.Left = btnOk.Left / 2;
        }
        
        
        void  LoadForm(string text)
        {
            try
            {
                 
                label1.Text = text;
                label1.MaximumSize = new Size(this.Width - 20, 0);
                label1.AutoSize = true;
            }
            catch (Exception err)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MpMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
