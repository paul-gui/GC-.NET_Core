using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomGCMethods;

namespace Curs6
{
    public partial class Ex1Form : Form
    {
        Pen pointPen = new Pen(Color.Black, 2);
        Pen linePen = new Pen(Color.Green);

        Graphics g;
        Bitmap bmp;
        public Ex1Form()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ClearGraphics();

            Random rnd = new Random();
            int n = rnd.Next(10, 15);

            List<Point> points = CustomGraphics.DrawRandomPoints(g, pointPen, n, 0, 0, pictureBox1.Width, pictureBox1.Height);

            SortedList<float, Tuple<Point, Point>> lengths = new(new CustomIntComparer());
            List<CustomGeometry.Segment> lines = new();

            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    lengths.Add(CustomGeometry.GetDistance(points[i], points[j]), new Tuple<Point, Point>(points[i], points[j]));
                }
            }

            foreach (var item in lengths)
            {
                bool intersects = false;
                for (int j = 0; j < lines.Count; j++)
                {
                    if (CustomGeometry.DoIntersect(item.Value.Item1, item.Value.Item2, lines[j].A, lines[j].B))
                    {
                        intersects = true;
                    }
                }
                if (!intersects)
                {
                    lines.Add(new CustomGeometry.Segment(item.Value.Item1, item.Value.Item2));
                }
            }

            for (int i = 0; i < lines.Count; i++)
            {
                g.DrawLine(linePen, lines[i].A, lines[i].B);
            }
            RefreshImage();
        }

        void ClearGraphics()
        {
            g.Clear(Color.White);
        }

        void RefreshImage()
        {
            pictureBox1.Image = bmp;
        }

        class CustomIntComparer : IComparer<float>
        {
            public int Compare(float x, float y)
            {
                if (x < y)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
