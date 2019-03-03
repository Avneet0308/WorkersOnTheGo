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
    /// <summary>
    /// Summary description for ImageHandler1
    /// </summary>
    public class ImageHandler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string roll_no = context.Request.QueryString["id"].ToString();
            string sConn = System.Configuration.ConfigurationManager.ConnectionStrings["WorkersOnTheGo"].ToString();
            SqlConnection objConn = new SqlConnection(sConn);
            objConn.Open();
            string sTSQL = "select ProfilePic from Customer_Detail where id=@roll_no";
            SqlCommand objCmd = new SqlCommand(sTSQL, objConn);
            objCmd.CommandType = CommandType.Text;
            objCmd.Parameters.AddWithValue("@roll_no", roll_no.ToString());
            object data = objCmd.ExecuteScalar();
            objConn.Close();
            objCmd.Dispose();
            context.Response.BinaryWrite((byte[])data); 
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}