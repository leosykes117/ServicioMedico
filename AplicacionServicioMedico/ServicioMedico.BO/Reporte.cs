using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Reporte
    {
        public int IdReporte { get; set; }

        public int Pertenece { get; set; }
        
        public DateTime FechaReporte { get; set; }
        
        public int HombresA { get; set; }
        
        public int MujeresA { get; set; }

        public int HombresD { get; set; }

        public int MujeresD { get; set; }

        public int HombresP { get; set; }

        public int MujeresP { get; set; }

        public int HombresE { get; set; }

        public int MujeresE { get; set; }

        public int SubtotalH { get; set; }

        public int SubtotalM { get; set; }

        public int Total { get; set; }
    }
}
