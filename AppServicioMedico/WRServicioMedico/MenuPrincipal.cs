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
            txtNuevaContraseña.Text = txtNuevaContraseña.PlaceHolder; txtContraseñaActual.Text = txtContraseñaActual.PlaceHolder; txtConfirmarContraseña.Text = txtConfirmarContraseña.PlaceHolder;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogIn login = new frmLogIn();
            this.Dispose(); this.Close(); this.Hide();
            login.ShowDialog();
        }

        private void nuevaConsultaToolStripMenuItem_Click(object sender, EventArgs e)//ABRE FORM PARA BUSCAR A EL PACIENTE
        {
            frmBuscarPaciente buscarPaciente = new frmBuscarPaciente(claveFrm1);
            buscarPaciente.ShowDialog();
        }

        private void verConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerConsultas consultas = new frmVerConsultas(claveFrm1); consultas.ShowDialog();
        }

        //-----------------------------------------------------CLICK DE LOS BOTONES------------------------------------------------------------
        private void btnOrdenContraseña_Click(object sender, EventArgs e)
        {
            pnlCambioContraseña.Visible = true;
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if (Validaciones.ValidarCampos(this.pnlCambioContraseña, ep) == true)
            {
                MessageBox.Show("Complete todos los campos", "Carencia de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtNuevaContraseña.Text == txtConfirmarContraseña.Text)
                {
                    Usuarios usuario = new Usuarios(claveFrm1, txtContraseñaActual.Text);
                    int resultado = usuario.CambiarContraseña(txtNuevaContraseña.Text);
                    if (resultado == 1)
                    {
                        MessageBox.Show("Su contraseña fue modificada con exito.\nReinicie su sesion para comprobar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar.Borrar(this.pnlCambioContraseña, ep);
                        pnlCambioContraseña.Visible = false;
                        DialogResult dr = MessageBox.Show("Su contraseña acaba de ser modificada.\n¿Desea ver un registro de las modificaiones?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            pnlTablaCambios.Visible = true;
                            DataTable tbContraseñas = (DataTable)Usuarios.TraerRegistrosContraseñas(claveFrm1);
                            dgvRegistrosContraseñas.DataSource = tbContraseñas;
                        }
                        else
                        {

                        }
                    }
                    else if (resultado == 2)
                    {
                        MessageBox.Show("Su contraseña ha sido cambiada con exito pero su correo no pudo ser enviado\nReinicie su sesion para comprobar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar.Borrar(this.pnlCambioContraseña, ep);
                        pnlCambioContraseña.Visible = false;
                        DialogResult dr = MessageBox.Show("Su contraseña acaba de ser modificada.\n¿Desea ver un registro de las modificaiones?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            pnlTablaCambios.Visible = true;
                            DataTable tbContraseñas = (DataTable)Usuarios.TraerRegistrosContraseñas(claveFrm1);
                            dgvRegistrosContraseñas.DataSource = tbContraseñas;
                        }
                        else
                        {

                        }
                    }
                    else if(resultado == 3)
                    {
                        MessageBox.Show("No puede poner esta contraseña", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Limpiar.Borrar(this.pnlCambioContraseña, ep);
                    }
                    else if (resultado == 0)
                    {
                        MessageBox.Show("Verifique su contraseña actual", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Limpiar.Borrar(this.pnlCambioContraseña, ep);
                    }
                    else
                    {
                        MessageBox.Show("Error en la base de datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Limpiar.Borrar(this.pnlCambioContraseña, ep);
                        pnlCambioContraseña.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Las Contraseñas no coinciden", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void btnOcultarDataGrid_Click(object sender, EventArgs e)
        {
            Limpiar.BorrarDataGrid(dgvRegistrosContraseñas);
            pnlTablaCambios.Visible = false;
        }
        //------------------------------------------------------EVENTOS TEXT CHANGED---------------------------------------------------------
        private void txtContraseñaActual_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PassWordPH_TextChanged(e, txtContraseñaActual, txtContraseñaActual.PlaceHolder);
        }

        private void txtNuevaContraseña_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PassWordPH_TextChanged(e, txtNuevaContraseña, txtNuevaContraseña.PlaceHolder);
        }

        private void txtConfirmarContraseña_TextChanged(object sender, EventArgs e)
        {
            PlaceHolders.PassWordPH_TextChanged(e, txtConfirmarContraseña, txtConfirmarContraseña.PlaceHolder);
        }

        //-------------------------------------------------------EVENTOS CLICK DE LOS TEXTBOX-------------------------------------------------
        private void txtContraseñaActual_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtContraseñaActual);
        }

        private void txtNuevaContraseña_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtNuevaContraseña);
        }

        private void txtConfirmarContraseña_Click(object sender, EventArgs e)
        {
            PlaceHolders.Seleccionar(e, txtConfirmarContraseña);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(Validaciones.Cancelar(this.pnlCambioContraseña) == true)
            {
                DialogResult dr = MessageBox.Show("¿Desea Cancelar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    Limpiar.Borrar(this.pnlCambioContraseña, ep);
                    pnlCambioContraseña.Visible = false;
                }
                else
                {

                }
            }
            else
            {
                Limpiar.Borrar(this.pnlCambioContraseña, ep);
                pnlCambioContraseña.Visible = false;
            }
        }
    }
}
