using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Modules.Product
{
    public partial class ViewProduct : System.Web.UI.Page
	{
		string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
			if (Page.RouteData.Values["GroupId"] != null)
			{
				id = Page.RouteData.Values["GroupId"] as string;
			}
			if (!IsPostBack)
			{
				if (Microsoft.VisualBasic.Information.IsNumeric(id))
				{
					List<Data.GroupProduct> listGroup = GroupProductService.GroupProduct_GetById(id);
					if (listGroup.Count > 0)
					{
						idU_ProductList.Level = listGroup[0].Level;
					}
				}	
			}
        }
    }
}