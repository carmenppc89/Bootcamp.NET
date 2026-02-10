using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Hospital
{
    public class Personal : Persona
    {
        public Hospital Hospital { get; set; }

        public Personal(string nombre, Hospital hospital) : base(nombre)
        {
            Hospital = hospital;
        }

    }
}
