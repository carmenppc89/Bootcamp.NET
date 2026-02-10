using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_CartasYBarajas
{
    internal class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            // Variables Auxiliares
            int eleccionMenu;
            int robarPosicion;
            Carta robada = new Carta();

            Baraja b1 = new Baraja("Entera");   // Baraja en la que vamos a jugar

            b1.AñadirBarajaEntera();            // Añadir las cartas a la baraja b1

            do
            {
                eleccionMenu = -1;  // Reiniciar la eleccion del menu              
                b1.PrintBaraja();   // Limpiar la consola e imprimir la baraja

                Console.WriteLine($@"

Introduce una opcion: (el numero)
1.  Barajar
2.  Robar
3.  Robar en Posicion
4.  RObar Al Azar
");

                //  Si ha habido carta robada se imprime mensaje y se reinicia la carta
                if (robada.Numero > 0)
                {
                    Console.WriteLine($"Has robado el {robada.Print()}");
                    robada = new Carta(); ;
                }

                //  Procesar la decision del menu
                do
                {
                    if (int.TryParse(Console.ReadLine(), out eleccionMenu))
                        break;
                    else
                        eleccionMenu = -1;
                }
                while (true);

                //  Implementar la decision del menu
                switch (eleccionMenu)
                {
                    case 1:
                        b1.Barajar();
                        break;

                    case 2:
                        robada = b1.Robar();
                        break;

                    case 3:
                        //  Escoger la posicion a la que robar
                        do
                        {
                            Console.WriteLine($" -> Escoge una posicion del 1 al {b1.Cartas.Count}");
                            if (int.TryParse(Console.ReadLine(), out robarPosicion))
                                break;
                            else
                                Console.WriteLine($" !!! -> Posicion invalida");
                        }
                        while (true);

                        robada = b1.RobarPosN(robarPosicion);
                        break;

                    case 4:
                        robada = b1.RobarAlAzar();
                        break;

                    //  inputs incorrectos hacen que se salga del programa
                    default:
                        return;
                }
            }
            while (true);
        }
    }
}
