using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Hospital
{
    public enum eCargo { SinCargo, Auxiliar, Rececpionista, Contable, Directivo };
    public class Administrativo : Personal
    {
        private eCargo Cargo { get; set; }
        public Administrativo(string nombre, Hospital hospital, eCargo cargo) : base(nombre, hospital)
        {
            Cargo = cargo;
        }
        public override string ToString()
        {
            return $@"{base.ToString()}
    Cargo:      {Cargo}";
        }
    }
}
