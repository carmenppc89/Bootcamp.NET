using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Forma2D
{
    public class Rombo : Cuadrado
    {
        private int Angulo { get; set; }
        public Rombo(int MedidaLado, int Angulo) : base(MedidaLado)
        {
            this.Angulo = Angulo;
        }

        public override double GetArea()
        {
            // todo - No Calula bien
            //A = L² * sen(Angulo)
            return ((Math.Pow(Lado, 2)) * (Math.Sin(Angulo)));
        }
        public override string ToString()
        {
            return $@"Rombo:
    Lado:       {Lado} u
    Angulo:     {Angulo} º
    Area:       {GetArea()} u²";
        }
    }
}
