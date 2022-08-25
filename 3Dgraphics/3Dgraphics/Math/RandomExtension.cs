using System;
using System.Drawing;

namespace _3Dgraphics
{
    public static class RandomExtension
    {
        static public Color NextColor(this Random random)
        {
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }
        //static public Point3 NextPoint(this Random random, Size MapSize)
        //{
        //    return new Point3(random.NextDouble() * MapSize.Width, random.NextDouble() * MapSize.Height);
        //}
        //static public Vec3 NextVec(this Random random)
        //{
        //    return Vec3.FromArg(1, random.NextDouble() * 2 * Math.PI);
        //}

    }
}
