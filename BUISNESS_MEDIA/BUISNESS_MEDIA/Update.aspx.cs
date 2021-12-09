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
    public partial class Update : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        Byte[] imgByte;
        FileUpload img2;
        HttpPostedFile File2;
        String username1;
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
                username1 = Session["username"].ToString();
                SqlCommand cmd1 = new SqlCommand("select * from tbluserdata where user_name=@user_name1", con);
                cmd1.Parameters.AddWithValue("@user_name1", username1);
               
                 con.Open();
                 DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                 cmd1.ExecuteNonQuery();
                con.Close();

                password.Text=  dt.Rows[0]["password"].ToString();
                name.Text = dt.Rows[0]["name"].ToString();
                category.Text = dt.Rows[0]["category"].ToString();
                email.Text = dt.Rows[0]["email_id"].ToString();
                contact.Text = dt.Rows[0]["contact_number"].ToString();
                
                date.Text = DateTime.Parse(dt.Rows[0]["date_of_birth"].ToString()).ToString("dd-MM-yyyy");
                int gender = Int32.Parse(dt.Rows[0]["gender"].ToString());
                if (gender == 1)
                {
                   male.Checked=true;
                }
                else
                {
                    female.Checked = true;
                }
                
                occupation.Text = dt.Rows[0]["occupation"].ToString();
                skills.Text = dt.Rows[0]["skill"].ToString();
                adress.Text = dt.Rows[0]["address"].ToString();
                bio.Text = dt.Rows[0]["user_bio"].ToString();
                SqlCommand cmd2 = new SqlCommand("select profile_pic from tbluserdata where user_name=@user_name1", con);
                cmd2.Parameters.AddWithValue("@user_name1", Session["username"].ToString());

                con.Open();
                byte[] bytes = (byte[])cmd2.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                impPrev.ImageUrl = "data:Image;base64," + strBase64;
                con.Close();
               
               
                    
                
               
            


        }

        protected void upload_Click(object sender, EventArgs e)
        {
            FileUpload img = (FileUpload)imgUpload;
            img2 = (FileUpload)imgUpload;

            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = imgUpload.PostedFile;
                File2 = File;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                imgUpload = img;
                impPrev.ImageUrl = "data:image;base64," + Convert.ToBase64String(imgByte);


            }

        }

        protected void input_Click(object sender, EventArgs e)
        {
            int gender = 0;
            if (male.Checked == true)
            {
                gender = 1;
            }
            if (female.Checked == true)
            {
                gender = 2;
            }

            FileUpload img = (FileUpload)imgUpload;
            img2 = (FileUpload)imgUpload;

            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = imgUpload.PostedFile;
                File2 = File;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                imgUpload = img;
                impPrev.ImageUrl = "data:image;base64," + Convert.ToBase64String(imgByte);



                SqlCommand cmd = new SqlCommand("update tbluserdata set user_name=@user_name,password=@password,name=@name,category=@category,email_id=@email_id,contact_number=@contact_number,date_of_birth=@date_of_birt,gender=@gender,occupation=@occupation,skill=@skill,address=@address,profile_pic=@profile_pic,user_bio=@user_bio where user_name=@user_name1", con);

                SqlCommand cmd1 = new SqlCommand("select count(*) from tbluserdata where user_name=@user_name", con);
                cmd1.Parameters.AddWithValue("@user_name", username.Text);
                cmd.Parameters.AddWithValue("@user_name1", username1);
                cmd.Parameters.AddWithValue("@user_name", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@privacy_type", 0);
                cmd.Parameters.AddWithValue("@category", category.Text);
                cmd.Parameters.AddWithValue("@email_id", email.Text);
                cmd.Parameters.AddWithValue("@contact_number", contact.Text);
                cmd.Parameters.AddWithValue("@date_of_birt",DateTime.Parse(date.Text));
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@occupation", occupation.Text);
                cmd.Parameters.AddWithValue("@skill", skills.Text);
                cmd.Parameters.AddWithValue("@address", adress.Text);
                cmd.Parameters.AddWithValue("@profile_pic", imgByte);
                cmd.Parameters.AddWithValue("@star_count", 0);
                cmd.Parameters.AddWithValue("@user_bio", bio.Text);
                cmd.Parameters.AddWithValue("@label", "not assign");
                cmd.Parameters.AddWithValue("@active_status", 1);

                con.Open();
                int check = Convert.ToInt32(cmd1.ExecuteScalar());
                con.Close();
                if (check > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('username already taken choose diffrent username')", true);

                }
                else
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session["username"] = username.Text;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('updated successfully')", true);
                    Response.Redirect("userprofile.aspx");

                }

            }
        }


        }
    }
