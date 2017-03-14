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
            this.lblMensaje = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.doctoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.doctoresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 31);
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
            // 
            // eliminarDoctorToolStripMenuItem
            // 
            this.eliminarDoctorToolStripMenuItem.Name = "eliminarDoctorToolStripMenuItem";
            this.eliminarDoctorToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.eliminarDoctorToolStripMenuItem.Text = "Eliminar Doctor";
            // 
            // frmMenuAdmi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 576);
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
    }
}