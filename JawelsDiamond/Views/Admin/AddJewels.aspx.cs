using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
	public partial class AddJewels : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Session["role"] = "admin";
            string role = Session["role"] as string;

            if (Session["user"] != null || Request.Cookies["user_cookie"] != null || role!="admin")
            {
                Response.Redirect("~/Views/ViewJewels.aspx");
            }
            
        }

	}
}