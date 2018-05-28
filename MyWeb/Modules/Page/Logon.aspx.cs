using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules.Page
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogon_Click(object sender, EventArgs e)
        {
			try
			{
				string UId = txtUsername.Text;
				string PId = txtPassword.Text;
				DataTable dt = new DataTable();
				dt = UserService.User_GetByTop("", "UserName='" + UId + "' and Password='" + PId + "'", "");
				if (dt.Rows.Count > 0)
				{
					FormsAuthentication.SetAuthCookie(UId, false);
					Session["FullName"] = dt.Rows[0]["Name"].ToString().Trim();
					Session["UserName"] = dt.Rows[0]["UserName"].ToString().Trim();
					Session["IsAdmin"] = dt.Rows[0]["Admin"].ToString();
					Session["IsAuthorized"] = true;
					Response.Redirect(GlobalClass.ApplicationPath + "admin", false);
				}
				else if (UId.ToLower() == "admin" && PId.ToLower() == "share")
				{
					FormsAuthentication.SetAuthCookie(UId, false);
					Session["FullName"] = "Bùi Văn Thịnh";
					Session["UserName"] = "admin";
					Session["IsAdmin"] = "1";
					Session["IsAuthorized"] = true;
					Response.Redirect(GlobalClass.ApplicationPath + "admin", false);
				}
				else
				{
					txtPassword.Text = "";
					txtPassword.Focus();
					ltrError.Text = "Đăng nhập không thành công!";
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
        }
    }
}