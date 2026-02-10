using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_BatallaDeCartas
{
    public class Baraja
    {
        private List<Carta> _cartas;
        public List<Carta> Cartas { get => _cartas; set => _cartas = value; }

        public Baraja()
        {
            Cartas = new List<Carta>();
        }

        public Baraja(Carta c)
        {
            Cartas = new List<Carta>();
            Cartas.Add(c);
        }
        public Baraja(List<Carta> c)
        {
            Cartas = c;
        }
        public override string ToString()
        {
            string cartas = "";
            foreach (Carta c in Cartas)
            {
                cartas += c.ToString() + "\n";
            }
            return cartas;
        }
        public void PrintBaraja()
        {
            Console.Clear();

            // columnas que imprimo
            int cont = 0;

            foreach (Carta c in Cartas)
            {
                Console.Write("{0, 3} de {1,9} |", c.Numero, c.Palo);

                //  Si ha impreso 3 cartas
                //  salta a la siguiente fila
                if (cont == 3)
                {
                    Console.WriteLine();
                    cont = 0;
                }
                else
                    cont++;
            }
        }
        public void AñadirBarajaEntera()
        {
            //  Añade 13 cartas de todos los tipos de Palos
            foreach (int p in Enum.GetValues(typeof(ePalos)))
            {
                for (int i = 1; i <= 13; i++)
                {
                    Cartas.Add(new Carta(i, (ePalos)p));
                }
            }
        }

        public List<Carta> Barajar(int veces)
        {
            List<Carta> cartasBarajadas = new List<Carta>();
            Carta c;    //  Carta que se va añadiendo a la nueva baraja y borrando de la anterior

            //  Barajar un numero de veces hace que las posiciones sean mas aleatorias
            for (int j = 0; j < veces; j++)
            {
                // Recorrer el for por el numero de cartas que hay pero no usar su indice
                for (int i = Cartas.Count; i > 0; i--)
                {
                    c = Cartas[Program.rnd.Next(Cartas.Count())];   //  Coger una carta aleatoria de la Baraja
                    cartasBarajadas.Add(c);                         //  Añadir la carta a la nueva baraja
                    Cartas.Remove(c);                               //  Quitar la carta que hemos añadido
                }
            }

            this.Cartas = cartasBarajadas;                     //  Guardarlas en memoria
            return Cartas;                                     //  devolverlas
        }

        public Carta Robar()
        {
            return RobarPosN(0);            //  Devolver la primera carta de la baraja
        }

        public Carta RobarPosN(int n)
        {
            Carta robada = Cartas[n];   //  Guardar la carta en Posicion de Array N
            Cartas.Remove(robada);          //  Quitarla de la baraja

            return robada;                  //  Devolver la carta robada
        }

        public Carta RobarAlAzar()
        {
            //  carta aleatoria entre 0 y el total de las cartas -1
            return RobarPosN(Program.rnd.Next(Cartas.Count()));
        }
        public List<List<Carta>> PartirBaraja(int tamañoMazo)
        {
            List<List<Carta>> particiones = new List<List<Carta>>();

            for (int i = 0; i < Cartas.Count; i += tamañoMazo)
            {
                particiones.Add(Cartas.GetRange(i, Math.Min(tamañoMazo, Cartas.Count - i)));
            }
            return particiones;
        }

        public void AsignarDueñoAlMazo(Jugador j)
        {
            foreach (Carta c in Cartas)
            {
                c.Dueño = j;
            }
        }

        public void AñadirCartas(List<Carta> cartas)
        {
            foreach (Carta c in cartas)
            {
                Cartas.Add(c);
            }
        }
    }
}
