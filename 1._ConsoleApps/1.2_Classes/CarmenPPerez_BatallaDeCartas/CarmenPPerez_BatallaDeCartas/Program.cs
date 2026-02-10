using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_BatallaDeCartas
{
    internal class Program
    {
        public static Random rnd = new Random();
        static JuegoDeBatalla jb;
        static void Main(string[] args)
        {

            //  Iniciamos jb
            jb = new JuegoDeBatalla();

            //  determinamos los jugadores y los creamos
            jb.InicializarJuego();

            //  Creamos y añadimos los jugadores a la Batalla
            jb.CrearYAñadirJugadores();

            //  Barajar las cartas
            jb.BarajaEntera.Barajar(rnd.Next(5));

            //  Partir la baraja de jb en el numero de jugadores
            //  Asignar mazos a los jugadores  
            jb.AsignarMazos((jb.BarajaEntera.Cartas.Count() / jb.NumJugadores));

            do
            {
                // Se empieza los turnos tirando una carta
                jb.TirarCarta();

                // Imprimir cartas de la ronda y puntuaciones
                Console.WriteLine(jb.Mesa.ToString());

                // Procesar las cartas que se han seleccionado
                jb.ProcesarCartas();
            }
            while (!jb.BoolFIN);
        }
    }
}
