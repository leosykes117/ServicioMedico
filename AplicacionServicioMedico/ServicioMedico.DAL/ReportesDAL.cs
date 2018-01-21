using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using ServicioMedico.BO;

namespace ServicioMedico.DAL
{
    public class ReportesDAL
    {
        private Conexion conexion;
        private SqlCommand comando;
        //private SqlDataReader lector;
        private SqlDataAdapter da;

        public ReportesDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public void InsertarReporte(int mes, int y)
        {
            string mensaje = string.Empty;
            try
            {
                int idRetornado = 0;
                comando = new SqlCommand("insCraerReporte", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;
                comando.Parameters.Add("@YEAR", SqlDbType.Int).Value = y;

                SqlParameter pretornado = new SqlParameter("@ID", SqlDbType.Int);
                pretornado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pretornado);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();
                idRetornado = Convert.ToInt32(comando.Parameters["@ID"].Value.ToString());

                comando = null;
                
                comando = new SqlCommand("UPDATE Reporte SET FechaElaboracion = @Fecha , Archivo = @Archivo WHERE IdReporte = @Id", conexion.getCon());
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = DateTime.Now.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Archivo", SqlDbType.VarBinary).Value = GenerarPdf(mes, y);
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = idRetornado;

                comando.ExecuteNonQuery();

                mensaje = "Reporte Hecho";

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
        }

        public DataTable Reporte(int mes, int y)
        {
            DataTable tablaReportes = new DataTable();
            /*try
            {
                tablaReportes = new DataTable();
                comando = new SqlCommand("selCraerReporte", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;
                comando.Parameters.Add("@YEAR", SqlDbType.Int).Value = y;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(tablaReportes);
            }
            catch (Exception)
            {
                tablaReportes = null;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }*/
            return tablaReportes;
        }

        public byte[] GenerarPdf(int month, int year)
        {
            byte[] bytesArchivo = null;
            DataTable tb = (DataTable)Reporte(month, year);
            MemoryStream ms = new MemoryStream();
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
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
            bytesArchivo = ms.ToArray();
            return bytesArchivo;
        }
    }
}
