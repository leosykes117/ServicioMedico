using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace ControlesValidaciones
{
    public class Limpiar
    {
        public static void Borrar(Control ctrl,ErrorProvider ep)
        {
            ep.Clear();
            foreach (Control item in ctrl.Controls)
            {
                if (item is PerTextBox)
                {
                    PerTextBox mitxt = (PerTextBox)item;
                    mitxt.Text = mitxt.PlaceHolder;
                    mitxt.ForeColor = Color.DimGray;
                }
                else if(item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;
                }
                else if(item is RadioButton)
                {
                    ((RadioButton)item).Checked = false;
                }
                else if(item is CheckBox)
                {
                    ((CheckBox)item).Checked = false;
                }
            }
        }

        public static void BorrarTxT(Control ctrl)
        {
            foreach (Control item in ctrl.Controls)
            {
                if (item is PerTextBox)
                {
                    ((PerTextBox)item).Clear();
                }
            }
        }

        public static void BorrarDataGrid(DataGridView dgv)
        {
            DataTable tb = (DataTable)dgv.DataSource;
            tb.Clear();
        }
    }
}
