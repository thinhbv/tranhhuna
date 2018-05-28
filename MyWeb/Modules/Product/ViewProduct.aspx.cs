using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Modules.Product
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected string groupName = string.Empty;
        protected int totalcount = 0;
        protected string id = string.Empty;
        private string pagenum = "1";
        private Int16 perpage = 9;
        private string sort = Consts.SortNum.asc.ToString();
		private string keyword;
		List<GroupProduct> listGroup;
		DataTable dtPro;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["GroupId"] != null)
            {
                id = Page.RouteData.Values["GroupId"] as string;
            }

            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString[Consts.CON_PARAM_URL_PAGE] != null)
                    {
                        pagenum = Request.QueryString[Consts.CON_PARAM_URL_PAGE];
                    }

                    if (Request.QueryString[Consts.CON_PARAM_URL_SORT] != null)
                    {
                        sort = Request.QueryString[Consts.CON_PARAM_URL_SORT];
                    }
					if (Request.QueryString["key"] != null)
					{
						keyword = Request.QueryString["key"];
					}
                    if (Int16.TryParse(Request.QueryString[Consts.CON_PARAM_URL_NO], out perpage) == false)
                    {
                        perpage = 9;
                    }
					if (keyword == null)
					{
						if (Microsoft.VisualBasic.Information.IsNumeric(id) == false)
						{
							return;
						}
						listGroup = GroupProductService.GroupProduct_GetById(id);
						if (listGroup.Count > 0)
						{
							groupName = listGroup[0].Name;
							totalcount = ProductService.Product_GetCount(listGroup[0].Level);
							dtPro = ProductService.Product_Pagination(pagenum, perpage.ToString(), listGroup[0].Level);
							if (dtPro.Rows.Count > 0)
							{
								if (sort == Consts.SortNum.asc.ToString())
								{
									dtPro = dtPro.AsEnumerable().OrderBy(dr => dr.Field<string>("Name")).CopyToDataTable();
								}
								else
								{
									dtPro = dtPro.AsEnumerable().OrderByDescending(dr => dr.Field<string>("Name")).CopyToDataTable();
								}
								for (int i = 0; i < dtPro.Rows.Count; i++)
								{
									ltrProducts.Text += GeneralProductHtml(i + 1, dtPro);
								}
								ltrPaging.Text = GeneralPaging();
								List<GroupProduct> listGroupSub = GroupProductService.GroupProduct_GetByTop("", "Active = 1 AND len([Level]) < len('" + listGroup[0].Level + "') AND left([Level], 5) = left('" + listGroup[0].Level + "', 5)", "[Level]");
								if (listGroupSub.Count > 0)
								{
									for (int i = 0; i < listGroupSub.Count; i++)
									{
										ltrCrumb.Text += "<li class='crumb-" + (i + 1).ToString() + "'>\n";
										ltrCrumb.Text += "<a href='" + PageHelper.GeneralGroupUrl(Consts.CON_SAN_PHAM, listGroupSub[i].Id, listGroupSub[i].Name) + "' title='" + listGroupSub[i].Name + "'>" + listGroupSub[i].Name + "</a>\n";
										ltrCrumb.Text += "</li>\n";
									}
								}
							}
						}
					}
					else
					{
						if (keyword == string.Empty)
						{
							dtPro = ProductService.Product_GetByTop("", "Active = 1", "Ord DESC");
						}
						else
						{
							dtPro = ProductService.Product_GetByTop("", "Active = 1 AND (Name like '%" + StringClass.SqlInjection(keyword) + "%' OR Detail like '%" + StringClass.SqlInjection(keyword) + "%' OR Content like '%" + StringClass.SqlInjection(keyword) + "%')", "Ord DESC");
						}
						totalcount = dtPro.Rows.Count;
						for (int i = 0; i < dtPro.Rows.Count; i++)
						{
							ltrProducts.Text += GeneralProductHtml(i + 1, dtPro);
						}
						ltrCrumb.Text += "<li class='crumb-1'>" + Server.HtmlEncode(keyword) + "</li>\n";
					}
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message);
				}
            }
        }

        private string GeneralProductHtml(int i, DataTable dt)
        {
            string strHtml = string.Empty;
            if (i % 3 == 0)
            {
                strHtml = "<li class='border-line ";
            }
            if (strHtml == string.Empty)
            {
                strHtml = "<li class='ajax_block_product col-xs-12 col-sm-6 col-md-4 ";
            }
            else
            {
                strHtml += "ajax_block_product col-xs-12 col-sm-6 col-md-4 ";
            }
            if (i % 3 == 1)
            {
                strHtml += "first-in-line ";
            }
            if (i % 3 == 0)
            {
                strHtml += "last-in-line ";
            }
            if (i > 3)
            {
                strHtml += "last-line ";
            }
            if (i % 2 == 1)
            {
                strHtml += "first-item-of-tablet-line first-item-of-mobile-line";
            }
            else if (i % 2 == 0)
            {
                strHtml += "last-item-of-tablet-line last-item-of-mobile-line";
            }
            strHtml += "'>\n";
            i = i - 1;
            strHtml += "<div class='product-container'>\n";
            strHtml += "<div class='left-block'>\n";
            strHtml += "<div class='product-image-container'>\n";
            List<GroupProduct> listG = GroupProductService.GroupProduct_GetByTop("1", "Id='" + dt.Rows[i]["GroupId"].ToString() + "'", "");
            string strURL = PageHelper.GeneralDetailUrl(Consts.CON_SAN_PHAM, listG[0].Name, dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Name"].ToString());
            strHtml += "<a class='product_img_link' href='" + strURL + "' title='" + dt.Rows[i]["Name"].ToString() + "' itemprop='url'>\n";
            strHtml += "<img class='replace-2x img-responsive' src='" + StringClass.ThumbImage(dt.Rows[i]["Image1"].ToString()) + "' alt='" + dt.Rows[i]["Name"].ToString() + "' title='" + dt.Rows[i]["Name"].ToString() + "' itemprop='image' /></a>\n";
            strHtml += "</div></div>\n";
            strHtml += "<div class='right-block'>\n";
            strHtml += "<h5 itemprop='name'>\n";
            strHtml += "<a class='product-name' href='" + strURL + "' title='" + dt.Rows[i]["Name"].ToString() + "' itemprop='url'>\n";
            strHtml += "<span class='list-name'>" + dt.Rows[i]["Name"].ToString() + "</span>\n";
            strHtml += "<span class='grid-name'>" + dt.Rows[i]["Name"].ToString() + "</span>\n</a>\n</h5>\n";
            strHtml += "<p class='product-desc' itemprop='description'>\n";
            strHtml += "<span class='list-desc'>" + StringClass.FormatContentNews(dt.Rows[i]["Content"].ToString(), 100) + "</span>\n";
            strHtml += "<span class='grid-desc'>" + StringClass.FormatContentNews(dt.Rows[i]["Content"].ToString(), 100) + "</span>\n</p>\n";
            strHtml += "<div class='buttons customizable'>\n";
            strHtml += "<a class='quick-view' href='" + strURL + "'><span>Chi tiết</span></a>\n</div>\n";
            strHtml += "</div></div><!-- .product-container> -->";
            return strHtml;
        }

        private string GeneralPaging()
        {
            string strPaging = string.Empty;
            int totalPage = totalcount / perpage;
            int currPage;
            string urlOrigin = Request.Path;
            if (perpage != 9)
            {
                urlOrigin = urlOrigin + "?no=" + perpage;
            }
            if (sort.Equals(Consts.SortNum.desc.ToString()))
            {
                if (urlOrigin.IndexOf("?") > -1)
                {
                    urlOrigin = urlOrigin + "&sort=" + sort;
                }
                else
                {
                    urlOrigin = urlOrigin + "?sort=" + sort;
                }
            }
            if (urlOrigin.IndexOf("?") > -1)
            {
                urlOrigin = urlOrigin + "&" + Consts.CON_PARAM_URL_PAGE + "=";
            }
            else
            {
                urlOrigin = urlOrigin + "?" + Consts.CON_PARAM_URL_PAGE + "=";
            }

            if (int.TryParse(pagenum, out currPage) == false)
            {
                currPage = 1;
            }
            if (totalcount % perpage > 0)
            {
                totalPage = totalPage + 1;
            }
            if (currPage == 1)
            {
                strPaging += "<li id='pagination_previous_bottom' class='disabled pagination_previous'>\n";
                strPaging += "<span><i class='fa fa-chevron-left'></i><b>Previous</b></span></li>\n";
            }
            else
            {
                strPaging += "<li id='pagination_previous_bottom' class='pagination_previous'>\n";
                strPaging += "<a href='" + urlOrigin + (currPage - 1).ToString() + "'>";
                strPaging += "<b>Previous</b> <i class='fa fa-chevron-left'></i></a></li>\n";
            }
            if (totalPage < 6)
            {
                for (int i = 1; i < totalPage + 1; i++)
                {
                    if (currPage == i)
                    {
                        strPaging += "<li class='active current'><span><span>" + i.ToString() + "</span></span></li>\n";
                    }
                    else
                    {
                        strPaging += "<li><a href='" + urlOrigin + i.ToString() + "'><span>" + i.ToString() + "</span></a></li>\n";
                    }
                }
            }
            else
            {
                if (currPage < 6)
                {
                    for (int i = 1; i < 6 + 1; i++)
                    {
                        if (currPage == i)
                        {
                            strPaging += "<li class='active current'><span><span>" + i.ToString() + "</span></span></li>\n";
                        }
                        else
                        {
                            strPaging += "<li><a href='" + urlOrigin + i.ToString() + "'><span>" + i.ToString() + "</span></a></li>\n";
                        }
                    }
                    strPaging += "<li><span>...</span></li>\n";
                    strPaging += "<li><a href='" + urlOrigin + totalPage.ToString() + "'><span>" + totalPage.ToString() + "</span></a></li>\n";
                }
                else
                {
                    strPaging += "<li><a href='" + urlOrigin + "1'><span>1</span></a></li>\n";
                    strPaging += "<li><span>...</span></li>\n";
                    if (totalPage - currPage > 6)
                    {
                        strPaging += "<li><a href='" + urlOrigin + (currPage - 2).ToString() + "'><span>" + (currPage - 2).ToString() + "</span></a></li>\n";
                        strPaging += "<li><a href='" + urlOrigin + (currPage - 1).ToString() + "'><span>" + (currPage - 1).ToString() + "</span></a></li>\n";
                        strPaging += "<li class='active current'><span><span>" + currPage.ToString() + "</span></span></li>\n";
                        strPaging += "<li><a href='" + urlOrigin + (currPage + 1).ToString() + "'><span>" + (currPage + 1).ToString() + "</span></a></li>\n";
                        strPaging += "<li><a href='" + urlOrigin + (currPage + 2).ToString() + "'><span>" + (currPage + 2).ToString() + "</span></a></li>\n";
                    }
                    else
                    {
                        for (int i = 6; i < totalPage + 1; i++)
                        {
                            if (i == currPage)
                            {
                                strPaging += "<li class='active current'><span><span>" + i.ToString() + "</span></span></li>\n";
                            }
                            else
                            {
                                strPaging += "<li><a href='" + urlOrigin + i.ToString() + "'><span>" + i.ToString() + "</span></a></li>\n";
                            }
                        }
                    }
                }
            }
            if (currPage == totalPage)
            {
                strPaging += "<li id='pagination_next_bottom' class='disabled pagination_next'>\n";
                strPaging += "<span><i class='fa fa-chevron-right'></i><b>Next</b></span></li>\n";
            }
            else
            {
                strPaging += "<li id='pagination_next_bottom' class='pagination_next'>\n";
                strPaging += "<a href='" + urlOrigin + (currPage + 1).ToString() + "'>";
                strPaging += "<b>Next</b> <i class='fa fa-chevron-right'></i></a></li>\n";
            }

            return strPaging;
        }
    }
}