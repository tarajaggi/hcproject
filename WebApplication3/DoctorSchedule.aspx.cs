using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class DoctorSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            string checkSlotID= "select TS_ID from TimeSlot where Day='" + DropDownListDay.SelectedItem.Value + "' And Start_Time='"+ DropDownListSTime.SelectedItem.Value + "' And End_Time='" + DropDownListETime.SelectedItem.Value + "' ";
            SqlCommand Comm = new SqlCommand(checkSlotID, con);
            
            string slot_ID = Comm.ExecuteScalar().ToString();
            string insertQuery = "insert into DoctorSchedule(Doc_Id,Ts_Id,Max_Visit,CreatedBy,CreatedDate,IsActive) values (@user,@slot_Id,@max,@c_user,getDate(),@active)";
            SqlCommand insertCom = new SqlCommand(insertQuery, con);
            insertCom.Parameters.AddWithValue("@user", Session["id"].ToString());
            insertCom.Parameters.AddWithValue("@slot_Id",slot_ID);
            insertCom.Parameters.AddWithValue("@max", TextBoxMax.Text);
            insertCom.Parameters.AddWithValue("@c_user", Session["id"].ToString());
            insertCom.Parameters.AddWithValue("@active", "Y");
            insertCom.ExecuteNonQuery();
            Response.Write("Added!!");
            con.Close();
        }

        /*protected void BindDropDownList(DropDownList ddl, string query, string text, string value, string defaultText)
        { 
            string conString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query);
            using(SqlConnection con= new SqlConnection(conString))
            {
                using(SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    ddl.DataSource
                }
            }
        }*/

        protected void DropDownListDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter mydata = new SqlDataAdapter("Select Start_Time From TimeSlot where Day='" + DropDownListDay.SelectedItem.Text + "'", con);
            mydata.Fill(ds);
            DropDownListSTime.DataSource = ds;
            DropDownListSTime.DataValueField = "Start_Time";
            DropDownListSTime.DataBind();
            DropDownListSTime.Items.Insert(0, new ListItem("Select", "0"));
            DataSet ds1 = new DataSet();
            SqlDataAdapter mydata1 = new SqlDataAdapter("Select End_Time From TimeSlot where Day='" + DropDownListDay.SelectedItem.Text + "'", con);
            mydata1.Fill(ds1);
            DropDownListETime.DataSource = ds1;
            DropDownListETime.DataValueField = "End_Time";
            DropDownListETime.DataBind();
            DropDownListETime.Items.Insert(0, new ListItem("Select", "0"));
            con.Close();
        }
    }
}