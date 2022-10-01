using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;


//using GMap.NET;
using GMap.NET.WindowsForms;
//using GMap.NET.WindowsForms.Markers;
//using GMap.NET.MapProviders;
//using System.IO;
//using KmlParseLib;
using GMap.NET.ObjectModel;

namespace kmlViewer
{
    class RadarOverlay : GMapOverlay
    {
        public ObservableCollectionThreadSafe<Radar> Radars;

        public RadarOverlay() : base()
        {
        }

        public RadarOverlay(string id) : base(id)
        {
            Radars = new ObservableCollectionThreadSafe<Radar>();
        }
    }
}
