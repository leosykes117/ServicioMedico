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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultas()
        { 
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Doctores doc)
        {
            if (!ModelState.IsValid)
            {
                return View(doc);
            }
            /*var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View(model);
            }*/
            return View(doc);
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
                        return RedirectToAction("Index", "Doctores");
                    case 1:
                        ViewBag.MensajesError = "Este correo es invalido";
                        break;
                    default:
                        ViewBag.MensajesError = "Ocurrio un error inesperado que no pudo ser controlado";
                        break;
                }
            }
            else
                ViewBag.MensajesError = "Complete todos los campos";
            return View("Registro");
        }
    }
}