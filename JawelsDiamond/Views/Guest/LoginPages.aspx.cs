using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
	public partial class LoginPages : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/Views/ViewJewels.aspx");
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            String email = TB_Email.Text;
            String password = TB_Password.Text;
            Boolean isRemember = CBox_RememberMe.Checked;
            if (email == null || password == null)
            {
                Lbl_Status.Text = "All fields must be filled.";
                return;
            }
            MsUser loginUser = UserRepository.LoginUser(email, password);
            if (loginUser == null)
            {
                Lbl_Status.Text = "Incorrect email or password";
                return;
            }
            else
            {
                if (isRemember == true)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = loginUser.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddMinutes(1);
                    Response.Cookies.Add(cookie);
                }
                Session["user"] = loginUser;
                Response.Redirect("~/Views/ViewJewels.aspx");
            }
        }

        protected void Link_Btn_ToRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPages.aspx");
        }
    }
}