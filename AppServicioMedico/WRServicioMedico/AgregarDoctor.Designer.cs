namespace WRServicioMedico
{
    partial class frmAgregarDoctor
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
            this.rdbMasculino = new System.Windows.Forms.RadioButton();
            this.rdbFemenino = new System.Windows.Forms.RadioButton();
            this.cmbConsultorio = new System.Windows.Forms.ComboBox();
            this.btnAgregarDoctor = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtConfirmarContraseña = new ControlesValidaciones.PerTextBox();
            this.txtContraseña = new ControlesValidaciones.PerTextBox();
            this.txtCorreo = new ControlesValidaciones.PerTextBox();
            this.txtUsuario = new ControlesValidaciones.PerTextBox();
            this.txtNombre = new ControlesValidaciones.PerTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbMasculino
            // 
            this.rdbMasculino.AutoSize = true;
            this.rdbMasculino.Location = new System.Drawing.Point(144, 158);
            this.rdbMasculino.Name = "rdbMasculino";
            this.rdbMasculino.Size = new System.Drawing.Size(124, 27);
            this.rdbMasculino.TabIndex = 2;
            this.rdbMasculino.TabStop = true;
            this.rdbMasculino.Text = "Masculino";
            this.rdbMasculino.UseVisualStyleBackColor = true;
            // 
            // rdbFemenino
            // 
            this.rdbFemenino.AutoSize = true;
            this.rdbFemenino.Location = new System.Drawing.Point(274, 158);
            this.rdbFemenino.Name = "rdbFemenino";
            this.rdbFemenino.Size = new System.Drawing.Size(118, 27);
            this.rdbFemenino.TabIndex = 3;
            this.rdbFemenino.TabStop = true;
            this.rdbFemenino.Text = "Femenino";
            this.rdbFemenino.UseVisualStyleBackColor = true;
            // 
            // cmbConsultorio
            // 
            this.cmbConsultorio.FormattingEnabled = true;
            this.cmbConsultorio.Items.AddRange(new object[] {
            "-Consultorio-",
            "Medicina General Matutino.",
            "Medicina General Vespertino.",
            "Odontología."});
            this.cmbConsultorio.Location = new System.Drawing.Point(147, 216);
            this.cmbConsultorio.Name = "cmbConsultorio";
            this.cmbConsultorio.Size = new System.Drawing.Size(245, 30);
            this.cmbConsultorio.TabIndex = 4;
            // 
            // btnAgregarDoctor
            // 
            this.btnAgregarDoctor.Location = new System.Drawing.Point(117, 428);
            this.btnAgregarDoctor.Name = "btnAgregarDoctor";
            this.btnAgregarDoctor.Size = new System.Drawing.Size(124, 47);
            this.btnAgregarDoctor.TabIndex = 8;
            this.btnAgregarDoctor.Text = "Aceptar";
            this.btnAgregarDoctor.UseVisualStyleBackColor = true;
            this.btnAgregarDoctor.Click += new System.EventHandler(this.btnAgregarDoctor_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(297, 428);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 47);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // txtConfirmarContraseña
            // 
            this.txtConfirmarContraseña.ForeColor = System.Drawing.Color.DimGray;
            this.txtConfirmarContraseña.Location = new System.Drawing.Point(147, 368);
            this.txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.PlaceHolder = "Confirme Contraseña";
            this.txtConfirmarContraseña.Requerido = true;
            this.txtConfirmarContraseña.Size = new System.Drawing.Size(245, 30);
            this.txtConfirmarContraseña.TabIndex = 7;
            this.txtConfirmarContraseña.Click += new System.EventHandler(this.txtConfirmarContraseña_Click);
            this.txtConfirmarContraseña.TextChanged += new System.EventHandler(this.txtConfirmarContraseña_TextChanged);
            // 
            // txtContraseña
            // 
            this.txtContraseña.ForeColor = System.Drawing.Color.DimGray;
            this.txtContraseña.Location = new System.Drawing.Point(147, 317);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PlaceHolder = "Contraseña";
            this.txtContraseña.Requerido = true;
            this.txtContraseña.Size = new System.Drawing.Size(245, 30);
            this.txtContraseña.TabIndex = 6;
            this.txtContraseña.Click += new System.EventHandler(this.txtContraseña_Click);
            this.txtContraseña.TextChanged += new System.EventHandler(this.txtContraseña_TextChanged);
            // 
            // txtCorreo
            // 
            this.txtCorreo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCorreo.Location = new System.Drawing.Point(147, 266);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.PlaceHolder = "Correo Electronico";
            this.txtCorreo.Requerido = true;
            this.txtCorreo.Size = new System.Drawing.Size(245, 30);
            this.txtCorreo.TabIndex = 5;
            this.txtCorreo.Click += new System.EventHandler(this.txtCorreo_Click);
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsuario.Location = new System.Drawing.Point(144, 99);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PlaceHolder = "Nombre de Usuario";
            this.txtUsuario.Requerido = true;
            this.txtUsuario.Size = new System.Drawing.Size(248, 30);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Click += new System.EventHandler(this.txtUsuario_Click);
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(144, 54);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceHolder = "Nombre del Doctor";
            this.txtNombre.Requerido = true;
            this.txtNombre.Size = new System.Drawing.Size(248, 30);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Click += new System.EventHandler(this.txtNombre_Click);
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // frmAgregarDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 495);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregarDoctor);
            this.Controls.Add(this.txtConfirmarContraseña);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.cmbConsultorio);
            this.Controls.Add(this.rdbFemenino);
            this.Controls.Add(this.rdbMasculino);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtNombre);
            this.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAgregarDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Doctor";
            this.Load += new System.EventHandler(this.frmAgregarDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlesValidaciones.PerTextBox txtNombre;
        private ControlesValidaciones.PerTextBox txtUsuario;
        private System.Windows.Forms.RadioButton rdbMasculino;
        private System.Windows.Forms.RadioButton rdbFemenino;
        private System.Windows.Forms.ComboBox cmbConsultorio;
        private ControlesValidaciones.PerTextBox txtCorreo;
        private ControlesValidaciones.PerTextBox txtContraseña;
        private ControlesValidaciones.PerTextBox txtConfirmarContraseña;
        private System.Windows.Forms.Button btnAgregarDoctor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider ep;
    }
}