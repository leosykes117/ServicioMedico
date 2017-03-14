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
    public partial class frmAgregarDoctor : Form
    {
        public frmAgregarDoctor()
        {
            InitializeComponent();
        }

        private void frmAgregarDoctor_Load(object sender, EventArgs e)
        {
            txtNombre.Text = txtNombre.PlaceHolder; txtUsuario.Text = txtUsuario.PlaceHolder; cmbConsultorio.SelectedIndex = 0;
            txtCorreo.Text = txtCorreo.PlaceHolder; txtContraseña.Text = txtContraseña.PlaceHolder; txtConfirmarContraseña.Text = txtConfirmarContraseña.PlaceHolder;
        }

        //------------------------------------------------------------CLICKS DE LOS BOTONES---------------------------------------------------
        private void btnAgregarDoctor_Click(object sender, EventArgs e)
        {
            if (Validaciones.ValidarCampos(this, ep) == true)
            {
                MessageBox.Show("Complete todos los campos", "Carencia de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (rdbMasculino.Checked == true)
                    {
                        Doctores nuevoDoc = new Doctores(txtNombre.Text, rdbMasculino.Text, cmbConsultorio.SelectedItem.ToString());
                        int respuesta = nuevoDoc.AgregarDoctor(txtUsuario.Text, txtContraseña.Text, txtCorreo.Text, 2);
                        if (respuesta == 1)
                        {
                            MessageBox.Show("El doctor se creo correctamente", "Nuevo Doctor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if(respuesta == 0)
                        {
                            MessageBox.Show("El doctor no pude ser guardado", "Nuevo Doctor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Lo sentimos, ha habido un error con la Base de Datos, intentelo mas tarde", "Error de la Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (rdbFemenino.Checked == true)
                    {
                        Doctores nuevoDoc = new Doctores(txtNombre.Text, rdbFemenino.Text, cmbConsultorio.SelectedItem.ToString());
                        int respuesta = nuevoDoc.AgregarDoctor(txtUsuario.Text, txtContraseña.Text, txtCorreo.Text, 2);
                        if (respuesta == 1)
                        {
                            MessageBox.Show("El doctor se creo correctamente", "Nuevo Doctor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else if (respuesta == 3)
                        {
                            MessageBox.Show("El doctor no pude ser guardado pero no se le envio un correo", "Nuevo Doctor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else if (respuesta == 0)
                        {
                            MessageBox.Show("El doctor no pude ser guardado", "Nuevo Doctor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Lo sentimos, ha habido un error con la Base de Datos, intentelo mas tarde", "Error de la Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Especifique el genero para el doctor", "Carencia de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Ha ocurrido un error, intentelo nuevamente", "Datos Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }

        //----------------------------------------------------------------TEXT CHANGED------------------------------------------------------------
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PlaceHolder_TextChanged(e, txtNombre, txtNombre.PlaceHolder);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PlaceHolder_TextChanged(e, txtUsuario, txtUsuario.PlaceHolder);
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PlaceHolder_TextChanged(e, txtCorreo, txtCorreo.PlaceHolder);
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PassWordPH_TextChanged(e, txtContraseña, txtContraseña.PlaceHolder);
        }

        private void txtConfirmarContraseña_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PassWordPH_TextChanged(e, txtConfirmarContraseña, txtConfirmarContraseña.PlaceHolder);
        }

        //--------------------------------------------------------EVENTOS CLICK DE LOS TEXTBOX------------------------------------------------
        private void txtNombre_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtNombre);
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtUsuario);
        }

        private void txtCorreo_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtCorreo);
        }

        private void txtContraseña_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtContraseña);
        }

        private void txtConfirmarContraseña_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtConfirmarContraseña);
        }
    }
}
