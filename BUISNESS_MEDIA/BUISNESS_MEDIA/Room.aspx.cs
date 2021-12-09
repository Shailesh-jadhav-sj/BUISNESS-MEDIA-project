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
    public partial class Room : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        String username;
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
               username = Session["username"].ToString();

            
            GridView1.DataBind();

        }

        protected void add_room_Click(object sender, EventArgs e)
        {
            if (Room_name.Text != null)
            {

                SqlCommand cmd2 = new SqlCommand("insert into room_table values (@roomname,@username,@expert_tag,@date,@privacy)", con);
                cmd2.Parameters.AddWithValue("@roomname", Room_name.Text);
                cmd2.Parameters.AddWithValue("@username", username);
                cmd2.Parameters.AddWithValue("@expert_tag", "not");
                cmd2.Parameters.AddWithValue("@date", DateTime.Now);
                cmd2.Parameters.AddWithValue("@privacy", 0);
                con.Open();
                cmd2.ExecuteNonQuery();

                con.Close();
                GridView1.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Added successfully')", true);
                    
            }
            else
            {
                Response.Write("enter rrom name");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "remove")
            {

                int num = Convert.ToInt32(e.CommandArgument.ToString());

                SqlCommand cmd2 = new SqlCommand("delete from room_table where room_id=@id", con);
                cmd2.Parameters.AddWithValue("@id", GridView1.Rows[num].Cells[0].Text);

                con.Open();
                cmd2.ExecuteNonQuery();

                con.Close();
                GridView1.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('deleted successfully')", true);

            }
            else
            {
                int num = Convert.ToInt32(e.CommandArgument.ToString());
                Session["room_id"] = GridView1.Rows[num].Cells[0].Text;
                Response.Redirect("viewroom.aspx");
            }
        }

    }
}