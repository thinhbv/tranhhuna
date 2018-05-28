using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;
using MyWeb.Common;

namespace MyWeb.Modules.News
{
    public partial class ViewNews : System.Web.UI.Page
    {
        protected string groupName = string.Empty;
        protected int totalcount = 0;
        string id = string.Empty;
        string pagenum = "1";
        string perpage = "4";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["GroupId"] != null)
            {
                id = Page.RouteData.Values["GroupId"] as string;
            }
            if (Page.RouteData.Values["page"] != null)
            {
                pagenum = Page.RouteData.Values["page"] as string;
            }
            if (!IsPostBack)
            {
                try
                {
                    DataTable dtGrp = GroupNewsService.GroupNews_GetById(id);
                    if (dtGrp.Rows.Count > 0)
                    {
                        groupName = dtGrp.Rows[0]["Name"].ToString();
                        totalcount = NewsService.News_GetCount(dtGrp.Rows[0]["Level"].ToString());
                        DataTable dtNews = NewsService.News_Pagination(pagenum, perpage, dtGrp.Rows[0]["Level"].ToString());
                        if (dtNews.Rows.Count > 0)
                        {
                            rptNews.DataSource = dtNews;
                            rptNews.DataBind();
                        }

                        DataTable dtGroupSub = GroupNewsService.GroupNews_GetByTop("", "Active = 1 AND len('[Level]') > 5 AND left('[Level]', 5) = left('" + dtGrp.Rows[0]["Level"].ToString() + "', 5)", "[Level]");
                        if (dtGroupSub.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtGroupSub.Rows.Count - 1; i++)
                            {
                                ltrCrumb.Text += "<li class='crumb-" + (i + 1).ToString() + "'>\n";
                                ltrCrumb.Text += "<a href='" + PageHelper.GeneralGroupUrl(Consts.CON_SAN_PHAM, dtGroupSub.Rows[i]["Id"].ToString(), dtGroupSub.Rows[i]["Name"].ToString()) + "' title='" + dtGroupSub.Rows[i]["Name"].ToString() + "'>" + dtGroupSub.Rows[i]["Name"].ToString() + "</a>\n";
                                ltrCrumb.Text += "</li>\n";
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