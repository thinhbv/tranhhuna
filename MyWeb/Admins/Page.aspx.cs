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
    public partial class Page : System.Web.UI.Page
    {
        static bool Insert = false;
        static string Level = "";
        SqlDataProvider sql = new SqlDataProvider();
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

        private void LoadDropDownListPageLinkType()
        {
            string[] myArr = new string[] { "1,Nhập liên kết", "2,Liên kết module" };
            Common.PageHelper.LoadDropDownList(ddlLinkType, myArr, true);
        }

        private void LoadDropDownListPageLink()
        {
            ddlLink.Items.Clear();
            ddlLink.Items.Add(new ListItem("Trang chủ", "/"));
            DataTable dt = new DataTable();
            dt = GroupNewsService.GroupNews_GetByTop("", "Active=1", "Level, Ord");
			ddlLink.Items.Add(new ListItem("Tin tức", "#"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlLink.Items.Add(new ListItem(StringClass.ShowNameLevel(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Level"].ToString() + "00000"), PageHelper.GeneralGroupUrl(Consts.CON_TIN_TUC, dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Name"].ToString())));
            }
            List<Data.GroupImages> listG = GroupImagesService.GroupImages_GetByTop("", "Active=1", "Level, Ord");
			ddlLink.Items.Add(new ListItem("Hình ảnh", "#"));
            if (listG.Count > 0)
            {
                for (int i = 0; i < listG.Count; i++)
                {
					ddlLink.Items.Add(new ListItem(StringClass.ShowNameLevel(listG[i].Name, listG[i].Level + "00000"), "/Thu-vien-anh/" + listG[i].Id + "/" + StringClass.NameToTag(listG[i].Name)));
                }
            }
            DataTable listGProduct = GroupProductService.GroupProduct_GetByTop("", "Active=1", "Level, Ord");
			ddlLink.Items.Add(new ListItem("Sản phẩm", "#"));
            if (listGProduct.Rows.Count > 0)
            {
                for (int i = 0; i < listGProduct.Rows.Count; i++)
                {
					ddlLink.Items.Add(new ListItem(StringClass.ShowNameLevel(listGProduct.Rows[i]["Name"].ToString(), listGProduct.Rows[i]["Level"].ToString() + "00000"), PageHelper.GeneralGroupUrl(Consts.CON_SAN_PHAM, listGProduct.Rows[i]["Id"].ToString(), listGProduct.Rows[i]["Name"].ToString())));
                }
            }
			DataTable listChude = ChudeService.Chude_GetByTop("", "Active=1", "Ord");
			ddlLink.Items.Add(new ListItem("Chủ đề", "#"));
			if (listChude.Rows.Count > 0)
			{
				for (int i = 0; i < listChude.Rows.Count; i++)
				{
					ddlLink.Items.Add(new ListItem(StringClass.ShowNameLevel(listChude.Rows[i]["Name"].ToString(), "0000000000"), "/chu-de/chu-de-" + listChude.Rows[i]["Id"].ToString() + "/" + StringClass.NameToTag(listChude.Rows[i]["Name"].ToString())));
				}
			}
            ddlLink.Items.Add(new ListItem("Liên hệ", "/lien-he"));
            ddlLink.DataBind();
        }

        private void BindGrid()
        {
            grdPage.DataSource = PageService.Page_GetByAll();
            grdPage.DataBind();
            if (grdPage.PageCount <= 1)
            {
                grdPage.PagerStyle.Visible = false;
            }
        }

        protected void grdPage_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdPage.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdPage_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdPage.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdPage_ItemCommand(object source, DataGridCommandEventArgs e)
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
                    txtId.Value = strCA;
                    DataTable dt = new DataTable();
                    dt = PageService.Page_GetById(strCA);
                    Level = dt.Rows[0]["Level"].ToString().Substring(0, dt.Rows[0]["Level"].ToString().Length - 5);
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtImage.Text = dt.Rows[0]["Image"].ToString();
                    imgImage.ImageUrl = dt.Rows[0]["Image"].ToString().Length > 0 ? dt.Rows[0]["Image"].ToString() : "";
                    fckDetail.Value = dt.Rows[0]["Detail"].ToString();
                    txtContent.Text = dt.Rows[0]["Description"].ToString();
                    //txtKeyword.Text = dt.Rows[0]["Keyword"].ToString();
                    PageHelper.LoadDropDownListPagePosition(ddlPosition);
                    PageHelper.LoadDropDownListTarget(ddlTarget);
                    PageHelper.LoadDropDownListPageType(ddlType);
                    LoadDropDownListPageLinkType();
                    LoadDropDownListPageLink();
                    ddlType.Text = dt.Rows[0]["Type"].ToString();
                    txtLink.Text = dt.Rows[0]["Link"].ToString();
                    try
                    {
                        ddlLink.Text = dt.Rows[0]["Link"].ToString();
                        ddlLinkType.Text = "2";
                    }
                    catch
                    {
                        ddlLinkType.Text = "1";
                    }
                    ddlTarget.Text = dt.Rows[0]["Target"].ToString();
                    ddlPosition.Text = dt.Rows[0]["Position"].ToString();
                    txtOrd.Text = dt.Rows[0]["Ord"].ToString();
                    chkActive.Checked = dt.Rows[0]["Active"].ToString() == "1" || dt.Rows[0]["Active"].ToString() == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update Page set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    PageService.Page_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            PageHelper.LoadDropDownListPagePosition(ddlPosition);
            PageHelper.LoadDropDownListTarget(ddlTarget);
            PageHelper.LoadDropDownListPageType(ddlType);
            LoadDropDownListPageLinkType();
            LoadDropDownListPageLink();

			SqlDataProvider sql = new SqlDataProvider();
			txtOrd.Text = (Int16.Parse(sql.GetMaxOrd("Page", Level)) + 1).ToString();
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdPage.Items.Count; i++)
            {
                item = grdPage.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        PageService.Page_Delete(strId);
                    }
                }
            }
            grdPage.CurrentPageIndex = 0;
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
                string Link = "";
                string Id = txtId.Value;
                Data.Page obj = new Data.Page();
                obj.Id = Id;
                obj.Name = txtName.Text;
                obj.Image = txtImage.Text;
                obj.Detail = fckDetail.Value;
                obj.Level = Level + "00000";
                obj.Description = txtContent.Text;
                obj.Keyword = "";
                obj.Type = ddlType.SelectedValue;
                obj.Link = txtLink.Text;
                obj.Target = ddlTarget.SelectedValue;
                obj.Position = ddlPosition.SelectedValue;
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Active = chkActive.Checked ? "1" : "0";
                if (Insert == true)
                {
                    PageService.Page_Insert(obj);
                    Id = sql.MaxId("Page", "Id");
                }
                else
                {
                    PageService.Page_Update(obj);
                }
                if (ddlType.SelectedValue == "2")
                {
                    DataTable dt = new DataTable();
                    dt = PageService.Page_GetById(Id);
                    Link = "/trang-tin/" + StringClass.NameToTag(dt.Rows[0]["Name"].ToString()) + "-" + Id;
                    sql.ExecuteNonQuery("Update Page set Link='" + Link + "'  Where Id='" + Id + "'");
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

        protected void imgUpdateOrd_Click(object sender, ImageClickEventArgs e)
        {
            TextBox txt;
            try
            {
                foreach (DataGridItem item in this.grdPage.Items)
                {
                    txt = (TextBox)item.FindControl("txtOrd");
                    string strId = item.Cells[1].Text;
                    sql.ExecuteNonQuery("Update Page set Ord='" + txt.Text + "' where Id='" + strId + "'");
                }
                lblThongbao.Text = "";
                BindGrid();
            }
            catch { lblThongbao.Text = "Bạn phải nhập số!"; }
        }
    }
}