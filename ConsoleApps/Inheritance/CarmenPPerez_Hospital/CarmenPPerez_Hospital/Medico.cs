using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Hospital
{
    public class Medico : Personal
    {
        public List<Paciente> ListPacientes { get; }

        public Medico(string nombre, Hospital hospital) : base(nombre, hospital)
        {
            ListPacientes = new List<Paciente>();
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
    Pacientes:  {ListPacientes.Count}";
        }

        public string ListarPacientes()
        {
            string str = $"\nLista de pacientes del Dr./Dra. {Nombre}:\n";
            int contador = 1;

            foreach (Paciente p in ListPacientes)
            {
                str += $"{contador++}. {p.ToString()}\n\n";
            }

            return str;
        }

        public void AñadirPaciente(Paciente paciente)
        {
            if (!ListPacientes.Contains(paciente))
                ListPacientes.Add(paciente);
        }

        public void QuitarPaciente(Paciente paciente)
        {
            if (ListPacientes.Contains(paciente))
                ListPacientes.Remove(paciente);
        }
    }
}
