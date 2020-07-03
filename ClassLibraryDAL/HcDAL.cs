
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using ClassLibraryMODEL;

namespace ClassLibraryDAL
{
    public class HcDAL
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
        conn.Open();
        //HcModel objModel = new HcModel();
        /*public void GetMaxId(string prefix)
        {
           
            string checkMax = "select MAX(ID) from User_Reg_Details where Prefix='" + prefix + "'";
            SqlCommand maxComm = new SqlCommand(checkMax, conn);
            object idValue = maxComm.ExecuteScalar();
            int temp;
            if (idValue != System.DBNull.Value)
            {
                temp = Convert.ToInt32(idValue.ToString());
                temp += 1;
            }
            else
            {
                temp = 1;
            }
            objModel.ID = temp;
        }
        */
        public void UserRegister(HcModel objModelReg)
        {
            string insertQuery = "insert into User_Reg_Details (ID,Prefix,firstname,middlename,lastname,gender,age,address,contactnumber,email,password) values ((ISNULL(((select MAX(ID) from User_Reg_Details where Prefix='"+ objModelReg.Prefix +"')+1),1)),@prefix,@fname,@mname,@lname,@gender,@age,@address,@cno,@email,@password)";
            SqlCommand comm = new SqlCommand(insertQuery, conn);
            //comm.Parameters.AddWithValue("@id", temp);
            comm.Parameters.AddWithValue("@prefix", objModelReg.Prefix);
            comm.Parameters.AddWithValue("@fname", objModelReg.firstname);
            comm.Parameters.AddWithValue("@mname", objModelReg.middlename);
            comm.Parameters.AddWithValue("@lname", objModelReg.lastname);
            comm.Parameters.AddWithValue("@gender", objModelReg.gender);
            comm.Parameters.AddWithValue("@age", objModelReg.age);
            comm.Parameters.AddWithValue("@address", objModelReg.address);
            comm.Parameters.AddWithValue("@cno", objModelReg.contactnumber);
            comm.Parameters.AddWithValue("@email", objModelReg.email);
            comm.Parameters.AddWithValue("@password",objModelReg.password);
            
            comm.ExecuteNonQuery();
        }

        conn.Close();
    }
}
