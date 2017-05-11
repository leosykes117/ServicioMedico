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
    public class PacientesDAL
    {
        private Conexion conexion;
        private SqlCommand comando;
        //private SqlDataReader lector;
        private DataSet ds;
        private SqlDataAdapter da;

        public PacientesDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public string insertar(Pacientes paciente)
        {
            string mensaje = string.Empty;
            try
            {
                if (paciente.TipoPaciente == 1)
                {
                    comando = new SqlCommand("insAgregarAlumno", conexion.getCon());
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = paciente.NombrePaciente;
                    comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = paciente.ApellidosPaciente;
                    comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = paciente.GeneroPaciente;
                    comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = paciente.EdadPaciente;
                    comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = paciente.CorreoElectronico;
                    comando.Parameters.Add("@Boleta", SqlDbType.NVarChar, 10).Value = paciente.Boleta;
                    comando.Parameters.Add("@Grupo", SqlDbType.NVarChar, 5).Value = paciente.Grupo;
                    comando.Parameters.Add("@Carrera", SqlDbType.SmallInt).Value = paciente.Carrera;

                    SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 100);
                    pmensaje.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(pmensaje);

                    SqlParameter pretornado = new SqlParameter("@Retornado", SqlDbType.Int);
                    pretornado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(pretornado);

                    conexion.getCon().Open();
                    comando.ExecuteNonQuery();
                    mensaje = comando.Parameters["@Mensaje"].Value.ToString();
                    paciente.IdPaciente = Convert.ToInt32(comando.Parameters["@Retornado"].Value.ToString());
                }
                else
                {
                    comando = new SqlCommand("insAgregarPacientes", conexion.getCon());
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = paciente.NombrePaciente;
                    comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = paciente.ApellidosPaciente;
                    comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = paciente.GeneroPaciente;
                    comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = paciente.EdadPaciente;
                    comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = paciente.CorreoElectronico;
                    comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = paciente.TipoPaciente;

                    SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 100);
                    pmensaje.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(pmensaje);

                    SqlParameter pretornado = new SqlParameter("@Retornado", SqlDbType.Int);
                    pretornado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(pretornado);

                    conexion.getCon().Open();
                    comando.ExecuteNonQuery();
                    mensaje = comando.Parameters["@Mensaje"].Value.ToString();
                    paciente.IdPaciente = Convert.ToInt32(comando.Parameters["@Retornado"].Value.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return mensaje;
        }

        public void modificar(Pacientes paciente)
        {
            
        }

        public void borrar(Pacientes paciente)
        {
            
        }

        public Pacientes buscar(Pacientes paciente)
        {
            return null;
        }

        public List<Pacientes> findAll()
        {
            return null;
        }

        public DataTable BusquedaGeneral(short t)
        {
            try
            {
                comando = new SqlCommand("selGenPacientes", conexion.getCon());
                ds = new DataSet();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = t;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(ds, "Pacientes");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return ds.Tables["Pacientes"];
        }

        public DataTable BusquedaGeneral(short t, string d)
        {
            try
            {
                comando = new SqlCommand("selBuscarPaciente", conexion.getCon());
                ds = new DataSet();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = t;
                comando.Parameters.Add("@Dato", SqlDbType.NVarChar, 50).Value = d;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(ds, "Pacientes");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return ds.Tables["Pacientes"];
        }
    }
}
