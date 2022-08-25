using System;
using System.Drawing;

namespace _3Dgraphics
{
    public struct Point2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point2 InMap(Size size)
        {
            double x = Math.Min(Math.Max(X, 0), size.Width);
            double y = Math.Min(Math.Max(Y, 0), size.Height);
            if (double.IsNaN(x) || double.IsNaN(y))
                throw new Exception("NaN position");
            return new Point2(x, y);
        }
        public double GetDistance(Point2 p2)
        {
            return (p2 - this).GetMagnitude();
        }

        public static implicit operator Point(Point2 point)
        {
            return new Point((int)point.X, (int)point.Y);
        }
        public static implicit operator Point2(Point point)
        {
            return new Point2(point.X, point.Y);
        }
        public static Point2 operator +(Point2 p, Vector2 v)
        {
            return new Point2(p.X+v.X, p.Y+v.Y);
        }
        public static Point2 operator -(Point2 p, Vector2 v)
        {
            return new Point2(p.X - v.X, p.Y - v.Y);
        }
        public static Vector2 operator -(Point2 p1, Point2 p2)
        {
            return new Vector2(p1.X - p2.X, p1.Y - p2.Y);
        }
    }
}
