using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace BUISNESS_MEDIA
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select count(*) from tbluserdata where user_name=@user_name and active_status=1", con);
            cmd1.Parameters.AddWithValue("@user_name", username1.Text);
            SqlCommand cmd2 = new SqlCommand("select password from tbluserdata where user_name=@user_name", con);
            cmd2.Parameters.AddWithValue("@user_name", username1.Text);
            int check = Convert.ToInt32(cmd1.ExecuteScalar());

            con.Close();
            if (check > 0)
            {
                con.Open();
                string pass = cmd2.ExecuteScalar().ToString();
                con.Close();
                if (pass.Equals(password2.Text))
                {

                    Session["username"] = username1.Text;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('login successfully')", true);
                    Response.Redirect("userprofile.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('incorrect password')", true);

                }
            }
            else
            {
                

             
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('incorrect username')", true);




            }
        }
    }
}