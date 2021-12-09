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
    public partial class viewcubic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
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


            }
            string name1 = Session["office_name"].ToString();
            TextBox1.Text = Session["office_name"].ToString();
        }
    }
}