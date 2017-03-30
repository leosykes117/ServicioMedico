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
    public partial class frmConsulta : Form
    {
        private Int64 clvPaciente;
        private int claveDocConsulta, tipo;
        private string nombre, boleta;

        public frmConsulta(Int64 paciente, string nom, string bol, int doc, int t)
        {
            InitializeComponent();
            clvPaciente = paciente;
            nombre = nom;
            boleta = bol;
            claveDocConsulta = doc;
            tipo = t;
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            Limpiar.Borrar(this, ep);
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            if(tipo == 1)
            {
                lblMensaje.Text = "Nombre: " + nombre + "\nBoleta: " + boleta;
            }
            else
            {
                lblMensaje.Text = "Nombre: " + nombre;
            }
        }

        private void btnAgregarConsulta_Click(object sender, EventArgs e)
        {
            if (Validaciones.ValidarCampos(this, ep))
            {
                MessageBox.Show("Escriba un tratamiento", "",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                Consultas nuevaConsulta = new Consultas(claveDocConsulta, clvPaciente, dtpFecha.Value.Date, Convert.ToInt32(nudHeridas.Value), Convert.ToInt32(nudInyecciones.Value), txtTratamiento.Text);
                int resultado = nuevaConsulta.AgregarConsulta(tipo);
                if(resultado == 1)
                {
                    MessageBox.Show("La consulta se realizo con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmBuscarPaciente buscarPaciente = new frmBuscarPaciente(claveDocConsulta);
                    this.Dispose(); buscarPaciente.ShowDialog();

                }
                else if(resultado == 0)
                {
                    MessageBox.Show("La consulta no se realizo con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmBuscarPaciente buscarPaciente = new frmBuscarPaciente(claveDocConsulta);
                    this.Dispose(); buscarPaciente.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Hubo un error en la base de datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmBuscarPaciente buscarPaciente = new frmBuscarPaciente(claveDocConsulta);
                    this.Dispose(); buscarPaciente.ShowDialog();
                }
            }
        }
    }
}
