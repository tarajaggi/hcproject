using CLModel;
using ClsLibraryBLL;
using CLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class DoctorMappingDept : System.Web.UI.Page
    {
        ClassBll objBll = new ClassBll();
        ModelClass objMapping = new ModelClass();
        BugLogger log = new BugLogger();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                objMapping.fullname = DropDownListdoc.SelectedItem.Value;
                objMapping.deptName = DropDownListdpt.SelectedItem.Value;

                int isSuccess = objBll.DocToDept(objMapping, Session["New"].ToString());

                if (isSuccess == 0)
                {
                    Response.Write("Doctor is already mapped to this department!!");
                }
                else if (isSuccess == 1)
                {
                    Response.Write("Doctor is added to this department successfully!!");
                }
            }
            catch(Exception ex)
            {
                objMapping.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objMapping.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objMapping.ex_msg = ex.Message;
                log.LogException(Session["New"].ToString(), objMapping);
            }
        }

        
    }
}