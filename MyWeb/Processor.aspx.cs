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

namespace MyWeb
{
	public partial class Processor : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string count = "0";
			try
			{
				if (Request.Params["del"] != null && Request.Params["del"].ToString() == "true")
				{
					if (Request.Params["orderid"] == null)
					{
						return;
					}
					count = OrdersService.DeleteItem(Request.Params["orderid"].ToString());
				}
				else
				{
					if (Request.Params["id"] == null)
					{
						return;
					}
					string id = Request.Params["id"].ToString();
					HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];
					string BillId = string.Empty;
					if (cookie == null || cookie.Value == null)
					{
						cookie = new HttpCookie(Consts.GUID_SHOPPING_CART);
						cookie.Value = Guid.NewGuid().ToString();
						cookie.Expires = DateTime.Now.AddDays(6);
						HttpContext.Current.Response.SetCookie(cookie);
					}
					count = OrdersService.Orders_Add(StringClass.SqlInjection(id), StringClass.SqlInjection(cookie.Value));
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
			Response.Write(count);
		}
	}
}