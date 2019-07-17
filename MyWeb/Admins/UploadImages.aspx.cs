using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MyWeb.Admins
{
    public partial class UploadImages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Span1.Text = string.Empty;
			if (!this.IsPostBack)
			{
				DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath("/Uploads/"));
				this.PopulateTreeView(rootInfo, null);
			}
        }

		protected void lbtUpload_Click(object sender, EventArgs e)
		{
			string filePathImage = TreeView1.SelectedValue;
			if (string.IsNullOrEmpty(filePathImage))
			{
				WebMsgBox.Show("Vui lòng chọn thư mục upload!");
				return;
			}
			string filePathImageThumbs = filePathImage.Replace("Uploads\\", "Uploads\\_thumbs\\");
			if (Directory.Exists(filePathImageThumbs) == false)
			{
				Directory.CreateDirectory(filePathImageThumbs);
			}
			HttpFileCollection uploadedFiles = Request.Files;
			Span1.Text = string.Empty;
			if (uploadedFiles.Count == 0)
			{
				WebMsgBox.Show("Vui lòng chọn file upload!");
				return;
			}
			for (int i = 0; i < uploadedFiles.Count; i++)
			{
				HttpPostedFile userPostedFile = uploadedFiles[i];
				string filename = userPostedFile.FileName;
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
							using (System.Drawing.Image image = System.Drawing.Image.FromFile(filePathImage + "\\" + filename, true))
							{
								using (Bitmap bmp = new Bitmap(image))
								{
									Save(bmp, 250, 250, 50, filePathImageThumbs + "\\" + filename);
								}
							}
							Span1.Text += "Kết quả: Thành công<p>";
						}
					}
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "", ex.Message + "\n" +ex.StackTrace);
					Span1.Text += "Kết quả: Thất bại <br>";
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
		private bool ThumbnailCallback()
		{
			return false;
		}
		/// <summary>
		/// Method to resize, convert and save the image.
		/// </summary>
		/// <param name="image">Bitmap image.</param>
		/// <param name="maxWidth">resize width.</param>
		/// <param name="maxHeight">resize height.</param>
		/// <param name="quality">quality setting value.</param>
		/// <param name="filePath">file path.</param>      
		public void Save(Bitmap image, int maxWidth, int maxHeight, int quality, string filePath)
		{
			// Get the image's original width and height
			int originalWidth = image.Width;
			int originalHeight = image.Height;

			// To preserve the aspect ratio
			float ratioX = (float)maxWidth / (float)originalWidth;
			float ratioY = (float)maxHeight / (float)originalHeight;
			float ratio = Math.Max(ratioX, ratioY);

			// New width and height based on aspect ratio
			int newWidth = (int)(originalWidth * ratio);
			int newHeight = (int)(originalHeight * ratio);

			// Convert other formats (including CMYK) to RGB.
			Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

			// Draws the image in the specified size with quality mode set to HighQuality
			using (Graphics graphics = Graphics.FromImage(newImage))
			{
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.DrawImage(image, 0, 0, newWidth, newHeight);
			}

			// Get an ImageCodecInfo object that represents the JPEG codec.
			ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

			// Create an Encoder object for the Quality parameter.
			Encoder encoder = Encoder.Quality;

			// Create an EncoderParameters object. 
			EncoderParameters encoderParameters = new EncoderParameters(1);

			// Save the image as a JPEG file with quality level.
			EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
			encoderParameters.Param[0] = encoderParameter;
			newImage.Save(filePath, imageCodecInfo, encoderParameters);
		}

		/// <summary>
		/// Method to get encoder infor for given image format.
		/// </summary>
		/// <param name="format">Image format</param>
		/// <returns>image codec info.</returns>
		private ImageCodecInfo GetEncoderInfo(ImageFormat format)
		{
			foreach (ImageCodecInfo item in ImageCodecInfo.GetImageDecoders())
			{
				if (item.FormatID == format.Guid)
				{
					return item;
				}
			}
			return ImageCodecInfo.GetImageDecoders()[0];
		}

    }
}