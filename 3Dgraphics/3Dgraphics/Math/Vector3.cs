using System;

namespace _3Dgraphics
{
    public struct Vector3
    {
        public enum Axis { X, Y, Z }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public void Rotate(float fi, float teta)
        {
            RotateAxis(fi, Axis.Y);
            RotateAxis(teta, Axis.X);
        }
        public void RotateAxis(float angle, Axis axis)
        {
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);
            float a;
            switch (axis)
            {
                case Axis.X:
                    a = Y;
                    Y = Y * cos - Z * sin;
                    Z = Z * cos + a * sin;
                    break;
                case Axis.Y:
                    a = X;
                    X = X * cos + Z * sin;
                    Z = Z * cos - a * sin;
                    break;
                case Axis.Z:
                    a = X;
                    X = X * cos - Y * sin;
                    Y = Y * cos + a * sin;
                    break;
            }
        }
        public float GetSquareLength()
        {
            return X * X + Y * Y + Z * Z;
        }

        public float GetLength()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector3 Normalized()
        {
            if (GetLength() == 0)
                return new Vector3(); //undefined
            return this / GetLength();
        }

        static public Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        static public Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z + v2.Z);
        }
        static public Vector3 operator *(Vector3 v, float k)
        {
            return new Vector3(v.X * k, v.Y * k, v.Z * k);
        }
        static public Vector3 operator *(float k, Vector3 v)
        {
            return new Vector3(v.X * k, v.Y * k, v.Z * k);
        }
        static public Vector3 operator /(Vector3 v, float k)
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
