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
    public partial class frmNuevaObra : Form
    {
        public frmNuevaObra()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtAlias.Text == "")
            {
                MessageBox.Show("Debe ingresar como mínimo un Alias.");
            }
            else
            {
                Obra PO = new Obra();
                PO.NOMBRE = txtNombre.Text;
                PO.ALIAS = txtAlias.Text;
                PO.COMITENTE = txtComitente.Text;
                int res = Obra.guardaObra(PO);

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
