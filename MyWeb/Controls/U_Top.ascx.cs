using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;
using System.Data;

namespace MyWeb.Controls
{
    public partial class U_Top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				try
				{
					List<Advertise> list = AdvertiseService.Advertise_GetByPosition("1");
					if (list.Count > 0)
					{
						//ltrLogo.Text = "<img title='" + list[0].Name + "' src='" + list[0].Image + "' alt='" + list[0].Name + "' class='navbar-brand-img' />";
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
					MailSender.SendMail("", "", "Error System", ex.Message);
				}
            }
        }
    }
}