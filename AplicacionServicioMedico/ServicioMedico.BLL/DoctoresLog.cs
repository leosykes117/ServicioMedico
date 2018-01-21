using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioMedico.BO;
using ServicioMedico.DAL;

namespace ServicioMedico.BLL
{
    public class DoctoresLog
    {
        public static string MessageLog { get; set; }

        public static Doctores Login(Usuario userlog)
        {
            DoctoresDAL docDAL = new DoctoresDAL();
            Doctores doc = docDAL.Login(userlog);
            if (doc != null)
            {
                MessageDoc(doc);
            }
            else
            {
                MessageLog = docDAL.Message;
            }
            return doc;
        }

        public static int AgregarDoctor(Doctores doclog)
        {
            string mensaje = string.Empty;
            DoctoresDAL docDAL = new DoctoresDAL();
            mensaje = docDAL.Agregar(doclog);
            if (mensaje.Equals("Registrado"))
                return 0;
            else if (mensaje.Contains("uq_email"))
                return 1;
            else
                return 4;
        }

        public static void MessageDoc(Doctores doc)
        {
            string nombre = OneWord(doc.NombreDoctor).ToUpper() + " " + OneWord(doc.ApellidosDoctor.ToUpper());
            
            switch (doc.Rol)
            {
                case 1:
                    if (doc.GeneroDoctor == 1)
                        MessageLog = "BIENVENIDO ADMINISTRADOR " + nombre;
                    else
                        MessageLog = "BIENVENIDA ADMINISTRADORA " + nombre;
                    break;

                case 2:
                    if (doc.GeneroDoctor == 1)
                        MessageLog = "BIENVENIDO DOCTOR " + nombre;
                    else
                        MessageLog = "BIENVENIDA DOCTORA " + nombre;
                    break;
                case 3:
                    if (doc.GeneroDoctor == 1)
                        MessageLog = "BIENVENIDO PASANTE " + nombre;
                    else
                        MessageLog = "BIENVENIDA PASANTE " + nombre;
                    break;
                default:
                    break;
            }
        }

        public static List<SelectListItem> ListForRegister()
        {
            DoctoresDAL docDAL = new DoctoresDAL();
            List<SelectListItem> selectLDoc = new List<SelectListItem>(); ;
            List<Doctores> listDoc = (List<Doctores>)docDAL.ListadoRegistro();
            if (listDoc.Count != 0 && listDoc != null)
            {
                foreach (var item in listDoc)
                {
                    selectLDoc.Add(new SelectListItem()
                    {
                        Value = item.IdDoctor.ToString(),
                        Text = item.NombreDoctor
                    });
                }
            }
            else
            {
                selectLDoc.Add(new SelectListItem()
                {
                    Value = "0",
                    Text = "Sin Registros"
                });
            }
            return selectLDoc;
        }

        private static string OneWord(string word)
        {
            if (word.Contains(" "))
            {
                word = word.Split(' ')[0];
            }
            return word;
        }
    }
}
