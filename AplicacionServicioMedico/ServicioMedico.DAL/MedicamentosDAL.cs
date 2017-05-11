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
        //private SqlDataReader lector;
        private DataSet ds;
        private SqlDataAdapter da;

        public MedicamentosDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public string AgregarMedicamento(Medicamentos medicamento)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("insNuevoMedicamento", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = medicamento.NombreMedicamento;
                comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = medicamento.Cantidad;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = medicamento.FechaCaducidad.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Categoria", SqlDbType.Int).Value = medicamento.Categoria;

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 100);
                pmensaje.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pmensaje);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();
                mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return mensaje;
        }

        public DataTable TodosMedicamentos()
        {
            try
            {
                comando = new SqlCommand("selListadoMedicamentos", conexion.getCon());
                ds = new DataSet();
                comando.CommandType = CommandType.StoredProcedure;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(ds, "Medicamentos");
            }
            catch(Exception)
            {
                ds = null;
                da.Fill(ds);
            }

            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return ds.Tables["Medicamentos"];
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
