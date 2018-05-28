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
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "","Error System", ex.Message);
			}
        }
    }
}