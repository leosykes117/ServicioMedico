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
using ControlesValidaciones;

namespace WRServicioMedico
{
    public partial class frmVerConsultas : Form
    {
        DataTable tbConsultas = null;
        int claveDocConsultas;

        public frmVerConsultas(int clave)
        {
            InitializeComponent();
            claveDocConsultas = clave;
        }

        private void frmVerConsultas_Load_1(object sender, EventArgs e)
        {
            Limpiar.Borrar(this, ep);
            this.Height = 196;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(dataGridView1.Visible == true)
            {
                this.Height = 196;
                dataGridView1.Visible = false;
            }
            else
            {
                this.Height = 581;
                dataGridView1.Visible = true;
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Height = 581;
            tbConsultas = (DataTable)Consultas.ConsultasPorMes(cmbTipo.SelectedIndex, claveDocConsultas, cmbMes.SelectedIndex);
            dataGridView1.DataSource = tbConsultas; dataGridView1.Visible = true;
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            tbConsultas = (DataTable)Consultas.ConsultasPorMes(cmbTipo.SelectedIndex, claveDocConsultas, cmbMes.SelectedIndex, txtDato.Text);
            dataGridView1.DataSource = tbConsultas; dataGridView1.Visible = true;
        }
    }
}
