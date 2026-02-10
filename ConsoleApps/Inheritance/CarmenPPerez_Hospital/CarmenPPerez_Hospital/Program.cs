using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Hospital
{
    internal class Program
    {
        static private Hospital Hospital;
        static void Main(string[] args)
        {
            Hospital = new Hospital("Ada Lovelace");

            GeneradorDeDemo GDD = new GeneradorDeDemo();

            GDD.GenerarMedicos(Hospital, 5);
            GDD.GenerarPacientes(Hospital, 10);
            GDD.GenerarAdministrativos(Hospital, 5);

            Menu Mnu = new Menu();

            Mnu.MenuPrincipal(Hospital);

            Console.WriteLine("Yata");
            Console.ReadKey();
        }

    }

}