using System.Drawing;

namespace _3Dgraphics
{
    public struct Size
    {
        public static implicit operator System.Drawing.Size(Size size)
        {
            return new System.Drawing.Size(size.Width, size.Height);
        }
        public static implicit operator Size(System.Drawing.Size size)
        {
            return new Size(size.Width, size.Height);
        }
        
        public static explicit operator Bitmap(Size size)
        {
            return new Bitmap(size.Width, size.Height);
        }

        public Size(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
