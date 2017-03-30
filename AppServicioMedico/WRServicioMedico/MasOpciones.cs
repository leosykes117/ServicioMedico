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
    public partial class frmMasOpciones : Form
    {
        public frmMasOpciones()
        {
            InitializeComponent();
        }

        private void lklMonitorearUsuarios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMonitorearUsuarios monitorearUsuarios = new frmMonitorearUsuarios();
            monitorearUsuarios.ShowDialog();
        }
    }
}
