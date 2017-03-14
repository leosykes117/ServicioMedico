using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico
{
    class Utilerias
    {
        public static string BienvenidaHTML(string nomDoc, string usuario, string Clave, string Password)
        {
            string documento = string.Empty;
            try
            {
                string ruta = "C:\\Programas\\ServicioMedico\\AppServicioMedico\\WRServicioMedico\\documentos\\Bienvenida.html";
                StreamReader lectura = new StreamReader(ruta);
                documento = lectura.ReadToEnd();
                documento = documento.Replace("{Nombre del Doc}", nomDoc);
                documento = documento.Replace("{Usuario}", usuario);
                documento = documento.Replace("{ID}", Clave);
                documento = documento.Replace("{Contraseña}", Password);
            }
            catch (EndOfStreamException)
            {
                documento = "No se realizo";
            }
            catch (Exception)
            {
                documento = "No se realizo";
            }
            return documento;
        }
    }
}
