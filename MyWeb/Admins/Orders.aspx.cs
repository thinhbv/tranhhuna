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

namespace MyWeb.Admins
{
	public partial class Orders : System.Web.UI.Page
	{
		static string Id = "";
		SqlDataProvider sql = new SqlDataProvider();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				PageHelper.LoadDropDownListStatusCart(ddlStatus);
				BindGrid();
			}
		}

		private void BindGrid()
		{
			if (ddlStatus.SelectedValue == "")
			{
				grdOrders.DataSource = OrdersService.Orders_GetByTop("", "", "");
				grdOrders.DataBind();
				if (grdOrders.PageCount <= 1)
				{
					grdOrders.PagerStyle.Visible = false;
				}
				else
				{
					grdOrders.PagerStyle.Visible = true;
				}
			}
			else
			{
				DataTable dtG = OrdersService.Orders_GetByTop("", "Status=" + ddlStatus.SelectedValue, "");
				grdOrders.DataSource = dtG;
				grdOrders.DataBind();
				if (grdOrders.PageCount <= 1)
				{
					grdOrders.PagerStyle.Visible = false;
				}
				else
				{
					grdOrders.PagerStyle.Visible = true;
				}
			}
		}

		protected void grdOrders_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			ListItemType itemType = e.Item.ItemType;
			if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
			{
				if (itemType == ListItemType.Header)
				{
					object checkBox = e.Item.FindControl("chkSelectAll");
					if ((checkBox != null))
					{
						((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
					}
				}
				else
				{
					string tableRowId = grdOrders.ClientID + "_row" + e.Item.ItemIndex.ToString();
					e.Item.Attributes.Add("id", tableRowId);
					object checkBox = e.Item.FindControl("chkSelect");
					if ((checkBox != null))
					{
						e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
						e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex.ToString() + ")");
						((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex.ToString() + ")");
					}
				}
			}
		}

		protected void grdOrders_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdOrders.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdOrders_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			DataTable dt = new DataTable();
			dt = OrdersService.Orders_GetById(strCA);
			switch (e.CommandName)
			{
				case "Edit":
					Id = strCA;
					DataTable dtOrderDetail = OrderDetailService.OrderDetail_GetByTop("", "OrderId=" + Id, "");
					grdProducts.DataSource = dtOrderDetail;
					grdProducts.DataBind();
					lblName.Text = dt.Rows[0]["Name"].ToString();
					lblTel.Text = dt.Rows[0]["Tel"].ToString();
					lblEmail.Text = dt.Rows[0]["Email"].ToString();
					lblAddress.Text = dt.Rows[0]["Address"].ToString();
					lblDetail.Text = dt.Rows[0]["Detail"].ToString();
					PageHelper.LoadDropDownListStatusCart(drlStatus);
					txtDate.Text = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy HH:mm:ss");
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
			}
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				sql.UpdateStatusCart(drlStatus.SelectedValue, Id);
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
			}
		}

		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			BindGrid();
		}

		protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			grdOrders.CurrentPageIndex = 0;
			BindGrid();
		}

		protected string ShowNameProduct(string productId)
		{
			DataTable dtPro = ProductService.Product_GetById(productId);
			if (dtPro.Rows.Count > 0)
			{
				return dtPro.Rows[0]["Name"].ToString();
			}
			return string.Empty;
		}
	}
}