using System;

namespace _3Dgraphics
{
    public struct Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public static Vector2 FromArg(double Mod, double Arg)
        {
            return new Vector2(Mod * Math.Cos(Arg), Mod * Math.Sin(Arg));
        }

        public double GetMagnitude()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
        public double Arg()
        {
            return Math.Atan2(Y, X);
        }

        public void MaxMod(double maxMod)
        {
            Vector2 result = Math.Min(maxMod, GetMagnitude()) * Normalized();
            X = result.X;
            Y = result.Y;
        }
        public Vector2 Normalized()
        {
            if (GetMagnitude() == 0)
                return new Vector2();
            return this / GetMagnitude();
        }

        static public Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }
        static public Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }
        static public Vector2 operator *(Vector2 v, double k)
        {
            return new Vector2(v.X * k, v.Y * k);
        }
        static public Vector2 operator *(double k, Vector2 v)
        {
            return new Vector2(v.X * k, v.Y * k);
        }
        static public Vector2 operator /(Vector2 v, double k)
        {
            return new Vector2(v.X / k, v.Y / k);
        }
        static public Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.X, -v.Y);
        }
    }
}
