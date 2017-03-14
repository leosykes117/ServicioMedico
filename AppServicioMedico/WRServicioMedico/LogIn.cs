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
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = txtUsuario.PlaceHolder; txtContraseña.Text = txtContraseña.PlaceHolder;
        }

        //------------------------------------------------------EVENTOS CLICK BOTONES-------------------------------------------------------
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            bool validacion = Validaciones.ValidarCampos(this, ep);
            if(validacion == true)
            {
                MessageBox.Show("Ingrese Usuario y Contraseña", "Carencia de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Usuarios doctor = new Usuarios(txtUsuario.Text, txtContraseña.Text);
                    string resultado = doctor.IniciarSesion();
                    if (resultado != "0" && resultado != "2")
                    {
                        if (doctor.Rol == 1)
                        {
                            frmMenuAdmi admi = new frmMenuAdmi(resultado);
                            this.Hide(); admi.ShowDialog(); this.Dispose();
                        }
                        else
                        {
                            frmMenuPrincipal menu = new frmMenuPrincipal(doctor.IdUsuario, resultado);
                            this.Hide(); menu.ShowDialog(); this.Dispose();
                        }
                    }
                    else if (resultado == "0")
                    {
                        MessageBox.Show("El usaurio no existe", "Datos Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lo sentimos, ha habido un error con la Base de Datos, intentelo mas tarde", "Error de la Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ocurrio un error, intentelo nuevamente", "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        //------------------------------------------------------------TEXT CHANGED-----------------------------------------------------------
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PlaceHolder_TextChanged(e, txtUsuario, txtUsuario.PlaceHolder);
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PassWordPH_TextChanged(e, txtContraseña, txtContraseña.PlaceHolder);
        }

        //-----------------------------------------------------------EVENTOS KEYPRESS---------------------------------------------------------
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(Keys.Enter)))
            {
                btnIniciarSesion.PerformClick();
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(Keys.Enter)))
            {
                btnIniciarSesion.PerformClick();
            }
        }

        //---------------------------------------------------EVENTOS CLICK DE LOS TEXTBOX-----------------------------------------------------
        private void txtUsuario_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtUsuario);
        }

        private void txtContraseña_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtContraseña);
        }
    }
}
