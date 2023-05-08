using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs6
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            Ex1Form ex1Form = new();
            ex1Form.ShowDialog();
        }

        private void btnEx2_3_Click(object sender, EventArgs e)
        {
            PolygonForm form1 = new();
            form1.ShowDialog();
        }
    }
}
