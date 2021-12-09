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
    public partial class userprofile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        int pt;
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();

            if (!IsPostBack)
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


            }
            //    SqlCommand cmd1 = new SqlCommand("select profile_pic from tbluserdata where user_name=@user_name", con);
            //    cmd1.Parameters.AddWithValue("@user_name", Session["username"].ToString());

            //    con.Open();
            //    if (cmd1.ExecuteScalar() != null)
            //    {
            //        byte[] bytes = (byte[])cmd1.ExecuteScalar();
            //        string strBase64 = Convert.ToBase64String(bytes);
            //        profilepic.ImageUrl = "data:Image;base64," + strBase64;
            //    }
            //    con.Close();
            //    SqlCommand cmd = new SqlCommand("select * from tbluserdata where user_name=@user_name", con);
            //    cmd.Parameters.AddWithValue("@user_name", Session["username"].ToString());
            //    con.Open();
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    da.Fill(dt);
            //    namebox.Text = dt.Rows[0]["user_name"].ToString();
            //    TextBox1.Text = dt.Rows[0]["name"].ToString();
            //    TextBox2.Text = dt.Rows[0]["category"].ToString();
            //    TextBox3.Text = dt.Rows[0]["email_id"].ToString();
            //    TextBox4.Text = dt.Rows[0]["contact_number"].ToString();
            //    int privacy = Int32.Parse(dt.Rows[0]["privacy_type"].ToString());
            //    if (privacy == 0)
            //    {
            //        TextBox5.Text = "Public";
            //    }
            //    else
            //    {
            //        TextBox5.Text = "Private";
            //    }
            //    TextBox6.Text = DateTime.Parse(dt.Rows[0]["date_of_birth"].ToString()).ToString("dd-MM-yyyy");
            //    int gender = Int32.Parse(dt.Rows[0]["gender"].ToString());
            //    if (gender == 1)
            //    {
            //        TextBox7.Text = "Male";
            //    }
            //    else
            //    {
            //        TextBox7.Text = "Female";
            //    }
                
            //    TextBox8.Text = dt.Rows[0]["occupation"].ToString();
            //    TextBox9.Text = dt.Rows[0]["skill"].ToString();
            //    TextBox10.Text = dt.Rows[0]["address"].ToString();
            //    //star3.Text = dt.Rows[0]["star_count"].ToString();
            //    TextBox12.Text = dt.Rows[0]["user_bio"].ToString();
            //    TextBox13.Text = dt.Rows[0]["expert_tag"].ToString();
            //    pt = Int32.Parse(dt.Rows[0]["privacy_type"].ToString());
                
            //TextBox14.Text = DateTime.Parse(dt.Rows[0]["creation_date"].ToString()).ToString("dd-MM-yyyy");
            //    int followers = 0;
            //    int following = 0;
            //    int Request = 0;
            //    int star1 = 0;
            //    SqlCommand cmd2 = new SqlCommand("select count(*) from user_connection_table where account_name=@user_name and connection_status=0 ", con);
            //    cmd2.Parameters.AddWithValue("@user_name", Session["username"].ToString());
            //    SqlCommand cmd3 = new SqlCommand("select count(*) from user_connection_table where follower_name=@user_name and connection_status=0", con);
            //    cmd3.Parameters.AddWithValue("@user_name", Session["username"].ToString());
            //    SqlCommand cmd5 = new SqlCommand("select count(*) from user_connection_table where account_name=@user_name and connection_status=1", con);
            //    cmd5.Parameters.AddWithValue("@user_name", Session["username"].ToString());

            //    SqlCommand cmd6 = new SqlCommand("select count(*) from post_table where user_name=@user_name ", con);
            //    cmd6.Parameters.AddWithValue("@user_name", Session["username"].ToString());
               
            //    star1 = Int32.Parse(cmd6.ExecuteScalar().ToString());
            //    followers = Int32.Parse(cmd2.ExecuteScalar().ToString());
            //    following = Int32.Parse(cmd3.ExecuteScalar().ToString());
            //    Request = Int32.Parse(cmd5.ExecuteScalar().ToString());
            //    if (followers == null && following == null)
            //    {
            //        followers = 0;
            //        following = 0;
            //        Request = 0;
            //    }
            //    Label1.Text = followers.ToString();
            //    Label2.Text = following.ToString();
            //    star3.Text = star1.ToString();
            //    Label3.Text = Request.ToString();

            //    con.Close();    
            //DataList2.DataSource = GetcubicData();
            //DataList2.DataBind();
             

            }

        protected DataTable GetcubicData()
        {

            SqlCommand cmd = new SqlCommand("select * from post_table where user_name= @username ", con);
            cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
            SqlCommand cmd3 = new SqlCommand("select count(*) from post_table where user_name= @username  ", con);
            cmd3.Parameters.AddWithValue("@username", Session["username"].ToString());

            con.Open();
            DataTable cdt3 = new DataTable();
            SqlDataAdapter cda = new SqlDataAdapter(cmd);
            cda.Fill(cdt3);
            cmd.ExecuteNonQuery();
            int count = Int32.Parse(cmd3.ExecuteScalar().ToString());
            con.Close();

            DataTable cdt2 = new DataTable();
            DataRow cdr2 = null;
            //Create DataTable columns
            cdt2.Columns.Add(new DataColumn("id", typeof(string)));
            cdt2.Columns.Add(new DataColumn("officename", typeof(string)));
            cdt2.Columns.Add(new DataColumn("profilepic", typeof(string)));


            for (int i = 0; i < count; i++)
            {
                cdr2 = cdt2.NewRow();
                cdr2["id"] = cdt3.Rows[i]["post_date"].ToString();
                SqlCommand cmd5 = new SqlCommand("select caption from post_table where data_id=@username", con);
                cmd5.Parameters.AddWithValue("@username", cdt3.Rows[i]["data_id"].ToString());
                con.Open();
                cdr2["officename"] = cmd5.ExecuteScalar().ToString();

                SqlCommand cmd6 = new SqlCommand("select data from post_table where data_id=@username ", con);
                cmd6.Parameters.AddWithValue("@username", cdt3.Rows[i]["data_id"].ToString());

                byte[] bytes = (byte[])cmd6.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                cdr2["profilepic"] = "data:Image;base64," + strBase64;
                con.Close();

                cdt2.Rows.Add(cdr2);
               
            }
            return cdt2;
        }
            
        protected void update_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");
        }
        protected void delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update tbluserdata set active_status=0 where user_name=@user_name", con);
            
            cmd.Parameters.AddWithValue("@user_name", Session["username"].ToString());
            
            con.Open();

           
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted successfully')", true);
            Session.Remove("username");
            Response.Redirect("userlogin.aspx");
                   
            
        }

        protected void pc(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("update tbluserdata set privacy_type=1 where user_name=@user_name", con);
                cmd1.Parameters.AddWithValue("@user_name", Session["username"].ToString());
                SqlCommand cmd2 = new SqlCommand("update tbluserdata set privacy_type=0 where user_name=@user_name", con);
                cmd2.Parameters.AddWithValue("@user_name", Session["username"].ToString());
                if (pt == 0)
                {
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    TextBox5.Text = "Private";
                    
                }
                else
                {
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    TextBox5.Text = "Public";


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("upload_img.aspx");
        }
        }
    }
