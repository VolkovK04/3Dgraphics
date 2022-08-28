using System.Drawing;

namespace _3Dgraphics
{
    public class Polygon
    {
        public Point3[] Points { get; }
        public Color Color { get; set; } = Color.Red;
        public float DistanseToCamera { get; private set; }
        public void CalculateDistanse() => DistanseToCamera = Camera.Position.GetSquareDistance(this);
        public Polygon(params Point3[] points)
        {
            Points = points;
        }
    }
}
