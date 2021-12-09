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
    public partial class viewroom : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        string username;
        string room_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["room_id"]==null)
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
                room_id = Session["room_id"].ToString();
            
            GridView1.DataBind();

        }

        protected void btnCommentPublish_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into knowledge_table values(@room_id,@knowledge_content,@knowledge_content_file,@star,@ask_date)", con);
            cmd.Parameters.AddWithValue("@room_id", room_id);
            cmd.Parameters.AddWithValue("@ask_date", room_id);
            cmd.Parameters.AddWithValue("@star", room_id);
            cmd.Parameters.AddWithValue("@knowledge_content_file", room_id);
            cmd.Parameters.AddWithValue("@knowledge_content", textComment.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
         //   GridView1.DataSource = ParentCommentIDAcess.GetAllDepartmentsandEmployee();
            GridView1.DataBind();
        }
        protected void btnReplyParent_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            Label lblchildCommentid = (Label)row.FindControl("lb1COmmenId");
            TextBox txtCommentParent = (TextBox)row.FindControl("textCommentReplyParent");
            SqlCommand cmd = new SqlCommand("spCommentReplyInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", Request.QueryString["User_name"].ToString());
            cmd.Parameters.AddWithValue("@CommentMessage", txtCommentParent.Text);
            cmd.Parameters.AddWithValue("@ParentCommentID", lblchildCommentid.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

           // GridView1.DataSource = ParentCommentIDAcess.GetAllDepartmentsandEmployee();
            GridView1.DataBind();

        }
    }
}