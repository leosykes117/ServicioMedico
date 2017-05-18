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
        public JsonResult AgregarAlumno(Alumnos alumno)
        {
            PacientesLog pacientelog = new PacientesLog();
            string [] JsonAlum = pacientelog.AgregarAlumno(alumno);
            JsonConvert.SerializeObject(JsonAlum);
            return Json(JsonAlum);
        }

        [HttpPost]
        public JsonResult AgregarPersonal(PersonalEscolar personal)
        {
            PacientesLog pacientelog = new PacientesLog();
            string[] JsonPersonal = pacientelog.AgregarPersonal(personal);
            JsonConvert.SerializeObject(JsonPersonal);
            return Json(JsonPersonal);
        }

        [HttpPost]
        public JsonResult AgregarExterno(Pacientes pExterno)
        {
            PacientesLog pacientelog = new PacientesLog();
            string[] JsonExterno = pacientelog.AgregarExterno(pExterno);
            JsonConvert.SerializeObject(JsonExterno);
            return Json(JsonExterno);
        }
    }
}