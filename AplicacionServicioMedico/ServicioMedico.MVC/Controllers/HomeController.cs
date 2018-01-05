﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioMedico.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if(Session["user"] != null)
            {
                return RedirectToAction("Index", "Doctores");
            }
            return View();
        }
    }
}