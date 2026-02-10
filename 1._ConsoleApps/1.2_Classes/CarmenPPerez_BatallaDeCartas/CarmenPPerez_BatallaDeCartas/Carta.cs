using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_BatallaDeCartas
{
    public enum ePalos { picas, corazones, treboles, diamantes };
    public class Carta
    {
        private int _numero;
        private ePalos _palo;
        private Jugador _dueño;

        public int Numero { get => _numero; }
        public ePalos Palo { get => _palo; }
        public Jugador Dueño { get => _dueño; set => _dueño = value; }

        public Carta() { }
        public Carta(int n, ePalos p)
        {
            _numero = n;
            _palo = p;
            _dueño = null;
        }

        public override string ToString()
        {
            if (Dueño == null)
                return Numero + " de " + Palo;
            else
                return "Jugador " + Dueño.ID + " (" + Dueño.Puntos.Cartas.Count + ") "
                    + ": " + Numero + " de " + Palo;
        }
    }
}
