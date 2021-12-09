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
    public partial class office : System.Web.UI.Page
    {
        String username;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

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
                username=Session["username"].ToString();
               
              

              refresh();
        }

        protected void refresh()
        {
            SqlCommand cmd = new SqlCommand("select * from office_table where user_name=@username ", con);
            cmd.Parameters.AddWithValue("@username", username);

            if (!IsPostBack)
            {
                con.Open();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                DropDownList1.DataSource = dt1;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "office_name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
                con.Close();
            }

            DataList1.DataSource = GetSampleData();
            DataList1.DataBind();
            DataList2.DataSource = GetcubicData();
            DataList2.DataBind();
  
            //===================================================================================
            



        }

        protected DataTable GetSampleData()
        {

            //NOTE: THIS IS JUST FOR DEMO
            //If you are working with database
            //You can query your actual data and fill it to the DataTable

            SqlCommand cmd = new SqlCommand("select * from office_table where user_name=@username ", con);
            cmd.Parameters.AddWithValue("@username", username);
            SqlCommand cmd3 = new SqlCommand("select count(*) from office_table where user_name=@username ", con);
            cmd3.Parameters.AddWithValue("@username", username);

            con.Open();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);
            cmd.ExecuteNonQuery();
            int count = Int32.Parse(cmd3.ExecuteScalar().ToString());
            con.Close();

            DataTable dt = new DataTable();
            DataRow dr = null;
            //Create DataTable columns
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("ProductImage", typeof(string)));
            dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));

            for (int i = 0; i < count; i++)
            {
                SqlCommand cmd4 = new SqlCommand("select count(*) from office_cubic_table where office_id=@username ", con);
                cmd4.Parameters.AddWithValue("@username", dt1.Rows[i]["id"].ToString());
                con.Open();
                int count2 = Int32.Parse(cmd4.ExecuteScalar().ToString());
                con.Close();
                dr = dt.NewRow();
                dr["id"] = "Office id="+ dt1.Rows[i]["id"].ToString();
                dr["ProductName"] = dt1.Rows[i]["office_name"].ToString();
                SqlCommand cmd5 = new SqlCommand("select profile_pic from office_table where id=@username ", con);
                cmd5.Parameters.AddWithValue("@username", dt1.Rows[i]["id"].ToString());
                con.Open();
                byte[] bytes = (byte[])cmd5.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                dr["ProductImage"] = "data:Image;base64," + strBase64;
                con.Close();
                dr["Price"] =" total cubicles join=" +count2;
                dt.Rows.Add(dr);

            }
            return dt;
        }
            protected DataTable GetcubicData()
            {

            SqlCommand cmd = new SqlCommand("select * from office_table where id IN ( select office_id from office_cubic_table where user_name = @username) ", con);
            cmd.Parameters.AddWithValue("@username", username);
            SqlCommand cmd3 = new SqlCommand("select count(*) from office_table where id IN ( select office_id from office_cubic_table where user_name = @username) ", con);
            cmd3.Parameters.AddWithValue("@username", username);

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
                cdr2["id"] = cdt3.Rows[i]["id"].ToString();
                SqlCommand cmd5 = new SqlCommand("select office_name from office_table where id=@username ", con);
                cmd5.Parameters.AddWithValue("@username", cdt3.Rows[i]["id"].ToString());
                con.Open();
                cdr2["officename"] = cmd5.ExecuteScalar().ToString();
               
                SqlCommand cmd6 = new SqlCommand("select profile_pic from office_table where id=@username ", con);
                cmd6.Parameters.AddWithValue("@username", cdt3.Rows[i]["id"].ToString());
               
                byte[] bytes = (byte[])cmd6.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                cdr2["profilepic"] = "data:Image;base64," + strBase64;
                con.Close();

                cdt2.Rows.Add(cdr2);
 
            }
            

            //Create Row for each columns
            


            return cdt2;
        }
            protected void del_click(object sender, EventArgs e)
            {
                SqlCommand cmd = new SqlCommand("delete from office_table where id=@username ", con);
                cmd.Parameters.AddWithValue("@username", DropDownList1.SelectedItem.Value);
                SqlCommand cmd2 = new SqlCommand("delete from office_cubic_table where office_id=@username ", con);
                cmd2.Parameters.AddWithValue("@username", DropDownList1.SelectedItem.Value);
                SqlCommand cmd3 = new SqlCommand("delete from cubic_work_table where cubic_id IN (select cubic_id from office_cubic_table where office_id=@username) ", con);
                cmd3.Parameters.AddWithValue("@username", DropDownList1.SelectedItem.Value);

                con.Open();
                cmd3.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
                refresh();
             
            }


        protected void office_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("office_sigunup.aspx");
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
             //int num= Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "Select")
            {
                DataListItem item = (DataListItem)(((LinkButton)(e.CommandSource)).NamingContainer);
                string text = ((Label)item.FindControl("lblProduct")).Text;
                Session["office_name"] = text;
                Response.Redirect("cubic.aspx");   
            }
            Response.Write(e.CommandName);
        }
        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //int num= Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "View")
            {
                DataListItem item = (DataListItem)(((LinkButton)(e.CommandSource)).NamingContainer);
                string text = ((Label)item.FindControl("lblProduct")).Text;
                Session["office_name"] = text;
                Response.Redirect("viewcubic.aspx");
            }
            
        }
    }
}
