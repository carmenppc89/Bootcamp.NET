using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Hospital
{
    public class GeneradorDeDemo
    {
        private static Array CargosDeAdministrativo = Enum.GetValues(typeof(eCargo));
        private static Random rand = new Random();
        private static List<string> ListNombres = new List<string> { "Clara", "Mateo",
            "Sofia", "Andres", "Valeria", "Lucas", "Elena",
            "Gabriel","Martina", "Tomas", "Diego", "Camila",
            "Julian", "Paula","Samuel", "Alicia", "Javier" };
        public GeneradorDeDemo() { }
        private string GetRandomName()
        {
            return ListNombres[rand.Next(ListNombres.Count)];
        }
        public void GenerarMedicos(Hospital hosp, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                hosp.AltaPersona(new Medico(GetRandomName(), hosp));
            }
        }

        public void GenerarPacientes(Hospital hosp, int cantidad)
        {
            Paciente p;
            List<Medico> mdcs = hosp.GetPersonasPorTipo<Medico>(); ;
            for (int i = 0; i < cantidad; i++)
            {
                // uno entre tres pacientes no tendra medico
                if (rand.Next(4) == 1)
                    p = new Paciente(GetRandomName());
                else
                {
                    p = new Paciente(GetRandomName(), mdcs[rand.Next(mdcs.Count)]);
                }

                hosp.AltaPersona(p);
            }
        }

        public void GenerarAdministrativos(Hospital hosp, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                eCargo cargoRand = (eCargo)rand.Next(CargosDeAdministrativo.Length);
                hosp.AltaPersona(new Administrativo(GetRandomName(), hosp, cargoRand));
            }

        }

    }
}
