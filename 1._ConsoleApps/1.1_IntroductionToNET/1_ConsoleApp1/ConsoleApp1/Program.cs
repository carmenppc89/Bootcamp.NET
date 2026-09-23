using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MENU
            int opc;
            do
            {
                Console.WriteLine("---------------------------\n     -     MENU     -\n" +
                    "---------------------------\nIntroduce una opcion: \n   " +
                    "1. Texto\n   2. Division entera \n   3. Media\n   4. Comparar fechas\n   5. camelCase" +
                    "\n   6. Palindromo de texto\n   7. Palindromo de numero\n   0. exit\n");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        texto();
                        break;
                    case 2:
                        div();
                        break;
                    case 3:
                        media();
                        break;
                    case 4:
                        fechas();
                        break;
                    case 5:
                        camelCase();
                        break;
                    case 6:
                        palindromoTXT();
                        break;
                    case 7:
                        palindromoNUM();
                        break;
                    case 0:
                        break;
                }
            } while (opc != 0);

            // Console.ReadKey();
        }

        // Ejercicio de practica de entrada y impresion de datos por consola
        static void texto()
        {
            Console.WriteLine("---------------------------\n          - TEXTO -\n" +
                    "---------------------------\n - Introduzaca un texto: ");
            string texto = Console.ReadLine();
            Console.WriteLine("Hello world! - " + texto);

            Console.WriteLine("Introduzaca un numero: ");
            string strNum = Console.ReadLine();
            int num = int.Parse(strNum);
            Console.WriteLine("   + strNum - " + strNum + "\nnum - " + num);
        }

        // Saca el quociente entero de una division
        static void div()
        {
            Console.WriteLine("---------------------------\n   - DIVISION ENTERA -\n" +
                    "---------------------------\n");
            Console.WriteLine("Introduce el numerador de la division:");
            int numerador = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el denominador de la division:");
            int denominador = int.Parse(Console.ReadLine());
            int intRes = 0;

            while (numerador >= denominador)
            {
                numerador = numerador - denominador;
                intRes++;
            }

            Console.WriteLine("   + El resultado es: " + intRes + "\n\n");
        }

        // La media entre x numeros
        static void media()
        {
            Console.WriteLine("---------------------------\n        - MEDIA -\n" +
                    "---------------------------\n");
            Console.WriteLine("Introduce cuantos numeros quieres introducir: ");
            int longitudSerie = int.Parse(Console.ReadLine());
            int[] serie = new int[longitudSerie];

            for (int i = 0; i < longitudSerie; i++)
            {
                Console.WriteLine("Introduce un numero: ");
                serie[i] = int.Parse(Console.ReadLine());
            }

            int suma = 0;
            for (int i = 0; i < longitudSerie; i++)
            {
                suma = suma + serie[i];
            }
            Console.WriteLine("   + El resultado es: " + (suma / longitudSerie) + "\n\n");
        }

        // Elige la fecha mas grande. Formato dd-mm-aa.
        static void fechas()
        {
            string res;
            Console.WriteLine("---------------------------\n        - FECHAS -\n" +
                   "---------------------------\n");
            Console.WriteLine("Introduce la primera fecha (dd-mm-aaaa): !! CON GUIONES");
            string f1 = Console.ReadLine();
            string[] fecha1 = f1.Split('-');
            int diaF1 = int.Parse(fecha1[0]);
            int mesF1 = int.Parse(fecha1[1]);
            int añoF1 = int.Parse(fecha1[2]);

            Console.WriteLine("Introduce la segunda fecha (dd-mm-aaaa): !! CON GUIONES");
            string f2 = Console.ReadLine();
            string[] fecha2 = f2.Split('-');
            int diaF2 = int.Parse(fecha2[0]);
            int mesF2 = int.Parse(fecha2[1]);
            int añoF2 = int.Parse(fecha2[2]);

            if (añoF1 == añoF2)
            {
                if (mesF1 == mesF2)
                {
                    if (diaF1 == diaF2)
                        res = "Son iguales.";
                    else
                    {
                        if (diaF1 > diaF2)
                            res = "La fecha: " + f1 + " es más grande.";
                        else
                            res = "La fecha: " + f2 + " es más grande.";
                    }
                }
                else
                {
                    if (mesF1 > mesF2)
                        res = "La fecha: " + f1 + " es más grande.";
                    else
                        res = "La fecha: " + f2 + " es más grande.";
                }
            }
            else
            {
                if (añoF1 > añoF2)
                    res = "La fecha: " + f1 + " es más grande.";
                else
                    res = "La fecha: " + f2 + " es más grande.";
            }

            Console.WriteLine("   + El resultado es: " + res + "\n\n");
        }

        // Pasar un texto a camelCase
        static void camelCase()
        {
            Console.WriteLine("---------------------------\n        - camelCase -\n" +
                   "---------------------------\n");
            Console.WriteLine("Escribe una frase a la que pasar por camelCase: ");
            char[] frase = Console.ReadLine().ToCharArray();
            string res = "";
            res += Char.ToLower(frase[0]);
            for (int i = 1; i < frase.Length; i++)
            {
                if (frase[i] == ' ')
                {
                    i++;
                    res += Char.ToUpper(frase[i]);
                }
                else
                {
                    res += Char.ToLower(frase[i]);
                }
            }
            Console.WriteLine("   + El resultado es: " + res + "\n\n");
        }

        // Decir si una frase es un palindromo
        static void palindromoTXT()
        {
            Console.WriteLine("---------------------------\n   - Palindromo de Texto -\n" +
                   "---------------------------\n");
            Console.WriteLine("Escirbe el posible palindromo: ");
            char[] palindromo = Console.ReadLine().ToCharArray();
            bool flag = true;

            for (int i = 0; i < (palindromo.Length / 2); i++)
            {
                //for (int j = (palindromo.Length / 2) - 1; j >= 0; j--) { }
                if (!palindromo[i].Equals(palindromo[(palindromo.Length - 1) - i]))
                {
                    flag = false;
                    break;
                }
            }
            Console.WriteLine(flag ?
                "   + El resultado es: Es palindromo" :
                "   + El resultado es: NO Es palindromo");
        }
        
        // Decir si un numero es un palindromo
        static void palindromoNUM()
        {
            Console.WriteLine("---------------------------\n   - Palindromo de Texto -\n" +
                  "---------------------------\n");
            Console.WriteLine("Escirbe el posible palindromo: ");
            int palindromo = int.Parse(Console.ReadLine());
            bool flag = true;
            //int digits = palindromo.ToString().Length;

            for (int digits = palindromo.ToString().Length; digits > 1; digits--)
            {
                if (((palindromo % 10) * 10) != (palindromo / (10 ^ (digits - 1))))
                {
                    flag = false;
                    break;
                }
                else
                {
                    palindromo = palindromo / 10;
                    digits--;
                }
            }


            Console.WriteLine(flag ?
                "   + El resultado es: Es palindromo" :
                "   + El resultado es: NO Es palindromo");
        }

    }
}
