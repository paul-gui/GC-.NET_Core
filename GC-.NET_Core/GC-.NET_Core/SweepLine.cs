using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GC_.NET_Core
{
    internal class SweepLine
    {
        public static void FindIntersections(List<Segment> S)
        {
            SortedSet<Point> pQueue = new SortedSet<Point>(new PointComparer());
            Dictionary<Point, List<Segment>> UpperPoints = new Dictionary<Point, List<Segment>>();

            foreach (var s in S)
            {
                foreach (PropertyInfo prop in typeof(Segment).GetProperties())
                {
                    Point p = (Point)prop.GetValue(s, null);
                    pQueue.Add(p);

                    if (prop.Name == "UpperPoint")
                    {
                        List<Segment> existing;
                        if (!UpperPoints.TryGetValue(p, out existing))
                        {
                            existing = new List<Segment>();
                            UpperPoints[p] = existing;
                        }
                        existing.Add(s);
                    }
                }
            }
        }

        class PointComparer : IComparer<Point>
        {
            int IComparer<Point>.Compare(Point p1, Point p2)
            {
                if (p1.Y < p2.Y)
                {
                    return -1;
                }
                else if (p1.Y > p2.Y)
                {
                    return 1;
                }
                else
                {
                    if (p1.X < p2.X)
                    {
                        return -1;
                    }
                    else if (p1.X > p2.X)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
    public struct Segment
    {
        public Point UpperPoint { get; set; }
        public Point LowerPoint { get; set; }

        public Segment(Point a, Point b)
        {
            UpperPoint = a;
            LowerPoint = b;
        }
    }

    struct Event : IComparable<Event>
    {
        public Point point;
        public bool isLeft;
        public Segment segment;

        public Event(Point p, bool l, Segment s)
        {
            point = p;
            isLeft = l;
            segment = s;
        }

        public int CompareTo(Event other)
        {
            if (this.point.Y < other.point.Y)
            {
                return -1;
            }
            else if (this.point.Y > other.point.Y)
            {
                return 1;
            }
            else
            {
                if (this.point.X < other.point.X)
                {
                    return -1;
                }
                else if (this.point.X > other.point.X)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
