﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace BUISNESS_MEDIA
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string query;
        SqlCommand com;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            string filePath = FileUpload1.PostedFile.FileName; // getting the file path of uploaded file  
            string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file  
            string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file  
            string type = String.Empty;
            if (!FileUpload1.HasFile)
            {
                Label2.Text = "Please Select File"; //if file uploader has no file selected  
            }
            else
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        switch (ext) // this switch code validate the files which allow to upload only PDF file   
                        {
                            case ".pdf":
                                type = "application/pdf";
                                break;
                        }
                        if (type != String.Empty)
                        {
                            con.Open();
                            Stream fs = FileUpload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs); //reads the binary files  
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes  
                            query = "insert into PDFFiles (Name,type,data)" + " values (@Name, @type, @Data)"; //insert query  
                            com = new SqlCommand(query, con);
                            com.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename1;
                            com.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
                            com.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                            com.ExecuteNonQuery();
                            Label2.ForeColor = System.Drawing.Color.Green;
                            Label2.Text = "File Uploaded Successfully";
                        }
                        else
                        {
                            Label2.ForeColor = System.Drawing.Color.Red;
                            Label2.Text = "Select Only PDF Files "; // if file is other than speified extension   
                        }
                    }
                    catch (Exception ex)
                    {
                        Label2.Text = "Error: " + ex.Message.ToString();
                    }
                }
        }
    protected void Button2_Click(object sender, EventArgs e) {  
       
        con.Open();
        query = "Select * from PDFFiles";  
        SqlDataAdapter da = new SqlDataAdapter(query, con);  
        DataSet ds = new DataSet();  
        da.Fill(ds);  
        GridView1.DataSource = ds;  
        GridView1.DataBind();  
        con.Close();  
    }  
        

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {
        con.Open();
    SqlCommand com = new SqlCommand("select Name,type,data from PDFFiles where id=@id", con);  
    com.Parameters.AddWithValue("id", GridView1.SelectedRow.Cells[1].Text);  
    SqlDataReader dr = com.ExecuteReader();  
    if (dr.Read()) {  
        Response.Clear();  
        Response.Buffer = true;  
        Response.ContentType = dr["type"].ToString();  
        Response.AddHeader("content-disposition", "attachment;filename=" + dr["Name"].ToString()); // to open file prompt Box open or Save file  
        Response.Charset = "";  
        Response.Cache.SetCacheability(HttpCacheability.NoCache);  
        Response.BinaryWrite((byte[]) dr["data"]);  
        Response.End();
        con.Close();
    }  
} 
    }
}