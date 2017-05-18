using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Pacientes
    {
        private int idPaciente;
        private string nombrePaciente;
        private string apellidosPaciente;
        private short generoPaciente;
        private DateTime fechaNac = new DateTime();
        private short edadPaciente;
        private string curp;
        private string calle;
        private int numInt;
        private int numExt;
        private string colonia;
        private string cp;
        private int municipio;
        private int estado;
        private string celular;
        private string telefono;
        private string correoElectronico;
        private short tipoPaciente;

        public int IdPaciente
        {
            get
            {
                return idPaciente;
            }

            set
            {
                idPaciente = value;
            }
        }

        public string NombrePaciente
        {
            get
            {
                return nombrePaciente;
            }

            set
            {
                nombrePaciente = value;
            }
        }

        public string ApellidosPaciente
        {
            get
            {
                return apellidosPaciente;
            }

            set
            {
                apellidosPaciente = value;
            }
        }

        public short GeneroPaciente
        {
            get
            {
                return generoPaciente;
            }

            set
            {
                generoPaciente = value;
            }
        }

        public DateTime FechaNac
        {
            get
            {
                return fechaNac;
            }

            set
            {
                fechaNac = value;
            }
        }

        public short EdadPaciente
        {
            get
            {
                return edadPaciente;
            }

            set
            {
                edadPaciente = value;
            }
        }

        public string Curp
        {
            get
            {
                return curp;
            }

            set
            {
                curp = value;
            }
        }

        public string Calle
        {
            get
            {
                return calle;
            }

            set
            {
                calle = value;
            }
        }

        public int NumInt
        {
            get
            {
                return numInt;
            }

            set
            {
                numInt = value;
            }
        }

        public int NumExt
        {
            get
            {
                return numExt;
            }

            set
            {
                numExt = value;
            }
        }

        public string Colonia
        {
            get
            {
                return colonia;
            }

            set
            {
                colonia = value;
            }
        }

        public string Cp
        {
            get
            {
                return cp;
            }

            set
            {
                cp = value;
            }
        }

        public int Municipio
        {
            get
            {
                return municipio;
            }

            set
            {
                municipio = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string CorreoElectronico
        {
            get
            {
                return correoElectronico;
            }

            set
            {
                correoElectronico = value;
            }
        }

        public short TipoPaciente
        {
            get
            {
                return tipoPaciente;
            }

            set
            {
                tipoPaciente = value;
            }
        }

        public Pacientes() { }

        public Pacientes(int idPaciente)
        {
            this.idPaciente = idPaciente;
        }

        public Pacientes(int idPaciente, string nombrePaciente, string apellidosPaciente, short generoPaciente, DateTime fechaNac, short edadPaciente, string curp, string calle, int numInt, int numExt, string colonia, string cp, int municipio, int estado, string celular, string telefono, string correoElectronico, short tipoPaciente)
        {
            this.idPaciente = idPaciente;
            this.nombrePaciente = nombrePaciente;
            this.apellidosPaciente = apellidosPaciente;
            this.generoPaciente = generoPaciente;
            this.fechaNac = fechaNac;
            this.edadPaciente = edadPaciente;
            this.curp = curp;
            this.calle = calle;
            this.numInt = numInt;
            this.numExt = numExt;
            this.colonia = colonia;
            this.cp = cp;
            this.municipio = municipio;
            this.estado = estado;
            this.celular = celular;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
            this.tipoPaciente = tipoPaciente;
        }
    }
}
