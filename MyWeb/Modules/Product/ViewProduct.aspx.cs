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
		protected string groupName = string.Empty;
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
						DataTable dt = GroupProductService.GroupProduct_GetByTop("", "Active = 1 AND Len(Level) > " + listGroup[0].Level.Length + " AND Left(Level,Len('" + listGroup[0].Level + "'))='" + listGroup[0].Level + "' AND Id <> " + id, "");
						if (dt.Rows.Count > 0)
						{
							idU_ProductList.Visible = false;
							U_GroupProductList.Visible = true;
							U_GroupProductList.GroupProduct = dt;
						}
						else
						{
							idU_ProductList.Visible = true;
							U_GroupProductList.Visible = false;
							idU_ProductList.Level = listGroup[0].Level;
							idU_ProductList.ItemCount = listGroup[0].Items;
						}
						groupName = listGroup[0].Name;
					}
				}	
			}
        }
    }
}