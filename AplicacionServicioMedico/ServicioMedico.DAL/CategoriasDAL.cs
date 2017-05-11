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
    public class CategoriasDAL
    {
        private Conexion conexion;
        private SqlCommand comando;
        //private SqlDataReader lector;
        private DataSet ds;
        private SqlDataAdapter da;

        public CategoriasDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public string Insertar(Categorias categoria)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("insNuevaCategoria", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 30).Value = categoria.DescripcionCategoria;

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 100);
                pmensaje.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pmensaje);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();
                mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }
            catch(Exception ex)
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

        public DataTable ListadoCategorias()
        {
            try
            {
                comando = new SqlCommand("selListadoCategorias", conexion.getCon());
                ds = new DataSet();
                comando.CommandType = CommandType.StoredProcedure;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(ds, "Categorias");
            }
            catch (Exception)
            {
                
            }

            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return ds.Tables["Categorias"];
        }
    }
}
