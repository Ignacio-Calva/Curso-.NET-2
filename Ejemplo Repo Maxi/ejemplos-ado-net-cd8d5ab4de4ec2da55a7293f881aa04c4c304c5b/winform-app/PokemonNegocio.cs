using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace winform_app
{
    class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, Descripcion From POKEMONS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<string> listarNombre()
        {
            List<string> lista = new List<string>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Nombre From POKEMONS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    string aux = (string)lector["Nombre"];
                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void sacarPokemon(string pokemonElegido)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "DELETE from POKEMONS where Nombre = '" + pokemonElegido + "'";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                conexion.Close();
                return;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void agregarPokemon(Pokemon pokemonAgregado) 
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                string stringComando;
                stringComando = "INSERT INTO POKEMONS (Numero, Nombre, Descripcion, UrlImagen, IdTipo, IdDebilidad, Activo) VALUES (";
                //PARA NUMERO
                stringComando += pokemonAgregado.Numero.ToString() + ", ";
                //PARA NOMBRE
                stringComando += "'" + pokemonAgregado.Nombre + "', ";
                //PARA DESCRIPCION
                stringComando += "'" + pokemonAgregado.Descripcion + "', ";
                //PARA IMAGEN
                stringComando += "' DEFAULT', ";
                //PARA IDTIPO
                stringComando +=  "1, ";
                //PARA IDDEBILIDAD
                stringComando += "2, ";
                //PARA ACTIVO
                stringComando += "1);";
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = stringComando;
                conexion.Open();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();
                conexion.Close();
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error.");
                throw;
            }

        }

    }
}
