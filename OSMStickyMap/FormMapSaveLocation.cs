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
    public partial class FormMapSaveLocation : Form
    {
        public FormMapSaveLocation(double lat , double lon , int zoom)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            lblLat.Text = lat.ToString();
            lblLon.Text = lon.ToString();
            lblZoom.Text = zoom.ToString();
            this.TopMost = true;
        }
 
        public void GetSaveLocation(out string location)
        {
            location = txtLocationName.Text;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void FormMapSaveLocation_Load(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.x = Math.Min(AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.x, screenWidth  - this.Width );
            AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.y = Math.Min(AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.y, screenHeight - this.Height);


            if (AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.x != -1 && AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.y != -1)
            {
                this.Location = new Point(AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.x, AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.y);
            }
        }

        private void FormMapSaveLocation_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.x = this.Location.X;
            AppSettings.Instance.Config.lastwinPos.MapSaveLocationWindow.y = this.Location.Y;
            AppSettings.Instance.Save();
        }
    }
}
