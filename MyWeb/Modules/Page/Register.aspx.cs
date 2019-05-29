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
using System.Web.Security;
using System.Text.RegularExpressions;

namespace MyWeb.Modules.Page
{
	public partial class Register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void lbtRegister_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					if (string.IsNullOrEmpty(txtUserName.Value.Trim()))
					{
						WebMsgBox.Show("Vui lòng nhập email của bạn");
						txtUserName.Focus();
						return;
					}
					if (!StringClass.IsValidEmail(txtUserName.Value.Trim()))
					{
						WebMsgBox.Show("Vui lòng nhập email đúng định dạng");
						txtUserName.Focus();
						return;
					}
					if (string.IsNullOrEmpty(txtPass.Value.Trim()))
					{
						WebMsgBox.Show("Vui lòng nhập mật khẩu");
						txtPass.Focus();
						return;
					}
					Regex reg = new Regex("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,15})$");
					if (!reg.IsMatch(txtPass.Value.Trim()))
					{
						WebMsgBox.Show("Mật khẩu chỉ bao gồm kí tự chữ và số");
						txtPass.Focus();
						return;
					}
					if (!txtPass.Value.Trim().Equals(txtConfirmPass.Value.Trim()))
					{
						WebMsgBox.Show("Mật khẩu xác nhận không khớp");
						txtConfirmPass.Focus();
						return;
					}
					Customers cus = new Customers();
					cus.Email = StringClass.SqlInjection(txtUserName.Value.Trim());
					cus.UserName = cus.Email.Substring(0, cus.Email.LastIndexOf("@"));
					cus.CreatedDate = DateTime.Now.ToShortDateString();
					cus.Password = StringClass.SqlInjection(StringClass.Encode(txtPass.Value.Trim()));
					cus.Active = "1";
					DataTable dt = CustomersService.Customers_GetByName(StringClass.SqlInjection(txtUserName.Value.Trim()));
					if (dt.Rows.Count > 0)
					{
						WebMsgBox.Show("Email này đã được đăng kí.");
						txtUserName.Focus();
						return;
					}
					CustomersService.Customers_Insert(cus); 
					FormsAuthentication.SetAuthCookie(StringClass.SqlInjection(txtUserName.Value.Trim()), false);
					Session["Email"] = cus.Email;
					Session["UserName"] = cus.UserName;
					Session["IsAuthorized"] = true;
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" +ex.StackTrace);
			}
		}
	}
}