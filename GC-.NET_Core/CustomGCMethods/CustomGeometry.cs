using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGCMethods
{
    public static class CustomGeometry
    {
        public static float GetDistance(Point a, Point b)
        {
            return (int)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static float GetAreaOfTriangle(Triangle t)
        {
            float a = GetDistance(t.B, t.C);
            float b = GetDistance(t.A, t.C);
            float c = GetDistance(t.A, t.B);
            float s = (a + b + c) / 2;

            return (float)(Math.Sqrt(s * (s - a) * (s - b) * (s - c)));
        }

        /// <summary>
        /// Checks if two lines intersect
        /// </summary>
        /// <param name="L1x">first point of first line</param>
        /// <param name="L1y">second point of first line</param>
        /// <param name="L2x">first point of second line</param>
        /// <param name="L2y">second point of second line</param>
        /// <returns>true if lines intersect, false otherwise</returns>
        public static bool DoIntersect(Point L1x, Point L1y, Point L2x, Point L2y)
        {
            if (GetOrientation(L1x, L1y, L2x) * GetOrientation(L1x, L1y, L2y) < 0 && GetOrientation(L2x, L2y, L1x) * GetOrientation(L2x, L2y, L1y) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Checks in which way are the three points arranged
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="P"></param>
        /// <returns>0 if the points are collinear, 1 if the rotation is clockwise and -1 if the rotation is counterclockwise</returns>
        public static int GetOrientation(Point A, Point B, Point P)
        {
            Point T1 = new Point(P.X - A.X, P.Y - A.Y);
            Point T2 = new Point(P.X - B.X, P.Y - B.Y);
            if (T1.X * T2.Y - T2.X * T1.Y == 0) return 0;
            return T1.X * T2.Y - T2.X * T1.Y > 0 ? 1 : -1;
        }

        /// <summary>
        /// Checks whether a polygon given by an ordered list of points is convex or not
        /// </summary>
        /// <param name="points"></param>
        /// <returns>true if the polygon is convex and false otherwise</returns>
        public static bool IsConvexPolygon(List<Point> points)
        {
            int n = points.Count;
            bool ok = true;
            for (int i = 0; i < n; i++)
            {
                int iMinus1 = (n + i - 1) % n;
                int iPlus1 = (n + i + 1) % n;

                if (GetOrientation(points[iMinus1], points[i], points[iPlus1]) == -1)
                {
                    ok = false;
                    break;
                }
            }
            return ok;
        }

        /// <summary>
        /// Checks if the point of a polygon is convex. The order of points in the polygon must be clockwise. Collinear points are considered convex.
        /// </summary>
        /// <param name="previous"></param>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <returns>true if the point is convex, false otherwise</returns>
        public static bool IsConvexPoint(Point previous, Point current, Point next)
        {
            int orientation = GetOrientation(previous, current, next);
            if (orientation == 1 || orientation == 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsInsidePolygon(Point xl, Point x, Point xr, Point interior)
        {
            if (GetOrientation(xl, x, xr) == 1)
            {
                int orientation1 = GetOrientation(x, interior, xr);
                int orientation2 = GetOrientation(x, xl, interior);
                if (orientation1 != -1 || orientation2 != -1)
                {
                    return false;
                }
            }
            else
            {
                int orientation1 = GetOrientation(x, interior, xr);
                int orientation2 = GetOrientation(x, xl, interior);
                if (orientation1 == 1 && orientation2 == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public struct Segment
        {
            public Point A, B;

            public Segment(Point a, Point b)
            {
                A = a;
                B = b;
            }
        }

        public struct Triangle
        {
            public Point A, B, C;

            public Triangle(Point a, Point b, Point c)
            {
                A = a;
                B = b;
                C = c;
            }
        }
    }
}
