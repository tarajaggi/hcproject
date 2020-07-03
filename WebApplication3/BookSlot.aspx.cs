using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class BookSlot : System.Web.UI.Page
    {
        string u_id = string.Empty;
        string slot = string.Empty;
        string date = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            u_id = Request["id"].ToString();
            slot = Session["Slot"].ToString();
            date = Session["Date"].ToString();
           
            con.Open();

            string checkCount = "select count(1) from Consultancy where Doc_ID='" + u_id + "' and Time_Slot='"+ slot + "' and Date='" + date + "'";
            SqlCommand comm = new SqlCommand(checkCount, con);
            int count = Convert.ToInt32(comm.ExecuteScalar().ToString());
            
            string checkMax = "select Max_Visit from DoctorSchedule where Doc_Id='" + u_id + "' and Ts_Id='" + slot + "'";
            SqlCommand commMax = new SqlCommand(checkMax, con);
            int max = Convert.ToInt32(commMax.ExecuteScalar().ToString());
            Session["num"] = count+1;

            

            con.Close();

            if (count == max)
            {
                TextBoxcount.Text = (max-count).ToString();
                Labelinfo.Text = "Seat is not available!! Please choose different slot!";
                ButtonBook.Visible = false;
            }
            else if(count < max)
            {
                TextBoxcount.Text = (max-count).ToString();
                Labelinfo.Text = "Seat is available!! Please confirm your booking!";
            }

        }

        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consultancy.aspx");
        }

        protected void ButtonBook_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            string insertQuery = "insert into Consultancy (Id,Pat_ID,Doc_ID,Time_Slot,Date) values (@id,@Pat_ID,@Doc_ID,@ts,@date)";
            SqlCommand comm = new SqlCommand(insertQuery, con);
            comm.Parameters.AddWithValue("@id",Session["Num"].ToString());
            comm.Parameters.AddWithValue("@Pat_ID", Session["id"].ToString());
            comm.Parameters.AddWithValue("@Doc_ID", Request["id"].ToString());
            comm.Parameters.AddWithValue("@ts", Session["Slot"].ToString());
            comm.Parameters.AddWithValue("@date", Session["Date"].ToString());
            comm.ExecuteNonQuery();
            con.Close();
            Response.Write("Booked!!");
        }
    }
}