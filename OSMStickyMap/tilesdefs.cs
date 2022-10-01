﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMStickyMap
{
    public struct Tile
    {
        public int x;
        public int x_size;
        public int y;
        public int y_size;
        public int pixelx;
        public int pixely;
        public int zoom;
        public string name;
    }

    public struct TileBlock
    {
        public int x;
        public int y;
        public int pixelx;
        public int pixely;
        public double lat;
        public double lon;
        public int zoom;
        public string name;
    }

    public struct LatLon
    {
        public float lat;
        public float lon;
        public int zoom;

    }

    public struct OSMXY
    {
        public int x;
        public int y;
        public int zoom;
    }
}
