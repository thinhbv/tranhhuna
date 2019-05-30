using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Data
{
	public class Customers
	{

		#region[Declare variables]
		private string _Id;
		private string _FullName;
		private string _UserName;
		private string _Password;
		private string _Email;
		private string _Phone;
		private string _Birthday;
		private string _CreatedDate;
		private string _Gender;
		private string _Ord;
		private string _Active;
		#endregion
		#region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string FullName { get { return _FullName; } set { _FullName = value; } }
		public string UserName { get { return _UserName; } set { _UserName = value; } }
		public string Password { get { return _Password; } set { _Password = value; } }
		public string Email { get { return _Email; } set { _Email = value; } }
		public string Phone { get { return _Phone; } set { _Phone = value; } }
		public string Birthday { get { return _Birthday; } set { _Birthday = value; } }
		public string CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
		public string Gender { get { return _Gender; } set { _Gender = value; } }
		public string Ord { get { return _Ord; } set { _Ord = value; } }
		public string Active { get { return _Active; } set { _Active = value; } }
		#endregion
	}
}
