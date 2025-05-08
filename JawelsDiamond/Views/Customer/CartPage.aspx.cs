    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using JawelsDiamond.Model;

    namespace JawelsDiamond.Views.Customer
    {
        public partial class CartPage : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["user"] != null)
                {
                    MsUser sessionUser = (MsUser)Session["user"];
                    HeaderCart.Text = sessionUser.UserName + "'s Cart";
                }
                else
                {   
                    Response.Redirect("~/Views/Login.aspx");
                }

                //if (!IsPostBack)
                //{
                //    LoadCart();
                //}
            }

            protected void LoadCart()
            {

            }
        }
    }