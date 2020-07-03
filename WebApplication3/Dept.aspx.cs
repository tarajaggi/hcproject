using CLModel;
using ClsLibraryBLL;
using CLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace WebApplication3
{
    public partial class Dept : System.Web.UI.Page
    {
        ClassBll objBllDept = new ClassBll();
        ModelClass objModelDept = new ModelClass();
        BugLogger log = new BugLogger();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click1(object sender, EventArgs e)
        {
            try
            {
                objModelDept.deptID = TextBoxdptId.Text;
                objModelDept.deptName = TextBoxdptname.Text;
                objModelDept.deptAbb = TextBoxAbb.Text;

                int isSuccess = objBllDept.DeptRegister(objModelDept, Session["id"].ToString());

                if (isSuccess == 1)
                {
                    Response.Write("Department successfully updated!!");
                }
                else
                {
                    Response.Write("Wrong Input!!");
                }
            }
            catch (Exception ex)
            {
                objModelDept.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModelDept.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModelDept.ex_msg = ex.Message;
                log.LogException(Session["New"].ToString(), objModelDept);
            }
        }
    }
}