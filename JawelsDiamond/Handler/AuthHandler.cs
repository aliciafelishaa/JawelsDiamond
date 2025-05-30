using JawelsDiamond.Factory;
using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
	public class AuthHandler
	{
		public static MsUser AttemptLogin(string email, string password)
		{
            //Bussiness logic
            MsUser user = UserRepository.LoginUser(email, password);
            return user;
        }

        public static string RegisterNewUser(string email, string username, string password, string gender, DateTime dob)
        {
            string role = email.Contains("admin") ? "admin" : "customer";
            MsUser newUser = UserFactory.CreateNewUser(email, username, password, gender, dob, role);
            return UserRepository.CreateNewUser(newUser);
        }
    }
}