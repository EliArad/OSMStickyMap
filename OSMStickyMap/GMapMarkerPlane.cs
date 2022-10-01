using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMStickyMap
{
    public class GMapMarkerPlane : GMapMarker
    {
        private readonly Bitmap icon;
        float heading = 0;

        public GMapMarkerPlane(PointLatLng p, float heading)
            : base(p)
        {
            icon = new Bitmap("planetracker.ico");
            this.heading = heading;
            Size = icon.Size;

            

        }
        public override void OnRender(Graphics g)
        {
            Matrix temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);
            g.RotateTransform(-Overlay.Control.Bearing);

            try
            {
                g.RotateTransform(heading);
            }
            catch { }

            g.DrawImageUnscaled(icon, icon.Width / -2, icon.Height / -2);
            g.Transform = temp;
        }
    }
}
