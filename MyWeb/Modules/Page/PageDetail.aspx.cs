using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules.Page
{
    public partial class PageDetail : System.Web.UI.Page
    {
        protected string pageId = string.Empty;
        protected string title = string.Empty;
		protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["pageId"] != null)
            {
                pageId = Page.RouteData.Values["pageId"] as string;
            }
            if (!IsPostBack)
            {
                try
                {
					if (Microsoft.VisualBasic.Information.IsNumeric(pageId) == false)
					{
						return;
					}
                    DataTable dtPage = PageService.Page_GetById(pageId);
                    if (dtPage.Rows.Count > 0)
                    {
                        title = dtPage.Rows[0]["Name"].ToString();
						content = dtPage.Rows[0]["Description"].ToString();
                        ltrDetail.Text = dtPage.Rows[0]["Detail"].ToString();
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