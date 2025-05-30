using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
	public partial class ViewJewels : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["user"] != null)
            {
                MsUser sessionUser = (MsUser)Session["user"];
                Header.Text = "Welcome " + sessionUser.UserName + "!";
                Header.Visible = true;
            }
            else
            {
                Header.Visible = false;
            }
            if (!IsPostBack)
			{
				LoadJewels();
				
			}
		}

		private void LoadJewels()
		{
			var jewels = JewelsRepository.getJewel();
			JewelGrid.DataSource = jewels;
			JewelGrid.DataBind();
		}

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}