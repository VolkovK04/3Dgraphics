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

        private static float distanceToScreen;
        private static float fi = 0;
        private static float teta = 0;

        static public void SetScreenSize(Size ScreenSize)
        {
            Camera.ScreenSize = ScreenSize;
            distanceToScreen = ScreenSize.Width / (float)Math.Tan(FieldOfView / 2);

            ScreenSizeChanged?.Invoke();
        }
        static public void SetFov(double FOV)
        {
            Camera.FieldOfView = FOV;
            distanceToScreen = ScreenSize.Width / (float)Math.Tan(FOV / 2);

            FovChanged?.Invoke();
        }

        static public void Move(Vector3 velosity)
        {
            velosity.Rotate(fi, 0);
            Position += velosity;
            OnMove?.Invoke();
        }

        static public void Rotate(Vector2 vec)
        {
            fi += (float)Math.Atan2(vec.X, distanceToScreen);
            teta += (float)Math.Atan2(vec.Y, distanceToScreen);
            OnRotate?.Invoke();
        }
        public static Point2 ToScrean(Point3 point, out bool InScrean)
        {
            InScrean = false;
            Vector3 p = point - Position;
            p.Rotate(-fi, -teta);
            if (p.Z > 0)
            {
                Vector3 r = distanceToScreen / p.Z * p;
                InScrean = true;
                return new Point2((int)(ScreenSize.Width / 2.0 + r.X), (int)(ScreenSize.Height / 2.0 - r.Y));
            }
            return new Point2();
        }

    }
}
