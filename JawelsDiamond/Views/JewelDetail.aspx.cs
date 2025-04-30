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
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
			if(jewelId == null)
			{
                Response.Redirect("~/Views/ViewJewels.aspx");
            }
            if (!IsPostBack)
			{	
				if (jewelId > 0)
				{
					LoadJewels(jewelId);
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
				lblPrice.Text = "Rp. " + jewels.JewelPrice.ToString();
				lblReleaseYear.Text = jewels.JewelReleaseYear.ToString();

				string role = Session["role"] as string;
                lblJewelName.Text += " (Role: " + role + ")";

                if (role == "admin")
				{
                    adminButtons.Style["display"] = "block";

				}
				else if(role=="guest")
				{
                    addToCartBtn.Style["display"] = "block";
				}
				else
				{
                    Response.Redirect("~/Views/Guest/LoginPages.aspx");
                }
			}

        }

		protected void btnEdit_Click(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
			Response.Redirect("EditJewels.aspx?id=" + jewelId);
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
            JewelsRepository.DeleteJewel(jewelId);
            Response.Redirect("~/Views/ViewJewels.aspx");
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

        }
    }
}