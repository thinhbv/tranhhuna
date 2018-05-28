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
    public partial class Contact : System.Web.UI.Page
    {
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
            grdContact.DataSource = ContactService.Contact_GetByAll();
            grdContact.DataBind();
            if (grdContact.PageCount <= 1)
            {
                grdContact.PagerStyle.Visible = false;
            }
        }

        protected void grdContact_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdContact.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdContact_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdContact.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdContact_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Delete":
                    ContactService.Contact_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdContact.Items.Count; i++)
            {
                item = grdContact.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ContactService.Contact_Delete(strId);
                    }
                }
            }
            grdContact.CurrentPageIndex = 0;
            BindGrid();
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}