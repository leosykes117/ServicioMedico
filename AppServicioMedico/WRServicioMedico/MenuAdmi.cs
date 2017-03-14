using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WRServicioMedico
{
    public partial class frmMenuAdmi : Form
    {
        private string mensaje;

        public frmMenuAdmi(string msm)
        {
            InitializeComponent();
            mensaje = msm;
        }

        private void frmMenuAdmi_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = mensaje;
        }

        //-----------------------------------------------------------------------------EVENTOS DEL MENUSTRIP------------------------------------------------------------
        private void nuevoDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarDoctor nuevoDoc = new frmAgregarDoctor();
            nuevoDoc.Show();
        }
    }
}
