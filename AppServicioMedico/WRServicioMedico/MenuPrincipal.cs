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
    public partial class frmMenuPrincipal : Form
    {
        private int claveFrm1;
        private string mensaje;

        public frmMenuPrincipal(int clave, string msm)
        {
            InitializeComponent();
            claveFrm1 = clave;
            mensaje = msm;
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = mensaje;
        }


    }
}
