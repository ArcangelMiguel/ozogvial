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
    public partial class frmBuscaParte : Form
    {
        public frmBuscaParte()
        {
            InitializeComponent();
        }
        // ==========================  ALGORITMOS DE PRESENTACION  ==============================
        public void cargaPartePorTema(int ValorTema)
        {
            DataTable dt = new DataTable();
            dt = Parte.PartePorTema(ValorTema);
            dgvPartes.DataSource = dt; dgvPartes.ReadOnly = true;

            dgvPartes.Columns[0].HeaderText = "N°";
            dgvPartes.Columns[0].Width = 30;
            dgvPartes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPartes.Columns[1].HeaderText = "Fecha";
            dgvPartes.Columns[1].Width = 80;
            dgvPartes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPartes.Columns[2].HeaderText = "Detalle";
            dgvPartes.Columns[2].Width = 300;
            dgvPartes.Columns[3].HeaderText = "Estado";
            dgvPartes.Columns[3].Width = 70;
        }

        public void cargaPartePorProcedencia(int ValorProc)
        {
            DataTable dt = new DataTable();
            dt = Parte.PartePorProcedencia(ValorProc);
            dgvPartes.DataSource = dt; dgvPartes.ReadOnly = true;

            dgvPartes.Columns[0].HeaderText = "N°";
            dgvPartes.Columns[0].Width = 30;
            dgvPartes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPartes.Columns[1].HeaderText = "Fecha";
            dgvPartes.Columns[1].Width = 80;
            dgvPartes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPartes.Columns[2].HeaderText = "Detalle";
            dgvPartes.Columns[2].Width = 300;
            dgvPartes.Columns[3].HeaderText = "Estado";
            dgvPartes.Columns[3].Width = 70;
        }

        public void seleccionaDatos()
        {
            dgvPartes.DataSource = null;
            if (cmbBusqueda.Text == "Tema")
            {
                int ValorTema;
                if (cmbDato.SelectedValue == null)
                {
                    ValorTema = 1;
                }
                else
                {
                    ValorTema = int.Parse(cmbDato.SelectedValue.ToString());
                }
                cargaPartePorTema(ValorTema);

            }
            if (cmbBusqueda.Text == "Procedencia")
            {
                int ValorProc;
                if (cmbDato.SelectedValue == null)
                {
                    ValorProc = 1;
                }
                else
                {
                    ValorProc = int.Parse(cmbDato.SelectedValue.ToString());
                }
                cargaPartePorProcedencia(ValorProc);
            }
        }

        public void arranca()
        {
            btnActualiza.Enabled = false;
            txtDetalle.Clear(); txtDetalle.Enabled = false;
            cmbEstado.Text = "";cmbEstado.Enabled = false;
        }

        // ==========================  ALGORITMOS DE BOTONERA  ==============================

        private void frmBuscaParte_Load(object sender, EventArgs e)
        {
           arranca();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            int orden= int.Parse(dgvPartes.CurrentRow.Cells[0].Value.ToString());
            Parte PD = new Parte();
            PD.IDPARTE = orden;
            PD.DETALLE = txtDetalle.Text;
            PD.ESTADO = cmbEstado.Text;
            int res = Parte.modificaEstado(PD, orden);
            if (res == 1)
            {
                MessageBox.Show("Datos almacenados");
            }
            else
            {
                MessageBox.Show("Los datos no se guardaron");
            }
            arranca();
            seleccionaDatos();
        }

        // ==========================  ALGORITMOS EVENTUALES  ==============================
        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPartes.DataSource = null;
            cmbBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;

            if (cmbBusqueda.Text == "Todos")
            {
                cmbDato.DataSource = null;
                DataTable dt = new DataTable();
                dt = Parte.extraeSinEstado();
                dgvPartes.DataSource = dt;
                dgvPartes.ReadOnly = true;

                dgvPartes.Columns[0].HeaderText = "N°";
                dgvPartes.Columns[0].Width = 30;
                dgvPartes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPartes.Columns[1].HeaderText = "Fecha";
                dgvPartes.Columns[1].Width = 80;
                dgvPartes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPartes.Columns[2].HeaderText = "Tema";
                dgvPartes.Columns[2].Width = 130;
                dgvPartes.Columns[3].HeaderText = "Proveedor";
                dgvPartes.Columns[3].Width = 130;
                dgvPartes.Columns[4].HeaderText = "Detalle";
                dgvPartes.Columns[4].Width = 300;
                dgvPartes.Columns[5].HeaderText = "Estado";
                dgvPartes.Columns[5].Width = 70;
            }
            if (cmbBusqueda.Text == "Tema")
            {
                cmbDato.DataSource = null;
                DataTable dt = new DataTable();
                dt = Tema.extraeTEMA();

                cmbDato.DisplayMember = "tema";
                cmbDato.ValueMember = "id_Tema";
                cmbDato.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbDato.DataSource = dt;

            }
            if (cmbBusqueda.Text == "Procedencia")
            {
                cmbDato.DataSource = null;
                DataTable dt = new DataTable();
                dt = Procede.extraeProcedencia();

                cmbDato.DisplayMember = "nombre";
                cmbDato.ValueMember = "id_Prov";
                cmbDato.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbDato.DataSource = dt;
            }
        }

        private void cmbDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionaDatos();
        }

        private void dgvPartes_DoubleClick(object sender, EventArgs e)
        {
            if (cmbBusqueda.Text == "Todos")
            {
                MessageBox.Show("Para modificar haga una búsqueda por Procedencia o por Tema");
            }
            else
            {
                btnActualiza.Enabled = true;
                txtDetalle.Enabled = true;
                cmbEstado.Enabled = true;

                txtDetalle.Text = dgvPartes.CurrentRow.Cells[2].Value.ToString();
                cmbEstado.Text = dgvPartes.CurrentRow.Cells[3].Value.ToString();
            }
        }
    }
}
