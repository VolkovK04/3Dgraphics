using System.Drawing;
using System.Collections.Generic;
using System;

namespace _3Dgraphics
{
    static class Drawing
    {
        private static readonly Comparison<Polygon> PolygonComparison = (Polygon p1, Polygon p2) => (int)(Camera.Position.DistanceTo(p2) - Camera.Position.DistanceTo(p1));

        static public void Draw3DPolygon(this Graphics graphics, Polygon polygon)
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

            graphics.FillPolygon(new SolidBrush(polygon.Color), points.ToArray());
            graphics.DrawPolygon(new Pen(Color.Black), points.ToArray());
        }
        
        static public void Draw3DPolygons(this Graphics graphics, List<Polygon> polygons)
        {
            polygons.Sort(PolygonComparison);
            foreach (Polygon polygon in polygons)
            {
                graphics.Draw3DPolygon(polygon);
            }
        }
        
        static public void DrawScene(this Graphics graphics, Scene scene)
        {
            List<Polygon> polygons = new List<Polygon>();
            foreach(Object3 object3 in scene.Objects)
            {
                for (int i=0; i<object3.Faces.Length; i++)
                {
                    polygons.Add(object3.Faces[i]);
                }
            }

            graphics.Clear(Color.White);
            graphics.Draw3DPolygons(polygons);
        }
    }
}
