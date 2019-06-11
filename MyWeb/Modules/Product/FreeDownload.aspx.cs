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
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using System.Reflection;
using System.Threading;
using Google.Apis.Services;
using System.IO;
using Google.Apis.Download;
using System.Net;

namespace MyWeb.Modules.Product
{
	public partial class FreeDownload : System.Web.UI.Page
	{
		private bool isValidDownload = false;
		private bool isLogin = false;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (Session["Id"] != null)
				{
					isLogin = true;
					DataTable dtCount = DownloadHistoryService.DownloadHistory_GetByUserId(Session["Id"].ToString());
					if (dtCount.Rows.Count < 2)
					{
						isValidDownload = true;
					}
				}
				if (!IsPostBack)
				{
					DataTable dt = FilesUploadService.FilesUpload_GetByTop("", "Active = 1", "Name");
					rptProducts.DataSource = dt;
					rptProducts.DataBind();
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}

		}

		protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			//try
			//{
			//	RepeaterItem item = e.Item;
			//	if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
			//	{
			//		LinkButton hlDownload = (LinkButton)item.FindControl("hlDownload");
			//		if (hlDownload != null)
			//		{
			//			if (isValidDownload)
			//			{
			//				hlDownload.Enabled = true;
			//				//hlDownload.NavigateUrl = DataBinder.Eval(item.DataItem, "WebContentLink").ToString(); ;
			//			}
			//			else
			//			{
			//				hlDownload.Enabled = false;
			//			}
			//		}
			//	}
			//}
			//catch (Exception ex)
			//{
			//	MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			//}
		}

		protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "download":
					try
					{
						if (isLogin)
						{
							if (isValidDownload)
							{
								DataTable file = FilesUploadService.FilesUpload_GetByTop("1", "Id='" + strCA + "'", "");
								DownloadHistory history = new DownloadHistory();
								history.UserId = Session["Id"].ToString();
								history.FileId = strCA;
								history.DownloadedDate = DateTime.Now.ToString("MM/dd/yyyy");
								DownloadHistoryService.DownloadHistory_Insert(history);
								Response.Redirect(file.Rows[0]["WebContentLink"].ToString(), false);
							}
							else
							{
								WebMsgBox.Show("Bạn chỉ có thể tải miễn phí 2 lần/ngày");
							}
						}
						else
						{
							Response.Redirect("/thanh-vien/dang-nhap", false);
						}
					}
					catch (Exception ex)
					{
						MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
					}

					break;
			}
		}
		private DriveService CreateDriveService()
		{
			DriveService service = null;
			string UserId = "user-id";
			GoogleAuthorizationCodeFlow flow;
			using (var stream = new FileStream(Server.MapPath(@"/client_secrets.json"), FileMode.Open, FileAccess.Read))
			{
				flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
				{
					DataStore = new FileDataStore(Server.MapPath(@"/Drive.Sample.Store")),
					ClientSecretsStream = stream,
					Scopes = new[] { DriveService.Scope.Drive }
				});
			}
			var uri = Request.Url.ToString();
			var code = Request["code"];
			if (code != null)
			{
				var token = flow.ExchangeCodeForTokenAsync(UserId, code,
					uri.Substring(0, uri.IndexOf("?")), CancellationToken.None).Result;

				// Extract the right state.
				var oauthState = AuthWebUtility.ExtracRedirectFromState(
					flow.DataStore, UserId, Request["state"]).Result;
				Response.Redirect(oauthState);
			}
			else
			{
				var result = new AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(UserId,
					CancellationToken.None).Result;
				if (result.RedirectUri != null)
				{
					// Redirect the user to the authorization server.
					Response.Redirect(result.RedirectUri);
				}
				else
				{
					// The data store contains the user credential, so the user has been already authenticated.
					service = new DriveService(new BaseClientService.Initializer
					{
						ApplicationName = "Google Drive API",
						HttpClientInitializer = result.Credential
					});
				}
			}
			return service;
		}
	}
}