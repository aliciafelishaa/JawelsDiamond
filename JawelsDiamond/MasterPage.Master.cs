using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string role = Session["role"] as string;

                phGuest.Visible = false;
                phCustomer.Visible = false;
                phAdmin.Visible = false;

                switch (role)
                {
                    case "guest":
                        phGuest.Visible = true;
                        break;
                    case "customer":
                        phCustomer.Visible = true;
                        break;
                    case "admin":
                        phAdmin.Visible = true;
                        break;
                    default:
                        phGuest.Visible = true;
                        break;
                }
            }
        }
    }
}