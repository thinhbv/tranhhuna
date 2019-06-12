using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Data
{
	public class FilesUpload
	{

		#region[Declare variables]
		private string _Id;
		private string _ProductId;
		private string _Name;
		private string _ThumbnailLink;
		private string _IconLink;
		private string _WebContentLink;
		private string _OriginalFileName;
		private string _Active;
		#endregion
		#region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string ProductId { get { return _ProductId; } set { _ProductId = value; } }
		public string Name { get { return _Name; } set { _Name = value; } }
		public string ThumbnailLink { get { return _ThumbnailLink; } set { _ThumbnailLink = value; } }
		public string IconLink { get { return _IconLink; } set { _IconLink = value; } }
		public string WebContentLink { get { return _WebContentLink; } set { _WebContentLink = value; } }
		public string OriginalFileName { get { return _OriginalFileName; } set { _OriginalFileName = value; } }
		public string Active { get { return _Active; } set { _Active = value; } }
		#endregion
	}
}
