using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BUISNESS_MEDIA
{
    public partial class office_sigunup : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        Byte[] imgByte;
        FileUpload img2;
        string username2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                {
                    Response.Redirect("Userlogin.aspx");

                }
                else
                {
                    Response.ClearHeaders();
                    Response.AppendHeader("Cache-Control", "no-store,max-age-0,must-revalidate");
                    Response.AddHeader("Pragma", "no-cache");

                }
                username2=Session["username"].ToString();
                username.Text = username2;
              
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            
            
            FileUpload img = (FileUpload)imgUpload;

            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = imgUpload.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                imgUpload = img;

                SqlCommand cmd = new SqlCommand("insert into office_table values(@office_name,@user_name,@profile_pic,@office_creation_date,@office_bio,@active_status,@privacy_type,@Expert_tag)", con);

                SqlCommand cmd1 = new SqlCommand("select count(*) from office_table where user_name=@office_name", con);
                cmd1.Parameters.AddWithValue("@office_name",name.Text);
                cmd.Parameters.AddWithValue("@office_name",name.Text);

                cmd.Parameters.AddWithValue("@user_name", username.Text);
                cmd.Parameters.AddWithValue("@privacy_type", 0);
                cmd.Parameters.AddWithValue("@profile_pic", imgByte);
                cmd.Parameters.AddWithValue("@office_creation_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@office_bio", bio.Text);
                cmd.Parameters.AddWithValue("@Expert_tag", "not assign");
                cmd.Parameters.AddWithValue("@active_status", 1);

                con.Open();
                int check = Convert.ToInt32(cmd1.ExecuteScalar());
                con.Close();
                if (check > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('officename already taken choose diffrent username')", true);

                }
                else
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registered successfully')", true);
                    Response.Redirect("office.aspx");
                    
                }

            }

        }
    }
}