using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPTresEnRaya
{
    internal class Program
    {
        // + VARIABLES ESTATICAS   
        //      - TURNOS:
        //          impar -> Jugador
        //          par   -> Maquina
        //          -1 -  -> Gana Jugador
        //          -2    -> Gana Maquina
        //          -3    -> Empate
        static int Turno = 1;
        //      - Posiciones: Todas las posiciones del tablero
        static string[] Posiciones = new string[9];
        //      - Posiciones Libres: Posiciones sin seleccionar
        static string[] PosLibres = new string[9];
        //      - Acceso a la classe Random
        static Random R = new Random();
        static void Main(string[] args)
        {
            // + VARIABLES LOCALES            
            string posEnTablero = "";
            int posEnArray;

            Console.WriteLine(@"
    -- TRES EN RAYA --
");

            EscribirTablero();

            do
            {
                Console.WriteLine(@"
-----------------------------
  - TURNO DEL JUGADOR (O) -
");

                //  - TURNO DEL JUGADOR -
                //  El jugador selecciona casilla VALIDA
                while (true)
                {
                    Console.WriteLine("+ Introduzca la posicion de una casilla:");
                    posEnTablero = Console.ReadLine();
                    posEnArray = (int.Parse(posEnTablero)) - 1; // paso la posicion del tablero en la misma posicion del array de la tabla

                    // Si introduce una posicion valida se rompe el bucle
                    if (!isPosicionOcupada(posEnArray))
                        break;
                }

                // Seleccionar casilla del tablero a traves de la posicion
                SeleccionarCasilla(posEnArray);

                // Comprobar si se ha terminado la partida
                if (haTerminado())
                    break;

                //  - TURNO DE LA MAQUINA -
                Console.WriteLine(@"
-----------------------------
 - TURNO DE LA MAQUINA (X) -
");
                Console.WriteLine("+ La Maquina esta introduciendo una casilla");

                // Sacamos todas las posiciones no seleccionadas
                PosicionesLibres();
                posEnArray = PosMaquina() - 1;
                // selecciona una posicion aleatoria a partir de las posiciones libres
                SeleccionarCasilla(posEnArray);

                // Comprobar si se ha terminado la partida
                if (haTerminado())
                    break;

            } while (Turno > 0);

            // Segunn el turno imprime el final
            ReslutadoTurno();

            Console.WriteLine("-> Key to exit");
            Console.ReadKey();
        }

        static void EscribirTablero()
        {
            for (int i = 0; i < Posiciones.Length; i++)
            {
                Posiciones[i] = "" + (i + 1);
            }

            Console.WriteLine(@"
-----------------------------

        {0} | {1} | {2} 
       ------------
        {3} | {4} | {5}
       ------------
        {6} | {7} | {8}

-----------------------------
", Posiciones[0], Posiciones[1], Posiciones[2], Posiciones[3], Posiciones[4],
Posiciones[5], Posiciones[6], Posiciones[7], Posiciones[8]);
        }
        static void PrintTablero()
        {
            Console.WriteLine(@"
-----------------------------

        {0} | {1} | {2} 
       ------------
        {3} | {4} | {5}
       ------------
        {6} | {7} | {8}

-----------------------------
", Posiciones[0], Posiciones[1], Posiciones[2], Posiciones[3], Posiciones[4],
Posiciones[5], Posiciones[6], Posiciones[7], Posiciones[8]);
        }
        static bool isPosicionOcupada(int pos)
        {
            if (Posiciones[pos] != "X" || Posiciones[pos] != "O")
            {
                return false;
            }
            else
            {
                Console.WriteLine("!! -> Esa posicion ya esta ocupada.");
                return true;
            }
        }
        static void SeleccionarCasilla(int pos)
        {
            Posiciones[pos] = Turno % 2 == 0 ? "X" : "O";
            Console.Clear();
            PrintTablero();
        }
        static bool haTerminado()
        {
            // Comprobar si ha habido Raya
            // !!! Antes que el empate
            Turno = ComprobarRaya();
            if (Turno < 0)
                return true;

            // Comprobar si se ha empatado
            Turno = HayEmpate();
            if (Turno < 0)
                return true;
            else // si no lo es sigue el juego y pasa al siguiente turno
                Turno++;
            return false;
        }
        static int ComprobarRaya()
        {
            // comparar horizontal
            if (Posiciones[0] == Posiciones[1] && Posiciones[1] == Posiciones[2] ||
                Posiciones[3] == Posiciones[4] && Posiciones[4] == Posiciones[5] ||
                Posiciones[6] == Posiciones[7] && Posiciones[7] == Posiciones[8] ||

                // Comparar vertical
                Posiciones[0] == Posiciones[3] && Posiciones[3] == Posiciones[6] ||
                Posiciones[1] == Posiciones[4] && Posiciones[4] == Posiciones[7] ||
                Posiciones[2] == Posiciones[5] && Posiciones[5] == Posiciones[8] ||

                // Comparar diagonal
                Posiciones[0] == Posiciones[4] && Posiciones[4] == Posiciones[8] ||
                Posiciones[6] == Posiciones[4] && Posiciones[4] == Posiciones[2])
            {
                if (Turno % 2 == 0)
                    return -2;
                else
                    return -1;
            }
            return Turno;
        }
        static int HayEmpate()
        {
            for (int i = 0; i < Posiciones.Length; i++)
            {
                if (Posiciones[i] != "X" || Posiciones[i] != "O")
                {
                    return Turno;
                }
            }
            return -3;
        }
        static void PosicionesLibres()
        {
            PosLibres = new string[9];
            // PosLibres = Posiciones;
            int posTablaLibre = 0;

            for (int posTablaFija = 0; posTablaFija < Posiciones.Length; posTablaFija++)
            {
                if (Posiciones[posTablaFija] != "X" && Posiciones[posTablaFija] != "O")
                {
                    PosLibres[posTablaLibre] = Posiciones[posTablaFija];
                    posTablaLibre++;
                }
            }

            int numPosLibres = Posiciones.Length - (Turno - 1);
            Array.Resize(ref PosLibres, numPosLibres);
        }
        static int PosMaquina()
        {
            return int.Parse(PosLibres[R.Next(PosLibres.Length)]);
        }
        static void ReslutadoTurno()
        {
            Console.WriteLine(@"
=============================
       FIN DE LA PARTIDA
=============================
");
            switch (Turno)
            {
                case -1:
                    Console.WriteLine(@"
    HA GANADO EL JUGADOR !!!
");
                    break;
                case -2:
                    Console.WriteLine(@"
    HA GANADO LA MAQUINA !!!
");
                    break;
                case -3:
                    Console.WriteLine(@"
           EMPATE !!!
");
                    break;
            }
        }
    }
}
