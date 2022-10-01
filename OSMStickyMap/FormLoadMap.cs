using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSMStickyMap
{
    public partial class FormLoadMap : Form
    {
        public FormLoadMap()
        {
            InitializeComponent();

            for (int i = 5; i <= 19; i++)
            {
                comboBoxZoom.Items.Add(i.ToString());
            }
            comboBoxZoom.SelectedIndex = AppSettings.Instance.Config.LastLoadMapZoom;
            textBoxLat.Text = AppSettings.Instance.Config.LastLoadMapLat.ToString();
            textBoxLong.Text = AppSettings.Instance.Config.LastLoadMapLon.ToString();
             

            this.DialogResult = DialogResult.Cancel;

            this.TopMost = true;
        }

        private void buttonLoadMap_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        public bool GetData(out double lat, out double lon , out int zoom, out string outMessage)
        {
            lat = 0;
            lon = 0;
            zoom = 0;
            outMessage = string.Empty;
            try
            {
                lat = double.Parse(textBoxLat.Text);
                lon = double.Parse(textBoxLong.Text);
                zoom = int.Parse(comboBoxZoom.Text);
                return true;
            }
            catch (Exception err)
            {
                outMessage = err.Message;
                return false;
            }
        }

        private void FormLoadMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                AppSettings.Instance.Config.lastwinPos.LoadMapWindow.x = this.Location.X;
                AppSettings.Instance.Config.lastwinPos.LoadMapWindow.y = this.Location.Y;

                AppSettings.Instance.Config.LastLoadMapZoom = comboBoxZoom.SelectedIndex;
                AppSettings.Instance.Config.LastLoadMapLat = double.Parse(textBoxLat.Text);
                AppSettings.Instance.Config.LastLoadMapLon = double.Parse(textBoxLong.Text);

                AppSettings.Instance.Save();
            }
            catch (Exception err)
            {
                e.Cancel = true;
                MessageBox.Show(err.Message);
                return;
            }
        }

        private void FormLoadMap_Load(object sender, EventArgs e)
        {

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            AppSettings.Instance.Config.lastwinPos.LoadMapWindow.x = Math.Min(AppSettings.Instance.Config.lastwinPos.LoadMapWindow.x, screenWidth  - this.Width );
            AppSettings.Instance.Config.lastwinPos.LoadMapWindow.y = Math.Min(AppSettings.Instance.Config.lastwinPos.LoadMapWindow.y, screenHeight - this.Height);


            if (AppSettings.Instance.Config.lastwinPos.LoadMapWindow.x != -1 && AppSettings.Instance.Config.lastwinPos.LoadMapWindow.y != -1)
            {
                this.Location = new Point(AppSettings.Instance.Config.lastwinPos.LoadMapWindow.x, AppSettings.Instance.Config.lastwinPos.LoadMapWindow.y);
            }
        }
    }
}

