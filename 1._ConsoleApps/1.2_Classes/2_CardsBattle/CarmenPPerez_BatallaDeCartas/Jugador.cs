using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_BatallaDeCartas
{
    public class Jugador
    {
        private Baraja _mazo;
        private Baraja _puntos;

        public int ID { get; }
        public Baraja Mazo { get => _mazo; set => _mazo = value; }
        public Baraja Puntos { get => _puntos; set => _puntos = value; }

        public Jugador()
        {
            ID = 0;
            _mazo = new Baraja();
            _puntos = new Baraja();
        }
        public Jugador(int id)
        {
            this.ID = id;
            this._mazo = new Baraja();
            _puntos = new Baraja();
        }
        public Jugador(int id, Baraja bj)
        {
            this.ID = id;
            this._mazo = bj;
            _puntos = new Baraja();
        }

        public void AñadirCartasPuntuacion(List<Carta> puntuacion)
        {
            foreach (Carta c in puntuacion)
            {
                Puntos.Cartas.Add(c);
                c.Dueño = null;
            }
        }

        // todo borrame
        public Baraja TirarCartaJugador(int numCartasATirar)
        {
            int indiceCartaSeleccionada;
            Baraja cartasTiradas = new Baraja();

            do
            {
                Console.WriteLine(@" -> Selecciona la posicion de la carta que vas a tirar");

                if (int.TryParse(Console.ReadLine(), out indiceCartaSeleccionada))
                {
                    indiceCartaSeleccionada--;
                    if (indiceCartaSeleccionada >= 0 && indiceCartaSeleccionada <= (Mazo.Cartas.Count - 1))
                    {
                        cartasTiradas.Cartas.Add(Mazo.RobarPosN(indiceCartaSeleccionada));
                        numCartasATirar--;
                    }
                }
                Console.Clear();
            }
            while (numCartasATirar > 0);

            return cartasTiradas;
        }

        // todo borrame
        public Baraja TirarCartaDelMazo(int numCartasATirar)
        {
            Baraja cartasTiradas = new Baraja();

            do
            {
                cartasTiradas.Cartas.Add(Mazo.RobarAlAzar());
                numCartasATirar--;
            }
            while (numCartasATirar > 0);

            return cartasTiradas;
        }
    }
}
