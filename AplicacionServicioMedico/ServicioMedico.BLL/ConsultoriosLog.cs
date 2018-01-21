using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ServicioMedico.BO;
using ServicioMedico.DAL;

namespace ServicioMedico.BLL
{
    public class ConsultoriosLog
    {
        public static List<SelectListItem> ListConsultoriosForRegister()
        {
            ConsultoriosDAL consultorioDAL = new ConsultoriosDAL();
            List<SelectListItem> selectLDoc = new List<SelectListItem>(); ;
            List<Consultorios> listConsultorio = (List<Consultorios>)consultorioDAL.ListadoRegistro();
            if (listConsultorio.Count != 0 && listConsultorio != null)
            {
                foreach (var item in listConsultorio)
                {
                    selectLDoc.Add(new SelectListItem()
                    {
                        Value = item.IdConsultorio.ToString(),
                        Text = item.NombreConsultorio
                    });
                }
            }
            else
            {
                selectLDoc.Add(new SelectListItem()
                {
                    Value = "null",
                    Text = "Sin Registros"
                });
            }
            return selectLDoc;
        }
    }
}
