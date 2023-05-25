using Curs6;
using CustomGCMethods;


namespace Curs9
{
    public partial class Form1 : Form
    {
        List<Point> points;
        List<Point> sortedPoints;
        Bitmap bmp;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void pcbDisplay_Click(object sender, EventArgs e)
        {
            using (InputForm inputForm = new(pcbDisplay.Size))
            {
                inputForm.ShowDialog();
                points = inputForm.RetrievePointsList();
                bmp = inputForm.RetrieveBitmap();
            }
            g = Graphics.FromImage(bmp);
            sortedPoints = new List<Point>(points);

            sortedPoints.Sort(new SortPointsFromTopToBottom());

            int n = points.Count;
            Color lineColor = Color.Magenta;

            for (int i = 0; i < n; i++)
            {
                int iMinus1 = (n + i - 1) % n;
                int iPlus1 = (n + i + 1) % n;
                int tmp = CustomGeometry.GetOrientation(points[iMinus1], points[i], points[iPlus1]);
                if (tmp == -1)
                {
                    if (points[iMinus1].Y > points[i].Y && points[iPlus1].Y > points[i].Y)
                    {
                        int index = sortedPoints.FindIndex(a => a == points[i]) - 1;
                        if (index >= 0)
                        {
                            bool ok = true;
                            for (int k = 0; k < n - 1; k++)
                            {
                                if (points[i] != points[k] && points[i] != points[k + 1] && sortedPoints[index] != points[k] && sortedPoints[index] != points[k + 1])
                                {
                                    if (CustomGeometry.DoIntersect(points[i], sortedPoints[index], points[k], points[k + 1]))
                                    {
                                        ok = false;
                                        break;
                                    }
                                }
                            }
                            if (ok)
                            {
                                g.DrawLine(new Pen(lineColor), points[i], sortedPoints[index]);
                            }
                        }
                    }

                    if (points[iMinus1].Y < points[i].Y && points[iPlus1].Y < points[i].Y)
                    {
                        int index = sortedPoints.FindIndex(a => a == points[i]) + 1;
                        if (index < n)
                        {
                            bool ok = true;
                            for (int k = 0; k < n - 1; k++)
                            {
                                if (points[i] != points[k] && points[i] != points[k + 1] && sortedPoints[index] != points[k] && sortedPoints[index] != points[k + 1])
                                {
                                    if (CustomGeometry.DoIntersect(points[i], sortedPoints[index], points[k], points[k + 1]))
                                    {
                                        ok = false;
                                        break;
                                    }
                                }
                            }
                            if (ok)
                            {
                                g.DrawLine(new Pen(lineColor), points[i], sortedPoints[index]);
                            }
                        }
                    }
                }
            }

            pcbDisplay.Image = bmp;
        }
    }

     public class SortPointsFromTopToBottom : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.Y < y.Y)
            {
                return -1;
            }
            else if (x.Y > y.Y)
            {
                return 1;
            }
            else
            {
                if (x.X < y.X)
                {
                    return -1;
                }
                else if (x.X > y.X)
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