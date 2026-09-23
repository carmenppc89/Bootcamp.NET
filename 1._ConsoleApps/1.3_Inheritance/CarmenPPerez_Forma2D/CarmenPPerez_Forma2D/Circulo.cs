using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Forma2D
{
    public class Circulo : Elipse
    {
        private int Radio { get => this.Radio1; set { Radio1 = value; Radio2 = value; } }

        public Circulo(int Radio) : base(Radio, Radio) { }

        public override string ToString()
        {
            return $@"Circulo: 
    Radio:      {Radio} u
    Area:       {GetArea()} u²";
        }
    }
}
