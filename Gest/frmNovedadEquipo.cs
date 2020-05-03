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
    public partial class frmNovedadEquipo : Form
    {
        public frmNovedadEquipo()
        {
            InitializeComponent();
        }

        private void frmNovedadEquipo_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            lblFecha.Text = hoy.ToShortDateString();
            apertura();

            // cargamos el combo de los equipos
            try 
            {
                DataTable dt = new DataTable();
                dt = Equipo.partEquipo();

                cmbEquipo.DisplayMember = "alias";
                cmbEquipo.ValueMember = "id_Equipo";
                cmbEquipo.DropDownStyle = ComboBoxStyle.DropDownList;// impide la edición del dato seleccionado
                cmbEquipo.DataSource = dt;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.ToString());
            }

            // cargamos el combo de las OBRAS
            try
            {
                DataTable dt = new DataTable();
                dt = Obra.extraeObra();

                cmbObra.DisplayMember = "alias";
                cmbObra.ValueMember = "id_Obra";
                cmbObra.DropDownStyle = ComboBoxStyle.DropDownList; // impide la edición del dato seleccionado
                cmbObra.DataSource = dt;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.ToString());
            }

            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;// impide la edición del dato seleccionado
            cmbTipo.Items.Add("REPARACIONES");
            cmbTipo.Items.Add("SERVICIOS");
            cmbTipo.Items.Add("GENERALES");
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
            cmbObra.Enabled = false;
            cmbTipo.Enabled = false;
            txtDetalle.Enabled = false; txtDetalle.Text = "";
            btnAgregaObra.Enabled = false;
            btnAgregaTipo.Enabled = false;
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
            cmbEquipo.Enabled = true;
            cmbObra.Enabled = true;
            cmbTipo.Enabled = true;
            txtDetalle.Enabled = true; txtDetalle.Text = "";
            btnAgregaObra.Enabled = true;
            btnAgregaTipo.Enabled = true;
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
            cmbEquipo.Enabled = true;
            cmbObra.Enabled = true;
            cmbTipo.Enabled = true;
            btnAgregaObra.Enabled = true;
            btnAgregaTipo.Enabled = true;
        }

        //========================  ALGORITMOS DE BOTONERA =======================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            alAgregar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDetalle.Text == "")
            {
                MessageBox.Show("Ingrese Novedades");
            }
            else
            {
                MovEquipo MEq = new MovEquipo();
                MEq.FECHA = lblFecha.Text;
                MEq.EQUIPO= int.Parse(cmbEquipo.SelectedValue.ToString());
                MEq.OBRA= int.Parse(cmbObra.SelectedValue.ToString());
                MEq.TIPO = cmbTipo.Text;
                MEq.DETALLE = txtDetalle.Text;
                if (txtHoras.Text == "")
                {
                    MEq.NUMERO = 0;
                }
                else
                {
                    MEq.NUMERO = float.Parse(txtHoras.Text);
                }
                int res = MovEquipo.guardaMovEquipo(MEq);

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmMovEncontrados fr = new frmMovEncontrados();
            fr.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            apertura();   
        }

        private void btnAgregaObra_Click(object sender, EventArgs e)
        {
            frmNuevaObra NO = new frmNuevaObra();
            NO.ShowDialog();
        }

        //========================  ALGORITMOS DE EVENTOS =======================================
        private void txtHoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.NumerosDecimales(e);
        }

        
    }
}
