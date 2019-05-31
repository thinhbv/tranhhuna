using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Data
{
	public class DownloadHistory
	{
		#region[Declare variables]
		private string _Id;
		private string _UserId;
		private string _FileId;
		private string _DownloadedDate;
		#endregion
		#region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string UserId { get { return _UserId; } set { _UserId = value; } }
		public string FileId { get { return _FileId; } set { _FileId = value; } }
		public string DownloadedDate { get { return _DownloadedDate; } set { _DownloadedDate = value; } }
		#endregion
	}
}
