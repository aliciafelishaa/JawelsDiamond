using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JawelsDiamond.Model;
using JawelsDiamond.Repository;

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
                Response.Redirect("~/Views/Guest/LoginPages.aspx");
            }


            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private DataTable GetAllCartItems(int userId)
        { 
            List<Cart> cartItems = CartRepository.GetCartItems(userId);
            
            DataTable dt = new DataTable();
            dt.Columns.Add("JewelID", typeof(int));
            dt.Columns.Add("JewelName", typeof(string));
            dt.Columns.Add("JewelPrice", typeof(decimal));
            dt.Columns.Add("BrandName", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Subtotal", typeof(decimal));
            foreach (Cart cartItem in cartItems)
            {
                System.Diagnostics.Debug.WriteLine($"Cart Item - UserID: {cartItem.UserID}, JewelID: {cartItem.JewelID}, Quantity: {cartItem.Quantity}");

                MsJewel jewel = JewelsRepository.findJewel(cartItem.JewelID);
                if (jewel != null)
                {
                    DataRow row = dt.NewRow();
                    row["JewelID"] = jewel.JewelID;
                    row["JewelName"] = jewel.JewelName;
                    row["JewelPrice"] = jewel.JewelPrice;
                    row["BrandName"] = JewelsRepository.GetBrandName(jewel.BrandID);
                    row["Quantity"] = cartItem.Quantity;
                    row["Subtotal"] = jewel.JewelPrice * cartItem.Quantity;
                    System.Diagnostics.Debug.WriteLine($"Adding to DataTable: {jewel.JewelID}, {jewel.JewelName}");
                    System.Diagnostics.Debug.WriteLine($"Row: JewelID={row["JewelID"]}, Name={row["JewelName"]}, Quantity={row["Quantity"]}");
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        protected void LoadCart()
        {
           
                MsUser currentUser= (MsUser)Session["user"];
                int userId = currentUser.UserID;
            
                DataTable dt = GetAllCartItems(userId);

                

                CartGrid.DataSource = dt;
                CartGrid.DataBind();
            
                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToDecimal(row["Subtotal"]);
                }
                Lbl_TotalPriceValue.Text = $"Rp{total:0.00}";
        }

        protected void CartGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Button btn = (Button)sender;
            //GridViewRow row = (GridViewRow)btn.NamingContainer;
            //int jewelId = Convert.ToInt32(CartGrid.DataKeys[row.RowIndex].Value);

            int jewelId = 0;
            if (e.RowIndex >= 0 && e.RowIndex < CartGrid.DataKeys.Count)
            {
                jewelId = Convert.ToInt32(CartGrid.DataKeys[e.RowIndex].Value);
                // proceed with deletion
            }

            MsUser currentUser = (MsUser)Session["user"];
            int userId = currentUser.UserID;

            //HeaderCart.Text = jewelId + "'s Cart";
            System.Diagnostics.Debug.WriteLine($"removing to DataTable: {jewelId}, {userId}");
            CartRepository.DeleteCartItem(userId, jewelId);

            CartGrid.DataSource = null;
            CartGrid.DataBind();

            LoadCart();
        }

        protected void CartGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true; // Cancel default edit mode behavior
            int jewelId = Convert.ToInt32(CartGrid.DataKeys[e.NewEditIndex].Value);

            MsUser currentUser = (MsUser)Session["user"];
            if (currentUser == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            Response.Redirect($"~/Views/Customer/UpdateJewelQuantityPage.aspx?id={jewelId}");
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_ClearCart_Click(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                MsUser currentUser = (MsUser)Session["user"];
                int userId = currentUser.UserID;

                CartRepository.ClearCart(userId);
                LoadCart();
            }
            else
            {
                Response.Redirect("~/Views/Guest/LoginPages.aspx");
            }
        }

        protected void Btn_Checkout_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/Guest/LoginPages.aspx");
                return;
            }

            MsUser currentUser = (MsUser)Session["user"];
            int userId = currentUser.UserID;
            List<Cart> cartItems = CartRepository.GetCartItems(userId);

            if (cartItems == null || cartItems.Count == 0)
            {
                Response.Write("<script>alert('Cart is empty. Cannot proceed to checkout.');</script>");
                return;
            }

            TransactionHeader header = new TransactionHeader
            {
                UserID = userId,
                TransactionDate = DateTime.Now,
                PaymentMethod = PaymentDropdown.SelectedValue,
                TransactionStatus = "Payment Pending"
            };

            int headerId = TransactionRepository.InsertTransactionHeader(header);

            foreach (Cart item in cartItems)
            {
                TransactionDetail detail = new TransactionDetail
                {
                    TransactionID = headerId,
                    JewelID = item.JewelID,
                    Quantity = item.Quantity
                };

                TransactionRepository.InsertTransactionDetail(detail);
            }

            CartRepository.ClearCart(userId);
            LoadCart();

        }
    }
}