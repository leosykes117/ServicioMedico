using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ServicioMedico
{
    public class Consultas
    {
        private Doctores doctor = new Doctores();
        private Pacientes paciente = new Pacientes();
        private string tratamiento;
        private DateTime fecha = new DateTime();
        private int numHeridas, numCeI, mes, año, masAlum, femAlum, masDoc, femDoc, masPae, femPae, masExt, femExt, subtotalh, subtotalm;

        public Pacientes Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        public Doctores Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public string Tratamiento
        {
            get { return tratamiento; }
            set { tratamiento = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        
        public int NumHeridas
        {
            get { return numHeridas; }
            set { numHeridas = value; }
        }

        public int NumCeI
        {
            get { return numCeI; }
            set { numCeI = value; }
        }

        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        public int Año
        {
            get { return año; }
            set { año = value; }
        }

        public int MasAlum
        {
            get { return masAlum; }
            set { masAlum = value; }
        }

        public int FemAlum
        {
            get { return femAlum; }
            set { femAlum = value; }
        }

        public int MasDoc
        {
            get { return masDoc; }
            set { masDoc = value; }
        }

        public int FemDoc
        {
            get { return femDoc; }
            set { femDoc = value; }
        }

        public int MasPae
        {
            get { return masPae; }
            set { masPae = value; }
        }

        public int FemPae
        {
            get { return femPae; }
            set { femPae = value; }
        }

        public int MasExt
        {
            get { return masExt; }
            set { masExt = value; }
        }

        public int FemExt
        {
            get { return femExt; }
            set { femExt = value; }
        }

        public int Subtotalh
        {
            get { return subtotalh; }
            set { subtotalh = value; }
        }

        public int Subtotalm
        {
            get { return subtotalm; }
            set { subtotalm = value; }
        }

        //CONTRUCTORES
        public Consultas() { }

        public Consultas(int cd, Int64 cp, DateTime fch, int nh, int nc, string trat)
        {
            doctor.IdDoctor = cd;
            paciente.IdPaciente = cp;
            fecha = fch;
            numHeridas = nh;
            numCeI = nc;
            tratamiento = trat;
        }

        public Consultas(int m, int y, int cve)
        {
            mes = m; año = y; doctor.IdDoctor = cve;
        }

        public int AgregarConsulta(int tipo)
        {
            int respuesta = 0;
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand insertar = new SqlCommand("insCrearConsulta", conexion);
            try
            {
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@Tipo", SqlDbType.Int).Value = tipo;
                insertar.Parameters.Add("@CVEPaciente", SqlDbType.BigInt).Value = Paciente.IdPaciente;
                insertar.Parameters.Add("@CVEDoctor", SqlDbType.Int).Value = Doctor.IdDoctor;
                insertar.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha.Date;
                insertar.Parameters.Add("@Heridas", SqlDbType.Int).Value = NumHeridas;
                insertar.Parameters.Add("@CeI", SqlDbType.Int).Value = NumCeI;
                insertar.Parameters.Add("@Tratamiento", SqlDbType.NVarChar).Value = Tratamiento;

               if (insertar.ExecuteNonQuery() > 0)//DECISON PARA SABER SI SE GUARDO EL USUARIO EN LA BD
                {   //SI SE CREO QUE DEVUELVA TRUE Y EJECUTE LOS METODOS CREAR ARCHIVO Y ENVIAR CORREO
                    respuesta = 1;
                }
                else
                {   //RETORNA FALSE SI NO SE CREO EL USUARIO
                    respuesta = 0;
                }
            }
            catch (SqlException)
            {
                respuesta = 2;
            }
            conexion.Close();//CIERRO LA CONEXION
            return respuesta;
        }//FIN DE METODO CREAR CONSULTA

        public static DataTable ConsultasPorMes(int tipo, int clave, int mes)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand busqueda = new SqlCommand("selBusquedaConsultas", conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                busqueda.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(busqueda);
                busqueda.Parameters.Add("@TipoPaciente", SqlDbType.Int).Value = tipo;
                busqueda.Parameters.Add("@Cve", SqlDbType.Int).Value = clave;
                busqueda.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;
                da.Fill(ds, "Fila");
            }
            catch (SqlException)
            {

            }
            conexion.Close();
            return ds.Tables["Fila"];
        }

        public static DataTable ConsultasPorMes(int tipo, int clave, int mes, string dato)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand busqueda = new SqlCommand("selConsultasByDato", conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                busqueda.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(busqueda);
                busqueda.Parameters.Add("@TipoPaciente", SqlDbType.Int).Value = tipo;
                busqueda.Parameters.Add("@Cve", SqlDbType.Int).Value = clave;
                busqueda.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;
                busqueda.Parameters.Add("@Dato", SqlDbType.NVarChar, 70).Value = dato;
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
