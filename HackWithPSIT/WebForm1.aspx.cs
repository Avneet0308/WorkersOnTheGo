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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["asd"].ConnectionString);

            HttpPostedFile ps = FileUpload1.PostedFile;
            Stream stream = ps.InputStream;
            BinaryReader br = new BinaryReader(stream);
            byte[] file = br.ReadBytes((Int32)stream.Length);
            String sql = "INSERT INTO dfg VALUES (@asd,'1')";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.Parameters.AddWithValue("@asd", file);
            SqlCommand cmdImg = new SqlCommand("select img from dfg where id='" + 1 + "' ", conn);
            conn.Open();
            cmd1.ExecuteNonQuery();
            Image1.ImageUrl = "data:Image/jpg;base64" + Convert.ToBase64String((byte[])(cmdImg.ExecuteScalar()),0,file.Length);
            /*if (Convert.ToBase64String(file) == Convert.ToBase64String((byte[])(cmdImg.ExecuteScalar()),0,file.Length))
                Response.Write("Fuck");*/
            //Response.Write(Convert.ToBase64String((byte[])(cmdImg.ExecuteScalar())));
            conn.Close();
        }
    }
}