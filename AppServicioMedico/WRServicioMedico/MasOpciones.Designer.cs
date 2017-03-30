namespace WRServicioMedico
{
    partial class frmMasOpciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.lklMonitorearUsuarios = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "La Aplicacion de Servicio Medico es tan completa que usted \r\npuede monitorear que" +
    " usuarios se han agregrado\r\n\r\n";
            // 
            // lklMonitorearUsuarios
            // 
            this.lklMonitorearUsuarios.AutoSize = true;
            this.lklMonitorearUsuarios.Location = new System.Drawing.Point(450, 24);
            this.lklMonitorearUsuarios.Name = "lklMonitorearUsuarios";
            this.lklMonitorearUsuarios.Size = new System.Drawing.Size(100, 23);
            this.lklMonitorearUsuarios.TabIndex = 1;
            this.lklMonitorearUsuarios.TabStop = true;
            this.lklMonitorearUsuarios.Text = "click aqui";
            this.lklMonitorearUsuarios.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklMonitorearUsuarios_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Explicacion de Como Monitorear Usuarios";
            // 
            // frmMasOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 532);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lklMonitorearUsuarios);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Chalet", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMasOpciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mas Opciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lklMonitorearUsuarios;
        private System.Windows.Forms.Label label2;
    }
}