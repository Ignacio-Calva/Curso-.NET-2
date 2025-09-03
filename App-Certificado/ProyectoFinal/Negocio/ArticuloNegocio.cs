using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> listarArticulos()
        {
            List<Articulos> listaArticulos = new List<Articulos>();
            //CREO EL OBJETO PARA LOS DATOS
            AccesoDatos datos = new AccesoDatos(); //Al instanciarlo crea la conexion

            try
            {
                datos.setQuery("SELECT * From ARTICULOS");
                datos.ejecutarRead();
                //Gracias al getter del lector puedo hacer este while
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    //Leo si la imagen NO es nula
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    else aux.UrlImagen = "Nulo";

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    listaArticulos.Add(aux);
                }

                return listaArticulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregarArticulo(Articulos articuloAgregado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES " +
                    "('" + articuloAgregado.Codigo + "', '" +
                     articuloAgregado.Nombre + "', '" +
                     articuloAgregado.Descripcion + "', '" +
                     articuloAgregado.IdCategoria + "', '" +
                     articuloAgregado.IdMarca + "', '" +
                     "PRUEBA" + "', '" +
                     "10')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }

    
}
