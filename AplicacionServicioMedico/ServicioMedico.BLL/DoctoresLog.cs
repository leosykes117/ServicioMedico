using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioMedico.BO;
using ServicioMedico.DAL;

namespace ServicioMedico.BLL
{
    public class DoctoresLog
    {
        public static bool Succeeded { get; set; }

        public static int AgregarDoctor(Doctores doclog)
        {
            string mensaje = string.Empty;
            DoctoresDAL docDAL = new DoctoresDAL();
            mensaje = docDAL.Agregar(doclog);
            if (mensaje.Equals("Registrado"))
                return 0;
            else if (mensaje.Contains("uq_email"))
                return 1;
            else
                return 4;
        }
    }
}
