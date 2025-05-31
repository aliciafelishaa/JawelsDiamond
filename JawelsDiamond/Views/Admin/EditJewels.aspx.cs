using JawelsDiamond.Controller;
using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views.Admin
{
    public partial class EditJewels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                LoadJewels(jewelId);
                LoadBrands();
                LoadCategory();
            }

        }
        private void LoadBrands()
        {
            var brands = JewelsRepository.GetBrands();

            JewelBrand.DataSource = brands;
            JewelBrand.DataTextField = "BrandName";
            JewelBrand.DataValueField = "BrandID";
            JewelBrand.DataBind();

            JewelBrand.Items.Insert(0, new ListItem("Select Brand", ""));
        }

        private void LoadCategory()
        {
            var category = JewelsRepository.GetCategories();

            JewelCategory.DataSource = category;
            JewelCategory.DataTextField = "CategoryName";
            JewelCategory.DataValueField = "CategoryID";
            JewelCategory.DataBind();

            JewelCategory.Items.Insert(0, new ListItem("Select Category", ""));
        }

        private void LoadJewels(int jewelId)
        {
            var jewels = JewelsRepository.findJewel(jewelId);
            JewelName.Text = jewels.JewelName;
            JewelBrand.SelectedValue = jewels.BrandID.ToString();       
            JewelCategory.SelectedValue = jewels.CategoryID.ToString();
            JewelPrice.Text = jewels.JewelPrice.ToString();
            JewelReleaseYear.Text = jewels.JewelReleaseYear.ToString();
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect($"~/Views/JewelDetail.aspx?id={jewelId}");
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
            string jewelName = JewelName.Text;
            string brand = JewelBrand.SelectedValue;
            string category = JewelCategory.SelectedValue;
            string price = JewelPrice.Text;
            string releaseYear = JewelReleaseYear.Text;

            string error = UpdateItem.checkItem(jewelName, brand, category, price, releaseYear);
            errorMsg.Text = error;


            Console.WriteLine("test");
            var jewels = JewelsRepository.findJewel(jewelId);
            jewels.JewelName = jewelName;
            jewels.BrandID = Convert.ToInt32(brand);           
            jewels.CategoryID = Convert.ToInt32(category);
            jewels.JewelPrice = Convert.ToInt32(price);
            jewels.JewelReleaseYear = Convert.ToInt32(releaseYear);

            JewelsRepository.EditJewel(jewels);
            Response.Redirect("~/Views/JewelDetail.aspx");

        }
    }
}