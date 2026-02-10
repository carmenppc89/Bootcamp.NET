using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraductorDeMorse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>() {
                { "a", ".-" }, { "b", "-..." }, { "c", "-.-." }, { "d", "-.." }, { "e", "." },
                { "f", "..-." }, { "g", "--." }, { "h", "...." }, { "i", ".." }, { "j", ".---" },
                { "k", "-.-" }, { "l", ".-.." }, { "m", "--" }, { "n", "-." }, { "o", "---" },
                { "p", ".--." }, { "q", "--.-" }, { "r", ".-." }, { "s", "..." }, { "t", "-" },
                { "u", "..-" }, { "v", "...-" }, { "w", ".--" }, { "x", "-..-" }, { "y", "-.--" },
                { "z", "--.." }, { "0", "-----" }, { "1", ".----" }, { "2", "..---" }, { "3", "...--" },
                { "4", "....-" }, { "5", "....." }, { "6", "-...." }, { "7", "--..." }, { "8", "---.." }, { "9", "----." }};

            string strEntrada;
            List<string> listEntradaDesglosada = new List<string>();
            List<string> listTraducida = new List<string>();
            string strTraduccion = "";

            do
            {
                strEntrada = "";
                strTraduccion = "";
                listEntradaDesglosada.Clear();
                listTraducida.Clear();

                Console.WriteLine("\nIntroduzca su texto a traducir: ");
                strEntrada = Console.ReadLine();

                // Comprobar si la entrada es enteramente morse o letras
                // + De Morse a Letras +
                if (strEntrada.All(x => x.Equals('.') || x.Equals('-') || x.Equals(' ')))
                {
                    // Desglosar el string por espacios en una lista
                    listEntradaDesglosada = strEntrada.Split(' ').ToList();
                    // Recorrer el desglose
                    foreach (string m in listEntradaDesglosada)
                    {
                        // Añade la letra(Key) despues de buscar el morse(Value) correspondiente en el diccionario
                        listTraducida.Add(diccionario.First(x => x.Value == m).Key);
                    }
                }
                // + Letras a Morse +
                else if (strEntrada.All(x => !x.Equals('.') || !x.Equals('-') || !x.Equals(' ')))
                {
                    // A partir de la entrada, se pasa a minusculas y se quitan los espacios
                    strEntrada.ToLower().Trim();
                    // Recorrer los caracteres de la entrada
                    foreach (char e in strEntrada)
                    {
                        // Añadir al resultado el valor de la e segun el diccionario
                        listTraducida.Add(diccionario[e + ""]);
                    }
                }
                else
                {
                    // Ha habido caracteres especiales o mezcla de leguajes.
                    Console.WriteLine("No se puede combinar Morse con Letras");
                    break;
                }

                // imprimir el resultado por pantalla
                foreach (string str in listTraducida)
                {
                    strTraduccion = strTraduccion + " " + str;
                }
                Console.WriteLine($" + La traduccion es: {strTraduccion}");

            } while (true);

            Console.WriteLine("\n -> Pulsa cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}
