using CustomGCMethods;
using System.CodeDom;
using System.Numerics;

namespace Curs5
{
    public partial class frmMain : Form
    {
        Bitmap bmp;
        Graphics g;
        public frmMain()
        {
            InitializeComponent();
            bmp = new Bitmap(pcbDisplay.Width, pcbDisplay.Height);
            g = Graphics.FromImage(bmp);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ClearGraphics();

            
            Pen pointsPen = new(Color.Black, 2);
            Pen linePen = new(Color.Red);

            Random rnd = new();
            int n = rnd.Next(20, 50);

            List<Point> points = CustomGraphics.DrawRandomPoints(g, pointsPen, n, 0, 0, pcbDisplay.Width, pcbDisplay.Height);

            List<Point> L = GetConvexHull(points);

            for (int i = 0; i < L.Count - 1; i++)
            {
                g.DrawLine(linePen, L[i], L[i + 1]);
            }
            g.DrawLine(linePen, L[0], L[L.Count - 1]);

            #region Comment
            ////Dictionary<Point, bool> usedStatus = new();

            //int minY = pcbDisplay.Height;
            //Point p0 = new();

            //for (int i = 0; i < points.Count; i++)
            //{
            //    if (points[i].Y < minY)
            //    {
            //        minY = points[i].Y;
            //        p0 = points[i];
            //    }
            //    //usedStatus.Add(points[i], false);
            //}

            //L.Add(p0);
            ////usedStatus[p0] = true;

            //float maxAngle = -180;
            //Point nextP = new();
            //for (int i = 0; i < points.Count; i++)
            //{
            //    //if (!usedStatus[points[i]])
            //    //{
            //        float currentAngle = GetAngle(p0, points[i]);
            //        if (currentAngle > maxAngle)
            //        {
            //            maxAngle = currentAngle;
            //            nextP = points[i];
            //        }
            //    //}
            //}

            //L.Add(nextP);
            ////usedStatus[nextP] = true;

            //int index = 1;
            //while (points[index] != p0)
            //{
            //    maxAngle = -180;
            //    nextP = new();
            //    for (int i = 0; i < points.Count; i++)
            //    {
            //        //if (!usedStatus[points[i]])
            //        //{
            //            float currentAngle = GetAngle(L[L.Count - 2], L[L.Count - 1], points[i]);
            //            if (currentAngle > maxAngle)
            //            {
            //                maxAngle = currentAngle;
            //                nextP = points[i];
            //            }
            //        //}
            //    }
            //    L.Add(nextP);
            //    //usedStatus[nextP] = true;
            //    index++;
            //}

            //for (int i = 0; i < L.Count - 1; i++)
            //{
            //    g.DrawLine(linePen, L[i], L[i + 1]);
            //}

            //int max = 0;
            //int l;
            //for (int i = 0; i < points.Count; i++)
            //{
            //    if (points[i].Y > max)
            //    {
            //        max = points[i].Y;
            //        l = i;
            //    }
            //}
            #endregion


            RefreshImage();
        }

        //0 - coliniare
        //1 - sensul acelor de ceas
        //2 - invers sensului acelor de ceas
        public int GetOrientation(Point A, Point B, Point P)
        {
            Point T1 = P.Substract(A);
            Point T2 = P.Substract(B);
            if (T1.X * T2.Y - T2.X * T1.Y == 0) return 0;
            return T1.X * T2.Y - T2.X * T1.Y > 0 ? 1 : 2;
        }

        List<Point> GetConvexHull(List<Point> points)
        {
            int n = points.Count;
            List<Point> L = new();

            int l = 0;
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (points[i].Y > max)
                {
                    max = points[i].Y;
                    l = i;
                }
            }

            int p = l, q;

            do
            {
                L.Add(points[p]);

                q = (p + 1) % n;

                for (int i = 0; i < n; i++)
                {
                    if (GetOrientation(points[p], points[i], points[q]) == 1)
                    {
                        q = i;
                    }
                }
                p = q;
            }
            while (p != l);

            return L;
        }

        private void RefreshImage()
        {
            pcbDisplay.Image = bmp;
        }

        private void ClearGraphics()
        {
            g.Clear(pcbDisplay.BackColor);
        }

        private float GetAngle(Point a, Point b)
        {
            if (a == b)
            {
                return 0;
            }
            if (a.X == b.X)
            {
                return 90;
            }
            float slope = (a.Y - b.Y) / (a.X - b.X);
            return (float)Math.Atan(slope);
        }

        public float GetAngle(Point A, Point B, Point C)
        {
            float a = CustomGeometry.GetDistance(B, C);
            float b = CustomGeometry.GetDistance(A, C);
            float c = CustomGeometry.GetDistance(A, B);

            float sp = (a + b + c) / 2;
            float area = (float)Math.Sqrt(sp * (sp - a) * (sp - b) * (sp - c));

            float angle = (float)(Math.Asin(((2 * area) / (a * c))) * (180 / Math.PI));

            return angle;
        }
    }

    public static class PointAritmethicExtensions
    {
        public static Point Substract(this Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
    }
}