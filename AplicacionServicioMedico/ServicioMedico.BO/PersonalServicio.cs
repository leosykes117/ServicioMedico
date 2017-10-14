using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    class PersonalServicio
    {
        private int id;
        private string nombre;
        private string apellido;
        private short genero;
        private string curp_Rfc;
        private string correoElectronico;
        private string userName;
        private string passWord;
        private short rol;
        private short vista;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public short Genero
        {
            get
            {
                return genero;
            }

            set
            {
                genero = value;
            }
        }

        public string Curp_Rfc
        {
            get
            {
                return curp_Rfc;
            }

            set
            {
                curp_Rfc = value;
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

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }

        public short Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
        }

        public short Vista
        {
            get
            {
                return vista;
            }

            set
            {
                vista = value;
            }
        }

        public PersonalServicio() { }//CONSTRUCTOR VACIO

        public PersonalServicio(int id, string nombre, string apellido, short genero, string curp_Rfc, string correoElectronico, string userName, string passWord, short rol, short vista)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.genero = genero;
            this.curp_Rfc = curp_Rfc;
            this.correoElectronico = correoElectronico;
            this.userName = userName;
            this.passWord = passWord;
            this.rol = rol;
            this.vista = vista;
        }
    }
}
