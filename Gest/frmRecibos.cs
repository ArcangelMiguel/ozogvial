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
    public partial class frmRecibos : Form
    {
        public frmRecibos()
        {
            InitializeComponent();
        }

        private void frmRecibos_Load(object sender, EventArgs e)
        {
            Size = new Size(877, 216);
            DateTime hoy = DateTime.Now;
            lblFecha.Text = hoy.ToShortDateString();
            apertura();
            cargaComboEmpleados();
            cargaComboObras();
            cmbEmpleado.Text = "";
            cargaDataGridRecibos();

        }

        //============================== ALGORITMOS DE LIMPIEZA Y PRESENTACION =============================

        private void apertura()
        {
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = true;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = true;
            pnlEncabezado.Enabled = false;
           
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
            cmbEmpleado.Enabled = true;
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
            cmbEmpleado.Enabled = true;
            cmbEstado.Enabled = true;
        }

        public void cargaComboEmpleados()
        {
            try //Extraemos los tipos para llenar un combo
            {
                DataTable dt = new DataTable();
                dt = Empleado.extraeEmpleadoCombo();
                cmbEmpleado.DisplayMember = "nombre";
                cmbEmpleado.ValueMember = "id_Empleado";
                cmbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbEmpleado.DataSource = dt;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.ToString());
            }
        }

        public void cargaComboObras()
        {
            DataTable dt = new DataTable();
            dt = Obra.extraeObra();

            cmbObra.DisplayMember = "alias";
            cmbObra.ValueMember = "id_Obra";
            cmbObra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbObra.DataSource = dt;
        }

        public void cargaDataGridRecibos()
        {
            DataTable dt = new DataTable();
            dt = Recibo.extraeRecibos();
            dgvRecibos.DataSource = dt;
            dgvRecibos.ReadOnly = true;

        }
        

        //============================== Algoritmos Eventuales =============================================

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.NumerosDecimales(e);
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMonto.Text == String.Empty || txtMonto.Text == "")
                {
                    txtMonto.Text = "0.00";
                }
                Decimal refer;
                refer = Convert.ToDecimal(txtMonto.Text);
                txtMonto.Text = refer.ToString("N2");

                txtMontoEscrito.Text = Conversion.enletras(txtMonto.Text.ToString());
            }
            catch (Exception er)
            {
                MessageBox.Show("++ INGRESE UN VALOR NUMERICO VALIDO.\n ++ DE LO CONTRARIO INGRESE CERO (0). \n ==================== \n " + er.ToString());
            }

        }

        //============================== algoritmos de  botoneras ====================================
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Size = new Size(877, 380);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
