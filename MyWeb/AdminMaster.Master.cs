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
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == null || Session["UserName"].ToString() == "")
                {
                    Response.Redirect("/Logon", false);
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = UserService.User_GetByUsername(Session["UserName"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        Session["FullName"] = dt.Rows[0]["Name"].ToString().Trim();
                        Session["UserName"] = dt.Rows[0]["UserName"].ToString().Trim();
                        Session["IsAdmin"] = dt.Rows[0]["Admin"].ToString();
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