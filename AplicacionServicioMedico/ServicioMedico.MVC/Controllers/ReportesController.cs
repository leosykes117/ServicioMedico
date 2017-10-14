using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ServicioMedico.BLL;
using ServicioMedico.BO;

namespace ServicioMedico.MVC.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ViewResult Index()
        {
            DataTable tb = (DataTable)ReporteLog.ReporteMes();
            return View(tb);
        }
    
        public ViewResult Anteriores()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ReporteAnterior(int Mes, int Year)
        {
            DataTable tb = (DataTable)ReporteLog.ReporteMes(Mes, Year);
            List<Dictionary<string, object>> objetoJSON = new List<Dictionary<string, object>>();
            Dictionary<string, object> atributo;
            foreach (DataRow dr in tb.Rows)
            {
                atributo = new Dictionary<string, object>();
                foreach (DataColumn col in tb.Columns)
                {
                    atributo.Add(col.ColumnName, dr[col]);
                }
                objetoJSON.Add(atributo);
            }
            return Json(objetoJSON, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ReportePF(string mesR, string yearR)
        {
            ReporteLog reportelog = new ReporteLog(mesR, yearR);
            string json = reportelog.GenerarPdf();
            return Json(json);
        }

        [HttpPost]
        public FileContentResult Archivo(int mesR, string yearR)
        {
            string[] meses = new string[12] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            ReporteLog reportelog = new ReporteLog(meses[mesR], yearR);
            return File(reportelog.ArchivoBytes() , "application/pdf");
        }
    }
}