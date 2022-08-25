using System.Drawing;

namespace _3Dgraphics
{
    class Polygon
    {
        public Polygon(params Point3[] points)
        {
            this.Points = points;
        }
        public Point3[] Points { get; }
        public Color Color { get; set; } = Color.Transparent;


    }
}
