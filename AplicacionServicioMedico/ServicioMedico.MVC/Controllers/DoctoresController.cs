using System;
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
        public ActionResult Index(string message)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Doctores doc = (Doctores)Session["user"];
            
            if (string.IsNullOrEmpty(message))
            {
                DoctoresLog.MessageDoc(doc);
                message = DoctoresLog.MessageLog;
            }
            ViewBag.Welcome = message;
            ViewBag.Name = doc.NombreDoctor;
            ViewBag.vistaRep = doc.VistaReporte;
            return View();
        }

        public ActionResult Consultas()
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        public ActionResult Registro()
        {
            ViewBag.consRegister = ConsultoriosLog.ListConsultoriosForRegister();
            ViewBag.docsRegister = DoctoresLog.ListForRegister();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Usuario doc)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MensajesError = "Ingrese correo electronico y contraseña";
                return RedirectToAction("Index", "Home");
            }

            var result = DoctoresLog.Login(doc);
            if (result != null)
            {
                Session["user"] = result;
                return RedirectToAction("Index", "Doctores", new { @message = DoctoresLog.MessageLog });
            }
            ViewBag.MensajesError = DoctoresLog.MessageLog;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Doctores doc)
        {
            if (ModelState.IsValid)
            {
                var msm = DoctoresLog.AgregarDoctor(doc);
                switch (msm)
                {
                    case 0:
                        Usuario user = new Usuario() { Email = doc.EmailDoctor, Password = doc.Password };
                        Session["user"] = DoctoresLog.Login(user);
                        return RedirectToAction("Index", "Doctores", new { @message = DoctoresLog.MessageLog });
                    case 1:
                        ViewBag.MensajesError = "Este correo no es invalido";
                        ViewBag.consRegister = ConsultoriosLog.ListConsultoriosForRegister();
                        ViewBag.docsRegister = DoctoresLog.ListForRegister();
                        break;
                    default:
                        ViewBag.MensajesError = "Ocurrio un error inesperado que no pudo ser controlado";
                        ViewBag.consRegister = ConsultoriosLog.ListConsultoriosForRegister();
                        ViewBag.docsRegister = DoctoresLog.ListForRegister();
                        break;
                }
            }
            else
            {
                ViewBag.consRegister = ConsultoriosLog.ListConsultoriosForRegister();
                ViewBag.docsRegister = DoctoresLog.ListForRegister();
                ViewBag.MensajesError = "Complete todos los campos";
            }
            return View("Registro");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            if (Session["user"] != null)
                Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}