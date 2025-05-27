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
        //private static Database1Entities db = new Database1Entities();
        private static Database1Entities db = DatabaseSingleton.getInstance();
        public static String CreateNewUser(String email, String username, String password, String Gender, DateTime DOB, String role)
        {
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

        public static List<MsUser> getUser()
        {
            return (from users in db.MsUsers select users).ToList();
        }

        public static MsUser findJewel(int id)
        {
            return (from usersid in db.MsUsers where usersid.UserID == id select usersid).FirstOrDefault();
        }

        public static void UpdateUserPassword(MsUser user)
        {
            var existingUser = db.MsUsers.FirstOrDefault(u => u.UserID == user.UserID);
            if (existingUser != null)
            {
                existingUser.UserPassword = user.UserPassword; // Update password
                db.SaveChanges();
            }
        }
    }
}