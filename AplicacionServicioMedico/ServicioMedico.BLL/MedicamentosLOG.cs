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
    public class MedicamentosLog
    {
        public static List<Medicamentos_Consultas> MedicamentosenConsulta(int consulta)
        {
            MedicamentosDAL medicamentoDAL = new MedicamentosDAL();
            return medicamentoDAL.MedicamentosPorConsuta(consulta);
        }
    }
}
