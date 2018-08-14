using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admins
{
	public partial class GroupProduct : System.Web.UI.Page
    {
        private static string Id = "";
        private static bool Insert = false;
		static string Level = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				NumberClass.OnlyInputNumber(txtOrd);
				BindGrid();
			}
		}

		private void BindGrid()
		{
			grdGroupProduct.DataSource = GroupProductService.GroupProduct_GetByAll();
			grdGroupProduct.DataBind();
			if (grdGroupProduct.PageCount <= 1)
			{
				grdGroupProduct.PagerStyle.Visible = false;
			}
			else
			{
				grdGroupProduct.PagerStyle.Visible = true;
			}
		}

		protected void grdGroupProduct_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdGroupProduct.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdGroupProduct_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdGroupProduct.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdGroupProduct_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			string strA = "";
			string str = e.Item.Cells[2].Text;
			SqlDataProvider sql = new SqlDataProvider();
			switch (e.CommandName)
			{
				case "AddSub":
					Level = strCA;
					AddButton_Click(source, e);
					break;
				case "Edit":
					Insert = false;
					Id = strCA;
					List<Data.GroupProduct> listE = GroupProductService.GroupProduct_GetById(Id);
					Level = listE[0].Level.Substring(0, listE[0].Level.Length - 5);
					txtName.Text = listE[0].Name;
					chkPosition.Checked = listE[0].Position == "1" || listE[0].Position == "True";
					txtItems.Text = listE[0].Items;
					txtOrd.Text = listE[0].Ord;
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					strA = str == "1" ? "0" : "1";
					sql.ExecuteNonQuery("Update [GroupProduct] set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					GroupProductService.GroupProduct_Delete(strCA);
					BindGrid();
					break;
				case "cmdPosition":
					str = e.Item.Cells[3].Text;
					strA = str == "True" ? "False" : "True";
					sql.ExecuteNonQuery("Update [GroupProduct] set Position='" + strA + "'  Where Id='" + strCA + "'");
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			ControlClass.ResetControlValues(this);
			SqlDataProvider sql = new SqlDataProvider();
			txtOrd.Text = (Int16.Parse(sql.GetMaxOrd("GroupProduct", Level)) + 1).ToString();
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdGroupProduct.Items.Count; i++)
			{
				item = grdGroupProduct.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						GroupProductService.GroupProduct_Delete(strId);
					}
				}
			}
			grdGroupProduct.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
				Data.GroupProduct obj = new Data.GroupProduct();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.Level = Level + "00000";
				obj.Position = chkPosition.Checked ? "1" : "0";
				obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
				obj.Active = chkActive.Checked ? "1" : "0";
				obj.Items = txtItems.Text.Trim();
				if (Insert == true){
					GroupProductService.GroupProduct_Insert(obj);
				}
				else{
					GroupProductService.GroupProduct_Update(obj);
				}
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
				Level= "";
				Insert = false;
			}
		}

		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			Level= "";
			Insert = false;
		}
	}
}