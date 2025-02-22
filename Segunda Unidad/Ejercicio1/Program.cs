using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Crear un proyecto de consola .Net Framework.
Crear la clase Telefono (recordemos que una clase va en un archivo nuevo; click derecho en el proyecto, agregar, class).
Agregale los siguientes atributos:
Modelo string.
Marca string.
NumeroTelefonico string.
CodigoOperador int (1, 2 o 3).
Agregale las propiedades correspondientes. Podés hacer el formato largo o el corto.
Modelo: solo lectura. Es decir, solo get.
Marca: solo lectura.
NumeroTelefonico: lectura y escritura.
CodigoOperador: lectura y escritura. Validar escritura que solo admita 1, 2 o 3, caso contrario escribir un cero.
Agregar Constructor que reciba Modelo y Marca.
Crear algunos objetos en el main de Program y probar escribirle datos y mostrar en pantalla el estado del Telefono.
Agregar método Llamar() sin parámetros que devuelva un string con la leyenda "Realizando llamada...".
Sobrecargar el método Llamar(string contacto) para que reciba un contacto y devuelva un string con la leyenda "Llamando a " + contacto
Probar métodos en el main mostrando en pantalla el comportamiento de los objetos.*/
namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //USO EL CONSTRUCTOR SOLICITADO
            Telefono telefonoEjemplo1 = new Telefono( "g40", "Motorola" );
            //USO CONSTRUCTOR SIN PARAMETROS
            Telefono telefonoEjemplo2 = new Telefono();
            Telefono telefonoEjemplo3 = new Telefono();
            //TESTEO QUE EL CONSTRUCTOR DEL EJEMPLO 1 HAYA FUNCIONADO
            Console.WriteLine("El primer ejemplo es - Modelo: " + telefonoEjemplo1.Modelo + " - Marca: " + telefonoEjemplo1.Marca);
            Console.ReadKey();
            //Utilizo la funcion de llamar sin ningun nombre
            Console.WriteLine(telefonoEjemplo1.Llamar());
            //Asigno un numero de telefono para probar en uno de los ejemplos (Necesito usar ToString ya que lo toma como un int y no lo puede asignar al atributo)
            telefonoEjemplo2.NumeroTelefonico = 7778889.ToString();
            //Pruebo el metodo de llamar que recibe un contacto por parametro de entrada
            Console.WriteLine(telefonoEjemplo2.Llamar("Carlos"));
            //Corroboro que se haya asignado correctamente el numero de telefono de antes.
            Console.WriteLine("El numero telefónico del segundo ejemplo es: " + telefonoEjemplo2.NumeroTelefonico);
            Console.ReadKey();
        }
    }
}
