using ControlManager;
using CoordinateSharp;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using InvokersLib;
using kmlViewer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSMStickyMap
{
    public partial class Form1 : Form
    {

        double minLat = 0, maxLat = 0, minLon = 0, maxLon = 0;
        SaveLocationForm saveLocationForm;
        string m_historyFileName = "MyHistoryBlock.json";
        GMapRoute line_layer;
        List<double> m_latList = new List<double>();
        List<double> m_lonList = new List<double>();
        String activeKmlFilePath;
        String saveMainFormText = "";
         
        Font ToolTipTextFont;

        private System.Windows.Forms.ToolTip tlTipRoute;
        private System.Windows.Forms.ToolTip tlTipPoly;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;


        GMapOverlay overlayMarkers = null;
        GMapOverlay overlayRoutes = null;
        GMapOverlay overlayPolygons = null;
        // GMapOverlay overlayRadar    = null;
        RadarOverlay overlayRadar = null;
        GMapOverlay overlayCustom = null;

        GMapPolygon savePoly = null;
        GMapRoute saveRoute = null;
        Color saveColorPoly = System.Drawing.Color.White;
        Color saveColorRoute = System.Drawing.Color.White;


        GMapOverlay polygons;
        GMapOverlay gMapOverlay;
        GMapOverlay gMapOverlayDraw;
        GMapOverlay line_overlay;
        Radar currentRadar;
        private int _xPos;
        private int _yPos;
        private bool _dragging;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        GMapMarker gMapMarker;
        string m_baseDir;
        private GMapControl gMapControl1;
        Bitmap radar_bmp;

        string CurrentDir;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.TopMost = true;
            topMostToolStripMenuItem.Checked = true;
            this.Text = "Bauotech Map";
        }


        void LoadForm()
        {

            CurrentDir = Directory.GetCurrentDirectory();

            presizeCallback = new ControlMoverOrResizer.ResizeCallback(ResizeCallbackMsg);
            this.tlTipRoute = new System.Windows.Forms.ToolTip(this.components);
            this.tlTipPoly = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);


            tlTipRoute.BackColor = System.Drawing.Color.Cyan;
            tlTipRoute.ForeColor = System.Drawing.Color.Red;
            tlTipPoly.BackColor = System.Drawing.Color.LightGreen;
            tlTipPoly.ForeColor = System.Drawing.Color.Red;

            radar_bmp = new Bitmap(Properties.Resources.radar);
             
            this.tlTipRoute.OwnerDraw = true;
            this.tlTipRoute.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.tlTip_Draw);
            // 
            // tlTipPoly
            // 
            this.tlTipPoly.OwnerDraw = true;
            this.tlTipPoly.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.tlTipPoly_Draw);

            FontFamily fam = new FontFamily("Microsoft Sans Serif");
            ToolTipTextFont = new Font(fam, 8, FontStyle.Regular);


            AppSettings.Instance.Load("OSMStickyMap.json");

            this.Left = AppSettings.Instance.Config.Left;
            this.Top = AppSettings.Instance.Config.Top;
            this.Width = AppSettings.Instance.Config.Width;
            this.Height = AppSettings.Instance.Config.Height;

            mapPanel.Left = 0;
            mapPanel.Top = 0;
            mapPanel.Width = AppSettings.Instance.Config.Width;
            mapPanel.Height = AppSettings.Instance.Config.Height;


            if (InitializeMap(out string outMessage) == false)
            {
                MpShowMessageBox(outMessage, 33321);
            }
            this.gMapControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.gMapControl1.Width = this.Width;
            this.gMapControl1.Height = this.Height;
            this.gMapControl1.Location = new Point(0, 0);

            LoadMap((int)AppSettings.Instance.Config.latestMapZoom, AppSettings.Instance.Config.latestMapLatLocation, AppSettings.Instance.Config.latestMapLonLocation);



            switch (AppSettings.Instance.Config.ShowMapCoordinate)
            {
                case MAP_CORDINATE.OFF:
                    MapCoordOff();
                    break;
                case MAP_CORDINATE.LAT_LON:
                    MapCoordLatLon();
                    break;
                case MAP_CORDINATE.ECEF_XYZ:
                    MapCoordECEF();
                    break;
            }


            gMapControl1.DoubleClick += GMapControl1_DoubleClick;
        }

        private void GMapControl1_DoubleClick(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != FormBorderStyle.Sizable)
                this.FormBorderStyle = FormBorderStyle.Sizable;
            else
                this.FormBorderStyle = FormBorderStyle.None;
        }

        void InitMapControl()
        {
            this.KeyPreview = true;
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();


            this.gMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            //this.gMapControl1.Size = new System.Drawing.Size(318, 321);
            this.gMapControl1.TabIndex = 2;
            this.gMapControl1.Zoom = 2D;
            this.gMapControl1.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMapControl1_OnMapZoomChanged);
            this.gMapControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDown);
            this.gMapControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseMove);
            this.gMapControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseUp);

            this.gMapControl1.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gmap_OnPolygonClick);
            this.gMapControl1.OnRouteClick += new GMap.NET.WindowsForms.RouteClick(this.gmap_OnRouteClick);
            this.gMapControl1.OnRouteEnter += new GMap.NET.WindowsForms.RouteEnter(this.gmap_OnRouteEnter);
            this.gMapControl1.OnRouteLeave += new GMap.NET.WindowsForms.RouteLeave(this.gmap_OnRouteLeave);
            this.gMapControl1.OnPolygonEnter += new GMap.NET.WindowsForms.PolygonEnter(this.gmap_OnPolygonEnter);
            this.gMapControl1.OnPolygonLeave += new GMap.NET.WindowsForms.PolygonLeave(this.gmap_OnPolygonLeave);




            this.mapPanel.Controls.Add(this.gMapControl1);
        }

        private void gMapControl1_OnMapZoomChanged()
        {
            comboBoxZoom.Text = gMapControl1.Zoom.ToString();
        }


        bool m_mouseDown = false;
        private void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                m_mouseDown = true;
        }

        private void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            m_mouseDown = false;
        }

        void AddTextPin(double lat, double lang, string tag, string text)
        {
            PointLatLng pointLatLng = new PointLatLng(lat, lang);
            GMapMarker gMapMarker = new GmapMarkerWithLabel(pointLatLng, text);
            gMapMarker.Tag = tag;
            gMapControl1.Overlays[0].Markers.Add(gMapMarker);

        }
        public static bool GetDriveInfo(string driveName, out DriveType driveType)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            driveType = DriveType.Unknown;
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.Name != "C:\\" && d.Name != "D:\\")
                    continue;
                if (d.IsReady == true)
                {
                    if (driveName == d.Name)
                    {
                        driveType = d.DriveType;
                        return true;
                    }
                }
            }
            return false;
        }
        bool InitializeMap(out string outMessage)
        {
            outMessage = string.Empty;
            string driveName = AppSettings.Instance.Config.OSMBaseDir.ToUpper().Substring(0, 3);

            if (GetDriveInfo(driveName, out DriveType driveType) == false)
            {
                outMessage = "Map Base directory unknown";
                return false;
            }
            if (driveType != DriveType.Fixed)
            {
                outMessage = "Map Base directory is not a fixed drive";
                return false;
            }
            m_baseDir = AppSettings.Instance.Config.OSMBaseDir + "\\";


            InitMapControl();

            if (polygons == null)
                polygons = new GMapOverlay("polygons");

            if (gMapOverlay == null)
            {
                gMapOverlay = new GMapOverlay("markers");
                gMapControl1.Overlays.Add(gMapOverlay);
            }

            overlayMarkers = new GMapOverlay("markers");
            overlayRoutes = new GMapOverlay("routes");
            overlayPolygons = new GMapOverlay("polygons");
            // overlayRadar    = new GMapOverlay("radar");
            overlayRadar = new RadarOverlay("radar");
            overlayCustom = new GMapOverlay("custom");
            // gmap.Overlays.Add(overlayRadar);
            // ####################
            gMapControl1.Overlays.Add(overlayRadar);
            gMapControl1.Overlays.Add(overlayCustom);



            gMapOverlayDraw = new GMapOverlay("drawings");
            gMapControl1.Overlays.Add(gMapOverlayDraw);

            if (line_overlay == null)
            {
                line_overlay = new GMapOverlay("line_overlay");
                line_layer = new GMapRoute("single_line");
                line_layer.Stroke = new Pen(Brushes.Black, 2); //width and color of line
                gMapControl1.Overlays.Add(line_overlay);
            }


            gMapControl1.ShowCenter = false;
            return true;

        }


        void LoadMap(int zoom, double lat, double lon)
        {
            gMapControl1.DragButton = MouseButtons.Left;

            if (string.IsNullOrEmpty(AppSettings.Instance.Config.MapProvider) == true)
            {
                AppSettings.Instance.Config.MapProvider = "OpenStreetMapProvider";
                gMapControl1.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            }

            if (!Directory.Exists(m_baseDir + AppSettings.Instance.Config.MapProvider))
            {
                Directory.CreateDirectory(m_baseDir + AppSettings.Instance.Config.MapProvider);
            }
            gMapControl1.CacheLocation = Path.Combine(m_baseDir + AppSettings.Instance.Config.MapProvider);

            gMapControl1.CanDragMap = true;
            //gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            //gMapControl1.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            ShowMapProvider(AppSettings.Instance.Config.MapProvider);

            SetMapAccessMode();


            comboBoxZoom.Text = zoom.ToString();

            //gMapControl1.SetPositionByKeywords("Israel, Tel Aviv");
            gMapControl1.Position = new GMap.NET.PointLatLng(lat, lon);

            gMapControl1.MaxZoom = 19;
            gMapControl1.MinZoom = 5;
            gMapControl1.Zoom = zoom;

            AppSettings.Instance.Config.latestMapLatLocation = lat;
            AppSettings.Instance.Config.latestMapLonLocation = lon;
            AppSettings.Instance.Config.latestMapZoom = zoom;
            AppSettings.Instance.Save();
            try
            {
                AddPin(lat, lon, "a1");
            }
            catch (Exception err)
            {

            }

            //MoveRadarBeam();
        }
        private void AddPin(double lat, double lang, string tag)
        {

            PointLatLng pointLatLng = new PointLatLng(lat, lang);

            gMapMarker = new GMarkerGoogle(pointLatLng, GMarkerGoogleType.red_pushpin);
            gMapOverlay.Markers.Add(gMapMarker);

            GMapMarkerPlane gMapMarkerPlane = new GMapMarkerPlane(pointLatLng, 0);
            gMapMarker.Tag = tag;

            //gMapControl1.Overlays[0].Markers.Add(gMapMarker);

            /*

            PointLatLng pointLatLng = new PointLatLng(lat, lang);
            GMapMarker gMapMarker = new GMarkerGoogle(pointLatLng, GMarkerGoogleType.red_pushpin);
            GMapMarkerPlane gMapMarkerPlane = new GMapMarkerPlane(pointLatLng, 0);
            gMapMarker.Tag = tag;

            //PointLatLng pointLatLng1 = new PointLatLng(lat + 1.010, lang + 1.010);
            //GMapMarker gMapMarker1 = new GMarkerGoogle(pointLatLng1, GMarkerGoogleType.blue_pushpin);


            //create overlay
            GMapOverlay gMapOverlay = new GMapOverlay("markers");
            //add marker
            //gMapOverlay.Markers.Add(gMapMarker1);
            //gMapOverlay.Markers.Add(gMapMarkerPlane);

            gMapOverlay.Markers.Add(gMapMarker);

            gMapControl1.Overlays.Add(gMapOverlay);
            //add overlay to map
            */
        }

        GeoCoordinate sCoord = null;
        GeoCoordinate eCoord = null;

        void MarkMapPointA()
        {
            sCoord = new GeoCoordinate(double.Parse(lblLat.Text), double.Parse(lblLon.Text));
        }
        void MarkMapPointB()
        {
            eCoord = new GeoCoordinate(double.Parse(lblLat.Text), double.Parse(lblLon.Text));
        }
        void CalcMapAirDistance()
        {
            if (eCoord == null || sCoord == null)
            {
                MpShowMessageBox("Please mark points before calling calculate", 9007);
                return;
            }
            double distanceInMeters = sCoord.GetDistanceTo(eCoord);
            MpShowMessageBox("Distance In meters: " + distanceInMeters + Environment.NewLine +
                            "Distance In Km: " + distanceInMeters / 1000.0 + Environment.NewLine);
        }
        public static void MpShowMessageBox(string msg, int errorNumber = 0)
        {
            MpMessageBox m = new MpMessageBox(msg, errorNumber);
            m.ShowDialog();
        }

        double m_lat;
        double m_lon;
        private void gMapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // long is x and lat is y

            m_lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            m_lon = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            string latitude = m_lat.ToString("0.0000000");
            string longitude = m_lon.ToString("0.0000000");

            switch (AppSettings.Instance.Config.ShowMapCoordinate)
            {
                case MAP_CORDINATE.OFF:
                    lblLat.Text = "";
                    lblLon.Text = "";
                    break;
                case MAP_CORDINATE.LAT_LON:
                    {
                        lblLat.Text = latitude;
                        lblLon.Text = longitude;
                    }
                    break;
                case MAP_CORDINATE.ECEF_XYZ:
                    {
                        Coordinate c = new Coordinate(m_lat, m_lon);
                        lblLon.Text = c.ECEF.X.ToString("0.0000000");
                        lblLat.Text = c.ECEF.Y.ToString("0.0000000");
                    }
                    break;
            }


            if (m_mouseDown && lineToolStripMenuItem1.Checked)
            {
                m_latList.Add(m_lat);
                m_lonList.Add(m_lon);

                line_layer.Points.Add(gMapControl1.FromLocalToLatLng(e.X, e.Y));

                line_overlay.Routes.Add(line_layer);

                gMapControl1.Overlays[(int)OVERLAYS.LINE] = line_overlay;

                //To force the draw, you need to update the route
                gMapControl1.UpdateRouteLocalPosition(line_layer);

            }


        }

       
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RadarSettings s = new RadarSettings();
            if (s.ShowDialog() == DialogResult.OK)
            {
                RadarSettings.SettingsData d = s.GetSettings();

                AppSettings.Instance.Config.OSMBaseDir = d.OSMBaseDir;
                m_baseDir = AppSettings.Instance.Config.OSMBaseDir + "\\";
                AppSettings.Instance.Config.MapAccessMode = d.MapAccessMode;

                ShowMapProvider(d.mapProvider);
                SetMapAccessMode();

                AppSettings.Instance.Save();
            }
        }

        void ShowMapProvider(string provider)
        {

            AppSettings.Instance.Config.MapProvider = provider;
            if (!Directory.Exists(m_baseDir + AppSettings.Instance.Config.MapProvider))
            {
                Directory.CreateDirectory(m_baseDir + AppSettings.Instance.Config.MapProvider);
            }
            gMapControl1.CacheLocation = Path.Combine(m_baseDir + AppSettings.Instance.Config.MapProvider);
             
                
            switch (provider)
            {
                case "BingMap":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
                    break;
                case "BingHybridMap":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
                    break;
                case "CloudMadeMapProvider":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.CloudMadeMapProvider.Instance;
                    break;
                case "GoogleMap":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                    break;
                case "OpenCycleMapProvider":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.CloudMadeMapProvider.Instance;                    
                    break;
                case "OpenStreetMapProvider":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
                    break;
                case "WikiMapiaMap":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.WikiMapiaMapProvider.Instance;
                    break;
                //case "YahooMapProvider":
                //    gmap.MapProvider = GMap.NET.MapProviders.YahooMapProvider.Instance;                    
                //    break;
                case "GoogleTerrainMap":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleTerrainMapProvider.Instance;
                    break;
                case "GoogleSatelliteMap":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                    break;
                case "GoogleHybridMap":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleHybridMapProvider.Instance;
                    break;
                case "ArcGIS_Topo_US_2D_Map":
                    gMapControl1.MapProvider = GMap.NET.MapProviders.ArcGIS_Topo_US_2D_MapProvider.Instance;
                    break;
            }
            gMapControl1.Refresh();
        }
 

        private void loadHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMapHistory();
        }

        public void CallbackMsg(int code, int index, string name, TileBlock tile)
        {

            if (code == 0)
            {
                int zoom = saveLocationForm.WithZoom() == false ? int.Parse(comboBoxZoom.Text) : tile.zoom;
                //textBoxLat.Text = tile.lat.ToString();
                //textBoxLong.Text = tile.lon.ToString();
                LoadMap(zoom, tile.lat, tile.lon);


                if (saveLocationForm != null)
                    SetHistory(saveLocationForm.GetHistory());

                if (saveLocationForm != null)
                {
                    AppSettings.Instance.Config.LoadWithZoom = saveLocationForm.WithZoom();
                    saveLocationForm.Close();
                }
                saveLocationForm = null;

            }
            if (code == 1)
            {
                saveLocationForm.DeleteEntry(index, name);
            }
        }
        void LoadMapHistory()
        {
            SaveLocationControl.Callback p = new SaveLocationControl.Callback(CallbackMsg);

            if (saveLocationForm != null)
            {
                AppSettings.Instance.Config.LoadWithZoom = saveLocationForm.WithZoom();
                saveLocationForm.Close();
                saveLocationForm = null;
            }
            saveLocationForm = new SaveLocationForm(m_historyFileName, AppSettings.Instance.Config.LoadWithZoom);
            saveLocationForm.LoadHistory(HistoryBlocks, p);
            saveLocationForm.ShowDialog();
            if (saveLocationForm != null)
                SetHistory(saveLocationForm.GetHistory());
        }

        public Dictionary<string, TileBlock> HistoryBlocks = new Dictionary<string, TileBlock>();
        public bool AddHistoryBlock(string name, TileBlock tile)
        {
            if (HistoryBlocks.ContainsKey(name) == false)
            {
                HistoryBlocks.Add(name, tile);
                return true;
            }
            return false;
        }
        public void SetHistory(Dictionary<string, TileBlock> h)
        {
            HistoryBlocks = h;
        }

        public string SaveHistory(string fileName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(HistoryBlocks);
                string jsonFormatted = JValue.Parse(json).ToString(Formatting.Indented);
                File.WriteAllText(fileName, jsonFormatted);
                return "ok";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        public bool LoadHistory(string fileName)
        {
            try
            {
                if (File.Exists(fileName) == false)
                {
                    HistoryBlocks = new Dictionary<string, TileBlock>();
                    return false;
                }
                string text = File.ReadAllText(fileName);
                HistoryBlocks = JsonConvert.DeserializeObject<Dictionary<string, TileBlock>>(text);
                return true;
            }
            catch (Exception err)
            {
                HistoryBlocks = new Dictionary<string, TileBlock>();
                return false;
            }
        }

        void SaveLocation()
        {

            string saveLocation = string.Empty;
            try
            {

                FormMapSaveLocation f = new FormMapSaveLocation(m_lat, m_lon, (int)gMapControl1.Zoom);
                if (f.ShowDialog() == DialogResult.Cancel)
                    return;
                f.GetSaveLocation(out saveLocation);
                if (saveLocation == string.Empty)
                    return;


            }
            catch (Exception err)
            {
                MpShowMessageBox(err.Message, 5002);
                return;
            }

            try
            {
                if (HistoryBlocks.ContainsKey(saveLocation) == false)
                {
                    TileBlock s = new TileBlock();

                    s.lat = m_lat;
                    s.lon = m_lon;
                    s.zoom = (int)gMapControl1.Zoom;
                    LatLongToPixelXYOSM(s.lat, s.lon, s.zoom,
                                     out int pixelX,
                                     out int pixelY,
                                     out int tilex,
                                     out int tiley);


                    s.x = tilex;
                    s.y = tilex;
                    s.pixelx = pixelX;
                    s.pixely = pixelY;

                    s.name = saveLocation;
                    HistoryBlocks.Add(saveLocation, s);
                    SaveHistory(m_historyFileName);
                    ShowMapSavedMsg();
                }
                else
                {
                    TileBlock s = HistoryBlocks[saveLocation];
                    //s.x = int.Parse(lblTileX.Text);
                    //s.y = int.Parse(lblTileY.Text);
                    //s.pixelx = int.Parse(lblPixelX.Text);
                    //s.pixely = int.Parse(lblPixelY.Text);

                    s.lat = m_lat;
                    s.lon = m_lon;
                    s.zoom = (int)gMapControl1.Zoom;
                    s.name = "location name??";
                    HistoryBlocks[saveLocation] = s;
                    SaveHistory(m_historyFileName);
                    ShowMapSavedMsg();
                }
            }
            catch (Exception err)
            {
                MpShowMessageBox(err.Message, 5003);
            }
        }
        void ShowMapSavedMsg()
        {
            lblMapPopupMsg.Visible = true;
            lblMapPopupMsg.Text = "Saved..";
            lblMapPopupMsg.Visible = true;
            var t = new Thread(() =>
            {
                Thread.Sleep(3000);
                INVOKERS.InvokeControlVisible(lblMapPopupMsg, false);
            });
            t.Start();
        }
        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoadMap f = new FormLoadMap();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.GetData(out double lat, out double lon, out int zoom, out string outMessage) == false)
                {
                    MpShowMessageBox(outMessage, 5005);
                    return;
                }
                LoadMap(zoom, lat, lon);
            }
        }
        public void LoadLocation(string location, bool forceZomming)
        {
            bool found = false;
            foreach (KeyValuePair<string, TileBlock> t in HistoryBlocks)
            {
                if (t.Key.ToLower() == location.ToLower())
                {
                    TileBlock tile = t.Value;
                    int zoom = forceZomming == false ? int.Parse(comboBoxZoom.Text) : tile.zoom;
                    //textBoxLat.Text = tile.lat.ToString();
                    //textBoxLong.Text = tile.lon.ToString();
                    LoadMap(zoom, tile.lat, tile.lon);
                    found = true;
                    return;
                }
            }
            if (found == false)
            {
                MpShowMessageBox("Location : " + location + " not found");
            }
        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadLocation("home", true);
        }

        private void findCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectMapCity f = new FormSelectMapCity();
            if (f.ShowDialog() == DialogResult.OK)
            {
                f.GetData(out string city, out string country);
                if (city == string.Empty && country == string.Empty)
                    return;
                string str = country + "," + city;
                gMapControl1.SetPositionByKeywords(str);
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            SaveLocation(true);
        }


        void SaveLocation(bool fromDlg)
        {

            string saveLocation = string.Empty;
            try
            {

                FormMapSaveLocation f = new FormMapSaveLocation(m_lat, m_lon, (int)gMapControl1.Zoom);
                if (f.ShowDialog() == DialogResult.Cancel)
                    return;
                f.GetSaveLocation(out saveLocation);
                if (saveLocation == string.Empty)
                    return;


            }
            catch (Exception err)
            {
                MpShowMessageBox(err.Message, 5002);
                return;
            }

            try
            {
                if (HistoryBlocks.ContainsKey(saveLocation) == false)
                {
                    TileBlock s = new TileBlock();

                    s.lat = m_lat;
                    s.lon = m_lon;
                    s.zoom = (int)gMapControl1.Zoom;
                    LatLongToPixelXYOSM(s.lat, s.lon, s.zoom,
                                     out int pixelX,
                                     out int pixelY,
                                     out int tilex,
                                     out int tiley);


                    s.x = tilex;
                    s.y = tilex;
                    s.pixelx = pixelX;
                    s.pixely = pixelY;

                    s.name = saveLocation;
                    HistoryBlocks.Add(saveLocation, s);
                    SaveHistory(m_historyFileName);
                    ShowMapSavedMsg();
                }
                else
                {
                    TileBlock s = HistoryBlocks[saveLocation];
                    //s.x = int.Parse(lblTileX.Text);
                    //s.y = int.Parse(lblTileY.Text);
                    //s.pixelx = int.Parse(lblPixelX.Text);
                    //s.pixely = int.Parse(lblPixelY.Text);

                    s.lat = m_lat;
                    s.lon = m_lon;
                    s.zoom = (int)gMapControl1.Zoom;
                    s.name = "location name??";
                    HistoryBlocks[saveLocation] = s;
                    SaveHistory(m_historyFileName);
                    ShowMapSavedMsg();
                }
            }
            catch (Exception err)
            {
                MpShowMessageBox(err.Message, 5003);
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            MarkMapPointA();
            AddPin(m_lat, m_lon, "a1");
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            MarkMapPointB();
            AddPin(m_lat, m_lon, "a1");
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            CalcMapAirDistance();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gMapControl1.Overlays[(int)OVERLAYS.LINE].Clear();
            line_overlay.Routes.Clear();
            line_layer.Clear();
            m_latList.Clear();
            m_lonList.Clear();
            gMapControl1.Refresh();
        }

        private void lineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lineToolStripMenuItem1.Checked = !lineToolStripMenuItem1.Checked;
            gMapControl1.CanDragMap = !lineToolStripMenuItem1.Checked;
        }

        private void calcDistanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalcLineDistance();
        }
        void CalcLineDistance()
        {
            GeoCoordinate sc = null;
            GeoCoordinate ec = null;
            double distanceInMeters = 0;

            for (int i = 0; i < m_latList.Count - 1; i += 1)
            {
                sc = new GeoCoordinate(m_latList[i], m_lonList[i]);
                ec = new GeoCoordinate(m_latList[i + 1], m_lonList[i + 1]);
                distanceInMeters += sc.GetDistanceTo(ec);
            }

            MpShowMessageBox("Line distance :" + distanceInMeters / 1000.0 + " Km", 6918);
            m_latList.Clear();
            m_lonList.Clear();
        }
        private void pinHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPin(m_lat, m_lon, "a1");

            double.TryParse(lblLat.Text, out AppSettings.Instance.Config.latestMapLatLocation);
            double.TryParse(lblLon.Text, out AppSettings.Instance.Config.latestMapLonLocation);
            double.TryParse(comboBoxZoom.Text, out AppSettings.Instance.Config.latestMapZoom);
        }

        private void clearAllPinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gMapControl1.Overlays[0].Markers.Clear();
            gMapControl1.Refresh();
        }

        private void screenShotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMapScreen();
        }
        void SaveMapScreen()
        {
            SnapshotMap("map_capture.jpg");
            System.Diagnostics.Process.Start("map_capture.jpg");
        }
        public Bitmap SnapshotMap(string fileName)
        {
            ScreenCapturer c = new ScreenCapturer(mapPanel.Left, mapPanel.Top, mapPanel.Width, mapPanel.Height);
            Bitmap result = c.Capture();
            result.Save(fileName, ImageFormat.Jpeg);
            return result;
        }
        private void fetchSelectedRegioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fetchSelectedRegioToolStripMenuItem.Checked = !fetchSelectedRegioToolStripMenuItem.Checked;
            btnStartFetch.Visible = fetchSelectedRegioToolStripMenuItem.Checked;
            if (fetchSelectedRegioToolStripMenuItem.Checked == true)
            {
                this.TopMost = false;
                topMostToolStripMenuItem.Checked = false;
            }
        }
        void FetchSelecedRegion()
        {
            try
            {
                DialogResult res = DialogResult.No;
                RectLatLng area = gMapControl1.SelectedArea;
                if (!area.IsEmpty)
                {
                    for (int i = (int)gMapControl1.Zoom; i <= gMapControl1.MaxZoom; i++)
                    {
                        if (askEveryZoomLevelToolStripMenuItem.Checked == true)
                            res = MessageBox.Show("Ready ripp at Zoom = " + i + " ?", "GMap.NET", MessageBoxButtons.YesNoCancel);
                        else
                            res = DialogResult.Yes;

                        if (res == DialogResult.Yes)
                        {
                            bool mode = gMapControl1.Manager.Mode != AccessMode.CacheOnly;
                            using (TilePrefetcher obj = new TilePrefetcher())
                            {

                                obj.Shuffle = gMapControl1.Manager.Mode != AccessMode.CacheOnly;

                                obj.Owner = this;
                                obj.ShowCompleteMessage = askEveryZoomLevelToolStripMenuItem.Checked;
                                obj.Start(area, i, gMapControl1.MapProvider, gMapControl1.Manager.Mode == AccessMode.CacheOnly ? 0 : 100, gMapControl1.Manager.Mode == AccessMode.CacheOnly ? 0 : 1);
                            }
                        }
                        else if (res == DialogResult.No)
                        {
                            btnStartFetch.Visible = false;
                            fetchSelectedRegioToolStripMenuItem.Checked = false;
                            continue;
                        }
                        else if (res == DialogResult.Cancel)
                        {
                            btnStartFetch.Visible = false;
                            fetchSelectedRegioToolStripMenuItem.Checked = false;
                            break;
                        }
                    }
                    btnStartFetch.Visible = false;
                    fetchSelectedRegioToolStripMenuItem.Checked = false;
                }
                else
                {
                    MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception err)
            {
                fetchSelectedRegioToolStripMenuItem.Checked = false;
                btnStartFetch.Visible = false;
            }
        }
        void AddObjectToMap(OBJECT_MAP ob)
        {

            string fileName = string.Empty;
            switch (ob)
            {
                case OBJECT_MAP.AIR_PLANE:
                    fileName = @"MapObjects\" + "Modern-Plane-PNG-Picture.png";
                    break;
            }
            // Random random = new Random();
            //double v = random.Next(1, 9) * 2d;
            //double lat = 31.790370 + v;
            //double lon = 74.598749 + v;

            //AddPin(lat,lon,"a1");

            GPoint p = gMapControl1.FromLatLngToLocal(new PointLatLng
            {
                Lat = m_lat,
                Lng = m_lon
            });

            PictureBox picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new System.Drawing.Size(55, 55),
                Location = new System.Drawing.Point((int)p.X, (int)p.Y),
                Image = Image.FromFile(fileName),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent

            };
            gMapControl1.Controls.Add(picture);

            picture.MouseDown += Picture_MouseDown;
            picture.MouseUp += Picture_MouseUp;
            picture.MouseMove += Picture_MouseMove;
            pictureBoxes.Add(picture);

            picture.BringToFront();
        }
        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            var c = sender as PictureBox;
            if (!_dragging || null == c) return;
            c.Top = e.Y + c.Top - _yPos;
            c.Left = e.X + c.Left - _xPos;
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            var c = sender as PictureBox;
            if (null == c) return;
            _dragging = false;
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _dragging = true;
            _xPos = e.X;
            _yPos = e.Y;
        }
        private void ariPLaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObjectToMap(OBJECT_MAP.AIR_PLANE);
        }
        PictureBox AddObjectToMap(string fileName)
        {

            GPoint p = gMapControl1.FromLatLngToLocal(new PointLatLng
            {
                Lat = m_lat,
                Lng = m_lon
            });

            PictureBox picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new System.Drawing.Size(55, 55),
                Location = new System.Drawing.Point((int)p.X, (int)p.Y),
                Image = Image.FromFile(fileName),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent

            };
            gMapControl1.Controls.Add(picture);

            picture.MouseDown += Picture_MouseDown;
            picture.MouseUp += Picture_MouseUp;
            picture.MouseMove += Picture_MouseMove;
            pictureBoxes.Add(picture);

            picture.BringToFront();

            return picture;
        }
        private void browseForObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Open Object",
                CheckFileExists = true,
                CheckPathExists = true,
                InitialDirectory = CurrentDir + "\\MapObjects",
                DefaultExt = "png",
                Filter = "PNG files (*.PNG)|*.png",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = false
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    AddObjectToMap(openFileDialog1.FileName);
                }
                catch (Exception err)
                {
                    MpShowMessageBox(err.Message, 918393);
                }
            }
        }
        enum OBJECT_MAP
        {
            AIR_PLANE
        }
        PictureBox AddObjectToMap(OBJECT_MAP ob, double lat, double lon)
        {

            string fileName = string.Empty;
            switch (ob)
            {
                case OBJECT_MAP.AIR_PLANE:
                    fileName = @"MapObjects\" + "Modern-Plane-PNG-Picture.png";
                    break;
            }


            GPoint p = gMapControl1.FromLatLngToLocal(new PointLatLng
            {
                Lat = lat,
                Lng = lon
            });

            PictureBox picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new System.Drawing.Size(55, 55),
                Location = new System.Drawing.Point((int)p.X, (int)p.Y),
                Image = Image.FromFile(fileName),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent

            };
            gMapControl1.Controls.Add(picture);

            picture.MouseDown += Picture_MouseDown;
            picture.MouseUp += Picture_MouseUp;
            picture.MouseMove += Picture_MouseMove;
            pictureBoxes.Add(picture);

            picture.BringToFront();

            return picture;
        }
        private void objectOnTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObjectToMap(OBJECT_MAP.AIR_PLANE, m_lat, m_lon);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gMapControl1.Controls.Clear();
        }

        private void showZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showZoomToolStripMenuItem.Checked = !showZoomToolStripMenuItem.Checked;
            comboBoxZoom.Visible = showZoomToolStripMenuItem.Checked;
            label1.Visible = comboBoxZoom.Visible;
        }
         

        void PixelXYToLatLongOSM(int pixelX, int pixelY, int zoomLevel, out double latitude, out double longitude)
        {
            int mapSize = (int)Math.Pow(2, zoomLevel) * 256;
            //int tileX = (int)Math.Truncate((decimal)(pixelX / 256));
            //int tileY = (int)Math.Truncate((decimal)pixelY / 256);

            double n = (float)Math.PI - ((2.0f * (double)Math.PI * (ClipByRange(pixelY, mapSize - 1) / 256)) / (double)Math.Pow(2.0, zoomLevel));

            longitude = ((ClipByRange(pixelX, mapSize - 1) / 256) / (double)Math.Pow(2.0, zoomLevel) * 360.0f) - 180.0f;
            latitude = (180.0f / (float)Math.PI * (double)Math.Atan(Math.Sinh(n)));
        }
        double ClipByRange(double n, double range)
        {
            return n % range;
        }

        double Clip(double n, double minValue, double maxValue)
        {
            return Math.Min(Math.Max(n, minValue), maxValue);
        }

        void LatLongToPixelXYOSM(double latitude, double longitude, int zoomLevel,
                                 out int pixelX,
                                 out int pixelY,
                                 out int tilex,
                                 out int tiley)
        {
            double MinLatitude = -85.05112878f;
            double MaxLatitude = 85.05112878f;
            double MinLongitude = -180;
            double MaxLongitude = 180;
            double mapSize = (double)Math.Pow(2, zoomLevel) * 256;

            latitude = Clip(latitude, MinLatitude, MaxLatitude);
            longitude = Clip(longitude, MinLongitude, MaxLongitude);

            double X = (double)((longitude + 180.0f) / 360.0f * (double)(1 << zoomLevel));
            double Y = (double)((1.0 - Math.Log(Math.Tan(latitude * (Math.PI / 180.0)) + 1.0 / Math.Cos(latitude * (Math.PI / 180.0))) / Math.PI) / 2.0 * (1 << zoomLevel));

            tilex = (int)(Math.Truncate(X));
            tiley = (int)(Math.Truncate(Y));
            pixelX = tilex * 256;
            pixelY = tiley * 256;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (mapPanel.Visible == false)
                {
                    mapPanel.Visible = true;
                    ControlMoverOrResizer.Stop(this);
                    AppSettings.Instance.Config.Left = this.Location.X;
                    AppSettings.Instance.Config.Top = this.Location.Y;
                    AppSettings.Instance.Config.Width = this.Size.Width;
                    AppSettings.Instance.Config.Height = this.Size.Height;

                    mapPanel.Left = 0;
                    mapPanel.Top = 0;
                    mapPanel.Width = AppSettings.Instance.Config.Width;
                    mapPanel.Height = AppSettings.Instance.Config.Height;
                    gMapControl1.Left = 0;
                    gMapControl1.Top = 0;
                    gMapControl1.Width = this.Width;
                    gMapControl1.Height = this.Height;
                    moveAndResizeToolStripMenuItem.Checked = false;
                    AppSettings.Instance.Save();
                    return;
                }
                Close();
            }
        }

        private void askEveryZoomLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            askEveryZoomLevelToolStripMenuItem.Checked = !askEveryZoomLevelToolStripMenuItem.Checked;
        }

        private void btnStartFetch_Click(object sender, EventArgs e)
        {
            FetchSelecedRegion();
        }

        private void OffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapCoordOff();
        }
        void MapCoordOff()
        {
            OffToolStripMenuItem.Checked = true;
            latLonToolStripMenuItem.Checked = false;
            xxToolStripMenuItem.Checked = false;
            AppSettings.Instance.Config.ShowMapCoordinate = MAP_CORDINATE.OFF;
            lblLat.Text = "";
            lblLon.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        private void latLonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapCoordLatLon();
        }
        void MapCoordLatLon()
        {

            OffToolStripMenuItem.Checked = false;
            latLonToolStripMenuItem.Checked = true;
            xxToolStripMenuItem.Checked = false;
            AppSettings.Instance.Config.ShowMapCoordinate = MAP_CORDINATE.LAT_LON;
            label2.Text = "Lat";
            label3.Text = "Lon";
        }

        private void xxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapCoordECEF();
        }
        void MapCoordECEF()
        {
            OffToolStripMenuItem.Checked = false;
            latLonToolStripMenuItem.Checked = false;
            xxToolStripMenuItem.Checked = true;
            AppSettings.Instance.Config.ShowMapCoordinate = MAP_CORDINATE.ECEF_XYZ;
            label2.Text = "Y";
            label3.Text = "X";
        }

        enum RADAR_OPERATION_MODE
        {
            ADD,
            EDIT,
            DELETE
        }
        bool SetRadar(RADAR_OPERATION_MODE mode, double radarLat, double radarLng,
                      double radarRange,
                      double Azimuth,
                      double FoV,
                      int transparency,
                      int argbColor,
                      out string outMessage)
        {
            

            if (radarRange < 0)
            {
                outMessage = "Range value must be positive";
                return false;
            }

            if (Azimuth > 360 || Azimuth < -360)
            {
                outMessage = "Azimuth value must be between -360 and 360";
                return false;
            }

            if (FoV < 0)
            {
                outMessage = "FoV value must be positive";
                return false;
            }

            if (transparency < 0 || transparency > 100)
            {
                outMessage = "Transparency value must be in the range 0 - 100";
                return false;
            }


            outMessage = "";
            // lblRadarErr.Visible = false;
            // overlayRadar.Markers.RemoveAt(0);
            

            if (mode == RADAR_OPERATION_MODE.ADD)
            {
                Radar radar = new Radar(overlayRadar, radarLat, radarLng, radarRange, Azimuth, FoV, argbColor, transparency);
                radar.Draw();
                currentRadar = radar;
                return true;
            }
            if (mode == RADAR_OPERATION_MODE.EDIT)
            {
                Radar radarOld = currentRadar;
                if (radarOld != null)
                    radarOld.Delete();
                Radar radar = new Radar(overlayRadar, radarLat, radarLng, radarRange, Azimuth, FoV, argbColor, transparency);
                radar.Draw();
                currentRadar = radar;
                return true;
            }

            return false;

            
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            AppSettings.Instance.Config.latestMapLatLocation = m_lat;
            AppSettings.Instance.Config.latestMapLonLocation = m_lon;
            AppSettings.Instance.Config.latestMapZoom = gMapControl1.Zoom;
            AppSettings.Instance.Save();
        }
        void SetMapAccessMode()
        {
            switch (AppSettings.Instance.Config.MapAccessMode)
            {
                case MAP_ACCESS_MODE.Offline:
                    {
                        GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.CacheOnly;
                    }
                    break;
                case MAP_ACCESS_MODE.Online:
                    {
                        GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                    }
                    break;
                case MAP_ACCESS_MODE.Both:
                    {
                        GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                    }
                    break;
            }

        }
        public bool IsControlDown()
        {
            return (Control.ModifierKeys & Keys.Control) == Keys.Control;
        }
         
        private void gmap_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            if (IsControlDown())
            {
                if (item is RadarPolygon)
                {
                    Radar radar = ((RadarPolygon)item).radar;
                    radar.Delete();
                    return;
                }
            }
            /*
            if (chkSetRadar.Checked && radioRadarEdit.Checked)
            {
                if (item is RadarPolygon)
                {
                    Radar radar = ((RadarPolygon)item).radar;
                    txtRadarLat.Text = radar.Lat.ToString();
                    txtRadarLon.Text = radar.Lon.ToString();
                    txtRadarRange.Text = radar.Range.ToString();
                    txtRadarAzim.Text = radar.Azimuth.ToString();
                    txtRadarFov.Text = radar.Fov.ToString();
                    txtTransparency.Text = radar.Transparency.ToString();
                    txtColor.BackColor = Color.FromArgb(radar.Argb);
                    currentRadar = radar;
                    return;
                }
            }
            */
            // unhighlite previously highlighted items:
            unhighlightPoly();
            unhighlightRoute();
            tlTipRoute.Active = false;
            // tlTipPoly.Active  = false;

            saveColorPoly = item.Stroke.Color;
            savePoly = item;
            highlightPoly(item);

            String s = String.Format("{0}", item.Tag);
            tlTipPoly.Active = true;
            tlTipPoly.SetToolTip(gMapControl1, s);
        }

        // POLYGON LEAVE
        private void gmap_OnPolygonLeave(GMapPolygon item)
        {
            unhighlightPoly();
            unhighlightRoute();
            tlTipPoly.Active = false;
        }

        private void gmap_OnRouteEnter(GMapRoute item)
        {
            // unhighlite previously highlighted items:
            unhighlightPoly();
            unhighlightRoute();

            tlTipRoute.Active = false;
            // tlTipPoly.Active = false;

            saveColorRoute = item.Stroke.Color;
            saveRoute = item;
            highlightRoute(item);

            String s = String.Format("{0}", item.Tag);
            tlTipRoute.Active = true;
            tlTipRoute.SetToolTip(gMapControl1, s);
        }

        // ROUTE CLICK
        private void gmap_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            // unhighlite previously highlighted items:
            unhighlightPoly();
            unhighlightRoute();
            // tlTipRoute.Active = false;
            tlTipPoly.Active = false;

            saveColorRoute = item.Stroke.Color;
            saveRoute = item;
            highlightRoute(item);

            String s = String.Format("{0}", item.Tag);
            tlTipRoute.Active = true;
            tlTipRoute.SetToolTip(gMapControl1, s);
        }

        // ROUTE LEAVE
        private void gmap_OnRouteLeave(GMapRoute item)
        {
            unhighlightPoly();
            unhighlightRoute();
            tlTipRoute.Active = false;
        }
        private void gmap_OnPolygonEnter(GMapPolygon item)
        {
            // unhighlite previously highlighted items:
            unhighlightPoly();
            unhighlightRoute();
            tlTipRoute.Active = false;
            // tlTipPoly.Active = false;

            saveColorPoly = item.Stroke.Color;
            savePoly = item;
            highlightPoly(item);

            String s = String.Format("{0}", item.Tag);
            tlTipPoly.Active = true;
            tlTipPoly.SetToolTip(gMapControl1, s);
        }
        private void highlightPoly(GMapPolygon poly)
        {
            Color line_color = System.Drawing.Color.Red;
            poly.Stroke = new Pen(line_color, poly.Stroke.Width);
        }

        private void unhighlightPoly()
        {
            if (savePoly != null)
                savePoly.Stroke.Color = saveColorPoly;
        }

        private void highlightRoute(GMapRoute route)
        {
            Color line_color = System.Drawing.Color.Red;
            route.Stroke = new Pen(line_color, route.Stroke.Width);
        }

        private void unhighlightRoute()
        {
            if (saveRoute != null)
                saveRoute.Stroke.Color = saveColorRoute;
        }

        private void tlTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            // e.DrawBorder();
            e.DrawText();
        }

        private void tlTipPoly_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            // e.DrawBorder();
            e.DrawText();
        }
         

        private byte[] abgr_to_argb(byte[] abgr)
        {
            byte[] argb = { abgr[0],     /*transparency*/
                            abgr[3],     /*red*/
                            abgr[2],     /*green*/
                            abgr[1]};    /*blue*/
            return argb;
        }

        void set_transparency(byte alpha, ref int argb)
        {
            byte[] byteArr = BitConverter.GetBytes(argb);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(byteArr);
            // byte[] result = byteArr;
            byteArr[0] = alpha;
            if (BitConverter.IsLittleEndian)
                Array.Reverse(byteArr);
            argb = BitConverter.ToInt32(byteArr, 0);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        private void setMinMax(double lat, double lon)
        {
            minLat = minLat == 0 ? lat : minLat < lat ? minLat : lat;
            maxLat = maxLat > lat ? maxLat : lat;
            minLon = minLon == 0 ? lon : minLon < lon ? minLon : lon;
            maxLon = maxLon > lon ? maxLon : lon;
        }
         

        ControlMoverOrResizer.ResizeCallback presizeCallback = null;
        void ResizeCallbackMsg(Control control, int x, int y)
        {

        }
        private void moveAndResizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveAndResizeToolStripMenuItem.Checked = !moveAndResizeToolStripMenuItem.Checked;
            if (moveAndResizeToolStripMenuItem.Checked)
            {
                mapPanel.Visible = false;
                this.BackColor = Color.LightSkyBlue;
                ControlMoverOrResizer.Init(this, presizeCallback);
            }
            else
            {
                mapPanel.Visible = true;
                ControlMoverOrResizer.Stop(this);
                AppSettings.Instance.Config.Left = this.Location.X;
                AppSettings.Instance.Config.Top = this.Location.Y;
                AppSettings.Instance.Config.Width = this.Size.Width;
                AppSettings.Instance.Config.Height = this.Size.Height;

                mapPanel.Left = AppSettings.Instance.Config.Left;
                mapPanel.Top = AppSettings.Instance.Config.Top;
                mapPanel.Width = AppSettings.Instance.Config.Width;
                mapPanel.Height = AppSettings.Instance.Config.Height;

                AppSettings.Instance.Save();

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topMostToolStripMenuItem.Checked = !topMostToolStripMenuItem.Checked;
            this.TopMost = topMostToolStripMenuItem.Checked;
        }
 
        private void kmlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    activeKmlFilePath = openFileDialog1.FileName;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                    return;
                }
                // Previous overlays will be deleted:
                overlayMarkers.Markers.Clear();
                overlayRoutes.Routes.Clear();
                overlayPolygons.Polygons.Clear();

                //overlayRadar.Markers.Clear();
                //overlayRadar.Routes.Clear();
                //overlayRadar.Polygons.Clear();

                // ????!!!! gmap.Overlays.Clear();
                ActiveForm.Text = activeKmlFilePath + " - " + saveMainFormText;
                 
                // ####################
                // gmap.Overlays.Add(overlayRadar);
                // ####################
            }
            else // if 'Cansel' selected in a file dialog
            {
                // grShowHideKml.Enabled = bShowHideKml_enabled_save;             
                //chkMarkers.Enabled = bShowHideKml_enabled_save;
                //chkRoutes.Enabled = bShowHideKml_enabled_save;
                //chkPoly.Enabled = bShowHideKml_enabled_save;
            }
            minLat = 0;
            maxLat = 0;
            minLon = 0;
            maxLon = 0;
            // fromObjNum = 0;
            // toObjNum = 0;
            // numObj = 0;
        }
    }
}
