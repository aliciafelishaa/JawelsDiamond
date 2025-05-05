using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond
{
	public partial class RegisterPages : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            String email = TB_Email.Text;
            String username = TB_Username.Text;
            String password = TB_Password.Text;
            String confirmpass = TB_ConfirmPass.Text;
            String selectedGender = RBL_Gender.SelectedValue;
            DateTime selectedDOB = DateTime.Parse(TB_DOB.Text);
            DateTime cutoffDate = new DateTime(2010, 1, 1);

            if (email == "" || username == "" || password == "" || confirmpass == "" || selectedGender == "" || selectedDOB == DateTime.MinValue)
            {
                Lbl_Status.Text = "All fields must be filled.";
                return;
            }
            else if (password != confirmpass)
            {
                Lbl_Status.Text = "Password doesnt match.";
                return;
            }
            else if (email.IndexOf("@") == -1 || email.IndexOf("@") == 0 || email.IndexOf("@") == email.Length - 1 || email.IndexOf(".") == -1 || email.IndexOf(".") == 0 || email.IndexOf(".") == email.Length - 1)
            {
                Lbl_Status.Text = "Email must contain @ in the right place.";
                return;
            }
            else if (selectedDOB >= cutoffDate)
            {
                Lbl_Status.Text = "Date must be earlier than 01/01/2010.";
                return;
            }
            String role = "customer";
            if (email.Contains("admin"))
            {
                role = "admin";
            }
            Lbl_Status.Text = UserRepository.CreateNewUser(email, username, password, selectedGender, selectedDOB, role);
            Response.Redirect("LoginPages.aspx");
        }

        protected void Link_Btn_ToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPages.aspx");
        }
    }
}