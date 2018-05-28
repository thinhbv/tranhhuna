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
                        List<Data.Product> pro = ProductService.Product_GetById(id);
                        if (pro.Count > 0)
                        {
                            name = pro[0].Name;
                            content = pro[0].Content;
                            ltrDetail.Text = pro[0].Detail;
                            sImage_01 = pro[0].Image1;
                            //Hiển thị ảnh sản phẩm
                            ltrImages.Text = ShowImages(pro[0].Image2, "2");
                            ltrImages.Text += ShowImages(pro[0].Image3, "3");
                            ltrImages.Text += ShowImages(pro[0].Image4, "4");
                            ltrImages.Text += ShowImages(pro[0].Image5, "5");

                            //Hiển thị sản phẩm tương tự
							DataTable dtRelated = ProductService.Product_GetByTop("", "Active = 1 AND GroupId='" + pro[0].GroupId + "' AND Id <> '" + id + "'", "Ord");
							if (dtRelated.Rows.Count > 0)
                            {
                                ltrRelated.Text += "<ul id='bxslider' class='bxslider clearfix' style='width: 915%; position: relative; transition-duration: 0s; transform: translate3d(0px, 0px, 0px);'>\n";
								for (int i = 0; i < dtRelated.Rows.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        ltrRelated.Text += "<li class='item product-box ajax_block_product first_item product_accessories_description' style='float: left; list-style: none; position: relative; margin-right: 20px; width: 178px;'>\n";
                                    }
									else if (i == dtRelated.Rows.Count - 1)
                                    {
                                        ltrRelated.Text += "<li class='item product-box ajax_block_product last_item product_accessories_description' style='float: left; list-style: none; position: relative; margin-right: 20px; width: 178px;'>\n";
                                    }
                                    else
                                    {
                                        ltrRelated.Text += "<li class='item product-box ajax_block_product product_accessories_description' style='float: left; list-style: none; position: relative; margin-right: 20px; width: 178px;'>\n";
                                    }
                                    ltrRelated.Text += "<div class='product_desc'>\n";
									ltrRelated.Text += "<a href='" + PageHelper.GeneralDetailUrl(Consts.CON_SAN_PHAM, groupname, dtRelated.Rows[i]["Id"].ToString(), dtRelated.Rows[i]["Name"].ToString()) + "' title='" + dtRelated.Rows[i]["Name"].ToString() + "' class='product-image product_image'>\n";
									ltrRelated.Text += "<img class='lazyOwl' src='" + StringClass.ThumbImage(dtRelated.Rows[i]["Image1"].ToString()) + "' alt='" + dtRelated.Rows[i]["Name"].ToString() + "'></a>\n";
									ltrRelated.Text += "<div class='block_description'><span>" + StringClass.FormatContentNews(dtRelated.Rows[i]["Content"].ToString(), 50) + "</span></div>\n";
                                    ltrRelated.Text += "</div>\n";
                                    ltrRelated.Text += "<div class='s_title_block'>\n";
                                    ltrRelated.Text += "<h5 class='product-name'>\n";
									ltrRelated.Text += "<a href='" + PageHelper.GeneralDetailUrl(Consts.CON_SAN_PHAM, groupname, dtRelated.Rows[i]["Id"].ToString(), dtRelated.Rows[i]["Name"].ToString()) + "' title='" + dtRelated.Rows[i]["Name"].ToString() + "'>" + dtRelated.Rows[i]["Name"].ToString() + "</a>\n</h5>\n</div>\n";
                                    ltrRelated.Text += "</li>";
                                }
                                ltrRelated.Text += "</ul>";
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
        private string ShowImages(string path, string index)
        {
            string strReturn = string.Empty;
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }
            if (index == "5")
            {
                strReturn = "<li id='thumbnail_" + index + "' class='last'>\n";
            }
            else
            {
                strReturn = "<li id='thumbnail_" + index + "'>\n";
            }
            strReturn += "<a href='javascript:void(0);'\n";
            strReturn += "rel=\"{gallery: 'gal1', smallimage: '" + path + "',largeimage: '" + path + "'}\"\n";
            strReturn += "title='" + name + "'>\n";
            strReturn += "<img class='img-responsive' id='thumb_" + index + "' src='" + StringClass.ThumbImage(path) + "' alt='" + name + "' title='" + name + "' height='99' width='80' itemprop='image' />\n";
            strReturn += "</a></li>";
            return strReturn;
        }
    }
}