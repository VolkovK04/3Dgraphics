using System;

namespace _3Dgraphics
{
    public struct Vector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public Vector3 Rotate(double fi, double teta)
        {
            Vector3 v1 = new Vector3();

            double sin = Math.Sin(fi);
            double cos = Math.Cos(fi);
            v1.X = X * cos + Z * sin;
            v1.Z = Z * cos - X * sin;
            v1.Y = Y;

            this = v1; //жесть

            sin = Math.Sin(teta);
            cos = Math.Cos(teta);
            v1.X = X;
            v1.Y = Y * cos - Z * sin;
            v1.Z = Z * cos + Y * sin;

            return v1;
        }
        public double GetMagnitude()
        {
            return Math.Sqrt(X*X+Y*Y+Z*Z);
        }

        public void MaxMod(double maxMod)
        {
            this = Math.Min(maxMod, GetMagnitude()) * Normalized(); //жесть
        }
        public Vector3 Normalized()
        {
            if (GetMagnitude() == 0)
                return new Vector3(); //undefined
            return this / GetMagnitude();
        }

        static public Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        static public Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z + v2.Z);
        }
        static public Vector3 operator *(Vector3 v, double k)
        {
            return new Vector3(v.X * k, v.Y * k, v.Z * k);
        }
        static public Vector3 operator *(double k, Vector3 v)
        {
            return new Vector3(v.X * k, v.Y * k, v.Z * k);
        }
        static public Vector3 operator /(Vector3 v, double k)
        {
            return new Vector3(v.X / k, v.Y / k, v.Z / k);
        }
        static public Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.X, -v.Y, -v.Z);
        }
        static public double operator *(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

    }
}
