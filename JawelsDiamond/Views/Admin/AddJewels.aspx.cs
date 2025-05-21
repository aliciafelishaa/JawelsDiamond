using JawelsDiamond.Controller;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class AddJewels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"].ToString() != "admin")
            {
                Response.Redirect("~/Views/ViewJewels.aspx");
                return;
            }

            if (!IsPostBack)
            {
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
            var categories = JewelsRepository.GetCategories();

            JewelCategory.DataSource = categories;
            JewelCategory.DataTextField = "CategoryName";
            JewelCategory.DataValueField = "CategoryID";
            JewelCategory.DataBind();

            JewelCategory.Items.Insert(0, new ListItem("Select Category", ""));
        }

        protected void Add_Btn(object sender, EventArgs e)
        {
            string jewelName = JewelName.Text;
            string brand = JewelBrand.SelectedValue;
            string category = JewelCategory.SelectedValue;
            string price = JewelPrice.Text;
            string releaseYear = JewelReleaseYear.Text;

            string error = AddItem.checkItem(jewelName, brand, category, price, releaseYear);
            errorMsg.Text = error;

            if (error == "")
            {
                // Jika berhasil, kosongkan semua field
                JewelName.Text = "";
                JewelBrand.SelectedIndex = 0;
                JewelCategory.SelectedIndex = 0;
                JewelPrice.Text = "";
                JewelReleaseYear.Text = "";
            }
        }

        protected void Cancel_Btn(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewJewels.aspx");
        }
    }
}