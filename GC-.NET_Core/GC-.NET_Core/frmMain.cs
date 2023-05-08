using CustomGCMethods;


namespace GC_.NET_Core
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
            int n = rnd.Next(50, 100);

            List<Point> points = CustomGraphics.DrawRandomPoints(g, pointsPen, n, 0, 0, pcbDisplay.Width, pcbDisplay.Height);
            
            List<Point> Lsup = new();
            List<Point> Linf = new();

            points.Sort(new PointComparer());

            Lsup.Add(points[0]);
            Lsup.Add(points[1]);

            for (int i = 2; i < n; i++)
            {
                Lsup.Add(points[i]);
                while (Lsup.Count > 2 && !DoRightTurn(Lsup[Lsup.Count - 1], Lsup[Lsup.Count - 2], Lsup[Lsup.Count - 3]))
                {
                    Lsup.RemoveAt(Lsup.Count - 2);
                }
            }

            Linf.Add(points[n - 1]);
            Linf.Add(points[n - 2]);

            for (int i = n - 3; i >= 0; i--)
            {
                Linf.Add(points[i]);
                while (Linf.Count > 2 && !DoRightTurn(Linf[Linf.Count - 1], Linf[Linf.Count - 2], Linf[Linf.Count - 3]))
                {
                    Linf.RemoveAt(Linf.Count - 2);
                }
            }

            //Linf.RemoveAt(0);
            //Linf.RemoveAt(Linf.Count - 1);

            Lsup.AddRange(Linf);

            for (int i = 0; i < Lsup.Count - 1; i++)
            {
                g.DrawLine(linePen, Lsup[i], Lsup[i + 1]);
            }

            RefreshImage();
        }

        private bool DoRightTurn(Point p, Point q, Point r)
        {
            int D = p.X * q.Y + q.X * r.Y + p.Y * r.X - r.X * q.Y - p.X * r.Y - q.X * p.Y;
            return D > 0;
        }

        class PointComparer : IComparer<Point>
        {
            public int Compare(Point p1, Point p2)
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
                        return 0;
                    }
                }
            }
        }

        private void RefreshImage()
        {
            pcbDisplay.Image = bmp;
        }

        private void ClearGraphics()
        {
            g.Clear(pcbDisplay.BackColor);
        }
    }
}