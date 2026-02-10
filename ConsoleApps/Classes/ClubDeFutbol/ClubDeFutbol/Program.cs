using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ClubDeFutbol; // Importa las clases definidas en el proyecto (Club, Equipo, Partido, etc.)

class Program
{
    // Diccionario de equipos: clave = nombre del equipo, valor = objeto Equipo
    public static Dictionary<string, Equipo> equipos = new Dictionary<string, Equipo>();

    // Lista de clubs
    public static List<Club> clubs = new List<Club>();

    // Lista de partidos
    public static List<Partido> partidos = new List<Partido>();

    // Punto de entrada del programa
    static void Main()
    {
        // Carga inicial de datos desde archivos JSON si existen
        Club.CargarClubs(clubs, "clubs.json");
        Equipo.CargarEquipos(equipos, clubs, "equipos.json");
        Partido.CargarPartidos(partidos, equipos, "partidos.json");

        Generador.GenerarDatosIniciales();
        // Muestra el menú principal
        MenuPrincipal();
    }
    // MENÚ PRINCIPAL
    static void MenuPrincipal()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== GESTOR CLUB DE FUTBOL ===");
            Console.WriteLine("1. Equipos");
            Console.WriteLine("2. Clubs");
            Console.WriteLine("3. Partidos");
            Console.WriteLine("0. Salir");
            opcion = Console.ReadLine();

            // Redirige a cada submenú según la opción elegida

            switch (opcion)
            {
                case "1":
                    MenuEquipos();
                    break;
                case "2":
                    MenuClubs();
                    break;
                case "3":
                    MenuPartidos();
                    break;
                default:
                    break;
            }

            if (opcion != "0") Pausa();
        } while (opcion != "0");
    }
    // MENÚ DE EQUIPOS
    static void MenuEquipos()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== EQUIPOS ===");
            Console.WriteLine("1. Listar equipos");
            Console.WriteLine("2. Crear equipo");
            Console.WriteLine("3. Ver jugadores");
            Console.WriteLine("4. Dar de baja equipo");
            Console.WriteLine("0. Volver");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine(Equipo.ListarEquipos(equipos));
                    break;

                case "2":
                    Equipo.CrearEquipo(equipos, clubs);
                    // Guardado automático
                    Equipo.GuardarEquipos(equipos, "equipos.json");
                    break;

                case "3":
                    Equipo.VerJugadoresEquipo(equipos);
                    break;

                case "4":
                    Equipo.BajaEquipo(equipos, clubs);
                    Equipo.GuardarEquipos(equipos, "equipos.json");
                    break;

                default:
                    break;
            }

            if (opcion != "0") Pausa();
        } while (opcion != "0");
    }

    // MENÚ DE CLUBS
    static void MenuClubs()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== CLUBS ===");
            Console.WriteLine("1. Listar clubs");
            Console.WriteLine("2. Crear club");
            Console.WriteLine("3. Ver equipos del club");
            Console.WriteLine("4. Dar de baja club");
            Console.WriteLine("0. Volver");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine(Club.ListarClubs(clubs));
                    break;

                case "2":
                    Club.CrearClub(clubs);
                    Club.GuardarClubs(clubs, "clubs.json");
                    break;
                case "3":
                    Club.VerEquiposClub(clubs);
                    break;

                case "4":
                    Club.BajaClub(clubs, equipos);
                    Club.GuardarClubs(clubs, "clubs.json");
                    break;

                default:
                    break;
            }

            if (opcion != "0") Pausa();
        } while (opcion != "0");
    }
    // MENÚ DE PARTIDOS
    static void MenuPartidos()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== PARTIDOS ===");
            Console.WriteLine("1. Listar partidos");
            Console.WriteLine("2. Crear partido manual");
            Console.WriteLine("3. Generar partidos aleatorios");
            Console.WriteLine("4. Jugar un partido");
            Console.WriteLine("5. Jugar todos los pendientes");
            Console.WriteLine("0. Volver");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine(Partido.ListarPartidos(partidos));
                    break;

                case "2":
                    Partido.CrearPartido(equipos, partidos);
                    Partido.GuardarPartidos(partidos, "partidos.json");
                    break;

                case "3":
                    Partido.CrearPartido(equipos, partidos);
                    Partido.GuardarPartidos(partidos, "partidos.json");
                    break;

                case "4":
                    Partido.JugarPartido(partidos);
                    Partido.GuardarPartidos(partidos, "partidos.json");
                    break;

                case "5":
                    Partido.JugarTodosPendientes(partidos);
                    Partido.GuardarPartidos(partidos, "partidos.json");
                    break;

                default:
                    break;
            }

            if (opcion != "0") Pausa();
        } while (opcion != "0");
    }
    // MÉTODO AUXILIAR DE PAUSA MEJORA LA EXPERIENCIA DE USUARIO
    static void Pausa()
    {
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine(); // Espera que el usuario presione Enter
    }
}
