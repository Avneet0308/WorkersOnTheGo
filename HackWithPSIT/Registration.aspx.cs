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
    public partial class Registration : System.Web.UI.Page
    {
        static String passwords;
        //DbFunctions objfun = new DbFunctions();
        //DbFunctions objFunc = new DbFunctions();
        //static Random random = new Random();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString);
        public void sendVerification()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
           // try
            //{
                
                
                Gender_Label.Visible = false;
                if (!IsPostBack)
                {
                    /*Dcourse.Items.Insert(0, "---Select Course---");
                    Dsubject.Items.Insert(0, "---Select Subject---");
                    Dmonth.Items.Insert(0, "---Select Month---");
                    Dday.Items.Insert(0, "---Select Day---");
                    objFunc.FillDropdownlist(Dcollege, "College", "SrNo", "SELECT College,SrNo FROM DropDowns", "---Select College---");
                    objFunc.FillDropdownlist(Dyear, "Year", "SrNo", "SELECT Year,SrNo FROM DropDownsYear", "---Select Year---");
                    Dcollege.Focus();*/
                    CalDiv.Visible = false;
                    LoadYears();
                    LoadMonths();
                    IDNO.Visible = false;
                    IDIM.Visible = false;
                }
                if (IsPostBack)
                {
                    if (Type1.Checked || Type2.Checked)
                    {
                        if (Type1.Checked)
                        {
                            IDNO.Visible = true;
                            IDIM.Visible = true;
                            DivType.Visible = true;
                        }
                        else
                        {
                            IDNO.Visible = false;
                            IDIM.Visible = false;
                            DivType.Visible = false;
                        }
                        if ((TextBox_EmailId.Text == "" || TextBox_FirstName.Text == "" || TextBox_LastName.Text == "" || TextBox_Address.Text == "" || TextBox1.Text=="")==false)
                        {
                            if (TextBox_EmailId.Text != "")
                            {
                                String tableName = Type1.Checked ? Type1.Text.ToString() : Type2.Text.ToString();
                                tableName += "_Detail";
                                conn.Open();
                                string checkUser = "select count(*) from " + tableName + " where Email='" + TextBox_EmailId.Text + "'";
                                SqlCommand com = new SqlCommand(checkUser, conn);
                                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                                conn.Close();
                                if (temp == 1)
                                {
                                    MsgBox("Email Id Already exists...", this);
                                }
                            }
                            else
                                MsgBox("Please Fill Email Id", this);
                        }
                    }
                    
                    

                }
            //}
            /*catch (Exception ex)
            {
                //Response.Redirect("../error_404_2.html");
                throw ex;
            }
            finally
            {
                conn.Close();
            }*/
        }
        public void MsgBox(string msg, Page refP)
        {
            Label lbl = new Label();
            string lb = "window.alert('" + msg + "')";
            ScriptManager.RegisterClientScriptBlock(refP, GetType(), "UniqueKey", lb, true);
            //ScriptManager.RegisterClientScriptBlock(refP, refP.GetType, "UniqueKey", lb, True)
            refP.Controls.Add(lbl);
        }

        


        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
            //try
            //{
                /*if ((Dcollege.SelectedItem.ToString()).Equals("---Select College---"))
                {
                    College_Label.Visible = true;
                }
                else
                    if ((Dcourse.SelectedItem.ToString()).Equals("---Select Course---"))
                    {
                        Course_Label.Visible = true;
                    }
                    else
                        if ((Dsubject.SelectedItem.ToString()).Equals("---Select Subject---"))
                        {
                            Subject_Label.Visible = true;
                        }
                        else
                            if ((Dyear.SelectedItem.ToString()).Equals("---Select Year---"))
                            {
                                Year_Label.Visible = true;
                            }
                            else
                                if ((Dmonth.SelectedItem.ToString()).Equals("---Select Month---"))
                                {
                                    Month_Label.Visible = true;
                                }
                                else
                                    if ((Dday.SelectedItem.ToString()).Equals("---Select Day---"))
                                    {
                                        Day_Label.Visible = true;
                                    }
                                    else*/
            
                                        if(!Type1.Checked&&!Type2.Checked)
                                            MsgBox("Select Customer or Worker....", this);
                                        else
                                        if (!Male_RadioButton.Checked && !Female_RadioButton.Checked && !Other_RadioButton.Checked)
                                            Gender_Label.Visible = true;
                                        else
                                            if ((TextBox_Password.Text.ToString()).Equals(""))
                                                MsgBox("Enter Password....", this);
                                            else
                                            {
                                                
                                                //passwords = "";
                                                String tableName = Type1.Checked ? Type1.Text.ToString() : Type2.Text.ToString();
                                                tableName += "_Detail";
                                                passwords = TextBox_Password.Text.ToString();
                                                String FirstName = TextBox_FirstName.Text.ToString();
                                                String LastName = TextBox_LastName.Text.ToString();
                                                String EmailId = TextBox_EmailId.Text.ToString();
                                                String MobileNumber = TextBox_MobileNumber.Text.ToString();
                                                //String CollegeId = TextBox_CollegeId.Text.ToString();
                                                String Password = passwords;
                                                String dob = TextBox1.Text.ToString();
                                                String type = Type1.Checked ? "G" : "C";
                                                /*String ConfirmPassword = passwords;
                                                String College = Dcollege.SelectedItem.ToString();
                                                String Course = Dcourse.SelectedItem.ToString();
                                                String Subject = Dsubject.SelectedItem.ToString();
                                                String Month = Dmonth.SelectedItem.ToString();
                                                int Year = Convert.ToInt32(Dyear.SelectedItem.ToString());
                                                int Day = Convert.ToInt32(Dday.SelectedItem.ToString());*/
                                                String gender = Male_RadioButton.Checked ? Male_RadioButton.Text.ToString() : (Female_RadioButton.Checked ? Female_RadioButton.Text : Other_RadioButton.Text);
                                                if (tableName.Equals("Customer_Detail"))
                                                {
                                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString))
                                                    {
                                                        HttpPostedFile ps = FileUpload1.PostedFile;
                                                        Stream stream = ps.InputStream;
                                                        BinaryReader br = new BinaryReader(stream);
                                                        byte[] file = br.ReadBytes((Int32)stream.Length);
                                                        String sql = "INSERT INTO " + tableName + " (Name,Address,City,ProfilePic,PhoneNo,Email,Password,Gender,DOB,Verification) VALUES ('" + FirstName +" "+ LastName + "','" + TextBox_Address.Text + "','"+TextBox_City.Text.ToString()+"',@asd,'" + MobileNumber + "','" + EmailId + "','" + Password + "','" + gender + "','" + dob + "','f') ";
                                                        SqlCommand cmd1 = new SqlCommand(sql, conn);
                                                        cmd1.Parameters.AddWithValue("@asd", file);
                                                        conn.Open();
                                                        cmd1.ExecuteNonQuery();
                                                        conn.Close();
                                                        Response.Redirect("Login.aspx");
                                                    }
                                                }
                                                else
                                                {
                                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString))
                                                    {
                                                        HttpPostedFile ps = FileUpload1.PostedFile;
                                                        Stream stream = ps.InputStream;
                                                        BinaryReader br = new BinaryReader(stream);
                                                        byte[] file = br.ReadBytes((int)stream.Length);
                                                        if (!(FileUpload2 == null))
                                                        {
                                                            HttpPostedFile ps1 = FileUpload2.PostedFile;
                                                            Stream stream1 = ps1.InputStream;
                                                            BinaryReader br1 = new BinaryReader(stream1);
                                                            byte[] file1 = br1.ReadBytes((int)stream.Length);

                                                            String sql = "INSERT INTO " + tableName + " (Name,Address,City,ProfilePic,PhoneNo,Email,Password,Gender,DOB,IdProofNo,IdProofPic,Verification,Type) VALUES ('" + FirstName + " " + LastName + "','" + TextBox_Address.Text + "','" + TextBox_City.Text.ToString() + "',@asd,'" + MobileNumber + "','" + EmailId + "','" + Password + "','" + gender + "','" + dob + "','" + TextBox2.Text + "',@aasd,'f','"+TextBox_WType.Text.ToString()+"') ";
                                                            SqlCommand cmd1 = new SqlCommand(sql, conn);
                                                            cmd1.Parameters.AddWithValue("@asd", file);
                                                            cmd1.Parameters.AddWithValue("@aasd", file1);
                                                            conn.Open();
                                                            cmd1.ExecuteNonQuery();
                                                            conn.Close();
                                                            Response.Redirect("Login.aspx");
                                                        }
                                                    }
                                                }
                            }
            }



        private void LoadMonths()
        {
            DataSet dsMonths = new DataSet();
            dsMonths.ReadXml(Server.MapPath("~/Months.xml"));

            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "Number";

            DropDownList2.DataSource = dsMonths;
            DropDownList2.DataBind();
        }

        private void LoadYears()
        {
            DataSet dsYears = new DataSet();
            dsYears.ReadXml(Server.MapPath("~/Years.xml"));

            DropDownList1.DataTextField = "Number";
            DropDownList1.DataValueField = "Number";

            DropDownList1.DataSource = dsYears;
            DropDownList1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = Convert.ToInt16(DropDownList1.SelectedValue);
            int month = Convert.ToInt16(DropDownList2.SelectedValue);
            Calendar1.VisibleDate = new DateTime(year, month, 1);
            Calendar1.SelectedDate = new DateTime(year, month, 1);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = Convert.ToInt16(DropDownList1.SelectedValue);
            int month = Convert.ToInt16(DropDownList2.SelectedValue);
            Calendar1.VisibleDate = new DateTime(year, month, 1);
            Calendar1.SelectedDate = new DateTime(year, month, 1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
            MainDiv.Visible = true;
            CalDiv.Visible = false;

        }


        protected void Calendar1_DayRender1(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.Red;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            MainDiv.Visible = false;
            CalDiv.Visible = true;
        }


            /*}
            catch (Exception ex)
            {
                //Response.Redirect("../error_404_2.html");
                throw ex;
            }
            finally
            {
                conn.Close();
            }*/
        }
        
    }
