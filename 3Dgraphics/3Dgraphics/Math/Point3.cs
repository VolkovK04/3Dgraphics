using System;

namespace _3Dgraphics
{
    public struct Point3 
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double GetSquareDistance(Point3 p2)
        {
            return (p2 - this).GetLength();
        }

        public double GetDistance(Point3 p2)
        {
            return (p2 - this).GetLength();
        }

        public double GetSquareDistance(Polygon polygon)
        {
            double r = 0;
            for (int i = 0; i < polygon.Points.Length; i++)
            {
                r += GetSquareDistance(polygon.Points[i]);
            }
            return r / polygon.Points.Length;
        }

        public double GetDistance(Polygon polygon)
        {
            double r = 0;
            for (int i=0; i<polygon.Points.Length; i++)
            {
                r += GetDistance(polygon.Points[i]);
            }
            return r / polygon.Points.Length;
        }

        public static Point3 operator +(Point3 p, Vector3 v)
        {
            return new Point3(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
        }
        public static Point3 operator -(Point3 p, Vector3 v)
        {
            return new Point3(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
        }
        public static Vector3 operator -(Point3 p1, Point3 p2)
        {
            return new Vector3(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

    }
}
