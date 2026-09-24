using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsAccesoADatos
{
    public partial class FormConnexion : Form
    {
        private SqlConnection Connection = null;
        private string ConnString = $"Data Source=46.183.118.102,54321;" +
                $"Initial Catalog=CarmenEmployees;" +
                $"User ID=sa;" +
                $"Password=Sql#123456789;";

        private string CMD = "";
        private SqlCommand SqlCmd;

        private Color ColConn = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        private Color ColDisConn = System.Drawing.SystemColors.InactiveCaption;

        private string Row = "";

        // campos de JOB
        int jobId;
        string jobTitle;
        decimal? jobMinSalary;
        decimal? jobMaxSalary;
        public FormConnexion()
        {
            Connection = new SqlConnection(ConnString);
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();

                    SwitchDesign(Connection.State);

                    UpdateLisBox();
                }
            }
            catch (Exception ex)
            {
                labConStatus.Text = ex.Message.ToString();
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();

                    SwitchDesign(Connection.State);

                    listBSelect.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                labConStatus.Text = ex.Message.ToString();
            }
        }

        private void SwitchDesign(ConnectionState state)
        {
            labConStatus.Text = state.ToString();
            labConStatus.BackColor = (state == ConnectionState.Open) ? ColConn : ColDisConn;

            btnRefresh.BackColor = (state == ConnectionState.Open) ? ColConn : ColDisConn;
            btnRefresh.Enabled = (state == ConnectionState.Open) ? true : false;

            btnAdd_V1.BackColor = (state == ConnectionState.Open) ? ColConn : ColDisConn;
            btnAdd_V1.Enabled = (state == ConnectionState.Open) ? true : false;

            btnAdd_V2.BackColor = (state == ConnectionState.Open) ? ColConn : ColDisConn;
            btnAdd_V2.Enabled = (state == ConnectionState.Open) ? true : false;

            btnAdd_V3.BackColor = (state == ConnectionState.Open) ? ColConn : ColDisConn;
            btnAdd_V3.Enabled = (state == ConnectionState.Open) ? true : false;

            btnAdd_V4.BackColor = (state == ConnectionState.Open) ? ColConn : ColDisConn;
            btnAdd_V4.Enabled = (state == ConnectionState.Open) ? true : false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateLisBox();
        }

        private void UpdateLisBox()
        {
            //try
            //{
            CMD = $"SELECT * FROM [CarmenEmployees].[dbo].[jobs]";
            SqlCmd = new SqlCommand(CMD, Connection);
            SqlDataReader select = SqlCmd.ExecuteReader();

            while (select.Read())
            {
                Row = $"{select.GetInt32(0)} - " +
                    $"{select.GetString(1)} : " +
                    $"{(select.IsDBNull(2) ? "null" : select.GetDecimal(2).ToString())} | " +
                    $"{(select.IsDBNull(3) ? "null" : select.GetDecimal(3).ToString())}";

                listBSelect.Items.Add(Row);
            }
        }

        private void btnAddV1_Click(object sender, EventArgs e)
        {
            CMD = "INSERT INTO [CarmenEmployees] " +
                "(job_title,min_salary,max_salary)" +
                "VALUES ('example',100,200);";

            SqlCmd = new SqlCommand(CMD, Connection);
            SqlCmd.ExecuteNonQuery();
        }
        private void btnAddV2_Click(object sender, EventArgs e)
        {
            // insertar entrada del usuario
            jobTitle = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(jobTitle))
            {
                MessageBox.Show($"Casilla vacia en {labTrabajo.Text.ToString()}");
                return;
            }

            decimal parseDec;
            jobMinSalary = null;
            jobMaxSalary = null;

            if (String.IsNullOrWhiteSpace(txtMin.Text))
            {
                if (decimal.TryParse(txtMin.Text, out parseDec))
                    jobMinSalary = parseDec;
            }

            if (String.IsNullOrWhiteSpace(txtMax.Text))
            {
                if (decimal.TryParse(txtMax.Text, out parseDec))
                    jobMaxSalary = parseDec;
            }

            CMD = $"INSERT INTO [CarmenEmployees] " +
                $"(job_title,min_salary,max_salary)" +
                $"VALUES (" +
                    $"'{jobTitle}', " +
                    $"{(jobMinSalary == null ? "NULL" : jobMinSalary.ToString())}, " +
                    $"{(jobMaxSalary == null ? "NULL" : jobMaxSalary.ToString())});";

            SqlCmd = new SqlCommand(CMD, Connection);
            SqlCmd.ExecuteNonQuery();
        }

        private void btnAddV3_Click(object sender, EventArgs e)
        {
            Job j = LeerJob();

            if (j == null || InsertarJob(j))
                MessageBox.Show("Error al inscribir el Trabajo.");


        }

        private void btnAddV4_Click(object sender, EventArgs e)
        {

        }
        private Job LeerJob() { return new Job(); }

        private bool InsertarJob(Job j)
        {

            try
            {
                string sql = $@"
INSERT INTO jobs ([job_title], [min_salary] ,[max_salary])
VALUES ('{j.job_id}', 
        {(j.min_salary == null ? "NULL" : j.min_salary.ToString())}, 
        {(j.max_salary == null ? "NULL" : j.max_salary.ToString())})";

                SqlCommand sqlCommand = new SqlCommand(sql, Connection);

                int num = sqlCommand.ExecuteNonQuery();
                //MessageBox.Show($"{num} filas insertadas!");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
