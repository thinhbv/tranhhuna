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
	public partial class CheckLogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				Customers cus = new Customers();
				cus.AppId = Request.QueryString.Get("id");
				cus.FullName = Request.QueryString.Get("name");
				cus.Email = Request.QueryString.Get("email");
				DataTable dt = CustomersService.Customers_GetByAppId(StringClass.SqlInjection(cus.AppId));
				if (dt.Rows.Count == 0)
				{
					CustomersService.Customers_Insert(cus);

					Session["Email"] = cus.Email;
					Session["FullName"] = cus.FullName;
					Session["IsAuthorized"] = true;
				}
				else
				{
					Session["Email"] = dt.Rows[0]["Email"].ToString().Trim();
					Session["FullName"] = dt.Rows[0]["FullName"].ToString().Trim();
					Session["IsAuthorized"] = true;
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}
	}
}