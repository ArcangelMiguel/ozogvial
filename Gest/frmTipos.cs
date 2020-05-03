using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace Gest
{
    public partial class frmTipos : Form
    {
        public frmTipos()
        {
            InitializeComponent();
        }

        private void frmTipos_Load(object sender, EventArgs e)
        {
            txtDetalle.Enabled = true;
            txtDetalle.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDetalle.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre.");
            }
            else
            {
                Tema PO = new Tema();
                PO.DETALLE = txtDetalle.Text;
                int res = Tema.guardaTema(PO);

                if (res == 1)
                {
                    MessageBox.Show("Datos almacenados");
                }
                else
                {
                    MessageBox.Show("Los datos no se guardaron");
                }
            }
        }
    }
}
