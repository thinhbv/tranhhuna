using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;
using System.Data;

namespace MyWeb.Controls
{
	public partial class U_ProductList : System.Web.UI.UserControl
	{
		private string level = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			DataTable dtPro;
			if (!IsPostBack)
			{
				if (string.IsNullOrEmpty(level))
				{
					dtPro = ProductService.Product_GetByTop("6", "Active=1 AND IsNew=1", "Ord");
				}
				else
				{
					dtPro = ProductService.Product_GetByTop("", "Active=1 AND GroupId IN (Select Id from GroupProduct Where Active=1 AND Left(Level,Len('" + level + "'))='" + level + "')", "Ord");
					
				}

				HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];
				rptProducts.DataSource = StringClass.ModifyDataProduct(dtPro, cookie);
				rptProducts.DataBind();
			}
		}

		public string Level { get { return level; } set { level = value; } }
	}
}