namespace WRServicioMedico
{
    partial class frmVerConsultas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbBuscarPor = new System.Windows.Forms.ComboBox();
            this.txtDato = new ControlesValidaciones.PerTextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1025, 366);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Visible = false;
            // 
            // cmbBuscarPor
            // 
            this.cmbBuscarPor.FormattingEnabled = true;
            this.cmbBuscarPor.Items.AddRange(new object[] {
            "-Buscar Por-",
            "Nombre",
            "Boleta",
            "Tratamiento"});
            this.cmbBuscarPor.Location = new System.Drawing.Point(499, 77);
            this.cmbBuscarPor.Name = "cmbBuscarPor";
            this.cmbBuscarPor.Size = new System.Drawing.Size(227, 30);
            this.cmbBuscarPor.TabIndex = 6;
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(732, 77);
            this.txtDato.Name = "txtDato";
            this.txtDato.PlaceHolder = "Nombre o Boleta";
            this.txtDato.Requerido = true;
            this.txtDato.Size = new System.Drawing.Size(281, 30);
            this.txtDato.TabIndex = 5;
            this.txtDato.TextChanged += new System.EventHandler(this.txtDato_TextChanged);
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
            this.cmbTipo.Location = new System.Drawing.Point(12, 77);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(251, 30);
            this.cmbTipo.TabIndex = 4;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "-Mes-",
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cmbMes.Location = new System.Drawing.Point(269, 77);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(224, 30);
            this.cmbMes.TabIndex = 7;
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmbMes_SelectedIndexChanged);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // frmVerConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 534);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.cmbBuscarPor);
            this.Controls.Add(this.txtDato);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmVerConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Consultas";
            this.Load += new System.EventHandler(this.frmVerConsultas_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbBuscarPor;
        private ControlesValidaciones.PerTextBox txtDato;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ErrorProvider ep;
    }
}