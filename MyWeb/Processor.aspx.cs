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
			string id = string.Empty;
			string quantity = string.Empty;
			try
			{
				switch (Request.Params["mode"])
				{
					case "delete":
						if (Request.Params["orderid"] == null)
						{
							return;
						}
						id = Request.Params["orderid"].ToString();
						count = OrdersService.DeleteItem(Request.Params["orderid"].ToString());
						break;
					case "add":
						if (Request.Params["id"] == null)
						{
							return;
						}
						if (Request.Params["quantity"] == null)
						{
							quantity = "1";
						}
						else
						{
							quantity = Request.Params["quantity"].ToString();
						}
						id = Request.Params["id"].ToString();
						HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];
						string BillId = string.Empty;
						if (cookie == null || cookie.Value == null)
						{
							cookie = new HttpCookie(Consts.GUID_SHOPPING_CART);
							cookie.Value = Guid.NewGuid().ToString();
							cookie.Expires = DateTime.Now.AddDays(6);
							HttpContext.Current.Response.SetCookie(cookie);
						}
						count = OrdersService.Orders_Add(StringClass.SqlInjection(id), StringClass.SqlInjection(cookie.Value), quantity);
						break;
					case "update":
						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
			Response.Clear();
			Response.AppendHeader("Content-Type", "text/plain; charset=Shift_JIS");
			Response.AppendHeader("Content-Length", System.Text.Encoding.Default.GetBytes(count).Length.ToString());
			Response.Write(count);
			Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
			Response.Flush();
			try
			{
				Response.End();
			}
			catch
			{
			}
		}
	}
}