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
        public ActionResult Index(int id, string nom, int edad, int genero)
        {
            List<Consultas> lista = objconsultasDAL.AntecedentesClinicos(id);

            ViewBag.idpaciente = id;
            ViewBag.nompaciente = nom;
            ViewBag.edadpaciente = edad;
            ViewBag.generopaciente = genero;
            return View(lista);
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
    }
}