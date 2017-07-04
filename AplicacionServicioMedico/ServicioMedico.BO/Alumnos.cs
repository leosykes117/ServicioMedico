using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Alumnos:Pacientes
    {
        private string boleta;
        private string grupo;
        private short carrera;

        public string Boleta
        {
            get
            {
                return boleta;
            }

            set
            {
                boleta = value;
            }
        }

        public string Grupo
        {
            get
            {
                return grupo;
            }

            set
            {
                grupo = value;
            }
        }

        public short Carrera
        {
            get
            {
                return carrera;
            }

            set
            {
                carrera = value;
            }
        }

        public Alumnos(){ }

        public Alumnos(int idPaciente, string nombrePaciente, string apellidosPaciente, short generoPaciente, 
            DateTime fechaNac, short edadPaciente, string curp, string calle, int numInt, int numExt, 
            string colonia, string cp, int delMun, int estado, string celular, string telefono, 
            string correoElectronico, short tipoPaciente, string boleta, string grupo, short carrera) : 
            //CONSTRUCTOR DE LA CLASE BASE 
            base (idPaciente, nombrePaciente, apellidosPaciente, generoPaciente, fechaNac, edadPaciente, 
                curp, calle, numInt, numExt, colonia, cp, delMun, estado, celular, telefono, 
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
            DelMun = delMun;
            Estado = estado;
            Celular = celular;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            TipoPaciente = tipoPaciente;
            this.boleta = boleta;
            this.grupo = grupo;
            this.carrera = carrera;
        }
    }
}
