using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Common;
using System.Drawing;

namespace MyWeb.Admins
{
    public partial class UploadImages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!this.IsPostBack)
			{
				DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath("~/Uploads/"));
				this.PopulateTreeView(rootInfo, null);
			}
        }

		protected void lbtUpload_Click(object sender, EventArgs e)
		{
			string filePathImage = TreeView1.SelectedValue;
			string filePathImageThumbs = filePathImage.Replace("Uploads\\", "Uploads\\_thumbs\\");
			HttpFileCollection uploadedFiles = Request.Files;
			Span1.Text = string.Empty;

			for (int i = 0; i < uploadedFiles.Count; i++)
			{
				HttpPostedFile userPostedFile = uploadedFiles[i];
				string filename = userPostedFile.FileName;
				System.Drawing.Image thumb = null;
				System.Drawing.Image image = null;
				try
				{
					if (userPostedFile.ContentLength > 0)
					{
						Span1.Text += "<u>File " + userPostedFile.FileName + "</u><br>";
						if (userPostedFile.ContentLength >= 12600580) //<5MB
						{
							Span1.Text += "Kết quả: File quá lớn => Thất bại<p>";
						}
						else
						{
							userPostedFile.SaveAs(filePathImage + "\\" + filename);
							//Create image thumbnail
							image = System.Drawing.Image.FromFile(filePathImage + "\\" + filename);
							if (image.Width >= image.Height)
							{
								thumb = image.GetThumbnailImage(Consts.MAX_IMAGE_THUMBNAIL, Convert.ToInt32((image.Height / (image.Width / Consts.MAX_IMAGE_THUMBNAIL))), () => false, IntPtr.Zero);
							}
							else
							{
								thumb = image.GetThumbnailImage(Convert.ToInt32((image.Width / (image.Height / Consts.MAX_IMAGE_THUMBNAIL))), Consts.MAX_IMAGE_THUMBNAIL, () => false, IntPtr.Zero);
							}
							if (image != null)
							{
								image.Dispose();
								image = null;
							}
							thumb.Save(filePathImageThumbs + "\\" + filename);
							Span1.Text += "Kết quả: Thành công<p>";
						}
					}
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "", ex.Message);
					Span1.Text += "Kết quả: Thất bại <br>";
				}
				finally
				{
					if (image != null)
					{
						image.Dispose();
						image = null;
					}
					if (thumb != null)
					{
						thumb.Dispose();
						thumb = null;
					}
				}
			}
		}
		private void PopulateTreeView(DirectoryInfo dirInfo, TreeNode treeNode)
		{
			foreach (DirectoryInfo directory in dirInfo.GetDirectories())
			{
				TreeNode directoryNode = new TreeNode
				{
					Text = directory.Name,
					Value = directory.FullName
				};

				if (treeNode == null)
				{
					//If Root Node, add to TreeView.
					if (directoryNode.Value.IndexOf("_thumbs") < 0)
					{
						TreeView1.Nodes.Add(directoryNode);
					}
				}
				else
				{
					//If Child Node, add to Parent Node.
					treeNode.ChildNodes.Add(directoryNode);
				}

				PopulateTreeView(directory, directoryNode);
			}
		}
    }
}