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
    public class MedicamentosLOG
    {
        public string TodosMedicamentos()
        {
            MedicamentosDAL listado = new MedicamentosDAL();
            DataTable tb = listado.TodosMedicamentos();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in tb.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in tb.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return JsonConvert.SerializeObject(rows);
        }
    }
}
