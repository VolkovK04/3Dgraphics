using System;

namespace _3Dgraphics
{
    public struct Vec2
    {
        public static Vec2 FromArg(double Mod, double Arg)
        {
            return new Vec2(Mod * Math.Cos(Arg), Mod * Math.Sin(Arg));
        }

        public Vec2(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public double X { get; set; }
        public double Y { get; set; }

        public double Mod()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
        public double Arg()
        {
            return Math.Atan2(Y, X);
        }

        public void MaxMod(double maxMod)
        {
            Vec2 result = Math.Min(maxMod, Mod()) * Norm();
            X = result.X;
            Y = result.Y;
        }
        public Vec2 Norm()
        {
            if (Mod() == 0)
                return new Vec2();
            return this / Mod();
        }

        static public Vec2 operator +(Vec2 v1, Vec2 v2)
        {
            return new Vec2(v1.X + v2.X, v1.Y + v2.Y);
        }
        static public Vec2 operator -(Vec2 v1, Vec2 v2)
        {
            return new Vec2(v1.X - v2.X, v1.Y - v2.Y);
        }
        static public Vec2 operator *(Vec2 v, double k)
        {
            return new Vec2(v.X * k, v.Y * k);
        }
        static public Vec2 operator *(double k, Vec2 v)
        {
            return new Vec2(v.X * k, v.Y * k);
        }
        static public Vec2 operator /(Vec2 v, double k)
        {
            return new Vec2(v.X / k, v.Y / k);
        }
        static public Vec2 operator -(Vec2 v)
        {
            return new Vec2(-v.X, -v.Y);
        }
    }
}
