using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class OrderDetail
	{
		#region[Declare variables]
		private string _Id;
		private string _OrderId;
		private string _ProductId;
		private string _ProductName;
		private string _ProductImage;
		private string _Price;
		private string _Size;
		private string _Quantity;
		#endregion
		#region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string OrderId { get { return _OrderId; } set { _OrderId = value; } }
		public string ProductId { get { return _ProductId; } set { _ProductId = value; } }
		public string ProductName { get { return _ProductName; } set { _ProductName = value; } }
		public string ProductImage { get { return _ProductImage; } set { _ProductImage = value; } }
		public string Price { get { return _Price; } set { _Price = value; } }
		public string Size { get { return _Size; } set { _Size = value; } }
		public string Quantity { get { return _Quantity; } set { _Quantity = value; } }
		#endregion
		#region[Advertise IDataReader]
		public OrderDetail OrdersIDataReader(IDataReader dr)
		{
			Data.OrderDetail obj = new Data.OrderDetail();
			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
			obj.OrderId = (dr["OrderId"] is DBNull) ? string.Empty : dr["OrderId"].ToString();
			obj.ProductId = (dr["ProductId"] is DBNull) ? string.Empty : dr["ProductId"].ToString();
			obj.ProductName = (dr["ProductName"] is DBNull) ? string.Empty : dr["ProductName"].ToString();
			obj.ProductImage = (dr["ProductImage"] is DBNull) ? string.Empty : dr["ProductImage"].ToString();
			obj.Price = (dr["Price"] is DBNull) ? string.Empty : dr["Price"].ToString();
			obj.Size = (dr["Size"] is DBNull) ? string.Empty : dr["Size"].ToString();
			obj.Quantity = (dr["Quantity"] is DBNull) ? string.Empty : dr["Quantity"].ToString();
			return obj;
		}
		#endregion
	}
}