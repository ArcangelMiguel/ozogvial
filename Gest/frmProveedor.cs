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
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
        }

       
        private void frmProveedor_Load(object sender, EventArgs e)
        {
            apertura();
            cargaProveedor();
        }

        //========================  METODOS DE PRESENTACION Y LIMPIEZA  ===========================
        public void cargaProveedor()
        {
            DataTable dt = new DataTable();
            dt = Procede.extraeTodoProv();
            dgvProveedor.DataSource = dt;
            dgvProveedor.ReadOnly = true;
            dgvProveedor.Columns[0].HeaderText = "N°";
            dgvProveedor.Columns[0].Width = 30;
            dgvProveedor.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProveedor.Columns[1].HeaderText = "NOMBRE";
            dgvProveedor.Columns[1].Width = 180;
            dgvProveedor.Columns[2].HeaderText = "DOMICILIO";
            dgvProveedor.Columns[2].Width = 180;
            dgvProveedor.Columns[3].HeaderText = "CUIT N°";
            dgvProveedor.Columns[3].Width = 80;
            dgvProveedor.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public void apertura()
        {
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = true;
            pnlEncabezado.Enabled = false;
        }
        public void alAgregar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = false;
            pnlEncabezado.Enabled = true;
        }
        public void alModificar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = true;
            btnSalir.Enabled = false;
            pnlEncabezado.Enabled = true;
        }
        //========================  METODOS DE BOTONERAS  ===========================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            apertura();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            alAgregar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese un NOMBRE válido de proveedor");
            }
            else
            {
                Procede Proc = new Procede();
                Proc.NOMBRE = txtNombre.Text;
                Proc.DIRECCION = txtDomicilio.Text;
                Proc.CUIT = txtCuit.Text;
                int res = Procede.guardaProced(Proc);

                if (res == 1)
                {
                    MessageBox.Show("Datos almacenados");
                }
                else
                {
                    MessageBox.Show("Los datos no se guardaron");
                }
            }
            apertura();
            cargaProveedor();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
