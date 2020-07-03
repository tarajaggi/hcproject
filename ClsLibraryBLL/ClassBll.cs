using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CLModel;
using CLUtils;
using DALClass;

namespace ClsLibraryBLL
{
    public class ClassBll
    {
        ClassDaL objDAL = new ClassDaL();
        ModelClass objModel = new ModelClass();
        BugLogger log = new BugLogger();

        public string getUserName(ModelClass objModelName)
        {
            string name = objDAL.getUserName(objModelName);
            return name;
        }
        public void UserRegister(ModelClass objectModelReg)
        {
            try
            {
                objDAL.UserRegister(objectModelReg);
            }
            catch(Exception ex)
            {
                objModel.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModel.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModel.ex_msg = ex.Message;
                log.LogException("System", objModel);
            }
        }

        public int UserLogin(ModelClass objectModelLogin)
        {
            int result = 0;
            try
            {
                result = objDAL.UserLogin(objectModelLogin);
            }
            catch(Exception ex)
            {
                objModel.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModel.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModel.ex_msg = ex.Message;
                log.LogException(objectModelLogin.User_id, objModel);
            }
            return result;
        }

        public int DeptRegister(ModelClass deptObj, string UserName)
        {
            int result = 0;
            try
            {
                result = objDAL.DeptRegister(deptObj, UserName);
            }
            catch (Exception ex)
            {
                objModel.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModel.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModel.ex_msg = ex.Message;
                log.LogException(UserName, objModel);
            }
            return result;
            
        }

        public int DocToDept(ModelClass ddMappingObj, string userName)
        {
            int result= 0;
            try
            {
                result = objDAL.DocToDept(ddMappingObj, userName);
            }
            catch (Exception ex)
            {
                objModel.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModel.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModel.ex_msg = ex.Message;
                log.LogException(userName, objModel);
            }
            return result;
        }
    }
}
