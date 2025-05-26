using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JawelsDiamond.Model;

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

                //Response.Write("DEBUG - Session role: " + (Session["role"] ?? "null"));

                if (Session["user"] != null)
                {
                    MsUser user = (MsUser)Session["user"];
                    Btn_goToCart.NavigateUrl = $"~/Views/Customer/CartPage.aspx?userId={user.UserID}";
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
            foreach (string cookieKey in Request.Cookies.AllKeys)
            {
                HttpCookie cookie = new HttpCookie(cookieKey);
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/Views/Guest/LoginPages.aspx");
        }
    }
}