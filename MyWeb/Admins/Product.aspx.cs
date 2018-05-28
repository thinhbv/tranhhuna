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
    public partial class Product : System.Web.UI.Page
    {
        private static string Id = "";
        private static bool Insert = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                NumberClass.OnlyInputNumber(txtOrd);
                LoadDropDownListGroupImage();
                BindGrid();
            }
        }

        protected void LoadDropDownListGroupImage()
        {
            ddlGroupProduct.Items.Clear();
            drlnhom.Items.Clear();
            ddlGroupProduct.Items.Add(new ListItem("--Chọn nhóm sản phẩm--", ""));
            drlnhom.Items.Add(new ListItem("--Chọn nhóm sản phẩm--", ""));
            List<Data.GroupProduct> listImg = new List<Data.GroupProduct>();
            listImg = GroupProductService.GroupProduct_GetByTop("", "Active = 1", "");
            for (int i = 0; i < listImg.Count; i++)
            {
                ddlGroupProduct.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(listImg[i].Name, listImg[i].Level), listImg[i].Id));
                drlnhom.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(listImg[i].Name, listImg[i].Level), listImg[i].Id));
            }
            ddlGroupProduct.DataBind();
            drlnhom.DataBind();
        }

        private void BindGrid()
        {
            if (drlnhom.SelectedValue == "")
            {
                grdProduct.DataSource = ProductService.Product_GetByAll();
                grdProduct.DataBind();
                if (grdProduct.PageCount <= 1)
                {
                    grdProduct.PagerStyle.Visible = false;
                }
                else
                {
                    grdProduct.PagerStyle.Visible = true;
                }
            }
            else
            {
                String level = String.Empty;
                List<Data.GroupProduct> listG = GroupProductService.GroupProduct_GetById(drlnhom.SelectedValue);
                if (listG.Count > 0)
                {
                    level = listG[0].Level;
                }
                grdProduct.DataSource = ProductService.Product_GetByTop("", "GroupId IN (Select Id From GroupProduct WHERE left(Level,len('" + level + "'))='" + level + "')", "Ord");
                grdProduct.DataBind();
                if (grdProduct.PageCount <= 1)
                {
                    grdProduct.PagerStyle.Visible = false;
                }
                else
                {
                    grdProduct.PagerStyle.Visible = true;
                }
            }
        }

        protected void grdProduct_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdProduct.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdProduct_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdProduct.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdProduct_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            SqlDataProvider sql = new SqlDataProvider();
            string strPri = "";
            List<Data.Product> listE = ProductService.Product_GetById(strCA);
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    LoadDropDownListGroupImage();
                    ddlGroupProduct.SelectedValue = listE[0].GroupId;
                    txtName.Text = listE[0].Name;
                    txtImage1.Text = listE[0].Image1;
                    imgImage1.ImageUrl = listE[0].Image1.Length > 0 ? listE[0].Image1 : "";
                    txtImage2.Text = listE[0].Image2;
                    imgImage2.ImageUrl = listE[0].Image2.Length > 0 ? listE[0].Image2 : "";
                    txtImage3.Text = listE[0].Image3;
                    imgImage3.ImageUrl = listE[0].Image3.Length > 0 ? listE[0].Image3 : "";
                    txtImage4.Text = listE[0].Image4;
                    imgImage4.ImageUrl = listE[0].Image4.Length > 0 ? listE[0].Image4 : "";
                    txtImage5.Text = listE[0].Image5;
                    imgImage5.ImageUrl = listE[0].Image5.Length > 0 ? listE[0].Image5 : "";
                    txtContent.Text = listE[0].Content;
                    fckDetail.Value = listE[0].Detail;
					txtPricePro.Text = StringClass.ConvertPrice(listE[0].Price);
                    chkPopular.Checked = listE[0].IsPopular == "1" || listE[0].IsPopular == "True";
                    chkHot.Checked = listE[0].IsHot == "1" || listE[0].IsHot == "True";
                    chkNew.Checked = listE[0].IsNew == "1" || listE[0].IsNew == "True";
                    chkSpecial.Checked = listE[0].IsSpecial == "1" || listE[0].IsSpecial == "True";
                    txtOrd.Text = listE[0].Ord;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [Product] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    ProductService.Product_Delete(strCA);
                    BindGrid();
                    break;
                case "IsPopular":
                    strPri = listE[0].IsPopular == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [Product] set [IsPopular]=" + strPri + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "IsHot":
                    strPri = listE[0].IsHot == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [Product] set [IsHot]=" + strPri + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "IsNew":
                    strPri = listE[0].IsNew == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [Product] set [IsNew]=" + strPri + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "IsSpecial":
                    strPri = listE[0].IsSpecial == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [Product] set [IsSpecial]=" + strPri + "  Where Id='" + strCA + "'");
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
            for (int i = 0; i < grdProduct.Items.Count; i++)
            {
                item = grdProduct.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ProductService.Product_Delete(strId);
                    }
                }
            }
            grdProduct.CurrentPageIndex = 0;
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
                Data.Product obj = new Data.Product();
                obj.Id = Id;
                obj.Name = txtName.Text;
                obj.Image1 = txtImage1.Text;
                obj.Image2 = txtImage2.Text;
                obj.Image3 = txtImage3.Text;
                obj.Image4 = txtImage4.Text;
                obj.Image5 = txtImage5.Text;
				obj.Content = txtContent.Text;
                obj.Detail = fckDetail.Value;
                obj.GroupId = ddlGroupProduct.SelectedValue;
				obj.Price = txtPricePro.Text;
				obj.GroupName = ddlGroupProduct.SelectedItem.Text;
                obj.IsPopular = chkPopular.Checked ? "1" : "0";
                obj.IsHot = chkHot.Checked ? "1" : "0";
                obj.IsNew = chkNew.Checked ? "1" : "0";
                obj.IsSpecial = chkSpecial.Checked ? "1" : "0";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Active = chkActive.Checked ? "1" : "0";
                if (Insert == true)
                {
                    ProductService.Product_Insert(obj);
                }
                else
                {
                    ProductService.Product_Update(obj);
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
            grdProduct.CurrentPageIndex = 0;
            BindGrid();
        }
    }
}