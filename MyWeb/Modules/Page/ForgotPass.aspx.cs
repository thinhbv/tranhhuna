using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.Page
{
	public partial class ForgotPass : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void lbtGetPass_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtEmail.Value.Trim() == string.Empty)
				{
					WebMsgBox.Show("Vui lòng nhập Email của bạn!");
					txtEmail.Focus();
					return;
				}
				DataTable dt = CustomersService.Customers_GetByName(txtEmail.Value.Trim());
				if (dt == null || dt.Rows.Count == 0)
				{
					WebMsgBox.Show("Email này không tồn tại trong hệ thống!");
					txtEmail.Focus();
					return;
				}

				Customers cus = new Customers();
				cus.Id = dt.Rows[0]["Id"].ToString();
				cus.AppId = dt.Rows[0]["AppId"].ToString();
				cus.UserName = dt.Rows[0]["UserName"].ToString();
				cus.FullName = dt.Rows[0]["FullName"].ToString();
				cus.Phone = dt.Rows[0]["Phone"].ToString();
				cus.Email = dt.Rows[0]["Email"].ToString();
				cus.Gender = dt.Rows[0]["Gender"].ToString();
				cus.CreatedDate = DateTime.Parse(dt.Rows[0]["CreatedDate"].ToString()).ToString("MM/dd/yyyy HH:mm:ss");
				cus.Ord = dt.Rows[0]["Ord"].ToString();
				cus.Active = dt.Rows[0]["Active"].ToString();
				string newPass = StringClass.RandomString(8);
				cus.Password = StringClass.Encode(newPass);
				CustomersService.Customers_Update(cus);
				MailSender.SendMail(txtEmail.Value.Trim(), "", @"Reset mật khẩu", "Bạn nhận được email này do bạn hoặc một ai đó đã sử dụng địa chỉ email " + txtEmail.Value.Trim() + 
																" để lấy lại mật khẩu tại filetranh.net.<br/> Mật khẩu mới của bạn là " + newPass + 
																"<br/>Nếu bạn không tạo tài khoản trên filetranh.net, vui lòng bỏ qua nội dung của email này.");
				WebMsgBox.Show("Chúng tôi đã gửi mật khẩu mới vào email của bạn. Vui lòng check email của bạn.");
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}

		}
	}
}