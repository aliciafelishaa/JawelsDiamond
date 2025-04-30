using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string role = Session["role"] as string;

                phGuest.Visible = false;
                phCustomer.Visible = false;
                phAdmin.Visible = false;

                switch (role)
                {
                    case "guest":
                        phGuest.Visible = true;
                        break;
                    case "customer":
                        phCustomer.Visible = true;
                        break;
                    case "admin":
                        phAdmin.Visible = true;
                        break;
                    default:
                        phGuest.Visible = true;
                        break;
                }
            }
        }

        protected void SignIn_Button(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Guest/LoginPages.aspx");
        }

        protected void SignUp_Button(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Guest/RegisterPages.aspx");
        }

        protected void SignOut_Button(object sender, EventArgs e)
        {
            String[] cookies = Request.Cookies.AllKeys;
            foreach (string s in cookies)
            {
                Request.Cookies[s].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Clear();
            Response.Redirect("ViewJewels.aspx");
        }
    }
}