using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admins
{
    public partial class GroupNews : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        static string Level = "";
        DataTable dt = new DataTable();
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
            grdGroupNews.DataSource = GroupNewsService.GroupNews_GetByAll();
            grdGroupNews.DataBind();
            if (grdGroupNews.PageCount <= 1)
            {
                grdGroupNews.PagerStyle.Visible = false;
            }
            else
            {
                grdGroupNews.PagerStyle.Visible = true;
            }
        }

        protected void grdGroupNews_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdGroupNews.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdGroupNews_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdGroupNews.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdGroupNews_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
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
                    dt = GroupNewsService.GroupNews_GetById(Id);
                    Level = dt.Rows[0]["Level"].ToString().Substring(0, dt.Rows[0]["Level"].ToString().Length - 5);
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtImage.Text = dt.Rows[0]["Image"].ToString();
                    imgImage.ImageUrl = dt.Rows[0]["Image"].ToString().Length > 0 ? dt.Rows[0]["Image"].ToString() : "";
                    txtOrd.Text = dt.Rows[0]["Ord"].ToString();
                    chkActive.Checked = dt.Rows[0]["Active"].ToString() == "1" || dt.Rows[0]["Active"].ToString() == "True";
                    chkIndex.Checked = dt.Rows[0]["Index"].ToString() == "1" || dt.Rows[0]["Index"].ToString() == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [GroupNews] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    sql.ExecuteNonQuery("Delete News where GroupNewsId='" + strCA + "'");
                    GroupNewsService.GroupNews_Delete(strCA);
                    BindGrid();
                    break;
                case "Index":
                    string strPri = "";
                    strPri = dt.Rows[0]["Index"].ToString() == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [GroupNews] set [Index]=" + strPri + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
			ControlClass.ResetControlValues(this);
			SqlDataProvider sql = new SqlDataProvider();
			txtOrd.Text = (Int16.Parse(sql.GetMaxOrd("GroupNews", Level)) + 1).ToString();
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdGroupNews.Items.Count; i++)
            {
                item = grdGroupNews.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        SqlDataProvider sql = new SqlDataProvider();
                        sql.ExecuteNonQuery("Delete News where GroupNewsId='" + strId + "'");
                        GroupNewsService.GroupNews_Delete(strId);
                    }
                }
            }
            grdGroupNews.CurrentPageIndex = 0;
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
                Data.GroupNews obj = new Data.GroupNews();
                obj.Id = Id;
                obj.Name = txtName.Text;
                obj.Image = txtImage.Text;
                obj.Level = Level + "00000";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Description = "";
                obj.Keyword = "";
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.Index = chkIndex.Checked ? "1" : "0";
                if (Insert == true)
                {
                    GroupNewsService.GroupNews_Insert(obj);
                }
                else
                {
                    GroupNewsService.GroupNews_Update(obj);
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
            BindGrid();
            Level = "";
            Insert = false;
        }
    }
}