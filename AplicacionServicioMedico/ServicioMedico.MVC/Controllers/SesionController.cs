using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioMedico.MVC.Controllers
{
    public class SesionController : Controller
    {
        // GET: Sesion
        public ActionResult Registro()
        {
            return View();
        }
    }
}