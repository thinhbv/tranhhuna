using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Data;
using MyWeb.Common;

namespace MyWeb.Controls
{
    public partial class U_MenuLeftNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (!IsPostBack)
				{
					DataTable dt = NewsService.News_GetByTop("5", "Active = 1 AND Priority <> 3", "Date DESC");
					if (dt.Rows.Count > 0)
					{
						ltrNews.Text = "<h4 class='title_block'>Tin mới nhất</h4>\n";
						ltrNews.Text += "<div class='block_content products-block'>\n<ul>\n";
						for (int i = 0; i < dt.Rows.Count; i++)
						{
							if (i == 0)
							{
								ltrNews.Text += "<li class='clearfix first_item'>\n";
							}
							else if (i == dt.Rows.Count - 1)
							{
								ltrNews.Text += "<li class='clearfix last_item'>\n";
							}
							else
							{
								ltrNews.Text += "<li class='clearfix'>\n";
							}
							ltrNews.Text += "<a class='products-block-image' title='" + dt.Rows[i]["Name"].ToString() + "' href='" + PageHelper.GeneralDetailUrl(Consts.CON_TIN_TUC, dt.Rows[i]["GroupNewsId"].ToString(), dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Name"].ToString()) + "'>\n";
							ltrNews.Text += "<img width='200' alt='" + dt.Rows[i]["Name"].ToString() + "' src='" + StringClass.ThumbImage(dt.Rows[i]["Image"].ToString()) + "'></a>\n";
							ltrNews.Text += "<div class='product-content'>\n";
							ltrNews.Text += "<h5><a class='post-name product-name' title='" + dt.Rows[i]["Name"].ToString() + "' href='" + PageHelper.GeneralDetailUrl(Consts.CON_TIN_TUC, dt.Rows[i]["GroupNewsId"].ToString(), dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Name"].ToString()) + "'>" + dt.Rows[i]["Name"].ToString() + "</a></h5>\n";
							ltrNews.Text += "<span class='info'>" + dt.Rows[i]["Date"].ToString() + "</span></div>\n";
						}
						ltrNews.Text += "</ul></div>\n";
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