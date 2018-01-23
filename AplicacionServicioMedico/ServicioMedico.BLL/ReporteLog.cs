﻿using System;
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
        private string rutaDoctor { get; set; }
        private Doctores doctor;
        private DirectoryInfo di;

        public ReporteLog(Doctores doc)
        {
            rutaDoctor = @"C:\Users\leono\Desktop\Servicio Medico\" + doc.NombreDoctor + " " + doc.ApellidosDoctor + @"\Reportes";
            doctor = doc;
        }

        //AQUI TENEMOS QUE ARMAR LA URL
        public string GenerarPdf(string mes, string year)
        {
            DataTable reporte = (DataTable)ReporteMes();
            if (reporte == null)
            {
                return "Error";
            }
            ComprobarRuta();
            string Ruta = rutaDoctor + @"\Reporte " + mes + " " + year + ".pdf";
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
            if (d.Month == 1)
                prgAuthor.Add(new Chunk("Mes: " + d.AddMonths(-1).ToString("MMMM", new System.Globalization.CultureInfo("es-ES")) + " " + d.AddYears(-1).Year));
            else
                prgAuthor.Add(new Chunk("Mes: " + d.AddMonths(-1).ToString("MMMM", new System.Globalization.CultureInfo("es-ES")) + " " + d.Year));
            prgAuthor.Add(new Chunk("\nFecha de elaboracion: " + DateTime.Now.ToString("dd/MM/yyyy")));
            document.Add(prgAuthor);

            document.Add(new Paragraph("\n"));

            int columnas = reporte.Columns.Count;
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

            for (int i = 0; i < reporte.Rows.Count; i++)
            {
                for (int j = 1; j < reporte.Columns.Count; j++)
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

                for (int j = 0; j < reporte.Columns.Count; j++)
                {
                    table.AddCell(reporte.Rows[i][j].ToString());
                }
            }


            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
            return "Hare el reporte";
        }

        public byte[] ArchivoBytes(string mes, string a)
        {
            byte[] pdfBytes;
            string Ruta = rutaDoctor + @"\Reporte " + mes + " " + a + ".pdf";
            if (!File.Exists(Ruta))
            {
                GenerarPdf(mes, a);
            }
            return pdfBytes = File.ReadAllBytes(Ruta);
        }

        public DataTable ReporteMes()
        {
            DateTime fecha = DateTime.Now;
            DataTable tb;
            if (SiCrear(fecha))
            {
                ReportesDAL reportesDAL = new ReportesDAL();
                int mes = fecha.Month;
                if (mes == 1)
                {
                    tb = reportesDAL.NuevoReporte(12, fecha.Year - 1, doctor.IdDoctor);
                }
                else
                {
                    tb = reportesDAL.NuevoReporte(fecha.Month - 1, fecha.Year, doctor.IdDoctor);
                }

            }
            else
            {
                tb = null;
            }
            return tb;
        }

        public static DataTable ReporteMes(int mesBuscar, int yearBuscar, int id)
        {
            ReportesDAL reporte = new ReportesDAL();
            return reporte.Reporte(mesBuscar, yearBuscar, id);
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

        private void ComprobarRuta()
        {
            try
            {
                if (!Directory.Exists(rutaDoctor))
                {
                    Directory.CreateDirectory(rutaDoctor);
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
