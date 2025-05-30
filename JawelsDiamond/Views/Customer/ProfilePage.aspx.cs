using System;
using System.Web.UI;
using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using JawelsDiamond.Controller;

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

            MsUser currentUser = (MsUser)Session["user"];

            String errorMsg = CheckPassword.ValidatePassword(oldPassword, newPassword, confirmPassword, currentUser);

            if (errorMsg != "")
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = errorMsg;
                return;
            }

            currentUser.UserPassword = newPassword;
            UserRepository.UpdateUserPassword(currentUser);

            lblErrorMessage.ForeColor = System.Drawing.Color.Green;
            lblErrorMessage.Text = "Password changed successfully!";
        }
    }
}
