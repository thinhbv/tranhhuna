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

namespace MyWeb.Controls
{
    public partial class U_Banner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				try
				{
					List<Advertise> listBanner = new List<Advertise>();
					listBanner = AdvertiseService.Advertise_GetByPosition("2");
					if (listBanner.Count > 0)
					{
						rptBanner.DataSource = listBanner;
						rptBanner.DataBind();
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