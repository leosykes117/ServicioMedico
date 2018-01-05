using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using ServicioMedico.BO;
using ServicioMedico.DAL;

namespace ServicioMedico.BLL
{
    public class ReporteLog
    {
        public string rutaDoctor { get; set; }

        public ReporteLog(string mes, string year)
        {
            rutaDoctor = @"C:\Users\leono\Desktop\Web\" + mes + "-" + year + ".pdf" ;
        }

        //AQUI TENEMOS QUE ARMAR LA URL
        public string GenerarPdf()
        {
            DataTable tb = (DataTable)ReporteMes();
            if (tb == null)
            {
                return "Error";
            }
            string Ruta = rutaDoctor;
            System.IO.FileStream fs = new FileStream(Ruta, FileMode.Create, FileAccess.Write, FileShare.None);
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

            PdfPCell titulo = new PdfPCell(new Phrase("INSTITUTO POLITECNICO NACIONAL\nSECRETARIA DE SERVICIOS EDUCATIVOS\nDIRECCIÓN DE SERVICIOS ESTUDIANTILES"));
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

            document.Add(new Paragraph("\n\n"));

            DateTime d = DateTime.Now;
            Paragraph prgAuthor = new Paragraph();
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Mes: " + d.AddMonths(-1).ToString("MMMM", new System.Globalization.CultureInfo("es-ES")) + " " + d.Year));
            prgAuthor.Add(new Chunk("\nFecha de elaboracion: " + d.ToString("dd/MM/yyyy")));
            document.Add(prgAuthor);

            document.Add(new Paragraph("\n"));

            int columnas = tb.Columns.Count;
            PdfPTable table = new PdfPTable(columnas);
            PdfPCell headerTabla = new PdfPCell(new Phrase("Servicio Medico"));
            headerTabla.Colspan = columnas - 1;
            headerTabla.HorizontalAlignment = 1;
            table.AddCell(headerTabla);

            PdfPCell headerTotal = new PdfPCell(new Phrase("TOTAL"));
            headerTotal.Rowspan = 3;
            table.AddCell(headerTotal);

            PdfPCell headerAlu = new PdfPCell(new Phrase("ALUMNOS"));
            headerAlu.Colspan = 2;
            table.AddCell(headerAlu);

            PdfPCell headerDoc = new PdfPCell(new Phrase("DOCENTES"));
            headerDoc.Colspan = 2;
            table.AddCell(headerDoc);

            PdfPCell headerPaae = new PdfPCell(new Phrase("PERSONA DE APOYO"));
            headerPaae.Colspan = 2;
            table.AddCell(headerPaae);

            PdfPCell headerExt = new PdfPCell(new Phrase("EXTERNOS"));
            headerExt.Colspan = 2;
            table.AddCell(headerExt);

            PdfPCell headerSub = new PdfPCell(new Phrase("SUBTOTAL"));
            headerSub.Colspan = 2;
            table.AddCell(headerSub);

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                for (int j = 1; j < tb.Columns.Count; j++)
                {
                    if ((j - 1) % 2 == 0)
                    {
                        table.AddCell(new PdfPCell(new Paragraph("Hombres")));
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Paragraph("Mujeres")));
                    }
                }

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    table.AddCell(tb.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
            return "Hare el reporte";
        }

        public byte[] ArchivoBytes()
        {
            byte[] pdfBytes;

            if (!File.Exists(rutaDoctor))
            {
                GenerarPdf();
            }
            return pdfBytes = File.ReadAllBytes(rutaDoctor);
        }

        public static DataTable ReporteMes()
        {
            DateTime fecha = DateTime.Now;
            DataTable tb;
            if (SiCrear(fecha))
            {
                ReportesDAL reportesDAL = new ReportesDAL();
                int mes = fecha.Month;
                if (mes == 1)
                {
                    tb = reportesDAL.Reporte(12, fecha.Year - 1);
                }
                else
                {
                    tb = reportesDAL.Reporte(fecha.Month - 1, fecha.Year);
                }

            }
            else
            {
                tb = null;
            }
            return tb;
        }

        public static DataTable ReporteMes(int mesBuscar, int yearBuscar)
        {
            ReportesDAL reporte = new ReportesDAL();
            return reporte.Reporte(mesBuscar, yearBuscar);
        }

        private static bool SiCrear(DateTime today)
        {
            bool respuesta = false;
             string diaSemana = today.ToString("dddd", new CultureInfo("es-ES"));
             if (diaSemana != "sábado" && diaSemana != "domingo")
             {
                 int dia = today.Day;
                 if (dia >= 1 && dia <= 7)
                 {
                     respuesta = true;
                 }
             }

             return respuesta;
        }
    }
}
