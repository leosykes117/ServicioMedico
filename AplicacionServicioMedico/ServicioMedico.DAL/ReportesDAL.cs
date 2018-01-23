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
        private SqlDataAdapter da;

        public ReportesDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public DataTable NuevoReporte(int mes, int y, int doc)
        {
            DataTable reporteMes;
            try
            {
                reporteMes = new DataTable();
                comando = new SqlCommand("insNuevoReporteMes", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@Mes", mes));
                comando.Parameters.Add(new SqlParameter("@YEAR", y));
                comando.Parameters.Add(new SqlParameter("@Doc", doc));
                da = new SqlDataAdapter(comando);
                da.Fill(reporteMes);
            }
            catch (Exception)
            {
                reporteMes = null;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return reporteMes;
        }

        public DataTable Reporte(int mes, int y, int doc)
        {
            DataTable tablaReportes = new DataTable();
            try
            {
                tablaReportes = new DataTable();
                comando = new SqlCommand("selReporte", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;
                comando.Parameters.Add("@YEAR", SqlDbType.Int).Value = y;
                comando.Parameters.Add("@Doc", SqlDbType.Int).Value = doc;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(tablaReportes);
            }
            catch (Exception ex)
            {
                tablaReportes = null;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return tablaReportes;
        }
    }
}
