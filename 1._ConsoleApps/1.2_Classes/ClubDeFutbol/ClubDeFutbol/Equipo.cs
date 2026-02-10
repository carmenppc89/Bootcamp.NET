using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json; // Usamos para guardar y cargar datos en formato JSON

namespace ClubDeFutbol
{
    // Clase que representa un equipo de fútbol
    public class Equipo
    {
        // Nombre del equipo
        public string Nombre { get; set; }

        // Lista de jugadores que pertenecen al equipo
        public List<Jugador> Jugadores { get; set; }

        // Nombre del entrenador asignado al equipo
        public string Entrenador { get; set; }

        // Puntuación acumulada del equipo (por partidos jugados)
        public int Puntuacion { get; set; }

        // Referencia al club al que pertenece el equipo (puede ser null si no está afiliado)
        public Club Afiliado { get; set; }

        // Constructor: inicializa el equipo con nombre y lista vacía de jugadores
        public Equipo(string nombre)
        {
            Nombre = nombre;
            Jugadores = new List<Jugador>();
            Puntuacion = 0;
        }

        // Método modifica la puntuación del equipo (usado al jugar partidos)
        // puntos a sumar (3 por victoria y 1 por empate)
        public void ModificarPuntuacion(int puntos) => Puntuacion += puntos;

        // Agrega una cantidad de jugadores generados automáticamente
        public void AgregarJugadores(int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
                Jugadores.Add(Generador.CrearJugador()); // Llama al generador(aleatorio) para crear jugadores ficticios
        }

        // Crea un equipo desde consola, con opción de asignarlo a un club
        public static void CrearEquipo(Dictionary<string, Equipo> equipos, List<Club> clubs)
        {
            Console.Write("Nombre del equipo: ");
            string nombre = Console.ReadLine();

            // Verifica que el nombre no esté repetido y no sea vacío
            if (!equipos.ContainsKey(nombre) && !string.IsNullOrWhiteSpace(nombre))
            {
                var equipo = new Equipo(nombre);
                equipo.AgregarJugadores(11); // Añade 11 jugadores automáticamente
                equipos[nombre] = equipo;//agrega al diccionario
                Console.WriteLine("Equipo creado con 11 jugadores");

                // Si hay clubs disponibles, ofrece asignar el equipo a uno
                if (clubs.Count > 0)
                {
                    Console.WriteLine("¿Asignar a club? (s/n)");
                    if ((Console.ReadLine() ?? "").ToLower() == "s")
                    {
                        Console.WriteLine(Club.ListarClubs(clubs)); // Muestra lista de clubs
                        Console.Write("Número del club: ");
                        if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= clubs.Count)
                        {
                            // idx → índice numérico del club elegido (1-based)
                            clubs[idx - 1].AltaEquipo(equipo); // Asocia el equipo al club y asigna entrenador
                            Console.WriteLine($"Equipo asignado a {clubs[idx - 1].Nombre}");
                        }
                    }
                }
            }
            else Console.WriteLine("El equipo ya existe o nombre inválido");
        }

        // Elimina un equipo del sistema y lo desasocia del club si corresponde
        public static void BajaEquipo(Dictionary<string, Equipo> equipos, List<Club> clubs)
        {
            Console.WriteLine(ListarEquipos(equipos));

            Console.WriteLine("Nombre del equipo a eliminar: ");
            var nombre = Console.ReadLine();

            if (equipos.ContainsKey(nombre))
            {
                var equipo = equipos[nombre];

                // Si el equipo está afiliado a un club, lo desasociamos
                if (equipo.Afiliado != null)
                    equipo.Afiliado.BajaEquipo(equipo);

                equipos.Remove(nombre); // Lo quitamos del diccionario
                Console.WriteLine("Equipo dado de baja");
            }
            else Console.WriteLine("Equipo no encontrado");
        }

        // Muestra todos los equipos agrupados por entrenador
        public static string ListarEquipos(Dictionary<string, Equipo> equipos)
        {
            var lista = "=== EQUIPOS ===\n";

            // Agrupa los equipos por entrenador usando GroupBy
            // e => e.Entrenador → expresión lambda que accede al entrenador de cada equipo 'e'
            // ?? "Sin entrenador" → si el entrenador es null, usamos "Sin entrenador"
            var grupos = equipos.Values.GroupBy(e => e.Entrenador ?? "Sin entrenador");

            foreach (var grupo in grupos.OrderBy(g => g.Key)) // Ordenamos los grupos por nombre del entrenador
            {
                //g = cada grupo de equipo y g.Key = el entrenador de ese grupo
                lista += $"\nEntrenador: {grupo.Key}\n";
                //+= = va acumulando texto , e = cada equipo dentro de un grupo
                foreach (var equipo in grupo.OrderBy(e => e.Nombre)) // Ordenamos los equipos por nombre 
                                                                     //OrderBy()= orden alfabéticamente para mostrar la información organizada
                {
                    // Mostramos solo nombre y puntuación, sin repetir el entrenador
                    lista += $"  - {equipo.Nombre} ({equipo.Puntuacion} pts)\n";
                }
            }

            return lista;
        }

        // Muestra los jugadores de un equipo específico
        public static void VerJugadoresEquipo(Dictionary<string, Equipo> equipos)
        {
            Console.WriteLine(ListarEquipos(equipos)); // Muestra lista antes de pedir nombre
            Console.Write("Nombre del equipo: ");
            string nombre = Console.ReadLine();

            if (equipos.ContainsKey(nombre))
            {
                var equipo = equipos[nombre];
                Console.WriteLine($"\n=== JUGADORES DE {equipo.Nombre.ToUpper()} ===");
                Console.WriteLine($"Entrenador: {equipo.Entrenador ?? "Sin asignar"}");
                Console.WriteLine("----------------------------------------");

                for (int i = 0; i < equipo.Jugadores.Count; i++)
                {
                    var jugador = equipo.Jugadores[i];
                    Console.WriteLine($"{i + 1}. {jugador.Nombre} - {jugador.Posicion} - Camiseta #{jugador.NumeroCamiseta}");
                }
            }
            else Console.WriteLine("Equipo no encontrado");
        }

        // Representación textual del equipo (usada en otros listados)
        public override string ToString() => $"{Nombre} - {(Entrenador ?? "Sin entrenador")} - {Puntuacion} pts";

        // DTO para guardar equipos en JSON sin referencias circulares
        public class EquipoDTO
        {
            public string Nombre { get; set; }
            public string Entrenador { get; set; }
            public int Puntuacion { get; set; }
            public string AfiliadoNombre { get; set; } // Solo guardamos el nombre del club
            public List<Jugador> Jugadores { get; set; }
        }

        // Guarda todos los equipos en archivo JSON
        public static void GuardarEquipos(Dictionary<string, Equipo> equipos, string ruta)
        {
            var dtos = equipos.Values.Select(e => new EquipoDTO
            {
                Nombre = e.Nombre,
                Entrenador = e.Entrenador,
                Puntuacion = e.Puntuacion,
                AfiliadoNombre = e.Afiliado?.Nombre,
                Jugadores = e.Jugadores
            }).ToList();

            var json = JsonConvert.SerializeObject(dtos, Formatting.Indented);
            File.WriteAllText(ruta, json);
            Console.WriteLine($"Equipos guardados en {ruta}");
        }

        // Carga equipos desde archivo JSON y reconstruye afiliación al club
        public static void CargarEquipos(Dictionary<string, Equipo> equipos, List<Club> clubs, string ruta)
        {
            if (!File.Exists(ruta)) return;

            try
            {
                var json = File.ReadAllText(ruta);
                var dtos = JsonConvert.DeserializeObject<List<EquipoDTO>>(json) ?? new List<EquipoDTO>();

                equipos.Clear();

                foreach (var dto in dtos)
                {
                    var equipo = new Equipo(dto.Nombre)
                    {
                        Entrenador = dto.Entrenador,
                        Puntuacion = dto.Puntuacion,
                        Jugadores = dto.Jugadores ?? new List<Jugador>()
                    };

                    // Si el equipo tiene club asignado, lo buscamos por nombre y lo reasignamos
                    if (!string.IsNullOrWhiteSpace(dto.AfiliadoNombre))
                    {
                        var club = clubs.FirstOrDefault(c => c.Nombre == dto.AfiliadoNombre);
                        if (club != null) club.AltaEquipo(equipo); // Usa AltaEquipo para mantener lógica de asignación
                    }

                    equipos[equipo.Nombre] = equipo;
                }

                Console.WriteLine($"Equipos cargados desde {ruta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar equipos: {ex.Message}");
            }
        }
    }
}
