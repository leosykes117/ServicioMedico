using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServicioMedico;

namespace WRServicioMedico
{
    public partial class frmMonitorearUsuarios : Form
    {
        public frmMonitorearUsuarios()
        {
            InitializeComponent();
        }

        private void frmMonitorearUsuarios_Load(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)Usuarios.TraerNuevosUsuarios();
            if(tb == null)
            {
                MessageBox.Show("No se a encontrado ningun registro","",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.DataSource = tb;
            }
        }
    }
}
