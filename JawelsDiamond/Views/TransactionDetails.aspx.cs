using System;
using System.Linq;
using JawelsDiamond.Repository;
using JawelsDiamond.Model;

namespace JawelsDiamond.Views
{
    public partial class TransactionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || Session["role"].ToString() != "customer")
            {
                Response.Redirect("~/Views/Guest/LoginPages.aspx");
                return;
            }

            if (!IsPostBack)
            {
                string transactionIdParam = Request.QueryString["id"];

                if (string.IsNullOrEmpty(transactionIdParam) || !int.TryParse(transactionIdParam, out int transactionId))
                {
                    Response.Redirect("~/Views/MyOrder.aspx");
                }
                else
                {
                    LoadTransactionDetails(transactionId);
                }
            }
        }

        private void LoadTransactionDetails(int transactionId)
        {
            using (var db = new Database1Entities())
            {
                var transactionDetails = (from th in db.TransactionHeaders
                                          join td in db.TransactionDetails on th.TransactionID equals td.TransactionID
                                          join jewel in db.MsJewels on td.JewelID equals jewel.JewelID
                                          where th.TransactionID == transactionId
                                          select new
                                          {
                                              th.TransactionID,
                                              JewelName = jewel.JewelName,
                                              td.Quantity
                                          }).FirstOrDefault();

                if (transactionDetails != null)
                {
                    lblTransactionID.Text = transactionDetails.TransactionID.ToString();
                    lblJewelName.Text = transactionDetails.JewelName;
                    lblQuantity.Text = transactionDetails.Quantity.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/MyOrder.aspx");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MyOrder.aspx");
        }
    }
}
