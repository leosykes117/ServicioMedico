using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesValidaciones
{
    public class PlaceHolders
    {
        public static void PlaceHolder_TextChanged(EventArgs e, PerTextBox ctrl,string ph)
        {
            PerTextBox txt = (PerTextBox)ctrl;

            if (txt.Text == "")
            {
                txt.Text = ph; txt.ForeColor = Color.DimGray;
            }
            if (txt.Text != ph)
            {
                txt.ForeColor = SystemColors.WindowText;
            }
            if (txt.Text == ph)
            {
                txt.SelectAll();
            }
        }

        public static void PassWordPH_TextChanged(EventArgs e, PerTextBox ctrl, string ph)
        {
            PerTextBox txt = (PerTextBox)ctrl;

            if (txt.Text == "")
            {
                txt.Text = ph; txt.ForeColor = Color.DimGray;
                txt.UseSystemPasswordChar = false;
            }
            if (txt.Text != ph)
            {
                txt.ForeColor = SystemColors.WindowText;
                txt.UseSystemPasswordChar = true;
            }
            if (txt.Text == ph)
            {
                txt.SelectAll();
                txt.UseSystemPasswordChar = false;
            }
        }
        
        public static void Seleccionar(EventArgs e, PerTextBox ctrl)
        {
            PerTextBox txt = (PerTextBox)ctrl;
            txt.SelectAll();
        }
    }
}
