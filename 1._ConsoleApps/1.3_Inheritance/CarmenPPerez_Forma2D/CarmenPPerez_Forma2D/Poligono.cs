using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Forma2D
{
    public class Poligono : Forma
    {
        protected readonly int NumLados;
        protected int Base { get; set; }
        protected int Altura { get; set; }
        public Poligono(int NumeroDeLados)
        {
            NumLados = NumeroDeLados;
        }
        public Poligono(int NumeroDeLados, int Base, int Altura)
        {
            NumLados = NumeroDeLados;
            this.Base = Base;
            this.Altura = Altura;
        }
        public override double GetArea()
        {
            throw new NotImplementedException();
        }
    }
}
