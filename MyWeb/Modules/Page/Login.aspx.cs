﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;
using System.Web.Security;

namespace MyWeb.Modules.Page
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void lbtLogin_Click(object sender, EventArgs e)
		{
			try
			{
				string redirectUrl = Request.QueryString.Get("url");
				if (string.IsNullOrEmpty(redirectUrl))
				{
					redirectUrl = "/";
				}
				if (Page.IsValid)
				{
					if (string.IsNullOrEmpty(txtUserName.Value.Trim()))
					{
						WebMsgBox.Show("Vui lòng nhập tên đăng nhập");
						txtUserName.Focus();
						return;
					}
					if (string.IsNullOrEmpty(txtPassword.Value.Trim()))
					{
						WebMsgBox.Show("Vui lòng nhập mật khẩu");
						txtPassword.Focus();
						return;
					}
					string pUI = StringClass.SqlInjection(txtUserName.Value.Trim());
					string pPW = StringClass.SqlInjection(txtPassword.Value.Trim());
					DataTable dt = new DataTable();
					dt = CustomersService.Customers_GetByName(pUI);
					if (dt.Rows.Count > 0 && pPW.Equals(StringClass.Decode(dt.Rows[0]["Password"].ToString())))
					{
						Customers cus = new Customers();
						cus.Id = dt.Rows[0]["Id"].ToString();
						cus.AppId = dt.Rows[0]["AppId"].ToString();
						cus.UserName = dt.Rows[0]["UserName"].ToString();
						cus.FullName = dt.Rows[0]["FullName"].ToString();
						cus.Phone = dt.Rows[0]["Phone"].ToString();
						cus.Email = dt.Rows[0]["Email"].ToString();
						FormsAuthentication.SetAuthCookie(StringClass.SqlInjection(txtUserName.Value.Trim()), false);
						Session["Info"] = cus;
						Response.Redirect(redirectUrl, false);
					}
					else
					{
						txtPassword.Value = "";
						txtPassword.Focus();
						WebMsgBox.Show("Địa chỉ email hoặc mật khẩu không đúng.");
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