using Connection;
using DAL;
using Linq;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsDAL
{
    public partial class FormJob : Form
    {
        // todo - formato de botones
        private Color m_ColConn = System.Drawing.Color.FromArgb(
            ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        private Color m_ColDisConn = System.Drawing.SystemColors.InactiveCaption;
        private Color m_ColEnabled;
        private Color m_ColDisabled;

        private DALJob m_DALJob;
        private LinqJob m_LinqJob;

        public FormJob()
        {
            InitializeComponent();

            m_DALJob = new DALJob(this);
            m_LinqJob = new LinqJob(this);

            EditState(false);
        }

        public void SqlConn_StateChange(object sender, StateChangeEventArgs e)
        {
            ConnectionState state = e.CurrentState;

            labConStatus.Text = state.ToString();
            labConStatus.BackColor = (state == ConnectionState.Open) ? m_ColConn : m_ColDisConn;
        }

        //  list Box
        private void listBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditState(true);
        }
        private void listBSelect_DoubleClick(object sender, MouseEventArgs e)
        {
            EditState(false);
        }
        private void DALUpdateLisBox()
        {
            (Exception, List<Job>) resultSelect = m_DALJob.SelectAllJobs();
            Exception ex = resultSelect.Item1;
            List<Job> listJobs = resultSelect.Item2;

            if (ex != null)
            {
                MessageBox.Show($"No se ha podido recuperar los Jobs" +
                    $"\nError -> \n{ex.ToString()}");
                return;
            }

            listBSelect.Items.Clear();
            foreach (Job j in listJobs)
            {
                listBSelect.Items.Add(j);
            }
        }


        //  BTNs
        private void btnEditJob_Click(object sender, EventArgs e)
        {
            // leer parametros NO COGE ID
            Job newJob = CreateJobByTextBoxes();
            if (newJob == null)
                return;

            // modificar el job a partir de la ID
            if (chckLinq.Checked)
            {
                // todo - edit with linq
            }
            else
            {
                if (m_DALJob.UpdateJob((listBSelect.SelectedItem as Job), newJob) == null)
                {
                    MessageBox.Show($"Se ha actualizado el siguiente trabajo correctamente:\n" +
                        $"{(listBSelect.SelectedItem as Job).job_id} : {newJob.job_title}\n" +
                        $"{newJob.min_salary} - {newJob.max_salary}");
                }
            }

            EditState(false);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (chckLinq.Checked)
                LinqUpdateLisBox();
            else
                DALUpdateLisBox();
        }
        private void btnAddJob_Click(object sender, EventArgs e)
        {
            Job job = CreateJobByTextBoxes();
            if (job == null)
                return;

            if (chckLinq.Checked)
            {
                // todo - edit with linq
            }
            else
            {
                Exception resultInsert = m_DALJob.InsertJob(job);
                if (resultInsert != null)
                {
                    MessageBox.Show($"No se ha podido inserir Job:" +
                        $"\nError -> \n{resultInsert.ToString()}");
                }
            }
        }

        //  Enable / Disable
        private void EditState(bool isEdit)
        {
            listBSelect.SelectedItem = isEdit ? listBSelect.SelectedItem as Job : null;
            Job job = listBSelect.SelectedItem as Job;
            FillTextBoxesByJob(job);

            btnAddJob.Enabled = !isEdit;
            btnEditJob.Enabled = isEdit;
        }

        // TXT boxes
        private Job CreateJobByTextBoxes()
        {
            Job job = new Job();

            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Introduzca el título del puesto.");
                return null;
            }

            job.job_title = txtTitle.Text;

            decimal parseDec;
            if (!String.IsNullOrWhiteSpace(txtMin.Text))
            {
                if (decimal.TryParse(txtMin.Text, out parseDec))
                    job.min_salary = parseDec;
                else
                    job.min_salary = null;
            }

            if (!String.IsNullOrWhiteSpace(txtMax.Text))
            {
                if (decimal.TryParse(txtMax.Text, out parseDec))
                    job.max_salary = parseDec;
                else
                    job.max_salary = null;
            }

            return job;
        }
        private void FillTextBoxesByJob(Job job)
        {
            // Pones en los campos txt los campos del job
            if (job != null)
            {
                txtTitle.Text = job.job_title == null ? "" : ("" + job.job_title);
                txtMin.Text = job.min_salary == null ? "" : ("" + job.min_salary);
                txtMax.Text = job.max_salary == null ? "" : ("" + job.max_salary);
            }
            else
            {
                txtTitle.Text = "";
                txtMin.Text = "";
                txtMax.Text = "";
            }
        }

        private void LinqUpdateLisBox()
        {
            // todo - edit with linq
        }
    }
}
