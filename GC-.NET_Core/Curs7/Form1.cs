using Curs6;
using CustomGCMethods;

namespace Curs7
{
    public partial class Curs7Form : Form
    {
        Bitmap bmp;
        Graphics g;
        List<Point> points;
        public Curs7Form()
        {
            InitializeComponent();
        }

        private void pcbDisplay_Click(object sender, EventArgs e)
        {
            GetInput();
            List<CustomGeometry.Segment> diagonals = new();

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
                        diagonals.Add(new CustomGeometry.Segment(points[i], points[j]));
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

            foreach (var d in diagonals)
            {
                g.DrawLine(Pens.Green, d.A, d.B);
            }
            RefreshImage();
        }

        private void GetInput()
        {
            using (InputForm inputForm = new(pcbDisplay.Size))
            {
                inputForm.ShowDialog();
                bmp = inputForm.RetrieveBitmap();
                points = inputForm.RetrievePointsList();
            }
            g = Graphics.FromImage(bmp);
        }

        private void RefreshImage()
        {
            pcbDisplay.Image = bmp;
        }
    }
}