using Curs6;
using CustomGCMethods;

namespace Curs11
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

            List<CustomGeometry.Segment> diagonals = new();
            List<CustomGeometry.Segment> essentialDiagonals = new();

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

            Dictionary<Point, int> bondedLines = new();
            for (int i = 0; i < points.Count; i++)
            {
                bondedLines.Add(points[i], 0);
            }

            for (int i = 0; i < n; i++)
            {
                int iMinus1 = (n + i - 1) % n;
                int iPlus1 = (n + i + 1) % n;

                if (CustomGeometry.GetOrientation(points[iMinus1], points[i], points[iPlus1]) == -1)
                {
                    bool leftFound = false;
                    bool rightFound = false;
                    foreach (var d in diagonals)
                    {
                        if (d.A == points[i] || d.B == points[i])
                        {
                            Point b = (d.A == points[i]) ? d.B : d.A;
                            int bIndex = points.FindIndex(a => a == b);
                            int bIndexMinus1 = (n + bIndex - 1) % n;
                            int bIndexPlus1 = (n + bIndex + 1) % n;
                            if (bondedLines[b] < 3)
                            {
                                int orientation1 = CustomGeometry.GetOrientation(points[iMinus1], points[i], b);
                                int orientation2 = CustomGeometry.GetOrientation(points[iPlus1], points[i], b);

                                if (orientation1 == 1 && orientation2 == -1)
                                {
                                    rightFound = true;
                                    leftFound = true;

                                    essentialDiagonals.Add(d);
                                    bondedLines[b]++;
                                    bondedLines[points[i]]++;
                                    break;
                                }
                                else if (CustomGeometry.GetOrientation(points[bIndexMinus1], points[bIndex], points[bIndexPlus1]) == -1)
                                {
                                    if (CustomGeometry.GetOrientation(points[iMinus1], points[i], points[bIndex]) == -1)
                                    {
                                        leftFound = true;
                                    }
                                    else if (CustomGeometry.GetOrientation(points[iPlus1], points[i], points[bIndex]) == 1)
                                    {

                                        rightFound = true;
                                    }
                                    essentialDiagonals.Add(d);
                                    bondedLines[b]++;
                                    bondedLines[points[i]]++;
                                    break;
                                }
                                else
                                {
                                    List<CustomGeometry.Segment> localDiagonals = new();
                                    foreach (var dp in diagonals)
                                    {
                                        if (dp.B == points[i])
                                        {
                                            localDiagonals.Add(new CustomGeometry.Segment(dp.B, dp.A));
                                        }
                                        if (dp.A == points[i])
                                        {
                                            localDiagonals.Add(dp);
                                        }
                                    }

                                    if (!leftFound)
                                    {
                                        //CustomGeometry.GetOrientation(points[iPlus1], points[i], b) == -1
                                        Point q = localDiagonals[0].B;
                                        for (int k = 1; k < localDiagonals.Count; k++)
                                        {
                                            int mainOrientation = CustomGeometry.GetOrientation(points[i], localDiagonals[k].B, q);
                                            int checkOrientation = CustomGeometry.GetOrientation(points[i - 1], points[i], localDiagonals[k].B);
                                            if (mainOrientation == -1 && checkOrientation == -1)
                                            {
                                                q = localDiagonals[k].B;
                                            }
                                        }
                                        essentialDiagonals.Add(new CustomGeometry.Segment(points[i], q));
                                        bondedLines[b]++;
                                        bondedLines[points[i]]++;
                                    }
                                    else if (!rightFound)
                                    {
                                        //CustomGeometry.GetOrientation(points[iMinus1], points[i], b) == 1
                                        Point q = localDiagonals[0].B;
                                        for (int k = 1; k < localDiagonals.Count; k++)
                                        {
                                            int mainOrientation = CustomGeometry.GetOrientation(points[i], localDiagonals[k].B, q);
                                            int checkOrientation = CustomGeometry.GetOrientation(points[i + 1], points[i], localDiagonals[k].B);
                                            if (mainOrientation == 1 && checkOrientation == 1)
                                            {
                                                q = localDiagonals[k].B;
                                            }
                                        }
                                        essentialDiagonals.Add(new CustomGeometry.Segment(points[i], q));
                                        bondedLines[b]++;
                                        bondedLines[points[i]]++;
                                    }
                                }
                            }
                        }
                    }
                    //if (maxFound)
                    //{
                    //    essentialDiagonals.Add(max);
                    //}
                    //if (minFound)
                    //{
                    //    essentialDiagonals.Add(min);
                    //}
                }
            }

            foreach (var d in essentialDiagonals)
            {
                g.DrawLine(new Pen(Color.Green, 3), d.A, d.B);
            }

            //foreach (var d in diagonals)
            //{
            //    g.DrawLine(Pens.Blue, d.A, d.B);
            //}

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
        }

        private void RefreshImage()
        {
            pcbDisplay.Image = bmp;
        }
    }
}