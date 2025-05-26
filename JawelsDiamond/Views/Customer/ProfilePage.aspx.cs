using System;
using System.Web.UI;
using JawelsDiamond.Model;
using JawelsDiamond.Repository;

namespace JawelsDiamond.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/Guest/LoginPages.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadUserInfo();
            }
        }

        private void LoadUserInfo()
        {
            var currentUser = (MsUser)Session["user"];

            if (currentUser != null)
            {
                lblUserName.Text = currentUser.UserName;
                lblUserEmail.Text = currentUser.UserEmail;
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            var currentUser = (MsUser)Session["user"];

            if (currentUser.UserPassword != oldPassword)
            {
                lblErrorMessage.Text = "Old password is incorrect.";
                return;
            }

            if (newPassword != confirmPassword)
            {
                lblErrorMessage.Text = "Confirm password does not match new password.";
                return;
            }

            currentUser.UserPassword = newPassword;
            UserRepository.UpdateUserPassword(currentUser);

            lblErrorMessage.ForeColor = System.Drawing.Color.Green;
            lblErrorMessage.Text = "Password changed successfully!";
        }
    }
}
