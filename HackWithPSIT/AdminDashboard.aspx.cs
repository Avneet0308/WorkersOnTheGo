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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from flag"))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        //Create a new DataTable.
                        DataTable dtCustomers = new DataTable("WorkersOnTheGo");

                        //Load DataReader into the DataTable.
                        dtCustomers.Load(sdr);

                        GridView1.DataSource = dtCustomers;
                        GridView1.DataBind();
                    }
                    con.Close();
                }
            }
            if (!IsPostBack)
            {
                SqlCommand com = new SqlCommand("SELECT WorkerId FROM flag", conn); // table name 
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                conn.Open();
                da.Fill(ds);  // fill dataset
                DropDownList3.DataTextField = ds.Tables[0].Columns["WorkerId"].ToString(); // text field name of table dispalyed in dropdown
                // DropDownList1.DataValueField = ds.Tables[0].Columns["id"].ToString();  
                // to retrive specific  textfield name 
                DropDownList3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                DropDownList3.DataBind();  //binding dropdownlist
                conn.Close();
                DropDownList3.Items.Insert(0, new ListItem("---Select WorkerId---", "0"));
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlCommand com = new SqlCommand("select OrderId from Worker_Detail", conn); // table name
            SqlCommand com2 = new SqlCommand("select UserId from flag where WorkerId='" + DropDownList3.SelectedValue.ToString() + "'", conn);
            conn.Open();
            //String order = com.ExecuteScalar().ToString();
            //order+=" "+DropDownList3.SelectedValue.ToString();
            String order=com2.ExecuteScalar().ToString();
            SqlCommand com1 = new SqlCommand("update Worker_Detail set OrderId='" + order + "' where id='" + DropDownList3.SelectedValue.ToString() + "'", conn); // table name
            com1.ExecuteNonQuery();
            SqlCommand com3 = new SqlCommand("delete from flag where WorkerId='" + DropDownList3.SelectedValue.ToString() + "'", conn); // table name
            com3.ExecuteNonQuery();
            conn.Close();
            SqlCommand cmdName = new SqlCommand("select name from Customer_Detail where id='" + order + "' ", conn);
            SqlCommand cmdAdd = new SqlCommand("select Address from Customer_Detail where id='" + order + "' ", conn);
            SqlCommand cmdMOB = new SqlCommand("select PhoneNo from Customer_Detail where id='" + order + "' ", conn);
            //SqlCommand cmdGender = new SqlCommand("select Gender from Customer_Detail where id='" + order + "' ", conn);
            SqlCommand cmdEmail = new SqlCommand("select Email from Customer_Detail where id='" + order + "' ", conn);
            SqlCommand cmdEmail2 = new SqlCommand("select Email from Worker_Detail where id='" + DropDownList3.SelectedValue.ToString() + "' ", conn);
            //SqlCommand cmdImg = new SqlCommand("select ProfilePic from Customer_Detail where id='" + order + "' ", conn);
            conn.Open();
            String Uname = cmdName.ExecuteScalar().ToString();
            String UAdd = cmdAdd.ExecuteScalar().ToString();
            String UMob = cmdMOB.ExecuteScalar().ToString();
            String UEmail = cmdEmail.ExecuteScalar().ToString();
            String WEmail = cmdEmail2.ExecuteScalar().ToString();
            conn.Close();
            //string to = log.Text; //To address    
            string from = "avneetvishnoi414@gmail.com"; //From address    
            MailMessage message = new MailMessage(from,WEmail );
            string mailbody = " Name: " + Uname + " Address: " + UAdd+" Mobile number: "+UMob+" Email: "+UEmail+" Of the customer";
            message.Subject = "The Details of User :";
            message.Body = mailbody;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("avneetvishnoi414@gmail.com", "lallolal03");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.Send(message);
        }
    }
}