using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;



namespace BUISNESS_MEDIA
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static String otp;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        Byte[] imgByte;
        FileUpload img2;
        HttpPostedFile File2;
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void BtnSendOTP_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                otp = random.Next(100001, 999999).ToString();
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("18bmiit083@gmail.com", "Zeelpatel29052000");
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage();
                msg.Subject = "Business Media - Registration";
                msg.Body = "Dear " + email.Text + " Your OTP for registration is " + otp + "\n\n\nThanks & Regards \nShailesh";
                msg.To.Add(email.Text);
                msg.From = new MailAddress("<18bmiit083@gmail.com>");
                try
                {
                    smtp.Send(msg);
                    LblMsg.Text = "OTP Send Successfully!";
                    LblMsg.Visible = true;
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void input_Click(object sender, EventArgs e)
        {
            int gender = 0;
            if (male.Checked == true)
            {
                gender = 1;
            }
            if(female.Checked==true)
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

                SqlCommand cmd = new SqlCommand("insert into tbluserdata values(@user_name,@password,@name,@privacy_type,@category,@email_id,@contact_number,@date_of_birt,@gender,@occupation,@skill,@address,@profile_pic,@star_count,@user_bio,@label,@active_status,@cur_d)", con);

                SqlCommand cmd1 = new SqlCommand("select count(*) from tbluserdata where user_name=@user_name", con);
                cmd1.Parameters.AddWithValue("@user_name", username.Text);
                cmd.Parameters.AddWithValue("@user_name", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@privacy_type", 0);
                cmd.Parameters.AddWithValue("@category", category.Text);
                cmd.Parameters.AddWithValue("@email_id", email.Text);
                cmd.Parameters.AddWithValue("@contact_number", contact.Text);
                cmd.Parameters.AddWithValue("@date_of_birt", date.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@occupation", occupation.Text);
                cmd.Parameters.AddWithValue("@skill", skills.Text);
                cmd.Parameters.AddWithValue("@address", adress.Text);
                cmd.Parameters.AddWithValue("@profile_pic", imgByte);
                cmd.Parameters.AddWithValue("@star_count", 0);
                cmd.Parameters.AddWithValue("@user_bio", bio.Text);
                cmd.Parameters.AddWithValue("@label", "not assign");
                cmd.Parameters.AddWithValue("@active_status", 1);
                cmd.Parameters.AddWithValue("@cur_d", DateTime.Now);
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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registered successfully')", true);
                    Response.Redirect("userlogin.aspx");
                    
                }

            }


        }
    }
}