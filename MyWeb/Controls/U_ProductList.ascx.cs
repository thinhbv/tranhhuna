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
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DataTable dtPro = ProductService.Product_GetByTop("12", "Active=1 AND IsNew=1", "Ord");
				rptProducts.DataSource = StringClass.ModifyDataProduct(dtPro);
				rptProducts.DataBind();
			}
		}
	}
}