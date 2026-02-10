using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ClubDeFutbol
{
    // Clase que representa un partido entre dos equipos
    public class Partido
    {
        public Equipo Local { get; set; }
        public Equipo Visitante { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public bool Jugado { get; set; }

        public Partido(Equipo local, Equipo visitante)
        {
            Local = local;
            Visitante = visitante;
            Jugado = false;
            GolesLocal = 0;
            GolesVisitante = 0;
        }

        public void JugarPartido()
        {
            var rand = new Random();
            GolesLocal = rand.Next(0, 5);
            GolesVisitante = rand.Next(0, 5);
            Jugado = true;

            if (GolesLocal > GolesVisitante)
                Local.ModificarPuntuacion(3);
            else if (GolesVisitante > GolesLocal)
                Visitante.ModificarPuntuacion(3);
            else
            {
                Local.ModificarPuntuacion(1);
                Visitante.ModificarPuntuacion(1);
            }
        }

        public static void CrearPartido(Dictionary<string, Equipo> equipos, List<Partido> partidos)
        {
            if (equipos.Count < 2)
            {
                Console.WriteLine("No hay suficientes equipos para crear un partido.");
                return;
            }

            Console.WriteLine("\n=== EQUIPOS DISPONIBLES ===");
            var lista = equipos.Values.ToList();
            for (int i = 0; i < lista.Count; i++)
                Console.WriteLine($"{i + 1}. {lista[i].Nombre} ({lista[i].Puntuacion} pts)");

            Console.Write("\nElige el número del equipo local: ");
            if (!int.TryParse(Console.ReadLine(), out int idxLocal) || idxLocal < 1 || idxLocal > lista.Count)
            {
                Console.WriteLine("Selección inválida.");
                return;
            }

            Console.Write("Elige el número del equipo visitante: ");
            if (!int.TryParse(Console.ReadLine(), out int idxVisitante) || idxVisitante < 1 || idxVisitante > lista.Count || idxVisitante == idxLocal)
            {
                Console.WriteLine("Selección inválida.");
                return;
            }

            var local = lista[idxLocal - 1];
            var visitante = lista[idxVisitante - 1];

            partidos.Add(new Partido(local, visitante));
            Console.WriteLine($"Partido creado: {local.Nombre} vs {visitante.Nombre}");
        }

        public static void JugarPartido(List<Partido> partidos)
        {
            if (partidos.Count == 0)
            {
                Console.WriteLine("No hay partidos disponibles.");
                return;
            }

            Console.WriteLine("\n=== PARTIDOS DISPONIBLES ===");
            for (int i = 0; i < partidos.Count; i++)
            {
                var p = partidos[i];
                var marcador = p.Jugado ? $"{p.GolesLocal}-{p.GolesVisitante}" : "pendiente";
                Console.WriteLine($"{i + 1}. {p.Local.Nombre} vs {p.Visitante.Nombre} ({marcador})");
            }

            Console.Write("\nElige el número del partido a jugar: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= partidos.Count)
            {
                var p = partidos[idx - 1];
                if (p.Jugado)
                {
                    Console.WriteLine("Ese partido ya fue jugado.");
                }
                else
                {
                    p.JugarPartido();
                    Console.WriteLine($"\nResultado final: {p.Local.Nombre} {p.GolesLocal} - {p.GolesVisitante} {p.Visitante.Nombre}");

                    if (p.GolesLocal > p.GolesVisitante)
                        Console.WriteLine($" Ganador: {p.Local.Nombre} (+3 pts)");
                    else if (p.GolesVisitante > p.GolesLocal)
                        Console.WriteLine($"Ganador: {p.Visitante.Nombre} (+3 pts)");
                    else
                        Console.WriteLine("Empate: ambos equipos suman 1 punto");

                    Console.WriteLine("\nPresiona Enter para volver al menú...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Selección inválida.");
            }
        }

        public static void JugarTodosPendientes(List<Partido> partidos)
        {
            int pendientes = partidos.Count(p => !p.Jugado);
            foreach (var p in partidos.Where(p => !p.Jugado))
                p.JugarPartido();

            Console.WriteLine($"Se jugaron {pendientes} partidos pendientes.");
        }

        public static string ListarPartidos(List<Partido> partidos)
        {
            var lista = "=== PARTIDOS ===\n";
            for (int i = 0; i < partidos.Count; i++)
            {
                var p = partidos[i];
                var marcador = p.Jugado ? $"{p.GolesLocal}-{p.GolesVisitante}" : "-";
                lista += $"{i + 1}. {p.Local.Nombre} {marcador} {p.Visitante.Nombre}\n";
            }
            return lista;
        }

        public override string ToString()
        {
            var marcador = Jugado ? $"{GolesLocal}-{GolesVisitante}" : "-";
            return $"{Local.Nombre} {marcador} {Visitante.Nombre}";
        }

        // Clase auxiliar para pasar a JSON
        public class PartidoDTO
        {
            public string LocalNombre { get; set; }
            public string VisitanteNombre { get; set; }
            public int GolesLocal { get; set; }
            public int GolesVisitante { get; set; }
            public bool Jugado { get; set; }
        }

        public static void GuardarPartidos(List<Partido> partidos, string ruta)
        {
            var dtos = partidos.Select(p => new PartidoDTO
            {
                LocalNombre = p.Local?.Nombre,
                VisitanteNombre = p.Visitante?.Nombre,
                GolesLocal = p.GolesLocal,
                GolesVisitante = p.GolesVisitante,
                Jugado = p.Jugado
            }).ToList();

            var json = JsonConvert.SerializeObject(dtos, Formatting.Indented);
            File.WriteAllText(ruta, json);
            Console.WriteLine($"Partidos guardados en {ruta}");
        }

        public static void CargarPartidos(List<Partido> partidos, Dictionary<string, Equipo> equipos, string ruta)
        {
            if (!File.Exists(ruta)) return;

            try
            {
                var json = File.ReadAllText(ruta);
                var dtos = JsonConvert.DeserializeObject<List<PartidoDTO>>(json) ?? new List<PartidoDTO>();

                partidos.Clear(); // Elimina todos los partidos existentes para cargar los nuevos
                foreach (var dto in dtos) //bucle recorre cada DTO (Data Transfer Object) y crea los objetos Partido reales
                {
                    if (equipos.ContainsKey(dto.LocalNombre) && equipos.ContainsKey(dto.VisitanteNombre))
                    {
                        var partido = new Partido(equipos[dto.LocalNombre], equipos[dto.VisitanteNombre]) // CREAR NUEVO OBJETO PARTIDO
                        {
                            GolesLocal = dto.GolesLocal,
                            GolesVisitante = dto.GolesVisitante,
                            Jugado = dto.Jugado
                        };
                        partidos.Add(partido);
                    }
                }

                Console.WriteLine($"Partidos cargados desde {ruta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar partidos: {ex.Message}");
                //Captura cualquier error durante la carga (archivo corrupto, JSON mal formado, etc.)
            }
        }
    }
}
