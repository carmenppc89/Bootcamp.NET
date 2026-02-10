using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Hospital
{
    public class Menu
    {
        //private string _opcion { get => _opcion; set => _opcion = value; }
        private string OpcionPrincipal, OpcionHospital, OpcionPacientes, OpcionMedicos, OpcionAdministrativos;

        private string Respuesta;
        public Menu()
        {
            OpcionPrincipal = "";
            OpcionHospital = "";
            OpcionPacientes = "";
            OpcionMedicos = "";
            OpcionAdministrativos = "";
        }

        public void MenuPrincipal(Hospital hospital)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($@"
        === GESTOR HOSPITAL ===
            1.  Hospital
            2.  Pacientes
            3.  Medicos
            4.  Administrativos
            0.  Salir
        ");

                OpcionPrincipal = Console.ReadLine();

                switch (OpcionPrincipal)
                {
                    case "1":
                        MenuHospital(hospital);
                        break;

                    case "2":
                        MenuPacientes(hospital);
                        break;

                    case "3":
                        MenuMedicos(hospital);
                        break;

                    case "4":
                        MenuAdministrativos(hospital);
                        break;

                    default:
                        break;
                }

                if (OpcionPrincipal != "0") Pausa();
            } while (OpcionPrincipal != "0");

        }

        private void MenuAdministrativos(Hospital hospital)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($@"
        === GESTOR HOSPITAL ===
          = Administrativos =
            1.  Listar Administrativos
            0.  Salir
        ");

                OpcionAdministrativos = Console.ReadLine();

                switch (OpcionAdministrativos)
                {
                    case "1":
                        Console.WriteLine(hospital.ListarPorTipo<Administrativo>());
                        break;

                    default:
                        break;
                }

                if (OpcionAdministrativos != "0") Pausa();
            } while (OpcionAdministrativos != "0");
        }

        private void MenuMedicos(Hospital hospital)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($@"
        === GESTOR HOSPITAL ===
              = Medicos =
            1.  Listar Medicos
            2.  Alta Medicos
            3.  Baja Medicos
            4.  Listar Pacientes de
            5.  Asignar Paciente
            6.  Desasignar Paciente
            0.  Salir
        ");

                OpcionMedicos = Console.ReadLine();

                switch (OpcionMedicos)
                {
                    case "1":   // Listar Medicos
                        //hospital.GetPersonasPorTipo<Medico>().ForEach(medico => Console.WriteLine(medico.ToString()));
                        Console.WriteLine(hospital.ListarPorTipo<Medico>());

                        break;

                    case "2":   // Alta Medicos
                        Medico m = (hospital.AltaPersonaPorConsola<Medico>()) as Medico;

                        Console.WriteLine("Quieres assignarle un paciente? S/N?");
                        string respuesta = Console.ReadLine();
                        if (respuesta == "S" || respuesta == "s")
                            hospital.AsignarPacientePorConsola(m);

                        break;

                    case "3":   // Baja Medicos
                        hospital.BajaPersonaPorConsola<Medico>();

                        break;

                    case "4":   // Listar Paciente de
                        hospital.ListarPacientesDe();

                        break;

                    case "5":   // Asignar Paciente
                        hospital.AsignarPacientePorConsola(null);

                        break;

                    case "6":   // Desasignar Paciente
                        hospital.DesAsignarPacientePorConsola();

                        break;

                    default:
                        break;
                }

                if (OpcionMedicos != "0") Pausa();
            } while (OpcionMedicos != "0");
        }

        private void MenuPacientes(Hospital hospital)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($@"
        === GESTOR HOSPITAL ===
             = Pacientes =
            1.  Listar Pacientes
            2.  Alta Paciente
            3.  Baja Paciente
            4.  Asignar Medico
            5.  Desasignar Medico
            0.  Salir
        ");

                OpcionPacientes = Console.ReadLine();

                switch (OpcionPacientes)
                {
                    case "1":   // Listar Pacientes
                        //hospital.GetPersonasPorTipo<Paciente>().ForEach(paciente => Console.WriteLine(paciente.ToString()));
                        Console.WriteLine(hospital.ListarPorTipo<Paciente>());
                        break;

                    case "2":   // Alta Paciente
                        Paciente p = (hospital.AltaPersonaPorConsola<Paciente>()) as Paciente;

                        Console.WriteLine("Quieres assignarle un medico? S/N?");
                        if (Console.ReadLine().Equals("S"))
                            hospital.AsignarMedicoPorConsola(p);

                        break;

                    case "3":   // Baja Paciente
                        hospital.BajaPersonaPorConsola<Paciente>();
                        break;

                    case "4":   // Asignar Medico
                        hospital.AsignarMedicoPorConsola(null);
                        break;

                    case "5":   // Desasignar Medico
                        hospital.DesAsignarMedicoPorConsola();
                        break;

                    default:
                        break;
                }

                if (OpcionPacientes != "0") Pausa();
            } while (OpcionPacientes != "0");
        }

        private void MenuHospital(Hospital hospital)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($@"
        === GESTOR HOSPITAL ===
              = Hospital =
            1.  Listar Personas
            0.  Salir
        ");

                OpcionHospital = Console.ReadLine();

                switch (OpcionHospital)
                {
                    case "1":
                        Console.WriteLine(hospital.ToString());
                        break;

                    default:
                        break;
                }

                if (OpcionHospital != "0") Pausa();
            } while (OpcionHospital != "0");
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine(); // Espera que el usuario presione Enter
        }

    }
}

