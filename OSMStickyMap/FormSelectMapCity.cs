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
    public partial class FormSelectMapCity : Form
    {
        public FormSelectMapCity()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.TopMost = true;
        }
        public void GetData(out string city , out string country)
        {
            city = txtMapKeyCity.Text;
            country = txtMapKeyCountry.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FormSelectMapCity_Load(object sender, EventArgs e)
        {

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            AppSettings.Instance.Config.lastwinPos.FormSelectCity.x = Math.Min(AppSettings.Instance.Config.lastwinPos.FormSelectCity.x, screenWidth  - this.Width );
            AppSettings.Instance.Config.lastwinPos.FormSelectCity.y = Math.Min(AppSettings.Instance.Config.lastwinPos.FormSelectCity.y, screenHeight - this.Height);


            if (AppSettings.Instance.Config.lastwinPos.FormSelectCity.x != -1 && AppSettings.Instance.Config.lastwinPos.FormSelectCity.y != -1)
            {
                this.Location = new Point(AppSettings.Instance.Config.lastwinPos.FormSelectCity.x, AppSettings.Instance.Config.lastwinPos.FormSelectCity.y);
            }
        }

        private void FormSelectMapCity_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppSettings.Instance.Config.lastwinPos.FormSelectCity.x = this.Location.X;
            AppSettings.Instance.Config.lastwinPos.FormSelectCity.y = this.Location.Y;
            AppSettings.Instance.Save();
        }
    }
}
