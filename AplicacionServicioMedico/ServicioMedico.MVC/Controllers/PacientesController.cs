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
            if(Session["user"] == null)
                return RedirectToAction("Index", "Doctores");
            return View();
        }

        public ActionResult PacientesEliminados()
        {
            if(Session["user"] == null)
                return RedirectToAction("Index", "Doctores");
            return View();
        }

        [HttpPost]
        public JsonResult ListadoGeneral(int tipo, int estatus)
        {
            PacientesDAL objDAL = new PacientesDAL();
            DataTable tb = objDAL.BusquedaGeneral(Convert.ToInt16(tipo), Convert.ToInt16(estatus));
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            if (tb != null)
            {
                foreach (DataRow dr in tb.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in tb.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
            }
            else
            {

            }
            
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AgregarAlumno(Alumnos nuevoPaciente)
        {
            PacientesLog pacientelog = new PacientesLog();
            string [] JsonAlum = pacientelog.AgregarAlumno(nuevoPaciente);
            JsonConvert.SerializeObject(JsonAlum);
            return Json(JsonAlum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AgregarPersonal(PersonalEscolar nuevoPaciente)
        {
            PacientesLog pacientelog = new PacientesLog();
            string[] JsonPersonal = pacientelog.AgregarPersonal(nuevoPaciente);
            JsonConvert.SerializeObject(JsonPersonal);
            return Json(JsonPersonal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AgregarExterno(Pacientes nuevoPaciente)
        {
            PacientesLog pacientelog = new PacientesLog();
            string[] JsonExterno = pacientelog.AgregarExterno(nuevoPaciente);
            JsonConvert.SerializeObject(JsonExterno);
            return Json(JsonExterno);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult ActualizarAlumno(Alumnos aluActualizar)
        {
            PacientesDAL pacienteDAL = new PacientesDAL();
            string json = pacienteDAL.Actualizar(aluActualizar);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult ActualizarPersonalE(PersonalEscolar personalActualizar)
        {
            PacientesDAL pacienteDAL = new PacientesDAL();
            string json = pacienteDAL.Actualizar(personalActualizar);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult ActualizarExterno(Pacientes extActualizar)
        {
            PacientesDAL pacienteDAL = new PacientesDAL();
            string json = pacienteDAL.Actualizar(extActualizar);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        [HttpPost]
        public JsonResult ActualizarEstatus(Pacientes pacEliminar)
        {
            PacientesDAL pacienteDAL = new PacientesDAL();
            string json = pacienteDAL.ActualizarEstatus(pacEliminar);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EliminarPaciente(int paciente)
        {
            string json = PacientesLog.EliminarPaciente(paciente);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }
    }
}