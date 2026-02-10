using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_DiaDeLaSemana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strDia = "";
            int intNum;

            strDia = EntradaDeDatos();
            intNum = DiaANumero(strDia);

            if (intNum != 0)
                Console.WriteLine("El resultado es: " + intNum);
            else
                Console.WriteLine(@"    !!! ->  No es valido");

            Console.WriteLine(@"    ->  Pulse cualquier tecla para salir.");
            Console.ReadKey();
        }

        static string EntradaDeDatos()
        {
            Console.WriteLine(@"
Escriba uno de los siguientes dias de la semana: (sin accentos)
- Lunes, Martes, Miercoles, Jueves, Viernes, Sabado o Domingo");

            string strInput = Console.ReadLine();
            return strInput.Trim().ToLower();
        }

        static int DiaANumero(string strDia)
        {
            switch (strDia)
            {
                case "lunes":
                    return 1;
                case "martes":
                    return 2;
                case "miercoles":
                    return 3;
                case "jueves":
                    return 4;
                case "viernes":
                    return 5;
                case "sabado":
                    return 6;
                case "domingo":
                    return 7;
                default:
                    return 0;
            }
        }

    }
}
