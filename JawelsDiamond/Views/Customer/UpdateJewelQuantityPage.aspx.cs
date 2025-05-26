using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JawelsDiamond.Model;
using JawelsDiamond.Repository;

namespace JawelsDiamond.Views.Customer
{
    public partial class UpdateJewelQuantityPage : System.Web.UI.Page
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
                lblPrice.Text = "$" + jewels.JewelPrice.ToString();
                lblReleaseYear.Text = jewels.JewelReleaseYear.ToString();

                string role = Session["role"] as string;

                if (role == null)
                {
                    Response.Redirect("~/Views/Guest/RegisterPages.aspx");
                    return;
                }
            }

        }

        protected void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            string idParam = Request.QueryString["id"];
            int jewelId = Convert.ToInt32(idParam);
            MsUser currentUser = (MsUser)Session["user"];
            int userId = currentUser.UserID;
            int updateQuantity = Convert.ToInt32(txtQuantity.Text);
            CartRepository.UpdateCart(userId, jewelId, updateQuantity);
            Response.Redirect($"~/Views/Customer/CartPage.aspx?userId={userId}");
        }
    }
}