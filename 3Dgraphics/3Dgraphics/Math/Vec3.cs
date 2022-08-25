using System;

namespace _3Dgraphics
{
    public struct Vec3
    {
        public Vec3(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vec3 Rotate(double fi, double teta)
        {
            Vec3 v1=new Vec3();

            double sin = Math.Sin(fi);
            double cos = Math.Cos(fi);
            v1.X = X * cos + Z * sin;
            v1.Z = Z * cos - X * sin;
            v1.Y = Y;

            this = v1;

            sin = Math.Sin(teta);
            cos = Math.Cos(teta);
            v1.X = X;
            v1.Y = Y * cos - Z * sin;
            v1.Z = Z * cos + Y * sin;

            return v1;
        }
        public double Mod()
        {
            return Math.Sqrt(X*X+Y*Y+Z*Z);
        }

        public void MaxMod(double maxMod)
        {
            this  = Math.Min(maxMod, Mod()) * Norm();
        }
        public Vec3 Norm()
        {
            if (Mod() == 0)
                return new Vec3(); //undefined
            return this / Mod();
        }

        static public Vec3 operator +(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        static public Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.X - v2.X, v1.Y - v2.Y, v1.Z + v2.Z);
        }
        static public Vec3 operator *(Vec3 v, double k)
        {
            return new Vec3(v.X * k, v.Y * k, v.Z * k);
        }
        static public Vec3 operator *(double k, Vec3 v)
        {
            return new Vec3(v.X * k, v.Y * k, v.Z * k);
        }
        static public Vec3 operator /(Vec3 v, double k)
        {
            return new Vec3(v.X / k, v.Y / k, v.Z / k);
        }
        static public Vec3 operator -(Vec3 v)
        {
            return new Vec3(-v.X, -v.Y, -v.Z);
        }
        static public double operator *(Vec3 v1, Vec3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

    }
}
