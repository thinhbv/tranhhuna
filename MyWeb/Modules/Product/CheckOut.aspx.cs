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
using System.Collections;

namespace MyWeb.Modules.Product
{
	public partial class CheckOut : System.Web.UI.Page
	{
		protected static string totalPrice = string.Empty;
		protected static int totalCount = 0;
		private static string orderId = string.Empty;
		private static string Id = string.Empty;
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
								totalCount = 0;
								rptCart.Visible = false;
								lblMsg.Text = "Hiện tại không có sản phẩm nào trong giỏ hàng";
							}
						}
						else
						{
							totalCount = 0;
							rptCart.Visible = false;
							lblMsg.Text = "Hiện tại không có sản phẩm nào trong giỏ hàng";
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
					Hashtable htData = new Hashtable();
					for (int i = 0; i < rptCart.Items.Count; i++)
					{
						RepeaterItem item = rptCart.Items[i];
						TextBox txtquantity = (TextBox)item.FindControl("txtquantity");
						DropDownList ddlSize = (DropDownList)item.FindControl("ddlSize");
						HiddenField hfId = (HiddenField)item.FindControl("hfId");
						htData.Add(hfId.Value.Trim(), txtquantity.Text.Trim() + "," + ddlSize.SelectedValue);
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
					OrdersService.PurchaseProduct(order, htData);
					lblMsg.Text = "Cảm ơn bạn đã mua sản phẩm của chúng tôi. Chúng tôi sẽ giao hàng trong thời gian sớm nhất.";
					shoppingcart.Visible = false;
					rptCart.Visible = false;
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
		}

		protected void rptCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem) 
			{
				DropDownList ddlSize = (DropDownList)item.FindControl("ddlSize");
				if (ddlSize != null)
				{
					HiddenField hdProductId = (HiddenField)item.FindControl("hdProductId");
					HiddenField hdSize = (HiddenField)item.FindControl("hdSize");
					if (hdProductId != null)
					{
						string proId = hdProductId.Value;
						DataTable dtPro = ProductService.Product_GetById(proId);
						if (dtPro.Rows.Count > 0)
						{
							string[] lSize;
							if (dtPro.Rows[0]["Image5"].ToString().IndexOf(",") > -1)
							{
								HiddenField hdPrice = (HiddenField)item.FindControl("hdPrice");
								lSize = dtPro.Rows[0]["Image5"].ToString().Split(Char.Parse(","));
								hdPrice.Value = dtPro.Rows[0]["Price"].ToString();
							}
							else
							{
								lSize = new string[] { dtPro.Rows[0]["Image5"].ToString() };
							}
							for (int i = 0; i < lSize.Length; i++)
							{
								ddlSize.Items.Add(new ListItem(lSize[i], lSize[i]));
							}
							ddlSize.DataBind();
							if (hdSize != null)
							{
								ddlSize.SelectedValue = hdSize.Value;
							}
						}
					}
				}
			}
		}
	}
}