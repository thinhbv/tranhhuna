using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class OrderDetailService
	{
		private static OrderDetailDAL db = new OrderDetailDAL();
		#region[OrderDetail_GetById]
		public static DataTable OrderDetail_GetById(string Id)
		{
			return db.OrderDetail_GetById(Id);
		}
		#endregion
		#region[OrderDetail_GetByTop]
		public static DataTable OrderDetail_GetByTop(string Top, string Where, string Order)
		{
			return db.OrderDetail_GetByTop(Top, Where, Order);
		}
		#endregion
		#region[OrderDetail_Insert]
		public static bool OrderDetail_Insert(OrderDetail data)
		{
			return db.OrderDetail_Insert(data);
		}
		#endregion
		#region[OrderDetail_Update]
		public static bool OrderDetail_Update(OrderDetail data)
		{
			return db.OrderDetail_Update(data);
		}
		#endregion
		#region[OrderDetail_Delete]
		public static bool OrderDetail_Delete(string Id)
		{
			return db.OrderDetail_Delete(Id);
		}
		#endregion
	}
}
