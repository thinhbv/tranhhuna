using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;
using MyWeb.Common;


namespace MyWeb.Controls
{
	public partial class U_NewsList : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				string groupName = string.Empty;
				if (!IsPostBack)
				{
					DataTable dtNews = NewsService.News_GetByTop("3", "Priority=2 AND Active=1", "Date DESC");
					for (int i = 0; i < dtNews.Rows.Count; i++)
					{
						DataTable dtGroup = GroupNewsService.GroupNews_GetById(dtNews.Rows[i]["GroupNewsId"].ToString());
						if (dtGroup.Rows.Count > 0)
						{
							groupName = dtGroup.Rows[0]["Name"].ToString();
						}

						if (i == 0)
						{
							ltrNews.Text = "<div class='col-md-4 col-sm-6 col-xs-12 wow fadeInLeft'>\n";
						}
						else if (i == 1)
						{
							ltrNews.Text += "<div class='col-md-4 col-sm-6 col-xs-12 wow fadeInUp'>\n";
						}
						else if (i == 2)
						{
							ltrNews.Text += "<div class='col-md-4 col-sm-6 col-md-offset-0 col-sm-offset-3 col-xs-12 wow fadeInRight'>\n";
						}
						string url = PageHelper.GeneralDetailUrl(Consts.CON_TIN_TUC, groupName, dtNews.Rows[i]["Id"].ToString(), dtNews.Rows[i]["Name"].ToString());
						ltrNews.Text += "<img src='" + dtNews.Rows[i]["Image"].ToString() + "' alt='" + dtNews.Rows[i]["Name"].ToString() + "' title='" + dtNews.Rows[i]["Name"].ToString() + "' width='100%'>\n";
						ltrNews.Text += "<h4><strong><a href='" + url + "'>" + dtNews.Rows[i]["Name"].ToString() + "</a></strong></h4>\n";
						ltrNews.Text += "<p>" + StringClass.FormatContentNews(dtNews.Rows[i]["Content"].ToString(), 100) + "</p>\n";
						ltrNews.Text += "<a href='" + url + "' class='btn-link'>Chi tiết >></a>\n";
						ltrNews.Text += "</div>\n";
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" +ex.StackTrace);
			}
		}
	}
}