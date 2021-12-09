using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.IO;

namespace BUISNESS_MEDIA
{
    public partial class work : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["office_name"] == null)
            {
                Response.Redirect("office.aspx");
            }
            string name1 = Session["office_name"].ToString();
            TextBox1.Text = Session["office_name"].ToString();
            refresh();
        
        }
        protected void refresh( )
        {
            SqlCommand com = new SqlCommand("select work_id,office_name,assign_date,deadline_date,work_status,cubic_data from cubic_work_table where office_name=@officename ", con);
            com.Parameters.AddWithValue("@officename", Session["office_name"].ToString());

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value=GridView1.SelectedValue.ToString();
            Label2.Text = value;
            con.Open();
            SqlCommand com = new SqlCommand("select * from cubic_work_table where work_id=@id", con);
            com.Parameters.AddWithValue("id",value);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + dr["office_name"].ToString() + dr["assign_date"].ToString() + ".pdf"); // to open file prompt Box open or Save file  
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["office_data"]);
                Response.End();
                con.Close();
            }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "request")
            {

                int num = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)GridView1.Rows[num];



                FileUpload FileUpload1 = (FileUpload)row.FindControl("FileUpload1");


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
                                SqlCommand com = new SqlCommand("update cubic_work_table set cubic_data=@office_data ,work_status='completed' where work_id=@work_id  ", con);
                                com.Parameters.AddWithValue("@work_id", GridView1.Rows[num].Cells[4].Text);

                                com.Parameters.Add("@office_data", SqlDbType.Binary).Value = bytes;
                                com.ExecuteNonQuery();
                                Label2.ForeColor = System.Drawing.Color.Green;
                                Label2.Text = "File Uploaded Successfully";
                                refresh();
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
            else if (e.CommandName != "submit")
              {
                  
                  int num= Convert.ToInt32(e.CommandArgument.ToString());
                 
                  con.Open();
                  SqlCommand com = new SqlCommand("select * from cubic_work_table where work_id=@id", con);
                  com.Parameters.AddWithValue("id", GridView1.Rows[num].Cells[4].Text);
                  SqlDataReader dr = com.ExecuteReader();
                  if (dr.Read())
                  {
                      Response.Clear();
                      Response.Buffer = true;
                      Response.ContentType = "application/pdf";
                      Response.AddHeader("content-disposition", "attachment;filename=" + dr["office_name"].ToString() + dr["assign_date"].ToString() + ".pdf"); // to open file prompt Box open or Save file  
                      Response.Charset = "";
                      Response.Cache.SetCacheability(HttpCacheability.NoCache);
                      Response.BinaryWrite((byte[])dr["cubic_data"]);
                      Response.End();
                      con.Close();
                  }
               }
        }
       
    }
}