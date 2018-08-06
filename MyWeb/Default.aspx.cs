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

namespace MyWeb
{
    public partial class Default : System.Web.UI.Page
    {
		protected string sAboutName = string.Empty;
		protected string sContents = string.Empty;
		protected string sUrl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{

				if (!IsPostBack)
				{
					DataTable dtConfig = ConfigService.Config_GetByTop("1", "", "");
					if (dtConfig.Rows.Count > 0)
					{
						Page.Title = dtConfig.Rows[0]["Title"].ToString();
						Page.MetaDescription = dtConfig.Rows[0]["Description"].ToString();
						Page.MetaKeywords = dtConfig.Rows[0]["Keyword"].ToString();
					}

					//Giới thiệu về chúng tôi
					DataTable dt = PageService.Page_GetByTop("1", "Name like N'%giới thiệu%'", "");
					if (dt.Rows.Count > 0)
					{
						sAboutName = dt.Rows[0]["Name"].ToString();
						sContents = dt.Rows[0]["Description"].ToString();
						sUrl = dt.Rows[0]["Link"].ToString();
					}
					dt.Clear();
					HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];

					DataTable dtGroup = GroupProductService.GroupProduct_GetByTop("", "Active=1 And Position=1", "Level, Ord");
					DataTable dtTop = dtGroup.AsEnumerable().Take(2).CopyToDataTable();

					for (int i = 0; i < dtGroup.Rows.Count; i++)
					{
						if (i<2)
						{
							dtGroup.Rows[i].Delete();
						}
					}
					dtGroup.AcceptChanges();
					rptGroup.DataSource = StringClass.ModifyDataGroupProduct(dtTop);
					rptGroup.DataBind();
					rptGroup01.DataSource = StringClass.ModifyDataGroupProduct(dtGroup);
					rptGroup01.DataBind();
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "","Error System", ex.Message + "\n" +ex.StackTrace);
			}
        }

		protected void rptGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
			{
				string id = DataBinder.Eval(item.DataItem, "Id").ToString();
				DataTable dtPro = ProductService.Product_GetByTop("", "Active = 1 AND IsPopular=1 AND GroupId=" + id, "Ord");
				if (dtPro.Rows.Count == 0)
				{
					item.Visible = false;
				}
				Repeater rptPro = (Repeater)item.FindControl("rptPro");
				if (rptPro != null)
				{
					HttpCookie cookie = Request.Cookies[Consts.GUID_SHOPPING_CART];
					rptPro.DataSource = StringClass.ModifyDataProduct(dtPro, cookie);
					rptPro.DataBind();
				}
			}
		}
    }
}