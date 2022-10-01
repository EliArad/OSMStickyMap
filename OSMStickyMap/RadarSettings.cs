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
    public partial class RadarSettings : Form
    {

        public struct SettingsData
        {
            public string mapProvider;
            public string OSMBaseDir;
            public MAP_ACCESS_MODE MapAccessMode;
        }

        SettingsData m_sdata = new SettingsData();
        public RadarSettings()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;

            cmbGMapProviders.Items.Add("OpenStreetMapProvider");            
            //cmbGMapProviders.Items.Add("OpenCycleMapProvider");
            cmbGMapProviders.Items.Add("BingHybridMap");
            cmbGMapProviders.Items.Add("BingMap");
            // cmbGMapProviders.Items.Add("CloudMadeMapProvider");
            cmbGMapProviders.Items.Add("GoogleMap");            
            
            cmbGMapProviders.Items.Add("GoogleTerrainMap");
            cmbGMapProviders.Items.Add("GoogleSatelliteMap");
            cmbGMapProviders.Items.Add("GoogleHybridMap");
            cmbGMapProviders.Items.Add("ArcGIS_Topo_US_2D_Map");
            cmbGMapProviders.Items.Add("WikiMapiaMap");

            cmbGMapProviders.Text = AppSettings.Instance.Config.MapProvider;

            txtOSMBaseDir.Text = AppSettings.Instance.Config.OSMBaseDir;
            cmbMapAccessMode.SelectedIndex = (int)AppSettings.Instance.Config.MapAccessMode;
            this.TopMost = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbGMapProviders.SelectedIndex == -1)
                return;
            m_sdata.mapProvider = cmbGMapProviders.Text;
            m_sdata.OSMBaseDir = txtOSMBaseDir.Text;
            m_sdata.MapAccessMode = (MAP_ACCESS_MODE)cmbMapAccessMode.SelectedIndex;

            this.DialogResult = DialogResult.OK;
            Close();

        }

        public SettingsData  GetSettings()
        {
            return m_sdata;
        }

         
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
