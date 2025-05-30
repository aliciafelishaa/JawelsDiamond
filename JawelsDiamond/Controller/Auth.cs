using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using JawelsDiamond.Controller;
using JawelsDiamond.Handler;
using JawelsDiamond.Repository;
using System.Text.RegularExpressions;
using System.Drawing;

namespace JawelsDiamond.Controller
{
	public class Auth
	{
		public static string checkUser(string email, string password, bool isRemember, HttpResponse response, HttpSessionState session)
		{
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                return "All fields are required";
            }

            //Handler business logic (auth check)
            MsUser loginUser = AuthHandler.AttemptLogin(email, password);

            if (loginUser == null)
            {
                return "Incorrect email or password";
            }
            else
            {
                if (isRemember == true)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = loginUser.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    response.Cookies.Add(cookie);
                }

                session["user"] = loginUser;
                session["role"] = loginUser.UserRole.ToLower() ?? "guest";
                response.Redirect("~/Views/ViewJewels.aspx");
                return string.Empty;
            }
        }

        public static string registCheckUser(string email, string username, string password, string confirmpass, string selectedGender, DateTime selectedDOB)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmpass) || string.IsNullOrEmpty(selectedGender) || selectedDOB == DateTime.MinValue)
            {
                return "All fields must be filled.";
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return "Email format is not valid.";
            }

            if (UserRepository.IsEmailExists(email))
            {
                return "Email is already registered.";
            }
            if (email.Length < 3 || email.Length > 25)
            {
                return "Email must be between 3 and 25 characters";
            }
            if(password.Length <8 || password.Length > 20)
            {
                return "Password must be between 8 and 20 characters";
            }
            if (!email.Contains("@") || email.StartsWith("@") || email.EndsWith("@") ||
            !email.Contains(".") || email.StartsWith(".") || email.EndsWith("."))
            {
                return "Email must contain @ and . in the correct positions.";
            }
            DateTime cutoffDate = new DateTime(2010, 1, 1);
            if (selectedDOB >= cutoffDate)
            {
                return "Date must be earlier than 01/01/2010.";
            }

            if (password != confirmpass)
            {
                return "Password doesnt match.";
            }
            return string.Empty;
        }
	}
}