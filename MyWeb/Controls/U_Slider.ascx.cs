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

namespace MyWeb.Controls
{
    public partial class U_Slider : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (!IsPostBack)
				{
					// Hiển thị list Đối Tác
					List<Advertise> listDoiTac = new List<Advertise>();
					listDoiTac = AdvertiseService.Advertise_GetByPosition("3");
					if (listDoiTac.Count > 0)
					{
						for (int i = 0; i < listDoiTac.Count; i++)
						{
							ltrDoiTac.Text += String.Format("<a href='{0}'><img src='{1}' alt='{2}' class='scrollimage' /></a>", listDoiTac[i].Link, listDoiTac[i].Image, listDoiTac[i].Name);
						}
					}

					// Hiển thị list Khách hàng
					List<Advertise> listKhachHang = new List<Advertise>();
					listKhachHang = AdvertiseService.Advertise_GetByPosition("4");
					if (listKhachHang.Count > 0)
					{
						for (int i = 0; i < listKhachHang.Count; i++)
						{
							ltrKhachHang.Text += String.Format("<a href='{0}'><img src='{1}' alt='{2}' class='scrollimage' /></a>", listKhachHang[i].Link, listKhachHang[i].Image, listKhachHang[i].Name);
						}
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