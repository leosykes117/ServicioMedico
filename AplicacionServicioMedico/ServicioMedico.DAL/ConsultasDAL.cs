using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ServicioMedico.BO;
using System.Globalization;

namespace ServicioMedico.DAL
{
    public class ConsultasDAL
    {
        private Conexion conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private DataSet ds;
        private SqlDataAdapter da;

        public ConsultasDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public string AgregarConsulta(Consultas objconsulta)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("insAgregarConsulta", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Paciente", SqlDbType.Int).Value = objconsulta.CvePaciente;
                comando.Parameters.Add("@Doctor", SqlDbType.NVarChar, 50).Value = objconsulta.CveDoctor;
                comando.Parameters.Add("@Diagnostico", SqlDbType.NVarChar).Value = objconsulta.Diagnostico;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = objconsulta.FechaConsulta.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@HoraEntrada", SqlDbType.Time).Value = objconsulta.HoraEntrada.ToString("HH:mm:ss");
                comando.Parameters.Add("@HoraSalida", SqlDbType.Time).Value = objconsulta.HoraSalida.ToString("HH:mm:ss");
                comando.Parameters.Add("@Motivo", SqlDbType.SmallInt).Value = objconsulta.MotivoConsulta;
                comando.Parameters.Add("@Medicamento", SqlDbType.Int).Value = objconsulta.CveMedicamento;
                comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = objconsulta.CantidadSumintrada;

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 200);
                pmensaje.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pmensaje);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();
                mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }
            catch (Exception  ex)
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

        public DataTable GeneralConsultas(short tipo, short estatus)
        {
            try
            {
                comando = new SqlCommand("selBusquedaConsultas", conexion.getCon());
                ds = new DataSet();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = tipo;
                comando.Parameters.Add("@Estatus", SqlDbType.SmallInt).Value = estatus;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(ds, "Consultas");
            }
            catch (Exception)
            {
                ds = new DataSet();
                da = new SqlDataAdapter(comando);
                da.Fill(ds, "Consultas");
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return ds.Tables["Consultas"];
        }

        public string ActualizarConsulta(Consultas objconsulta)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("updActualizarConsulta", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Paciente", SqlDbType.Int).Value = objconsulta.CvePaciente;
                comando.Parameters.Add("@Diagnostico", SqlDbType.NVarChar).Value = objconsulta.Diagnostico;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = objconsulta.FechaConsulta.Date.ToString("yyyy-MM-dd");
                comando.Parameters.Add("@HoraEntrada", SqlDbType.Time).Value = objconsulta.HoraEntrada.ToString("HH:mm:ss");
                comando.Parameters.Add("@HoraSalida", SqlDbType.Time).Value = objconsulta.HoraSalida.ToString("HH:mm:ss");
                comando.Parameters.Add("@Motivo", SqlDbType.SmallInt).Value = objconsulta.MotivoConsulta;
                comando.Parameters.Add("@Medicamento", SqlDbType.Int).Value = objconsulta.CveMedicamento;
                comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = objconsulta.CantidadSumintrada;

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 200);
                pmensaje.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pmensaje);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();
                mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }
            catch(Exception ex)
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

        public List<Consultas> AntecedentesClinicos(int clave)
        {
            List<Consultas> historiaClinica = new List<Consultas>();
            try
            {
                comando = new SqlCommand("selHistoriaClinica", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@CvePaciente", SqlDbType.Int).Value = clave;
                conexion.getCon().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Consultas consultaMedica = new Consultas();
                    consultaMedica.FechaConsulta = Convert.ToDateTime(lector[0]).Date;
                    consultaMedica.NombreMotivo = lector[1].ToString();
                    consultaMedica.Diagnostico = lector[2].ToString();
                    consultaMedica.NombreMedicamento = lector[3].ToString();
                    consultaMedica.CveDoctor = lector[4].ToString();
                    historiaClinica.Add(consultaMedica);
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
            return historiaClinica;
        }

        public DataTable ListadoMotivos()
        {
            try
            {
                comando = new SqlCommand("selListadoMotivos", conexion.getCon());
                ds = new DataSet();
                comando.CommandType = CommandType.StoredProcedure;
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(ds, "Motivos");
            }
            catch (Exception)
            {
                ds = null;
                da.Fill(ds);
            }

            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return ds.Tables["Motivos"];
        }

    }
}
