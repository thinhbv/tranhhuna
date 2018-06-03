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
	public partial class CheckOut : System.Web.UI.Page
	{
		protected string totalPrice = string.Empty;
		protected int totalCount = 0;
		private string orderId = string.Empty;
		private string Id = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];
					if (cookie != null && cookie.Value != null)
					{
						orderId = cookie.Value;
						DataTable dtCart = new DataTable();
						dtCart = OrdersService.Orders_GetByTop("1", "OrderId='" + StringClass.SqlInjection(orderId) + "' AND Status=0", "");
						if (dtCart.Rows.Count > 0)
						{
							Id = dtCart.Rows[0]["Id"].ToString();
							totalPrice = StringClass.ConvertPrice(dtCart.Rows[0]["Price"].ToString());
							DataTable dtCartInfo = OrderDetailService.OrderDetail_GetByTop("", "OrderId='" + dtCart.Rows[0]["Id"].ToString() + "'", "");
							if (dtCartInfo.Rows.Count > 0)
							{
								totalCount = dtCartInfo.Rows.Count;
								rptCart.DataSource = dtCartInfo;
								rptCart.DataBind();
							}
							else
							{
								rptCart.Visible = false;
								lblMsg.Visible = true;
							}
						}
						else
						{
							rptCart.Visible = false;
							lblMsg.Visible = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
		}

		protected void btnDelivery_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					if (string.IsNullOrEmpty(fname.Value.Trim()))
					{
						lblName.Visible = true;
						fname.Focus();
						return;
					}
					else
					{
						lblName.Visible = false;
					}
					if (string.IsNullOrEmpty(email.Value.Trim()))
					{
						lblEmail.Visible = true;
						email.Focus();
						return;
					}
					else
					{
						lblEmail.Visible = false;
					}
					if (string.IsNullOrEmpty(adr.Value.Trim()))
					{
						lblTel.Visible = true;
						adr.Focus();
						return;
					}
					else
					{
						lblTel.Visible = false;
					}
					if (string.IsNullOrEmpty(city.Value.Trim()))
					{
						lblAddress.Visible = true;
						city.Focus();
						return;
					}
					else
					{
						lblAddress.Visible = false;
					}

					Orders order = new Orders();
					order.Id = Id;
					order.Name = fname.Value.Trim();
					order.Email = email.Value.Trim();
					order.Tel = adr.Value.Trim();
					order.Address = city.Value.Trim();
					order.OrderId = orderId;
					order.OrderDate = DateTimeClass.ConvertDateTime(DateTime.Now, "dd/MM/yyyy HH:mm:ss");
					if (rdoChuyenkhoan.Checked)
					{
						order.PaymentMethod = "0";
					}
					else
					{
						order.PaymentMethod = "1";
					}
					order.Price = totalPrice;
					order.Status = "1";
					order.Detail = content.Value.Trim();
					order.DeliveryDate = "";
					OrdersService.Orders_Update(order);
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
		}
	}
}