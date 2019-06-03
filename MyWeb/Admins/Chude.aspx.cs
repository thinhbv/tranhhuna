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
	public partial class Chude : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
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
			grdChude.DataSource = ChudeService.Chude_GetByAll();
			grdChude.DataBind();
			if (grdChude.PageCount <= 1)
			{
				grdChude.PagerStyle.Visible = false;
			}
			else
			{
				grdChude.PagerStyle.Visible = true;
			}
		}

		protected void grdChude_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdChude.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdChude_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdChude.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdChude_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "AddSub":
					Level = strCA;
					AddButton_Click(source, e);
					break;
				case "Edit":
					Insert = false;
					Id = strCA;
					DataTable listE = ChudeService.Chude_GetById(Id);
					Level = listE.Rows[0]["Level"].ToString();
					txtName.Text = listE.Rows[0]["Name"].ToString();
					txtOrd.Text = listE.Rows[0]["Ord"].ToString();
					chkActive.Checked = listE.Rows[0]["Active"].ToString() == "1" || listE.Rows[0]["Active"].ToString() == "True";
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update [Chude] set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;

				case "Delete":
					ChudeService.Chude_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			ControlClass.ResetControlValues(this);
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdChude.Items.Count; i++)
			{
				item = grdChude.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						ChudeService.Chude_Delete(strId);
						SqlDataProvider sql = new SqlDataProvider();
						sql.ExecuteNonQuery("Delete From [Images] where GroupId='" + strId + "'");
					}
				}
			}
			grdChude.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				Data.Chude obj = new Data.Chude();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
				obj.Active = chkActive.Checked ? "1" : "0";
				if (Insert == true)
				{
					ChudeService.Chude_Insert(obj);
				}
				else
				{
					ChudeService.Chude_Update(obj);
				}
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
				Level = "";
				Insert = false;
			}
		}

		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			Level = "";
			Insert = false;
		}
	}
}