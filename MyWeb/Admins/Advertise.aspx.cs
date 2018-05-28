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
    public partial class Advertise : System.Web.UI.Page
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
                NumberClass.OnlyInputNumber(txtOrd);
                BindGrid();
            }
        }

        private void BindGrid()
        {
            grdAdvertise.DataSource = AdvertiseService.Advertise_GetByAll();
            grdAdvertise.DataBind();
            if (grdAdvertise.PageCount <= 1)
            {
                grdAdvertise.PagerStyle.Visible = false;
            }
            else
            {
                grdAdvertise.PagerStyle.Visible = true;
            }
        }

        protected void grdAdvertise_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdAdvertise.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdAdvertise_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdAdvertise.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdAdvertise_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    dt = AdvertiseService.Advertise_GetById(Id);
                    //LoadDropDownListPage();
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtImage.Text = dt.Rows[0]["Image"].ToString();
                    imgImage.ImageUrl = dt.Rows[0]["Image"].ToString().Length > 0 ? dt.Rows[0]["Image"].ToString() : "";
                    txtWidth.Text = dt.Rows[0]["Width"].ToString();
                    txtHeight.Text = dt.Rows[0]["Height"].ToString();
                    txtLink.Text = dt.Rows[0]["Link"].ToString();
                    PageHelper.LoadDropDownListTarget(ddlTarget);
                    ddlTarget.SelectedValue = dt.Rows[0]["Target"].ToString();
                    PageHelper.LoadDropDownListPosition(ddlPosition);
                    ddlPosition.SelectedValue = dt.Rows[0]["Position"].ToString();
                    txtOrd.Text = dt.Rows[0]["Ord"].ToString();
                    chkActive.Checked = dt.Rows[0]["Active"].ToString() == "1" || dt.Rows[0]["Active"].ToString() == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [Advertise] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    AdvertiseService.Advertise_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            //LoadDropDownListPage();
            PageHelper.LoadDropDownListTarget(ddlTarget);
            PageHelper.LoadDropDownListPosition(ddlPosition);
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdAdvertise.Items.Count; i++)
            {
                item = grdAdvertise.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        AdvertiseService.Advertise_Delete(strId);
                    }
                }
            }
            grdAdvertise.CurrentPageIndex = 0;
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
                Data.Advertise obj = new Data.Advertise();
                obj.Id = Id;
                obj.Name = txtName.Text;
                obj.Image = txtImage.Text;
                obj.Width = txtWidth.Text;
                obj.Height = txtHeight.Text;
                obj.Link = txtLink.Text;
                obj.Target = ddlTarget.SelectedValue;
                obj.Content = "";
                obj.Position = ddlPosition.SelectedValue;
                obj.PageId = "0";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.Click = "0";
                if (Insert == true)
                {
                    AdvertiseService.Advertise_Insert(obj);
                }
                else
                {
                    AdvertiseService.Advertise_Update(obj);
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