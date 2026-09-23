using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubDeFutbol
{
    public static class Generador
    {
        // Generador de números aleatorios para toda la clase
        public static Random rand = new Random();
        // ARRAYS DE DATOS BASE

        // Nombres realistas para jugadores (internacionales y locales)
        private static string[] nombresJugadores = {
            "Messi", "Ronaldo", "Neymar", "Elias", "Marcos",
            "Harol", "Salah", "Benzema", "Harol", "Modric",
            "Kane", "Son", "Miguel", "Vincent", "Sammy",
            "Ederson", "Alisson", "Kante", "Tomas", "Gabriel",
            "Pedro", "Lucas", "Steven", "Sancho", "Fabi",
            "David", "Sergio", "Carlos", "Javier", "Antonio",
            "Roberto", "Diego", "Fernando", "Pablo", "Juan",
            "Daniel", "Alejandro", "Jorge", "Ricardo", "Manuel",
            "Francisco", "Luis", "Rafael", "Jose", "Andres",
            "Alberto", "Mario", "Victor", "Raul", "Iker"
        };

        // Posiciones de fútbol para cubrir todas las zonas del campo
        private static string[] posiciones = {
            "Portero", "Defensa", "Lateral", "Central", "Mediocentro",
            "Interior", "Extremo", "Delantero", "Carrilero", "Pivote"
        };

        // Nombres base para equipos 
        private static string[] nombresEquipos = {
            "Dragones", "Leones", "Águilas", "Lobos",
            "Tiburones", "Panteras", "Halcones", "Cóndores",
            "Toros", "Palomas", "Ballenas", "Dragones",
            "Ardillas", "Mapaches", "Serpientes"
        };

        // Prefijos comunes para clubs 
        private static string[] nombresClubs = {
            "Camaleon", "Sporting", "Atléticos", "Real",
            "Estrellas", "Union", "CentroC"
        };

        // Ciudades españolas para generar nombres geográficos realistas
        private static string[] ciudades = {
            "Madrid", "Barcelona", "Sevilla", "Valencia", "Bilbao",
            "Málaga", "Zaragoza", "Murcia", "Granada", "Tenerife"
        };
        // MÉTODOS AUXILIARES

        //Mezcla aleatoriamente los elementos de una lista usando Fisher-Yates.
        //Evita que se repitan los mismos jugadores en equipos diferentes.
        private static void MezclarLista<T>(List<T> lista)
        {
            int n = lista.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                T temp = lista[i];
                lista[i] = lista[j];
                lista[j] = temp;
            }
        }

        // MÉTODOS PRINCIPALES

        // Crea un equipo con nombre único y 11 jugadores aleatorios.
        public static Equipo CrearEquipo()
        {
            string nombreEquipo;
            int intentos = 0;

            // Intenta generar un nombre único para el equipo
            do
            {
                nombreEquipo = nombresEquipos[rand.Next(nombresEquipos.Length)];
                intentos++;
            } while (Program.equipos.ContainsKey(nombreEquipo) && intentos < 10);

            // Si no lo consigue en 10 intentos, agrega un número al nombre
            if (intentos >= 10)
            {
                nombreEquipo = $"{nombreEquipo} {rand.Next(100, 999)}";
            }

            var equipo = new Equipo(nombreEquipo);

            // Mezcla los nombres disponibles para evitar repeticiones
            var nombresDisponibles = new List<string>(nombresJugadores);
            MezclarLista(nombresDisponibles);

            // Crea 11 jugadores únicos para el equipo
            for (int i = 0; i < 11 && i < nombresDisponibles.Count; i++)
            {
                string nombre = nombresDisponibles[i];
                string posicion = posiciones[rand.Next(posiciones.Length)];
                int numeroCamiseta = rand.Next(1, 100);

                equipo.Jugadores.Add(new Jugador(nombre)
                {
                    Posicion = posicion,
                    NumeroCamiseta = numeroCamiseta
                });
            }

            return equipo;
        }
        // Crea un jugador individual con datos aleatorios.
        public static Jugador CrearJugador()
        {
            string nombre = nombresJugadores[rand.Next(nombresJugadores.Length)];
            string posicion = posiciones[rand.Next(posiciones.Length)];
            int numeroCamiseta = rand.Next(1, 100);

            return new Jugador(nombre)
            {
                Posicion = posicion,
                NumeroCamiseta = numeroCamiseta
            };
        }
        // Crea un club con nombre único combinando prefijo y ciudad.
        public static Club CrearClub()
        {
            string nombreClub = $"{nombresClubs[rand.Next(nombresClubs.Length)]} {ciudades[rand.Next(ciudades.Length)]}";

            int intentos = 0;
            while (Program.clubs.Exists(c => c.Nombre == nombreClub) && intentos < 10)
            {
                nombreClub = $"{nombresClubs[rand.Next(nombresClubs.Length)]} {ciudades[rand.Next(ciudades.Length)]}";
                intentos++;
            }

            return new Club(nombreClub);
        }
        /// Genera todos los datos iniciales del sistema: clubs, equipos y jugadores.
        public static void GenerarDatosIniciales()
        {
            Program.equipos.Clear();
            Program.clubs.Clear();
            Program.partidos.Clear();

            // Crea 4 clubs
            for (int i = 0; i < 4; i++)
            {
                Program.clubs.Add(CrearClub());
            }

            // Crea 12 equipos y los asigna a clubs aleatorios
            for (int i = 0; i < 12; i++)
            {
                var equipo = CrearEquipo();
                Program.equipos[equipo.Nombre] = equipo;

                var club = Program.clubs[rand.Next(Program.clubs.Count)];
                club.AltaEquipo(equipo);
            }

            var Partido = CrearPartidos(5);


            Console.WriteLine($" Generados: {Program.clubs.Count} clubs, {Program.equipos.Count} equipos" +
                $"{Program.partidos.Count} partidos");
        }

        public static List<Partido> CrearPartidos(int cantidad)
        {
            if (Program.equipos.Count < 2)
            {
                Console.WriteLine("No hay suficientes equipos para generar partidos.");
                return null;
            }

            var partidosCreados = new List<Partido>();
            var listaEquipos = Program.equipos.Values.ToList();
            int generados = 0;
            var existentes = new HashSet<string>(Program.partidos.Select(p => p.Local.Nombre + "|" + p.Visitante.Nombre));

            for (int i = 0; i < cantidad; i++)
            {
                var local = listaEquipos[rand.Next(listaEquipos.Count)];
                var visitante = listaEquipos[rand.Next(listaEquipos.Count)];

                if (local == visitante) { i--; continue; }

                string clave = local.Nombre + "|" + visitante.Nombre;
                if (existentes.Contains(clave)) { i--; continue; }

                Program.partidos.Add(new Partido(local, visitante));
                partidosCreados.Add(new Partido(local, visitante));
                existentes.Add(clave);
                generados++;
            }

            //Console.WriteLine($"Partidos generados: {generados}");
            return partidosCreados;
        }
    }
}
