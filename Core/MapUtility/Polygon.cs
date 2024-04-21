using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
namespace Core.MapUtility
{
    /// <summary>
    /// Polygon
    /// </summary>
    public class Polygon : IShape
    {
        private List<Coordinate> points = new List<Coordinate>();
        /// <summary>
        /// Danh sách các đỉnh
        /// </summary>
        public List<Coordinate> Points
        {
            get { return points; }
            set { points = value; }
        }

        /// <summary>
        /// Kiểm tra xem một điểm có nằm ở trong hay không
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool IsPointIn(Coordinate point)
        {
            bool isIn = false;

            int i, j = 0;
            for (i = 0, j = Points.Count - 1; i < Points.Count; j = i++)
            {
                if (((Points[i].Longitude <= point.Longitude && point.Longitude < Points[j].Longitude) || (Points[j].Longitude <= point.Longitude && point.Longitude < Points[i].Longitude)) &&
                    (point.Latitude < (Points[j].Latitude - Points[i].Latitude) * (point.Longitude - Points[i].Longitude) / (Points[j].Longitude - Points[i].Longitude) + Points[i].Latitude))
                {
                    isIn = !isIn;
                }
            }

            return isIn;
        }

        private Coordinate center = null;
        /// <summary>
        /// Tâm polygon
        /// </summary>
        public Coordinate Center
        {
            get
            {
                if (points.Count == 0) return null;
                if (center == null)
                {
                    int index = points.Count - 1;
                    if (points[0].Latitude == points[index].Latitude && points[0].Longitude == points[index].Longitude)
                    {
                        var pp = points.ToList(); pp.RemoveAt(index);
                        center = new Coordinate(pp.Average(p => p.Longitude), points.Average(p => p.Latitude));
                    }
                    else
                    {
                        center = new Coordinate(points.Average(p => p.Longitude), points.Average(p => p.Latitude));
                    }
                }
                return center;
            }
        }

        /// <summary>
        /// Convert một string ra polygon
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static implicit operator Polygon(string str)
        {
            // nếu str rỗng thì làm gì có polygon mà tạo
            if (str.IsNull()) return new Polygon();

            // Tọa độ đỉnh
            var points = str.Split(',').Where(p => p.IsNotNull()).Select<string, Coordinate>(p => p).Where(p => p.IsNotNull()).ToList();

            // Kiểm tra điểm đầu vào điểm cuối.
            if (points.Count > 2)
            {
                int index = points.Count - 1;
                if (points[0].Latitude != points[index].Latitude || points[0].Longitude != points[index].Longitude)
                    points.Add(new Coordinate(points[0].Latitude, points[0].Longitude));
            }

            // return polygon
            return points.Count == 0 ? new Polygon() : new Polygon { Points = points };
        }
    }
}
