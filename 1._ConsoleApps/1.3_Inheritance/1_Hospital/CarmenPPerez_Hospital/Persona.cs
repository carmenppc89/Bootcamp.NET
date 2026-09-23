using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Hospital
{
    public class Persona
    {
        public string Nombre { get; }
        public Persona(string nombre)
        {
            Nombre = nombre;
        }
        public override string ToString()
        {
            return $@"{this.GetType().Name}
    Nombre:     {Nombre}";
        }
    }
}
