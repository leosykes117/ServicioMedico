using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using ServicioMedico;
using ControlesValidaciones;

namespace WRServicioMedico.ClaseApp
{
    class ClaseFrmBusqueda
    {
        private static DataTable tabla = null;

        public static void ValidarControles(EventArgs e, Control frm, ComboBox cmb, DataGridView dgv)
        {
            if(cmb.SelectedIndex == 0)
            {
                frm.Height = 247; dgv.Visible = false;
            }
            else
            {
                tabla = (DataTable)Pacientes.TraerPacientes(cmb.SelectedIndex);
                dgv.DataSource = tabla;
                dgv.Columns[0].Visible = false;
                frm.Height = 567; dgv.Visible = true;
            }
        }

        public static void ValidarControles(EventArgs e, Control frm, ComboBox cmb1, ComboBox cmb2,DataGridView dgv)
        {
            if (cmb1.SelectedIndex > 1 && cmb2.SelectedIndex == 2)
            {
                
            }
            else
            {

            }
        }

        public static void ValidarControles(EventArgs e, Control frm, ComboBox cmb, PerTextBox txt, DataGridView dgv)
        {
            if(txt.Text == txt.PlaceHolder)
            {
                tabla = (DataTable)Pacientes.TraerPacientes(cmb.SelectedIndex);
                dgv.DataSource = tabla;
                dgv.Columns[0].Visible = false;
            }
            else
            {
                tabla = (DataTable)Pacientes.TraerPacientes(cmb.SelectedIndex, txt.Text);
                dgv.DataSource = tabla;
                dgv.Columns[0].Visible = false;
            }
        }
    }
}
