using System;

namespace _3Dgraphics
{
    public struct Point2
    {
        public static implicit operator System.Drawing.Point(Point2 point)
        {
            return new System.Drawing.Point((int)point.X, (int)point.Y);
        }
        public static implicit operator Point2(System.Drawing.Point point)
        {
            return new Point2(point.X, point.Y);
        }

        public Point2(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public double X { get; set; }
        public double Y { get; set; }

        static public Point2 operator +(Point2 p, Vec2 v)
        {
            return new Point2(p.X+v.X, p.Y+v.Y);
        }
        static public Point2 operator -(Point2 p, Vec2 v)
        {
            return new Point2(p.X - v.X, p.Y - v.Y);
        }
        static public Vec2 operator -(Point2 p1, Point2 p2)
        {
            return new Vec2(p1.X - p2.X, p1.Y - p2.Y);
        }

        public Point2 InMap(Size size)
        {
            double x = Math.Min(Math.Max(X, 0), size.Width);
            double y = Math.Min(Math.Max(Y, 0), size.Height);
            if (double.IsNaN(x) || double.IsNaN(y))
                throw new Exception("NaN position");
            return new Point2(x, y);
        }
        public double DistanceTo(Point2 p2)
        {
            return (p2 - this).Mod();
        }
    }
}
