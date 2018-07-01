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
    public partial class Images : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                NumberClass.OnlyInputNumber(txtOrd);
                BindGrid();
                LoadDropDownListGroupImage();
                //PageHelper.LoadDropProPriority(ddlPriority);
            }
        }

        private void BindGrid()
        {
            if (drlnhom.SelectedValue == "0")
            {
                grdImages.DataSource = ImagesService.Images_GetByAll();
                grdImages.DataBind();
                if (grdImages.PageCount <= 1)
                {
                    grdImages.PagerStyle.Visible = false;
                }
                else
                {
                    grdImages.PagerStyle.Visible = true;
                }
            }
            else
            {
                String level = String.Empty;
                List<Data.GroupImages> listG = GroupImagesService.GroupImages_GetById(drlnhom.SelectedValue);
                if (listG.Count > 0)
                {
                    level = listG[0].Level;
                }
                grdImages.DataSource = ImagesService.Images_GetByTop("", "GroupId IN (Select Id From GroupImages WHERE left([Level],len('" + level + "'))='" + level + "')", "Ord");
                grdImages.DataBind();
                if (grdImages.PageCount <= 1)
                {
                    grdImages.PagerStyle.Visible = false;
                }
                else
                {
                    grdImages.PagerStyle.Visible = true;
                }
            }
        }

        protected void LoadDropDownListGroupImage()
        {
            ddlGroupImage.Items.Clear();
            drlnhom.Items.Clear();
            ddlGroupImage.Items.Add(new ListItem("--Chọn nhóm hình ảnh--", ""));
            drlnhom.Items.Add(new ListItem("--Chọn nhóm hình ảnh--", "0"));
            List<Data.GroupImages> listImg = new List<Data.GroupImages>();
            listImg = GroupImagesService.GroupImages_GetByTop("", "Active = 1", "");
            for (int i = 0; i < listImg.Count; i++)
            {
                ddlGroupImage.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(listImg[i].Name, listImg[i].Level), listImg[i].Id));
                drlnhom.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(listImg[i].Name, listImg[i].Level), listImg[i].Id));
            }
            ddlGroupImage.DataBind();
            drlnhom.DataBind();
        }



        protected void grdImages_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdImages.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdImages_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdImages.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdImages_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.Images> listE = ImagesService.Images_GetById(Id);
                    ddlGroupImage.SelectedValue = listE[0].GroupId;
                    LoadDropDownListGroupImage();
                    //PageHelper.LoadDropProPriority(ddlPriority);
                    txtImage.Text = listE[0].Image;
                    imgImage.ImageUrl = listE[0].Image.Length > 0 ? listE[0].Image : "";
                    //ddlPriority.SelectedValue = listE[0].Priority;
                    txtOrd.Text = listE[0].Ord;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [Images] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    ImagesService.Images_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            LoadDropDownListGroupImage();
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdImages.Items.Count; i++)
            {
                item = grdImages.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ImagesService.Images_Delete(strId);
                    }
                }
            }
            grdImages.CurrentPageIndex = 0;
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
                Data.Images obj = new Data.Images();
                obj.Id = Id;
				obj.Thumbnail = string.Empty;
                obj.Image = txtImage.Text;
                obj.GroupId = ddlGroupImage.SelectedValue;
                obj.Priority = "0";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Active = chkActive.Checked ? "1" : "0";
                if (Insert == true)
                {
                    ImagesService.Images_Insert(obj);
                }
                else
                {
                    ImagesService.Images_Update(obj);
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
            Insert = false;
        }

        protected void drlChuyenmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdImages.CurrentPageIndex = 0;
            BindGrid();
        }
    }
}