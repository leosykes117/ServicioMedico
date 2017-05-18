using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ServicioMedico.BO;
using ServicioMedico.DAL;
using Newtonsoft.Json;

namespace ServicioMedico.BLL
{
    public class PacientesLog
    {
        public string[] AgregarAlumno(Alumnos alum)
        {
            string [] json;
            PacientesDAL alumDAL = new PacientesDAL();
            string respuesta = alumDAL.Agregar(alum);
            if (respuesta == "Registrado")
            {
                json = new string[5];
                json[0] = respuesta;
                json[1] = alum.IdPaciente.ToString();
                json[2] = alum.NombrePaciente + " " + alum.ApellidosPaciente;
                json[3] = alum.EdadPaciente.ToString();
                json[4] = alum.GeneroPaciente.ToString();
            }
            else
            {
                json = new string[1];
                json[0] = respuesta;
            }
            return json;
        }

        public string[] AgregarPersonal(PersonalEscolar pEsc)
        {
            string[] json;
            PacientesDAL personalDAL = new PacientesDAL();
            string respuesta = personalDAL.Agregar(pEsc);
            if (respuesta == "Registrado")
            {
                json = new string[5];
                json[0] = respuesta;
                json[1] = pEsc.IdPaciente.ToString();
                json[2] = pEsc.NombrePaciente + " " + pEsc.ApellidosPaciente;
                json[3] = pEsc.EdadPaciente.ToString();
                json[4] = pEsc.GeneroPaciente.ToString();
            }
            else
            {
                json = new string[1];
                json[0] = respuesta;
            }
            return json;
        }

        public string[] AgregarExterno(Pacientes ext)
        {
            string[] json;
            PacientesDAL externoDAL = new PacientesDAL();
            string respuesta = externoDAL.Agregar(ext);
            if (respuesta == "Registrado")
            {
                json = new string[5];
                json[0] = respuesta;
                json[1] = ext.IdPaciente.ToString();
                json[2] = ext.NombrePaciente + " " + ext.ApellidosPaciente;
                json[3] = ext.EdadPaciente.ToString();
                json[4] = ext.GeneroPaciente.ToString();
            }
            else
            {
                json = new string[1];
                json[0] = respuesta;
            }
            return json;
        }
    }
}
