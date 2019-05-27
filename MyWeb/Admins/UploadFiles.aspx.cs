using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace MyWeb.Admins
{
	public partial class UploadFiles : System.Web.UI.Page
	{
		static string[] Scopes = { DriveService.Scope.Drive };
		static string ApplicationName = "Application_upload_file_zip";
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		private void UploadImage(string path, DriveService service, string folderUpload)
		{
			var fileMetadata = new Google.Apis.Drive.v3.Data.File();
			fileMetadata.Name = Path.GetFileName(path);
			fileMetadata.MimeType = "image/*";

			fileMetadata.Parents = new List<String>() { folderUpload };

			FilesResource.CreateMediaUpload request;
			using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
			{
				request = service.Files.Create(fileMetadata, stream, "image/*");
				request.Fields = "id";
				request.Upload();
			}

			var file = request.ResponseBody;

		}
		private UserCredential GetCredentials()
		{
			UserCredential credential;

			using (var stream = new FileStream(Server.MapPath("/credentials.json"), FileMode.Open, FileAccess.Read))
			{
				string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

				credPath = Path.Combine(credPath, "token.json");

				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					Scopes,
					"user",
					CancellationToken.None,
					new FileDataStore(credPath, true)).Result;
				Span1.Text = string.Format("Credential file saved to: " + credPath);
			}

			return credential;
		}

		protected void lbtUpload_Click(object sender, EventArgs e)
		{
			try
			{
				UserCredential credential;

				credential = GetCredentials();

				// Create Drive API service.
				var service = new DriveService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = credential,
					ApplicationName = ApplicationName,
				});

				string folderid;
				//get folder id by name
				var fileMetadatas = new Google.Apis.Drive.v3.Data.File()
				{
					Name = txtFolderNameUpload.Text,
					MimeType = "application/vnd.google-apps.folder"
				};
				var requests = service.Files.Create(fileMetadatas);
				requests.Fields = "id";
				var files = requests.Execute();
				folderid = files.Id;

				HttpFileCollection uploadedFiles = Request.Files;
				if (uploadedFiles.Count > 0)
				{
					for (int i = 0; i < uploadedFiles.Count; i++)
					{
						HttpPostedFile userPostedFile = uploadedFiles[i];
						Thread thread = new Thread(() =>
						{
							UploadImage(userPostedFile.FileName, service, folderid);
							lblMsg.Text += userPostedFile.FileName + " => upload thành công..." + "<br/>";
						});
						thread.IsBackground = true;
						thread.Start();

					}

				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}