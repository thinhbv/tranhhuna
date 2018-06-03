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

namespace MyWeb.Modules.Product
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected string name = string.Empty;
        protected string content = string.Empty;
        protected string sImage_01 = string.Empty;
        string id = string.Empty;
        string groupname = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["Id"] != null)
            {
                id = Page.RouteData.Values["Id"] as string;
            }
            if (Page.RouteData.Values["groupName"] != null)
            {
                groupname = Page.RouteData.Values["groupName"] as string;
            }
            if (!IsPostBack)
            {
                try
                {
                    if (Microsoft.VisualBasic.Information.IsNumeric(id))
                    {
                        DataTable pro = ProductService.Product_GetById(id);
                        if (pro.Rows.Count > 0)
                        {
                            name = pro.Rows[0]["Name"].ToString();
                            content = pro.Rows[0]["Content"].ToString();
                            ltrDetail.Text = pro.Rows[0]["Detail"].ToString();
                            sImage_01 = pro.Rows[0]["Image1"].ToString();

                            //Hiển thị sản phẩm tương tự
							DataTable dtRelated = ProductService.Product_GetByTop("6", "Active = 1 AND GroupId='" + pro.Rows[0]["GroupId"].ToString() + "' AND Id <> '" + id + "'", "Ord");
							if (dtRelated.Rows.Count > 0)
                            {
								rptProducts.DataSource = StringClass.ModifyDataProduct(dtRelated);
								rptProducts.DataBind();
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
}