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
    public class ConsultoriosDAL
    {
        private Conexion conexion;
        private SqlCommand comando;
        SqlDataReader dr;

        public ConsultoriosDAL()
        {
            conexion = Conexion.saberEstado();
        }

        public List<Consultorios> ListadoRegistro()
        {
            List<Consultorios> all;
            try
            {
                comando = new SqlCommand("selListadoConsultorios", conexion.getCon());
                comando.CommandType = CommandType.StoredProcedure;
                conexion.getCon().Open();
                dr = comando.ExecuteReader();
                if (dr.HasRows)
                {
                    all = new List<Consultorios>();
                    while (dr.Read())
                    {
                        Consultorios consultorio = new Consultorios();
                        consultorio.IdConsultorio = dr.GetInt16(0);
                        consultorio.NombreConsultorio = dr.GetString(1);
                        all.Add(consultorio);
                    }
                }
                else
                {
                    all = null;
                }
            }
            catch (Exception ex)
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
    }
}
