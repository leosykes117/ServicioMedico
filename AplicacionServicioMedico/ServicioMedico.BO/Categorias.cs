using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Categorias
    {
        //ATRIBUTOS
        private int idCategoria;
        private string descripcionCategoria;

        public int IdCategoria
        {
            get
            {
                return idCategoria;
            }

            set
            {
                idCategoria = value;
            }
        }

        public string DescripcionCategoria
        {
            get
            {
                return descripcionCategoria;
            }

            set
            {
                descripcionCategoria = value;
            }
        }

        public Categorias() { }

        public Categorias(int idCategoria)
        {
            this.idCategoria = idCategoria;
        }

        public Categorias(int idCategoria, string descripcionCategoria)
        {
            this.idCategoria = idCategoria;
            this.descripcionCategoria = descripcionCategoria;
        }
    }
}
