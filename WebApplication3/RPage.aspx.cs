using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using ClsLibraryBLL;
using CLModel;
using CLUtils;

namespace WebApplication3
{
    public partial class RPage : System.Web.UI.Page
    {
        ClassBll objBll = new ClassBll();
        ModelClass objModelRegister = new ModelClass();
        BugLogger log = new BugLogger();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                objModelRegister.Prefix = DropDownListRole.SelectedItem.Value;
                objModelRegister.firstname = TextBoxFname.Text;
                objModelRegister.middlename = TextBoxMName.Text;
                objModelRegister.lastname = TextBoxLName.Text;
                objModelRegister.gender = DropDownListGender.SelectedItem.Value;
                objModelRegister.age = Convert.ToInt32(TextBoxAge.Text);
                objModelRegister.address = TextBoxaddress.Text;
                objModelRegister.contactnumber = Convert.ToInt32(TextBoxCNo.Text);
                objModelRegister.email = TextBoxmail.Text;
                objModelRegister.password = TextBoxpass.Text;

                objBll.UserRegister(objModelRegister);
                Response.Redirect("login.aspx",true);
                
                
            }
            catch(Exception ex)
            {
                objModelRegister.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModelRegister.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModelRegister.ex_msg = ex.Message;
                log.LogException("System", objModelRegister);
            }
        }
    }
}