using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class DownloadHistoryService
	{
		private static DownloadHistoryDAL db = new DownloadHistoryDAL();
		#region[DownloadHistory_GetByUserId]
		public static DataTable DownloadHistory_GetByUserId(string Id)
		{
			return db.DownloadHistory_GetByUserId(Id);
		}
		#endregion
		
		#region[DownloadHistory_Insert]
		public static bool DownloadHistory_Insert(DownloadHistory data)
		{
			return db.DownloadHistory_Insert(data);
		}
		#endregion
		#region[DownloadHistory_Update]
		public static bool DownloadHistory_Update(DownloadHistory data)
		{
			return db.DownloadHistory_Update(data);
		}
		#endregion
		#region[DownloadHistory_Delete]
		public static bool DownloadHistory_Delete(string Id)
		{
			return db.DownloadHistory_Delete(Id);
		}
		#endregion
	}
}
