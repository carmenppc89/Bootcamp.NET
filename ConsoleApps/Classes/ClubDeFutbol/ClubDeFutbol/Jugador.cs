using System;

namespace ClubDeFutbol
{
    // Representa un jugador de fútbol con nombre, posición y número de camiseta.
    // Se utiliza dentro de los equipos generados o creados manualmente.
    public class Jugador
    {
        // Nombre del jugador (puede ser real o generado)
        public string Nombre { get; set; }
        // Posición en el campo (ej. Portero, Defensa, Delantero...)
        public string Posicion { get; set; }
        // Número de camiseta asignado al jugador (entre 1 y 99)
        public int NumeroCamiseta { get; set; }
        // Constructor principal que recibe solo el nombre.
        // Las demás propiedades se pueden asignar después.

        public Jugador(string nombre)
        {
            Nombre = nombre;
            Posicion = "Sin definir";
            NumeroCamiseta = 0;
        }

        //Devuelve una representación textual del jugador.
        //Incluye nombre, posición y número de camiseta.
        public override string ToString()
        {
            return $"{Nombre} - {Posicion} - #{NumeroCamiseta}";
        }
    }
}
