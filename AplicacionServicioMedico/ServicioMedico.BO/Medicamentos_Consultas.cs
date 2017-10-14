using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Medicamentos_Consultas
    {
        private string nombreMedicamento;
        private int cantidadSuministrada;
        private string prescripcionMedica;

        public string NombreMedicamento
        {
            get
            {
                return nombreMedicamento;
            }

            set
            {
                nombreMedicamento = value;
            }
        }

        public int CantidadSuministrada
        {
            get
            {
                return cantidadSuministrada;
            }

            set
            {
                cantidadSuministrada = value;
            }
        }

        public string PrescripcionMedica
        {
            get
            {
                return prescripcionMedica;
            }

            set
            {
                prescripcionMedica = value;
            }
        }
    }
}
