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
    public partial class cubic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

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
           

           
            
          int  pt = Int32.Parse(dt.Rows[0]["privacy_type"].ToString());

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
    }
}