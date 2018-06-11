using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MyWeb.Data;
using System.Collections;

namespace MyWeb.Business
{
	public class OrdersService
	{
		private static OrdersDAL db = new OrdersDAL();
		#region[Orders_GetById]
		public static DataTable Orders_GetById(string Id)
		{
			return db.Orders_GetById(Id);
		}
		#endregion
		#region[Orders_GetByTop]
		public static DataTable Orders_GetByTop(string Top, string Where, string Order)
		{
			return db.Orders_GetByTop(Top, Where, Order);
		}
		#endregion
		#region[Orders_GetByAll]
		public static List<Data.Orders> Orders_GetByAll()
		{
			return db.Orders_GetByAll();
		}
		#endregion
		#region[Orders_Insert]
		public static bool Orders_Insert(Orders data)
		{
			return db.Orders_Insert(data);
		}
		#endregion
		#region[Orders_Delete]
		public static bool Orders_Delete(string Id)
		{
			return db.Orders_Delete(Id);
		}
		#endregion
		#region[Orders_Add]
		public static string Orders_Add(string id, string orderid, string quantity)
		{
			return db.Orders_Add(id, orderid, quantity);
		}
		#endregion

		#region[Delete_Item]
		public static string DeleteItem(string id)
		{
			return db.DeleteItem(id);
		}
		#endregion

		#region[PurchaseProduct]
		public static bool PurchaseProduct(Orders order, Hashtable htData)
		{
			return db.PurchaseProduct(order, htData);
		}
		#endregion
	}
}
