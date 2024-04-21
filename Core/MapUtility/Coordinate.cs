using Core.Extensions;
using System;
namespace Core.MapUtility
{
    /// <summary>
    /// định nghĩa tọa độ điểm
    /// </summary>
    public class Coordinate : IComparable<Coordinate>
    {
        /// <summary>
        /// Convert một str ra tọa độ
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static implicit operator Coordinate(string str)
        {
            if (str.IsNull()) return null;
            var latlng = str.Split(' ');
            if (latlng.Length != 2) return null;
            return new Coordinate(Convert.ToSingle(latlng[0]), Convert.ToSingle(latlng[1]));
        }

        public float Longitude { get; private set; }
        public float Latitude { get; private set; }

        /// <summary>
        /// khởi tạo điểm
        /// </summary>
        /// <param name="lng">kinh độ</param>
        /// <param name="lat">vĩ độ</param>
        public Coordinate(float lat, float lng)
        {
            Longitude = lng;
            Latitude = lat;
        }

        public override string ToString()
        {
            return Latitude + " " + Longitude;
        }

        public int CompareTo(Coordinate other)
        {
            if (this.Latitude > other.Latitude) return 1;
            if (this.Latitude < other.Latitude) return -1;
            else return 0;
        }

        /// <summary>
        /// Kinh độ và vĩ độ có thỏa mãn hay không
        /// </summary>
        public bool IsEmpty
        {
            get { return Longitude == 0 || Latitude == 0; }
        }

        /// <summary>
        /// Tính khoảng cách giữa 2 điểm
        /// </summary>
        public static double operator -(Coordinate c1, Coordinate c2)
        {
            return MapHelper.Distance(c1.Longitude, c1.Latitude, c2.Longitude, c2.Latitude, UnitsOfLength.Kilometer);
        }

        public static readonly Coordinate Empty = new Coordinate(0, 0);

        public bool IsBetween(Coordinate min, Coordinate max)
        {
            return min.Latitude <= Latitude && Latitude <= max.Latitude &&
                   min.Longitude <= Longitude && Longitude <= max.Longitude;
        }
    }
}
