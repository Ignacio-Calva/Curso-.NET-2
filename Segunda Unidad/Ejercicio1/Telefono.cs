using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Telefono
    {
        public string Modelo { get; }
        public string Marca { get; }
        public string NumeroTelefonico { get; set; }
        //public int CodigoOperador { get; set; } //TIENE QUE VALIDAR
        private int codigoOperador;
        public int CodigoOperador
        {
            set 
            {
                if (value < 1 || value > 3)
                {
                    codigoOperador = 0;
                }
                else codigoOperador = value;
            }
            get { return codigoOperador; }
        }
        public Telefono (string modelo, string marca)
        {
            Modelo = modelo;
            Marca = marca;
        }
        
        public Telefono() { }

        public string Llamar()
        {
            return "Realizando Llamada...";
        }
        public string Llamar(string contacto)
        {
            return "Llamando a " + contacto;
        }
    }
}
