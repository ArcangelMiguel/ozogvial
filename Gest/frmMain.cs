using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void partesDiariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParteDiario fpd = new frmParteDiario();
            fpd.MdiParent = this;
            fpd.Show();
        }

        private void novedadesEquiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovedadEquipo fne = new frmNovedadEquipo();
            fne.MdiParent = this;
            fne.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMaterial fmat = new frmMaterial();
            fmat.MdiParent = this;
            fmat.Show();
        }
    }
}
