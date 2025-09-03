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
                datos.setQuery("Select A.Codigo, A.Nombre, A.Descripcion, C.Descripcion AS DescripcionCategoria, M.Descripcion AS DescripcionMarca, A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id AND A.IdMarca = M.Id");
                //Consulta testeada en SQL antes
                datos.ejecutarRead();
                //Gracias al getter del lector puedo hacer este while
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Descripcion = (string)datos.Lector["DescripcionMarca"]; //USA EL NOMBRE QUE LE DI EN LA BDD
                    aux.Categoria = new Categorias();
                    aux.Categoria.Descripcion = (string)datos.Lector["DescripcionCategoria"];
                    //Leo si la imagen NO es nula
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

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
                     articuloAgregado.Categoria.IdCategoria + "', '" +
                     articuloAgregado.Marca.IdMarca + "', '" +
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
