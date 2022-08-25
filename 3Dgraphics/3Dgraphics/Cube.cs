namespace _3Dgraphics
{
    class Cube : Object3
    {
        public Cube(Point3 Position, double Size=10)
        {
            this.Position = Position;
            this.Size = Size;
            Faces = new Polygon[6];

            Point3[] p = new Point3[8];

            p[0] = new Point3(Position.X, Position.Y, Position.Z);
            p[1] = new Point3(Position.X + Size, Position.Y, Position.Z);
            p[2] = new Point3(Position.X, Position.Y + Size, Position.Z);
            p[3] = new Point3(Position.X + Size, Position.Y + Size, Position.Z);
            p[4] = new Point3(Position.X, Position.Y, Position.Z + Size);
            p[5] = new Point3(Position.X + Size, Position.Y, Position.Z + Size);
            p[6] = new Point3(Position.X, Position.Y + Size, Position.Z + Size);
            p[7] = new Point3(Position.X + Size, Position.Y + Size, Position.Z + Size);

            Faces[0] = new Polygon(p[0], p[1], p[3], p[2]);
            Faces[1] = new Polygon(p[0], p[1], p[5], p[4]);
            Faces[2] = new Polygon(p[0], p[2], p[6], p[4]);
            Faces[3] = new Polygon(p[1], p[3], p[7], p[5]);
            Faces[4] = new Polygon(p[2], p[3], p[7], p[6]);
            Faces[5] = new Polygon(p[4], p[5], p[7], p[6]);

        }
        public Point3 Position { get; set; }
        public double Size { get; set; }
    }
}
