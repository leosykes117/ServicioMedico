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
    public class DoctoresDAL
    {
        private Conexion conexion;
        private SqlCommand comando;

        public DoctoresDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public string Agregar(Doctores doc)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("insNuevoDoctor", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = doc.NombreDoctor;
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 30).Value = doc.ApellidosDoctor;
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = doc.GeneroDoctor;
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = doc.EmailDoctor;
                comando.Parameters.Add("@Passw", SqlDbType.NVarChar, 255).Value = doc.Password;
                comando.Parameters.Add("@Rol", SqlDbType.SmallInt).Value = doc.Rol;

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 4000);
                pmensaje.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pmensaje);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();

                mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }
            catch (SqlException sqlex)
            {
                mensaje = sqlex.Message;
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
            return mensaje;
        }
    }
}
