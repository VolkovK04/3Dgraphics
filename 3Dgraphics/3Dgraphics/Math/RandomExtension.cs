using System;
using System.Drawing;

namespace _3Dgraphics
{
    public static class RandomExtension
    {
        public static Color GetNextColor(this Random random)
        {
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }
    }
}
