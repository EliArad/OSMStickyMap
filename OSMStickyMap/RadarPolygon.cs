using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GMap.NET.WindowsForms;
//using GMap.NET.WindowsForms.Markers;
//using GMap.NET.MapProviders;
//using System.IO;
//using KmlParseLib;
//using GMap.NET.ObjectModel;

using GMap.NET;
//using GMap.NET.WindowsForms;
//using GMap.NET.WindowsForms.Markers;
//using GMap.NET.MapProviders;

//using System.Security;
//using System.IO;
//using KmlParseLib;

namespace kmlViewer
{
    class RadarPolygon : GMapPolygon
    {
        public Radar radar { get; set; }

        public RadarPolygon(Radar radar, List<PointLatLng> points, string name) : base(points, name)
        {
            this.radar = radar;
        }
    }
}
