using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Forma2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Diagrama d = new Diagrama();

            d.AddForma(new Elipse(2, 3));       // 18.85
            d.AddForma(new Circulo(2));         // 12.56
            d.AddForma(new Triangulo(5, 4, 7)); // 9.79
            d.AddForma(new Rectangulo(7, 4));   // 28
            d.AddForma(new Cuadrado(5));        // 25
            d.AddForma(new Rombo(4, 40));       // 10.2848

            Console.WriteLine(d.ToString());    // 106,1356960747

            Console.ReadKey();
        }
    }
}
