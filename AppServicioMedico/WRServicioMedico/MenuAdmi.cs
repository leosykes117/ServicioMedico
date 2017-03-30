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
    public partial class frmMenuAdmi : Form
    {
        int idDoc, accion;
        private string mensaje, antiguoUsuario;
        private DataTable tbDoctores;
        

        public frmMenuAdmi(string msm)
        {
            InitializeComponent();
            mensaje = msm;
        }

        private void frmMenuAdmi_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = mensaje;
        }

        //-----------------------------------------------------------------------------EVENTOS DEL MENUSTRIP------------------------------------------------------------
        private void nuevoDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tbDoctores == null)
            {
                frmAgregarDoctor nuevoDoc = new frmAgregarDoctor();
                nuevoDoc.ShowDialog(); 
            }
            else
            {
                tbDoctores.Clear(); trvDoctores.Nodes.Clear(); Limpiar.BorrarTxT(this.pnlDatos);
                pnlDatos.Visible = false; pnlArbol.Visible = false;
                frmAgregarDoctor nuevoDoc = new frmAgregarDoctor();
                nuevoDoc.ShowDialog();
            }
        }

        private void editarDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlArbol.Visible = true;
            trvDoctores.Nodes.Clear();
            tbDoctores = (DataTable)Doctores.LlenarArbol();
            TreeNode padre = null;
            TreeNode hijo = null;
            if(tbDoctores != null)
            {
                try
                {
                    padre = new TreeNode("Doctores");
                    padre.Name = "ndPadre";
                    padre.Text = "Doctores";
                    foreach (DataRow dr in tbDoctores.Rows)//se leen  todas las filas de datatable
                    {
                        hijo = new TreeNode(dr.ItemArray[1].ToString());//Se le pone el nombre del doc al nodo;
                        padre.Nodes.Add(hijo);
                    }
                    this.trvDoctores.Nodes.AddRange(new TreeNode[] { padre });
                }
                catch (Exception)
                { 
                }
            }
            else
            {
                MessageBox.Show("No se encontraron Doctores", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            accion = 1;
        }

        private void eliminarDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlArbol.Visible = true;
            trvDoctores.Nodes.Clear();
            tbDoctores = (DataTable)Doctores.LlenarArbol();
            TreeNode padre = null;
            TreeNode hijo = null;
            if (tbDoctores != null)
            {
                try
                {
                    padre = new TreeNode("Doctores");
                    padre.Name = "ndPadre";
                    padre.Text = "Doctores";
                    foreach (DataRow dr in tbDoctores.Rows)//se leen  todas las filas de datatable
                    {
                        hijo = new TreeNode(dr.ItemArray[1].ToString());//Se le pone el nombre del doc al nodo;
                        padre.Nodes.Add(hijo);
                    }
                    this.trvDoctores.Nodes.AddRange(new TreeNode[] { padre });
                }
                catch (Exception)
                {
                }
            }
            else
            {
                MessageBox.Show("No se encontraron Doctores", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            accion = 2;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogIn login = new frmLogIn();
            this.Close(); this.Dispose(); this.Hide();
            login.ShowDialog();
        }

        //-----------------------------------------------------------------------------EVENTOS CLICK-------------------------------------------------------------------
        private void btnModificarDoctor_Click(object sender, EventArgs e)
        {
            if(Validaciones.ValidarCampos(this.pnlDatos,ep) == true)
            {
                MessageBox.Show("Completa todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Doctores doctor = new Doctores(idDoc, txtNombre.Text, cmbGenero.SelectedItem.ToString(), cmbConsultorio.SelectedItem.ToString());
                    int resultado = doctor.ModificarDoc(txtCorreo.Text, txtUsuario.Text, antiguoUsuario);
                    if(resultado == 1)
                    {
                        MessageBox.Show("La modificacion se realizo con exito","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        tbDoctores.Clear(); trvDoctores.Nodes.Clear(); Limpiar.BorrarTxT(this.pnlDatos);
                        pnlDatos.Visible = false; pnlArbol.Visible = false;
                    }
                    else if(resultado == 0)
                    {
                        MessageBox.Show("Verifica que los datos sean correctos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Limpiar.BorrarTxT(this.pnlDatos); pnlDatos.Visible = false;
                    }

                    else
                    {
                        MessageBox.Show("Hubo un erro en la base de datos, intentalo mas tarde", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbDoctores.Clear(); trvDoctores.Nodes.Clear(); Limpiar.BorrarTxT(this.pnlDatos);
                        pnlDatos.Visible = false; pnlArbol.Visible = false;
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Excepcion", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar.BorrarTxT(this.pnlDatos); pnlDatos.Visible = false;
        }
        
        private void lklMasOp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tbDoctores == null)
            {
                frmMasOpciones masOpciones = new frmMasOpciones();
                masOpciones.Show();
            }
            else
            {
                tbDoctores.Clear(); trvDoctores.Nodes.Clear(); Limpiar.BorrarTxT(this.pnlDatos);
                pnlDatos.Visible = false; pnlArbol.Visible = false;
                frmMasOpciones masOpciones = new frmMasOpciones();
                masOpciones.Show();
            }
        }

        //----------------------------------------------------------------------------EVENTOS DEL TREE VIEW----------------------------------------------------------------
        private void trvDoctores_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
                {
                    int posicion = e.Node.Index;
                    idDoc = Convert.ToInt32(tbDoctores.Rows[posicion]["ID"].ToString());
                    if (accion == 1)
                    {
                        txtNombre.Text = tbDoctores.Rows[posicion]["Nombre"].ToString();
                        cmbGenero.SelectedItem = tbDoctores.Rows[posicion]["Genero"].ToString();
                        cmbConsultorio.SelectedItem = tbDoctores.Rows[posicion]["Consultorio"].ToString();
                        txtUsuario.Text = tbDoctores.Rows[posicion]["Usuario"].ToString();
                        antiguoUsuario = tbDoctores.Rows[posicion]["Usuario"].ToString();//ATRIBUTO ANTIGUO USUARIO
                        txtCorreo.Text = tbDoctores.Rows[posicion]["Correo"].ToString();
                        pnlDatos.Visible = true;
                    }
                    else
                    {
                        Doctores doctor = new Doctores();

                        DialogResult dr = MessageBox.Show("¿Estas seguro que quieres eliminar a " + e.Node.Text + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(dr == DialogResult.Yes)
                        {
                            int resultado = doctor.EliminarDoc(idDoc);
                            if (resultado == 1)
                            {
                                MessageBox.Show("El doctor se ha elimindado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbDoctores.Clear(); trvDoctores.Nodes.Clear(); Limpiar.BorrarTxT(this.pnlDatos);
                                pnlDatos.Visible = false; pnlArbol.Visible = false;
                            }
                            else if (resultado == 0)
                            {
                                MessageBox.Show("No se ha sido eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Limpiar.BorrarTxT(this.pnlDatos); pnlDatos.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Hubo un erro en la base de datos, intentalo mas tarde", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbDoctores.Clear(); trvDoctores.Nodes.Clear(); Limpiar.BorrarTxT(this.pnlDatos);
                                pnlDatos.Visible = false; pnlArbol.Visible = false;
                            }
                        }
                        else{}
                    }
                }
                else
                {
                    MessageBox.Show("Has click en un elemento de la lista");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //pnlDatos.Visible = true;
        }
    }
}
