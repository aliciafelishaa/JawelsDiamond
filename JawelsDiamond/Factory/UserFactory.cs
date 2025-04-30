using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Factory
{
    public class UserFactory
    {
        public static MsUser CreateNewUser(string email, string username, string password, string gender, DateTime DOB, string role)
        {
            MsUser newUser = new MsUser();
            newUser.UserEmail = email;
            newUser.UserName = username;
            newUser.UserPassword = password;
            newUser.UserGender = gender;
            newUser.UserDOB = DOB;
            newUser.UserRole = role;
            return newUser;
        }
    }
}