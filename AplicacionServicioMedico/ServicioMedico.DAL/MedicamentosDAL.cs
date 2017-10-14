using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ServicioMedico.BO;

namespace ServicioMedico.DAL
{
    public class MedicamentosDAL
    {
        private Conexion conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private DataSet ds;
        private SqlDataAdapter da;

        public MedicamentosDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public List<Medicamentos_Consultas> MedicamentosPorConsuta(int claveConsulta)
        {
            List<Medicamentos_Consultas> listadomedicamentos;
            try
            {
                listadomedicamentos = new List<Medicamentos_Consultas>();
                comando = new SqlCommand("selHistoriaMedicamentos", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Consulta", SqlDbType.Int).Value = claveConsulta;
                conexion.getCon().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Medicamentos_Consultas med = new Medicamentos_Consultas();
                    med.NombreMedicamento = lector[0].ToString();
                    med.CantidadSuministrada = Convert.ToInt32(lector[1]);
                    med.PrescripcionMedica = lector[2].ToString();
                    listadomedicamentos.Add(med);
                }
            }
            catch (Exception ex)
            {
                listadomedicamentos = new List<Medicamentos_Consultas>();
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return listadomedicamentos;
        }

        public DataTable MedicamentosCat()
        {
            try
            {
                comando = new SqlCommand("selBusquedaMedCat", conexion.getCon());
                ds = new DataSet();
                comando.CommandType = CommandType.StoredProcedure;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(ds, "MedCats");
            }
            catch(Exception)
            {
                
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return ds.Tables["MedCats"];
        }
    }
}
