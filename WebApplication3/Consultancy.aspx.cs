using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Consultancy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth || e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.Gray;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Session["Date"] = TextBoxDate.Text;
            HiddenFieldDay.Value = Calendar1.SelectedDate.DayOfWeek.ToString();
            HiddenFieldMonth.Value = DateTimeFormatInfo.CurrentInfo.GetMonthName(Calendar1.SelectedDate.Month);
            Calendar1.Visible = false;
            
        }


        protected void DropDownListDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            string DeptQuery = "Select Dept_ID From Department where Dept_Name='"+ DropDownListDept.SelectedItem.Text +"'";
            SqlCommand comm = new SqlCommand(DeptQuery, con);
            HiddenFieldDpt.Value = Convert.ToString(comm.ExecuteScalar());
            Session["Dept"] = HiddenFieldDpt.Value;
            con.Close();

        }

        protected void DropDownListTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            string TSQuery = "Select TS_ID From TimeSlot where Day='" + HiddenFieldDay.Value + "' and Start_Time='"+ DropDownListTS.SelectedItem.Value + "'";
            SqlCommand comm = new SqlCommand(TSQuery, con);
            HiddenFieldTS.Value = comm.ExecuteScalar().ToString();
            Session["Slot"] = HiddenFieldTS.Value;
            this.SetDataToRepeaterTS();
            con.Close();
        }

        protected void SetDataToRepeaterTS()
        {
               string connectionStr = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
               using (SqlConnection con = new SqlConnection(connectionStr))
               {
                   using (SqlDataAdapter mydata = new SqlDataAdapter())
                   {
                       using(mydata.SelectCommand= con.CreateCommand())
                       {

                        mydata.SelectCommand.CommandText = "Select distinct u.User_id , u.Full_Name , d.Max_Visit from User_Reg_Details as u inner join DoctorSchedule as d on u.User_id=d.Doc_Id where u.User_id IN (Select Doc_Id from DoctorSchedule where Ts_Id=@ts_val and Month=@month and Doc_Id IN (Select Doc_ID from DoctorDeptMapping where Dept_ID=@dpt_val))";
                        mydata.SelectCommand.Parameters.Clear();
                        mydata.SelectCommand.Parameters.Add("@ts_val", SqlDbType.VarChar).Value = Convert.ToString(HiddenFieldTS.Value);
                        mydata.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = Convert.ToString(HiddenFieldMonth.Value);
                        mydata.SelectCommand.Parameters.Add("@dpt_val", SqlDbType.VarChar).Value = Convert.ToString(HiddenFieldDpt.Value);
                        DataSet ds = new DataSet();
                        mydata.Fill(ds); 
                        Repeater2.DataSource = ds.Tables[0];
                        Repeater2.DataBind();
                        }
                   }
               }
            

        }

        protected void SetDataToRepeaterDoc()
        {

            string connectionStr = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                using (SqlDataAdapter mydata = new SqlDataAdapter())
                {
                    using (mydata.SelectCommand = con.CreateCommand())
                    {
                        mydata.SelectCommand.CommandText = "Select Start_Time, TS_ID From TimeSlot where Day='" + HiddenFieldDay.Value + "' and TS_ID IN(Select Ts_ID from DoctorSchedule where Doc_Id='" + HiddenFieldDoc.Value + "' and Month='" + HiddenFieldMonth.Value + "'); ";
                        /*mydata.SelectCommand.Parameters.Clear();
                        mydata.SelectCommand.Parameters.Add("@ts_val", SqlDbType.VarChar).Value = Convert.ToString(HiddenFieldTS.Value);
                        mydata.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = Convert.ToString(HiddenFieldMonth.Value);
                        mydata.SelectCommand.Parameters.Add("@dpt_val", SqlDbType.VarChar).Value = Convert.ToString(HiddenFieldDpt.Value);*/
                        DataSet ds = new DataSet();
                        mydata.Fill(ds);
                        Repeater1.DataSource = ds.Tables[0];
                        Repeater1.DataBind();
                    }
                }
            }
        }


        protected void RadioButtonTS_CheckedChanged(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter mydata = new SqlDataAdapter("Select DISTINCT Start_Time From TimeSlot where Day='" + HiddenFieldDay.Value + "'", con);
            mydata.Fill(ds);
            DropDownListTS.DataSource = ds;
            DropDownListTS.DataTextField = "Start_Time";
            DropDownListTS.DataValueField = "Start_Time";
            DropDownListTS.DataBind();
            DropDownListTS.Items.Insert(0, new ListItem("Select", "0"));

            DropDownListTS.Visible = true;
            DropDownListDoc.Visible = false;

            con.Close();
        }

        protected void RadioButtonDoc_CheckedChanged(object sender, EventArgs e)
        {
            DropDownListDoc.Visible = true;
            DropDownListTS.Visible = false;
        }

        protected void DropDownListDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            con.Open();
            string DocQuery = "Select User_id From User_Reg_Details where Full_Name='" + DropDownListDoc.SelectedItem.Text + "'";
            SqlCommand comm = new SqlCommand(DocQuery, con);
            HiddenFieldDoc.Value = Convert.ToString(comm.ExecuteScalar());
            Session["Doc_id"] = HiddenFieldDoc.Value;
            this.SetDataToRepeaterDoc();
            con.Close();
        }
    }
    }
