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
	public partial class ProductDetail : System.Web.UI.Page
	{
		protected string name = string.Empty;
		protected string content = string.Empty;
		protected string sImage_01 = string.Empty;
		protected string sPrice = string.Empty;
		protected string id = string.Empty;
		string groupname = string.Empty;
		private bool isLogin = false;
		private bool isValidDownload = false;
		Customers cus = new Customers();
		protected bool isShowDownload = false; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.RouteData.Values["Id"] != null)
			{
				id = Page.RouteData.Values["Id"] as string;
			}
			if (Page.RouteData.Values["groupName"] != null)
			{
				groupname = Page.RouteData.Values["groupName"] as string;
			}
			if (Session["Info"] != null)
			{
				cus = (Customers)Session["Info"];
				isLogin = true;
				DataTable dtCount = DownloadHistoryService.DownloadHistory_GetByUserId(cus.Id);
				if (dtCount.Rows.Count < 2)
				{
					isValidDownload = true;
				}
			}
			try
			{
				if (Microsoft.VisualBasic.Information.IsNumeric(id))
				{
					DataTable pro = ProductService.Product_GetById(id);
					if (pro.Rows.Count > 0)
					{
						name = pro.Rows[0]["Name"].ToString();
						Page.Title = name;
						content = pro.Rows[0]["Content"].ToString();
						ltrDetail.Text = pro.Rows[0]["Detail"].ToString();
						sImage_01 = pro.Rows[0]["Image1"].ToString();
						sPrice = pro.Rows[0]["Price"].ToString();
						hdPrice.Value = sPrice;
						if (sPrice.IndexOf(",") > -1)
						{
							sPrice = sPrice.Split(Char.Parse(","))[0];
						}
						if (pro.Rows[0]["IsSpecial"].ToString() == "1")
						{
							isShowDownload = true;
						}
						if (!IsPostBack)
						{
							string strSize = pro.Rows[0]["Image5"].ToString();
							string[] lSize;
							if (strSize.IndexOf(",") > -1)
							{
								lSize = strSize.Split(Char.Parse(","));
							}
							else
							{
								lSize = new string[] { strSize };
							}

							for (int i = 0; i < lSize.Length; i++)
							{
								if (lSize[i] == string.Empty)
								{
									continue;
								}
								ddlSize.Items.Add(new ListItem(lSize[i], lSize[i]));
							}
							ddlSize.DataBind();
							ddlSize.SelectedIndex = 0;

							//Hiển thị sản phẩm tương tự
							List<GroupProduct> lstG = GroupProductService.GroupProduct_GetById(pro.Rows[0]["GroupId"].ToString());
							string itemCnt = string.Empty;
							if (lstG.Count > 0)
							{
								itemCnt = lstG[0].Items;
							}
							if (string.IsNullOrEmpty(itemCnt) || itemCnt == "0")
							{
								itemCnt = "3";
							}
							DataTable dtRelated = ProductService.Product_GetByTop((Int16.Parse(itemCnt) * 2).ToString(), "Active = 1 AND GroupId='" + pro.Rows[0]["GroupId"].ToString() + "' AND Id <> '" + id + "'", "Ord");
							if (dtRelated.Rows.Count > 0)
							{
								HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];
								switch (itemCnt)
								{
									case "4":
										rptProducts04.DataSource = StringClass.ModifyDataProduct(dtRelated, cookie);
										rptProducts04.DataBind();
										break;
									default:
										rptProducts.DataSource = StringClass.ModifyDataProduct(dtRelated, cookie);
										rptProducts.DataBind();
										break;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}

		protected void btnAddCart_Click(object sender, EventArgs e)
		{
			try
			{
				if (isLogin)
				{
					if (isValidDownload)
					{
						DataTable file = FilesUploadService.FilesUpload_GetByTop("1", "ProductId='" + id + "'", "");
						if (file.Rows.Count == 0)
						{
							WebMsgBox.Show("File này không còn tồn tại trong hệ thống!");
							return;
						}
						DownloadHistory history = new DownloadHistory();
						history.UserId = cus.Id;
						history.FileId = file.Rows[0]["Id"].ToString();
						history.DownloadedDate = DateTime.Now.ToString("MM/dd/yyyy");
						DownloadHistoryService.DownloadHistory_Insert(history);
						Response.Redirect(file.Rows[0]["WebContentLink"].ToString(), false);
					}
					else
					{
						WebMsgBox.Show("Bạn chỉ có thể tải miễn phí 2 lần/ngày");
					}
				}
				else
				{
					Response.Redirect("/thanh-vien/dang-nhap", false);
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}

		//protected void btnBuyNow_Click(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];
		//		string BillId = string.Empty;
		//		if (cookie == null || cookie.Value == null)
		//		{
		//			cookie = new HttpCookie(Consts.GUID_SHOPPING_CART);
		//			cookie.Value = Guid.NewGuid().ToString();
		//			cookie.Expires = DateTime.Now.AddDays(6);
		//			HttpContext.Current.Response.SetCookie(cookie);
		//		}
		//		string quantity = "1";
		//		if (!string.IsNullOrEmpty(txtQuantity.Text.Trim()))
		//		{
		//			quantity = txtQuantity.Text.Trim();
		//		}
		//		OrdersService.Orders_Add(StringClass.SqlInjection(id), StringClass.SqlInjection(cookie.Value), quantity);
		//		Response.Redirect("/gio-hang", false);
		//	}
		//	catch (Exception ex)
		//	{
		//		MailSender.SendMail("", "", "Error System", ex.Message + "\n" +ex.StackTrace);
		//	}
		//}
	}
}