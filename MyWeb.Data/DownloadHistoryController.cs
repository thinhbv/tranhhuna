using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Data
{
	public class DownloadHistoryDAL: SqlDataProvider
	{
		static SqlCommand dbCmd;
		#region[DownloadHistory_GetByUserId]
		public DataTable DownloadHistory_GetByUserId(string UserId)
		{
			string strReturn = "Select Id From DownloadHistory Where UserId=@UserId And DownloadedDate = CONVERT(date, GETDATE())";
			SqlCommand cmd = GetCommand(strReturn);
			cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
			return GetData(cmd);
		}
		#endregion
		#region[DownloadHistory_Insert]
		public bool DownloadHistory_Insert(DownloadHistory data)
		{
			dbCmd = new SqlCommand("sp_DownloadHistory_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@UserId", data.UserId));
			dbCmd.Parameters.Add(new SqlParameter("@FileId", data.FileId));
			dbCmd.Parameters.Add(new SqlParameter("@DownloadedDate", data.DownloadedDate));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("DownloadHistory");
			return true;
		}
		#endregion
		#region[DownloadHistory_Update]
		public bool DownloadHistory_Update(DownloadHistory data)
		{
			dbCmd = new SqlCommand("sp_DownloadHistory_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@UserId", data.UserId));
			dbCmd.Parameters.Add(new SqlParameter("@FileId", data.FileId));
			dbCmd.Parameters.Add(new SqlParameter("@DownloadedDate", data.DownloadedDate));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("DownloadHistory");
			return true;
		}
		#endregion
		#region[DownloadHistory_Delete]
		public bool DownloadHistory_Delete(string Id)
		{
			dbCmd = new SqlCommand("sp_DownloadHistory_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("DownloadHistory");
			return true;
		}
		#endregion
	}
}
