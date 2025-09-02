using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categorias> listarCategorias()
        {
            List<Categorias> listaCategorias= new List<Categorias>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //Para setear la consulta:
                datos.setQuery("Select Id, Descripcion from CATEGORIAS");
                //Ejecuto la lectura
                datos.ejecutarRead();
                //Reviso dato por dato para agregarlo a la lista
                while (datos.Lector.Read())
                {
                    //Creo un objeto para cargar cada categoria
                    Categorias auxiliar = new Categorias();
                    //Cargo las id y descripcion casteando cada tipo de dato
                    auxiliar.IdCategoria = (int)datos.Lector["Id"];
                    auxiliar.Descripcion = (string)datos.Lector["Descripcion"];
                    //Añado el objeto cargado a la lista
                    listaCategorias.Add(auxiliar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaCategorias;
        }
    }
}
