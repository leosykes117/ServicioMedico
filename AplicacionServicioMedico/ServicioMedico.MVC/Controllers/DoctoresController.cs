﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using System.Globalization;
using System.Data;
using ServicioMedico.DAL;
using ServicioMedico.BO;
using ServicioMedico.BLL;
using Newtonsoft.Json;

namespace ServicioMedico.MVC.Controllers
{
    public class DoctoresController : Controller
    {
        // GET: Doctores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultas()
        { 
            return View();
        }
    }
}