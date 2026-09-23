using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Forma2D
{
    public class Triangulo : Poligono
    {
        private int[] MedidaLados { get; set; }
        public Triangulo() : base(3)
        {
            MedidaLados = new int[3];
        }
        public Triangulo(int lado1, int lado2, int lado3) : base(3)
        {
            //if (!DesigualdadTriangular(lado1, lado2, lado3))
            //    throw new Exception("La suma de dos lados debe ser mayor que el lado sobrante");

            MedidaLados = new int[3];
            this.MedidaLados[0] = lado1;
            this.MedidaLados[1] = lado2;
            this.MedidaLados[2] = lado3;

            // coge el primer valor de los lados y lo pone como la Base
            Base = MedidaLados.FirstOrDefault(lado => lado != 0);
        }
        public override double GetArea()
        {
            if (MedidaLados.All(lado => lado != 0))
            {
                // FOMRULA DE HERON
                // S=((a+b+c)/2)
                // A= Math.Sqrt((S(S - a)(S - b)(S - c)));

                double semiperimetro = GetPerimetro() / 2;
                double res = Math.Sqrt(semiperimetro * ((semiperimetro - MedidaLados[0]) *
                    (semiperimetro - MedidaLados[1]) * (semiperimetro - MedidaLados[2])));
                return res;
            }
            else
            {
                Console.WriteLine("Falta informacion de este triangulo");
                return -3.0;
            }
        }
        public override string ToString()
        {
            return $@"Triangulo: 
    Lado 1:     {MedidaLados[0]} u
    Lado 2:     {MedidaLados[1]} u
    Lado 3:     {MedidaLados[2]} u
    Area:       {GetArea()} u²";
        }

        public double GetPerimetro()
        {
            if (MedidaLados.All(lado => lado != 0))
            {
                return MedidaLados[0] + MedidaLados[1] + MedidaLados[2];
            }
            else
            {
                Console.WriteLine("Falta informacion de este triangulo");
                return -3;
            }

        }
    }
}
