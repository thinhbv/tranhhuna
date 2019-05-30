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
using System.Security.Cryptography.X509Certificates;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using Google.Apis.Drive.v3.Data;

namespace MyWeb.Admins
{
	public partial class UploadFiles : System.Web.UI.Page
	{
		static string[] Scopes = { DriveService.Scope.Drive };
		static string ApplicationName = "Application_upload_file_zip";
		String serviceAccountEmail = "filetranh@quickstart-1558691445868.iam.gserviceaccount.com";
		protected void Page_Load(object sender, EventArgs e)
		{
			GoogleConnect.ClientId = "449114385123-5qbi7gtkh7isv98294knrio8r2tmcofh.apps.googleusercontent.com";
			GoogleConnect.ClientSecret = "ppi6y6pXOE6UKGYweoYfnd1g";
			GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];
			GoogleConnect.API = EnumAPI.Drive;
			if (!string.IsNullOrEmpty(Request.QueryString["code"]))
			{
				string code = Request.QueryString["code"];
				string json = GoogleConnect.Fetch("me", code);
				GoogleDriveFiles files = new JavaScriptSerializer().Deserialize<GoogleDriveFiles>(json);
				dlFiles.DataSource = files.Items;
				dlFiles.DataBind();
				pnlProfile.Visible = true;
				btnLogin.Enabled = false;
			}
			if (Request.QueryString["error"] == "access_denied")
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
			}
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
				request.Fields = "id,name,size,description,createdTime,webViewLink";
				request.Upload();
			}

			var file = request.ResponseBody;

		}
		private ServiceAccountCredential GetCredentials()
		{
			string[] scopes = new string[] { DriveService.Scope.Drive }; // Full access

			var keyFilePath = Server.MapPath(@"/key.p12");    // Downloaded from https://console.developers.google.com
			var serviceAccountEmail = "filetranh@quickstart-1558691445868.iam.gserviceaccount.com";  // found https://console.developers.google.com

			//loading the Key file
			var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
			var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
			{
				Scopes = scopes
			}.FromCertificate(certificate));
			//UserCredential credential;

			//using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
			//{
			//	string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

			//	credPath = Path.Combine(credPath, "client_secreta.json");

			//	credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
			//		GoogleClientSecrets.Load(stream).Secrets,
			//		Scopes,
			//		"user",
			//		CancellationToken.None).Result;
			//	Span1.Text = string.Format("Credential file saved to: " + credPath);
			//}
			return credential;
		}

		protected void lbtUpload_Click(object sender, EventArgs e)
		{
			try
			{
				ServiceAccountCredential credential;

				credential = GetCredentials();

				// Create Drive API service.
				var service = new DriveService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = credential,
					ApplicationName = ApplicationName,
				});
				//string pageToken = null;
				//do
				//{
				//	ListFiles(service, ref pageToken);

				//} while (pageToken != null);
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
							UploadImage("D:\\Download\\W4_49.pdf", service, folderid);
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
		protected void Login(object sender, EventArgs e)
		{
			GoogleConnect.Authorize("https://www.googleapis.com/auth/drive.readonly");
		}

		protected void Clear(object sender, EventArgs e)
		{
			//GoogleConnect.Clear();
		}

		public class GoogleDriveFiles
		{
			public List<GoogleDriveFile> Items { get; set; }
		}

		public class GoogleDriveFile
		{
			public string Id { get; set; }
			public string Title { get; set; }
			public string OriginalFilename { get; set; }
			public string ThumbnailLink { get; set; }
			public string IconLink { get; set; }
			public string WebContentLink { get; set; }
			public DateTime CreatedDate { get; set; }
			public DateTime ModifiedDate { get; set; }
			public GoogleDriveFileLabel Labels { get; set; }
		}

		public class GoogleDriveFileLabel
		{
			public bool Starred { get; set; }
			public bool Hidden { get; set; }
			public bool Trashed { get; set; }
			public bool Restricted { get; set; }
			public bool Viewed { get; set; }
		}
		private void ListFiles(DriveService service, ref string pageToken)
		{
			List<Google.Apis.Drive.v3.Data.File> result = new List<Google.Apis.Drive.v3.Data.File>();
			FilesResource.ListRequest request = service.Files.List();

			do
			{
				try
				{
					request.PageSize = 1;
					request.Fields = "nextPageToken, files(id, name)";
					request.Q = "mimeType='image/*'";
					FileList files = request.Execute();

					result.AddRange(files.Files);
					request.PageToken = files.NextPageToken;
				}
				catch (Exception e)
				{
					Console.WriteLine("An error occurred: " + e.Message);
					request.PageToken = null;
				}
			} while (!String.IsNullOrEmpty(request.PageToken));
		}
	}
}