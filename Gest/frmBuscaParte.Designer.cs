namespace Gest
{
    partial class frmBuscaParte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.btnActualiza = new System.Windows.Forms.Button();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cmbDato = new System.Windows.Forms.ComboBox();
            this.cmbBusqueda = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPartes = new System.Windows.Forms.DataGridView();
            this.pnlEncabezado.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(171)))), ((int)(((byte)(201)))));
            this.pnlEncabezado.Controls.Add(this.btnActualiza);
            this.pnlEncabezado.Controls.Add(this.txtDetalle);
            this.pnlEncabezado.Controls.Add(this.btnSalir);
            this.pnlEncabezado.Controls.Add(this.cmbDato);
            this.pnlEncabezado.Controls.Add(this.cmbBusqueda);
            this.pnlEncabezado.Controls.Add(this.label2);
            this.pnlEncabezado.Controls.Add(this.cmbEstado);
            this.pnlEncabezado.Controls.Add(this.label1);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(800, 121);
            this.pnlEncabezado.TabIndex = 0;
            // 
            // btnActualiza
            // 
            this.btnActualiza.BackColor = System.Drawing.Color.Teal;
            this.btnActualiza.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualiza.ForeColor = System.Drawing.Color.White;
            this.btnActualiza.Location = new System.Drawing.Point(118, 88);
            this.btnActualiza.Name = "btnActualiza";
            this.btnActualiza.Size = new System.Drawing.Size(95, 23);
            this.btnActualiza.TabIndex = 38;
            this.btnActualiza.Text = "Actualizar";
            this.btnActualiza.UseVisualStyleBackColor = false;
            this.btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(320, 8);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalle.Size = new System.Drawing.Size(477, 103);
            this.txtDetalle.TabIndex = 37;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Teal;
            this.btnSalir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(219, 88);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 23);
            this.btnSalir.TabIndex = 36;
            this.btnSalir.Text = "Cerrar Búsqueda";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // cmbDato
            // 
            this.cmbDato.FormattingEnabled = true;
            this.cmbDato.Location = new System.Drawing.Point(74, 35);
            this.cmbDato.Name = "cmbDato";
            this.cmbDato.Size = new System.Drawing.Size(240, 21);
            this.cmbDato.TabIndex = 4;
            this.cmbDato.SelectedIndexChanged += new System.EventHandler(this.cmbDato_SelectedIndexChanged);
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.FormattingEnabled = true;
            this.cmbBusqueda.Items.AddRange(new object[] {
            "Tema",
            "Procedencia",
            "Todos"});
            this.cmbBusqueda.Location = new System.Drawing.Point(74, 8);
            this.cmbBusqueda.Name = "cmbBusqueda";
            this.cmbBusqueda.Size = new System.Drawing.Size(139, 21);
            this.cmbBusqueda.TabIndex = 3;
            this.cmbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbBusqueda_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar por:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Cerrado",
            "Pagado"});
            this.cmbEstado.Location = new System.Drawing.Point(99, 62);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(114, 21);
            this.cmbEstado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cambiar estado a:";
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.Controls.Add(this.label3);
            this.pnlCuerpo.Controls.Add(this.dgvPartes);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 121);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(800, 329);
            this.pnlCuerpo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(794, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "PARTES DIARIOS ENCONTRADOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPartes
            // 
            this.dgvPartes.AllowUserToAddRows = false;
            this.dgvPartes.AllowUserToDeleteRows = false;
            this.dgvPartes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartes.Location = new System.Drawing.Point(3, 26);
            this.dgvPartes.Name = "dgvPartes";
            this.dgvPartes.ReadOnly = true;
            this.dgvPartes.RowHeadersVisible = false;
            this.dgvPartes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartes.Size = new System.Drawing.Size(794, 321);
            this.dgvPartes.TabIndex = 0;
            this.dgvPartes.DoubleClick += new System.EventHandler(this.dgvPartes_DoubleClick);
            // 
            // frmBuscaParte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlEncabezado);
            this.Name = "frmBuscaParte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSQUEDA DE PARTES DIARIOS";
            this.Load += new System.EventHandler(this.frmBuscaParte_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlCuerpo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.DataGridView dgvPartes;
        private System.Windows.Forms.ComboBox cmbDato;
        private System.Windows.Forms.ComboBox cmbBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Button btnActualiza;
        private System.Windows.Forms.Label label3;
    }
}