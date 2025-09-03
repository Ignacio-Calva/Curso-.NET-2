using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Marcas> listarMarcas()
        {
            List<Marcas> listaMarcas = new List<Marcas>();
            try
            {
                datos.setQuery("Select Id, Descripcion from MARCAS");
                datos.ejecutarRead();
                while (datos.Lector.Read())
                {
                    Marcas auxiliar = new Marcas();
                    auxiliar.IdMarca = (int)datos.Lector["Id"];
                    auxiliar.Descripcion = (string)datos.Lector["Descripcion"];
                    listaMarcas.Add(auxiliar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaMarcas;
        }
    }
}
