using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Forma2D
{
    public class Rectangulo : Poligono
    {
        public Rectangulo(int B, int A) : base(4, B, A) { }
        public override double GetArea()
        {
            return (this.Base * this.Altura);
        }
        public override string ToString()
        {
            return $@"Rectangulo:
    Base:       {Base} u
    Altura:     {Altura} u
    Area:       {GetArea()} u²";
        }
    }
}
