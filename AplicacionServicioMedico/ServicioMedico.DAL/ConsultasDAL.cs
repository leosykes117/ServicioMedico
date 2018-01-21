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
        private SqlDataAdapter da;

        public ConsultasDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public string Agregar(Consultas objconsulta)
        {
            string mensaje = string.Empty;
            SqlTransaction transaccion = null;
            try
            {
                comando = new SqlCommand("insAgregarConsulta", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Paciente", SqlDbType.Int).Value = objconsulta.CvePaciente;
                comando.Parameters.Add("@Doctor", SqlDbType.Int).Value = objconsulta.CveDoctor;
                comando.Parameters.Add("@Diagnostico", SqlDbType.NVarChar).Value = objconsulta.Diagnostico;
                comando.Parameters.Add("@Observaciones", SqlDbType.NVarChar).Value = objconsulta.Observaciones;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = objconsulta.FechaConsulta.Date.ToString("dd/MM/yyyy");
                comando.Parameters.Add("@HoraEntrada", SqlDbType.Time).Value = objconsulta.HoraEntrada.ToString("HH:mm:ss");
                comando.Parameters.Add("@HoraSalida", SqlDbType.Time).Value = objconsulta.HoraSalida.ToString("HH:mm:ss");
                comando.Parameters.Add("@Temp", SqlDbType.Decimal).Value = objconsulta.Temperatura;
                comando.Parameters.Add("@TA", SqlDbType.NVarChar, 8).Value = objconsulta.TA;
                comando.Parameters.Add("@FC", SqlDbType.Decimal).Value = objconsulta.FC;
                comando.Parameters.Add("@FR", SqlDbType.Decimal).Value = objconsulta.FR;

                SqlParameter pretornado = new SqlParameter("@IdRetornado", SqlDbType.Int);
                pretornado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pretornado);

                conexion.getCon().Open();
                transaccion = conexion.getCon().BeginTransaction();
                comando.Transaction = transaccion;

                comando.ExecuteNonQuery();
                objconsulta.IdConsulta = Convert.ToInt32(comando.Parameters["@IdRetornado"].Value.ToString());

                for (int i = 0; i < objconsulta.MotivosConsultas.Count; i++)
                {
                    comando = new SqlCommand("insMotivoConsulta", conexion.getCon());
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ClaveConsulta", SqlDbType.Int).Value = objconsulta.IdConsulta;
                    comando.Parameters.Add("@ClaveMotivo", SqlDbType.SmallInt).Value = objconsulta.MotivosConsultas[i].IdMotivo;

                    if(conexion.getCon().State == ConnectionState.Closed)
                    {
                        conexion.getCon().Open();
                    }
                    if(transaccion == null)
                    {
                        transaccion = conexion.getCon().BeginTransaction();
                    }
                    comando.Transaction = transaccion;
                    //EJECUTAMOS LA SENTENCIA SQL
                    comando.ExecuteNonQuery();
                }

                for(int i = 0; i < objconsulta.MedicamentosConsultas.Count; i++)
                {
                    comando = new SqlCommand("insMedicamentoConsulta", conexion.getCon());
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ClaveConsulta", SqlDbType.Int).Value = objconsulta.IdConsulta;
                    comando.Parameters.Add("@Medicamento", SqlDbType.NVarChar, 100).Value = objconsulta.MedicamentosConsultas[i].NombreMedicamento;
                    comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = objconsulta.MedicamentosConsultas[i].CantidadSuministrada;
                    comando.Parameters.Add("@Prescripcion", SqlDbType.NVarChar, 100).Value = objconsulta.MedicamentosConsultas[i].PrescripcionMedica;

                    if (conexion.getCon().State == ConnectionState.Closed)
                    {
                        conexion.getCon().Open();
                    }
                    if (transaccion == null)
                    {
                        transaccion = conexion.getCon().BeginTransaction();
                    }
                    comando.Transaction = transaccion;
                    //EJECUTAMOS LA SENTENCIA SQL
                    comando.ExecuteNonQuery();
                }
                transaccion.Commit();
                mensaje = "La Consulta se Registro Correctamente";
            }
            catch (Exception  ex)
            {
                transaccion.Rollback();
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
            DataTable tablaConsultas;
            try
            {
                comando = new SqlCommand("selBusquedaConsultas", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = tipo;
                comando.Parameters.Add("@Estatus", SqlDbType.SmallInt).Value = estatus;
                tablaConsultas = new DataTable();
                conexion.getCon().Open();
                da = new SqlDataAdapter(comando);
                da.Fill(tablaConsultas);
            }
            catch (Exception)
            {
                tablaConsultas = new DataTable();
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return tablaConsultas;
        }

        public string Actualizar(Consultas objconsulta)
        {
            string mensaje = string.Empty;
            try
            {
                comando = new SqlCommand("updActualizarConsulta", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Consulta", SqlDbType.Int).Value = objconsulta.IdConsulta;
                comando.Parameters.Add("@Diagnostico", SqlDbType.NVarChar).Value = objconsulta.Diagnostico;
                comando.Parameters.Add("@Observaciones", SqlDbType.NVarChar).Value = objconsulta.Observaciones;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = objconsulta.FechaConsulta.Date.ToString("yyyy-MM-dd");
                comando.Parameters.Add("@HoraEntrada", SqlDbType.Time).Value = objconsulta.HoraEntrada.ToString("HH:mm:ss");
                comando.Parameters.Add("@HoraSalida", SqlDbType.Time).Value = objconsulta.HoraSalida.ToString("HH:mm:ss");
                comando.Parameters.Add("@Temp", SqlDbType.Decimal).Value = objconsulta.Temperatura;
                comando.Parameters.Add("@TA", SqlDbType.NVarChar).Value = objconsulta.TA;
                comando.Parameters.Add("@FC", SqlDbType.Decimal).Value = objconsulta.FC;
                comando.Parameters.Add("@FR", SqlDbType.Decimal).Value = objconsulta.FR;

                conexion.getCon().Open();
                comando.ExecuteNonQuery();
                mensaje = "Consulta Actualizada con Exito";
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

        public string Eliminar(int id)
        {
            string mensaje = string.Empty;
            try
            {
                Consultas consulta = new Consultas(id);
                comando = new SqlCommand("dltEliminarConsulta", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Consulta", SqlDbType.Int).Value = consulta.IdConsulta;
                conexion.getCon().Open();
                comando.ExecuteNonQuery();
                mensaje = "Eliminada";
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

        public string ActualizarEstatus(int claveConsulta, short estatusCon)
        {
            string mensaje = string.Empty;
            try
            {
                Consultas consulta = new Consultas(claveConsulta, estatusCon);
                comando = new SqlCommand("updEliminarConsulta", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Consulta", SqlDbType.Int).Value = consulta.IdConsulta;
                comando.Parameters.Add("@Estatus", SqlDbType.SmallInt).Value = consulta.EstatusConsulta;

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 200);
                pmensaje.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pmensaje);

                conexion.getCon().Open();
                comando.ExecuteNonQuery();

                mensaje = comando.Parameters["@Mensaje"].Value.ToString();
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

        public List<Consultas> AntecedentesClinicos(int clave)
        {
            List<Consultas> historiaClinica;
            try
            {
                historiaClinica = new List<Consultas>();
                comando = new SqlCommand("selHistoriaClinica", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@CvePaciente", SqlDbType.Int).Value = clave;
                conexion.getCon().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Consultas consultaMedica = new Consultas();
                    consultaMedica.IdConsulta = Convert.ToInt32(lector[0]);
                    consultaMedica.FechaConsulta = Convert.ToDateTime(lector[1]).Date;
                    consultaMedica.Diagnostico = lector[2].ToString();
                    consultaMedica.Observaciones = lector[3].ToString();
                    consultaMedica.NomDoc = lector[4].ToString();
                    historiaClinica.Add(consultaMedica);
                }

            }
            catch (Exception)
            {
                historiaClinica = new List<Consultas>();
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return historiaClinica;
        }
    }
}
