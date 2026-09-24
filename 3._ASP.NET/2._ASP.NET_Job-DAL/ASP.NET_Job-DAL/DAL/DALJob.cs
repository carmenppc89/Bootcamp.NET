using Connection;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

//using WinformsDAL;

namespace DAL
{
    public class DALJob
    {
        private DBConnect m_ConnDB;
        //private FormJob m_FromJob;

        private string m_CMDSelect = "SELECT * FROM [CarmenEmployees].[dbo].[jobs]";

        //public DALJob(FormJob fj)
        //{
        //    m_FromJob = fj;
        //    m_ConnDB = new DBConnect();
        //    m_ConnDB.SqlConn.StateChange += m_FromJob.SqlConn_StateChange;
        //}
        public DALJob()
        {
            m_ConnDB = new DBConnect();
            //m_ConnDB.SqlConn.StateChange += m_FromJob.SqlConn_StateChange;
        }

        public (Exception, List<Job>) SelectAllJobs()
        {
            List<Job> listJobs = new List<Job>();
            Job j;
            try
            {
                m_ConnDB.OpenConnection();

                SqlCommand sqlCmdSelect = new SqlCommand(m_CMDSelect, m_ConnDB.SqlConn);
                SqlDataReader dataSelect = sqlCmdSelect.ExecuteReader();

                while (dataSelect.Read())
                {
                    j = new Job(dataSelect.GetInt32(0), dataSelect.GetString(1),
                        (dataSelect.IsDBNull(2) ? null : dataSelect?.GetDecimal(2)),
                        (dataSelect.IsDBNull(3) ? null : dataSelect?.GetDecimal(3)));

                    listJobs.Add(j);
                }
            }
            catch (Exception ex)
            {
                m_ConnDB.CloseConnection();
                return (ex, null);
            }

            m_ConnDB.CloseConnection();
            return (null, listJobs);
        }

        public Exception InsertJob(Job job)
        {
            m_ConnDB.OpenConnection();

            try
            {
                string CmdInsert = $@"INSERT INTO [CarmenEmployees].[dbo].[jobs] ([job_title], [min_salary] ,[max_salary])
VALUES ( @job_title, @min_salary, @max_salary)";

                SqlCommand SqlCmdInsert = new SqlCommand(CmdInsert, m_ConnDB.SqlConn);
                SqlCmdInsert.Parameters.AddWithValue("@job_title", job.job_title);
                SqlCmdInsert.Parameters.AddWithValue("@min_salary", (object)job.min_salary ?? DBNull.Value);
                SqlCmdInsert.Parameters.AddWithValue("@max_salary", (object)job.max_salary ?? DBNull.Value);

                int ResultNonQuery = SqlCmdInsert.ExecuteNonQuery();
                if (ResultNonQuery == 0)
                    throw new Exception("Rows Inserted = 0");
            }
            catch (Exception ex)
            {
                m_ConnDB.CloseConnection();
                return ex;
            }

            m_ConnDB.CloseConnection();
            return null;
        }

        public Exception UpdateJob(Job oldJob, Job newJob)
        {
            m_ConnDB.OpenConnection();
            try
            {
                string CmdUpdate = $@"UPDATE [CarmenEmployees].[dbo].[jobs]
SET 
    [job_title] = @job_title,
    [min_salary] = @min_salary,
    [max_salary] = @max_salary
WHERE [job_id] = @job_id;";

                SqlCommand SqlCmdUpdate = new SqlCommand(CmdUpdate, m_ConnDB.SqlConn);
                SqlCmdUpdate.Parameters.AddWithValue("@job_id", oldJob.job_id);
                SqlCmdUpdate.Parameters.AddWithValue("@job_title", newJob.job_title);
                SqlCmdUpdate.Parameters.AddWithValue("@min_salary", (object)newJob.min_salary ?? DBNull.Value);
                SqlCmdUpdate.Parameters.AddWithValue("@max_salary", (object)newJob.max_salary ?? DBNull.Value);

                int ResultNonQuery = SqlCmdUpdate.ExecuteNonQuery();
                if (ResultNonQuery == 0)
                    throw new Exception("Rows Updated = 0");
            }
            catch (Exception ex)
            {
                m_ConnDB.CloseConnection();
                return ex;
            }

            m_ConnDB.CloseConnection();
            return null;
        }
        public Job StringToJob(string str)
        {
            //$"{job_id} -> {job_title} : {min_salary} - {max_salary}";
            int id = int.Parse(str.Substring(0, str.IndexOf(" -> ")));
            string title = "";
            decimal minSal = 0;
            decimal maxSal = 0;

            return new Job();
        }
    }
}
