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
	public partial class U_ImageList : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					List<Images> listImg = ImagesService.Images_GetByTop("", "Priority=1 AND Active=1", "Ord");
					rptImages.DataSource = listImg;
					rptImages.DataBind();
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" +ex.StackTrace);
			}
		}
	}
}