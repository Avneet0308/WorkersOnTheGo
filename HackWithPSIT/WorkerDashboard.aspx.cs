using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace HackWithPSIT
{
    public partial class WorkerDashboard : System.Web.UI.Page
    {
        String id, tableName;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            //tableName = Request.QueryString["tb"];
            Image1.ImageUrl = "Handler1.ashx?id=" + id;
            SqlCommand cmd1 = new SqlCommand("Select OrderId from worker_Detail where id="+id+"",conn);
            conn.Open();
            String order = cmd1.ExecuteScalar().ToString();
            string constr = ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString;
            SqlCommand cmdName = new SqlCommand("select name from Worker_Detail where id='" + id + "' ", conn);
            SqlCommand cmdDOB = new SqlCommand("select dob from Worker_Detail where id='" + id + "' ", conn);
            SqlCommand cmdMOB = new SqlCommand("select PhoneNo from Worker_Detail where id='" + id + "' ", conn);
            SqlCommand cmdGender = new SqlCommand("select Gender from Worker_Detail where id='" + id + "' ", conn);
            SqlCommand cmdEmail = new SqlCommand("select Email from Worker_Detail where id='" + id + "' ", conn);
            SqlCommand cmdImg = new SqlCommand("select ProfilePic from Worker_Detail where id='" + id + "' ", conn);
            NameLabel.Text = cmdName.ExecuteScalar().ToString();
            DOBLabel.Text = cmdDOB.ExecuteScalar().ToString();
            PhoneNoLabel.Text = cmdMOB.ExecuteScalar().ToString();
            EmailLabel.Text = cmdEmail.ExecuteScalar().ToString();
            GenderLabel.Text = cmdGender.ExecuteScalar().ToString();
            conn.Close();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Name,Address,PhoneNo,Gender,Email FROM Customer_Detail where id=" +order +""))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        //Create a new DataTable.
                        DataTable dtCustomers = new DataTable("WokersOnTheGo");

                        //Load DataReader into the DataTable.
                        dtCustomers.Load(sdr);

                        GridView1.DataSource = dtCustomers;
                        GridView1.DataBind();
                    }
                    conn.Close();
                }
            }
        
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}