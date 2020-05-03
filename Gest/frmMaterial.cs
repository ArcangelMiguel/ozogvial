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
    public partial class frmMaterial : Form
    {
        public frmMaterial()
        {
            InitializeComponent();
        }

        private void frmMaterial_Load(object sender, EventArgs e)
        {
            apertura();
            cargaMateriales();
            // Dejamos inhabilitados los campos numericos, salvo el de referencia
            txtAdquirido.Enabled = false;
            txtRecibido.Enabled = false;
            txtStock.Enabled = false;
            txtProceso.Enabled = false;
            //----------------------------------------
            
            //Extraemos los tipos para llenar un combo
            try
            {
                DataTable dt = new DataTable();
                dt = Tipo.extraeTipos();

                cmbTipo.DisplayMember = "detalle";
                cmbTipo.ValueMember = "id_Tipo";
                cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbTipo.DataSource = dt;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.ToString());
            }            
        }

        //========================  METODOS DE PRESENTACION Y LIMPIEZA  ===========================

        public void apertura()
        {
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnActualizar.Enabled= false;
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
            cmbTipo.Enabled = true;
            txtAdquirido.Text = "0.00";
            txtRecibido.Text = "0.00";
            txtProceso.Text = "0.00";
            txtStock.Text = "0.00";
        }
        public void alModificar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;           
            btnActualizar.Enabled = true;
            btnSalir.Enabled = false;
            pnlEncabezado.Enabled = true;
            cmbTipo.Enabled = false;
        }
        public void cargaMateriales()
        {
            //cargamos la grilla de materiales
            try
            {
                DataTable dt = new DataTable();
                dt = Material.extraeTodos();
                dgvMateriales.DataSource = dt; dgvMateriales.ReadOnly = true;
                dgvMateriales.Columns[0].HeaderText = "N°";
                dgvMateriales.Columns[0].Width = 30;
                dgvMateriales.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMateriales.Columns[1].HeaderText = "Tipo";
                dgvMateriales.Columns[1].Width = 80;
                dgvMateriales.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMateriales.Columns[2].HeaderText = "Descripción";
                dgvMateriales.Columns[2].Width = 150;
                dgvMateriales.Columns[3].HeaderText = "Unidad";
                dgvMateriales.Columns[3].Width = 60;
                dgvMateriales.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMateriales.Columns[4].HeaderText = "Cant.Adquirida";
                dgvMateriales.Columns[4].Width = 80;
                dgvMateriales.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMateriales.Columns[5].HeaderText = "Cant.Recibida";
                dgvMateriales.Columns[5].Width = 80;
                dgvMateriales.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMateriales.Columns[6].HeaderText = "A Procesar";
                dgvMateriales.Columns[6].Width = 80;
                dgvMateriales.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMateriales.Columns[7].HeaderText = "Stock Actual";
                dgvMateriales.Columns[7].Width = 80;
                dgvMateriales.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMateriales.Columns[8].HeaderText = "Referencia";
                dgvMateriales.Columns[8].Width = 80;
                dgvMateriales.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMateriales.Columns[9].HeaderText = "Anotaciones";
                dgvMateriales.Columns[9].Width = 280;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.ToString());
            }
        }

        //=======================  METODOS DE BOTONERAS  =====================================
       
        private void btnSalir_Click_1(object sender, EventArgs e)
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
                MessageBox.Show("Ingrese una descripción del recurso");
            }
            else
            {
                Material Mat = new Material();
                Mat.IDTIPO = int.Parse(cmbTipo.SelectedValue.ToString());
                Mat.DETALLE = txtDetalle.Text;
                Mat.UNIDAD = txtUnidad.Text;
                Mat.ADQUIRIDO = float.Parse(txtAdquirido.Text.ToString());
                Mat.RECIBIDO = float.Parse(txtRecibido.Text.ToString());
                Mat.PROCESO = float.Parse(txtProceso.Text.ToString());
                Mat.STOCK = float.Parse(txtStock.Text.ToString());
                Mat.REFERENCIA = float.Parse(txtReferencia.Text.ToString());
                Mat.ANOTA = txtAnota.Text;
               
                int res = Material.guardaMaterial(Mat);

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
            cargaMateriales();
        }

        //=======================  ALGORITMOS  EVENTUALES  =====================================
        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.NumerosDecimales(e);
        }

        private void txtReferencia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtReferencia.Text == String.Empty || txtReferencia.Text == "")
                {
                    txtReferencia.Text = "0.00";
                }
                Decimal refer;
                refer = Convert.ToDecimal(txtReferencia.Text);
                txtReferencia.Text = refer.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("++ INGRESE UN VALOR NUMERICO VALIDO.\n ++ DE LO CONTRARIO INGRESE CERO (0). \n ==================== \n " + er.ToString());
            }
        }

        
    }
}
