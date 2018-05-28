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
			if (!IsPostBack)
			{
				List<Images> listImg = ImagesService.Images_GetByTop("", "Priority=2 AND Active=1", "Ord");
				rptImages.DataSource = listImg;
				rptImages.DataBind();
			}
		}
	}
}