using System;
using System.Drawing;

namespace _3Dgraphics
{
    public static class Camera
    {
        public static event Action OnMove;
        public static event Action OnRotate;
        public static event Action ScreenSizeChanged;
        public static event Action FovChanged;

        public static double FieldOfView { get; private set; } = Math.PI / 2;
        public static Size ScreenSize { get; private set; }
        public static Point3 Position { get; private set; }

        private static double distanceToScreen;
        private static double fi = 0;
        private static double teta = 0;

        static public void SetScreenSize(Size ScreenSize)
        {
            Camera.ScreenSize = ScreenSize;
            distanceToScreen = ScreenSize.Width / Math.Tan(FieldOfView / 2);

            ScreenSizeChanged?.Invoke();
        }
        static public void SetFov(double FOV)
        {
            Camera.FieldOfView = FOV;
            distanceToScreen = ScreenSize.Width / Math.Tan(FOV / 2);

            FovChanged?.Invoke();
        }

        static public void Move(Vector3 velosity)
        {
            Position += velosity.Rotate(fi, 0);
            OnMove?.Invoke();
        }

        static public void Rotate(Vector2 vec)
        {
            fi += Math.Atan2(vec.X, distanceToScreen);
            teta += Math.Atan2(vec.Y, distanceToScreen);
            OnRotate?.Invoke();
        }
        public static Point2 ToScrean(Point3 point, out bool InScrean)
        {
            InScrean = false;
            Vector3 p = (point - Position).Rotate(-fi, -teta);
            if (p.Z > 0)
            {
                Vector3 r = distanceToScreen / p.Z * p;
                //if (Math.Abs(r.X)< ScreenSize.Width / 2.0 && Math.Abs(r.Y) < ScreenSize.Height/2.0)
                InScrean = true;
                return new Point2((int)(ScreenSize.Width / 2.0 + r.X), (int)(ScreenSize.Height / 2.0 - r.Y));
            }
            return new Point2();
        }

    }
}
