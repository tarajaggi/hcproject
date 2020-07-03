using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ClinicMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] == null)
                Response.Redirect("login.aspx");

            if (!IsPostBack)
            {
                LabelUser.Text = Session["New"].ToString();
            }
        }

        protected void LinkButtonlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("New");
            Response.Redirect("login.aspx");
        }
    }
}