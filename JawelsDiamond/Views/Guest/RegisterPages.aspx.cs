using JawelsDiamond.Controller;
using JawelsDiamond.Handler;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            DateTime selectedDOB;

            //Parse DOB sbg string terlebih dahulu
            if (!DateTime.TryParse(TB_DOB.Text, out selectedDOB))
            {
                Lbl_Status.Text = "Invalid Date of Birth format. Please enter a valid date (e.g., YYYY-MM-DD).";
                Lbl_Status.ForeColor = Color.Red;
                return; 
            }

            //Controller validasi
            string errorMsg = Auth.registCheckUser(email, username, password, confirmpass, selectedGender, selectedDOB);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                Lbl_Status.Text = errorMsg;
                Lbl_Status.ForeColor = Color.Red;
                return;
            }

            //Handler bussiness logic
            string result = AuthHandler.RegisterNewUser(email, username, password, selectedGender, selectedDOB);
            Lbl_Status.Text = result;
            Response.Redirect("LoginPages.aspx");
        }

        protected void Link_Btn_ToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPages.aspx");
        }
    }
}