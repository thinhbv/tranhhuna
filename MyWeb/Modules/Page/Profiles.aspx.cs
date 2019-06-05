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
	public partial class Profiles : System.Web.UI.Page
	{
		private Customers cus = new Customers();
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (Session["Info"] != null)
				{
					DataTable dtCus = CustomersService.Customers_GetById(((Customers)Session["Info"]).Id);

					cus.Id = dtCus.Rows[0]["Id"].ToString();
					cus.AppId = dtCus.Rows[0]["AppId"].ToString();
					cus.Email = dtCus.Rows[0]["Email"].ToString();
					cus.UserName = dtCus.Rows[0]["UserName"].ToString();
					cus.FullName = dtCus.Rows[0]["FullName"].ToString();
					cus.Password = dtCus.Rows[0]["Password"].ToString();
					cus.Phone = dtCus.Rows[0]["Phone"].ToString();
					cus.Gender = dtCus.Rows[0]["Gender"].ToString();
					cus.CreatedDate = DateTime.Parse(dtCus.Rows[0]["CreatedDate"].ToString()).ToString("MM/dd/yyyy HH:mm:ss");
					cus.Ord = dtCus.Rows[0]["Ord"].ToString();
					cus.Active = dtCus.Rows[0]["Active"].ToString();
				}
				else
				{
					Response.Redirect("/", false);
					return;
				}
				if (!IsPostBack)
				{
					if (cus != null)
					{
						txtFullName.Value = cus.FullName;
						txtEmail.Value = cus.Email;
						txtPhone.Value = cus.Phone;
					}
				}

			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}

		protected void lbtSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					cus.FullName = txtFullName.Value.Trim();
					cus.Phone = txtPhone.Value.Trim();
					CustomersService.Customers_Update(cus);
					Session["Info"] = cus;
					WebMsgBox.Show("Cập nhật thông tin thành công.");
				}
			}
			catch (Exception ex)
			{
				WebMsgBox.Show("Cập nhật thông tin thất bại. Vui lòng thử lại sau.");
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}

		protected void lbtLogout_Click(object sender, EventArgs e)
		{
			try
			{
				Session.RemoveAll();
				Session.Abandon();
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}

		protected void lbtSavePass_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					if (!string.IsNullOrEmpty(cus.Password))
					{
						if (!StringClass.Encode(txtOldPassword.Value.Trim()).Equals(cus.Password))
						{
							WebMsgBox.Show("Mật khẩu cũ không đúng");
							txtOldPassword.Focus();
							Response.Redirect("/thanh-vien/thong-tin-ca-nhan#doi-mat-khau", false);
							return;
						}
					}
					Regex reg = new Regex("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,15})$");
					if (!reg.IsMatch(txtNewPassword.Value.Trim()))
					{
						WebMsgBox.Show("Mật khẩu chỉ bao gồm kí tự chữ và số");
						txtNewPassword.Focus();
						Response.Redirect("/thanh-vien/thong-tin-ca-nhan#doi-mat-khau", false);
						return;
					}
					if (!txtNewPassword.Value.Trim().Equals(txtConfirmNewPassword.Value.Trim()))
					{
						WebMsgBox.Show("Mật khẩu xác nhận không khớp");
						txtConfirmNewPassword.Focus();
						Response.Redirect("/thanh-vien/thong-tin-ca-nhan#doi-mat-khau", false);
						return;
					}
					cus.Password = StringClass.Encode(txtNewPassword.Value.Trim());
					CustomersService.Customers_Update(cus);
					Session["Info"] = cus;
					WebMsgBox.Show("Cập nhật mật khẩu thành công.");
					Response.Redirect("/thanh-vien/thong-tin-ca-nhan#doi-mat-khau", false);
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
				WebMsgBox.Show("Cập nhật mật khẩu thất bại. Vui lòng thử lại.");
				Response.Redirect("/thanh-vien/thong-tin-ca-nhan#doi-mat-khau", false);
			}
		}
	}
}