using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Controller
{
	public class CheckPassword
	{
        public static string ValidatePassword(string oldPassword, string newPassword, string confirmPassword, MsUser user)
        {
            String currentUserPassword = user.UserPassword;
            if (string.IsNullOrWhiteSpace(oldPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "All fields are required.";
            }
            if (oldPassword != currentUserPassword)
            {
                return "Old password is incorrect.";
            }
            if (newPassword.Length <= 8 || newPassword.Length >= 25)
            {
                return "New password must be between 8 to 25 characters.";
            }
            if (newPassword != confirmPassword)
            {
                return "Confirm password does not match new password.";
            }
            return "";
        }

    }
}