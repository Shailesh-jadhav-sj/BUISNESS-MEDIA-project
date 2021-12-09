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
    public partial class assign : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            if (Session["office_name"] == null)
            {
                Response.Redirect("office.aspx");

            }
            else
            {
                Response.ClearHeaders();
                Response.AppendHeader("Cache-Control", "no-store,max-age-0,must-revalidate");
                Response.AddHeader("Pragma", "no-cache");

            }
            string name1 = Session["office_name"].ToString();
            if (!IsPostBack)
            {
                SqlCommand cmdc = new SqlCommand("select * from office_cubic_table where office_id=(select id from office_table where office_name= @username ) ", con);
                cmdc.Parameters.AddWithValue("@username", name1);

                con.Open();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da5 = new SqlDataAdapter(cmdc);
                da5.Fill(dt1);
                DropDownList1.DataSource = dt1;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "user_name";
                DropDownList1.DataValueField = "user_name";
                DropDownList1.DataBind();
                con.Close();
                view1();
            }
            //Session.Remove("office_name");
            TextBox1.Text = name1;
            SqlCommand cmd1 = new SqlCommand("select profile_pic from office_table where office_name=@user_name", con);
            cmd1.Parameters.AddWithValue("@user_name", Session["office_name"].ToString());

            con.Open();
            if (cmd1.ExecuteScalar() != null)
            {
                byte[] bytes = (byte[])cmd1.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                profilepic.ImageUrl = "data:Image;base64," + strBase64;
            }
            con.Close();

            SqlCommand cmd = new SqlCommand("select * from office_table where office_name=@user_name", con);
            cmd.Parameters.AddWithValue("@user_name", Session["office_name"].ToString());
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TextBox1.Text = dt.Rows[0]["office_name"].ToString();
            // TextBox2.Text = dt.Rows[0]["privacy_type"].ToString();
            //TextBox3.Text = dt.Rows[0]["office_creation_date"].ToString();
            int privacy = Int32.Parse(dt.Rows[0]["privacy_type"].ToString());
            if (privacy == 0)
            {
                TextBox2.Text = "Public";
            }
            else
            {
                TextBox2.Text = "Private";
            }
            TextBox3.Text = DateTime.Parse(dt.Rows[0]["office_creation_date"].ToString()).ToString("dd-MM-yyyy");




            int pt = Int32.Parse(dt.Rows[0]["privacy_type"].ToString());

            int joined_cubicles = 0;
            int assign_tasks = 0;
            int finish_tasks = 0;
            SqlCommand cmd2 = new SqlCommand("select count(*) from office_cubic_table  where office_id  IN (select id from office_table where office_name=@user_name) ", con);
            cmd2.Parameters.AddWithValue("@user_name", Session["office_name"].ToString());
            SqlCommand cmd3 = new SqlCommand("select count(*) from user_connection_table where follower_name=@user_name and connection_status=0", con);
            cmd3.Parameters.AddWithValue("@user_name", Session["username"].ToString());
            SqlCommand cmd5 = new SqlCommand("select count(*) from user_connection_table where account_name=@user_name and connection_status=1", con);
            cmd5.Parameters.AddWithValue("@user_name", Session["username"].ToString());

            joined_cubicles = Int32.Parse(cmd2.ExecuteScalar().ToString());
            //following = Int32.Parse(cmd3.ExecuteScalar().ToString());
            //Request = Int32.Parse(cmd5.ExecuteScalar().ToString());
            if (joined_cubicles == null)
            {
                joined_cubicles = 0;

            }
            TextBox4.Text = joined_cubicles.ToString();

            con.Close();

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
                            SqlCommand com1 = new SqlCommand("select cubic_id from office_cubic_table where user_name = @cubic_id", con);
                            com1.Parameters.AddWithValue("@cubic_id", DropDownList1.SelectedItem.Value);
                            con.Open();
                            string s = com1.ExecuteScalar().ToString();
                            con.Close();

                            con.Open();
                            Stream fs = FileUpload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs); //reads the binary files  
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes  
                            SqlCommand com = new SqlCommand("insert into cubic_work_table (office_name,cubic_id,assign_date,office_data,deadline_date,work_status) values(@officename,@cubic_id,@assign_date,@office_data,@deadline_date,@work_status)", con);
                            com.Parameters.AddWithValue("@officename", Session["office_name"].ToString());
                            com.Parameters.AddWithValue("@cubic_id",s);
                            com.Parameters.AddWithValue("@assign_date", DateTime.Now);
                            com.Parameters.AddWithValue("@deadline_date",date.Text);
                            com.Parameters.AddWithValue("@work_status", "Assigned");
                            com.Parameters.Add("@office_data", SqlDbType.Binary).Value = bytes;
                            com.ExecuteNonQuery();
                            Label2.ForeColor = System.Drawing.Color.Green;
                            Label2.Text = "File Uploaded Successfully";
                            con.Close();
                            view1();
                            
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
        protected void view1()
        {
            SqlCommand com = new SqlCommand("select * from cubic_work_table where office_name=@officename ", con);
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
            con.Open();
            SqlCommand com = new SqlCommand("select * from cubic_work_table where work_id=@id", con);
            com.Parameters.AddWithValue("id", GridView1.SelectedRow.Cells[2].Text);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + dr["office_name"].ToString() + dr["assign_date"].ToString()+".pdf"); // to open file prompt Box open or Save file  
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["office_data"]);
                Response.End();
                con.Close();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "request")
            {

                int num = Convert.ToInt32(e.CommandArgument.ToString());

                con.Open();
                SqlCommand com = new SqlCommand("select * from cubic_work_table where work_id=@id", con);
                com.Parameters.AddWithValue("id", GridView1.Rows[num].Cells[2].Text);
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