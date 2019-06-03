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
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace MyWeb.Admins
{
	public partial class UploadFiles : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		DataTable dt = new DataTable();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				BindGrid();
			}
		}

		private void BindGrid()
		{
			grdUploadFiles.DataSource = FilesUploadService.FilesUpload_GetByTop("", "", "Id DESC");
			grdUploadFiles.DataBind();
			if (grdUploadFiles.PageCount <= 1)
			{
				grdUploadFiles.PagerStyle.Visible = false;
			}
			else
			{
				grdUploadFiles.PagerStyle.Visible = true;
			}
		}

		protected void grdUploadFiles_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			ListItemType itemType = e.Item.ItemType;
			if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
			{
				if (itemType == ListItemType.Header)
				{
					object checkBox = e.Item.FindControl("chkSelectAll");
					if ((checkBox != null))
					{
						((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
					}
				}
				else
				{
					string tableRowId = grdUploadFiles.ClientID + "_row" + e.Item.ItemIndex.ToString();
					e.Item.Attributes.Add("id", tableRowId);
					object checkBox = e.Item.FindControl("chkSelect");
					if ((checkBox != null))
					{
						e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
						e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex.ToString() + ")");
						((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex.ToString() + ")");
					}
				}
			}
		}

		protected void grdUploadFiles_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdUploadFiles.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdUploadFiles_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
					dt = FilesUploadService.FilesUpload_GetByTop("1", "Id='" + Id + "'", "");

					txtName.Text = dt.Rows[0]["Name"].ToString();
					txtImage.Text = dt.Rows[0]["ThumbnailLink"].ToString();
					imgImage.ImageUrl = dt.Rows[0]["ThumbnailLink"].ToString().Length > 0 ? dt.Rows[0]["ThumbnailLink"].ToString() : "";
					chkActive.Checked = dt.Rows[0]["Active"].ToString() == "1" || dt.Rows[0]["Active"].ToString() == "True";
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update [FilesUpload] set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					FilesUploadService.FilesUpload_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			ControlClass.ResetControlValues(this);
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdUploadFiles.Items.Count; i++)
			{
				item = grdUploadFiles.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						FilesUploadService.FilesUpload_Delete(strId);
					}
				}
			}
			grdUploadFiles.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				Data.FilesUpload obj = new Data.FilesUpload();
				obj.Id = Id;
				obj.Name = txtName.Text;
				obj.ThumbnailLink = txtImage.Text;
				obj.IconLink = "";
				obj.WebContentLink = "";
				obj.Active = chkActive.Checked ? "1" : "0";
				if (Insert == true)
				{
					FilesUploadService.FilesUpload_Insert(obj);
				}
				else
				{
					FilesUploadService.FilesUpload_Update(obj);
				}
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
				Insert = false;
			}
		}

		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			BindGrid();
			Insert = false;
		}

		protected void lbtSynch_Click(object sender, EventArgs e)
		{
			try
			{
				DriveService service = CreateDriveService();
				string pageToken = null;
				List<Google.Apis.Drive.v3.Data.File> lstFiles;
				do
				{
					lstFiles = ListFiles(service, ref pageToken);

				} while (pageToken != null);
				lstFiles = lstFiles.Distinct().ToList();
				string json = Newtonsoft.Json.JsonConvert.SerializeObject(lstFiles);
				DataTable pDt = JsonConvert.DeserializeObject<DataTable>(json);
				foreach (var column in pDt.Columns.Cast<DataColumn>().ToArray())
				{
					if (pDt.AsEnumerable().All(dr => dr.IsNull(column)))
						pDt.Columns.Remove(column);
				}
				pDt.Columns.Add("OriginalFileName", typeof(string));
				if (pDt.Columns["thumbnailLink"] == null)
				{
					pDt.Columns.Add("thumbnailLink", typeof(string));
				}
				pDt.Columns.Add("Active", typeof(int));
				pDt.Columns["Id"].SetOrdinal(0);
				pDt.Columns["Name"].SetOrdinal(1);
				pDt.Columns["thumbnailLink"].SetOrdinal(2);
				pDt.Columns["IconLink"].SetOrdinal(3);
				pDt.Columns["WebContentLink"].SetOrdinal(4);
				for (int i = 0; i < pDt.Rows.Count; i++)
				{
					pDt.Rows[i]["Active"] = 1;
				}
				pDt.AcceptChanges();
				BulkInsert(pDt);
				BindGrid();
				WebMsgBox.Show("Đồng bộ dữ liệu thành công!");
			}
			catch (Exception)
			{
			}
		}
		private List<Google.Apis.Drive.v3.Data.File> ListFiles(DriveService service, ref string pageToken)
		{		
			string owner = "buithinh.tt1@gmail.com";
			List<Google.Apis.Drive.v3.Data.File> lstFiles = new List<Google.Apis.Drive.v3.Data.File>();
			// Define parameters of request.
			FilesResource.ListRequest listRequest = service.Files.List();
			listRequest.PageSize = 10;
			listRequest.Fields = "nextPageToken, files(id,name,thumbnailLink,webContentLink,iconLink)";
			listRequest.PageToken = pageToken;
			listRequest.Q = "(mimeType='application/rar' OR mimeType='application/zip') and '" + owner + "' in owners and createdTime > '2019-05-01T12:00:00'";

			// List files.
			var request = listRequest.Execute();
			if (request.Files != null && request.Files.Count > 0)
			{
				lstFiles.AddRange(request.Files);

				pageToken = request.NextPageToken;

				if (request.NextPageToken != null)
				{
					Console.ReadLine();
				}
			}
			return lstFiles;
		}
		private void BulkInsert(DataTable dt)
		{
			using (SqlConnection connection = SqlDataProvider.GetConnection())
			{
				string TableName = "FilesUpload";
				try
				{
					// make sure to enable triggers
					// more on triggers in next post
					SqlBulkCopy bulkCopy =
						new SqlBulkCopy
						(
						connection,
						SqlBulkCopyOptions.TableLock |
						SqlBulkCopyOptions.FireTriggers |
						SqlBulkCopyOptions.UseInternalTransaction,
						null
						);

					// set the destination table name
					bulkCopy.DestinationTableName = TableName;
					SqlCommand cmd = new SqlCommand("TRUNCATE TABLE " + TableName, connection);
					cmd.ExecuteNonQuery();
					// write the data in the "dataTable"
					bulkCopy.WriteToServerAsync(dt);
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					connection.Close();
				}
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