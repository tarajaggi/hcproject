using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CLModel;

namespace CLUtils
{
    public class BugLogger
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
        public void LogException(string user,ModelClass obj) 
        {
            con.Open();
            string logQuery = "insert into Logging_Exception (ExceptionMsg, ExceptionSource, ExceptionURL, Logdate, CreatedBy, CreatedDate) values (@msg, @source, @url, getDate(), @user, getDate())";
            SqlCommand comm = new SqlCommand(logQuery, con);
            comm.Parameters.AddWithValue("@msg", obj.ex_msg);
            comm.Parameters.AddWithValue("@source", obj.ex_source);
            comm.Parameters.AddWithValue("@url", obj.ex_url);
            comm.Parameters.AddWithValue("@user", user);
            comm.ExecuteNonQuery();
            con.Close();
        }
    }
}
