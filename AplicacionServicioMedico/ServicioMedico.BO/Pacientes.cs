using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Pacientes
    {
        //ATRIBUTOS
        private int idPaciente;
        private string nombrePaciente;
        private string apellidosPaciente;
        private short generoPaciente;
        private short edadPaciente;
        private string correoElectronico;
        private string boleta;
        private string grupo;
        private short carrera;
        private short tipoPaciente;

        //PROPIEDADES
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


        //CONSTRUCTORES
        public Pacientes() { } //CONSTRUCTOR VACIO

        public Pacientes(int id) //CONSTRUTOR PARA BUSCAR
        {
            idPaciente = id;
        }

        //CONTRUCTOR PARA AGREGAR PACIENTE
        public Pacientes(string nombre, string apellidos, short genero, short edad, string correo, short tipo)
        {
            nombrePaciente = nombre;
            apellidosPaciente = apellidos;
            generoPaciente = genero;
            edadPaciente = edad;
            correoElectronico = correo;
            tipoPaciente = tipo;
        }

        //CONSTRUCTOR PARA AGREGAR ALUMNO
        public Pacientes(string nombre, string apellidos, short genero, short edad, string correo, string bol, string grp, short carr, short tipo)
        {
            nombrePaciente = nombre;
            apellidosPaciente = apellidos;
            generoPaciente = genero;
            edadPaciente = edad;
            correoElectronico = correo;
            boleta = bol;
            grupo = grp;
            carrera = carr;
            tipoPaciente = tipo;
        }
    }
}
