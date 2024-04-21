using System;
using System.Collections.Generic;
namespace Core.MapUtility
{
    public class AreaInfor
    {
        public Coordinate Min { private set; get; }
        public Coordinate Max { private set; get; }

        public int Width { private set; get; } // khoảng cách giữa các ô, hay chiều rộng hình chữ nhật nhỏ trong vùng diện tích(đơn vị  chiều dài) mét
        public double LatStep { private set; get; }  // độ lệch vĩ độ, phụ thuộc và độ rộng, đơn vị độ        
        public double LngStep { private set; get; } // độ lệch kinh độ, phụ thuộc và độ rộng


        public int MaxLatIndex { private set; get; }
        public int MaxLngIndex { private set; get; }

        public AreaInfor(Coordinate min, Coordinate max, int width)
        {
            Min = min; Max = max;            
            Width = width;
            LatStep = width * MapHelper.Constant.DeltaCoordinate;
            LngStep = LatStep / Math.Cos(Min.Latitude * Math.PI / 180);

            MaxLatIndex = GetLatIndex(Max.Latitude);
            MaxLngIndex = GetLngIndex(Max.Longitude);
        }

        private int GetLatIndex(double lat)
        {
            return (int)((lat - Min.Latitude) / LatStep);
        }

        private int GetLngIndex(double lng)
        {
            return (int)((lng - Min.Longitude) / LngStep);
        }

        public int GetCell(Coordinate latlng)
        {
            return GetLatIndex(latlng.Latitude) + GetLngIndex(latlng.Longitude) * MaxLatIndex;
        }

        public IEnumerable<int> FindCell(Coordinate min, Coordinate max)
        {
            // Hình chữ nhật ABCD. 
            // A = LatMin,LngMin => Min
            // B = LatMax,LngMin
            // C = LatMax,LngMax => Max
            var b = new Coordinate(max.Latitude, min.Longitude);
            var cellA = GetCell(min);
            var cellB = GetCell(b);
            var cellC = GetCell(max);

            for(var i = cellA; i <= cellB; i++)
            {
                yield return i;
                var index = i + MaxLatIndex;
                while(index <= cellC)
                {
                    yield return index;
                    index += MaxLatIndex;
                }
            }
        }

        public static AreaInfor VNArea = new AreaInfor("8.340809 102.052251", "23.534257 109.536247", 500);
    }
}