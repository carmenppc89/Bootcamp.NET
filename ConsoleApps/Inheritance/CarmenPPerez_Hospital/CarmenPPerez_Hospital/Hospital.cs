using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Hospital
{
    public class Hospital
    {
        private string _nombre;
        private List<Persona> _personas;
        public string Nombre { get => _nombre; }
        public List<Persona> ListaPersonas { get => _personas; }

        public Hospital(string nombre)
        {
            _nombre = nombre;
            _personas = new List<Persona>();
        }

        public override string ToString()
        {
            string str = $"\nHospital {Nombre}:\n";
            int contador = 1;

            foreach (Persona p in _personas)
            {
                str += $"{contador++}. {p.ToString()}\n\n";
            }
            return str;
        }

        public string ListarPorTipo<T>() where T : Persona
        {
            string str = $"\nLista de {typeof(T).Name}:\n";
            int contador = 1;

            foreach (Persona p in GetPersonasPorTipo<T>())
            {
                str += $"{contador++}. {p.ToString()}\n\n";
            }
            return str;
        }

        public string ListarPorPersona<T>(List<T> personas) where T : Persona
        {
            string str = $"Listadas:\n";
            int contador = 1;

            foreach (Persona p in personas)
            {
                str += $"{contador++}. {p.ToString()}\n\n";
            }
            return str;
        }

        public Persona AltaPersona(Persona nuevaPersona)
        {
            ListaPersonas.Add(nuevaPersona);
            return nuevaPersona;
        }

        public void BajaPersona(Persona nuevaPersona)
        {
            if (nuevaPersona is Paciente)
                (nuevaPersona as Paciente).DESAssignarMedico();
            if (nuevaPersona is Medico)
            {
                foreach (Paciente p in (nuevaPersona as Medico).ListPacientes)
                {
                    p.DESAssignarMedico();
                }
            }

            ListaPersonas.Remove(nuevaPersona);
        }

        public List<T> GetPersonasPorTipo<T>() where T : Persona
        {
            return ListaPersonas.OfType<T>().ToList();
        }

        public Persona AltaPersonaPorConsola<T>() where T : Persona
        {
            Console.Clear();
            Console.WriteLine($"Introduce el nombre de {typeof(T).Name} :");


            switch (typeof(T).Name)
            {
                case "Medico":
                    return AltaPersona(new Medico(Console.ReadLine(), this));

                case "Paciente":
                    return AltaPersona(new Paciente(Console.ReadLine()));

                case "Administrativo":
                    return AltaPersona(new Administrativo(Console.ReadLine(), this, eCargo.SinCargo));

                case "Persona":
                    return AltaPersona(new Paciente(Console.ReadLine()));

                default:
                    return null;
            }

        }

        public void BajaPersonaPorConsola<T>() where T : Persona
        {
            BajaPersona(EscogerPorTipoPorConsola<T>());
        }

        private Persona EscogerPorTipoPorConsola<T>() where T : Persona
        {
            List<T> personas = GetPersonasPorTipo<T>();
            do
            {
                Console.Clear();
                Console.WriteLine(ListarPorTipo<T>());

                Console.WriteLine(" -   Introduce el numero de la persona:\n");
                if (int.TryParse(Console.ReadLine(), out int indicePersona))
                {
                    if (indicePersona > 0 && indicePersona <= personas.Count)
                        return personas[indicePersona - 1];
                    else
                        Console.WriteLine("!!   El numero no es valido");
                }
                else
                    Console.WriteLine("!!   Se necesita un numero");

            }
            while (true);
        }

        private Persona EscogerPorPersonasPorConsola<T>(List<T> personas) where T : Persona
        {
            do
            {
                Console.Clear();
                Console.WriteLine(ListarPorPersona(personas));

                Console.WriteLine(" -   Introduce el numero de la persona:\n");
                if (int.TryParse(Console.ReadLine(), out int indicePersona))
                {
                    if (indicePersona > 0 && indicePersona <= personas.Count)
                        return personas[indicePersona - 1];
                    else
                        Console.WriteLine("!!   El numero no es valido");
                }
                else
                    Console.WriteLine("!!   Se necesita un numero");

            }
            while (true);
        }

        public void AsignarMedicoPorConsola(Paciente paciente)
        {
            if (paciente == null)
                paciente = EscogerPorTipoPorConsola<Paciente>() as Paciente;

            paciente.AssignarMedico(EscogerPorTipoPorConsola<Medico>() as Medico);
        }

        public void DesAsignarMedicoPorConsola()
        {
            Paciente paciente = EscogerPorTipoPorConsola<Paciente>() as Paciente;
            paciente.DESAssignarMedico();
        }

        public void AsignarPacientePorConsola(Medico medico)
        {
            if (medico == null)
                medico = EscogerPorTipoPorConsola<Medico>() as Medico;


            List<Paciente> pacientesAEscoger = GetPersonasPorTipo<Paciente>();

            // buscar los pacientes que ya tengan este medico
            pacientesAEscoger.RemoveAll(repetidos => medico.ListPacientes.Contains(repetidos));

            Paciente escogido = EscogerPorPersonasPorConsola<Paciente>(pacientesAEscoger) as Paciente;
            escogido.AssignarMedico(medico);

        }

        public void DesAsignarPacientePorConsola()
        {
            Medico medico = EscogerPorTipoPorConsola<Medico>() as Medico;
            Paciente escogido = EscogerPorPersonasPorConsola<Paciente>(medico.ListPacientes) as Paciente;

            escogido.DESAssignarMedico();
        }

        public void ListarPacientesDe()
        {
            Medico medico = EscogerPorTipoPorConsola<Medico>() as Medico;
            Console.WriteLine(medico.ListarPacientes());
        }

    }
}

