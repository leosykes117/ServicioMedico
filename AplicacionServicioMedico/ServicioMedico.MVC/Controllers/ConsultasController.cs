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
    public class ConsultasController : Controller
    {
        private ConsultasDAL objconsultasDAL;

        public ConsultasController()
        {
            objconsultasDAL = new ConsultasDAL();
        }

        [HttpPost]
        public ViewResult Index(int id, string nom, int edad, string genero)
        {
            List<Consultas> lista = objconsultasDAL.AntecedentesClinicos(id);
            ViewBag.idpaciente = id;
            ViewBag.nompaciente = nom;
            ViewBag.edadpaciente = edad;
            ViewBag.generopaciente = genero;
            return View(lista);
        }

        [HttpGet]
        public ViewResult VerConsultas()
        {
            return View();
        }

        [HttpPost]
        public ViewResult EditarConsulta(int id, string nom, int edad, string genero, string diagnostico, string fecha, string entrada, string salida, string duracion, int medicamento, int motivo, int cantidad)
        {
            ViewBag.idpaciente = id;
            ViewBag.nompaciente = nom;
            ViewBag.edadpaciente = edad;
            ViewBag.generopaciente = genero;
            ViewBag.diagnostico = diagnostico;
            ViewBag.fecha = fecha;
            ViewBag.entrada = entrada;
            ViewBag.salida = salida;
            ViewBag.duracion = duracion;
            ViewBag.medicamento = medicamento;
            ViewBag.motivo = motivo;
            ViewBag.cantidad = cantidad;
            return View();
        }

        [HttpPost]
        public JsonResult Guardar(Consultas consultaMedica)
        {
            string json = string.Empty;
            ConsultasDAL conDAL = new ConsultasDAL();
            json = conDAL.AgregarConsulta(consultaMedica);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        [HttpPost]
        public JsonResult ListarConsultas(short t, short estatus)
        {
            ConsultasDAL consultas = new ConsultasDAL();
            DataTable tb = consultas.GeneralConsultas(t, estatus);
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
        public JsonResult Actualizar(Consultas consultaEditada)
        {
            string json = string.Empty;
            ConsultasDAL conDAL = new ConsultasDAL();
            json = conDAL.ActualizarConsulta(consultaEditada);
            JsonConvert.SerializeObject(json);
            return Json(json);
        }

        [HttpGet]
        public JsonResult ListadoMotivos()
        {
            ConsultasDAL motivos = new ConsultasDAL();
            DataTable tb = motivos.ListadoMotivos();
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
    }
}