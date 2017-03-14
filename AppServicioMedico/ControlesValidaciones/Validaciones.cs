using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesValidaciones
{
    public class Validaciones
    {
        public static bool ValidarCampos(Control ctrl, ErrorProvider ep)
        {
            bool mensajes = false;
            foreach(Control item in ctrl.Controls)
            {
                if(item is PerTextBox)
                {
                    PerTextBox mitxt = (PerTextBox)item;
                    if(mitxt.Requerido == true)
                    {
                        if(mitxt.Text == mitxt.PlaceHolder)
                        {
                            ep.SetError(mitxt, "Complete este campo");
                            mensajes = true;
                        }
                    }
                    else
                    {
                        ep.Clear();
                    } 
                }

                else if(item is ComboBox)
                {
                    ComboBox cmb = (ComboBox)item;
                    if(cmb.SelectedIndex == 0)
                    {
                        ep.SetError(cmb, "Seleccione una opcion");
                        mensajes = true;
                    }
                    else
                    {
                        ep.Clear();
                    }
                }
            }
            return mensajes;
        }

        public static bool Cancelar(Control ctrl)
        {
            bool mensajes = false;
            foreach (Control item in ctrl.Controls)
            {
                if (item is PerTextBox)
                {
                    PerTextBox mitxt = (PerTextBox)item;
                    if (mitxt.Text != mitxt.PlaceHolder)
                    {
                        mensajes = true;
                    }
                    else
                    {
                        mensajes = false;
                    }
                }

                if (item is ComboBox)
                {
                    ComboBox cmb = (ComboBox)item;
                    if (cmb.SelectedIndex != 0)
                    {
                        mensajes = true;
                    }
                    else
                    {
                        mensajes = false;
                    }
                }

                if(item is RadioButton)
                {
                    RadioButton rdb = (RadioButton)item;
                    if (rdb.Checked == true)
                    {
                        mensajes = true;
                    }
                    else
                    {
                        mensajes = false;
                    }
                }
            }
            return mensajes;
        }
    }
}
