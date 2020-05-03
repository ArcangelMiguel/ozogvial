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
    public partial class frmParteDiario : Form
    {
        public frmParteDiario()
        {
            InitializeComponent();
        }

        private void frmParteDiario_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            lblFecha.Text = hoy.ToShortDateString();
            apertura();
            
            try //Extraemos los tipos para llenar un combo
            {               
                DataTable dt = new DataTable();
                dt = Tema.extraeTEMA();

                cmbTema.DisplayMember = "tema";
                cmbTema.ValueMember = "id_Tema";
                cmbTema.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbTema.DataSource = dt;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.ToString());
            }

            try  //Extraemos los proveedores o procedencia para llenar un combo
            {                
                DataTable dt = new DataTable();
                dt = Procede.extraeProcedencia();

                cmbProcede.DisplayMember = "nombre";
                cmbProcede.ValueMember = "id_Prov";
                cmbProcede.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbProcede.DataSource = dt;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.ToString());
            }

            try   //Extraemos partes diarios Pendientes y lo mostramos en el datagrid
            {                
                DataTable dt = new DataTable();
                dt = Parte.extraeParte("Pendiente");
                dgvParteDiario.DataSource = dt;dgvParteDiario.ReadOnly = true;
                dgvParteDiario.Columns[0].HeaderText = "N°";
                dgvParteDiario.Columns[0].Width = 30;
                dgvParteDiario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvParteDiario.Columns[1].HeaderText = "Fecha";
                dgvParteDiario.Columns[1].Width = 80;
                dgvParteDiario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvParteDiario.Columns[2].HeaderText = "Tema";
                dgvParteDiario.Columns[2].Width = 130;
                dgvParteDiario.Columns[3].HeaderText = "Proveedor";
                dgvParteDiario.Columns[3].Width = 130;
                dgvParteDiario.Columns[4].HeaderText = "Detalle";
                dgvParteDiario.Columns[4].Width = 300;
                
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.ToString());
            }

        }

        //=======================  METODOS DE BOTONERAS  =====================================
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            alAgregar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            apertura();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDetalle.Text == "")
            {
                MessageBox.Show("Ingrese Novedades");
            }
            else
            {
                Parte PD = new Parte();
                PD.FECHA = lblFecha.Text;
                PD.IDTIPO = int.Parse(cmbTema.SelectedValue.ToString());
                PD.IDPROCED = int.Parse(cmbProcede.SelectedValue.ToString());
                PD.DETALLE = txtDetalle.Text;
                if (cmbEstado.Text == "")
                {
                    cmbEstado.Text = "Pendiente";
                }
                PD.ESTADO = cmbEstado.Text;
                int res = Parte.guardaParte(PD);

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
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int orden=int.Parse(dgvParteDiario.CurrentRow.Cells[0].Value.ToString());
            Parte PD = new Parte();
            PD.IDPARTE = orden;
            PD.DETALLE = txtDetalle.Text;
            PD.ESTADO = cmbEstado.Text;
            int res = Parte.modificaParte(PD,orden);

            if (res == 1)
            {
                MessageBox.Show("Datos almacenados");
            }
            else
            {
                MessageBox.Show("Los datos no se guardaron");
            }
            apertura();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscaParte fbp = new frmBuscaParte();
            fbp.ShowDialog();
        }


        //========================  METODOS DE PRESENTACION Y LIMPIEZA  ===========================

        public void apertura()
        {
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = true;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = true;
            pnlEncabezado.Enabled = false;
            txtDetalle.Enabled = false; txtDetalle.Text = "";
        }
        public void alAgregar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnBuscar.Enabled = false;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = false;
            pnlEncabezado.Enabled = true;
            cmbEstado.Enabled = true;
            cmbProcede.Enabled = true;
            cmbTema.Enabled = true;
            txtDetalle.Enabled = true;txtDetalle.Text = "";
        }
        public void alModificar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
            btnBuscar.Enabled = false;
            btnActualizar.Enabled = true;
            btnSalir.Enabled = false;
            pnlEncabezado.Enabled = true;
            txtDetalle.Enabled = true;
            cmbEstado.Enabled = true;
            cmbProcede.Enabled = false;
            cmbTema.Enabled = false;
        }

        //========================  RUTINAS DE EVENTOS ================================================
        private void dgvParteDiario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbTema.Text= dgvParteDiario.CurrentRow.Cells[2].Value.ToString();
            cmbProcede.Text= dgvParteDiario.CurrentRow.Cells[3].Value.ToString();
            txtDetalle.Text = dgvParteDiario.CurrentRow.Cells[4].Value.ToString();
            lblFecha.Text= dgvParteDiario.CurrentRow.Cells[1].Value.ToString();
            cmbEstado.Text = "Pendiente";
            alModificar();
        }

        
    }
}
