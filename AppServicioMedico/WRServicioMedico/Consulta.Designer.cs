namespace WRServicioMedico
{
    partial class frmConsulta
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
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.nudHeridas = new System.Windows.Forms.NumericUpDown();
            this.nudInyecciones = new System.Windows.Forms.NumericUpDown();
            this.txtTratamiento = new ControlesValidaciones.PerTextBox();
            this.btnAgregarConsulta = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudHeridas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInyecciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(62, 71);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 23);
            this.lblMensaje.TabIndex = 0;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(66, 121);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(149, 30);
            this.dtpFecha.TabIndex = 1;
            // 
            // nudHeridas
            // 
            this.nudHeridas.Location = new System.Drawing.Point(66, 181);
            this.nudHeridas.Name = "nudHeridas";
            this.nudHeridas.Size = new System.Drawing.Size(120, 30);
            this.nudHeridas.TabIndex = 2;
            // 
            // nudInyecciones
            // 
            this.nudInyecciones.Location = new System.Drawing.Point(66, 245);
            this.nudInyecciones.Name = "nudInyecciones";
            this.nudInyecciones.Size = new System.Drawing.Size(120, 30);
            this.nudInyecciones.TabIndex = 3;
            // 
            // txtTratamiento
            // 
            this.txtTratamiento.Location = new System.Drawing.Point(66, 311);
            this.txtTratamiento.Multiline = true;
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.PlaceHolder = "Tratamiento";
            this.txtTratamiento.Requerido = true;
            this.txtTratamiento.Size = new System.Drawing.Size(289, 159);
            this.txtTratamiento.TabIndex = 4;
            // 
            // btnAgregarConsulta
            // 
            this.btnAgregarConsulta.Location = new System.Drawing.Point(66, 525);
            this.btnAgregarConsulta.Name = "btnAgregarConsulta";
            this.btnAgregarConsulta.Size = new System.Drawing.Size(132, 57);
            this.btnAgregarConsulta.TabIndex = 5;
            this.btnAgregarConsulta.Text = "Generar Conultas";
            this.btnAgregarConsulta.UseVisualStyleBackColor = true;
            this.btnAgregarConsulta.Click += new System.EventHandler(this.btnAgregarConsulta_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 666);
            this.Controls.Add(this.btnAgregarConsulta);
            this.Controls.Add(this.txtTratamiento);
            this.Controls.Add(this.nudInyecciones);
            this.Controls.Add(this.nudHeridas);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblMensaje);
            this.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.frmConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHeridas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInyecciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.NumericUpDown nudHeridas;
        private System.Windows.Forms.NumericUpDown nudInyecciones;
        private ControlesValidaciones.PerTextBox txtTratamiento;
        private System.Windows.Forms.Button btnAgregarConsulta;
        private System.Windows.Forms.ErrorProvider ep;
    }
}