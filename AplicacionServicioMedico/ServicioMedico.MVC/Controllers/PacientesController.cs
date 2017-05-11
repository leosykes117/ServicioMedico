using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ServicioMedico.DAL;
using ServicioMedico.BO;
using ServicioMedico.BLL;
using Newtonsoft.Json;

namespace ServicioMedico.MVC.Controllers
{
    public class PacientesController : Controller
    {
        // GET: Pacientes
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListadoGeneral(int tipo)
        {
            PacientesDAL objDAL = new PacientesDAL();
            DataTable tb = objDAL.BusquedaGeneral(Convert.ToInt16(tipo));
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
        }

        [HttpPost]
        public JsonResult BusquedaPaciente(int tipo, string dato)
        {
            PacientesDAL objDAL = new PacientesDAL();
            DataTable tb = objDAL.BusquedaGeneral(Convert.ToInt16(tipo), dato);
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
        }

        [HttpPost]
        public JsonResult NuevoPaciente(Pacientes paciente)
        {
            string [] json = new string[5];
            PacientesDAL pacDal = new PacientesDAL();
            json[0] = pacDal.insertar(paciente);
            json[1] = paciente.IdPaciente.ToString();
            json[2] = paciente.NombrePaciente + " " + paciente.ApellidosPaciente;
            json[3] = paciente.EdadPaciente.ToString();
            json[4] = paciente.GeneroPaciente.ToString();
            JsonConvert.SerializeObject(json);
            return Json(json);
        }
    }
}