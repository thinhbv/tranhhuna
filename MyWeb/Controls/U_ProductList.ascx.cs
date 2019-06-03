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
		private string itemCnt = "4";
		string chudeId = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (Page.RouteData.Values["Id"] != null)
				{
					chudeId = Page.RouteData.Values["Id"] as string;
				}
				DataTable dtPro = null;
				if (!IsPostBack)
				{
					if (Request.QueryString["key"] != null)
					{
						string key = StringClass.SqlInjection(Request.QueryString["key"].ToString());
						dtPro = ProductService.Product_GetByTop("12", "Active=1 AND (Name like '%" + key + "%' OR Detail like '%" + key + "%' OR Content like '%" + key + "%')", "Ord");
					}
					else if (Microsoft.VisualBasic.Information.IsNumeric(chudeId))
					{
						dtPro = ProductService.Product_GetByTop("", "Active=1 AND ChudeId=" + chudeId, "Ord");
					}
					else if (string.IsNullOrEmpty(level))
					{
						dtPro = ProductService.Product_GetByTop("12", "Active=1", "Ord");
					}
					else
					{
						dtPro = ProductService.Product_GetByTop("", "Active=1 AND GroupId IN (Select Id from GroupProduct Where Active=1 AND Left(Level,Len('" + level + "'))='" + level + "')", "Ord");
					}

					HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];

					switch (itemCnt)
					{
						case "4":
							rptProducts04.DataSource = StringClass.ModifyDataProduct(dtPro, cookie);
							rptProducts04.DataBind();
							break;
						default:
							rptProducts.DataSource = StringClass.ModifyDataProduct(dtPro, cookie);
							rptProducts.DataBind();
							break;
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}

		public string Level { get { return level; } set { level = value; } }
		public string ChudeId { get; set;}

		public string ItemCount { get { return itemCnt; } set { itemCnt = value; } }
	}
}