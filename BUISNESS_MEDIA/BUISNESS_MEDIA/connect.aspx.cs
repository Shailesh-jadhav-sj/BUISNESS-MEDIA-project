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
    public partial class connect : System.Web.UI.Page
    {
        String username;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            refresh();

        }
        protected void refresh()
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
                SqlCommand cmd5 = new SqlCommand("select profile_pic from tbluserdata where id=@username and active_status=1", con);
                cmd5.Parameters.AddWithValue("@username", dt1.Rows[i]["id"].ToString());

                con.Open();
                byte[] bytes = (byte[])cmd5.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
               dr["profile_pic"] = "data:Image;base64," + strBase64;
               con.Close();

               dr["user_name"] = dt1.Rows[i]["user_name"].ToString();

               SqlCommand cmd2 = new SqlCommand("select count(*) from user_connection_table where follower_name=@username and account_name=@account_name", con);
               cmd2.Parameters.AddWithValue("@username", username);
               cmd2.Parameters.AddWithValue("@account_name", dt1.Rows[i]["user_name"].ToString());

               con.Open();
               int countf = Int32.Parse(cmd2.ExecuteScalar().ToString());//for store count
               con.Close();

               if (countf > 0)
               {
                   dr["button_name"] = "unfollow";
                   

               }
               else
               {
                   dr["button_name"] = "follow";

               }


               dt.Rows.Add(dr);

            }
            GridView1.DataSource = dt;
           
            GridView1.DataBind();

            //==================================================================================

            //cmd of fatching data in data table
            SqlCommand fcmd = new SqlCommand("select *  from tbluserdata where user_name!= @username and user_name IN (select follower_name from user_connection_table where account_name=@username and connection_status=0 ) and active_status=1", con);
            fcmd.Parameters.AddWithValue("@username", username);

            //cmd of count data in data table 
            SqlCommand fcmd3 = new SqlCommand("select count(*) from tbluserdata where user_name!=@username and user_name IN (select follower_name from user_connection_table where account_name=@username and connection_status=0 ) and active_status=1", con);
            fcmd3.Parameters.AddWithValue("@username", username);

            //for fill the data in data table 
            con.Open();
            DataTable fdt1 = new DataTable();
            SqlDataAdapter fda = new SqlDataAdapter(fcmd);
            fda.Fill(fdt1);
            fcmd.ExecuteNonQuery();
            int fcount = Int32.Parse(fcmd3.ExecuteScalar().ToString());//for store count
            con.Close();

            //data table customized
            DataTable fdt = new DataTable();
            DataRow fdr = null;
            //Create DataTable columns

            fdt.Columns.Add(new DataColumn("user_name", typeof(string)));
            fdt.Columns.Add(new DataColumn("profile_pic", typeof(string)));
            fdt.Columns.Add(new DataColumn("button_name", typeof(string)));

            for (int i = 0; i < fcount; i++)
            {
                fdr = fdt.NewRow();
                SqlCommand fcmd5 = new SqlCommand("select profile_pic from tbluserdata where id=@username and active_status=1 ", con);
                fcmd5.Parameters.AddWithValue("@username", fdt1.Rows[i]["id"].ToString());

                con.Open();
                byte[] bytes = (byte[])fcmd5.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                fdr["profile_pic"] = "data:Image;base64," + strBase64;
                con.Close();

                fdr["user_name"] = fdt1.Rows[i]["user_name"].ToString();

                SqlCommand fcmd2 = new SqlCommand("select count(*) from user_connection_table where follower_name=@username and account_name=@account_name ", con);
                fcmd2.Parameters.AddWithValue("@username", username);
                fcmd2.Parameters.AddWithValue("@account_name", dt1.Rows[i]["user_name"].ToString());

                con.Open();
                int countf = Int32.Parse(fcmd2.ExecuteScalar().ToString());//for store count
                con.Close();

                if (countf > 0)
                {
                   fdr["button_name"] = "unfollow";


                }
                else
                {
                    fdr["button_name"] = "follow";

                }


                fdt.Rows.Add(fdr);

            }
            GridView2.DataSource = fdt;

            GridView2.DataBind();
           

            //=================================================================================================

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
            SqlCommand ucmd = new SqlCommand("select *  from tbluserdata where user_name!= @username  and user_name IN (select account_name from user_connection_table where follower_name=@username and connection_status=0 ) and active_status=1", con);
            ucmd.Parameters.AddWithValue("@username", username);
            

            //cmd of count data in data table 
            SqlCommand ucmd3 = new SqlCommand("select count(*) from tbluserdata where user_name!=@username  and user_name IN (select account_name from user_connection_table where follower_name=@username  and connection_status=0) and active_status=1", con);
            ucmd3.Parameters.AddWithValue("@username", username);

            

            //for fill the data in data table 
            con.Open();
            DataTable udt1 = new DataTable();
            SqlDataAdapter uda = new SqlDataAdapter(ucmd);
            uda.Fill(udt1);
            ucmd.ExecuteNonQuery();
            int ucount = Int32.Parse(ucmd3.ExecuteScalar().ToString());//for store count
            con.Close();

            //data table customized
            DataTable udt = new DataTable();
            DataRow udr = null;
            //Create DataTable columns

            udt.Columns.Add(new DataColumn("user_name", typeof(string)));
            udt.Columns.Add(new DataColumn("profile_pic", typeof(string)));
            udt.Columns.Add(new DataColumn("button_name", typeof(string)));

            for (int i = 0; i < ucount; i++)
            {
                udr = udt.NewRow();
                SqlCommand ucmd5 = new SqlCommand("select profile_pic from tbluserdata where id=@username and active_status=1 ", con);
                ucmd5.Parameters.AddWithValue("@username", udt1.Rows[i]["id"].ToString());

                con.Open();
                byte[] bytes = (byte[])ucmd5.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                udr["profile_pic"] = "data:Image;base64," + strBase64;
                con.Close();

                udr["user_name"] = udt1.Rows[i]["user_name"].ToString();

                SqlCommand ucmd2 = new SqlCommand("select count(*) from user_connection_table where follower_name=@username and account_name=@account_name", con);
                ucmd2.Parameters.AddWithValue("@username", username);
                ucmd2.Parameters.AddWithValue("@account_name", udt1.Rows[i]["user_name"].ToString());

                con.Open();
                int countu = Int32.Parse(ucmd2.ExecuteScalar().ToString());//for store count
                con.Close();

                if (countu > 0)
                {
                    udr["button_name"] = "unfollow";


                }
                else
                {
                    udr["button_name"] = "follow";

                }


                udt.Rows.Add(udr);

            }
            GridView3.DataSource = udt;

            GridView3.DataBind();

            //=========================================================================================================
            //cmd of fatching data in data table
            SqlCommand rcmd = new SqlCommand("select *  from tbluserdata where user_name!= @username and user_name IN (select follower_name from user_connection_table where account_name=@username and connection_status=1) and active_status=1", con);
            rcmd.Parameters.AddWithValue("@username", username);

            //cmd of count data in data table 
            SqlCommand rcmd3 = new SqlCommand("select count(*) from tbluserdata where user_name!=@username and user_name IN (select follower_name from user_connection_table where account_name=@username and connection_status=1 ) and active_status=1", con);
            rcmd3.Parameters.AddWithValue("@username", username);

            //for fill the data in data table 
            con.Open();
            DataTable rdt1 = new DataTable();
            SqlDataAdapter rda = new SqlDataAdapter(rcmd);
            rda.Fill(rdt1);
            rcmd.ExecuteNonQuery();
            int rcount = Int32.Parse(rcmd3.ExecuteScalar().ToString());//for store count
            con.Close();

            //data table customized
            DataTable rdt = new DataTable();
            DataRow rdr = null;
            //Create DataTable columns

            rdt.Columns.Add(new DataColumn("user_name", typeof(string)));
            rdt.Columns.Add(new DataColumn("profile_pic", typeof(string)));
            rdt.Columns.Add(new DataColumn("button_name", typeof(string)));

            for (int i = 0; i < rcount; i++)
            {
                rdr = rdt.NewRow();
                SqlCommand rcmd5 = new SqlCommand("select profile_pic from tbluserdata where id=@username and active_status=1 ", con);
                rcmd5.Parameters.AddWithValue("@username", rdt1.Rows[i]["id"].ToString());

                con.Open();
                byte[] bytes = (byte[])rcmd5.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                rdr["profile_pic"] = "data:Image;base64," + strBase64;
                con.Close();

                rdr["user_name"] = rdt1.Rows[i]["user_name"].ToString();

                SqlCommand rcmd2 = new SqlCommand("select count(*) from user_connection_table where follower_name=@username and account_name=@account_name", con);
                rcmd2.Parameters.AddWithValue("@username", username);
                rcmd2.Parameters.AddWithValue("@account_name", rdt1.Rows[i]["user_name"].ToString());

                con.Open();
                int countf = Int32.Parse(rcmd2.ExecuteScalar().ToString());//for store count
                con.Close();

                if (countf > 0)
                {
                    rdr["button_name"] = "unfollow";


                }
                else
                {
                    rdr["button_name"] = "follow";

                }


                rdt.Rows.Add(rdr);

            }
            GridView4.DataSource = rdt;

            GridView4.DataBind();
           

            con.Close();



        }
          protected void change(object sender, EventArgs e)
          {
              //SqlCommand cmd = new SqlCommand("select id,user_name from office_table where user_name!=@username ", con);
              //cmd.Parameters.AddWithValue("@username",username );

              //con.Open();
              //DataTable dt1 = new DataTable();
              //SqlDataAdapter da = new SqlDataAdapter(cmd);
              //da.Fill(dt1);
              //cmd.ExecuteNonQuery();
              //int count = Int32.Parse(cmd.ExecuteScalar().ToString());
            
              //data.DataSource = dt1;
              //data.DataBind();
              //con.Close();

            
          }

          protected void input_Click(object sender, EventArgs e)
          {

              
          }

          protected void unfollow_Click(object sender, EventArgs e)
          {
              SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where id=@account_name and active_status=1", con);
              cmd.Parameters.AddWithValue("@account_name", TextBox1.Text);
              SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where id=@account_nameand active_status=1 ", con);
              cmd1.Parameters.AddWithValue("@account_name", TextBox1.Text);

              con.Open();

              if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
              {
                  int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                  string account_name = cmd1.ExecuteScalar().ToString();



                  SqlCommand cmd2 = new SqlCommand("delete from user_connection_table where follower_name=@username and account_name=@account_name", con);
                  cmd2.Parameters.AddWithValue("@username", username);
                  cmd2.Parameters.AddWithValue("@account_name", account_name);
                  cmd2.ExecuteNonQuery();
                  Response.Write("done");
                  con.Close();
                  refresh();
              }
              else
              {
                  Response.Write("error");
                  con.Close();
              }
            
          }
          protected void accept_Click(object sender, EventArgs e)
          {
              SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where id=@account_name and active_status=1 ", con);
              cmd.Parameters.AddWithValue("@account_name", TextBox1.Text);
              SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where id=@account_name  and active_status=1", con);
              cmd1.Parameters.AddWithValue("@account_name", TextBox1.Text);

              con.Open();

              if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
              {
                  int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                  string account_name = cmd1.ExecuteScalar().ToString();



                  SqlCommand cmd2 = new SqlCommand("update user_connection_table set connection_status=0 where account_name=@username and follower_name=@account_name", con);
                  cmd2.Parameters.AddWithValue("@username", username);
                  cmd2.Parameters.AddWithValue("@account_name", account_name);
                  cmd2.ExecuteNonQuery();
                  Response.Write("done");
                  con.Close();
                  refresh();
              }
              else
              {
                  Response.Write("error");
                  con.Close();
              }
         
        
          }
          protected void decline_Click(object sender, EventArgs e)
          {

              SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where id=@account_name and active_status=1", con);
              cmd1.Parameters.AddWithValue("@account_name", TextBox1.Text);

              con.Open();

              if ( cmd1.ExecuteScalar() != null)
              {
                  string account_name = cmd1.ExecuteScalar().ToString();



                  SqlCommand cmd2 = new SqlCommand("delete from user_connection_table where account_name=@username and follower_name=@account_name", con);
                  cmd2.Parameters.AddWithValue("@username", username);
                  cmd2.Parameters.AddWithValue("@account_name", account_name);
                  cmd2.ExecuteNonQuery();
                  Response.Write("done");
                  con.Close();
                  refresh();
              }
              else
              {
                  Response.Write("error");
                  con.Close();
              }
            

          }

          protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
          {
              if (e.CommandName == "request")
              {
                  
                  int num= Convert.ToInt32(e.CommandArgument.ToString());
                 // GridView1.Rows[num].Cells[2].Text="unfoll";
                  Button button1 = (Button)GridView1.Rows[num].Cells[2].Controls[0];
                  if (button1.Text == "follow")
                  {
                      SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where user_name=@account_name and active_status=1 ", con);
                      cmd.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);
                      SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name and active_status=1", con);
                      string name = GridView1.Rows[num].Cells[1].Text;
                      cmd1.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);

                      con.Open();

                      if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                      {
                          int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                          string account_name = cmd1.ExecuteScalar().ToString();



                          SqlCommand cmd2 = new SqlCommand("insert into user_connection_table values (@username,@account_name,@connection_status)", con);
                          cmd2.Parameters.AddWithValue("@username", username);
                          cmd2.Parameters.AddWithValue("@account_name", account_name);
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
                      SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where user_name=@account_name ", con);
                      cmd.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);
                      SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name and active_status=1 ", con);
                      cmd1.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);

                      con.Open();

                      if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                      {
                          int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                          string account_name = cmd1.ExecuteScalar().ToString();



                          SqlCommand cmd2 = new SqlCommand("delete from user_connection_table where follower_name=@username and account_name=@account_name", con);
                          cmd2.Parameters.AddWithValue("@username", username);
                          cmd2.Parameters.AddWithValue("@account_name", GridView1.Rows[num].Cells[1].Text);
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
              }
          }

          protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
          {
              if (e.CommandName == "request")
              {

                  int num = Convert.ToInt32(e.CommandArgument.ToString());
                  // GridView1.Rows[num].Cells[2].Text="unfoll";
                  Button button1 = (Button)GridView2.Rows[num].Cells[2].Controls[0];
                  if (button1.Text == "follow")
                  {
                      SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where user_name=@account_name  and active_status=1", con);
                      cmd.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);
                      SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name and active_status=1 ", con);
                      string name = GridView1.Rows[num].Cells[1].Text;
                      cmd1.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);

                      con.Open();

                      if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                      {
                          int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                          string account_name = cmd1.ExecuteScalar().ToString();



                          SqlCommand cmd2 = new SqlCommand("insert into user_connection_table values (@username,@account_name,@connection_status)", con);
                          cmd2.Parameters.AddWithValue("@username", username);
                          cmd2.Parameters.AddWithValue("@account_name", account_name);
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
                      cmd.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);
                      SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name and active_status=1 ", con);
                      cmd1.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);

                      con.Open();

                      if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                      {
                          int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                          string account_name = cmd1.ExecuteScalar().ToString();



                          SqlCommand cmd2 = new SqlCommand("delete from user_connection_table where follower_name=@username and account_name=@account_name", con);
                          cmd2.Parameters.AddWithValue("@username", username);
                          cmd2.Parameters.AddWithValue("@account_name", GridView2.Rows[num].Cells[1].Text);
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
              }
          }

          protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
          {
              if (e.CommandName == "request")
              {

                  int num = Convert.ToInt32(e.CommandArgument.ToString());
                  // GridView1.Rows[num].Cells[2].Text="unfoll";
                  Button button1 = (Button)GridView3.Rows[num].Cells[2].Controls[0];
                  if (button1.Text == "follow")
                  {
                      SqlCommand cmd = new SqlCommand("select privacy_type from tbluserdata where user_name=@account_name and active_status=1", con);
                      cmd.Parameters.AddWithValue("@account_name", GridView3.Rows[num].Cells[1].Text);
                      SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name and active_status=1", con);
                      string name = GridView1.Rows[num].Cells[1].Text;
                      cmd1.Parameters.AddWithValue("@account_name", GridView3.Rows[num].Cells[1].Text);

                      con.Open();

                      if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                      {
                          int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                          string account_name = cmd1.ExecuteScalar().ToString();



                          SqlCommand cmd2 = new SqlCommand("insert into user_connection_table values (@username,@account_name,@connection_status)", con);
                          cmd2.Parameters.AddWithValue("@username", username);
                          cmd2.Parameters.AddWithValue("@account_name", account_name);
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
                      cmd.Parameters.AddWithValue("@account_name", GridView3.Rows[num].Cells[1].Text);
                      SqlCommand cmd1 = new SqlCommand("select user_name from tbluserdata where user_name=@account_name and active_status=1 ", con);
                      cmd1.Parameters.AddWithValue("@account_name", GridView3.Rows[num].Cells[1].Text);

                      con.Open();

                      if (cmd.ExecuteScalar() != null && cmd1.ExecuteScalar() != null)
                      {
                          int count = Int32.Parse(cmd.ExecuteScalar().ToString());
                          string account_name = cmd1.ExecuteScalar().ToString();



                          SqlCommand cmd2 = new SqlCommand("delete from user_connection_table where follower_name=@username and account_name=@account_name", con);
                          cmd2.Parameters.AddWithValue("@username", username);
                          cmd2.Parameters.AddWithValue("@account_name", GridView3.Rows[num].Cells[1].Text);
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
              }
          }

          protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
          {
               if (Session["username"] == null)
            {
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                username = Session["username"].ToString();

            }
              if (e.CommandName == "accept")
              {

                  int num = Convert.ToInt32(e.CommandArgument.ToString());
                  // GridView1.Rows[num].Cells[2].Text="unfoll";
                  
                      SqlCommand cmd = new SqlCommand("update user_connection_table set connection_status=0 where follower_name=@account_name and account_name=@username ", con);
                      cmd.Parameters.AddWithValue("@account_name", GridView4.Rows[num].Cells[1].Text);
                  cmd.Parameters.AddWithValue("@username",username );
                  con.Open();
                      cmd.ExecuteNonQuery();
                      con.Close();
                      refresh();
                  
              }
              else
              {
                  int num = Convert.ToInt32(e.CommandArgument.ToString());
                  // GridView1.Rows[num].Cells[2].Text="unfoll";

                  SqlCommand cmd = new SqlCommand("delete from user_connection_table  where follower_name=@account_name and account_name=@username ", con);
                  cmd.Parameters.AddWithValue("@account_name", GridView4.Rows[num].Cells[1].Text);
                  cmd.Parameters.AddWithValue("@username", username);
                  con.Open();
                  cmd.ExecuteNonQuery();
                  con.Close();
                  refresh();
              }
          }

          protected void contact_TextChanged(object sender, EventArgs e)
          {
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
              SqlCommand cmd = new SqlCommand("select *  from tbluserdata where user_name!= @username and user_name like @find and active_status=1", con);
              cmd.Parameters.AddWithValue("@username", username);
              string find=contact.Text +"%";
              cmd.Parameters.AddWithValue("@find",find );

              //cmd of count data in data table 
              SqlCommand cmd3 = new SqlCommand("select count(*) from tbluserdata where user_name!=@username and user_name like @find and active_status=1", con);
              cmd3.Parameters.AddWithValue("@username", username);
             
              cmd3.Parameters.AddWithValue("@find", find);

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
                  SqlCommand cmd5 = new SqlCommand("select profile_pic from tbluserdata where id=@username and active_status=1 ", con);
                  cmd5.Parameters.AddWithValue("@username", dt1.Rows[i]["id"].ToString());

                  con.Open();
                  byte[] bytes = (byte[])cmd5.ExecuteScalar();
                  string strBase64 = Convert.ToBase64String(bytes);
                  dr["profile_pic"] = "data:Image;base64," + strBase64;
                  con.Close();

                  dr["user_name"] = dt1.Rows[i]["user_name"].ToString();

                  SqlCommand cmd2 = new SqlCommand("select count(*) from user_connection_table where follower_name=@username and account_name=@account_name", con);
                  cmd2.Parameters.AddWithValue("@username", username);
                  cmd2.Parameters.AddWithValue("@account_name", dt1.Rows[i]["user_name"].ToString());

                  con.Open();
                  int countf = Int32.Parse(cmd2.ExecuteScalar().ToString());//for store count
                  con.Close();

                  if (countf > 0)
                  {
                      dr["button_name"] = "unfollow";


                  }
                  else
                  {
                      dr["button_name"] = "follow";

                  }


                  dt.Rows.Add(dr);

              }
              GridView1.DataSource = dt;

              GridView1.DataBind();

              con.Close();

          }

          protected void TextBox1_TextChanged(object sender, EventArgs e)
          {
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
              SqlCommand cmd = new SqlCommand("select *  from tbluserdata where user_name!= @username and user_name like @find and user_name IN (select follower_name from user_connection_table where account_name=@username ) and active_status=1", con);
              cmd.Parameters.AddWithValue("@username", username);
              string find = TextBox1.Text + "%";
              cmd.Parameters.AddWithValue("@find", find);

              //cmd of count data in data table 
              SqlCommand cmd3 = new SqlCommand("select count(*) from tbluserdata where user_name!=@username and user_name like @find and user_name IN (select follower_name from user_connection_table where account_name=@username ) and active_status=1", con);
              cmd3.Parameters.AddWithValue("@username", username);

              cmd3.Parameters.AddWithValue("@find", find);

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
                  SqlCommand cmd5 = new SqlCommand("select profile_pic from tbluserdata where id=@username and active_status=1", con);
                  cmd5.Parameters.AddWithValue("@username", dt1.Rows[i]["id"].ToString());

                  con.Open();
                  byte[] bytes = (byte[])cmd5.ExecuteScalar();
                  string strBase64 = Convert.ToBase64String(bytes);
                  dr["profile_pic"] = "data:Image;base64," + strBase64;
                  con.Close();

                  dr["user_name"] = dt1.Rows[i]["user_name"].ToString();

                  SqlCommand cmd2 = new SqlCommand("select count(*) from user_connection_table where follower_name=@username and account_name=@account_name", con);
                  cmd2.Parameters.AddWithValue("@username", username);
                  cmd2.Parameters.AddWithValue("@account_name", dt1.Rows[i]["user_name"].ToString());

                  con.Open();
                  int countf = Int32.Parse(cmd2.ExecuteScalar().ToString());//for store count
                  con.Close();

                  if (countf > 0)
                  {
                      dr["button_name"] = "unfollow";


                  }
                  else
                  {
                      dr["button_name"] = "follow";

                  }


                  dt.Rows.Add(dr);

              }
              GridView2.DataSource = dt;

              GridView2.DataBind();

              con.Close();

          }

          protected void TextBox2_TextChanged(object sender, EventArgs e)
          {
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
              SqlCommand cmd = new SqlCommand("select *  from tbluserdata where user_name!= @username and user_name like @find and user_name IN (select account_name from user_connection_table where follower_name=@username ) and active_status=1", con);
              cmd.Parameters.AddWithValue("@username", username);
              string find = TextBox2.Text + "%";
              cmd.Parameters.AddWithValue("@find", find);

              //cmd of count data in data table 
              SqlCommand cmd3 = new SqlCommand("select count(*) from tbluserdata where user_name!=@username and user_name like @find and user_name IN (select account_name from user_connection_table where follower_name=@username ) and active_status=1", con);
              cmd3.Parameters.AddWithValue("@username", username);

              cmd3.Parameters.AddWithValue("@find", find);

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

                  SqlCommand cmd2 = new SqlCommand("select count(*) from user_connection_table where follower_name=@username and account_name=@account_name", con);
                  cmd2.Parameters.AddWithValue("@username", username);
                  cmd2.Parameters.AddWithValue("@account_name", dt1.Rows[i]["user_name"].ToString());

                  con.Open();
                  int countf = Int32.Parse(cmd2.ExecuteScalar().ToString());//for store count
                  con.Close();

                  if (countf > 0)
                  {
                      dr["button_name"] = "unfollow";


                  }
                  else
                  {
                      dr["button_name"] = "follow";

                  }


                  dt.Rows.Add(dr);

              }
              GridView3.DataSource = dt;

              GridView3.DataBind();

              con.Close();

          }

          protected void TextBox3_TextChanged(object sender, EventArgs e)
          {
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
              SqlCommand cmd = new SqlCommand("select *  from tbluserdata where user_name!= @username and user_name like @find and user_name IN (select account_name from user_connection_table where follower_name=@username ) and active_status=1", con);
              cmd.Parameters.AddWithValue("@username", username);
              string find = TextBox3.Text + "%";
              cmd.Parameters.AddWithValue("@find", find);

              //cmd of count data in data table 
              SqlCommand cmd3 = new SqlCommand("select count(*) from tbluserdata where user_name!=@username and user_name like @find and user_name IN (select account_name from user_connection_table where follower_name=@username ) and active_status=1", con);
              cmd3.Parameters.AddWithValue("@username", username);

              cmd3.Parameters.AddWithValue("@find", find);

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
                  SqlCommand cmd5 = new SqlCommand("select profile_pic from tbluserdata where id=@username and active_status=1", con);
                  cmd5.Parameters.AddWithValue("@username", dt1.Rows[i]["id"].ToString());

                  con.Open();
                  byte[] bytes = (byte[])cmd5.ExecuteScalar();
                  string strBase64 = Convert.ToBase64String(bytes);
                  dr["profile_pic"] = "data:Image;base64," + strBase64;
                  con.Close();

                  dr["user_name"] = dt1.Rows[i]["user_name"].ToString();

                  SqlCommand cmd2 = new SqlCommand("select count(*) from user_connection_table where follower_name=@username and account_name=@account_name", con);
                  cmd2.Parameters.AddWithValue("@username", username);
                  cmd2.Parameters.AddWithValue("@account_name", dt1.Rows[i]["user_name"].ToString());

                  con.Open();
                  int countf = Int32.Parse(cmd2.ExecuteScalar().ToString());//for store count
                  con.Close();

                  if (countf > 0)
                  {
                      dr["button_name"] = "unfollow";


                  }
                  else
                  {
                      dr["button_name"] = "follow";

                  }


                  dt.Rows.Add(dr);

              }
              GridView3.DataSource = dt;

              GridView3.DataBind();

              con.Close();

          }
      }
    }
