using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_CartasYBarajas
{
    public enum ePalos { picas, corazones, treboles, diamantes };
    public class Carta
    {
        private int _numero;
        private ePalos _palo;

        public int Numero { get => _numero; set => _numero = value; }
        public ePalos Palo { get => _palo; set => _palo = value; }

        public Carta() { }
        public Carta(int n, ePalos p)
        {
            this._numero = n;
            this._palo = p;
        }

        public string Print()
        {
            return this.Numero + " de " + this.Palo;
        }
    }
}
