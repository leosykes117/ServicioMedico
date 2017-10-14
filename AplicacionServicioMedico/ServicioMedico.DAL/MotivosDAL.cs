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
    public class MotivosDAL
    {
        private Conexion conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public MotivosDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public List<Motivos> TodosLosMotivos()
        {
            List<Motivos> all;
            try
            {
                all = new List<Motivos>();
                comando = new SqlCommand("selListadoMotivos", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                conexion.getCon().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Motivos motivo = new Motivos();
                    motivo.IdMotivo = Convert.ToInt16(lector[0]);
                    motivo.DescripcionMotivo = lector[1].ToString();
                    all.Add(motivo);
                }
            }
            catch (Exception)
            {
                all = new List<Motivos>();
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return all;
        }

        public List<Motivos> MotivosPorConsuta(int claveConsulta)
        {
            List<Motivos> listadomotivos;
            try
            {
                listadomotivos = new List<Motivos>();
                comando = new SqlCommand("selHistoriaMotivos", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Consulta", SqlDbType.Int).Value = claveConsulta;
                conexion.getCon().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Motivos mot = new Motivos();
                    mot.IdMotivo = Convert.ToInt16(lector[0]);
                    mot.DescripcionMotivo = lector[1].ToString();
                    listadomotivos.Add(mot);
                }
            }
            catch (Exception)
            {
                listadomotivos = new List<Motivos>();
            }
            finally
            {
                conexion.getCon().Close();
                conexion.cerrarConexion();
            }
            return listadomotivos;
        }
    }
}
