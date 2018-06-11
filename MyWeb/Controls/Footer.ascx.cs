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
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message);
				}
            }
        }
    }
}