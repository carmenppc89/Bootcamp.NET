using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Job_DAL
{
    public partial class _Default : Page
    {
        DALJob m_DALJob;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                m_DALJob = new DALJob();
                DALUpdateLisBox();
            }
        }

        private void DALUpdateLisBox()
        {
            (Exception, List<Job>) resultSelect = m_DALJob.SelectAllJobs();
            Exception ex = resultSelect.Item1;
            List<Job> listJobs = resultSelect.Item2;

            if (ex != null)
            {
                labErrorSelectJobs.Text = $"No se ha podido recuperar los Jobs\n{ex.Message}";
                return;
            }

            ListBox_Jobs.Items.Clear();
            foreach (Job j in listJobs)
            {
                ListBox_Jobs.Items.Add(j.ToString());
            }

            // https://learn.microsoft.com/es-es/dotnet/api/system.web.ui.webcontrols.listcontrol.datatextfield?view=netframework-4.8.1
            //ListBox_Jobs.DataMember = "Job";
            //ListBox_Jobs.DataSource = listJobs;
            //ListBox_Jobs.DataMember = "Job";
            //ListBox_Jobs.ItemType = "Job";
            //ListBox_Jobs.DataValueField = "job_id";
            //ListBox_Jobs.DataTextField = "job_title";
            //ListBox_Jobs.AppendDataBoundItems(false);

            //ListBox_Jobs.DataBind();
            //ListBox_Jobs.data

            //IDataSource data = ListBox_Jobs.DataSourceObject;
        }

        protected void ListBox_Jobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // todo -  Desplazarse a un nuevo form: JobModificar.aspx
            // todo - !! no se puede sacar el item selected por el postback

            //ListBox d = sender as ListBox;
            //object o = d.SelectedItem;
            //e.ToString();

            //int[] indices = ListBox_Jobs.GetSelectedIndices();

            //ListItemCollection a = ListBox_Jobs.Items;
            Session["JobSelected"] = stringToJob(ListBox_Jobs.SelectedItem.ToString());
            //stringToJob(Session["JobSelected"].ToString());
            //Session["JobSelected"] = ListBox_Jobs.SelectedItem;

            //foreach (object item in a)
            //{
            //    ListItem it = (item as ListItem);

            //    if (it.Selected)
            //    {
            //        Job j = m_DALJob.StringToJob(it.Text);
            //        break;
            //    }
            //}


            //Object ibj = ListBox_Jobs.Items[1];
            //Response.Redirect("JobModificar.aspx");



        }

        private Job stringToJob(string str)
        {
            string id, title, minSal, maxSal;
            int sepID, sepTitle, sepMin, sepMax;

            sepID = str.IndexOf(", title: ");
            id = str.Substring(3, sepID);
            int intID = int.Parse(id);

            sepTitle = str.IndexOf(", Min: ");
            title = str.Substring(sepID, sepTitle);

            sepMin = str.IndexOf(", Max: ");
            char c = str[sepMin];
            minSal = str.Substring(sepTitle + 3, sepMin);
            decimal? decMin = null;
            if (minSal != null)
            {
                decMin = int.Parse(minSal);
            }

            sepMax = str.Length - 1;
            maxSal = str.Substring(sepMin + 3, sepMax);
            decimal? decMax = null;
            if (maxSal != null)
            {
                decMax = int.Parse(maxSal);
            }

            return new Job(intID, title, decMin, decMax);

        }

        protected void ListBox_Jobs_Unload(object sender, EventArgs e)
        {
            string str = ListBox_Jobs.SelectedValue;
            object obj = ListBox_Jobs.SelectedIndex;
            int ind = ListBox_Jobs.SelectedIndex;

            object segundo = ListBox_Jobs.Items[2];
        }

        //private void DisplayJobForm()
        //{
        //    // montar html a partir de un div vacio
        //    //JobSelectedInfo.InnerHtml = "";
        //    JobSelectedInfo.InnerHtml = @"
        //        <div id=""JobForm"" class=""row"">

        //            <p>Trabajo:</p>
        //            <input id=""txtJobTitulo"" type=""text"" />
        //            <br />

        //            <p>Salario Minimo:</p>
        //            <input id=""txtJobSalMin"" type=""number"" />
        //            <br />

        //            <p>Salario Maximo:</p>
        //            <input id=""txtJobSalMax"" type=""number"" />
        //            <br /> <br />

        //            <input id=""btnUpdate"" type=""button"" value=""Modificar"" />


        //        </div>";
        //}
    }
}