    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using ServicioMedico.BO;

namespace ServicioMedico.DAL
{
    public class PacientesDAL
    {
        private Conexion conexion;
        private SqlCommand comando;
        /*private SqlDataReader lector;
        //private DataSet ds;*/
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
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = Capitalize(alumno.NombrePaciente);
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = Capitalize(alumno.ApellidosPaciente);
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = alumno.GeneroPaciente;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = alumno.FechaNac.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = alumno.EdadPaciente;
                comando.Parameters.Add("@CURP", SqlDbType.NVarChar, 18).Value = Uppercase(alumno.Curp);

                comando.Parameters.Add("@Calle", SqlDbType.NVarChar, 100).Value = Capitalize(alumno.Calle);
                comando.Parameters.Add("@Int", SqlDbType.Int).Value = alumno.NumInt;
                comando.Parameters.Add("@Ext", SqlDbType.Int).Value = alumno.NumExt;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = Capitalize(alumno.Colonia);
                comando.Parameters.Add("@CP", SqlDbType.NVarChar, 5).Value = alumno.Cp;
                comando.Parameters.Add("@Mun", SqlDbType.Int).Value = alumno.DelMun;
                comando.Parameters.Add("@Estado", SqlDbType.Int).Value = alumno.Estado;

                comando.Parameters.Add("@Celular", SqlDbType.NVarChar, 15).Value = alumno.Celular;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value = alumno.Telefono;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = alumno.CorreoElectronico;
                comando.Parameters.Add("@Boleta", SqlDbType.NVarChar, 10).Value = Uppercase(alumno.Boleta);
                comando.Parameters.Add("@Grupo", SqlDbType.NVarChar, 5).Value = Uppercase(alumno.Grupo);
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
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = Capitalize(pEscolar.NombrePaciente);
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = Capitalize(pEscolar.ApellidosPaciente);
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = pEscolar.GeneroPaciente;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = pEscolar.FechaNac.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = pEscolar.EdadPaciente;
                comando.Parameters.Add("@CURP", SqlDbType.NVarChar, 18).Value = Uppercase(pEscolar.Curp);

                comando.Parameters.Add("@Calle", SqlDbType.NVarChar, 100).Value = Capitalize(pEscolar.Calle);
                comando.Parameters.Add("@Int", SqlDbType.Int).Value = pEscolar.NumInt;
                comando.Parameters.Add("@Ext", SqlDbType.Int).Value = pEscolar.NumExt;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = Capitalize(pEscolar.Colonia);
                comando.Parameters.Add("@CP", SqlDbType.NVarChar, 5).Value = pEscolar.Cp;
                comando.Parameters.Add("@Mun", SqlDbType.Int).Value = pEscolar.DelMun;
                comando.Parameters.Add("@Estado", SqlDbType.Int).Value = pEscolar.Estado;

                comando.Parameters.Add("@Celular", SqlDbType.NVarChar, 15).Value = pEscolar.Celular;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value = pEscolar.Telefono;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = pEscolar.CorreoElectronico;
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = pEscolar.TipoPaciente;
                comando.Parameters.Add("@NumEmpleado", SqlDbType.NVarChar, 10).Value = Uppercase(pEscolar.NumEmpleado);
                comando.Parameters.Add("@RFC", SqlDbType.NVarChar, 15).Value = Uppercase(pEscolar.Rfc);

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
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = Capitalize(externo.NombrePaciente);
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = Capitalize(externo.ApellidosPaciente);
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = externo.GeneroPaciente;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = externo.FechaNac.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = externo.EdadPaciente;
                comando.Parameters.Add("@CURP", SqlDbType.NVarChar, 18).Value = Uppercase(externo.Curp);

                comando.Parameters.Add("@Calle", SqlDbType.NVarChar, 100).Value = Capitalize(externo.Calle);
                comando.Parameters.Add("@Int", SqlDbType.Int).Value = externo.NumInt;
                comando.Parameters.Add("@Ext", SqlDbType.Int).Value = externo.NumExt;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = Capitalize(externo.Colonia);
                comando.Parameters.Add("@CP", SqlDbType.NVarChar, 5).Value = externo.Cp;
                comando.Parameters.Add("@Mun", SqlDbType.Int).Value = externo.DelMun;
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
                mensaje = ex.Message;
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return mensaje;
        }

        public DataTable BusquedaGeneral(short t, short estatus)
        {
            DataTable tablaPacientes;
            try
            {
                comando = new SqlCommand("selGenPacientes", conexion.getCon());
                tablaPacientes = new DataTable();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = t;
                comando.Parameters.Add("@Estatus", SqlDbType.SmallInt).Value = estatus;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(tablaPacientes);
            }
            catch (Exception)
            {
                tablaPacientes = new DataTable();
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return tablaPacientes;
        }

        public string Actualizar(Alumnos alumno)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("updActualizarAlumno", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = alumno.IdPaciente;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = Capitalize(alumno.NombrePaciente);
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = Capitalize(alumno.ApellidosPaciente);
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = alumno.GeneroPaciente;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = alumno.FechaNac.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = alumno.EdadPaciente;
                comando.Parameters.Add("@CURP", SqlDbType.NVarChar, 18).Value = Uppercase(alumno.Curp);

                comando.Parameters.Add("@Calle", SqlDbType.NVarChar, 100).Value = Capitalize(alumno.Calle);
                comando.Parameters.Add("@Int", SqlDbType.Int).Value = alumno.NumInt;
                comando.Parameters.Add("@Ext", SqlDbType.Int).Value = alumno.NumExt;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = Capitalize(alumno.Colonia);
                comando.Parameters.Add("@CP", SqlDbType.NVarChar, 5).Value = alumno.Cp;
                comando.Parameters.Add("@Mun", SqlDbType.Int).Value = alumno.DelMun;
                comando.Parameters.Add("@Estado", SqlDbType.Int).Value = alumno.Estado;

                comando.Parameters.Add("@Celular", SqlDbType.NVarChar, 15).Value = alumno.Celular;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value = alumno.Telefono;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = alumno.CorreoElectronico;
                comando.Parameters.Add("@Boleta", SqlDbType.NVarChar, 10).Value = Uppercase(alumno.Boleta);
                comando.Parameters.Add("@Grupo", SqlDbType.NVarChar, 5).Value = Uppercase(alumno.Grupo);
                comando.Parameters.Add("@Carrera", SqlDbType.SmallInt).Value = alumno.Carrera;
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = alumno.TipoPaciente;

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

        public string Actualizar(PersonalEscolar pEscolar)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("updActualizarPersonalEscolar", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = pEscolar.IdPaciente;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = Capitalize(pEscolar.NombrePaciente);
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = Capitalize(pEscolar.ApellidosPaciente);
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = pEscolar.GeneroPaciente;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = pEscolar.FechaNac.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = pEscolar.EdadPaciente;
                comando.Parameters.Add("@CURP", SqlDbType.NVarChar, 18).Value = Uppercase(pEscolar.Curp);

                comando.Parameters.Add("@Calle", SqlDbType.NVarChar, 100).Value = Capitalize(pEscolar.Calle);
                comando.Parameters.Add("@Int", SqlDbType.Int).Value = pEscolar.NumInt;
                comando.Parameters.Add("@Ext", SqlDbType.Int).Value = pEscolar.NumExt;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = Capitalize(pEscolar.Colonia);
                comando.Parameters.Add("@CP", SqlDbType.NVarChar, 5).Value = pEscolar.Cp;
                comando.Parameters.Add("@Mun", SqlDbType.Int).Value = pEscolar.DelMun;
                comando.Parameters.Add("@Estado", SqlDbType.Int).Value = pEscolar.Estado;

                comando.Parameters.Add("@Celular", SqlDbType.NVarChar, 15).Value = pEscolar.Celular;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value = pEscolar.Telefono;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = pEscolar.CorreoElectronico;
                comando.Parameters.Add("@NumEmpleado", SqlDbType.NVarChar, 10).Value = Uppercase(pEscolar.NumEmpleado);
                comando.Parameters.Add("@RFC", SqlDbType.NVarChar, 15).Value = Uppercase(pEscolar.Rfc);
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = pEscolar.TipoPaciente;

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

        public string Actualizar(Pacientes externo)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("updActualizarExternos", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = externo.IdPaciente;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = Capitalize(externo.NombrePaciente);
                comando.Parameters.Add("@Apellidos", SqlDbType.NVarChar, 20).Value = Capitalize(externo.ApellidosPaciente);
                comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = externo.GeneroPaciente;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = externo.FechaNac.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@Edad", SqlDbType.SmallInt).Value = externo.EdadPaciente;
                comando.Parameters.Add("@CURP", SqlDbType.NVarChar, 18).Value = Uppercase(externo.Curp);

                comando.Parameters.Add("@Calle", SqlDbType.NVarChar, 100).Value = Capitalize(externo.Calle);
                comando.Parameters.Add("@Int", SqlDbType.Int).Value = externo.NumInt;
                comando.Parameters.Add("@Ext", SqlDbType.Int).Value = externo.NumExt;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = Capitalize(externo.Colonia);
                comando.Parameters.Add("@CP", SqlDbType.NVarChar, 5).Value = externo.Cp;
                comando.Parameters.Add("@Mun", SqlDbType.Int).Value = externo.DelMun;
                comando.Parameters.Add("@Estado", SqlDbType.Int).Value = externo.Estado;

                comando.Parameters.Add("@Celular", SqlDbType.NVarChar, 15).Value = externo.Celular;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value = externo.Telefono;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = externo.CorreoElectronico;
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = externo.TipoPaciente;

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

        public string ActualizarEstatus(Pacientes pac)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("updEliminarRecuperarPaciente", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = pac.IdPaciente;
                comando.Parameters.Add("@Estatus", SqlDbType.SmallInt).Value = pac.EstatusPaciente;
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

        public string Eliminar(int id)
        {
            string mensaje = string.Empty;
            try
            {
                Pacientes paciente = new Pacientes(id);
                comando = new SqlCommand("dltEliminarPaciente", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = paciente.IdPaciente;

                conexion.getCon().Open();
                comando.ExecuteNonQuery();
                mensaje = "Paciente Borrado con Exito";

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

        private string Capitalize(string convertir)
        {
            string textoCapitalizado = string.Empty;
            CultureInfo cul = Thread.CurrentThread.CurrentCulture;
            TextInfo text = cul.TextInfo;
            if (convertir == null)
            {
                textoCapitalizado = null;
            }
            else
            {
                textoCapitalizado = text.ToTitleCase(convertir);
            }
            return textoCapitalizado;
        }

        private string Uppercase(string convertir)
        {
            string mayusculas = string.Empty;
            if (convertir == null)
            {
                mayusculas = null;
            }
            else
            {
                mayusculas = convertir.ToUpper();
            }
            return mayusculas;
        }
    }
}