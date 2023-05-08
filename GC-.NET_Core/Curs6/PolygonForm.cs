namespace Curs6
{
    public partial class PolygonForm : Form
    {
        Pen trianglePen = new Pen(Color.Green);

        Bitmap bmp;
        List<Point> points;
        Graphics g;
        public PolygonForm()
        {
            InitializeComponent();
            points = new List<Point>();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            UseInputForm();
            label1.Visible = false;
            g = Graphics.FromImage(bmp);
            TriangulatePolygon();
            RefreshImage();
        }

        void UseInputForm()
        {
            using (InputForm inputForm = new InputForm(pictureBox1.Size))
            {
                inputForm.ShowDialog();

                bmp = inputForm.RetrieveBitmap();
                points = inputForm.RetrievePointsList();
            }
        }

        void TriangulatePolygon()
        {
            for (int i = 2; i < points.Count - 1; i++)
            {
                g.DrawLine(trianglePen, points[0], points[i]);
            }
            RefreshImage();
        }


        void RefreshImage()
        {
            pictureBox1.Image = bmp;
        }
    }
}