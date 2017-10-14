using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ServicioMedico.BO;
using ServicioMedico.BLL;
using Newtonsoft.Json;


namespace ServicioMedico.MVC.Controllers
{
    public class MedicamentosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

       [HttpGet]
       public JsonResult MedicamentosConsultas(int cve)
        {
            List<Medicamentos_Consultas> listaMed = (List<Medicamentos_Consultas>)MedicamentosLog.MedicamentosenConsulta(cve);
            return Json( listaMed, JsonRequestBehavior.AllowGet );
        }

        /*[HttpGet]
        public JsonResult ListadoMedicamentos()
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
            return Json(rows, JsonRequestBehavior.AllowGet);
        }*/

        /*[HttpPost]
        public JsonResult AgregarMedicamento(Medicamentos medicamento)
        {
            string json = string.Empty;
            MedicamentosDAL nuevoMed = new MedicamentosDAL();
            json = nuevoMed.AgregarMedicamento(medicamento);
            return Json(json);
        }

        [HttpPost]
        public JsonResult ListadoMedCat()
        {
            MedicamentosDAL listado = new MedicamentosDAL();
            DataTable tb = listado.MedicamentosCat();
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
            return Json(rows, JsonRequestBehavior.AllowGet);
        }*/
    }
}