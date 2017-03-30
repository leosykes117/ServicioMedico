namespace WRServicioMedico
{
    partial class frmBuscarPaciente
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
            this.components = new System.ComponentModel.Container();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lklAgregarPaciente = new System.Windows.Forms.LinkLabel();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDato = new ControlesValidaciones.PerTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Location = new System.Drawing.Point(102, 206);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            this.dgvPacientes.RowTemplate.Height = 24;
            this.dgvPacientes.Size = new System.Drawing.Size(621, 302);
            this.dgvPacientes.TabIndex = 0;
            this.dgvPacientes.Visible = false;
            this.dgvPacientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellClick);
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "-Tipo de Paciente-",
            "Alumno.",
            "Docente.",
            "PAAE.",
            "Externo"});
            this.cmbTipo.Location = new System.Drawing.Point(102, 134);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(251, 30);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Chalet", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Buscar Paciente";
            // 
            // lklAgregarPaciente
            // 
            this.lklAgregarPaciente.AutoSize = true;
            this.lklAgregarPaciente.Location = new System.Drawing.Point(630, 71);
            this.lklAgregarPaciente.Name = "lklAgregarPaciente";
            this.lklAgregarPaciente.Size = new System.Drawing.Size(167, 23);
            this.lklAgregarPaciente.TabIndex = 6;
            this.lklAgregarPaciente.TabStop = true;
            this.lklAgregarPaciente.Text = "Agregar Paciente";
            this.lklAgregarPaciente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklAgregarPaciente_LinkClicked);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(442, 134);
            this.txtDato.Name = "txtDato";
            this.txtDato.PlaceHolder = "Nombre o Boleta";
            this.txtDato.Requerido = true;
            this.txtDato.Size = new System.Drawing.Size(281, 30);
            this.txtDato.TabIndex = 2;
            this.txtDato.Click += new System.EventHandler(this.txtDato_Click);
            this.txtDato.TextChanged += new System.EventHandler(this.txtDato_TextChanged);
            // 
            // frmBuscarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 520);
            this.Controls.Add(this.lklAgregarPaciente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDato);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.dgvPacientes);
            this.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBuscarPaciente";
            this.Text = "Nueva Consulta";
            this.Load += new System.EventHandler(this.frmBuscarPaciente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.ComboBox cmbTipo;
        private ControlesValidaciones.PerTextBox txtDato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lklAgregarPaciente;
        private System.Windows.Forms.ErrorProvider ep;
    }
}