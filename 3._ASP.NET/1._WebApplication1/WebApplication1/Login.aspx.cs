using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Session["User"] = txtUser.Text;
            //string user = Request.QueryString["user"];

            string user = txtUser.Text;

            if (user == "admin" /*&& pwrd == "1234"*/)
            {
                Session["UserName"] = user;
                labLoginEstatus.Text = "";
                ((SiteMaster)Master).SpawnName.InnerText = user;
            }
            else
            {
                labLoginEstatus.Text = "Incorrecto";
            }
        }
    }
}