using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using JawelsDiamond.Repository;
using JawelsDiamond.Model;

namespace JawelsDiamond.Views
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/Guest/LoginPages.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            int userId = ((MsUser)Session["user"]).UserID;

            var orders = TransactionRepository.GetUserTransactions(userId);
            OrderGrid.DataSource = orders;
            OrderGrid.DataBind();
        }

        protected void ViewDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int transactionId = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect($"TransactionDetails.aspx?id={transactionId}");
        }

        protected void ConfirmPackage_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int transactionId = Convert.ToInt32(btn.CommandArgument);

            TransactionRepository.UpdateTransactionStatus(transactionId, "Done");

            LoadOrders();
        }

        protected void RejectPackage_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int transactionId = Convert.ToInt32(btn.CommandArgument);

            TransactionRepository.UpdateTransactionStatus(transactionId, "Rejected");

            LoadOrders();
        }
    }
}
