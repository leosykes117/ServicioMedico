using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioMedico.MVC.Controllers
{
    public class DoctoresController : Controller
    {
        // GET: Doctores
        public ActionResult Index()
        {
            return View();
        }
    }
}