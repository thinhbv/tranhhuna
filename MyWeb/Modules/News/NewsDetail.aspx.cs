using System;
using System.Data;
using System.Web;
using System.Web.UI;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules.News
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected string titleNews = string.Empty;
        protected string contents = string.Empty;
        protected string titleReleate = string.Empty;
        string groupName = string.Empty;
        string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["Id"] != null)
            {
                id = Page.RouteData.Values["Id"] as string;
            }
            if (!IsPostBack)
            {
                try
                {
                    DataTable dtNews = NewsService.News_GetById(id);
                    if (dtNews.Rows.Count > 0)
                    {
                        titleNews = dtNews.Rows[0]["Name"].ToString();
                        contents = dtNews.Rows[0]["Content"].ToString();
                        ltrDetail.Text = dtNews.Rows[0]["Detail"].ToString();
                        DataTable dtGroup = GroupNewsService.GroupNews_GetById(dtNews.Rows[0]["GroupNewsId"].ToString());
                        if (dtGroup.Rows.Count > 0)
                        {
                            groupName = dtGroup.Rows[0]["Name"].ToString();

                            DataTable dtGroupSub = GroupNewsService.GroupNews_GetByTop("", "Active = 1 AND len([Level]) < len('" + dtGroup.Rows[0]["Level"].ToString() + "') AND left([Level], 5) = left('" + dtGroup.Rows[0]["Level"].ToString() + "', 5)", "[Level]");
                            if (dtGroupSub.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtGroupSub.Rows.Count; i++)
                                {
                                    ltrCrumb.Text += "<li class='crumb-" + (i + 1).ToString() + "'>\n";
                                    ltrCrumb.Text += "<a href='" + PageHelper.GeneralGroupUrl(Consts.CON_SAN_PHAM, dtGroupSub.Rows[i]["Id"].ToString(), dtGroupSub.Rows[i]["Name"].ToString()) + "' title='" + dtGroupSub.Rows[i]["Name"].ToString() + "'>" + dtGroupSub.Rows[i]["Name"].ToString() + "</a>\n";
                                    ltrCrumb.Text += "</li>\n";
                                }
                            }
                        }
                        DataTable dtNewsReleate = NewsService.News_GetByTop("3", "Active = 1 AND GroupNewsId = '" + dtNews.Rows[0]["GroupNewsId"].ToString() + "'", "Date Desc");
                        if (dtNewsReleate.Rows.Count > 0)
                        {
                            titleReleate = "Tin liên quan";
                            for (int i = 0; i < dtNewsReleate.Rows.Count; i++)
                            {
                                GeneralNewsReleate(i, dtNewsReleate.Rows[i]);
                            }
                        }
					}
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message + "\n" +ex.StackTrace);
				}
            }
        }

        private void GeneralNewsReleate(int i, DataRow row)
        {
            ltrNewsReleate.Text += "<li class='col-xs-12 col-sm-6 col-md-4 ";
            if (i % 3 == 0)
            {
                ltrNewsReleate.Text += "first-in-line ";
            }
            if (i % 3 == 2)
            {
                ltrNewsReleate.Text += "last-in-line ";
            }
            if (i > 0)
            {
                ltrNewsReleate.Text += "last-line ";
            }
            if (i % 2 == 0)
            {
                ltrNewsReleate.Text += "first-item-of-tablet-line first-item-of-mobile-line";
            }
            else
            {
                ltrNewsReleate.Text += "last-item-of-tablet-line last-item-of-mobile-line";
            }
            ltrNewsReleate.Text += "'>\n";
            ltrNewsReleate.Text += "<a class='products-block-image' title='" + row["Name"].ToString() + "' href='" + PageHelper.GeneralDetailUrl(Consts.CON_TIN_TUC, groupName, row["Id"].ToString(), row["Name"].ToString()) + "'>\n";
            ltrNewsReleate.Text += "<img class='img-responsive' alt='" + row["Name"].ToString() + "' src='" + row["Image"].ToString() + "'></a>\n";
            ltrNewsReleate.Text += "<h5><a class='post-name product-name' title='" + row["Name"].ToString() + "' href='" + PageHelper.GeneralDetailUrl(Consts.CON_TIN_TUC, groupName, row["Id"].ToString(), row["Name"].ToString()) + "'>" + row["Name"].ToString() + "</a></h5>\n";
            ltrNewsReleate.Text += "<span class='info'>" + row["Date"].ToString() + "</span>\n</li>\n";
        }
    }
}