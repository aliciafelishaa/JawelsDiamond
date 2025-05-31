using JawelsDiamond.Dataset;
using JawelsDiamond.Handler;
using JawelsDiamond.Model;
using System;
using System.Collections.Generic;

namespace JawelsDiamond.Views.Admin
{
    public partial class Report : System.Web.UI.Page
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
                CrystalReports report = new CrystalReports();
                CrystalReportViewer1.ReportSource = report;
                TransactionDataset dataSet = GetData(TransactionHandlers.GetData());
                report.SetDataSource(dataSet);
            }
        }

        private static TransactionDataset GetData(List<TransactionHeader> transactions)
        {
            TransactionDataset data = new TransactionDataset();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach (TransactionHeader t in transactions)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["PaymentMethod"] = t.PaymentMethod;
                hrow["TransactionStatus"] = t.TransactionStatus;
                headerTable.Rows.Add(hrow);

                if (t.TransactionDetails != null)
                {
                    foreach (var detail in t.TransactionDetails)
                    {
                        var drow = detailTable.NewRow();
                        drow["TransactionID"] = detail.TransactionID;
                        drow["Quantity"] = detail.Quantity;
                        drow["JewelID"] = detail.JewelID;

                        int price = detail.MsJewel?.JewelPrice ?? 0;
                        drow["Price"] = price;
                        drow["Subtotal"] = price * detail.Quantity;

                        detailTable.Rows.Add(drow);
                    }
                }
            }

            return data;
        }
    }
}