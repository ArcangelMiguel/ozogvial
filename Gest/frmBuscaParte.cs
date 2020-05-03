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

       
        private void frmBuscaParte_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {

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
        }
       
    }
}
