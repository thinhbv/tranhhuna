using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Data
{
	public class Chude
	{
		#region[Declare variables]
		private string _Id;
		private string _Name;
		private string _Ord;
		private string _Active;
		#endregion
		#region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string Name { get { return _Name; } set { _Name = value; } }
		public string Ord { get { return _Ord; } set { _Ord = value; } }
		public string Active { get { return _Active; } set { _Active = value; } }
		#endregion
	}
}
