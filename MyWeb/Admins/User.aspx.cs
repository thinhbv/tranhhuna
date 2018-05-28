using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Admins
{
    public partial class User : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
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
            grdUser.DataSource = UserService.User_GetByAll();
            grdUser.DataBind();
            if (grdUser.PageCount <= 1)
            {
                grdUser.PagerStyle.Visible = false;
            }
        }

        protected void grdUser_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdUser.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdUser_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdUser.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdUser_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    DataTable dt = new DataTable();
                    dt = UserService.User_GetById(Id);
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtUsername.Text = dt.Rows[0]["UserName"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    chkAdmin.Checked = dt.Rows[0]["Admin"].ToString() == "1" || dt.Rows[0]["Admin"].ToString() == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Delete":
                    UserService.User_Delete(strCA);
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
            for (int i = 0; i < grdUser.Items.Count; i++)
            {
                item = grdUser.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        UserService.User_Delete(strId);
                    }
                }
            }
            grdUser.CurrentPageIndex = 0;
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
                Data.User obj = new Data.User();
                obj.Id = Id;
                obj.Name = txtName.Text;
                obj.UserName = txtUsername.Text;
                obj.Password = txtPassword.Text;
                obj.Email = txtEmail.Text;
                obj.Phone = txtPhone.Text;
                obj.Date = DateTimeClass.ConvertDateTime(DateTime.Now.ToString(), "MM/dd/yy hh:mm:ss");
                obj.Admin = chkAdmin.Checked ? "1" : "0";
                obj.Active = "0";
                if (Insert == true)
                {
                    UserService.User_Insert(obj);
                }
                else
                {
                    UserService.User_Update(obj);
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