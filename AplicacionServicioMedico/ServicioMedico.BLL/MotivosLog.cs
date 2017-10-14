using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioMedico.BO;
using ServicioMedico.DAL;

namespace ServicioMedico.BLL
{
    public class MotivosLog
    {

        public static List<Motivos> ListadoDeMotivos()
        {
            MotivosDAL motivoDAL = new MotivosDAL();
            return motivoDAL.TodosLosMotivos();
        }

        public static List<Motivos> MotivosEnConsulta(int consulta)
        {
            MotivosDAL motCons = new MotivosDAL();
            return motCons.MotivosPorConsuta(consulta);
        }
    }
}
