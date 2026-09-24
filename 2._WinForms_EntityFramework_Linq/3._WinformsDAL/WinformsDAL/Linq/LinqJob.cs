using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformsDAL;

//jobs j = (from job in dc.jobs
//          where job.job_id == 15
//          select job).FirstOrDefault();

//var jobsLinq2 = dc.jobs.Where(j2 => j2.job_id == 15);
//List<jobs> listJobs = jobsLinq2.ToList();

//IQueryable<string> jobsTitles = from job in dc.jobs
//                                where job.job_id == 15
//                                select job.job_title;
//j.job_title = "Nuevo objeto desde Linq to SQL";
//dc.SubmitChanges();

namespace Linq
{
    internal class LinqJob
    {
        private EmployeesDataContext m_dc;
        private FormJob m_FromJob;

        public LinqJob() { }
        public LinqJob(FormJob fj)
        {
            m_dc = new EmployeesDataContext();
            m_FromJob = fj;
        }

        public List<jobs> GetAllJobs()
        {
            using (m_dc)
            {
                IQueryable<jobs> jobsLinq = from job in m_dc.jobs
                                            select job;

                return jobsLinq.ToList();
            }
        }

        public jobs GetJobFromId(int id)
        {
            using (m_dc)
            {
                jobs selectedJob = (from job in m_dc.jobs
                                    where job.job_id == id
                                    select job).FirstOrDefault();

                return selectedJob;
            }
        }

        public void AddJob(Job job)
        {
            using (m_dc)
            {
                jobs newJob = new jobs();
                newJob.job_id = job.job_id;
                newJob.job_title = job.job_title;
                newJob.min_salary = job.min_salary;
                newJob.max_salary = job.max_salary;

                m_dc.jobs.InsertOnSubmit(newJob);
                m_dc.SubmitChanges();
            }
        }

        public void SetJob(Job job)
        {
            using (m_dc)
            {
                jobs newJob = GetJobFromId(job.job_id);
                newJob.job_title = job.job_title;
                newJob.min_salary = job.min_salary;
                newJob.max_salary = job.max_salary;

                m_dc.SubmitChanges();
            }
        }
    }
}
