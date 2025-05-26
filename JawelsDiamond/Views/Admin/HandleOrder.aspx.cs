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
    public partial class HandleOrders : System.Web.UI.Page
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
                BindGrid();
            }
        }

        private void BindGrid()
        {
            List<TransactionHeader> transaction = TransactionRepository.GetUnfinishedTransaction();
            if (transaction != null)
            {
                GV_Transaction.DataSource = transaction;
                GV_Transaction.DataBind();
            }
        }

        protected void GV_Transaction_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();
                Button btnConfirm = (Button)e.Row.FindControl("Btn_Confirm");
                Button btnShip = (Button)e.Row.FindControl("Btn_Ship");
                Label lblArrived = (Label)e.Row.FindControl("Lbl_Arrived");

                btnConfirm.Visible = false;
                btnShip.Visible = false;
                lblArrived.Visible = false;

                if (status == "Payment Pending")
                {
                    btnConfirm.Visible = true;
                }
                else if (status == "Shipment Pending")
                {
                    btnShip.Visible = true;
                }
                else if (status == "Arrived")
                {
                    lblArrived.Visible = true;
                }
            }
        }

        protected void GV_Transaction_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm" || e.CommandName == "Ship")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GV_Transaction.Rows[index];

                int transactionId = Convert.ToInt32(GV_Transaction.DataKeys[index].Value);

                string newStatus = "";
                if (e.CommandName == "Confirm")
                    newStatus = "Shipment Pending";
                else if (e.CommandName == "Ship")
                    newStatus = "Arrived";

                TransactionRepository.UpdateTransactionStatus(transactionId, newStatus);
                BindGrid();
            }
        }

    }
}