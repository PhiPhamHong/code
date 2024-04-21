using System;
namespace Core.MapUtility
{
    public static class MapHelper
    {        
        private const double _MilesToNautical = 0.8684;

        /// <summary>
        /// Converts degrees to Radians.
        /// </summary>
        /// <returns>Returns a radian from degrees.</returns>
        public static double ToRadian(this double degree) { return (degree * Math.PI / 180.0); }
        /// <summary>
        /// To degress from a radian value.
        /// </summary>
        /// <returns>Returns degrees from radians.</returns>
        public static double ToDegree(this double radian) { return (radian / Math.PI * 180.0); }

        /// <summary>
        /// Calculates the distance between two points of latitude and longitude.
        /// Great Link - http://www.movable-type.co.uk/scripts/latlong.html
        /// </summary>
        /// <param name="coordinate1">First coordinate.</param>
        /// <param name="coordinate2">Second coordinate.</param>
        /// <param name="unitsOfLength">Sets the return value unit of length.</param>
        public static double Distance(double _OldLongitude, double _OldLatitude, double Longitude, double Latitude, UnitsOfLength unitsOfLength)
        {
            if (_OldLongitude == 0 || _OldLatitude == 0 || Longitude == 0 || Latitude == 0) return 0;
            if (_OldLongitude == Longitude && _OldLatitude == Latitude) return 0;

            var theta = _OldLongitude - Longitude;
            var distance = Math.Sin(_OldLatitude.ToRadian()) * Math.Sin(Latitude.ToRadian()) +
                           Math.Cos(_OldLatitude.ToRadian()) * Math.Cos(Latitude.ToRadian()) *
                           Math.Cos(theta.ToRadian());

            distance = Math.Acos(distance).ToDegree() * 60 * 1.1515;

            switch (unitsOfLength)
            {
                case UnitsOfLength.Kilometer: return distance * Constant.MilesToKilometers;
                case UnitsOfLength.NauticalMiles: return distance * Constant.MilesToNautical;
                default: return distance;
            }
        }

        /// <summary>
        /// check điểm trong hình chữ nhật
        /// chính là hình chữ nhật ngoại tiếp đường tròn
        /// </summary>
        /// <param name="point">điểm cần check</param>
        /// <param name="radius">bán kính</param>
        /// <param name="center">tâm đường tròn</param>
        /// <returns></returns>
        public static bool CheckPointInRectangle(Coordinate point, Coordinate center, double radius)
        {
            double deltaLat = radius * Constant.DeltaCoordinate;  // độ rộng vĩ độ            
            double deltaLng = deltaLat / (Math.Cos(center.Latitude * Math.PI / 180)); // độ rộng vĩ độ            
            if (point.Latitude > center.Latitude + deltaLat || point.Latitude < center.Latitude - deltaLat) return false; // check điểm có nằm trong khoảng vĩ độ
            return !(point.Longitude > center.Longitude + deltaLng || point.Longitude < center.Longitude - deltaLng); // check điểm có nằm trong khoảng kinh độ

        }

        /// <summary>
        /// Hàm kiểm tra một điểm có nằm trong một đa giác hay không
        /// theo thuật toán xét xe nằm trên hay dưới đường thẳng của đa giac
        /// </summary>
        /// <param name="point">điểm cần check</param>
        /// <param name="polygon">list điểm của đa giác</param>
        /// <returns></returns>
        public static bool CheckPointInsidePolygon(Coordinate point, Coordinate[] polygon)
        {
            int cn = 0;
            for (int i = 0; i < polygon.Length - 1; i++)
            {
                if (((polygon[i].Longitude <= point.Longitude) && (polygon[i + 1].Longitude > point.Longitude))
                 || ((polygon[i].Longitude > point.Longitude) && (polygon[i + 1].Longitude <= point.Longitude)))
                {
                    double vt = (point.Longitude - polygon[i].Longitude) / (polygon[i + 1].Longitude - polygon[i].Longitude);
                    if (point.Latitude < polygon[i].Latitude + vt * (polygon[i + 1].Latitude - polygon[i].Latitude))
                        ++cn;
                }
            }
            return ((cn & 1) == 1);
            // 0 if even (out), and 1 if odd (in)
        }

        /// <summary>
        /// XÁc định hướng
        /// </summary>
        public static byte Bearing(double Distance, byte _OldBearing, double _OldLongitude, double _OldLatitude, double Longitude, double Latitude)
        {
            //If longitude and latitude are not valid, don't change car's direction
            if (Longitude == 0 | Latitude == 0) return _OldBearing;

            //If distance between two cars is too small, retur old Bearing
            if (Distance < 0.02) return _OldBearing;            

            byte _Bearing = 0;
            //Calculate new direction
            double DeltaX = Latitude - _OldLatitude;
            double DeltaY = Longitude - _OldLongitude;
            double S = Math.Sqrt(Math.Pow(DeltaX, 2) + Math.Pow(DeltaY, 2));
            double G = Math.Acos(DeltaX / S);
            if (DeltaY < 0) G = 2 * Math.PI - G;
            G = Math.Round(4 * G / Math.PI);
            if (G > 7 || G < 0) G = 0;

            try
            { _Bearing = (byte)G; }
            catch
            { _Bearing = 0; }

            return _Bearing;
        }

        public static byte Bearing(double distance, byte oldBearing, Coordinate old, Coordinate now)
        {
            return Bearing(distance, oldBearing, old.Longitude, old.Latitude, now.Longitude, now.Latitude);
        }

        public class Constant
        {
            public const int EarthRadius = 6380000; // bán kính trái đất        
            public const double DeltaCoordinate = 0.0000089805297042448772; // hằng số delta tọa độ: delta= 180/pi*R(bán kính trái đất)
            public const double MilesToKilometers = 1.609344;
            public const double MilesToNautical = 0.8684;
        }
    }

    public enum UnitsOfLength
    {
        Kilometer,
        NauticalMiles
    }
}
