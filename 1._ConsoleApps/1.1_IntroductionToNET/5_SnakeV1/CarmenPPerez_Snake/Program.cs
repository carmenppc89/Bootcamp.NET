using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarmenPPerez_Snake
{
    internal class Program
    {
        //  Variables estaticas
        static string[,] Terreno;
        // Lista de coordenadas dentro de terreno donde se enuentra las partes de la serpiente
        static List<Point> Snake;
        static void Main(string[] args)
        {
            do
            {
                // Reinicio/Declaracion de variables
                int tamanoUtilTablero = 0;  // numero de largo y ancho donde la serpiente se podra mover
                int tamanoRealTablero = 0;  // numero de largo y ancho del tablero realmente
                bool gameOver = false;      // condicion de salida del programa
                ConsoleKey key = new ConsoleKey();      // inputs del jugador
                Point posicionCabeza = new Point();     // coordenada de la cabeza
                Point siguientePosicion = new Point();  // coordenada de la siguiente posicion de la cabeza

                Console.WriteLine("    -   SNAKE   -");
                do
                {
                    // Pedir el tamaño del tablero y validarlo
                    Console.WriteLine("->   Establece el tamaño del terreno.\nHa de ser mas Grande de 10");
                    if (int.TryParse(Console.ReadLine(), out tamanoUtilTablero) || tamanoUtilTablero > 10)
                        break;
                    else
                        Console.WriteLine("!!   -> Valor no valido, escriba un numero.");
                } while (true);

                // Establecer el tamaño del tablero con bordes y guias
                tamanoRealTablero = tamanoUtilTablero + 3;
                Terreno = new string[tamanoRealTablero, tamanoRealTablero];

                CrearTerreno(tamanoRealTablero);
                CrearSerpiente(tamanoRealTablero);
                ConsolaTerreno(tamanoRealTablero);

                do
                {
                    siguientePosicion = CogerFlecha(key);

                    // Si la siguiente posicion esta ocupada por su cuerpo o un margen romperemos el bucle
                    if (Terreno[siguientePosicion.X, siguientePosicion.Y] == "Y" ||
                        Terreno[siguientePosicion.X, siguientePosicion.Y] == "#")
                        gameOver = true;

                    MoverSerpiente(siguientePosicion, posicionCabeza);
                    CrearTerreno(tamanoRealTablero);
                    ConsolaSerpiente();
                    ConsolaTerreno(tamanoRealTablero);

                    Console.WriteLine($"\n    - Puntuacion: {Snake.Count}\n");

                } while (!gameOver);

                Console.WriteLine(@"
=====================================
        -   GAME OVER   -

    -> Pulsa cualquier tecla para cerrar el programa");

                Console.ReadKey();
                return;

            } while (true);
        }

        static void CrearTerreno(int real)
        {
            Console.Clear();

            for (int f = 0; f < real; f++)
            {
                for (int c = 0; c < real; c++)
                {
                    // -> Poner los bordes del terreno
                    // pones borde en las columnas y filas 1 y tamanoReal-1
                    if ((f == 1 && c >= 1) ||
                        (c == 1 && f >= 1) ||
                        (f == (real - 1) && c >= 1) ||
                        ((c == real - 1) && f >= 1))
                        Terreno[f, c] = "#";
                    // -> Poner numeros como cooredenadas
                    // si la fila es 0 le pones los numeros de la columna
                    else if (f == 0 && c >= 2)
                        Terreno[f, c] = (c - 2) + "";
                    // si la columna es 0 le pones el numero de la fila
                    else if (c == 0 && f >= 2)
                        Terreno[f, c] = (f - 2) + "";
                    else if ((f == 0 && c < 2) || (c == 0 && f < 2))
                        Terreno[f, c] = " ";
                    else
                        Terreno[f, c] = " ";
                }
            }
        }

        static void ConsolaTerreno(int real)
        {
            // Imprimir el terreno (Width component) 
            for (int c = 0; c < real; c++)
            {
                for (int f = 0; f < real; f++)
                {
                    Console.Write("{0,-2}", Terreno[f, c]);
                }
                Console.WriteLine();
            }
        }

        static void CrearSerpiente(int real)
        {
            // Inicializar la serpiente
            Snake = new List<Point> { new Point(real / 2, real / 2) };
            // Coger la mitad el tablero y Poner la cabeza y una casilla de cuerpo
            Terreno[Snake[0].X, Snake[0].Y] = "@";
        }

        static Point CogerFlecha(ConsoleKey k)
        {
            do
            {
                // Cogemos la flecha pulsada y devolvemos la coordenada en el terreno
                Console.WriteLine("->   Muevete con la felchas.");
                k = Console.ReadKey().Key;

                switch (k)
                {
                    case ConsoleKey.LeftArrow:
                        return new Point(Snake[0].X - 1, Snake[0].Y);
                    case ConsoleKey.RightArrow:
                        return new Point(Snake[0].X + 1, Snake[0].Y);
                    case ConsoleKey.UpArrow:
                        return new Point(Snake[0].X, Snake[0].Y - 1);
                    case ConsoleKey.DownArrow:
                        return new Point(Snake[0].X, Snake[0].Y + 1);
                    default:
                        Console.WriteLine("!!   -> Solo felchas");
                        break;
                }
            } while (true);
        }

        static void MoverSerpiente(Point nuevaPosiscion, Point cabeza)
        {
            //  Cogemos el valor de la cabeza antes de mover la serpiente
            cabeza = new Point(Snake[0].X, Snake[0].Y);

            // Ponemos la cabeza en la nueva posicion
            Snake[0] = nuevaPosiscion;
            // Añadimos nuevo cuerpo donde estaba la cabeza
            // Serpiente infinita por ser la version 1
            Snake.Add(new Point(cabeza.X, cabeza.Y));
        }

        static void ConsolaSerpiente()
        {
            // Poner la serpiente en las posiciones del tablero
            // Primera posicion de la serpiente es cabeza
            for (int i = (Snake.Count() - 1); i >= 0; i--)
            {
                Terreno[Snake[i].X, Snake[i].Y] = i == 0 ? "@" : "Y";
            }
        }
    }
}
