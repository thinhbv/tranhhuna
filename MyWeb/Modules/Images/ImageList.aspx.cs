using System;
using System.Web;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Collections.Generic;

namespace MyWeb.Modules.Images
{
    public partial class ImageList : System.Web.UI.Page
    {
        protected string GroupId = string.Empty;
        protected string groupName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (Page.RouteData.Values["GroupId"] != null)
				{
					GroupId = Page.RouteData.Values["GroupId"] as string;
				}
				if (!IsPostBack)
				{
					List<GroupImages> listGrp = GroupImagesService.GroupImages_GetById(GroupId);
					if (listGrp.Count > 0)
					{
						groupName = listGrp[0].Name;
						List<Data.Images> listImages = ImagesService.Images_GetByTop("", "Active = 1 AND GroupId = '" + listGrp[0].Id + "'", "Ord");
						for (int i = 0; i < listImages.Count; i++)
						{
							ltrImages.Text += "<a href=http://unitegallery.net>\n";
							ltrImages.Text += "<img alt='" + groupName + "'\n";
							ltrImages.Text += "src='" + StringClass.ThumbImage(listImages[i].Image) + "'\n";
							ltrImages.Text += "data-image='" + listImages[i].Image + "'\n";
							ltrImages.Text += "style='display:none'></a>";
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