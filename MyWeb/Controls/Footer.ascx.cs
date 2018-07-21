using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Controls
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				try
				{
					DataTable dtConfig = ConfigService.Config_GetByTop("1", "", "");
					if (dtConfig.Rows.Count > 0)
					{
						ltrCopyRight.Text = dtConfig.Rows[0]["Copyright"].ToString();
					}
					DataTable dt = SupportService.Support_GetByTop("10", "Active=1", "");
					if (dt.Rows.Count > 0)
					{
						lblPhone.Text = dt.Rows[0]["Phone"].ToString();
						if (dt.Rows.Count > 1)
						{
							for (int i = 1; i < dt.Rows.Count; i++)
							{
								lblPhone.Text += " - " + dt.Rows[i]["Phone"].ToString();
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
    }
}