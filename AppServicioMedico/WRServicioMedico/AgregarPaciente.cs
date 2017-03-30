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
    public partial class frmAgregarPaciente : Form
    {
        private int claveAgregar;

        public frmAgregarPaciente(int clave)
        {
            InitializeComponent();
            claveAgregar = clave;
        }

        private void AgregarPaciente_Load(object sender, EventArgs e)
        {
            Limpiar.Borrar(this, ep);
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipo.SelectedIndex == 1)
                {
                    Pacientes alumno = new Pacientes(txtBoleta.Text, txtNombre.Text,
                            cmbGenero.SelectedItem.ToString(), cmbCarrera.SelectedItem.ToString(), txtGrupo.Text);
                    int respuesta = alumno.AgregarPaciente();
                    if (respuesta == 1)
                    {
                        frmConsulta consulta = new frmConsulta(alumno.IdPaciente, alumno.NombrePaciente,
                        alumno.Boleta, claveAgregar, cmbTipo.SelectedIndex);
                        this.Dispose();
                        consulta.ShowDialog();
                    }
                    else if (respuesta == 0)
                    {
                        MessageBox.Show("El alumno ya existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error en la base de datos. Intentelo mas tarde", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    Pacientes paciente = new Pacientes(txtNombre.Text, cmbGenero.SelectedItem.ToString());
                    int respuesta = paciente.AgregarPaciente(cmbTipo.SelectedIndex);
                    if (respuesta == 1)
                    {
                        frmConsulta consulta = new frmConsulta(paciente.IdPaciente, paciente.NombrePaciente,
                            null, claveAgregar, cmbTipo.SelectedIndex);
                        this.Dispose();
                        consulta.ShowDialog();
                    }
                    else if (respuesta == 0)
                    {
                        MessageBox.Show("No se pudo agregar a el paciente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error en la base de datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifa los datos", "Datos Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
