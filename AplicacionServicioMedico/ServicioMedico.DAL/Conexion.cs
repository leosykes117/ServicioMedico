using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ServicioMedico.DAL
{
    public class Conexion
    {
        private static Conexion objConexion = null;
        private SqlConnection con;

        private Conexion()
        {
            con = new SqlConnection(@"Data Source=.;Initial Catalog=ServicioMedicoTest;Integrated Security=True");
        }

        public static Conexion saberEstado()
        {
            if(objConexion == null)
            {
                objConexion = new Conexion();
            }
            return objConexion;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void cerrarConexion()
        {
            objConexion = null;
        }
    }
}
