using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace ServicioMedico
{
    public class Usuarios
    {
        private int idUsuario, rol;
        private string usuario, contraseña, correoElectronico;

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        public int Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public Usuarios() { }//CONSTRUCTOR VACIO

        public Usuarios(int id, string usu, string contra, string mail, int r)
        {
            idUsuario = id;
            usuario = usu;
            contraseña = contra;
            correoElectronico = mail;
            rol = r;
        }//CONTRUCTOR PARA INSERTAR

        public Usuarios(string usu, string contra)//CONTRUCTOR PARA LOGIN
        {
            usuario = usu;
            contraseña = contra;
        }

        public Usuarios(int id)
        {
            idUsuario = id;
        }

        public Usuarios(int id, string password)//CONTRUCTOR PARA CAMBIAR CONTRASEÑA
        {
            idUsuario = id;
            contraseña = password;
        }

        public int AgregarUsuario(string doc)
        {
            int respuesta = 0;
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand insertar = new SqlCommand("insNuevoUsuario", conexion);
            try
            {
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@ID", SqlDbType.Int).Value = IdUsuario;
                insertar.Parameters.Add("@Usuario", SqlDbType.NVarChar, 15).Value = Usuario;
                insertar.Parameters.Add("@Contraseña", SqlDbType.NVarChar, 15).Value = Contraseña;
                insertar.Parameters.Add("@Correo", SqlDbType.NVarChar, 70).Value = CorreoElectronico;
                insertar.Parameters.Add("@Rol", SqlDbType.Int).Value = Rol;

                SqlParameter pcontador = new SqlParameter("@Contador", SqlDbType.Int);
                pcontador.Direction = ParameterDirection.Output;
                insertar.Parameters.Add(pcontador);

                insertar.ExecuteNonQuery();
                int contador = Convert.ToInt32(insertar.Parameters["@Contador"].Value.ToString());
                if (contador == 1)
                {
                    if (EnviarCorreo(doc, "Bienvenido a la Aplicación") == 1)
                    {
                        respuesta = 1;
                    }
                    else
                    {
                        respuesta = 3;
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

        public string IniciarSesion()
        {
            string respuesta = string.Empty;
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand login = new SqlCommand("selIniciarSesion", conexion);
            try
            {
                login.CommandType = CommandType.StoredProcedure;
                login.Parameters.Add("@Usuario", SqlDbType.NVarChar, 15).Value = Usuario;
                login.Parameters.Add("@Contraseña", SqlDbType.NVarChar, 15).Value = Contraseña;

                SqlParameter pclave = new SqlParameter("@IdRetornado", SqlDbType.Int);
                pclave.Direction = ParameterDirection.Output;
                login.Parameters.Add(pclave);

                SqlParameter pmensajerol = new SqlParameter("@MensajeRol", SqlDbType.SmallInt);
                pmensajerol.Direction = ParameterDirection.Output;
                login.Parameters.Add(pmensajerol);

                SqlParameter pmensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 90);
                pmensaje.Direction = ParameterDirection.Output;
                login.Parameters.Add(pmensaje);

                login.ExecuteNonQuery();

                idUsuario = Convert.ToInt32(login.Parameters["@IdRetornado"].Value.ToString());

                if (idUsuario > 0)
                {
                    Rol = Convert.ToInt32(login.Parameters["@MensajeRol"].Value.ToString());
                    respuesta = login.Parameters["@Mensaje"].Value.ToString();
                }
                else
                {
                    respuesta = "0";
                }
            }
            catch (SqlException ex)
            {
                respuesta = ex.ToString();
            }
            conexion.Close();
            return respuesta;
        }

        /*public int BuscarDoctor()
        {
            int respuesta = 0;
            DataTable tb = new DataTable();
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand busqueda = new SqlCommand("selDocById", conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                busqueda.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(busqueda);
                busqueda.Parameters.Add("@ID", SqlDbType.Int).Value = IdUsuario;
                da.Fill(ds, "Fila");
                tb = ds.Tables["fila"];
                Doctores doc = new Doctores();
                doc.NombreDoctor = tb.Rows[0]["Nombre"].ToString();
                usuario = tb.Rows[0]["Usuario"].ToString();
                correoElectronico = tb.Rows[0]["Correo"].ToString();
                if(usuario != string.Empty)
                {
                    respuesta = 1;
                }
                else
                {
                    respuesta = 0;
                }
            }
            catch (SqlException)
            {
                conexion.Close();
                respuesta = 2;
            }
            conexion.Close();
            return respuesta;
        }*/

        public int CambiarContraseña(string nueva)
        {
            int respuesta = 0;
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand modificar = new SqlCommand("updCambioContraseña", conexion);
            try
            {
                modificar.CommandType = CommandType.StoredProcedure;
                modificar.Parameters.Add("@ID", SqlDbType.Int).Value = idUsuario;
                modificar.Parameters.Add("@Actual", SqlDbType.NVarChar, 15).Value = Contraseña;
                modificar.Parameters.Add("@Nueva", SqlDbType.NVarChar, 15).Value = nueva;

                SqlParameter pcorreo = new SqlParameter("@Correo",SqlDbType.NVarChar,70);
                pcorreo.Direction = ParameterDirection.Output;
                modificar.Parameters.Add(pcorreo);

                SqlParameter pnombre = new SqlParameter("@Nombre",SqlDbType.NVarChar,50);
                pnombre.Direction = ParameterDirection.Output;
                modificar.Parameters.Add(pnombre);
                modificar.ExecuteNonQuery();
                correoElectronico = modificar.Parameters["@Correo"].Value.ToString();
                string nombre = modificar.Parameters["@Nombre"].Value.ToString();
                if(CorreoElectronico == "No se pudo")
                {
                    respuesta = 0;
                }
                else if (CorreoElectronico == "Repetida")
                {
                    respuesta = 3;
                }
                else
                {
                    string doc = Utilerias.CambioPasswordHTML(nombre);
                    if (EnviarCorreo(doc, "Modificacion de la contraseña") == 1)
                    {
                        respuesta = 1;
                    }
                    else
                    {
                        respuesta = 2;
                    }
                }
            }
            catch(SqlException)
            {
                respuesta = 4;
            }
            conexion.Close();
            return respuesta;
        }

        public static DataTable TraerNuevosUsuarios()
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand busqueda = new SqlCommand("selTablaNuevosUsuarios", conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                busqueda.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(busqueda);
                da.Fill(ds, "Fila");
            }
            catch (SqlException)
            {

            }
            conexion.Close();
            return ds.Tables["Fila"];
        }//FIN DE METODO BUSCA GENERAL

        public static DataTable TraerRegistrosContraseñas(int clave)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand busqueda = new SqlCommand("selTablaCambiosContraseñas", conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                busqueda.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(busqueda);
                busqueda.Parameters.Add("@ID", SqlDbType.Int).Value = clave;
                da.Fill(ds, "Fila");
            }
            catch (SqlException)
            {

            }
            conexion.Close();
            return ds.Tables["Fila"];
        }

        private int EnviarCorreo(string documento, string asunto)
        {
            int enviado = 0;
            try
            {
                MailMessage mensaje = new MailMessage();
                SmtpClient micorreo = new SmtpClient();
                mensaje.To.Add(CorreoElectronico);
                mensaje.From = new MailAddress("servi.medicoCecyt13@hotmail.com", "Servicio Medico", Encoding.UTF8);
                mensaje.Subject = asunto;
                mensaje.SubjectEncoding = Encoding.UTF8;
                mensaje.Body = documento;
                mensaje.IsBodyHtml = true;
                mensaje.BodyEncoding = Encoding.UTF8;
                micorreo.Credentials = new NetworkCredential("servi.medicoCecyt13@hotmail.com", "SismiCecyt13");
                micorreo.Port = 587;
                micorreo.Host = "smtp.live.com";
                micorreo.EnableSsl = true;
                micorreo.Send(mensaje);
                enviado = 1;
            }
            catch (SmtpException)
            {
                enviado = 2;
            }
            return enviado;
        }
    }
}
