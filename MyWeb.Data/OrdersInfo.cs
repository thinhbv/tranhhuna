using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class Orders
	{
		#region[Declare variables]
		private string _Id;
		private string _Name;
		private string _Address;
		private string _Phone;
		private string _Email;
		private string _Products;
		private string _Prices;
		private string _Status;
		private string _CreateDate;
		private string _Method;
		private string _Bill;
		#endregion
		#region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string Name { get { return _Name; } set { _Name = value; } }
		public string Address { get { return _Address; } set { _Address = value; } }
		public string Phone { get { return _Phone; } set { _Phone = value; } }
		public string Email { get { return _Email; } set { _Email = value; } }
		public string Products { get { return _Products; } set { _Products = value; } }
		public string Prices { get { return _Prices; } set { _Prices = value; } }
		public string Status { get { return _Status; } set { _Status = value; } }
		public string CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
		public string Method { get { return _Method; } set { _Method = value; } }
		public string Bill { get { return _Bill; } set { _Bill = value; } }
		#endregion
		#region[Advertise IDataReader]
		public Orders OrdersIDataReader(IDataReader dr)
		{
			Data.Orders obj = new Data.Orders();
			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Address = (dr["Address"] is DBNull) ? string.Empty : dr["Address"].ToString();
			obj.Phone = (dr["Phone"] is DBNull) ? string.Empty : dr["Phone"].ToString();
			obj.Email = (dr["Email"] is DBNull) ? string.Empty : dr["Email"].ToString();
			obj.Products = (dr["Products"] is DBNull) ? string.Empty : dr["Products"].ToString();
			obj.Prices = (dr["Prices"] is DBNull) ? string.Empty : dr["Prices"].ToString();
			obj.Status = (dr["Status"] is DBNull) ? string.Empty : dr["Status"].ToString();
			obj.CreateDate = (dr["CreateDate"] is DBNull) ? string.Empty : dr["CreateDate"].ToString();
			obj.Method = (dr["Method"] is DBNull) ? string.Empty : dr["Method"].ToString();
			obj.Bill = (dr["Bill"] is DBNull) ? string.Empty : dr["Bill"].ToString();
			return obj;
		}
		#endregion
	}
}