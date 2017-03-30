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
    public partial class frmBuscarPaciente : Form
    {
        private int claveFrm2;

        public frmBuscarPaciente(int clave)
        {
            InitializeComponent();
            claveFrm2 = clave;
        }

        private void frmBuscarPaciente_Load(object sender, EventArgs e)
        {
            Limpiar.Borrar(this, ep);
        }

        private void lklAgregarPaciente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
            frmAgregarPaciente agregarPaciente = new frmAgregarPaciente(claveFrm2);
            agregarPaciente.ShowDialog();
        }

        //--------------------------------------------------------EVENTOS DE LOS COMBO---------------------------------------------------------
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClaseApp.ClaseFrmBusqueda.ValidarControles(e, this, cmbTipo, dgvPacientes);
        }

        private void cmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //----------------------------------------------------------------EVENTOS TEXT CHANGED-----------------------------------------------------------------------------
        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PlaceHolder_TextChanged(e, txtDato, txtDato.PlaceHolder);
            ClaseApp.ClaseFrmBusqueda.ValidarControles(e, this, cmbTipo, txtDato, dgvPacientes);
        }

        private void txtDato_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtDato);
        }

        //--------------------------------------------------------------EVENTOS DEL DATAGRIDVIEW------------------------------------------------------------------
        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (cmbTipo.SelectedIndex == 1)
                {
                    frmConsulta consulta = new frmConsulta(Convert.ToInt64(dgvPacientes.CurrentRow.Cells[0].Value.ToString()), dgvPacientes.CurrentRow.Cells[2].Value.ToString(),
                        dgvPacientes.CurrentRow.Cells[1].Value.ToString(), claveFrm2, cmbTipo.SelectedIndex);
                    this.Dispose();
                    consulta.ShowDialog();
                }
                else
                {
                    frmConsulta consulta = new frmConsulta(Convert.ToInt64(dgvPacientes.CurrentRow.Cells[0].Value.ToString()), dgvPacientes.CurrentRow.Cells[1].Value.ToString(),
                        null, claveFrm2, cmbTipo.SelectedIndex);
                    this.Dispose();
                    consulta.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("No selecciono ningun paciente " + ex, "");
            }
        }
    }
}