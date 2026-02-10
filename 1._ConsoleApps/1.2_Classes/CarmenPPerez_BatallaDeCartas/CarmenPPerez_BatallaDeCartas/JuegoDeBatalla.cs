using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_BatallaDeCartas
{
    public class JuegoDeBatalla
    {
        private List<Jugador> _jugadores;
        private int _numJugadores;
        private Baraja _barajaEntera;
        //private Dictionary<Jugador, Baraja> _mesa;
        private Baraja _mesa;
        private Baraja _descartes;

        private bool bFIN = false;

        public List<Jugador> Jugadores { get { return _jugadores; } set { _jugadores = value; } }
        public int NumJugadores { get { return _numJugadores; } set { _numJugadores = value; } }
        public Baraja BarajaEntera { get { return _barajaEntera; } set { _barajaEntera = value; } }
        //public Dictionary<Jugador, Baraja> Mesa { get { return _mesa; } set { _mesa = value; } }
        public Baraja Mesa { get { return _mesa; } set { _mesa = value; } }
        public Baraja Descartes { get { return _descartes; } set { _descartes = value; } }
        public bool BoolFIN { get { return bFIN; } }

        public JuegoDeBatalla()
        {
            BarajaEntera = new Baraja();
            BarajaEntera.AñadirBarajaEntera();

            NumJugadores = 0;
            Jugadores = new List<Jugador>();
            Mesa = new Baraja();
            Descartes = new Baraja();
        }

        public JuegoDeBatalla(int numJugadores)
        {
            BarajaEntera = new Baraja();
            BarajaEntera.AñadirBarajaEntera();

            NumJugadores = numJugadores;
            Jugadores = new List<Jugador>();
            CrearYAñadirJugadores();

            Mesa = new Baraja();
            Descartes = new Baraja();
        }

        public void InicializarJuego()
        {
            int _numJugadores;

            //  Determinar el numero de jugadores
            do
            {
                Console.WriteLine(@"    -   El Juego de Cartas Clásico(Guerra)  -
------------------------------------------------------------------
    - Objetivo: Ser el jugador que consiga todas las cartas. 
    - Cómo se juega:

        1. Se reparten las cartas en dos mazos, boca abajo, 
            entre los jugadores. 
        2. Cada jugador voltea su carta superior al mismo tiempo.
        3. El jugador con la carta más alta gana ambas y 
            las coloca en su montón de cartas ganadas. 
        4. Si las cartas son del mismo valor(por ejemplo, dos 8s), 
            hay una ""guerra"".
        5. En una guerra, cada jugador pone tres cartas boca abajo, 
            y luego una carta boca arriba para determinar el ganador. 
            El ganador toma todas las cartas de la guerra.
        6. El primer jugador en quedarse sin cartas pierde.
------------------------------------------------------------------

->  Cuantos jugadores van a ser?
");

                if (int.TryParse(Console.ReadLine(), out _numJugadores))
                {
                    if (_numJugadores >= 2 && _numJugadores <= 5)
                        break;
                }
                Console.Clear();
            }
            while (true);
            this.NumJugadores = _numJugadores;
        }

        public void CrearYAñadirJugadores()
        {
            for (int i = 1; i <= NumJugadores; i++)
            {
                this.Jugadores.Add(new Jugador(i));
            }
        }

        public void AsignarMazos(int tamañoMazo)
        {
            List<List<Carta>> particiones = BarajaEntera.PartirBaraja(tamañoMazo);

            if (particiones.Count != Jugadores.Count)
            {
                particiones.RemoveAt(particiones.Count - 1);
            }
            // todo !! a veces particiones no da nada

            foreach (Jugador j in Jugadores)
            {
                j.Mazo = (new Baraja(particiones[0]));
                j.Mazo.AsignarDueñoAlMazo(j);

                particiones.RemoveAt(0);
            }
        }

        //public void TirarCarta(int numCartasATirar)
        //{
        //    foreach (Jugador j in Jugadores)
        //    {
        //        Mesa.Add(j, j.TirarCartaDelMazo(numCartasATirar));
        //    }
        //}
        public void TirarCarta()
        {
            foreach (Jugador j in Jugadores)
            {
                Mesa.Cartas.Add(j.Mazo.Robar());
            }
        }

        //public string MesaToString()
        //{
        //    string printMesa = "";
        //    foreach (KeyValuePair<Jugador, Baraja> m in Mesa)
        //    {
        //        printMesa += "Carta jugador: " + m.Key.ID + "\n";
        //        printMesa += m.Value.ToString() + "\n";
        //    }
        //    return printMesa;
        //}
        public List<Carta> CartasMasGrandes()
        {
            List<Carta> ordenada = Mesa.Cartas.OrderByDescending(num => num.Numero).ToList();

            // Encuentra todas las cartas que sean iguales a la carta mas grande
            return (ordenada.FindAll(grande => grande.Numero.Equals(ordenada[0].Numero)));
        }
        public void ProcesarCartas()
        {
            // Coger la Carta con el numero mas grande y las repetidas
            List<Carta> empates = CartasMasGrandes();

            // Si son mas de una empieza el empate
            if (empates.Count > 1)
            {
                // Recoger los jugadores empatados
                List<Jugador> empatados = new List<Jugador>();
                foreach (Carta c in empates)
                {
                    // Si el jugador empata y tiene cartas procede al desenpate
                    if (c.Dueño.Mazo.Cartas.Count > 0)
                        empatados.Add(c.Dueño);
                }
                if (empatados.Count == 0)
                {
                    FIN(null);
                    return;
                }
                Empate(empatados);
            }
            // No es empate
            else
            {
                // Comprueba si ya tiene las 52
                if ((empates[0].Dueño.Puntos.Cartas.Count +empates[0].Dueño.Mazo.Cartas.Count +
                    Mesa.Cartas.Count) == 52)
                    FIN(empates[0].Dueño);

                // Añadir las cartas al ganador
                empates[0].Dueño.AñadirCartasPuntuacion(Mesa.Cartas);
                Mesa = new Baraja();

                if (Descartes.Cartas.Count > 0)
                {
                    empates[0].Dueño.AñadirCartasPuntuacion(Descartes.Cartas);
                    Descartes = new Baraja();
                }



            }
        }

        public void Empate(List<Jugador> empatados)
        {
            Descartes = Mesa;
            Mesa = new Baraja();
            Baraja barEmpate = new Baraja();
            Carta cartaElegida = new Carta();

            // Cada jugador Tira 3 cartas
            foreach (Jugador j in empatados)
            {
                if (j.Mazo.Cartas.Count <= 3)
                {
                    barEmpate.AñadirCartas(j.Mazo.Cartas);
                }
                else
                {
                    for (int i = 0; i <= 3; i++)
                        barEmpate.Cartas.Add(j.Mazo.Robar());
                }

                cartaElegida = j.Mazo.RobarAlAzar();
                Descartes.AñadirCartas(Mesa.Cartas.FindAll(carta => !carta.Equals(cartaElegida)));
                Mesa = barEmpate;

                ProcesarCartas();
            }
        }

        public void PrintPuntuaciones()
        {
            Console.WriteLine(" - Puntuacion - ");
            foreach (Jugador j in Jugadores)
            {
                Console.Write($"+ Jugador {j.ID} -> {j.Puntos.Cartas.Count}\n");
            }
            Console.WriteLine("\n");
        }

        public void FIN(Jugador ganadores)
        {
            bFIN = true;
            Console.WriteLine($@"
 - - FIN - -");
            if (ganadores.Equals(null))
            {
                Console.Write(@"    EMPATE");
            }

            PrintPuntuaciones();
        }
    }
}
