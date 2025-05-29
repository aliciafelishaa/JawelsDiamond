using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
	public partial class JewelDetail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string idParam = Request.QueryString["id"];

            if (string.IsNullOrEmpty(idParam) || !int.TryParse(idParam, out int jewelId))
            {
                Response.Redirect("~/Views/ViewJewels.aspx");
                return;
            }

            if (!IsPostBack)
            {
                if (jewelId > 0)
                {
                    LoadJewels(jewelId);
                    
                }
            }

            if (Session["user"] == null && Request.Cookies["user_cookie"] != null)
            {
                int userId = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                MsUser user = UserRepository.findJewel(userId);
                if (user != null)
                {
                    Session["user"] = user;
                    Session["role"] = user.UserRole.ToLower();
                }
            }

        }

		private void LoadJewels(int jewelID)
		{
			var jewels = JewelsRepository.findJewel(jewelID);
			if (jewels != null)
			{
				lblJewelName.Text = jewels.JewelName;
				lblJewelCategory.Text = jewels.MsCategory.CategoryName;
				lblJewelBrand.Text = jewels.MsBrand.BrandName;
				lblCountryOrigin.Text = jewels.MsBrand.BrandCountry;
				lblClass.Text = jewels.MsBrand.BrandClass;
				lblPrice.Text = "$ " + jewels.JewelPrice.ToString();
				lblReleaseYear.Text = jewels.JewelReleaseYear.ToString();

				string role = Session["role"] as string;
                
				if(role == null)
				{
                    Response.Redirect("~/Views/Guest/RegisterPages.aspx");
                    return;
                }
                else if (role == "admin")
				{
                    adminButtons.Style["display"] = "block";

				}
				else if(role == "customer")
				{
                    addToCartBtn.Style["display"] = "block";
				}
				
			}

        }


		protected void btnEdit_Click(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
			Response.Redirect("~/Views/Admin/EditJewels.aspx?id=" + jewelId);
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
            JewelsRepository.DeleteJewel(jewelId);
            Response.Redirect("~/Views/ViewJewels.aspx");
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/Guest/LoginPages.aspx");
                return;
            }

            MsUser currentUser = (MsUser)Session["user"];
            int userId = currentUser.UserID;

            string idParam = Request.QueryString["id"];
            if (string.IsNullOrEmpty(idParam) || !int.TryParse(idParam, out int jewelId))
            {
                Response.Redirect("~/Views/ViewJewels.aspx");
                return;
            }

            int quantity = 1;
            //System.Diagnostics.Debug.WriteLine($"id: {idParam}, Name={userId}");
            // Call repository method to insert into cart
            CartRepository.AddToCart(userId, jewelId, quantity);

            // Redirect to user's cart page
            Response.Redirect($"~/Views/Customer/CartPage.aspx?userId={userId}");
        }
    }
}