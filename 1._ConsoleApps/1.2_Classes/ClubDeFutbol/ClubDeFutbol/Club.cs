using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json; // Serialización JSON compatible con .NET Framework

namespace ClubDeFutbol
{
    public class Club
    {
        public string Nombre { get; set; }
        public List<Equipo> Equipos { get; set; }

        // Rotamos entrenadores al dar de alta equipos
        private static int indiceEntrenador = 0;
        private static string[] entrenadores = { "Pepe", "Carlo", "Diego" };

        public Club(string nombre)
        {
            Nombre = nombre;
            Equipos = new List<Equipo>();
        }

        // Alta de equipo: añade al club, asigna entrenador y afiliación
        public void AltaEquipo(Equipo equipo)
        {
            if (!Equipos.Contains(equipo))
            {
                Equipos.Add(equipo);
                equipo.Afiliado = this;
                equipo.Entrenador = entrenadores[indiceEntrenador];
                indiceEntrenador = (indiceEntrenador + 1) % entrenadores.Length;
            }
        }

        // Baja de equipo: desasocia del club y quita entrenador
        public void BajaEquipo(Equipo equipo)
        {
            if (Equipos.Remove(equipo))
            {
                equipo.Afiliado = null;
                equipo.Entrenador = null;
            }
        }

        // Crear club desde consola (usado por Program)
        public static void CrearClub(List<Club> clubs)
        {
            Console.Write("Nombre del club: ");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre) && !clubs.Any(c => c.Nombre == nombre))
            {
                clubs.Add(new Club(nombre));
                Console.WriteLine("Club creado");
            }
            else Console.WriteLine("Nombre inválido o club ya existe");
        }

        // Baja de club desde consola: desasocia sus equipos
        public static void BajaClub(List<Club> clubs, Dictionary<string, Equipo> equipos)
        {
            Console.Write("Número del club a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= clubs.Count)
            {
                var club = clubs[idx - 1];
                foreach (var eq in club.Equipos.ToList())
                    club.BajaEquipo(eq);
                clubs.Remove(club);
                Console.WriteLine("Club dado de baja");
            }
            else Console.WriteLine("Club no válido");
        }

        // Listado para consola (usado por Program y Equipo.CrearEquipo)
        public static string ListarClubs(List<Club> clubs)
        {
            var lista = "=== CLUBS ===\n";
            for (int i = 0; i < clubs.Count; i++)
                lista += $"{i + 1}. {clubs[i]}\n";
            return lista;
        }

        // Ver equipos del club (usado por Program)
        public static void VerEquiposClub(List<Club> clubs)
        {
            Console.Write("Número del club: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= clubs.Count)
            {
                var club = clubs[idx - 1];
                Console.WriteLine($"\n=== EQUIPOS DEL CLUB {club.Nombre.ToUpper()} ===");

                // Agrupamos por entrenador
                var grupos = club.Equipos.GroupBy(e => e.Entrenador ?? "Sin entrenador");

                foreach (var grupo in grupos.OrderBy(g => g.Key))
                {
                    Console.WriteLine($"\nEntrenador: {grupo.Key}");
                    foreach (var equipo in grupo.OrderBy(e => e.Nombre))
                    {
                        Console.WriteLine($"  - {equipo.Nombre} ({equipo.Puntuacion} pts)");
                    }
                }
            }
            else Console.WriteLine("Club no válido");
        }
        public override string ToString() => $"{Nombre} ({Equipos.Count} equipos)";

        // DTO: guardamos referencias por nombre para evitar ciclos
        public class ClubDTO
        {
            public string Nombre { get; set; }
            public List<string> NombresEquipos { get; set; }
        }

        // Guardar clubs a JSON (usado por Program)
        public static void GuardarClubs(List<Club> clubs, string ruta)
        {
            var dtos = clubs.Select(c => new ClubDTO
            {
                Nombre = c.Nombre,
                NombresEquipos = c.Equipos.Select(e => e.Nombre).ToList()
            }).ToList();

            var json = JsonConvert.SerializeObject(dtos, Formatting.Indented);
            File.WriteAllText(ruta, json);
            Console.WriteLine($"Clubs guardados en {ruta}");
        }

        // Cargar clubs desde JSON (usado por Program)
        public static void CargarClubs(List<Club> clubs, string ruta)
        {
            if (!File.Exists(ruta)) return;

            try
            {
                var json = File.ReadAllText(ruta);
                var dtos = JsonConvert.DeserializeObject<List<ClubDTO>>(json) ?? new List<ClubDTO>();
                clubs.Clear();
                foreach (var dto in dtos)
                    clubs.Add(new Club(dto.Nombre));

                Console.WriteLine($"Clubs cargados desde {ruta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar clubs: {ex.Message}");
            }
        }
    }
}


