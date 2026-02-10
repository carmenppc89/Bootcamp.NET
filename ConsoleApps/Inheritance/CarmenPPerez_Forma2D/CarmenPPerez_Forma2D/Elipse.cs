using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Forma2D
{
    public class Elipse : Forma
    {
        private int _radio1;
        private int _radio2;

        protected int Radio1 { get => _radio1; set => _radio1 = value; }
        protected int Radio2 { get => _radio2; set => _radio2 = value; }

        public Elipse(int Radio1, int Radio2)
        {
            this.Radio1 = Radio1;
            this.Radio2 = Radio2;
        }
        public override double GetArea()
        {
            return (Math.PI * Radio1 * Radio2);
        }
        public override string ToString()
        {
            return $@"Elipse: 
    Radio 1:    {Radio1} u
    Radio 2:    {Radio2} u
    Area:       {GetArea()} u²";
        }
    }
}
