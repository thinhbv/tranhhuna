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
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Session["Id"] != null)
				{
					DataTable dtCount = DownloadHistoryService.DownloadHistory_GetByUserId(Session["Id"].ToString());
					if (dtCount.Rows.Count < 2)
					{
						isValidDownload = true;
					}
				}

				DataTable dt = FilesUploadService.FilesUpload_GetByTop("", "Active = 1", "Id DESC");
				rptProducts.DataSource = dt;
				rptProducts.DataBind();
			}
		}

		protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			try
			{
				RepeaterItem item = e.Item;
				if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
				{
					LinkButton hlDownload = (LinkButton)item.FindControl("hlDownload");
					if (hlDownload != null)
					{
						if (isValidDownload)
						{
							hlDownload.Enabled = true;
							//hlDownload.NavigateUrl = DataBinder.Eval(item.DataItem, "WebContentLink").ToString(); ;
						}
						else
						{
							hlDownload.Enabled = false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}

		protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "download":
					DataTable file = FilesUploadService.FilesUpload_GetByTop("1", "Id='" + strCA + "'", "");
					//Create a stream for the file
					Stream stream = null;

					//This controls how many bytes to read at a time and send to the client
					int bytesToRead = 10000;

					// Buffer to read bytes in chunk size specified above
					byte[] buffer = new Byte[bytesToRead];

					// The number of bytes read
					try
					{
						//Create a WebRequest to get the file
						HttpWebRequest fileReq = (HttpWebRequest)HttpWebRequest.Create(file.Rows[0]["WebContentLink"].ToString());

						//Create a response for this request
						HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();

						if (fileReq.ContentLength > 0)
							fileResp.ContentLength = fileReq.ContentLength;

						//Get the Stream returned from the response
						stream = fileResp.GetResponseStream();

						// prepare the response to the client. resp is the client Response
						var resp = HttpContext.Current.Response;

						//Indicate the type of data being sent
						resp.ContentType = "application/octet-stream";

						//Name the file 
						resp.AddHeader("Content-Disposition", "attachment; filename=\"" + file.Rows[0]["Name"].ToString() + "\"");
						resp.AddHeader("Content-Length", fileResp.ContentLength.ToString());

						int length;
						do
						{
							// Verify that the client is connected.
							if (resp.IsClientConnected)
							{
								// Read data into the buffer.
								length = stream.Read(buffer, 0, bytesToRead);

								// and write it out to the response's output stream
								resp.OutputStream.Write(buffer, 0, length);

								// Flush the data
								resp.Flush();

								//Clear the buffer
								buffer = new Byte[bytesToRead];
							}
							else
							{
								// cancel the download if client has disconnected
								length = -1;
							}
						} while (length > 0); //Repeat until no data is read
					}
					finally
					{
						if (stream != null)
						{
							//Close the input stream
							stream.Close();
						}
					}
					break;
			}
		}
	}
}