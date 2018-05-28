using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FredCK.FCKeditorV2;
using System.Collections;

namespace MyWeb.Common
{
    public class ControlClass : System.Web.UI.UserControl
    {
        public static void SetPostBackUrlLinkControl(Control parent) 
        {
            foreach (Control c in parent.Controls)
            {
                string abc = c.ID;
                if (c.Controls.Count > 0)
                {
                    SetPostBackUrlLinkControl(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.LinkButton":
                            ((LinkButton)c).PostBackUrl = c.ID.Replace("lbt", "/Admin/") + ".aspx";
                            break;
                    }
                }
            }
        }
        public static void ResetControlValues(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                string abc = c.ID;
                if (c.Controls.Count > 0)
                {
                    if (c.GetType().ToString() == "FredCK.FCKeditorV2.FCKeditor") {
                        ((FCKeditor)c).Value = "";
                    }
                    else {
                        ResetControlValues(c);
                    }
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.DropDownList":
                            ((DropDownList)c).Items.Clear();
                            break;   
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = ((CheckBox)c).ID.ToLower().Contains("actite") ? true : false;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.Image":
                            ((Image)c).ImageUrl = null;
                            ((Image)c).Width = 0;
                            break;
                        case "FredCK.FCKeditorV2.FCKeditor":
                            ((FCKeditor)c).Value = "";
                            break;
                        case"System.Web.UI.WebControls.CheckBoxList":
                            ((CheckBoxList)c).Items.Clear();
                            break;
                    }
                }
            }
        }
        public static ArrayList ListTinh()
        {
            ArrayList list = new ArrayList();
            list.Add("--Chọn tỉnh thành--");
            list.Add("Hà Nội");
            list.Add("Bắc Giang");
            list.Add("Bắc Kạn");
            list.Add("Bắc Ninh");
            list.Add("Cao Bằng");
            list.Add("Điện Biên");
            list.Add("Hà Giang");
            list.Add("Hà Nam");
            list.Add("Hải Dương");
            list.Add("Hải Phòng");
            list.Add("Hòa Bình");
            list.Add("Hưng Yên");
            list.Add("Lai Châu");
            list.Add("Lào Cai");
            list.Add("Lạng Sơn");
            list.Add("Nam Định");
            list.Add("Ninh Bình");
            list.Add("Phú Thọ");
            list.Add("Quảng Ninh");
            list.Add("Sơn La");
            list.Add("Thái Bình");
            list.Add("Thái Nguyên");
            list.Add("Tuyên Quang");
            list.Add("Vĩnh Phúc");
            list.Add("Yên Bái");
            list.Add("Đà Nẵng");
            list.Add("Bình Định");
            list.Add("Đắk Lắk");
            list.Add("Đắk Nông");
            list.Add("Gia Lai");
            list.Add("Hà Tĩnh");
            list.Add("Khánh Hòa");
            list.Add("Kon Tum");
            list.Add("Nghệ An");
            list.Add("Phú Yên");
            list.Add("Quảng Bình");
            list.Add("Quảng Nam");
            list.Add("Quảng Ngãi");
            list.Add("Quảng Trị");
            list.Add("Thanh Hóa");
            list.Add("Thừa Thiên Huế");
            list.Add("TP. Hồ Chí Minh");
            list.Add("An Giang");
            list.Add("Bà Rịa Vũng Tàu");
            list.Add("Bạc Liêu");
            list.Add("Bến Tre");
            list.Add("Bình Dương");
            list.Add("Bình Phước");
            list.Add("Bình Thuận");
            list.Add("Cà Mau");
            list.Add("Cần Thơ");
            list.Add("Đồng Nai");
            list.Add("Đồng Tháp");
            list.Add("Hậu Giang");
            list.Add("Kiên Giang");
            list.Add("Lâm Đồng");
            list.Add("Long An");
            list.Add("Ninh Thuận");
            list.Add("Sóc Trăng");
            list.Add("Tây Ninh");
            list.Add("Tiền Giang");
            list.Add("Trà Vinh");
            list.Add("Vĩnh Long");
            return list;
        }
    }
}
