using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioMedico.BO;
using ServicioMedico.BLL;
using Newtonsoft.Json;

namespace ServicioMedico.MVC.Controllers
{
    public class MotivosController : Controller
    {
        // GET: Motivos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListadoMotivos()
        {
            List<Motivos> allMotivos = (List<Motivos>)MotivosLog.ListadoDeMotivos();
            return Json(allMotivos);
        }

        [HttpPost]
        public JsonResult MotivosConsultas(int cve)
        {
            List<Motivos> motCons = (List<Motivos>)MotivosLog.MotivosEnConsulta(cve);
            return Json(motCons);
        }
    }
}