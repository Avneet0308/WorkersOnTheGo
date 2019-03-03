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
    public partial class UserDashBoard : System.Web.UI.Page
    {
        String id,tableName;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            tableName=Request.QueryString["tb"];
            Image1.ImageUrl = "ImageHandler1.ashx?id=" + id;
            //id = "3";
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConn"].ConnectionString);
            
        
           SqlCommand cmdName = new SqlCommand("select name from Customer_Detail where id='" + id + "' ", conn);
            SqlCommand cmdDOB = new SqlCommand("select dob from Customer_Detail where id='" + id + "' ", conn);
            SqlCommand cmdMOB = new SqlCommand("select PhoneNo from Customer_Detail where id='" + id + "' ", conn);
            SqlCommand cmdGender = new SqlCommand("select Gender from Customer_Detail where id='" + id + "' ", conn);
            SqlCommand cmdEmail = new SqlCommand("select Email from Customer_Detail where id='" + id + "' ", conn);
            SqlCommand cmdImg = new SqlCommand("select ProfilePic from Customer_Detail where id='" + id + "' ", conn);
            //SqlCommand cmdCity = new SqlCommand("select City from City", conn);
            /*string constr = ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Name FROM Customer_Detail"))
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
            }*/
            
            conn.Open();
            NameLabel.Text = cmdName.ExecuteScalar().ToString();
            DOBLabel.Text = cmdDOB.ExecuteScalar().ToString();
            PhoneNoLabel.Text = cmdMOB.ExecuteScalar().ToString();
            EmailLabel.Text = cmdEmail.ExecuteScalar().ToString();
            GenderLabel.Text = cmdGender.ExecuteScalar().ToString();
            conn.Close();
            if (!IsPostBack)
            {
                conn.Open();
                SqlCommand com = new SqlCommand("select * from City", conn); // table name 
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();

                da.Fill(ds);  // fill dataset
                DropDownList1.DataTextField = ds.Tables[0].Columns["city"].ToString(); // text field name of table dispalyed in dropdown
                //DropDownList1.DataValueField = ds.Tables[0].Columns["id"].ToString();
                // to retrive specific  textfield name 
                DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                DropDownList1.DataBind();  //binding dropdownlist
                conn.Close();
            }
            
            
            //DropDownList1.Items.Insert(0, new ListItem("---Select City---", "0"));
        }






        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select distinct Type from Worker_Detail where city='" + DropDownList1.SelectedItem.ToString() + "'", conn); // table name 
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);  // fill dataset
            DropDownList2.DataTextField = ds.Tables[0].Columns["Type"].ToString(); // text field name of table dispalyed in dropdown
           // DropDownList1.DataValueField = ds.Tables[0].Columns["id"].ToString();  
            // to retrive specific  textfield name 
            DropDownList2.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            DropDownList2.DataBind();  //binding dropdownlist
            conn.Close();
            DropDownList2.Items.Insert(0, new ListItem("---Select WorkerType---", "0"));
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Name,PhoneNo,Gender,Email FROM Worker_Detail where city='" + DropDownList1.SelectedValue.ToString() + "' and Type='" + DropDownList2.SelectedValue.ToString() + "'"))
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
                        SqlCommand com = new SqlCommand("SELECT Email FROM Worker_Detail where city='" + DropDownList1.SelectedValue.ToString() + "' and Type='" + DropDownList2.SelectedValue.ToString() + "'", conn); // table name 
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataSet ds = new DataSet();
                        conn.Open();
                        da.Fill(ds);  // fill dataset
                        DropDownList3.DataTextField = ds.Tables[0].Columns["Email"].ToString(); // text field name of table dispalyed in dropdown
                        // DropDownList1.DataValueField = ds.Tables[0].Columns["id"].ToString();  
                        // to retrive specific  textfield name 
                        DropDownList3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                        DropDownList3.DataBind();  //binding dropdownlist
                        conn.Close();
                        DropDownList3.Items.Insert(0, new ListItem("---Select WorkerEmail---", "0"));
                    }
                    con.Close();

                }
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("SELECT id FROM Worker_Detail where Email='" + DropDownList3.SelectedValue.ToString() + "'", conn);
            conn.Open();
            String idW = com.ExecuteScalar().ToString();
            SqlCommand com1 = new SqlCommand("insert into flag values('"+id+"','"+idW+"')", conn);
            com1.ExecuteNonQuery();
            conn.Close();
        }
    }
}