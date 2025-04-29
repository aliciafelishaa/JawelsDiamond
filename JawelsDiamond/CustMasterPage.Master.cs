using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond
{
	public partial class CustMasterPage : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            phCust.Visible = true;
        }
	}
}