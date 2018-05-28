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

namespace MyWeb.Controls
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				try
				{
					DataTable dtConfig = ConfigService.Config_GetByTop("1", "", "");
					if (dtConfig.Rows.Count > 0)
					{
						ltrInfo.Text = dtConfig.Rows[0]["Copyright"].ToString();
					}
					DataTable dt = PageService.Page_GetByTop("", "Active = 1 AND Position = 3", "Ord DESC");
					if (dt.Rows.Count > 0)
					{
						ltrMenu.Text = "<ul class='bullet'>\n";
						for (int i = 0; i < dt.Rows.Count; i++)
						{
							ltrMenu.Text += "<li><a href='" + dt.Rows[i]["Link"].ToString() + "' title='" + dt.Rows[i]["Name"].ToString() + "' rel='nofollow'>My orders</a></li>\n";
						}
						ltrMenu.Text += "</ul>\n";
					}
					dt.Clear();
					List<Images> listImg = ImagesService.Images_GetByTop("8", "Active = 1", "Ord DESC");
					if (listImg.Count > 0)
					{
						for (int i = 0; i < listImg.Count; i++)
						{
							ltrImages.Text += "<div class='instagram_item'>\n";
							ltrImages.Text += "<a class='instagram_link' href='#' target='_blank' rel='nofollow' style='background-image: url(" + listImg[i].Image + ");'><span class='instagram__cover'></span></a>\n";
							ltrImages.Text += "</div>";
						}
					}
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message);
				}
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                WebMsgBox.Show("Đã có lỗi xảy ra khi đăng ký. Bạn vui lòng thử lại!");
            }
            finally
            {

            }
        }
    }
}