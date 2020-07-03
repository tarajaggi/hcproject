using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class TimeSlotUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DateTime start_dt = DateTime.Parse("10:00 AM");
                DateTime end_dt = DateTime.Parse("10:30 AM");
                MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
                if(start_dt.ToString("tt") == "AM" && end_dt.ToString("tt") == "AM")
                {
                    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                }
                else
                {
                    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                }
                TimeSelector1.SetTime(start_dt.Hour, start_dt.Minute, am_pm);
                TimeSelector2.SetTime(end_dt.Hour, end_dt.Minute, am_pm);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            string start_time = TimeSelector1.Hour.ToString() + ":" + TimeSelector1.Minute.ToString() + " " + TimeSelector1.AmPm.ToString();
            string end_time = TimeSelector2.Hour.ToString() + ":" + TimeSelector2.Minute.ToString() + " " + TimeSelector2.AmPm.ToString();
            string checkslot = "select count(1) from TimeSlot where Day='" + DropDownList1.SelectedItem.Value + "' And Start_Time='"+ start_time +"' And End_Time='"+ end_time +"'";
            SqlCommand com = new SqlCommand(checkslot, con);
            int count = Convert.ToInt32(com.ExecuteScalar().ToString());
            
            if (count == 0)
            {
                
                string insertQuery = "insert into TimeSlot(Prefix,Day,Start_Time,End_Time,CreatedBy,CreatedDate,IsActive) values (@prefix,@day,@stime,@etime,@user,getDate(),@active)";
                SqlCommand comm = new SqlCommand(insertQuery, con);
                comm.Parameters.AddWithValue("@user", Session["id"].ToString());
                comm.Parameters.AddWithValue("@prefix", "TS");
                comm.Parameters.AddWithValue("@day", DropDownList1.SelectedItem.Value);
                comm.Parameters.AddWithValue("@stime", start_time);
                comm.Parameters.AddWithValue("@etime", end_time);
                comm.Parameters.AddWithValue("@active", "Y");
                comm.ExecuteNonQuery();
                Response.Write("Time Slot Added!!!");
            }
            else
            {
                Response.Write("Time Slot Already exists!!");
            }
            con.Close();
        }
    }
}