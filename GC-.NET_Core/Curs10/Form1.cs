using Curs6;
using CustomGCMethods;
using Curs9;
using System;

namespace Curs10
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        List<Point> points;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetInput();
            g = Graphics.FromImage(bmp);
            List<Point> sortedPoints = new(points);
            List<Point> leftChain = new();
            List<Point> rightChain = new();

            sortedPoints.Sort(new SortPointsFromTopToBottom());

            int n = points.Count;
            int i = 0;
            while (i < n && points[i] != sortedPoints[n - 1])
            {
                rightChain.Add(points[i]);
                i++;
            }
            while (i < n)
            {
                leftChain.Add(points[i]);
                i++;
            }

            Stack<Point> stack = new();
            stack.Push(sortedPoints[0]);
            stack.Push(sortedPoints[1]);

            Pen linePen = new Pen(Color.Blue);
            for (int j = 2; j < points.Count - 1; j++)
            {
                if (leftChain.Contains(sortedPoints[j]) && rightChain.Contains(stack.Peek()) || leftChain.Contains(stack.Peek()) && rightChain.Contains(sortedPoints[j]))
                {
                    while (stack.Count > 1)
                    {
                        g.DrawLine(linePen, sortedPoints[j], stack.Pop());
                    }
                    stack.Pop();
                    stack.Push(sortedPoints[j - 1]);
                    stack.Push(sortedPoints[j]);
                }
                else
                {
                    Point last = stack.Pop();
                    bool ok = true;
                    int index = points.FindIndex(a => a == sortedPoints[j]);
                    do
                    {
                        Point p = stack.Peek();
                        ok = true;
                        for (int k = 0; k < n - 1; k++)
                        {
                            if (sortedPoints[j] != points[k] && sortedPoints[j] != points[k + 1] && p != points[k] && p != points[k + 1])
                            {
                                if (CustomGeometry.DoIntersect(sortedPoints[j], p, points[k], points[k + 1]))
                                {
                                    ok = false;
                                    break;
                                }
                            }
                        }
                        ok = CustomGeometry.IsInsidePolygon(points[index - 1], points[index], points[index + 1], p);
                        if (ok)
                        {
                            last = stack.Pop();
                            g.DrawLine(linePen, points[index], last);
                        }
                    }
                    while (ok && stack.Count > 0);
                    stack.Push(last);
                    stack.Push(points[index]);
                }
            }

            stack.Pop();
            while (stack.Count > 1)
            {
                g.DrawLine(linePen, points[n - 1], stack.Pop());
            }

            pictureBox1.Image = bmp;
        }

        private void GetInput()
        {
            using(InputForm ipf = new InputForm(pictureBox1.Size))
            {
                ipf.ShowDialog();
                bmp = ipf.RetrieveBitmap();
                points = ipf.RetrievePointsList();
            }
        }
    }
}