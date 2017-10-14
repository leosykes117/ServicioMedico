using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Motivos
    {
        private short idMotivo;
        private string descripcionMotivo;

        public short IdMotivo
        {
            get
            {
                return idMotivo;
            }

            set
            {
                idMotivo = value;
            }
        }

        public string DescripcionMotivo
        {
            get
            {
                return descripcionMotivo;
            }

            set
            {
                descripcionMotivo = value;
            }
        }

        public Motivos() { }

        public Motivos(short idMotivo, string descripcionMotivo)
        {
            this.idMotivo = idMotivo;
            this.descripcionMotivo = descripcionMotivo;
        }
    }
}
