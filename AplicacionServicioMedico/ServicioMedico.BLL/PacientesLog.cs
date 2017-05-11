using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ServicioMedico.BO;
using ServicioMedico.DAL;

namespace ServicioMedico.BLL
{
    public class PacientesLog
    {
        private PacientesDAL pacientesDAL;

        public PacientesLog()
        {
            pacientesDAL = new PacientesDAL();  
        }

        public void agregar(Pacientes pacientes)
        {
            string respuesta = string.Empty;
            respuesta = pacientesDAL.insertar(pacientes);
        }
    }
}
