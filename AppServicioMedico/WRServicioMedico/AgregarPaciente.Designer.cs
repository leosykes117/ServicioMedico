namespace WRServicioMedico
{
    partial class frmAgregarPaciente
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
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtNombre = new ControlesValidaciones.PerTextBox();
            this.cmbCarrera = new System.Windows.Forms.ComboBox();
            this.txtGrupo = new ControlesValidaciones.PerTextBox();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.txtBoleta = new ControlesValidaciones.PerTextBox();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "-Tipo de Paciente-",
            "Alumno.",
            "Docente.",
            "PAAE.",
            "Externo."});
            this.cmbTipo.Location = new System.Drawing.Point(60, 54);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(160, 30);
            this.cmbTipo.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(60, 111);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceHolder = "Nombre del Paciente";
            this.txtNombre.Requerido = true;
            this.txtNombre.Size = new System.Drawing.Size(316, 30);
            this.txtNombre.TabIndex = 1;
            // 
            // cmbCarrera
            // 
            this.cmbCarrera.FormattingEnabled = true;
            this.cmbCarrera.Items.AddRange(new object[] {
            "-Carrera-",
            "Tecnico en Informatica.",
            "Tecnico en Administracion.",
            "Tecnico en Contabilidad.",
            "Tecnico en Administracion de Empresas Turisticas.",
            "Tronco Comun."});
            this.cmbCarrera.Location = new System.Drawing.Point(60, 280);
            this.cmbCarrera.Name = "cmbCarrera";
            this.cmbCarrera.Size = new System.Drawing.Size(316, 30);
            this.cmbCarrera.TabIndex = 5;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(60, 345);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.PlaceHolder = "Grupo";
            this.txtGrupo.Requerido = true;
            this.txtGrupo.Size = new System.Drawing.Size(167, 30);
            this.txtGrupo.TabIndex = 6;
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Location = new System.Drawing.Point(60, 400);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(141, 48);
            this.btnAgregarUsuario.TabIndex = 7;
            this.btnAgregarUsuario.Text = "Agregar";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // txtBoleta
            // 
            this.txtBoleta.Location = new System.Drawing.Point(60, 226);
            this.txtBoleta.Name = "txtBoleta";
            this.txtBoleta.PlaceHolder = "Boleta o PM";
            this.txtBoleta.Requerido = true;
            this.txtBoleta.Size = new System.Drawing.Size(246, 30);
            this.txtBoleta.TabIndex = 4;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // cmbGenero
            // 
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "-Genero-",
            "Masculino",
            "Femenino"});
            this.cmbGenero.Location = new System.Drawing.Point(60, 168);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(223, 30);
            this.cmbGenero.TabIndex = 8;
            // 
            // frmAgregarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 460);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.txtBoleta);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Controls.Add(this.txtGrupo);
            this.Controls.Add(this.cmbCarrera);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmbTipo);
            this.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAgregarPaciente";
            this.Text = "Agregar Paciente";
            this.Load += new System.EventHandler(this.AgregarPaciente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipo;
        private ControlesValidaciones.PerTextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbCarrera;
        private ControlesValidaciones.PerTextBox txtGrupo;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private ControlesValidaciones.PerTextBox txtBoleta;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.ComboBox cmbGenero;
    }
}