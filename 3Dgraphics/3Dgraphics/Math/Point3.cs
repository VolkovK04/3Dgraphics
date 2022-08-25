using System;

namespace _3Dgraphics
{
    struct Point3
    {
        public Point3(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        static public Point3 operator +(Point3 p, Vec3 v)
        {
            return new Point3(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
        }
        static public Point3 operator -(Point3 p, Vec3 v)
        {
            return new Point3(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
        }
        static public Vec3 operator -(Point3 p1, Point3 p2)
        {
            return new Vec3(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        //public Point3 InMap(Size size)
        //{
        //    double x = Math.Min(Math.Max(X, 0), size.Width);
        //    double y = Math.Min(Math.Max(Y, 0), size.Height);
        //    if (double.IsNaN(x) || double.IsNaN(y))
        //        throw new Exception("NaN position");
        //    return new Point3(x, y, z);
        //}
        public double DistanceTo(Point3 p2)
        {
            return (p2 - this).Mod();
        }

        public double DistanceTo(Polygon polygon)
        {
            double r = 0;
            for (int i=0; i<polygon.Points.Length; i++)
            {
                r += DistanceTo(polygon.Points[i]);
            }
            return r / polygon.Points.Length;
        }

    }
}
