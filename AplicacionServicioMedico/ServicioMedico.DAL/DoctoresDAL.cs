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
        public string Message { get; set; }

        public DoctoresDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public Doctores Login(Usuario user)
        {
            Doctores docReturn = null;
            try
            {
                comando = new SqlCommand("selIniciarSesion", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@Email", user.Email));
                comando.Parameters.Add(new SqlParameter("@Password", user.Password));
                SqlDataReader dr = null;
                conexion.getCon().Open();
                dr = comando.ExecuteReader();
                if (dr.HasRows)
                {
                    docReturn = new Doctores();
                    while (dr.Read())
                    {
                        docReturn.IdDoctor = dr.GetInt32(0);
                        docReturn.NombreDoctor = dr.GetString(1);
                        docReturn.ApellidosDoctor = dr.GetString(2);
                        docReturn.GeneroDoctor = dr.GetInt16(3);
                        docReturn.EmailDoctor = dr.GetString(4);
                        docReturn.Rol = dr.GetInt16(5);
                        docReturn.VistaReporte = dr.GetBoolean(6);
                    }
                }
                else
                    Message = "Usuario o contraseña erroneos";
                dr.Close();
            }
            catch (SqlException sqlex)
            {
                Message = sqlex.Message;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return docReturn;
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
                if (doc.Responsable != 0)
                    comando.Parameters.Add("@Responsable", SqlDbType.Int).Value = doc.Responsable;
                if(doc.Consultorio != 0)
                    comando.Parameters.Add("@Consultorio", SqlDbType.SmallInt).Value = doc.Consultorio;
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

        public List<Doctores> ListadoRegistro()
        {
            List<Doctores> all;
            try
            {
                comando = new SqlCommand("selListadoDocRegister", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = null;
                conexion.getCon().Open();
                dr = comando.ExecuteReader();
                all = new List<Doctores>();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Doctores d = new Doctores();
                        d.IdDoctor = dr.GetInt32(0);
                        d.NombreDoctor = dr.GetString(1);
                        all.Add(d);
                    }
                }
            }
            catch (Exception)
            {
                all = null;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return all;
        }

        public bool ModificarVistaReporte(int id)
        {
            bool actualizo = false;
            try
            {
                string query = "UPDATE tbDoctores SET VistaReporte = 1 WHERE IdDoctor = " + id;
                comando = new SqlCommand(query, conexion.getCon());
                conexion.getCon().Open();
                if (comando.ExecuteNonQuery() > 0)
                {
                    actualizo = true;
                }
            }
            catch (Exception) { }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return actualizo;
        }
    }
}
