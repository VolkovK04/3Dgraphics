using System.Drawing;

namespace _3Dgraphics
{
    public class Polygon
    {
        public Point3[] Points { get; }
        public Color Color { get; set; } = Color.Transparent;

        public Polygon(params Point3[] points)
        {
            Points = points;
        }
    }
}
