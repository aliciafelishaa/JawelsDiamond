using JawelsDiamond.Factory;
using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repository
{
    public class UserRepository
    {
        public static String CreateNewUser(String email, String username, String password, String Gender, DateTime DOB, String role)
        {
            Database1Entities db = new Database1Entities();
            MsUser newUser = UserFactory.CreateNewUser(email, username, password, Gender, DOB, role);
            db.MsUsers.Add(newUser);
            db.SaveChanges();
            return "Registration Success";
        }
        public static MsUser LoginUser(string email, string password)
        {
            Database1Entities db = new Database1Entities();
            MsUser loginUser = (from x in db.MsUsers where x.UserEmail == email && x.UserPassword == password select x).FirstOrDefault();
            return loginUser;
        }
    }
}