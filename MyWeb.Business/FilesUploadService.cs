using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class FilesUploadService
	{
		private static UploadFilesDAL db = new UploadFilesDAL();
		#region[FilesUpload_GetByTop]
		public static DataTable FilesUpload_GetByTop(string Top, string Where, string Order)
		{
			return db.FilesUpload_GetByTop(Top, Where, Order);
		}
		#endregion
		#region[FilesUpload_Insert]
		public static bool FilesUpload_Insert(FilesUpload data)
		{
			return db.FilesUpload_Insert(data);
		}
		#endregion
		#region[FilesUpload_Update]
		public static bool FilesUpload_Update(FilesUpload data)
		{
			return db.FilesUpload_Update(data);
		}
		#endregion
		#region[FilesUpload_Delete]
		public static bool FilesUpload_Delete(string Id)
		{
			return db.FilesUpload_Delete(Id);
		}
		#endregion
	}
}
