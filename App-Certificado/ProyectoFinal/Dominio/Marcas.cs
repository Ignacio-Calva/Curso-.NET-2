using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marcas
    { 
        //PROPIEDADES
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }

        //OVERRIDE DEL TO STRING PARA QUE SE MUESTRE EN LA GRILLA
        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
