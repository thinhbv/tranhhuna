using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;

namespace MyWeb.Admins
{
	public partial class UploadFiles : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		DataTable dt = new DataTable();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				BindGrid();
			}
		}

		private void BindGrid()
		{
			grdUploadFiles.DataSource = FilesUploadService.FilesUpload_GetByTop("","","Id DESC");
			grdUploadFiles.DataBind();
			if (grdUploadFiles.PageCount <= 1)
			{
				grdUploadFiles.PagerStyle.Visible = false;
			}
			else
			{
				grdUploadFiles.PagerStyle.Visible = true;
			}
		}

		protected void grdUploadFiles_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdUploadFiles.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdUploadFiles_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdUploadFiles.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdUploadFiles_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					dt = FilesUploadService.FilesUpload_GetByTop("1", "Id=" + Id, "");

					txtName.Text = dt.Rows[0]["Name"].ToString();
					txtImage.Text = dt.Rows[0]["ThumbnailLink"].ToString();
					imgImage.ImageUrl = dt.Rows[0]["ThumbnailLink"].ToString().Length > 0 ? dt.Rows[0]["ThumbnailLink"].ToString() : "";
					chkActive.Checked = dt.Rows[0]["Active"].ToString() == "1" || dt.Rows[0]["Active"].ToString() == "True";
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update [FilesUpload] set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					FilesUploadService.FilesUpload_Delete(strCA);
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
			for (int i = 0; i < grdUploadFiles.Items.Count; i++)
			{
				item = grdUploadFiles.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						FilesUploadService.FilesUpload_Delete(strId);
					}
				}
			}
			grdUploadFiles.CurrentPageIndex = 0;
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
				Data.FilesUpload obj = new Data.FilesUpload();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.ThumbnailLink = txtImage.Text;
				obj.IconLink = "";
				obj.WebContentLink = "";
				obj.Active = chkActive.Checked ? "1" : "0";
				if (Insert == true)
				{
					FilesUploadService.FilesUpload_Insert(obj);
				}
				else
				{
					FilesUploadService.FilesUpload_Update(obj);
				}
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
				Insert = false;
			}
		}

		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			BindGrid();
			Insert = false;
		}
	}
}