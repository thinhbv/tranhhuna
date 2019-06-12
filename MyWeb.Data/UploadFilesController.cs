using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Data
{
	public class UploadFilesDAL : SqlDataProvider
	{
		static SqlCommand dbCmd;

		#region[FilesUpload_GetByTop]
		public DataTable FilesUpload_GetByTop(string Top, string Where, string Order)
		{
			dbCmd = new SqlCommand("sp_FilesUpload_GetByTop");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
			dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
			dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
			return GetData(dbCmd);
		}
		#endregion
		#region[FilesUpload_Insert]
		public bool FilesUpload_Insert(FilesUpload data)
		{
			dbCmd = new SqlCommand("sp_FilesUpload_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@ProductId", data.ProductId));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@ThumbnailLink", data.ThumbnailLink));
			dbCmd.Parameters.Add(new SqlParameter("@IconLink", data.IconLink));
			dbCmd.Parameters.Add(new SqlParameter("@WebContentLink", data.WebContentLink));
			dbCmd.Parameters.Add(new SqlParameter("@OriginalFileName", data.OriginalFileName));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("FilesUpload");
			return true;
		}
		#endregion
		#region[FilesUpload_Update]
		public bool FilesUpload_Update(FilesUpload data)
		{
			dbCmd = new SqlCommand("sp_FilesUpload_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@ProductId", data.ProductId));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@ThumbnailLink", data.ThumbnailLink));
			dbCmd.Parameters.Add(new SqlParameter("@IconLink", data.IconLink));
			dbCmd.Parameters.Add(new SqlParameter("@WebContentLink", data.WebContentLink));
			dbCmd.Parameters.Add(new SqlParameter("@OriginalFileName", data.OriginalFileName));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("FilesUpload");
			return true;
		}
		#endregion
		#region[FilesUpload_Delete]
		public bool FilesUpload_Delete(string Id)
		{
			dbCmd = new SqlCommand("sp_FilesUpload_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("FilesUpload");
			return true;
		}
		#endregion
	}
}
