using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

using System.Net;
using System.Net.Mail;
using System.IO;
using System.Collections.Specialized;

namespace HackWithPSIT
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ConnectionString);
        static Random random = new Random();
        protected void SendOTP(String Email)
        {
            //try
            //{

            SqlCommand cmd = new SqlCommand("SELECT MAX(OTP) FROM OTPT", conn);
            conn.Open();
            String otp = cmd.ExecuteScalar().ToString();
            conn.Close();
            //string to = log.Text; //To address    
            string from = "avneetvishnoi414@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, Email);
            string mailbody = "Your required OTP is " + otp;
            message.Subject = "This is the OTP required for this session of Login";
            message.Body = mailbody;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("avneetvishnoi414@gmail.com", "lallolal03");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.Send(message);

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Table2.Visible = false;
                Label1.Visible=false;
                Table3.Visible = false;
            }
            
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Table1.Visible = false;
            Table2.Visible = true;
        }

        protected void Resend_Button_Click(object sender, EventArgs e)
        {

            // try
            //{

            String tableName = DropDownList2.SelectedItem + "_detail";
            if (tableName.Equals("---SELECT---_detail"))
            {
                MsgBox("Please Select Customer or Worker", this);
            }
            else
            {
                conn.Open();
                string checkUser = "select count(*) from " + tableName + " where email='" + TextBox_EmailId_Fo.Text + "'";
                //SqlCommand cmd2 = new SqlCommand("SELECT m_no FROM " + tableName + " where email='" + TextBox_EmailId_Fo.Text + "'", conn);
                SqlCommand com = new SqlCommand(checkUser, conn);
                //String number = cmd2.ExecuteScalar().ToString();
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
                if (temp == 1)
                {
                    conn.Open();
                    SqlCommand cmd5 = new SqlCommand("UPDATE OTPT SET OTP='" + (random.Next(1000, 9999)) + "' WHERE SrNo = 1", conn);
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);

                    cmd5.ExecuteNonQuery();
                    conn.Close();

                    SendOTP(TextBox_EmailId_Fo.Text.ToString());
                    Label1.Text = "OTP Sent to Email Id.........";
                    Label1.Visible = true;
                    Resend_Button.Text = "Resend";


                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
                    Label1.Text = "Email Id Doesn't exists...";
                    Label1.Visible = true;
                }
                /*}
                catch (Exception ex)
                {
                    Response.Redirect("../error_404_2.html");
                    //throw ex;
                }
                finally
                {
                    conn.Close();
                }*/
            }
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
            String tableName = DropDownList1.SelectedItem + "_detail";
            if (log.Text.ToString().Trim() == "")
            {
                MsgBox("Please Enter User Name.", this);
            }
            else
                if (pass.Text.ToString().Trim() == "")
                {
                    MsgBox("Please Enter Password.", this);
                }
                else
                    if (log.Text == "avneetvishnoi420@gmail.com" && pass.Text == "lallolal03")
                            Response.Redirect("AdminDashboard.aspx");
                    
                    else
                    {
                        if (tableName.Equals("---SELECT---_detail"))
                            MsgBox("Please Select Customer or Worker", this);
                        else
                        {
                            conn.Open();
                            string checkUser = "select count(*) from " + tableName + " where email='" + log.Text + "'";
                            SqlCommand com = new SqlCommand(checkUser, conn);
                            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                            conn.Close();
                            if (temp == 1)
                            {

                                string checkPassword = "select Password from " + tableName + " where email='" + log.Text + "'";
                                SqlCommand cmd = new SqlCommand(checkPassword, conn);
                                conn.Open();
                                string passw = cmd.ExecuteScalar().ToString();
                                conn.Close();

                                //Response.Write(checkPassword);
                                if (passw == pass.Text)
                                {

                                    if (DropDownList1.SelectedIndex == 1)
                                    {

                                        SqlCommand cmdid = new SqlCommand("select id from " + tableName + " where email='" + log.Text + "'", conn);
                                        conn.Open();
                                        String idmain = cmdid.ExecuteScalar().ToString();
                                        conn.Close();
                                        HiddenField1.Value = idmain;
                                        Response.Redirect("UserDashBoard.aspx?id=" + idmain + "&tb=" + tableName + "");
                                    }

                                    else
                                    {
                                        SqlCommand cmdid = new SqlCommand("select id from " + tableName + " where email='" + log.Text + "'", conn);
                                        conn.Open();
                                        String idmain = cmdid.ExecuteScalar().ToString();
                                        conn.Close();
                                        HiddenField1.Value = idmain;
                                        Response.Redirect("WorkerDashboard.aspx?id=" + idmain + "");
                                    }
                                        
                                }
                                else
                                    MsgBox("Invalid Password....", this);

                            }
                            else
                                MsgBox("No such Email Id....", this);

                        }
                        /*}
                        catch (Exception ex)
                        {
                            Response.Redirect("../error_404_2.html");
                            //throw ex;
                        }
                        finally
                        {
                            conn.Close();
                        }*/
                    }
        }

        protected void Button_Submit_Fo_Click(object sender, EventArgs e)
        {
        //try
        //{
        String tableName = DropDownList2.SelectedItem + "_detail";
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 OTP FROM OTPT ORDER BY OTP DESC", conn);
            conn.Open();
            String otp = cmd.ExecuteScalar().ToString();
            conn.Close();
            if (TextBox_OTP_Fo.Text == otp)
            {
                Table2.Visible = false;
                Table3.Visible = true;
                Label1.Visible=false;
                /*if (TextBox_Password_Fo.Text != TextBox_CPassword_Fo.Text)
                {
                    objfunc.MsgBox("Both Passwords must be same....", this);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE "+tableName+" SET Password='" + TextBox_Password_Fo.Text + "' WHERE email='" + TextBox_EmailId_Fo.Text + "'", conn);
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect(Request.RawUrl.ToString()); // redirect on itself
                    //objfunc.MsgBox("Password Successfully reset....", this);
                }*/
            }

            else
            {
                Label1.Text = "Entered Wrong OTP.....";
                Label1.Visible = true;
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
            }
        /*}
        catch (Exception ex)
        {
            Response.Redirect("../error_404_2.html");
            //throw ex;
        }*/
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String tableName = DropDownList2.SelectedItem + "_detail";
            if (TextBox1.Text != TextBox2.Text)
            {
                MsgBox("Both Passwords must be same....", this);
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE " + tableName + " SET Password='" + TextBox1.Text + "' WHERE email='" + TextBox_EmailId_Fo.Text + "'", conn);
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("PasswordChanged.aspx"); // redirect on itself
                //objfunc.MsgBox("Password Successfully reset....", this);
            }
        }


    }
}