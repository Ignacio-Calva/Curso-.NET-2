using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio //Toda la informacion que necesito manipular desde la BDD
{
    public class AccesoDatos
    {
        //DECLARO EN PRIVATE LOS 3 ATRIBUTOS DE LA CONEXION
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //EL LECTOR ES PRIVADO Asi que tengo que crear una propiedad publica tipo getter para poder leerlo desde afuera
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=. \\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setQuery(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
        }

        //ejecutarRead se utiliza para leer informacion
        public void ejecutarRead()
        {
            //Establezco la conexion para el comando
            comando.Connection = conexion;
            try
            {
                //Abro la conexion y cargo la lectura en el objeto lector
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //ejecutarAccion se utiliza para 
        public void ejecutarAccion()
        {
            comando.Connection = conexion; 
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery(); //Ejecuta la sentencia sin necesariamente cargarla en un lector
                cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            //PRIMERO Reviso el lector, porque hay que cerrarlo tambien
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
