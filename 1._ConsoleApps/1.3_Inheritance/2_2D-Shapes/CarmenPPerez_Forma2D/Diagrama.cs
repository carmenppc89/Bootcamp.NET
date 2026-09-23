using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Forma2D
{
    public class Diagrama
    {
        public Dictionary<int, Forma> Formas { get; }

        public Diagrama()
        {
            Formas = new Dictionary<int, Forma>();
        }

        public void AddForma(Forma f)
        {
            Formas.Add(Formas.Count, f);
        }

        public double GetArea()
        {
            double area = 0;
            foreach (Forma f in Formas.Values)
            {
                area += f.GetArea();
            }
            return area;
        }
        public override string ToString()
        {
            string str = "";
            foreach (KeyValuePair<int, Forma> f in Formas)
            {
                str += $"{f.Key + 1}. {f.Value.ToString()}\n";
            }

            str += $@"
Area del Diagrama: {GetArea()} u²";

            return str;
        }
    }
}
