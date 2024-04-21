namespace Core.MapUtility
{
    public class Circle : IShape
    {
        /// <summary>
        /// Tâm đường tròn
        /// </summary>
        public Coordinate Center { set; get; }

        /// <summary>
        /// Bán kính
        /// </summary>
        public int Radius { set; get; }

        /// <summary>
        /// Kiểm tra điểm có nằm trong đường tròn hay không
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool IsPointIn(Coordinate point)
        {
            return Center - point <= Radius;
        }
    }
}
