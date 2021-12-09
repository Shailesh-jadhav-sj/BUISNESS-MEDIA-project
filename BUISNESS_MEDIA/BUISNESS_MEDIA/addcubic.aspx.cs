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
    public partial class addcubic : System.Web.UI.Page
    {
        String username;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

        protected void Page_Load(object sender, EventArgs e)
        {
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
                if (!IsPostBack)
                {
                    if (Session["office_name"] == null)
                    {
                        Response.Redirect("office_name");

                    }
                    else
                    {
                        Response.ClearHeaders();
                        Response.AppendHeader("Cache-Control", "no-store,max-age-0,must-revalidate");
                        Response.AddHeader("Pragma", "no-cache");

                    }


                }


            }
            refresh();
            refresh2();
        }

        protected void refresh()
        {
            if (Session["office_name"] == null)
            {
                Response.Redirect("office.aspx");
            }
            if (Session["username"] == null)
            {
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                username = Session["username"].ToString();

            }
            //==================================================================================

            //cmd of fatching data in data table
            SqlCommand cmd = new SqlCommand("select *  from tbluserdata where user_name!= @username and active_status=1", con);
            cmd.Parameters.AddWithValue("@username", username);

            //cmd of count data in data table 
            SqlCommand cmd3 = new SqlCommand("select count(*) from tbluserdata where user_name!=@username and active_status=1", con);
            cmd3.Parameters.AddWithValue("@username", username);

            //for fill the data in data table 
            con.Open();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);
            cmd.ExecuteNonQuery();
            int count = Int32.Parse(cmd3.ExecuteScalar().ToString());//for store count
            con.Close();

            //data table customized
            DataTable dt = new DataTable();
            DataRow dr = null;
            //Create DataTable columns

            dt.Columns.Add(new DataColumn("user_name", typeof(string)));
            dt.Columns.Add(new DataColumn("profile_pic", typeof(string)));
            dt.Columns.Add(new DataColumn("button_name", typeof(string)));

            for (int i = 0; i < count; i++)
            {
                dr = dt.NewRow();
                SqlCommand cmd5 = new SqlCommand("select profile_pic from tbluserdata where id=@username ", con);
                cmd5.Parameters.AddWithValue("@username", dt1.Rows[i]["id"].ToString());

                con.Open();
                byte[] bytes = (byte[])cmd5.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                dr["profile_pic"] = "data:Image;base64," + strBase64;
                con.Close();

                dr["user_name"] = dt1.Rows[i]["user_name"].ToString();

                SqlCommand cmd2 = new SqlCommand("select count(*) from office_cubic_table where user_name=@username and office_id=(select id from office_table where office_name=@officename) ", con);
                cmd2.Parameters.AddWithValue("@username", dt1.Rows[i]["user_name"].ToString());
                cmd2.Parameters.AddWithValue("@officename", Session["office_name"].ToString());

                con.Open();
                int countf = Int32.Parse(cmd2.ExecuteScalar().ToString());//for store count
                con.Close();

                if (countf > 0)
                {
                    dr["button_name"] = "Remove";


                }
                else
                {
                    dr["button_name"] = "Add";

                }


                dt.Rows.Add(dr);

            }
            GridView1.DataSource = dt;

            GridView1.DataBind();
            refresh2();

        }
        protected void refresh2()
        {
            if (Session["office_name"] == null)
            {
                Response.Redirect("office.aspx");
            }
            if (Session["username"] == null)
            {
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                username = Session["username"].ToString();

            }
            //==================================================================================

            //cmd of fatching data in data table
            SqlCommand cmd = new SqlCommand("select *  from tbluserdata where  user_name IN (select user_name from office_cubic_table where office_id=(select id from office_table where office_name=@officename) and active_status=1)", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@officename", Session["office_name"].ToString());
            //cmd of count data in data table 
            SqlCommand cmd3 = new SqlCommand("select count(*) from tbluserdata where user_name IN (select user_name from office_cubic_table where office_id=(select id from office_table where office_name=@officename)and active_status=1) ", con);
            cmd3.Parameters.AddWithValue("@username", username);
            cmd3.Parameters.AddWithValue("@officename", Session["office_name"].ToString());

            //for fill the data in data table 
            con.Open();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);
            cmd.ExecuteNonQuery();
            int count = Int32.Parse(cmd3.ExecuteScalar().ToString());//for store count
            con.Close();

            //data table customized
            DataTable dt = new DataTable();
            DataRow dr = null;
            //Create DataTable columns

            dt.Columns.Add(new DataColumn("user_name", typeof(string)));
            dt.Columns.Add(new DataColumn("profile_pic", typeof(string)));
            dt.Columns.Add(new DataColumn("button_name", typeof(string)));

            for (int i = 0; i < count; i++)
            {
                dr = dt.NewRow();
                SqlCommand cmd5 = new SqlCommand("select profile_pic from tbluserdata where id=@username ", con);
                cmd5.Parameters.AddWithValue("@username", dt1.Rows[i]["id"].ToString());

                con.Open();
                byte[] bytes = (byte[])cmd5.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                dr["profile_pic"] = "data:Image;base64," + strBase64;
                con.Close();

                dr["user_name"] = dt1.Rows[i]["user_name"].ToString();

                SqlCommand cmd2 = new SqlCommand("select count(*) from office_cubic_table where user_name=@username and office_id=(select id from office_table where office_name=@officename) ", con);
                cmd2.Parameters.AddWithValue("@username", dt1.Rows[i]["user_name"].ToString());
                cmd2.Parameters.AddWithValue("@officename", Session["office_name"].ToString());

                con.Open();
                int countf = Int32.Parse(cmd2.ExecuteScalar().ToString());//for store count
                con.Close();

                if (countf > 0)
                {
                    dr["button_name"] = "Remove";


                }
                else
                {
                    dr["button_name"] = "Add";

                }


                dt.Rows.Add(dr);

            }
            GridView2.DataSource = dt;

            GridView2.DataBind();

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "request")
            {

                int num = Convert.ToInt32(e.CommandArgument.ToString());
                // GridView1.Rows[num].Cells[2].Text="unfoll";
                Button button1 = (Button)GridView1.Rows[num].Cells[2].Controls[0];
                if (button1.Text == "Add")
                {
                    SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where user_name=@account_name and active_status=1", con);
                    cmd.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);
                    SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name and active_status=1", con);
                    string name = GridView1.Rows[num].Cells[1].Text;
                    cmd1.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);

                    con.Open();

                    if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                    {
                        int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                        string account_name = cmd1.ExecuteScalar().ToString();



                        SqlCommand cmd2 = new SqlCommand("insert into office_cubic_table values ((select id from office_table where office_name=@username),@account_name,@connection_status)", con);
                        cmd2.Parameters.AddWithValue("@username", Session["office_name"].ToString());
                        cmd2.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);
                        cmd2.Parameters.AddWithValue("@connection_status", count);
                        cmd2.ExecuteNonQuery();

                        con.Close();
                        refresh();
                      
                    }
                    else
                    {
                        Response.Write("error");
                        con.Close();
                    }

                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where user_name=@account_name and active_status=1 ", con);
                    cmd.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);
                    SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name and active_status=1 ", con);
                    cmd1.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);

                    con.Open();

                    if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                    {
                        int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                        string account_name = cmd1.ExecuteScalar().ToString();



                        SqlCommand cmd2 = new SqlCommand("delete from office_cubic_table where office_id=(select id from office_table where office_name=@username) and user_name=@account_name", con);
                        cmd2.Parameters.AddWithValue("@username", Session["office_name"].ToString());
                        cmd2.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);
                        cmd2.ExecuteNonQuery();

                        con.Close();
                        refresh();
                        refresh2();
                       
                    }
                    else
                    {
                        Response.Write("error");
                        con.Close();
                    }
                }
            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "request")
            {

                int num = Convert.ToInt32(e.CommandArgument.ToString());
                // GridView1.Rows[num].Cells[2].Text="unfoll";
                Button button1 = (Button)GridView2.Rows[num].Cells[2].Controls[0];
                if (button1.Text == "Add")
                {
                    SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where user_name=@account_name and active_status=1 ", con);
                    cmd.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);
                    SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name and active_status=1 ", con);
                    string name = GridView1.Rows[num].Cells[1].Text;
                    cmd1.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);

                    con.Open();

                    if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                    {
                        int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                        string account_name = cmd1.ExecuteScalar().ToString();



                        SqlCommand cmd2 = new SqlCommand("insert into office_cubic_table values ((select id from office_table where office_name=@username),@account_name,@connection_status)", con);
                        cmd2.Parameters.AddWithValue("@username", Session["office_name"].ToString());
                        cmd2.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);
                        cmd2.Parameters.AddWithValue("@connection_status", count);
                        cmd2.ExecuteNonQuery();

                        con.Close();
                        refresh();
                        refresh2();

                    }
                    else
                    {
                        Response.Write("error");
                        con.Close();
                    }

                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where user_name=@account_name and active_status=1 ", con);
                    cmd.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);
                    SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name  and active_status=1", con);
                    cmd1.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);

                    con.Open();

                    if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                    {
                        int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                        string account_name = cmd1.ExecuteScalar().ToString();



                        SqlCommand cmd2 = new SqlCommand("delete from office_cubic_table where office_id=(select id from office_table where office_name=@username) and user_name=@account_name", con);
                        cmd2.Parameters.AddWithValue("@username", Session["office_name"].ToString());
                        cmd2.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);
                        cmd2.ExecuteNonQuery();

                        con.Close();
                        refresh();
                        refresh2();

                    }
                    else
                    {
                        Response.Write("error");
                        con.Close();
                    }
                }
            }
        }



    }
}