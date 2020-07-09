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
        DateTime hoy = DateTime.Now; // habilito la fecha actual =======================

        private void frmNovedadEquipo_Load(object sender, EventArgs e)
        {
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
            lblFecha.Text = hoy.ToShortDateString();
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = true;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = true;
            pnlEncabezado.Enabled = true;
            cmbEquipo.Enabled = true;
            cmbObra.Enabled = false;
            cmbTipo.Enabled = false;cmbTipo.Text = "";
            txtDetalle.Enabled = false; txtDetalle.Text = "";
            txtHoras.Enabled = false;txtHoras.Text = "";
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
            txtHoras.Enabled = true;
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
            txtDetalle.Enabled = true; txtHoras.Enabled = true;
            cmbEquipo.Enabled = false;
            cmbObra.Enabled = false;
            cmbTipo.Enabled = false;
            btnAgregaObra.Enabled = true;
            btnAgregaTipo.Enabled = true;
        }
        public void cargaNovedades()
        {
            DataTable dt = new DataTable();
            dt = MovEquipo.buscarPorEquipo(int.Parse(cmbEquipo.SelectedValue.ToString()));

            dgvNovedades.DataSource = dt; dgvNovedades.ReadOnly = true;
            dgvNovedades.Columns[0].HeaderText = "ORDEN";
            dgvNovedades.Columns[0].Width = 40;
            dgvNovedades.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNovedades.Columns[1].HeaderText = "FECHA";
            dgvNovedades.Columns[1].Width = 60;
            dgvNovedades.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNovedades.Columns[2].HeaderText = "TIPO";
            dgvNovedades.Columns[2].Width = 100;
            dgvNovedades.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNovedades.Columns[3].HeaderText = "DESCRIPCION";
            dgvNovedades.Columns[3].Width = 280;
            dgvNovedades.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvNovedades.Columns[4].HeaderText = "HORAS / KM";
            dgvNovedades.Columns[4].Width = 85;
            dgvNovedades.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            cargaNovedades();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MovEquipo MEq = new MovEquipo();
            int orden = int.Parse(dgvNovedades.CurrentRow.Cells[0].Value.ToString());
            MEq.IDMEQ = orden;
            MEq.DETALLE = txtDetalle.Text;
            if (txtHoras.Text == "")
            {
                MEq.NUMERO = 0;
            }
            else
            {
                MEq.NUMERO = float.Parse(txtHoras.Text);
            }
            int res = MovEquipo.modifMovEquipo(MEq,orden);

            if (res == 1)
            {
                MessageBox.Show("Datos almacenados");
            }
            else
            {
                MessageBox.Show("Los datos no se guardaron");
            }
            apertura();
            cargaNovedades();
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

        private void cmbEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaNovedades();
        }

        private void dgvNovedades_DoubleClick(object sender, EventArgs e)
        {
            alModificar();
            lblFecha.Text = dgvNovedades.CurrentRow.Cells[1].Value.ToString();
            cmbTipo.Text = dgvNovedades.CurrentRow.Cells[2].Value.ToString();
            txtDetalle.Text = dgvNovedades.CurrentRow.Cells[3].Value.ToString();
            txtHoras.Text= dgvNovedades.CurrentRow.Cells[4].Value.ToString();
        }

    }
}
