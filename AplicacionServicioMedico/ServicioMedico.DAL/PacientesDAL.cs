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

        public string Agregar(Alumnos alumno)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("insAgregarAlumno", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = alumno.NombrePaciente;
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = alumno.ApellidosPaciente;
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = alumno.GeneroPaciente;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = alumno.FechaNac.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = alumno.EdadPaciente;
                comando.Parameters.Add("@CURP", SqlDbType.NVarChar, 18).Value = alumno.Curp;

                comando.Parameters.Add("@Calle", SqlDbType.NVarChar, 100).Value = alumno.Calle;
                comando.Parameters.Add("@Int", SqlDbType.Int).Value = alumno.NumInt;
                comando.Parameters.Add("@Ext", SqlDbType.Int).Value = alumno.NumExt;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = alumno.Colonia;
                comando.Parameters.Add("@CP", SqlDbType.NVarChar, 5).Value = alumno.Cp;
                comando.Parameters.Add("@Mun", SqlDbType.Int).Value = alumno.Municipio;
                comando.Parameters.Add("@Estado", SqlDbType.Int).Value = alumno.Estado;

                comando.Parameters.Add("@Celular", SqlDbType.NVarChar, 15).Value = alumno.Celular;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value = alumno.Telefono;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = alumno.CorreoElectronico;
                comando.Parameters.Add("@Boleta", SqlDbType.NVarChar, 10).Value = alumno.Boleta;
                comando.Parameters.Add("@Grupo", SqlDbType.NVarChar, 5).Value = alumno.Grupo;
                comando.Parameters.Add("@Carrera", SqlDbType.SmallInt).Value = alumno.Carrera;

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 100);
                pmensaje.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pmensaje);

                SqlParameter pretornado = new SqlParameter("@Retornado", SqlDbType.Int);
                pretornado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pretornado);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();

                mensaje = comando.Parameters["@Mensaje"].Value.ToString();
                alumno.IdPaciente = Convert.ToInt32(comando.Parameters["@Retornado"].Value.ToString());
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

        public string Agregar(PersonalEscolar pEscolar)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("insAgregarPersonalEscolar", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = pEscolar.NombrePaciente;
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = pEscolar.ApellidosPaciente;
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = pEscolar.GeneroPaciente;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = pEscolar.FechaNac.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = pEscolar.EdadPaciente;
                comando.Parameters.Add("@CURP", SqlDbType.NVarChar, 18).Value = pEscolar.Curp;

                comando.Parameters.Add("@Calle", SqlDbType.NVarChar, 100).Value = pEscolar.Calle;
                comando.Parameters.Add("@Int", SqlDbType.Int).Value = pEscolar.NumInt;
                comando.Parameters.Add("@Ext", SqlDbType.Int).Value = pEscolar.NumExt;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = pEscolar.Colonia;
                comando.Parameters.Add("@CP", SqlDbType.NVarChar, 5).Value = pEscolar.Cp;
                comando.Parameters.Add("@Mun", SqlDbType.Int).Value = pEscolar.Municipio;
                comando.Parameters.Add("@Estado", SqlDbType.Int).Value = pEscolar.Estado;

                comando.Parameters.Add("@Celular", SqlDbType.NVarChar, 15).Value = pEscolar.Celular;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value = pEscolar.Telefono;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = pEscolar.CorreoElectronico;
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = pEscolar.TipoPaciente;
                comando.Parameters.Add("@NumEmpleado", SqlDbType.NVarChar, 10).Value = pEscolar.NumEmpleado;
                comando.Parameters.Add("@RFC", SqlDbType.NVarChar, 15).Value = pEscolar.Rfc;

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 100);
                pmensaje.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pmensaje);

                SqlParameter pretornado = new SqlParameter("@Retornado", SqlDbType.Int);
                pretornado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pretornado);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();

                mensaje = comando.Parameters["@Mensaje"].Value.ToString();
                pEscolar.IdPaciente = Convert.ToInt32(comando.Parameters["@Retornado"].Value.ToString());
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

        public string Agregar(Pacientes externo)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("insAgregarExterno", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = externo.NombrePaciente;
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = externo.ApellidosPaciente;
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = externo.GeneroPaciente;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = externo.FechaNac.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = externo.EdadPaciente;
                comando.Parameters.Add("@CURP", SqlDbType.NVarChar, 18).Value = externo.Curp;

                comando.Parameters.Add("@Calle", SqlDbType.NVarChar, 100).Value = externo.Calle;
                comando.Parameters.Add("@Int", SqlDbType.Int).Value = externo.NumInt;
                comando.Parameters.Add("@Ext", SqlDbType.Int).Value = externo.NumExt;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = externo.Colonia;
                comando.Parameters.Add("@CP", SqlDbType.NVarChar, 5).Value = externo.Cp;
                comando.Parameters.Add("@Mun", SqlDbType.Int).Value = externo.Municipio;
                comando.Parameters.Add("@Estado", SqlDbType.Int).Value = externo.Estado;

                comando.Parameters.Add("@Celular", SqlDbType.NVarChar, 15).Value = externo.Celular;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value = externo.Telefono;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = externo.CorreoElectronico;

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 100);
                pmensaje.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pmensaje);

                SqlParameter pretornado = new SqlParameter("@Retornado", SqlDbType.Int);
                pretornado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pretornado);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();

                mensaje = comando.Parameters["@Mensaje"].Value.ToString();
                externo.IdPaciente = Convert.ToInt32(comando.Parameters["@Retornado"].Value.ToString());
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
    }
}