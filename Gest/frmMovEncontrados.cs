using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;
using System.Windows.Forms;

namespace Gest
{
    public partial class frmMovEncontrados : Form
    {
        public frmMovEncontrados()
        {
            InitializeComponent();
        }

        private void frmMovEncontrados_Load(object sender, EventArgs e)
        {
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

            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;// impide la edición del dato seleccionado
            cmbTipo.Items.Add("REPARACIONES");
            cmbTipo.Items.Add("SERVICIOS");
            cmbTipo.Items.Add("GENERALES");
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            int eq = int.Parse(cmbEquipo.SelectedValue.ToString());
            txtDetalle.Text = "";
            DataTable dt = new DataTable();
            dt = MovEquipo.paraBusqueda(eq,cmbTipo.Text);

            dgvEncontrados.DataSource = dt;
            dgvEncontrados.ReadOnly = true;

            dgvEncontrados.Columns[0].HeaderText = "FECHA";
            dgvEncontrados.Columns[0].Width = 80;
            dgvEncontrados.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEncontrados.Columns[1].HeaderText = "ANOTACIONES";
            dgvEncontrados.Columns[1].Width = 750;
            dgvEncontrados.Columns[2].HeaderText = "HOROMETRO / KM";
            dgvEncontrados.Columns[2].Width = 100;
            dgvEncontrados.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // evento para seleccionar la fila del data grid y pasarla al campo de texto
        private void dgvEncontrados_DoubleClick(object sender, EventArgs e)
        {
            txtDetalle.Text = "";
            txtDetalle.Text = dgvEncontrados.CurrentRow.Cells[1].Value.ToString().Trim();
        }
    }
}
