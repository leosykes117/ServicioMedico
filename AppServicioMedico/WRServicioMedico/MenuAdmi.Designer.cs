namespace WRServicioMedico
{
    partial class frmMenuAdmi
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
            this.lblMensaje = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.doctoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trvDoctores = new System.Windows.Forms.TreeView();
            this.pnlArbol = new System.Windows.Forms.Panel();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificarDoctor = new System.Windows.Forms.Button();
            this.cmbConsultorio = new System.Windows.Forms.ComboBox();
            this.lklMasOp = new System.Windows.Forms.LinkLabel();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtCorreo = new ControlesValidaciones.PerTextBox();
            this.txtUsuario = new ControlesValidaciones.PerTextBox();
            this.txtNombre = new ControlesValidaciones.PerTextBox();
            this.menuStrip1.SuspendLayout();
            this.pnlArbol.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Chalet", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(118, 81);
            this.lblMensaje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 41);
            this.lblMensaje.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doctoresToolStripMenuItem,
            this.pacientesToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1142, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // doctoresToolStripMenuItem
            // 
            this.doctoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoDoctorToolStripMenuItem,
            this.editarDoctorToolStripMenuItem,
            this.eliminarDoctorToolStripMenuItem});
            this.doctoresToolStripMenuItem.Name = "doctoresToolStripMenuItem";
            this.doctoresToolStripMenuItem.Size = new System.Drawing.Size(99, 27);
            this.doctoresToolStripMenuItem.Text = "Doctores";
            // 
            // nuevoDoctorToolStripMenuItem
            // 
            this.nuevoDoctorToolStripMenuItem.Name = "nuevoDoctorToolStripMenuItem";
            this.nuevoDoctorToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.nuevoDoctorToolStripMenuItem.Text = "Nuevo Doctor";
            this.nuevoDoctorToolStripMenuItem.Click += new System.EventHandler(this.nuevoDoctorToolStripMenuItem_Click);
            // 
            // editarDoctorToolStripMenuItem
            // 
            this.editarDoctorToolStripMenuItem.Name = "editarDoctorToolStripMenuItem";
            this.editarDoctorToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.editarDoctorToolStripMenuItem.Text = "Editar Doctor";
            this.editarDoctorToolStripMenuItem.Click += new System.EventHandler(this.editarDoctorToolStripMenuItem_Click);
            // 
            // eliminarDoctorToolStripMenuItem
            // 
            this.eliminarDoctorToolStripMenuItem.Name = "eliminarDoctorToolStripMenuItem";
            this.eliminarDoctorToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.eliminarDoctorToolStripMenuItem.Text = "Eliminar Doctor";
            this.eliminarDoctorToolStripMenuItem.Click += new System.EventHandler(this.eliminarDoctorToolStripMenuItem_Click);
            // 
            // pacientesToolStripMenuItem
            // 
            this.pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            this.pacientesToolStripMenuItem.Size = new System.Drawing.Size(107, 27);
            this.pacientesToolStripMenuItem.Text = "Pacientes";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(98, 27);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(140, 27);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // trvDoctores
            // 
            this.trvDoctores.Location = new System.Drawing.Point(12, 3);
            this.trvDoctores.Name = "trvDoctores";
            this.trvDoctores.Size = new System.Drawing.Size(311, 406);
            this.trvDoctores.TabIndex = 2;
            this.trvDoctores.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDoctores_AfterSelect);
            // 
            // pnlArbol
            // 
            this.pnlArbol.Controls.Add(this.trvDoctores);
            this.pnlArbol.Location = new System.Drawing.Point(0, 166);
            this.pnlArbol.Name = "pnlArbol";
            this.pnlArbol.Size = new System.Drawing.Size(326, 412);
            this.pnlArbol.TabIndex = 3;
            this.pnlArbol.Visible = false;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Controls.Add(this.cmbGenero);
            this.pnlDatos.Controls.Add(this.btnCancelar);
            this.pnlDatos.Controls.Add(this.btnModificarDoctor);
            this.pnlDatos.Controls.Add(this.txtCorreo);
            this.pnlDatos.Controls.Add(this.cmbConsultorio);
            this.pnlDatos.Controls.Add(this.txtUsuario);
            this.pnlDatos.Controls.Add(this.txtNombre);
            this.pnlDatos.Location = new System.Drawing.Point(498, 169);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(586, 286);
            this.pnlDatos.TabIndex = 4;
            this.pnlDatos.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(358, 201);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(165, 57);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificarDoctor
            // 
            this.btnModificarDoctor.Location = new System.Drawing.Point(52, 201);
            this.btnModificarDoctor.Name = "btnModificarDoctor";
            this.btnModificarDoctor.Size = new System.Drawing.Size(165, 57);
            this.btnModificarDoctor.TabIndex = 8;
            this.btnModificarDoctor.Text = "Aceptar";
            this.btnModificarDoctor.UseVisualStyleBackColor = true;
            this.btnModificarDoctor.Click += new System.EventHandler(this.btnModificarDoctor_Click);
            // 
            // cmbConsultorio
            // 
            this.cmbConsultorio.FormattingEnabled = true;
            this.cmbConsultorio.Items.AddRange(new object[] {
            "",
            "Medicina General Matutino.",
            "Medicina General Vespertino.",
            "Odontología."});
            this.cmbConsultorio.Location = new System.Drawing.Point(311, 68);
            this.cmbConsultorio.Name = "cmbConsultorio";
            this.cmbConsultorio.Size = new System.Drawing.Size(258, 30);
            this.cmbConsultorio.TabIndex = 4;
            // 
            // lklMasOp
            // 
            this.lklMasOp.AutoSize = true;
            this.lklMasOp.Location = new System.Drawing.Point(980, 81);
            this.lklMasOp.Name = "lklMasOp";
            this.lklMasOp.Size = new System.Drawing.Size(136, 23);
            this.lklMasOp.TabIndex = 5;
            this.lklMasOp.TabStop = true;
            this.lklMasOp.Text = "Mas Opciones";
            this.lklMasOp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklMasOp_LinkClicked);
            // 
            // cmbGenero
            // 
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "",
            "Masculino",
            "Femenino"});
            this.cmbGenero.Location = new System.Drawing.Point(14, 68);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(270, 30);
            this.cmbGenero.TabIndex = 6;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(3, 135);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.PlaceHolder = null;
            this.txtCorreo.Requerido = false;
            this.txtCorreo.Size = new System.Drawing.Size(291, 30);
            this.txtCorreo.TabIndex = 6;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(311, 15);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PlaceHolder = null;
            this.txtUsuario.Requerido = false;
            this.txtUsuario.Size = new System.Drawing.Size(258, 30);
            this.txtUsuario.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(3, 15);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceHolder = null;
            this.txtNombre.Requerido = false;
            this.txtNombre.Size = new System.Drawing.Size(291, 30);
            this.txtNombre.TabIndex = 0;
            // 
            // frmMenuAdmi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 576);
            this.Controls.Add(this.lklMasOp);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlArbol);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenuAdmi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenuAdmi_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlArbol.ResumeLayout(false);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem doctoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoDoctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarDoctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarDoctorToolStripMenuItem;
        private System.Windows.Forms.TreeView trvDoctores;
        private System.Windows.Forms.Panel pnlArbol;
        private System.Windows.Forms.Panel pnlDatos;
        private ControlesValidaciones.PerTextBox txtUsuario;
        private ControlesValidaciones.PerTextBox txtNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificarDoctor;
        private ControlesValidaciones.PerTextBox txtCorreo;
        private System.Windows.Forms.ComboBox cmbConsultorio;
        private System.Windows.Forms.ToolStripMenuItem pacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lklMasOp;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.ErrorProvider ep;
    }
}