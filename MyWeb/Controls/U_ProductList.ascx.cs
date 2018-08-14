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
		private string itemCnt = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				DataTable dtPro;
				if (!IsPostBack)
				{
					if (string.IsNullOrEmpty(level))
					{
						dtPro = ProductService.Product_GetByTop("12", "Active=1 AND IsNew=1", "Ord");
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

		public string ItemCount { get { return itemCnt; } set { itemCnt = value; } }
	}
}