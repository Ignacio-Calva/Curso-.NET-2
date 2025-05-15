using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio //Cada parte de la tabla que necesito recrear en el codigo
{
    public class Articulos
    {
        // PROPIEDADES

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string UrlImagen { get; set; }
        public float Precio { get; set; }

        //METODOS


    }
}
