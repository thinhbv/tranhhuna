using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Data;
using MyWeb.Common;
using System.Data;

namespace MyWeb.Controls
{
    public partial class U_MenuLeft : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				try
				{
					string groupId = string.Empty;
					string level = string.Empty;
					int count = 0;
					string strUrl = string.Empty;
					List<GroupProduct> listG = GroupProductService.GroupProduct_GetByTop("", "Active=1", "Level, Ord");
					if (listG.Count > 0)
					{
						for (int i = 0; i < listG.Count; i++)
						{
							if (listG[i].Level.Length == 5)
							{
								List<GroupProduct> listSub = listG.Where(l => l.Level.Length == 10 && l.Level.Substring(0, 5) == listG[i].Level).ToList();
								ltrmenu.Text += "<div class='layered_filter'>\n";
								ltrmenu.Text += "<div class='layered_subtitle_heading'>\n";
								count = ProductService.Product_GetCount(listG[i].Level);
								ltrmenu.Text += "<input type='checkbox' class='checkbox' name='layer_id_attribute_group_" + (i + 1).ToString() + "' id='layered_id_attribute_group_" + (i + 1).ToString() + "' value='" + listG[i].Id + "' />\n";
								ltrmenu.Text += "<label for='layer_id_attribute_group_" + (i + 1).ToString() + "'>\n";

								strUrl = PageHelper.GeneralGroupUrl(Consts.CON_SAN_PHAM, listG[i].Id, listG[i].Name);
								ltrmenu.Text += "<a href='" + strUrl + "'>";
								ltrmenu.Text += "<strong>" + listG[i].Name + "</strong>\n";

								count = ProductService.Product_GetCount(listG[i].Level);
								ltrmenu.Text += "<span>(" + count.ToString() + ")</span></a>\n</label></div>\n";
								if (listSub.Count > 0)
								{
									ltrmenu.Text += "<ul id='ul_layered_id_attribute_group_" + (i + 1).ToString() + "' class='col-lg-12 layered_filter_ul'>\n";
									for (int j = 0; j < listSub.Count; j++)
									{
										ltrmenu.Text += "<li class='nomargin hiddable col-lg-12'>\n";
										ltrmenu.Text += "<input type='checkbox' class='checkbox' name='layered_id_attribute_group_" + (j + 1).ToString() + "' id='layered_id_attribute_group_" + (j + 1).ToString() + "' value='" + listSub[j].Id + "' />\n";
										ltrmenu.Text += "<label for='layered_id_attribute_group_" + (j + 1).ToString() + "'>\n";

										strUrl = PageHelper.GeneralGroupUrl(Consts.CON_SAN_PHAM, listSub[j].Id, listSub[j].Name);
										ltrmenu.Text += "<a href='" + strUrl + "'>";
										ltrmenu.Text += "<strong>" + listSub[j].Name + "</strong>\n";
										count = ProductService.Product_GetCount(listSub[j].Level);
										ltrmenu.Text += "<span>(" + count.ToString() + ")</span></a>\n</label>\n</li>\n";
									}
									ltrmenu.Text += "</ul>\n";
								}
								ltrmenu.Text += "</div>\n";
							}
						}
					}
					DataTable dtSub = GroupNewsService.GroupNews_GetByTop("", "Active=1 And left(Level,5)='" + level + "' And len(Level) = 10", "Level, Ord");
					if (dtSub.Rows.Count > 0)
					{
						for (int i = 0; i < dtSub.Rows.Count; i++)
						{
							ltrmenu.Text += "<h3><a href='/" + dtSub.Rows[i]["Id"] + "/" + StringClass.NameToTag(dtSub.Rows[i]["Name"].ToString()) + ".aspx' title='" + dtSub.Rows[i]["Name"] + "'>" + dtSub.Rows[i]["Name"] + "</a></h3>";
							DataTable dt3 = NewsService.News_GetByTop("5", "Active=1 And GroupNewsId='" + dtSub.Rows[i]["Id"] + "'", "Date Desc");
							if (dt3.Rows.Count > 0)
							{
								ltrmenu.Text += "<div class='content-menu'><ul>";
								for (int j = 0; j < dt3.Rows.Count; j++)
								{
									if ("1".Equals(dt3.Rows[j]["Index"].ToString()))
									{
										ltrmenu.Text += "<li><a href='/" + dtSub.Rows[i]["Id"] + "/" + StringClass.NameToTag(dtSub.Rows[i]["Name"].ToString()) + "/" + dt3.Rows[j]["Id"] + "/" + StringClass.NameToTag(dt3.Rows[j]["Name"].ToString()) + ".aspx' title='" + dt3.Rows[j]["Name"] + "'>" + dt3.Rows[j]["Name"] + "</a><img src='/Images/icon_hot.gif' style='margin-left:2px' /></li>";
									}
									else
									{
										ltrmenu.Text += "<li><a href='/" + dtSub.Rows[i]["Id"] + "/" + StringClass.NameToTag(dtSub.Rows[i]["Name"].ToString()) + "/" + dt3.Rows[j]["Id"] + "/" + StringClass.NameToTag(dt3.Rows[j]["Name"].ToString()) + ".aspx' title='" + dt3.Rows[j]["Name"] + "'>" + dt3.Rows[j]["Name"] + "</a></li>";
									}
								}
								ltrmenu.Text += "</ul></div>";
							}
						}
					}
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message);
				}
            }
        }
    }
}