using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class PersonalEscolar:Pacientes
    {
        private string numEmpleado;
        private string rfc;

        public string NumEmpleado
        {
            get
            {
                return numEmpleado;
            }

            set
            {
                numEmpleado = value;
            }
        }

        public string Rfc
        {
            get
            {
                return rfc;
            }

            set
            {
                rfc = value;
            }
        }

        public PersonalEscolar() { }

        public PersonalEscolar(int idPaciente, string nombrePaciente, string apellidosPaciente, short generoPaciente,
            DateTime fechaNac, short edadPaciente, string curp, string calle, int numInt, int numExt,
            string colonia, string cp, int municipio, int estado, string celular, string telefono,
            string correoElectronico, short tipoPaciente, string numEmpleado, string rfc):
            //CONSTRUCTOR DE LA CLASE BASE
            base(idPaciente, nombrePaciente, apellidosPaciente, generoPaciente, fechaNac, edadPaciente,
                curp, calle, numInt, numExt, colonia, cp, municipio, estado, celular, telefono,
                correoElectronico, tipoPaciente)
        {
            IdPaciente = idPaciente;
            NombrePaciente = nombrePaciente;
            ApellidosPaciente = apellidosPaciente;
            GeneroPaciente = generoPaciente;
            FechaNac = fechaNac;
            EdadPaciente = edadPaciente;
            Curp = curp;
            Calle = calle;
            NumInt = numInt;
            NumExt = numExt;
            Colonia = colonia;
            Cp = cp;
            DelMun = municipio;
            Estado = estado;
            Celular = celular;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            TipoPaciente = tipoPaciente;
            this.numEmpleado = numEmpleado;
            this.rfc = rfc;
        }
    }
}
