using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Forma2D
{
    public class Cuadrado : Rectangulo
    {
        protected int Lado { get => this.Base; set { Base = value; Altura = value; } }
        public Cuadrado(int MedidaLado) : base(MedidaLado, MedidaLado) { }
        public override string ToString()
        {
            return $@"Cuadrado:
    Lado:       {Lado} u
    Area:       {GetArea()} u²";
        }
    }
}
