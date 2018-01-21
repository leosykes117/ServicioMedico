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
    public class ConsultasController : Controller
    {
        [HttpPost]
        public ActionResult Index(int id, string nom, int edad, string genero)
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", "Home");

            List<Consultas> lista = (List<Consultas>)ConsultasLog.ConsultasAnteriores(id);
            ViewBag.idpaciente = id;
            ViewBag.nompaciente = nom;
            ViewBag.edadpaciente = edad;
            ViewBag.generopaciente = genero;
            return View(lista);
        }

        [HttpGet]
        public ActionResult VerConsultas()
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpGet]
        public ActionResult ConsultasEliminadas()
        {
            if(Session["user"] == null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        //string diagnostico, string observaciones, string cveDoctor, DateTime fecha, DateTime entrada, DateTime salida
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ViewResult EditarConsulta(int id, string nom, int edad, string genero, Consultas con)
        {
            ViewBag.idConsulta = id;
            ViewBag.nompaciente = nom;
            ViewBag.edadpaciente = edad;
            ViewBag.generopaciente = genero;
            ViewBag.diagnostico = con.Diagnostico;
            ViewBag.observaciones = con.Observaciones;
            ViewBag.cveDoctor = con.CveDoctor;
            ViewBag.fecha = con.FechaConsulta.ToString("dd/MM/yyyy");
            ViewBag.entrada = con.HoraEntrada.ToString("HH:mm:ss");
            ViewBag.salida = con.HoraSalida.ToString("HH:mm:ss");
            ViewBag.temp = Convert.ToSingle(con.Temperatura);
            ViewBag.ta = con.TA;
            ViewBag.fc = Convert.ToSingle(con.FC);
            ViewBag.fr = Convert.ToSingle(con.FR);
            return View();
        }

        [HttpPost]
        public JsonResult Guardar(Consultas nuevaConsulta)
        {
            Doctores doc = (Doctores)Session["user"];
            nuevaConsulta.CveDoctor = doc.IdDoctor;
            string json = ConsultasLog.AgregarConsulta(nuevaConsulta);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        public JsonResult ConReceta(Consultas nuevaConsulta)
        {
            string json = ConsultasLog.AgregarConsulta(nuevaConsulta);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult Actualizar([Bind(Include = "IdConsulta, Diagnostico, Observaciones, FechaConsulta, HoraEntrada, HoraSalida, Temperatura, TA, FC, FR")]Consultas consultaEditada)
        {
            string json = ConsultasLog.ActualizarConsulta(consultaEditada);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        [HttpPost]
        public JsonResult Eliminar([Bind(Include="consulta")]int consulta)
        {
            string json = ConsultasLog.EliminarConsulta(consulta);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        [HttpPost]
        public JsonResult CambiarEstatus([Bind(Include = "consulta")]int consulta, short estatusCon)
        {
            string json = ConsultasLog.ActualizarEstatusLOG(consulta,estatusCon);
            return Json(json);
        }

        [HttpPost]
        public JsonResult ListarConsultas(short t, short estatus)
        {
            DataTable tb = (DataTable)ConsultasLog.TodasLasConsultas(t, estatus);
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
            return Json(rows);
        }
    }
}