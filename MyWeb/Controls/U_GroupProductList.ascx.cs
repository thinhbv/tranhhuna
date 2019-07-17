using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Common;
using MyWeb.Data;
using MyWeb.Business;


namespace MyWeb.Controls
{
	public partial class U_GroupProductList : System.Web.UI.UserControl
	{
		private DataTable dtGroup;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					if (dtGroup != null && dtGroup.Rows.Count > 0)
					{
						rptGroup.DataSource = StringClass.ModifyDataGroupProduct(dtGroup);
						rptGroup.DataBind();
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}
		protected void rptGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			try
			{
				RepeaterItem item = e.Item;
				if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
				{
					string id = DataBinder.Eval(item.DataItem, "Id").ToString();
					string itemCnt = DataBinder.Eval(item.DataItem, "Items").ToString();
					DataTable dtPro = ProductService.Product_GetByTop("10", "Active = 1 AND GroupId=" + id, "Id DESC");
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
		public DataTable GroupProduct { get { return dtGroup; } set { dtGroup = value; } }
	}
}