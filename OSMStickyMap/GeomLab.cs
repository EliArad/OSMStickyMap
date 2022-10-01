using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GMap.NET;
//using GMap.NET.WindowsForms;
//using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
//using System.IO;
//using KmlParseLib;

namespace kmlViewer
{
    class GeomLab
    {
        const double RADKM = 6371.0088;  // Earth's radius in kilometers

        public static void calculateBeamEndPosition(double lat, double lon, double range, double azimuth, out double latC, out double lonC)
        {
            if (azimuth < 0)
                azimuth = 360 + azimuth;

            int sign = (azimuth > 0 && azimuth <= 180) ? -1 : 1;

            double latBx = getLatB(lat, -range);
            latC = getLatC(lat, latBx, azimuth);
            lonC = getLonC((90 - lat), (90 - latC), (latBx - lat), lon, sign);
        }

        public static double deltaMetric(double latA, double latB, double lonA, double lonB)
        {
            int sign = latA >= latB ? -1 : 1;
            latA = latA * Math.PI / 180;
            latB = latB * Math.PI / 180;
            lonA = lonA * Math.PI / 180;
            lonB = lonB * Math.PI / 180;

            //	cout << sin(latA) * sin(latB) << endl;
            //	cout << cos(latA) * cos(latB) << endl;
            return sign * RADKM * Math.Acos(Math.Sin(latA) * Math.Sin(latB) + Math.Cos(latA) * Math.Cos(latB) * Math.Cos(lonA - lonB));
        }

        public static double getLatB(double latA, double range)
        {
            // given the first latitude and the distance in km find the second latitude in deg:
            //int sign = range >= 0 ? 1 : -1;
            int sign = -1;
            latA = latA * Math.PI / 180;

            double Q = Math.Cos(range / RADKM);
            // double P = sin(latA);
            // double R = cos(latA);
            // double K = P / Q;
            double K = Math.Sin(latA) / Q;
            // double L = R / Q;
            double L = Math.Cos(latA) / Q;
            double A = K * K + L * L;
            double B = -2 * K;
            double C = 1 - L * L;
            double latB = (-B + sign * Math.Sqrt(B * B - 4 * A * C)) / 2 / A;
            return Math.Asin(latB) * 180 / Math.PI;
        }

        public static double getLatC(double latA, double latB, double azimuth)
        {
            // rotate delta latitude to the angle of azimuth and find the latitude of the resulting point in deg:
            double a = 90 - latA;
            double b = latB - latA;
            a = a * Math.PI / 180;
            b = b * Math.PI / 180;
            azimuth = azimuth * Math.PI / 180;

            // find the side of a triangle by two sides & angle between them
            double c = Math.Acos(Math.Cos(a) * Math.Cos(b) - Math.Sin(a) * Math.Sin(b) * Math.Cos(azimuth));
            c = c * 180 / Math.PI;
            return 90 - c;
        }

        public static double getLonC(double a, double b, double c, double lonA, int sign)
        {
            //int sign = azimuth >= 0 ? 1 : -1;
            // if east from meridian:
            // int sign = (azimuth >= 0 || azimuth <= 180) ? 1 : -1;
            // rotate delta latitude to the angle of azimuth and find the longitude of the resulting point in deg:
            a = a * Math.PI / 180;
            b = b * Math.PI / 180;
            c = c * Math.PI / 180;
            // find the angle of a triangle by known 3 sides:
            double f = ((Math.Cos(c) - Math.Cos(a) * Math.Cos(b)) / Math.Sin(a) / Math.Sin(b));
            if (f > 1.0)
                f = 1.0;
            double gamma = Math.Acos(f);
            gamma = gamma * 180 / Math.PI;
            return lonA - gamma * sign;
        }

        public static void calculateArcPoints(double cntrLat, double cntrLon, double radius, double angle, double deltaAngle, List<PointLatLng> points)
        {
            if (angle < 0)
                angle = 360 + angle;

            double latCx;
            double lonCx;
            calculateBeamEndPosition(cntrLat, cntrLon, radius, angle, out latCx, out lonCx);

            for (int i = 0; i < deltaAngle * 10; i++)
            {
                angle += 0.1;
                if (angle > 360)
                    angle -= 360;
                calculateBeamEndPosition(cntrLat, cntrLon, radius, angle, out latCx, out lonCx);
                points.Add(new PointLatLng(latCx, lonCx));
            }
        }

        public static void setTransparency(byte alpha, ref int argb)
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
    }
}
