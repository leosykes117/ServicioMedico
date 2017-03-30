namespace WRServicioMedico
{
    partial class frmMenuPrincipal
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
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verConsultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenContraseña = new System.Windows.Forms.Button();
            this.pnlCambioContraseña = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCambiarContraseña = new System.Windows.Forms.Button();
            this.txtConfirmarContraseña = new ControlesValidaciones.PerTextBox();
            this.txtNuevaContraseña = new ControlesValidaciones.PerTextBox();
            this.txtContraseñaActual = new ControlesValidaciones.PerTextBox();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlTablaCambios = new System.Windows.Forms.Panel();
            this.btnOcultarDataGrid = new System.Windows.Forms.Button();
            this.dgvRegistrosContraseñas = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.pnlCambioContraseña.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.pnlTablaCambios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosContraseñas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Chalet", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(75, 105);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 41);
            this.lblMensaje.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultasToolStripMenuItem,
            this.pacientesToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1078, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaConsultaToolStripMenuItem,
            this.verConsultasToolStripMenuItem,
            this.editarConsultaToolStripMenuItem,
            this.eliminarConsultaToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(106, 27);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // nuevaConsultaToolStripMenuItem
            // 
            this.nuevaConsultaToolStripMenuItem.Name = "nuevaConsultaToolStripMenuItem";
            this.nuevaConsultaToolStripMenuItem.Size = new System.Drawing.Size(243, 28);
            this.nuevaConsultaToolStripMenuItem.Text = "Nueva Consulta";
            this.nuevaConsultaToolStripMenuItem.Click += new System.EventHandler(this.nuevaConsultaToolStripMenuItem_Click);
            // 
            // verConsultasToolStripMenuItem
            // 
            this.verConsultasToolStripMenuItem.Name = "verConsultasToolStripMenuItem";
            this.verConsultasToolStripMenuItem.Size = new System.Drawing.Size(243, 28);
            this.verConsultasToolStripMenuItem.Text = "Ver Consultas";
            this.verConsultasToolStripMenuItem.Click += new System.EventHandler(this.verConsultasToolStripMenuItem_Click);
            // 
            // editarConsultaToolStripMenuItem
            // 
            this.editarConsultaToolStripMenuItem.Name = "editarConsultaToolStripMenuItem";
            this.editarConsultaToolStripMenuItem.Size = new System.Drawing.Size(243, 28);
            this.editarConsultaToolStripMenuItem.Text = "Editar Consulta";
            // 
            // eliminarConsultaToolStripMenuItem
            // 
            this.eliminarConsultaToolStripMenuItem.Name = "eliminarConsultaToolStripMenuItem";
            this.eliminarConsultaToolStripMenuItem.Size = new System.Drawing.Size(243, 28);
            this.eliminarConsultaToolStripMenuItem.Text = "Eliminar Consulta";
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
            // btnOrdenContraseña
            // 
            this.btnOrdenContraseña.Location = new System.Drawing.Point(82, 228);
            this.btnOrdenContraseña.Name = "btnOrdenContraseña";
            this.btnOrdenContraseña.Size = new System.Drawing.Size(211, 53);
            this.btnOrdenContraseña.TabIndex = 2;
            this.btnOrdenContraseña.Text = "Cambiar Contraseña";
            this.btnOrdenContraseña.UseVisualStyleBackColor = true;
            this.btnOrdenContraseña.Click += new System.EventHandler(this.btnOrdenContraseña_Click);
            // 
            // pnlCambioContraseña
            // 
            this.pnlCambioContraseña.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCambioContraseña.Controls.Add(this.btnCancelar);
            this.pnlCambioContraseña.Controls.Add(this.btnCambiarContraseña);
            this.pnlCambioContraseña.Controls.Add(this.txtConfirmarContraseña);
            this.pnlCambioContraseña.Controls.Add(this.txtNuevaContraseña);
            this.pnlCambioContraseña.Controls.Add(this.txtContraseñaActual);
            this.pnlCambioContraseña.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlCambioContraseña.Location = new System.Drawing.Point(82, 287);
            this.pnlCambioContraseña.Name = "pnlCambioContraseña";
            this.pnlCambioContraseña.Size = new System.Drawing.Size(363, 212);
            this.pnlCambioContraseña.TabIndex = 3;
            this.pnlCambioContraseña.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(196, 163);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 42);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCambiarContraseña
            // 
            this.btnCambiarContraseña.Location = new System.Drawing.Point(33, 163);
            this.btnCambiarContraseña.Name = "btnCambiarContraseña";
            this.btnCambiarContraseña.Size = new System.Drawing.Size(123, 42);
            this.btnCambiarContraseña.TabIndex = 3;
            this.btnCambiarContraseña.Text = "Aceptar";
            this.btnCambiarContraseña.UseVisualStyleBackColor = true;
            this.btnCambiarContraseña.Click += new System.EventHandler(this.btnCambiarContraseña_Click);
            // 
            // txtConfirmarContraseña
            // 
            this.txtConfirmarContraseña.ForeColor = System.Drawing.Color.DimGray;
            this.txtConfirmarContraseña.Location = new System.Drawing.Point(17, 120);
            this.txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.PlaceHolder = "Repetir contraseña nueva";
            this.txtConfirmarContraseña.Requerido = false;
            this.txtConfirmarContraseña.Size = new System.Drawing.Size(280, 30);
            this.txtConfirmarContraseña.TabIndex = 2;
            this.txtConfirmarContraseña.Click += new System.EventHandler(this.txtConfirmarContraseña_Click);
            this.txtConfirmarContraseña.TextChanged += new System.EventHandler(this.txtConfirmarContraseña_TextChanged);
            // 
            // txtNuevaContraseña
            // 
            this.txtNuevaContraseña.ForeColor = System.Drawing.Color.DimGray;
            this.txtNuevaContraseña.Location = new System.Drawing.Point(17, 66);
            this.txtNuevaContraseña.Name = "txtNuevaContraseña";
            this.txtNuevaContraseña.PlaceHolder = "Nueva Contraseña";
            this.txtNuevaContraseña.Requerido = true;
            this.txtNuevaContraseña.Size = new System.Drawing.Size(280, 30);
            this.txtNuevaContraseña.TabIndex = 1;
            this.txtNuevaContraseña.Click += new System.EventHandler(this.txtNuevaContraseña_Click);
            this.txtNuevaContraseña.TextChanged += new System.EventHandler(this.txtNuevaContraseña_TextChanged);
            // 
            // txtContraseñaActual
            // 
            this.txtContraseñaActual.ForeColor = System.Drawing.Color.DimGray;
            this.txtContraseñaActual.Location = new System.Drawing.Point(17, 13);
            this.txtContraseñaActual.Name = "txtContraseñaActual";
            this.txtContraseñaActual.PlaceHolder = "Contraseña Actual";
            this.txtContraseñaActual.Requerido = true;
            this.txtContraseñaActual.Size = new System.Drawing.Size(280, 30);
            this.txtContraseñaActual.TabIndex = 0;
            this.txtContraseñaActual.Click += new System.EventHandler(this.txtContraseñaActual_Click);
            this.txtContraseñaActual.TextChanged += new System.EventHandler(this.txtContraseñaActual_TextChanged);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // pnlTablaCambios
            // 
            this.pnlTablaCambios.Controls.Add(this.btnOcultarDataGrid);
            this.pnlTablaCambios.Controls.Add(this.dgvRegistrosContraseñas);
            this.pnlTablaCambios.Location = new System.Drawing.Point(431, 202);
            this.pnlTablaCambios.Name = "pnlTablaCambios";
            this.pnlTablaCambios.Size = new System.Drawing.Size(590, 237);
            this.pnlTablaCambios.TabIndex = 4;
            this.pnlTablaCambios.Visible = false;
            // 
            // btnOcultarDataGrid
            // 
            this.btnOcultarDataGrid.Location = new System.Drawing.Point(478, 56);
            this.btnOcultarDataGrid.Name = "btnOcultarDataGrid";
            this.btnOcultarDataGrid.Size = new System.Drawing.Size(95, 57);
            this.btnOcultarDataGrid.TabIndex = 1;
            this.btnOcultarDataGrid.Text = "Cerrar registro";
            this.btnOcultarDataGrid.UseVisualStyleBackColor = true;
            this.btnOcultarDataGrid.Click += new System.EventHandler(this.btnOcultarDataGrid_Click);
            // 
            // dgvRegistrosContraseñas
            // 
            this.dgvRegistrosContraseñas.AllowUserToAddRows = false;
            this.dgvRegistrosContraseñas.AllowUserToDeleteRows = false;
            this.dgvRegistrosContraseñas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrosContraseñas.Location = new System.Drawing.Point(0, 0);
            this.dgvRegistrosContraseñas.Name = "dgvRegistrosContraseñas";
            this.dgvRegistrosContraseñas.ReadOnly = true;
            this.dgvRegistrosContraseñas.RowTemplate.Height = 24;
            this.dgvRegistrosContraseñas.Size = new System.Drawing.Size(472, 234);
            this.dgvRegistrosContraseñas.TabIndex = 0;
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 524);
            this.Controls.Add(this.pnlTablaCambios);
            this.Controls.Add(this.pnlCambioContraseña);
            this.Controls.Add(this.btnOrdenContraseña);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenuPrincipal";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlCambioContraseña.ResumeLayout(false);
            this.pnlCambioContraseña.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.pnlTablaCambios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosContraseñas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.Button btnOrdenContraseña;
        private System.Windows.Forms.Panel pnlCambioContraseña;
        private System.Windows.Forms.Button btnCambiarContraseña;
        private ControlesValidaciones.PerTextBox txtConfirmarContraseña;
        private ControlesValidaciones.PerTextBox txtNuevaContraseña;
        private ControlesValidaciones.PerTextBox txtContraseñaActual;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Panel pnlTablaCambios;
        private System.Windows.Forms.DataGridView dgvRegistrosContraseñas;
        private System.Windows.Forms.Button btnOcultarDataGrid;
        private System.Windows.Forms.ToolStripMenuItem nuevaConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verConsultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarConsultaToolStripMenuItem;
        private System.Windows.Forms.Button btnCancelar;
    }
}