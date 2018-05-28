using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Controls
{
    public partial class U_Contact : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtConfig = new DataTable();
                dtConfig = ConfigService.Config_GetByTop("1", "", "");
                if (dtConfig.Rows.Count>0)
                {
                    ltrContact.Text = dtConfig.Rows[0]["Contact"].ToString();
                }
                DataTable dtSupport = new DataTable();
                dtSupport = SupportService.Support_GetByTop("2", "Active=1", "");
                if (dtSupport.Rows.Count > 0)
                {
                    lblPhone.Text = dtSupport.Rows[0]["Phone"].ToString();
                    ltrYahoo.Text = "<a href='ymsgr:sendim?" + dtSupport.Rows[0]["Nick"] + "'>";
                    ltrYahoo.Text += "<img src='http://opi.yahoo.com/online?u=" + dtSupport.Rows[0]["Nick"] + "&amp;m=g&amp;t=2' style='width: 90px; height: 25px;' /></a>";
                    ltrSkype.Text = "<a href='skype:" + dtSupport.Rows[0]["Skype"] + "?call'><img src='/Images/skype.png' alt='My status' /></a>";
                    ltrMail.Text = "<div style='width:235px; float:left; padding-left: 5px;'><a href='mailto:info@" + dtSupport.Rows[0]["Email"] + "'>" + dtSupport.Rows[0]["Email"] + "</a><br />";
                    if (dtSupport.Rows.Count > 1)
                    {
                        lblPhone.Text+= " - " + dtSupport.Rows[1]["Phone"].ToString();
                        ltrMail.Text += "<a href='mailto:info@" + dtSupport.Rows[1]["Email"] + "'>" + dtSupport.Rows[1]["Email"] + "</a>";
                    }
                    ltrMail.Text += "</div>";
                }
            }
        }
    }
}