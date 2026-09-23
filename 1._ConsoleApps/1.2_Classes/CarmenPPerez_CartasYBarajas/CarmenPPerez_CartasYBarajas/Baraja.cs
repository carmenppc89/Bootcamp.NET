using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace CarmenPPerez_CartasYBarajas
{
    public class Baraja
    {
        private string _nombre;
        private List<Carta> _cartas;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public List<Carta> Cartas { get => _cartas; set => _cartas = value; }

        public Baraja()
        {
            this._cartas = new List<Carta>();
        }
        public Baraja(string n)
        {
            this._nombre = n;
            this._cartas = new List<Carta>();
        }
        public Baraja(string n, List<Carta> c)
        {
            this._nombre = n;
            this._cartas = c;
        }

        public void PrintBaraja()
        {
            Console.Clear();
            Console.WriteLine("- Baraja: " + this._nombre + "\n");

            // columnas que imprimo
            int cont = 0;

            foreach (Carta c in _cartas)
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
            Console.WriteLine($@"
-> Añadiendo Baraja: {this._nombre}
---------------------------------
");
            foreach (int p in Enum.GetValues(typeof(ePalos)))
            {
                for (int i = 1; i <= 13; i++)
                {
                    this.Cartas.Add(new Carta(i, (ePalos)p));
                }
            }
        }

        public List<Carta> Barajar()
        {
            List<Carta> cartasBarajadas = new List<Carta>();
            Carta c;    //  Carta que se va añadiendo a la nueva baraja y borrando de la anterior

            // Recorrer el for por el numero de cartas que hay pero no usar su indice
            for (int i = Cartas.Count; i > 0; i--)
            {
                c = Cartas[Program.rnd.Next(Cartas.Count())];   //  Coger una carta aleatoria de la Baraja
                cartasBarajadas.Add(c);                         //  Añadir la carta a la nueva baraja
                Cartas.Remove(c);                               //  Quitar la carta que hemos añadido
            }

            this.Cartas = cartasBarajadas;                     //  Guardarlas en memoria
            return Cartas;                                     //  devolverlas
        }

        public Carta Robar()
        {
            return RobarPosN(1);            //  Devolver la primera carta de la baraja
        }

        public Carta RobarPosN(int n)
        {
            Carta robada = Cartas[n - 1];   //  Guardar la carta en Posicion de Array N
            Cartas.Remove(robada);          //  Quitarla de la baraja

            return robada;                  //  Devolver la carta robada
        }

        public Carta RobarAlAzar()
        {
            //  carta aleatoria entre 0 y el total de las cartas -1
            return RobarPosN(Program.rnd.Next(Cartas.Count()));
        }
    }
}
