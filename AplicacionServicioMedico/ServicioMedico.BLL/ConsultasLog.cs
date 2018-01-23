using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ServicioMedico.DAL;
using ServicioMedico.BO;

namespace ServicioMedico.BLL
{
    public class ConsultasLog
    {
        public string rutaDoctor { get; set; }

        public ConsultasLog(string mes, string year)
        {
            rutaDoctor = @"C:\Users\leono\Desktop\Web\" + mes + "-" + year + ".pdf";
        }

        public static string AgregarConsulta(Consultas con)
        {
            ConsultasDAL consultaDAL = new ConsultasDAL();
            return consultaDAL.Agregar(con);
        }

        public static string ConsultaConReceta(Consultas con)
        {
            ConsultasDAL consultaDAL = new ConsultasDAL();
            return consultaDAL.Agregar(con);
        }

        public static DataTable TodasLasConsultas(short tipo, short estatus, int idDoc)
        {
            ConsultasDAL consultasDAL = new ConsultasDAL();
            return consultasDAL.GeneralConsultas(tipo, estatus, idDoc);
        }

        public static string ActualizarConsulta(Consultas consulta)
        {
            ConsultasDAL consultaDAL = new ConsultasDAL();
            return consultaDAL.Actualizar(consulta);
        }

        public static string EliminarConsulta(int cveConsulta)
        {
            ConsultasDAL consultaDAL = new ConsultasDAL();
            return consultaDAL.Eliminar(cveConsulta);
        }

        public static List<Consultas> ConsultasAnteriores(int paciente)
        {
            ConsultasDAL consultaDAL = new ConsultasDAL();
            return consultaDAL.AntecedentesClinicos(paciente);
        }

        public static string ActualizarEstatusLOG(int clave, short est)
        {
            ConsultasDAL consultaDAL = new ConsultasDAL();
            return consultaDAL.ActualizarEstatus(clave, est);
        }

        /*private byte Receta()
        {
            System.IO.FileStream fs = new FileStream(rutaDoctor, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            PdfPTable encabezado = new PdfPTable(5);
            Image imgPoli = Image.GetInstance(@"C:\Users\leono\OneDrive\Imágenes\Saved Pictures\ipn.png");
            PdfPCell poli = new PdfPCell(imgPoli);
            poli.Colspan = 1; // either 1 if you need to insert one cell
            poli.Border = 0;
            poli.HorizontalAlignment = 1;
            encabezado.AddCell(poli);

            PdfPCell titulo = new PdfPCell(new Phrase("INSTITUTO POLITECNICO NACIONAL\nCentro de Estudios Cientificos y Tecnologicos No. 13\n\"Ricardo Flores Magon\"\nSUBDIRECCIÓN DE SERVICIOS EDUCATIVOS E INTEGRACION SOCIAL\nDepartamento de Servicios Estudiantiles"));
            titulo.Colspan = 3;
            titulo.Border = 0;
            titulo.PaddingTop = 15f;
            titulo.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right
            encabezado.AddCell(titulo);

            Image imgCecyt = Image.GetInstance(@"C:\Users\leono\OneDrive\Imágenes\Saved Pictures\cecyt13.png");
            PdfPCell cecyt = new PdfPCell(imgCecyt);
            cecyt.Colspan = 1; // either 1 if you need to insert one cell
            cecyt.Border = 0;
            cecyt.HorizontalAlignment = 1;
            encabezado.AddCell(cecyt);
            document.Add(encabezado);

            document.Add(new Paragraph("\n"));



            document.Close();
            writer.Close();
            fs.Close();
            return Convert.ToByte(fs);

        }*/
    }
}
