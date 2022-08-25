using System;
using System.Drawing;

namespace _3Dgraphics
{
    static class Camera
    {
        static public event Action OnMove;
        static public event Action OnRotate;
        static public event Action ScreenSizeChanged;
        static public event Action FovChanged;


        static public double FOV { get; private set; } = Math.PI / 2;
        static public Size ScreenSize { get; private set; }
        static public Point3 Position { get; private set; }

        static private double DistanceToScreen;
        static private double fi = 0;
        static private double teta = 0;

        static public void SetScreenSize(Size ScreenSize)
        {
            Camera.ScreenSize = ScreenSize;
            DistanceToScreen = ScreenSize.Width / Math.Tan(FOV / 2);

            ScreenSizeChanged?.Invoke();
        }
        static public void SetFov(double FOV)
        {
            Camera.FOV = FOV;
            DistanceToScreen = ScreenSize.Width / Math.Tan(FOV / 2);

            FovChanged?.Invoke();
        }

        static public void Move(Vec3 velosity)
        {
            Position += velosity.Rotate(fi, 0);
            OnMove?.Invoke();
        }

        static public void Rotate(Vec2 vec)
        {
            fi += Math.Atan2(vec.X, DistanceToScreen);
            teta += Math.Atan2(vec.Y, DistanceToScreen);
            OnRotate?.Invoke();
        }
        public static Point2 ToScrean(Point3 point, out bool InScrean)
        {
            InScrean = false;
            Vec3 p = (point - Position).Rotate(-fi, -teta);
            if (p.Z > 0)
            {
                Vec3 r = DistanceToScreen / p.Z * p;
                //if (Math.Abs(r.X)< ScreenSize.Width / 2.0 && Math.Abs(r.Y) < ScreenSize.Height/2.0)
                InScrean = true;
                return new Point2((int)(ScreenSize.Width / 2.0 + r.X), (int)(ScreenSize.Height / 2.0 - r.Y));
            }
            return new Point2();
        }

    }
}
