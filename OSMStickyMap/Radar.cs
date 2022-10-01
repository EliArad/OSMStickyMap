using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.IO;
// using GeomLab;

namespace kmlViewer
{
    class Radar
    {
        RadarOverlay Overlay;
        public double Lat {get; set;}
        public double Lon {get; set;}
        public double Range {get; set;}
        public double Azimuth {get; set;}
        public double Fov {get; set;}
        // GMapOverlay Overlay { get; set; }
        // OverlayRadar Overlay { get; set; }
        public int Argb { get; set; }
        public int Transparency { get; set; }
        private Color lineColor;
        private Color fillColor;
        public RadarPolygon polySector{ get; set;}
        public RadarPolygon polyPosition { get; set; }
        public GMapRoute direction { get; set; }

        public Radar(RadarOverlay Overlay, double Lat, double Lon, double Range, double Azimuth,
            double Fov, int Argb, int Transparency)
        {
            this.Overlay = Overlay;
            this.Lat = Lat;
            this.Lon = Lon;
            this.Range = Range;
            this.Azimuth = Azimuth;
            this.Fov = Fov;
            this.Argb = Argb;
            this.Transparency = Transparency;
            setColors();
        }

        public void setColors()
        {
            // Colors:
            lineColor = Color.FromArgb(Argb); ;
            int argb_fill = Argb;

#if SHRDEBUG
            string scolor = string.Format("hex is {0:x}", argb_fill);
            MessageBox.Show(scolor);
#endif
            byte alpha = (byte)(Transparency * 255 / 100);
            GeomLab.setTransparency(alpha, ref argb_fill);
#if SHRDEBUG
            scolor = string.Format("alpha: {0} is {1:x}", alpha, argb_fill);
            MessageBox.Show(scolor);
#endif
            fillColor = Color.FromArgb(argb_fill);
        }

        public void Draw()
        {
            //Overlay.Markers.Clear();
            //Overlay.Routes.Clear();
            //Overlay.Polygons.Clear();

            // Radar beam direction:
            double latC;
            double lonC;
            GeomLab.calculateBeamEndPosition(Lat, Lon, Range, Azimuth, out latC, out lonC);
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(Lat, Lon));
            points.Add(new PointLatLng(latC, lonC));

            direction = new GMapRoute(points, "radar beam direction");

            if (null != direction)
            {
                direction.Stroke = new Pen(lineColor, 3);
                direction.Tag = direction.Name;
                // activate mouse events:
                direction.IsHitTestVisible = true;
                Overlay.Routes.Add(direction);
            }

            // Radar polygon:
            List<PointLatLng> pointsPoly = new List<PointLatLng>();
            pointsPoly.Add(new PointLatLng(Lat, Lon));
            double angle = Azimuth - Fov / 2;
            GeomLab.calculateArcPoints(Lat, Lon, Range, angle, Fov, pointsPoly);
            pointsPoly.Add(new PointLatLng(Lat, Lon));

            polySector = new RadarPolygon(this, pointsPoly, "radarPoly");
            if (null != polySector)
            {
                polySector.Fill = new SolidBrush(fillColor);
                polySector.Stroke = new Pen(lineColor, 3);
                polySector.Tag = "radar beam sector";
                // activate mouse events:
                polySector.IsHitTestVisible = true;
                Overlay.Polygons.Add(polySector);
            }

            // circle designating the radar location:
            List<PointLatLng> pointsRadarPos = new List<PointLatLng>();
            GeomLab.calculateArcPoints(Lat, Lon, 1, 0, 360, pointsRadarPos);
            polyPosition = new RadarPolygon(this, pointsRadarPos, "radarCenter");
            if (null != polyPosition)
            {
                polyPosition.Fill = new SolidBrush(fillColor);
                polyPosition.Stroke = new Pen(lineColor, 3);
                polyPosition.Tag = "radar position";
                // activate mouse events:
                polyPosition.IsHitTestVisible = true;
                Overlay.Polygons.Add(polyPosition);
                Overlay.Radars.Add(this);
            }
        }

        public void Delete()
        {
            Overlay.Polygons.Remove(polySector);
            Overlay.Polygons.Remove(polyPosition);
            Overlay.Routes.Remove(direction);
            Overlay.Radars.Remove(this);
        }
    }
}
