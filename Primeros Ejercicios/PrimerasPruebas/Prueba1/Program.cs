using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Por favor ingrese su nombre.");
            dibujarLinea(40);
            string nombreUsuario = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Excelente! Bienvenido " + nombreUsuario + "!");
            dibujarLinea(40);
            while (true) {
                int eleccion = mostrarMenu();
                seleccionMenu(eleccion, ref nombreUsuario);
            }
            Console.ReadKey();
        }

        static void seleccionMenu(int eleccion, ref string nombre){
            Console.Clear();
            switch (eleccion)
            {
                case 1:
                    {
                        int valor1, valor2;
                        int resultado = 0;
                        Console.Write("Por favor, ingrese el primer valor: ");
                        valor1 = int.Parse(Console.ReadLine());
                        Console.Write("Por favor, ingrese el segundo valor: ");
                        valor2 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Datos Cargados.");
                        Console.WriteLine("Ingrese 1 si desea sumar los valores.");
                        Console.WriteLine("Ingrese 2 si desea restar los valores.");
                        int eleccion2 = int.Parse(Console.ReadLine());
                        if (eleccion2 == 1) { resultado = valor1 + valor2; }
                        else if (eleccion2 == 2) { resultado = valor1 - valor2; }
                        Console.WriteLine("El resultado es: " + resultado);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                case 2:
                    {
                        string nuevoNombre = "";
                        Console.WriteLine("Su nombre de usuario actual es " + nombre);
                        Console.Write("Ingrese su nuevo nombre de usuario (Deje vacio si desea que siga igual): ");
                        nuevoNombre = Console.ReadLine();
                        if (nuevoNombre != "") { nombre = nuevoNombre; }
                        Console.Clear();
                    }
                    break;
                default:
                    Console.WriteLine("Opcion Invalida.");
                    break;
            }
        }
        static int mostrarMenu(){
            Console.WriteLine("=========MENU PRINCIPAL=========");
            Console.WriteLine("1 - Calculadora. ");
            Console.WriteLine("2 - Cambiar Nombre. ");
            dibujarLinea(35);
            Console.Write("Opcion deseada: ");
            int opc = int.Parse(Console.ReadLine());
            return opc;
        }
        static void dibujarLinea(int cantidadEspacios){
            for (int i = 0; i < cantidadEspacios; i++){
                Console.Write("=");
            }
            Console.WriteLine("");
            return;
        }
    }
}
