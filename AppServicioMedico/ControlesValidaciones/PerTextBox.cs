using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesValidaciones
{
    public partial class PerTextBox : TextBox
    {
        //ATRIBUTOS
        private bool requerido;
        private string placeHolder;

        //PROPIEDADES
        public string PlaceHolder
        {
            get { return placeHolder; }
            set { placeHolder = value; }
        }

        public bool Requerido
        {
            get { return requerido; }
            set { requerido = value; }
        }

        //CONSTRUTOR
        public PerTextBox()
        {
            InitializeComponent();
        }
    }
}
