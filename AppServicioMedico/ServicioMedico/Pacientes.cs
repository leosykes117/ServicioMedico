using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ServicioMedico
{
    public class Pacientes
    {
        private Int64 idPaciente;
        private string boleta, nombrePaciente, generoPaciente, carrera, grupo;

        public Int64 IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public string Boleta
        {
            get { return boleta; }
            set { boleta = value; }
        }

        public string NombrePaciente
        {
            get { return nombrePaciente; }
            set { nombrePaciente = value; }
        }

        public string GeneroPaciente
        {
            get { return generoPaciente; }
            set { generoPaciente = value; }
        }

        public string Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }

        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        //CONTRUCTORES
        public Pacientes() { }//CONTRUCTOR VACIO

        public Pacientes(string id, string nom, string gnr, string carr, string grp)//CONTRUCTOR PARA AGREGAR ALUMNO
        {
            boleta = id;
            nombrePaciente = nom;
            generoPaciente = gnr;
            carrera = carr;
            grupo = grp;
        }

        public Pacientes(string nom, string gnr)//AGREGAR OCENTE, PAAE O EXTERNO
        {
            nombrePaciente = nom;
            generoPaciente = gnr;
        }

        //METODOS
        public int AgregarPaciente()
        {
            int respuesta = 0;
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand insertar = new SqlCommand("insAgregarAlumno", conexion);
            try
            {
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@Boleta", SqlDbType.NVarChar,10).Value = Boleta;
                insertar.Parameters.Add("@Nombre", SqlDbType.NVarChar,50).Value = NombrePaciente;
                insertar.Parameters.Add("@Sexo", SqlDbType.NVarChar, 9).Value = GeneroPaciente;
                insertar.Parameters.Add("@Carrera", SqlDbType.NVarChar, 50).Value = Carrera;
                insertar.Parameters.Add("@Grupo", SqlDbType.NVarChar, 5).Value = Grupo;

                SqlParameter pretornado = new SqlParameter("@Retornado", SqlDbType.BigInt);
                pretornado.Direction = ParameterDirection.Output;
                insertar.Parameters.Add(pretornado);

                if(insertar.ExecuteNonQuery() > 0)
                {
                    idPaciente = Convert.ToInt64(insertar.Parameters["@Retornado"].Value.ToString());
                    respuesta = 1;
                }
                else
                {
                    respuesta = 0;
                }
            }
            catch(SqlException)
            {
                respuesta = 2;
            }
            conexion.Close();
            return respuesta;
        }

        public int AgregarPaciente(int tipo)
        {
            int respuesta = 0;
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand insertar = new SqlCommand("insAgregarPacientes", conexion);
            try
            {
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@Tipo", SqlDbType.Int).Value = tipo;
                insertar.Parameters.Add("@Nombre", SqlDbType.NVarChar, 60).Value = NombrePaciente;
                insertar.Parameters.Add("@Genero", SqlDbType.NVarChar, 9).Value = generoPaciente;

                SqlParameter pretornado = new SqlParameter("@Retornado", SqlDbType.BigInt);
                pretornado.Direction = ParameterDirection.Output;
                insertar.Parameters.Add(pretornado);

                if(insertar.ExecuteNonQuery() > 0)
                {
                    idPaciente = Convert.ToInt64(insertar.Parameters["@Retornado"].Value.ToString());
                    respuesta = 1;
                }
                else
                {
                    respuesta = 0;
                }
            }
            catch (SqlException)
            {
                respuesta = 2;
            }
            conexion.Close();
            return respuesta;
        }

        public static DataTable TraerPacientes(int tipo)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand busqueda = new SqlCommand("selGenPacientes", conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                busqueda.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(busqueda);
                busqueda.Parameters.Add("@Tipo", SqlDbType.Int).Value = tipo;
                da.Fill(ds, "Fila");
            }
            catch (SqlException)
            {

            }
            conexion.Close();
            return ds.Tables["Fila"];
        }

        public static DataTable TraerPacientes(int tipo, string dato)//METODO PARA TRAER A UN PACIENTE CUANDO SE EJECUTE EL TEXTCHANGED
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand busqueda = new SqlCommand("selBusGenNomBol", conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                busqueda.CommandType = CommandType.StoredProcedure;
                busqueda.Parameters.Add("@TipoPaciente", SqlDbType.Int).Value = tipo;
                busqueda.Parameters.Add("@NombreBoleta", SqlDbType.NVarChar, 50).Value = dato;
                da = new SqlDataAdapter(busqueda);
                da.Fill(ds, "Fila");
            }
            catch (SqlException)
            {

            }
            conexion.Close();
            return ds.Tables["Fila"];
        }
    }
}