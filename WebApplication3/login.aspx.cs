using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using CLModel;
using ClsLibraryBLL;
using CLUtils;

namespace WebApplication3
{
    public partial class login : System.Web.UI.Page
    {
        ClassBll objBllLogin = new ClassBll();
        ModelClass objModelLogin = new ModelClass();
        BugLogger log = new BugLogger();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_login_Click(object sender, EventArgs e)
        {
            try
            {
                objModelLogin.User_id = TextBoxuid.Text;
                objModelLogin.password = TextBoxpass.Text;

                int result = objBllLogin.UserLogin(objModelLogin);

                if (result == -1)
                {
                    Response.Write("User_id is incorrect!!");
                }
                else if (result == 1)
                {
                    string UserName = objBllLogin.getUserName(objModelLogin);
                    Session["New"] = UserName;
                    Session["id"]= TextBoxuid.Text;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Write("Password is incorrect!!");
                }
            }

            catch (Exception ex)
            {
                objModelLogin.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModelLogin.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModelLogin.ex_msg = ex.Message;
                log.LogException(Session["New"].ToString(), objModelLogin);
            }

           
        }
    }
}