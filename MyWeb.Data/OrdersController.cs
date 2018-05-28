using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	class OrdersController : SqlDataProvider
	{
		static SqlCommand dbCmd;
		#region[Orders_GetById]
		public DataTable Orders_GetById(string Id)
		{
			dbCmd = new SqlCommand("sp_Orders_GetById");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			return GetData(dbCmd);
		}
		#endregion
		#region[Orders_GetByTop]
		public DataTable Orders_GetByTop(string Top, string Where, string Order)
		{
			dbCmd = new SqlCommand("sp_Orders_GetByTop");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
			dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
			dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
			return GetData(dbCmd);
		}
		#endregion
		#region[Orders_GetByAll]
		public List<Orders> Orders_GetByAll()
		{
			List<Data.Orders> list = new List<Data.Orders>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Orders_GetByAll", GetConnection()))
			{
				Data.Orders obj = new Data.Orders();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				try
				{
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							list.Add(obj.OrdersIDataReader(dr));
						}
					}
				}
				catch (Exception)
				{

				}
				finally
				{
					if (dr != null)
					{
						dr.Close();
					}
					obj = null;
				}
			}
			return list;
		}
		#endregion
		#region[Orders_Insert]
		public bool Orders_Insert(Orders data)
		{
			dbCmd = new SqlCommand("sp_Orders_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Address", data.Address));
			dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@Products", data.Products));
			dbCmd.Parameters.Add(new SqlParameter("@Prices", data.Prices));
			dbCmd.Parameters.Add(new SqlParameter("@Status", data.Status));
			dbCmd.Parameters.Add(new SqlParameter("@CreateDate", data.CreateDate));
			dbCmd.Parameters.Add(new SqlParameter("@Method", data.Method));
			dbCmd.Parameters.Add(new SqlParameter("@Bill", data.Bill));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Orders");
			return true;
		}
		#endregion
		#region[Orders_Update]
		public bool Orders_Update(Orders data)
		{
			dbCmd = new SqlCommand("sp_Orders_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Address", data.Address));
			dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@Products", data.Products));
			dbCmd.Parameters.Add(new SqlParameter("@Prices", data.Prices));
			dbCmd.Parameters.Add(new SqlParameter("@Status", data.Status));
			dbCmd.Parameters.Add(new SqlParameter("@CreateDate", data.CreateDate));
			dbCmd.Parameters.Add(new SqlParameter("@Method", data.Method));
			dbCmd.Parameters.Add(new SqlParameter("@Bill", data.Bill));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Orders");
			return true;
		}
		#endregion
		#region[Orders_Delete]
		public bool Orders_Delete(string Id)
		{
			dbCmd = new SqlCommand("sp_Orders_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Orders");
			return true;
		}
		#endregion
	}
}
