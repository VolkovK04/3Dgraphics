namespace _3Dgraphics
{
    public struct Point3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Point3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public float GetSquareDistance(Point3 p2)
        {
            return (p2 - this).GetSquareLength();
        }

        public float GetDistance(Point3 p2)
        {
            return (p2 - this).GetLength();
        }

        public float GetSquareDistance(Polygon polygon)
        {
            float r = 0;
            for (int i = 0; i < polygon.Points.Length; i++)
            {
                r += GetSquareDistance(polygon.Points[i]);
            }
            return r / polygon.Points.Length;
        }

        public float GetDistance(Polygon polygon)
        {
            float r = 0;
            for (int i = 0; i < polygon.Points.Length; i++)
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
