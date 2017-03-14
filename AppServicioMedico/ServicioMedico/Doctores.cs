using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ServicioMedico
{
    public class Doctores
    {
        private int idDoctor, vistaReporte;
        private string nombreDoctor, generoDoctor, consultorio;

        public string NombreDoctor
        {
            get { return nombreDoctor; }
            set { nombreDoctor = value; }
        }

        public string GeneroDoctor
        {
            get { return generoDoctor; }
            set { generoDoctor = value; }
        }

        public string Consultorio
        {
            get { return consultorio; }
            set { consultorio = value; }
        }

        public int IdDoctor
        {
            get { return idDoctor; }
            set { idDoctor = value; }
        }

        public int VistaReporte
        {
            get { return vistaReporte; }
            set { vistaReporte = value; }
        }

        public Doctores() { }//CONSTRUTOR VACIO

        public Doctores(string nombre, string gnr, string cons)//CONTRUCTOR PARA AGREGAR DOCTOR
        {
            nombreDoctor = nombre;
            generoDoctor = gnr;
            consultorio = cons;
        }

        public int AgregarDoctor(string user, string contraseña, string mail, int rol)
        {
            int respuesta = 0;
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand insertar = new SqlCommand("insNuevoDoctor",conexion);
            try
            {
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = NombreDoctor;
                insertar.Parameters.Add("@Genero",SqlDbType.NVarChar, 9).Value = GeneroDoctor;
                insertar.Parameters.Add("@Consultorio", SqlDbType.NVarChar, 30).Value = Consultorio;
                insertar.Parameters.Add("@Vista", SqlDbType.SmallInt).Value = 0;

                SqlParameter pclave = new SqlParameter("@IdRetornado", SqlDbType.Int);
                pclave.Direction = ParameterDirection.Output;
                insertar.Parameters.Add(pclave);

                insertar.ExecuteNonQuery();

                idDoctor = Convert.ToInt32(insertar.Parameters["@IdRetornado"].Value.ToString());
                if(idDoctor > 0)
                {
                    string documento = Utilerias.BienvenidaHTML(NombreDoctor, user, idDoctor.ToString(), contraseña);
                    if (documento == "No se realizo")
                    {
                        respuesta = 0;
                    }
                    else
                    {
                        Usuarios usuario = new Usuarios(idDoctor, user, contraseña, mail, rol);
                        int creado = usuario.AgregarUsuario(documento);
                        if (creado == 1)
                        {
                            respuesta = 1;
                        }
                        else if(creado == 3)
                        {
                            respuesta = 3;
                        }

                        else
                        {
                            respuesta = 0;
                        }
                    }
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
    }
}