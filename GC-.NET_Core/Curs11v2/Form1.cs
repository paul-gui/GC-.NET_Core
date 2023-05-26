using Curs6;
using CustomGCMethods;
using System.Drawing.Text;

namespace Curs11v2
{
    public partial class Form1 : Form
    {
        List<Point> points;
        Bitmap bmp;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetInput();

            g = Graphics.FromImage(bmp);

            List<Polygon> polygons = new();
            List<CustomGeometry.Segment> diagonals = new();

            polygons.Add(new Polygon(points));


            int n = points.Count;
            for (int i = 0; i < n - 2; i++)
            {
                bool breakCondition = false;
                for (int j = i + 2; j < n; j++)
                {
                    if (i == 0 && j == n - 1)
                    {
                        break;
                    }

                    bool ok = true;
                    for (int k = 0; k < n - 1; k++)
                    {
                        if (points[i] != points[k] && points[i] != points[k + 1] && points[j] != points[k] && points[j] != points[k + 1])
                        {
                            if (CustomGeometry.DoIntersect(points[i], points[j], points[k], points[k + 1]))
                            {
                                ok = false;
                                break;
                            }
                        }
                    }

                    if (ok)
                    {
                        foreach (var d in diagonals)
                        {
                            if (CustomGeometry.DoIntersect(points[i], points[j], d.A, d.B))
                            {
                                ok = false;
                            }
                        }
                    }

                    //bool isInside = false;
                    if (ok)
                    {
                        int lowerIndex = (n + i - 1) % n; //in loc de i - 1 ca sa nu am out of range exception
                        if (CustomGeometry.GetOrientation(points[lowerIndex], points[i], points[i + 1]) == 1)
                        {
                            int orientation1 = CustomGeometry.GetOrientation(points[i], points[j], points[i + 1]);
                            int orientation2 = CustomGeometry.GetOrientation(points[i], points[lowerIndex], points[j]);
                            if (orientation1 != -1 || orientation2 != -1)
                            {
                                ok = false;
                            }
                        }
                        else
                        {
                            int orientation1 = CustomGeometry.GetOrientation(points[i], points[j], points[i + 1]);
                            int orientation2 = CustomGeometry.GetOrientation(points[i], points[lowerIndex], points[j]);
                            if (orientation1 == 1 && orientation2 == 1)
                            {
                                ok = false;
                            }
                        }
                    }

                    if (ok)
                    {
                        CustomGeometry.Segment diagonal = new(points[i], points[j]);
                        diagonals.Add(diagonal);
                        List<Polygon> polygonsCopy = new(polygons);
                        foreach (var p in polygons)
                        {
                            if (p.ContainsSegment(diagonal))
                            {
                                polygonsCopy.Insert(polygonsCopy.IndexOf(p), p.SplitPolygon(diagonal.A, diagonal.B));
                            }
                        }
                        polygons = new List<Polygon>(polygonsCopy);
                        //for (int k = 0; k < polygons.Count; k++)
                        //{
                        //    if (polygonsCopy[k].ContainsSegment(diagonal))
                        //    {
                        //        Polygon p = polygonsCopy[k].SplitPolygon(diagonal.A, diagonal.B);
                        //        polygonsCopy.Add(p);
                        //    }
                        //}
                    }

                    if (diagonals.Count == n - 3)
                    {
                        breakCondition = true;
                        break;
                    }
                }
                if (breakCondition)
                {
                    break;
                }
            }


            //for (int i = 0; i < polygons.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < polygons.Count; j++)
            //    {
            //        Polygon polygonCopy = polygons[i];
            //        polygonCopy.JoinPolygon(polygons[j]);
            //        if (polygonCopy.IsConvex())
            //        {
            //            polygons[i].JoinPolygon(polygons[j]);
            //            polygons.RemoveAt(j);
            //            j--;
            //        }
            //    }
            //}
            List<CustomGeometry.Segment> diagonalsCopy = new(diagonals);
            foreach (var d in diagonals)
            {
                Polygon p1 = new();
                Polygon p2 = new();
                foreach (var p in polygons)
                {
                    if (p.ContainsSegment(d))
                    {
                        if (p1.IsEmpty)
                        {
                            p1 = p;
                        }
                        else
                        {
                            p2 = p;
                            break;
                        }
                    }
                }

                Polygon testPolygon = p1;
                testPolygon.JoinPolygon(p2);
                if (testPolygon.IsConvex())
                {
                    diagonalsCopy.Remove(d);
                    polygons.Remove(p1);
                    polygons.Remove(p2);
                    polygons.Add(testPolygon);
                }
            }


            //Polygon p1 = new(points);
            //Polygon p2 = p1.SplitPolygon(points[0], points[3]);
            //Polygon p3 = p1.SplitPolygon(points[0], points[4]);
            //p1.JoinPolygon(p2);
            //p1.Draw(g, new Pen(Color.Blue, 2));
            //p2.Draw(g, Pens.Green);
            //p3.Draw(g, Pens.Orange);


            //for (int i = 0; i < polygons.Count; i++)
            //{
            //    polygons[i].Draw(g, Pens.Blue);
            //    g.DrawString($"{i}", this.Font, Brushes.Black, polygons[i].GetCenterOfGravity());
            //}

            foreach (var d in diagonalsCopy)
            {
                g.DrawLine(Pens.Blue, d.A, d.B);
            }
            RefreshImage();
        }

        void GetInput()
        {
            using (InputForm ipf = new InputForm(pictureBox1.Size))
            {
                ipf.ShowDialog();
                points = ipf.RetrievePointsList();
                bmp = ipf.RetrieveBitmap();
            }
        }

        void RefreshImage()
        {
            pictureBox1.Image = bmp;
        }
    }
}