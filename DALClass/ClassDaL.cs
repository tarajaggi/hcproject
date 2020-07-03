using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLModel;
using System.Reflection;
using CLUtils;
using System.Web;

namespace DALClass
{
    public class ClassDaL
    {
        BugLogger log = new BugLogger();
        ModelClass objModel = new ModelClass();
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);

        public void UserRegister(ModelClass objModelReg)
        {
            try
            {
                
                con.Open();
                string insertQuery = "insert into User_Reg_Details (ID,Prefix,firstname,middlename,lastname,Full_Name,gender,age,address,contactnumber,email,password) values (@id,@prefix,@fname,@mname,@lname,@fullname,@gender,@age,@address,@cno,@email,@password)";
                SqlCommand comm = new SqlCommand(insertQuery, con);
                string getID = "Select ISNULL((select MAX(ID) from User_Reg_Details where Prefix='DOC')+1,1)";
                SqlCommand commID = new SqlCommand(getID, con);
                int id = Convert.ToInt32(commID.ExecuteScalar().ToString());
                string fullname = objModelReg.firstname + " " + objModelReg.middlename + " " + objModelReg.lastname + " " + id.ToString();
                comm.Parameters.AddWithValue("@id", id.ToString());
                comm.Parameters.AddWithValue("@prefix", objModelReg.Prefix);
                comm.Parameters.AddWithValue("@fname", objModelReg.firstname);
                comm.Parameters.AddWithValue("@mname", objModelReg.middlename);
                comm.Parameters.AddWithValue("@lname", objModelReg.lastname);
                comm.Parameters.AddWithValue("@fullname", fullname);
                comm.Parameters.AddWithValue("@gender", objModelReg.gender);
                comm.Parameters.AddWithValue("@age", objModelReg.age);
                comm.Parameters.AddWithValue("@address", objModelReg.address);
                comm.Parameters.AddWithValue("@cno", objModelReg.contactnumber);
                comm.Parameters.AddWithValue("@email", objModelReg.email);
                comm.Parameters.AddWithValue("@password", objModelReg.password);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                
                objModel.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModel.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModel.ex_msg = ex.Message;
                log.LogException("Systems", objModel);
            }
        }

        public string getUserName(ModelClass objModelName)
        {
            string name = string.Empty;
            con.Open();
            string checkusername = "select Full_Name from User_Reg_Details where User_id='" + objModelName.User_id + "'";
            SqlCommand comm = new SqlCommand(checkusername, con);
            name= comm.ExecuteScalar().ToString();
            return name;
        }
        public int UserLogin(ModelClass objModelLogin)
        {
            int result = 0 ;
            try
            {
                con.Open();
                string checkuser = "select count(1) from User_Reg_Details where User_id='" + objModelLogin.User_id + "'";
                SqlCommand comm = new SqlCommand(checkuser, con);
                int temp = Convert.ToInt32(comm.ExecuteScalar().ToString());
                con.Close();
                if (temp == 1)
                {
                    con.Open();
                    string checkPasswordQuery = "select password from User_Reg_Details where User_id='" + objModelLogin.User_id + "'";
                    SqlCommand passComm = new SqlCommand(checkPasswordQuery, con);
                    string password = passComm.ExecuteScalar().ToString().Replace(" ", "");
                    if (password == objModelLogin.password)
                    {
                        result = 1;

                    }
                    else
                    {
                        result = 0;
                    }

                }
                else
                {
                    result = -1;
                }
                con.Close();
            }
            catch(Exception ex)
            {
                objModel.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModel.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModel.ex_msg = ex.Message;
                log.LogException(objModelLogin.User_id, objModel);
            }
            return result;
        }
        
        public int DeptRegister(ModelClass deptObj, string userName)
        {
            int result = 0;
            try
            {
                con.Open();
                string query = "Merge Department AS Target Using (Select @Dept_Id AS D_id, @Dept_Name AS D_name, @Dept_Abbr AS D_Abb, @CreatedBy AS C_B, @UpdatedBy AS U_B, @IsActive AS Active) AS Source ON Target.Dept_Id=Source.D_id When Matched Then UPDATE SET Target.Dept_Name=Source.D_name, Target.Dept_Abbreviation=Source.D_Abb, Target.UpdatedBy=Source.U_B, Target.UpdatedDate=getDate(), Target.IsActive=Source.Active When Not Matched Then INSERT (Dept_Id, Dept_Name, Dept_Abbreviation, CreatedBy, CreatedDate,IsActive) VALUES (Source.D_id, Source.D_name, Source.D_Abb, Source.C_B, getDate(), Source.Active);";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@Dept_Id", deptObj.deptID);
                com.Parameters.AddWithValue("@Dept_Name", deptObj.deptName);
                com.Parameters.AddWithValue("@Dept_Abbr", deptObj.deptAbb);
                com.Parameters.AddWithValue("@CreatedBy", userName);
                com.Parameters.AddWithValue("@UpdatedBy", userName);
                com.Parameters.AddWithValue("@IsActive", "Y");
                result = com.ExecuteNonQuery();

                con.Close();
            }
            catch(Exception ex)
            {
                objModel.ex_source = this.GetType().Name + MethodBase.GetCurrentMethod().Name;
                objModel.ex_url = HttpContext.Current.Request.Url.AbsolutePath;
                objModel.ex_msg = ex.Message;
                log.LogException(userName, objModel);
            }
            return result;
        }
    

        public int DocToDept(ModelClass ddMappingObj, string userName)
        {
            int result=0;
            try
            {
                con.Open();
                string docid = "Select User_id from User_Reg_Details where Full_Name = '"+ ddMappingObj.fullname +"'";
                SqlCommand commDI = new SqlCommand(docid, con);
                string Doc_Id = commDI.ExecuteScalar().ToString();
                string deptid = "Select Dept_ID from Department where Dept_Name = '" + ddMappingObj.deptName + "'";
                SqlCommand commDpI = new SqlCommand(deptid, con);
                string Dept_Id = commDpI.ExecuteScalar().ToString();
                string checkMapping = "select count(1) from DoctorDeptMapping where Doc_ID='" + Doc_Id + "' and Dept_ID='" + Dept_Id + "'";
                SqlCommand comm = new SqlCommand(checkMapping, con);
                int temp = Convert.ToInt32(comm.ExecuteScalar().ToString());
                if (temp == 0)
                {
                    string InsertDDMQuery = "insert into DoctorDeptMapping(Doc_ID,Dept_ID,CreatedBy,CreatedDate) values (@docid,@deptid,@user,getDate())";
                    SqlCommand insertCom = new SqlCommand(InsertDDMQuery, con);
                    insertCom.Parameters.AddWithValue("@docid", Doc_Id);
                    insertCom.Parameters.AddWithValue("@deptid", Dept_Id);
                    insertCom.Parameters.AddWithValue("@user", userName);
                    result = insertCom.ExecuteNonQuery();
                }
                else
                {
                    result = 0;
                }
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
