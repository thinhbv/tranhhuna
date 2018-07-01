using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;

namespace MyWeb.Controls
{
	public partial class U_Delivery : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					DataTable dt = NewsService.News_GetByTop("3", "Priority=3 AND Active=1", "Ord DESC");
					rptDelivery.DataSource = dt;
					rptDelivery.DataBind();
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
		}
	}
}