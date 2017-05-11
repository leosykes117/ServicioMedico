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
    public class CategoriasController : Controller
    {
        public JsonResult ListadoCategorias()
        {
            CategoriasDAL listado = new CategoriasDAL();
            DataTable tb = listado.ListadoCategorias();
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