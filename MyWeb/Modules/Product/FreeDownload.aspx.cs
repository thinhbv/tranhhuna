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

namespace MyWeb.Modules.Product
{
	public partial class FreeDownload : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DataTable dt = FilesUploadService.FilesUpload_GetByTop("", "Active = 1", "Id DESC");
				rptProducts.DataSource = dt;
				rptProducts.DataBind();
			}
		}

		protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			try
			{
				RepeaterItem item = e.Item;
				if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
				{
					string id = DataBinder.Eval(item.DataItem, "Id").ToString();
					string itemCnt = DataBinder.Eval(item.DataItem, "Items").ToString();
					DataTable dtPro = ProductService.Product_GetByTop("10", "Active = 1 AND GroupId=" + id, "Ord");
					if (dtPro.Rows.Count == 0)
					{
						item.Visible = false;
					}
					Repeater rptPro = (Repeater)item.FindControl("rptPro");
					Repeater rptProducts04 = (Repeater)item.FindControl("rptProducts04");
					if (rptPro != null)
					{
						HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];
						switch (itemCnt)
						{
							case "4":
								rptProducts04.DataSource = StringClass.ModifyDataProduct(dtPro, cookie);
								rptProducts04.DataBind();
								break;
							default:
								rptPro.DataSource = StringClass.ModifyDataProduct(dtPro, cookie);
								rptPro.DataBind();
								break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}
	}
}