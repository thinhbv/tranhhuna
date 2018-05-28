using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;
using System.Net.Mail;

namespace MyWeb.Modules.Page
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Liên hệ với chúng tôi";
                DataTable dt = ConfigService.Config_GetByTop("1", "", "");
                if (dt.Rows.Count > 0)
                {
                    ltrContact.Text = dt.Rows[0]["Contact"].ToString();
                }
            }
        }

		protected void btnSend_Click(object sender, EventArgs e)
		{
			Data.Contact obj = new Data.Contact();
			obj.Name = txtHoTen.Text;
			obj.Company = txtAddress.Text;
			obj.Email = txtEmail.Text;
			obj.Phone = txtPhone.Text;
			obj.Website = string.Empty;
			obj.Title = txtTitle.Text;
			obj.Detail = txtDetail.Text;
			obj.Date = DateTimeClass.ConvertDateTime(DateTime.Now.ToLongDateString(), "MM/dd/yyyy HH:mm:ss");
			ContactService.Contact_Insert(obj);
			#region[SendMail]
			try
			{
				string strchuoi = "Họ tên: " + txtHoTen.Text.Trim() + "\n<br />";
				strchuoi += "E-mail: " + txtEmail.Text.Trim() + "\n<br />";
				strchuoi += "Điện thoại: " + txtPhone.Text.Trim() + "\n<br />";
				strchuoi += "Địa chỉ: " + txtAddress.Text.Trim() + "\n<br />";
				strchuoi += "Nội dung: " + txtDetail.Text.Trim() + "\n";
				MailSender.SendMail("", "", txtTitle.Text.Trim(), strchuoi);
				WebMsgBox.Show("Bạn đã gửi thành công!");
			}
			catch (Exception ex)
			{
				WebMsgBox.Show("Bạn đã gửi thất bại! Vui lòng thử lại lần nữa!");
			}
			finally
			{
				txtTitle.Text = string.Empty;
				txtAddress.Text = string.Empty;
				txtHoTen.Text = string.Empty;
				txtEmail.Text = string.Empty;
				txtDetail.Text = string.Empty;
				txtPhone.Text = string.Empty;
			}
			#endregion

		}
    }
}