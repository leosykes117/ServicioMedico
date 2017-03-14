using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ServicioMedico
{
    class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection nuevaconexion = new SqlConnection(@"Data Source=.;Initial Catalog=ServicioMedico;Integrated Security=True");
            nuevaconexion.Open();
            return nuevaconexion;
        }
    }
}
