using JawelsDiamond.Controller;
using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
	public partial class LoginPages : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    Response.Redirect("~/Views/ViewJewels.aspx");
                    return;
                }

                // Attempt auto-login via cookie
                HttpCookie cookie = Request.Cookies["user_cookie"];
                if (cookie != null)
                {
                    int userId;
                    if (int.TryParse(cookie.Value, out userId))
                    {
                        MsUser user = UserRepository.findJewel(userId);
                        if (user != null)
                        {
                            Session["user"] = user;
                            Session["role"] = user.UserRole.ToLower() ?? "guest";
                            Response.Redirect("~/Views/ViewJewels.aspx");
                            return;
                        }
                    }
                }
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            String email = TB_Email.Text;
            String password = TB_Password.Text;
            Boolean isRemember = CBox_RememberMe.Checked;

            string errorMsg = Auth.checkUser(email,password,isRemember, Response, Session);

            if (!string.IsNullOrEmpty(errorMsg))
            {
                Lbl_Status.Text = errorMsg;
                Lbl_Status.ForeColor = Color.Red;
            }

        }

        protected void Link_Btn_ToRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPages.aspx");
        }
    }
}