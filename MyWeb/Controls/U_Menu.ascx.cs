using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;
using System.Data;
using System.Web.UI.HtmlControls;

namespace MyWeb.Controls
{
    public partial class U_Menu : System.Web.UI.UserControl
	{
		DataTable dtPage = new DataTable();
		protected string keyword = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				try
				{
					if (Request.QueryString["key"] != null)
					{
						keyword = Request.QueryString["key"];
					}
					ShowMenu();
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message + "\n" +ex.StackTrace);
				}
            }
        }

        #region Hiển thị menu chính
        /// <summary>
        /// Hiển thị menu chính
        /// </summary>
        private void ShowMenu()
        {
            dtPage = PageService.Page_GetByTop("", "Active=1 and Position = 2", "Level, Ord");
            if (dtPage.Rows.Count > 0)
            {
				rptParent.DataSource = dtPage.Select("LEN(Level) = 5").CopyToDataTable();
				rptParent.DataBind();
				//int count = 1;
				//int countsub = 1;
				//for (int i = 1; i < dtPage.Rows.Count; i++)
				//{
				//	string rdnNum = string.Empty;
				//	if (dtPage.Rows[i - 1]["Level"].ToString().Length < dtPage.Rows[i]["Level"].ToString().Length)
				//	{
				//		if (dtPage.Rows[i - 1]["Level"].ToString().Length == 5)
				//		{
				//			rdnNum = NumberClass.GeneralRandomNum();
				//			this.ltrmenu.Text += "<li class=\" top-level-menu-li tmmegamenu_item it_" + rdnNum + "\"><a class='it_" + rdnNum + " top-level-menu-li-a tmmegamenu_item' href=\"" + dtPage.Rows[i - 1]["Link"].ToString() + "\" title='" + dtPage.Rows[i - 1]["Name"].ToString() + "'>" + dtPage.Rows[i - 1]["Name"].ToString() + "</a>\n";
				//			this.ltrmenu.Text += "<div class=\"is-megamenu tmmegamenu_item first-level-menu it_" + rdnNum + "\">\n";
				//			this.ltrmenu.Text += "<div id=\"megamenu-row-" + count + "-1\" class=\"megamenu-row row megamenu-row-1\">\n";
                            

				//		}
				//		else if (dtPage.Rows[i - 1]["Level"].ToString().Length == 10)
				//		{
				//			this.ltrmenu.Text += "<div id=\"column-" + count + "-1-" + countsub + "\" class=\"megamenu-col megamenu-col-1-" + countsub + " col-sm-3\">\n";
				//			this.ltrmenu.Text += "<ul class=\"content\">\n";
				//			this.ltrmenu.Text += "<li class=\"category\"><a title='" + dtPage.Rows[i - 1]["Name"].ToString() + "' href=\"" + dtPage.Rows[i - 1]["Link"].ToString() + "\">" + dtPage.Rows[i - 1]["Name"].ToString() + "</a>\n";
				//			this.ltrmenu.Text += "<ul>\n";
				//		}
				//	}
				//	else if (dtPage.Rows[i - 1]["Level"].ToString().Length == dtPage.Rows[i]["Level"].ToString().Length)
				//	{
				//		if (dtPage.Rows[i - 1]["Level"].ToString().Length == 5)
				//		{
				//			rdnNum = NumberClass.GeneralRandomNum();
				//			this.ltrmenu.Text += "<li class=\" top-level-menu-li tmmegamenu_item it_" + rdnNum + "\"><a class='it_" + rdnNum + " top-level-menu-li-a tmmegamenu_item' href=\"" + dtPage.Rows[i - 1]["Link"].ToString() + "\" title='" + dtPage.Rows[i - 1]["Name"].ToString() + "'>" + dtPage.Rows[i - 1]["Name"].ToString() + "</a></li>\n";
				//		}
				//		else if (dtPage.Rows[i - 1]["Level"].ToString().Length == 10)
				//		{
				//			this.ltrmenu.Text += "<div id=\"column-" + count + "-1-" + countsub + "\" class=\"megamenu-col megamenu-col-1-" + countsub + " col-sm-3\">\n";
				//			this.ltrmenu.Text += "<ul class=\"content\">\n";
				//			this.ltrmenu.Text += "<li class=\"category\"><a title='" + dtPage.Rows[i - 1]["Name"].ToString() + "' href=\"" + dtPage.Rows[i - 1]["Link"].ToString() + "\">" + dtPage.Rows[i - 1]["Name"].ToString() + "</a></li>\n";
				//			this.ltrmenu.Text += "</ul></div>\n";
				//		}
				//		else if (dtPage.Rows[i - 1]["Level"].ToString().Length == 15)
				//		{
				//			this.ltrmenu.Text += "<li class=\"category\"><a title='" + dtPage.Rows[i - 1]["Name"].ToString() + "' href=\"" + dtPage.Rows[i - 1]["Link"].ToString() + "\">" + dtPage.Rows[i - 1]["Name"].ToString() + "</a></li>\n";
                            
				//		}
				//	}
				//	else if (dtPage.Rows[i - 1]["Level"].ToString().Length > dtPage.Rows[i]["Level"].ToString().Length)
				//	{
				//		if (dtPage.Rows[i - 1]["Level"].ToString().Length == 15)
				//		{
				//			this.ltrmenu.Text += "<li class=\"category\"><a title='" + dtPage.Rows[i - 1]["Name"].ToString() + "' href=\"" + dtPage.Rows[i - 1]["Link"].ToString() + "\">" + dtPage.Rows[i - 1]["Name"].ToString() + "</a></li>\n";
				//		}
				//		else if (dtPage.Rows[i - 1]["Level"].ToString().Length == 10)
				//		{
				//			this.ltrmenu.Text += "<div id=\"column-" + count + "-1-" + countsub + "\" class=\"megamenu-col megamenu-col-1-" + countsub + " col-sm-3\">\n";
				//			this.ltrmenu.Text += "<ul class=\"content\">\n";
				//			this.ltrmenu.Text += "<li class=\"category\"><a title='" + dtPage.Rows[i - 1]["Name"].ToString() + "' href=\"" + dtPage.Rows[i - 1]["Link"].ToString() + "\">" + dtPage.Rows[i - 1]["Name"].ToString() + "</a></li>\n";
				//			//this.ltrmenu.Text += "</ul></div>\n";
				//		}
				//		this.ltrmenu.Text += Inma(dtPage.Rows[i - 1]["Level"].ToString().Length, dtPage.Rows[i]["Level"].ToString().Length);
				//		if (dtPage.Rows[i]["Level"].ToString().Length == 5)
				//		{
				//			count++;
				//		}
				//		else if (dtPage.Rows[i]["Level"].ToString().Length == 10)
				//		{
				//			countsub++;
				//		}
				//	}
				//}
				////Khi phần tử cuối cùng là con của phần tử trước nó
				//if (dtPage.Rows[dtPage.Rows.Count - 2]["Level"].ToString().Length < dtPage.Rows[dtPage.Rows.Count - 1]["Level"].ToString().Length)
				//{
				//	if (dtPage.Rows[dtPage.Rows.Count - 1]["Level"].ToString().Length == 15)
				//	{
				//		this.ltrmenu.Text += "<li class=\"category\"><a title='" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "' href=\"" + dtPage.Rows[dtPage.Rows.Count - 1]["Link"].ToString() + "\">" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "</a></li>\n";
				//	}
				//	else if (dtPage.Rows[dtPage.Rows.Count - 1]["Level"].ToString().Length == 10)
				//	{
				//		this.ltrmenu.Text += "<div id=\"column-" + count + "-1-" + countsub + "\" class=\"megamenu-col megamenu-col-1-" + countsub + " col-sm-3\">\n";
				//		this.ltrmenu.Text += "<ul class=\"content\">\n";
				//		this.ltrmenu.Text += "<li class=\"category\"><a title='" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "' href=\"" + dtPage.Rows[dtPage.Rows.Count - 1]["Link"].ToString() + "\">" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "</a></li>\n";
				//	}
				//	this.ltrmenu.Text += Inma(dtPage.Rows[dtPage.Rows.Count - 1]["Level"].ToString().Length, 5);
				//}
				//else
				//{
				//	//Khi phần tử cuối cùng không phải là con
				//	if (dtPage.Rows[dtPage.Rows.Count - 1]["Level"].ToString().Length == 5)
				//	{
				//		string rdnNum = string.Empty;
				//		rdnNum = NumberClass.GeneralRandomNum();
				//			 this.ltrmenu.Text += "<li class=\" top-level-menu-li tmmegamenu_item it_" + rdnNum + "\"><a class='it_" + rdnNum + " top-level-menu-li-a tmmegamenu_item' href=\"" + dtPage.Rows[dtPage.Rows.Count - 1]["Link"].ToString() + "\" title='" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "'>" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "</a></li>\n";

				//	}
				//	else if (dtPage.Rows[dtPage.Rows.Count - 1]["Level"].ToString().Length == 10)
				//	{
				//		this.ltrmenu.Text += "<div id=\"column-" + count + "-1-" + countsub + "\" class=\"megamenu-col megamenu-col-1-" + countsub + " col-sm-3\">\n";
				//		this.ltrmenu.Text += "<ul class=\"content\">\n";
				//		this.ltrmenu.Text += "<li class=\"category\"><a title='" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "' href=\"" + dtPage.Rows[dtPage.Rows.Count - 1]["Link"].ToString() + "\">" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "</a></li>\n";
				//		this.ltrmenu.Text += Inma(10, 5);
				//	}
				//	else if (dtPage.Rows[dtPage.Rows.Count - 1]["Level"].ToString().Length == 15)
				//	{
				//		this.ltrmenu.Text += "<li class=\"category\"><a title='" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "' href=\"" + dtPage.Rows[dtPage.Rows.Count - 1]["Link"].ToString() + "\">" + dtPage.Rows[dtPage.Rows.Count - 1]["Name"].ToString() + "</a></li>\n";
				//		this.ltrmenu.Text += Inma(15, 5);
				//	}
				//}
            }
            dtPage = null;
        }
        #endregion

        #region In mã HTML
        /// <summary>
        /// In thẻ đóng html
        /// </summary>
        /// <param name="a">Integer</param>
        /// <returns>String html</returns>
        string Inma(int prev, int next)
        {
            string str = "";
            if (prev == 15 && next == 10)
            {
                str = "</ul></li></ul></div>";
            }
            else if (prev == 15 && next == 5)
            {
                str = "</ul></li></ul></div></div></div></li>";
            }
            else if (prev == 10 && next == 5)
            {
                str = "</ul></div></div></div></li>";
            }
            return str;
        }
        #endregion

		protected void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater rptSub = (Repeater)item.FindControl("rptSub");
				HtmlGenericControl liparent = (HtmlGenericControl)item.FindControl("liparent");
				HtmlGenericControl ulSub = (HtmlGenericControl)item.FindControl("ulSub");
				
				if (rptSub != null)
				{
					string level = DataBinder.Eval(item.DataItem, "Level").ToString();
					DataRow[] drSub = dtPage.Select("LEN(level)=10 AND substring(level,1,5)='" + level.Substring(0,5) + "'");
					if (drSub != null && drSub.Length > 0)
					{
						liparent.Attributes["class"] = "dropdown";
						ulSub.Visible = true;
						rptSub.DataSource = drSub.CopyToDataTable();
						rptSub.DataBind();
					}
				}
			}
		}
		protected void rptSub_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			try
			{
				RepeaterItem item = e.Item;
				if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
				{
					Repeater rptLevel3 = (Repeater)item.FindControl("rptLevel3");
					HtmlGenericControl ulLevel3 = (HtmlGenericControl)item.FindControl("ulLevel3");
					if (rptLevel3 != null)
					{
						string level = DataBinder.Eval(item.DataItem, "Level").ToString();
						DataRow[] drSub = dtPage.Select("LEN(level)=15 AND substring(level,1,10)='" + level.Substring(0, 10) + "'");
						if (drSub != null && drSub.Length > 0)
						{
							ulLevel3.Visible = true;
							rptLevel3.DataSource = drSub.CopyToDataTable();
							rptLevel3.DataBind();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" +ex.StackTrace);
			}
		}

		protected void lbtLogout_Click(object sender, EventArgs e)
		{
			try
			{
				Session.RemoveAll();
				Session.Abandon();
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" +ex.StackTrace);
			}
		}
    }
}