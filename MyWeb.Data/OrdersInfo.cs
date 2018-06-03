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
		private string _OrderId;
		private string _Name;
		private string _Address;
		private string _Tel;
		private string _Email;
		private string _PaymentMethod;
		private string _Price;
		private string _Status;
		private string _OrderDate;
		private string _Detail;
		private string _DeliveryDate;
		#endregion
		#region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string OrderId { get { return _OrderId; } set { _OrderId = value; } }
		public string Name { get { return _Name; } set { _Name = value; } }
		public string Address { get { return _Address; } set { _Address = value; } }
		public string Tel { get { return _Tel; } set { _Tel = value; } }
		public string Email { get { return _Email; } set { _Email = value; } }
		public string PaymentMethod { get { return _PaymentMethod; } set { _PaymentMethod = value; } }
		public string Price { get { return _Price; } set { _Price = value; } }
		public string Status { get { return _Status; } set { _Status = value; } }
		public string OrderDate { get { return _OrderDate; } set { _OrderDate = value; } }
		public string Detail { get { return _Detail; } set { _Detail = value; } }
		public string DeliveryDate { get { return _DeliveryDate; } set { _DeliveryDate = value; } }
		#endregion
		#region[Advertise IDataReader]
		public Orders OrdersIDataReader(IDataReader dr)
		{
			Data.Orders obj = new Data.Orders();
			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
			obj.OrderId = (dr["OrderId"] is DBNull) ? string.Empty : dr["OrderId"].ToString();
			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Address = (dr["Address"] is DBNull) ? string.Empty : dr["Address"].ToString();
			obj.Tel = (dr["Tel"] is DBNull) ? string.Empty : dr["Tel"].ToString();
			obj.Email = (dr["Email"] is DBNull) ? string.Empty : dr["Email"].ToString();
			obj.PaymentMethod = (dr["PaymentMethod"] is DBNull) ? string.Empty : dr["PaymentMethod"].ToString();
			obj.Price = (dr["Price"] is DBNull) ? string.Empty : dr["Price"].ToString();
			obj.Status = (dr["Status"] is DBNull) ? string.Empty : dr["Status"].ToString();
			obj.OrderDate = (dr["OrderDate"] is DBNull) ? string.Empty : dr["OrderDate"].ToString();
			obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
			obj.DeliveryDate = (dr["DeliveryDate"] is DBNull) ? string.Empty : dr["DeliveryDate"].ToString();
			return obj;
		}
		#endregion
	}
}