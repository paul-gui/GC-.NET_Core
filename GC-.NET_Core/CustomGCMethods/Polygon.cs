using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomGCMethods;

namespace CustomGCMethods
{
    public class Polygon
    {
        private List<Point> points;
        public bool IsEmpty
        {
            get
            {
                if (points.Count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Polygon()
        {
            points = new List<Point>();
        }

        public Polygon(List<Point> points)
        {
            this.points = new(points);
        }

        public void AddPoint(Point p)
        {
            points.Add(p);
        }

        /// <summary>
        /// Splits the current polygon by the diagonal determined by p1 and p2. The part of the polygon to the left of the diagonal p1p2 remains in the current object and the right part is returned.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>the part of the polygon to the right of p1p2</returns>
        public Polygon SplitPolygon(Point p1, Point p2)
        {
            Polygon currentPolygon = new();
            Polygon resultingPolygon = new();
            if (points.Contains(p1) && points.Contains(p2))
            {
                int indexOfp1 = points.IndexOf(p1);
                int iPlus1 = indexOfp1;
                int f = points.IndexOf(p2);
                bool finished = false;
                int n = points.Count;
                currentPolygon.AddPoint(points[iPlus1]);
                currentPolygon.AddPoint(points[f]);
                do
                {
                    if (!finished)
                    {
                        resultingPolygon.AddPoint(points[iPlus1]);
                        if (iPlus1 == f)
                        {
                            finished = true;
                        }
                        iPlus1 = (n + iPlus1 + 1) % n;
                    }
                    else
                    {
                        currentPolygon.AddPoint(points[iPlus1]);
                        iPlus1 = (n + iPlus1 + 1) % n;
                    }
                }
                while (iPlus1 != indexOfp1);

                points = currentPolygon.points;
            }
            return resultingPolygon;
        }

        /// <summary>
        /// Joins the given polygon to the current polygon if they have a common side
        /// </summary>
        /// <param name="toJoin"></param>
        public void JoinPolygon(Polygon toJoin)
        {
            Point p1 = new(-1, -1);
            Point p2 = new(-1, -1);
            for (int k = 0; k < points.Count; k++)
            {
                if (toJoin.points.Contains(points[k]))
                {
                    if (p1.X == -1)
                    {
                        p1 = points[k];
                    }
                    else
                    {
                        p2 = points[k];
                    }
                }
            }
            if (p1.X != -1 && p2.X != -1)
            {
                int indexOfp1 = toJoin.points.IndexOf(p1);
                int n = toJoin.points.Count;
                int i = indexOfp1;
                List<Point> pointsToAdd = new();
                do
                {
                    i = (n + i + 1) % n;
                    pointsToAdd.Add(toJoin.points[i]);
                }
                while (i != indexOfp1);
                pointsToAdd.RemoveAt(pointsToAdd.Count - 1);

                int startIndex = points.IndexOf(p1);
                points.InsertRange(startIndex + 1, pointsToAdd);
            }
        }

        public bool IsConvex()
        {
            int n = points.Count;
            bool ok = true;
            for (int i = 0; i < n; i++)
            {
                int iMinus1 = (n + i - 1) % n;
                int iPlus1 = (n + i + 1) % n;

                if (CustomGeometry.GetOrientation(points[iMinus1], points[i], points[iPlus1]) == -1)
                {
                    ok = false;
                    break;
                }
            }
            return ok;
        }

        public bool ContainsSegment(CustomGeometry.Segment s)
        {
            if (points.Contains(s.A) && points.Contains(s.B))
            {
                return true;
            }
            return false;
        }

        public void Draw(Graphics g, Pen p)
        {
            g.DrawPolygon(p, points.ToArray());
        }

        public PointF GetCenterOfGravity()
        {
            float x = 0;
            float y = 0;
            foreach (var p in points)
            {
                x += p.X;
                y += p.Y;
            }
            x = x / (float)points.Count;
            y = y / (float)points.Count;
            return new PointF(x, y);
        }
    }
}
