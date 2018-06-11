using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class OrderDetailDAL : SqlDataProvider
	{
		static SqlCommand dbCmd;
		#region[OrderDetail_GetById]
		public DataTable OrderDetail_GetById(string Id)
		{
			dbCmd = new SqlCommand("sp_OrderDetail_GetById");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			return GetData(dbCmd);
		}
		#endregion
		#region[OrderDetail_GetByTop]
		public DataTable OrderDetail_GetByTop(string Top, string Where, string Order)
		{
			dbCmd = new SqlCommand("sp_OrderDetail_GetByTop");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
			dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
			dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
			return GetData(dbCmd);
		}
		#endregion
		#region[OrderDetail_Insert]
		public bool OrderDetail_Insert(OrderDetail data)
		{
			dbCmd = new SqlCommand("sp_OrderDetail_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@OrderId", data.OrderId));
			dbCmd.Parameters.Add(new SqlParameter("@ProductId", data.ProductId));
			dbCmd.Parameters.Add(new SqlParameter("@ProductName", data.ProductName));
			dbCmd.Parameters.Add(new SqlParameter("@ProductImage", data.ProductImage));
			dbCmd.Parameters.Add(new SqlParameter("@Price", data.Price));
			dbCmd.Parameters.Add(new SqlParameter("@Quantity", data.Quantity));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("OrderDetail");
			return true;
		}
		#endregion
		#region[OrderDetail_Update]
		public bool OrderDetail_Update(OrderDetail data)
		{
			dbCmd = new SqlCommand("sp_OrderDetail_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@OrderId", data.OrderId));
			dbCmd.Parameters.Add(new SqlParameter("@ProductId", data.ProductId));
			dbCmd.Parameters.Add(new SqlParameter("@ProductName", data.ProductName));
			dbCmd.Parameters.Add(new SqlParameter("@ProductImage", data.ProductImage));
			dbCmd.Parameters.Add(new SqlParameter("@Price", data.Price));
			dbCmd.Parameters.Add(new SqlParameter("@Quantity", data.Quantity));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("OrderDetail");
			return true;
		}
		#endregion
		#region[OrderDetail_Delete]
		public bool OrderDetail_Delete(string Id)
		{
			dbCmd = new SqlCommand("sp_OrderDetail_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("OrderDetail");
			return true;
		}
		#endregion

		#region[OrderDetail_UpdateQuantity]
		public bool OrderDetail_UpdateQuantity(string Id, string quantity)
		{
			dbCmd = new SqlCommand("Update Order_Detail Set Quantity=@Quantity Where Id=@Id");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Quantity", quantity));
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("OrderDetail");
			return true;
		}
		#endregion
	}
}
