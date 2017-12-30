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
        public static string AgregarDoctor(Doctores doclog)
        {
            string mensaje = string.Empty;
            DoctoresDAL docDAL = new DoctoresDAL();
            mensaje = docDAL.Agregar(doclog);
            if (mensaje.Equals("Registrado"))
                mensaje = "Cuenta registrada con exito";

            else if (mensaje.Contains("uq_email"))
                mensaje = "Este email ya ha sido registrado";
            else
                mensaje = "Ocurrio un error inesperado que no pudo ser controlado";

            return mensaje;
        }
    }
}
