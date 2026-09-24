using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAccesoADatos
{
    internal class Job
    {
        public int job_id { get; set; }
        public string job_title { get; set; }
        public decimal? min_salary { get; set; }
        public decimal? max_salary { get; set; }

        public Job() { }
        public Job(int id, string title, decimal min, decimal max)
        {
            job_id = id;
            job_title = title;
            min_salary = min;
            max_salary = max;
        }
    }
}
