using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OSMStickyMap
{
    public class GmapMarkerWithLabel : GMarkerGoogle, ISerializable
    {
        private readonly Font _font;
        private GMarkerGoogle _innerMarker;
        private readonly string _caption;
        private static Bitmap BitmapMarker = Properties.Resources.TransImg;
        public GmapMarkerWithLabel(PointLatLng p, string caption)
            : base(p, BitmapMarker)
        {
            _font = new Font("Arial", 11, FontStyle.Bold);
            _innerMarker = new GMarkerGoogle(p, BitmapMarker);

            _caption = caption;
        }

        public override void OnRender(Graphics g)
        {
            base.OnRender(g);

            var stringSize = g.MeasureString(_caption, _font);
            var localPoint = new PointF(LocalPosition.X - stringSize.Width / 2, LocalPosition.Y + stringSize.Height);
            g.DrawString(_caption, _font, Brushes.Black, localPoint);
        }

        public override void Dispose()
        {
            if (_innerMarker != null)
            {
                _innerMarker.Dispose();
                _innerMarker = null;
            }

            base.Dispose();
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }

        protected GmapMarkerWithLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
}
