using System.Drawing;
using System.Collections.Generic;
using System;
using System.Linq;

namespace _3Dgraphics
{
    public static class GraphicsExtensions
    {
        private static readonly Comparison<Polygon> PolygonComparison = 
            (Polygon p1, Polygon p2) => (int)(Camera.Position.GetSquareDistance(p2) - Camera.Position.GetSquareDistance(p1));

        public static void Draw3DPolygon(this Graphics graphics, Polygon polygon)
        {
            List<Point> points = new List<Point>();
            for (int i=0; i< polygon.Points.Length; i++)
            {
                Point point = Camera.ToScrean(polygon.Points[i], out bool inScrean);
                if (inScrean)
                    points.Add(point);
            }
            if (points.Count < 2)
                return;

            //graphics.FillPolygon(new SolidBrush(polygon.Color), points.ToArray());
            graphics.DrawPolygon(new Pen(Color.Black), points.ToArray());
        }
        
        public static void Draw3DPolygons(this Graphics graphics, List<Polygon> polygons)
        {
            polygons.Sort(PolygonComparison);
            foreach (Polygon polygon in polygons)
            {
                graphics.Draw3DPolygon(polygon);
            }
        }
        public static void DrawScene(this Graphics graphics, Scene scene)
        {
            List<Polygon> polygons = scene.Objects.SelectMany(object3 => object3.Faces).ToList();
            graphics.Clear(Color.White);
            graphics.Draw3DPolygons(polygons);
        }
    }
}
