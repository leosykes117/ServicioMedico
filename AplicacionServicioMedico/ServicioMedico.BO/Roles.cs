using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    class Roles
    {
        private short idRol; 
        private string descripcionRol;

        public short IdRol
        {
            get
            {
                return idRol;
            }

            set
            {
                idRol = value;
            }
        }

        public string DescripcionRol
        {
            get
            {
                return descripcionRol;
            }

            set
            {
                descripcionRol = value;
            }
        }

        public Roles() { }

        public Roles(short idRol, string descripcionRol)
        {
            this.idRol = idRol;
            this.descripcionRol = descripcionRol;
        }
    }
}
