using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Doctores
    {
        private int idDoctor;
        private string nombreDoctor;
        private string apellidosDoctor;
        private short generoDoctor;
        private string emailDoctor;
        private string passwordEncriptada;
        private short rol;
        private string tokenReseteoPassword;
        private DateTime creadoEl;
        private DateTime modificadoEl;

        public int IdDoctor
        {
            get
            {
                return idDoctor;
            }

            set
            {
                idDoctor = value;
            }
        }

        public string NombreDoctor
        {
            get
            {
                return nombreDoctor;
            }

            set
            {
                nombreDoctor = value;
            }
        }

        public string ApellidosDoctor
        {
            get
            {
                return apellidosDoctor;
            }

            set
            {
                apellidosDoctor = value;
            }
        }

        public short GeneroDoctor
        {
            get
            {
                return generoDoctor;
            }

            set
            {
                generoDoctor = value;
            }
        }

        public string EmailDoctor
        {
            get
            {
                return emailDoctor;
            }

            set
            {
                emailDoctor = value;
            }
        }

        public string PasswordEncriptada
        {
            get
            {
                return passwordEncriptada;
            }

            set
            {
                passwordEncriptada = value;
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

        public string TokenReseteoPassword
        {
            get
            {
                return tokenReseteoPassword;
            }

            set
            {
                tokenReseteoPassword = value;
            }
        }

        public DateTime CreadoEl
        {
            get
            {
                return creadoEl;
            }

            set
            {
                creadoEl = value;
            }
        }

        public DateTime ModificadoEl
        {
            get
            {
                return modificadoEl;
            }

            set
            {
                modificadoEl = value;
            }
        }

        public Doctores() { }

        public Doctores(string email, string password)
        {
            emailDoctor = email;
            passwordEncriptada = password;
        }
    }
}
