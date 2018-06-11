using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
namespace MyWeb.Data
{
	public class OrdersDAL : SqlDataProvider
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
			dbCmd.Parameters.Add(new SqlParameter("@OrderId", data.OrderId));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Address", data.Address));
			dbCmd.Parameters.Add(new SqlParameter("@Tel", data.Tel));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@PaymentMethod", data.PaymentMethod));
			dbCmd.Parameters.Add(new SqlParameter("@Price", data.Price));
			dbCmd.Parameters.Add(new SqlParameter("@Status", data.Status));
			dbCmd.Parameters.Add(new SqlParameter("@OrderDate", data.OrderDate));
			dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
			dbCmd.Parameters.Add(new SqlParameter("@DeliveryDate", data.DeliveryDate));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Orders");
			return true;
		}
		#endregion
		#region[Orders_Update]
		public bool Orders_Update(Orders data, SqlConnection con, SqlTransaction tran)
		{
			dbCmd = new SqlCommand("sp_Orders_Update", con, tran);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@OrderId", data.OrderId));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Address", data.Address));
			dbCmd.Parameters.Add(new SqlParameter("@Tel", data.Tel));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@PaymentMethod", data.PaymentMethod));
			dbCmd.Parameters.Add(new SqlParameter("@Price", data.Price));
			dbCmd.Parameters.Add(new SqlParameter("@Status", data.Status));
			dbCmd.Parameters.Add(new SqlParameter("@OrderDate", data.OrderDate));
			dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
			dbCmd.Parameters.Add(new SqlParameter("@DeliveryDate", data.DeliveryDate));
			dbCmd.ExecuteNonQuery();
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
		#region[Orders_Add]
		public string Orders_Add(string id, string orderid, string quantity)
		{
			string count = "0";
			SqlTransaction mTran;
			SqlConnection mCon;
			SqlCommand cmdSelect;
			SqlCommand cmdInsert;
			SqlCommand cmdUpdate;
			string sSQL;
			DataTable dtPro = new DataTable();

			mCon = GetConnection();
			mTran = mCon.BeginTransaction();

			string BillId = string.Empty;
			try
			{
				sSQL = "Select * from Product where Id=@Id";
				cmdSelect = new SqlCommand(sSQL, mCon, mTran);
				cmdSelect.Parameters.Add("@Id", SqlDbType.Int).Value = id;
				DataTable dt = GetData(cmdSelect, false);
				if (dt.Rows.Count > 0)
				{
					string name = dt.Rows[0]["Name"].ToString();
					string price = dt.Rows[0]["Price"].ToString().Replace(" Đ", string.Empty).Replace(".", string.Empty);
					price = (int.Parse(price) * int.Parse(quantity)).ToString();
					string img = dt.Rows[0]["Image1"].ToString();
					//Get Order
					sSQL = "Select * from Orders where OrderId=@OrderId And Status=0";
					cmdSelect = new SqlCommand(sSQL, mCon, mTran);
					cmdSelect.Parameters.Add("@OrderId", SqlDbType.VarChar).Value = orderid;
					DataTable dtOrder = GetData(cmdSelect, false);

					if (dtOrder.Rows.Count > 0)
					{
						BillId = dtOrder.Rows[0]["Id"].ToString();
						sSQL = "Select * from Order_Detail where OrderId=@OrderId And ProductId=@ProductId";
						cmdSelect = new SqlCommand(sSQL, mCon, mTran);
						cmdSelect.Parameters.Add("@OrderId", SqlDbType.Int).Value = BillId;
						cmdSelect.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;
						dtPro = GetData(cmdSelect, false);
						if (dtPro.Rows.Count == 0)
						{
							sSQL = "Update Orders set Price=@Price Where Id=@Id";
							cmdUpdate = new SqlCommand(sSQL, mCon, mTran);
							cmdUpdate.Parameters.Add("@Price", SqlDbType.VarChar).Value = (int.Parse(dtOrder.Rows[0]["Price"].ToString()) + int.Parse(price)).ToString();
							cmdUpdate.Parameters.Add("@Id", SqlDbType.Int).Value = BillId;
							if (cmdUpdate.ExecuteNonQuery() == 0)
							{
								if (mTran != null)
								{
									mTran.Rollback();
								}
								return "0";
							}
						}
					}
					else
					{
						cmdInsert = new SqlCommand("sp_Orders_Insert", mCon, mTran);
						cmdInsert.CommandType = CommandType.StoredProcedure;
						cmdInsert.Parameters.Add(new SqlParameter("@OrderId", orderid));
						cmdInsert.Parameters.Add(new SqlParameter("@Name", string.Empty));
						cmdInsert.Parameters.Add(new SqlParameter("@Address", string.Empty));
						cmdInsert.Parameters.Add(new SqlParameter("@Tel", string.Empty));
						cmdInsert.Parameters.Add(new SqlParameter("@Email", string.Empty));
						cmdInsert.Parameters.Add(new SqlParameter("@PaymentMethod", string.Empty));
						cmdInsert.Parameters.Add(new SqlParameter("@Price", price));
						cmdInsert.Parameters.Add(new SqlParameter("@Status", "0"));
						cmdInsert.Parameters.Add(new SqlParameter("@OrderDate", string.Empty));
						cmdInsert.Parameters.Add(new SqlParameter("@Detail", string.Empty));
						cmdInsert.Parameters.Add(new SqlParameter("@DeliveryDate", string.Empty));
						if (cmdInsert.ExecuteNonQuery() == 0)
						{
							if (mTran != null)
							{
								mTran.Rollback();
							}
							return "0";
						}
						sSQL = "SELECT max(Id) as maxid FROM Orders";
						cmdSelect = new SqlCommand(sSQL, mCon, mTran);
						BillId = cmdSelect.ExecuteScalar().ToString();
					}
					if (dtPro.Rows.Count == 0)
					{
						dbCmd = new SqlCommand("sp_OrderDetail_Insert", mCon, mTran);
						dbCmd.CommandType = CommandType.StoredProcedure;
						dbCmd.Parameters.Add(new SqlParameter("@OrderId", BillId));
						dbCmd.Parameters.Add(new SqlParameter("@ProductId", id));
						dbCmd.Parameters.Add(new SqlParameter("@ProductName", name));
						dbCmd.Parameters.Add(new SqlParameter("@ProductImage", img));
						dbCmd.Parameters.Add(new SqlParameter("@Price", price));
						dbCmd.Parameters.Add(new SqlParameter("@Quantity", quantity));
						if (dbCmd.ExecuteNonQuery() == 1)
						{
							count = "1";
							mTran.Commit();
						}
						else
						{
							mTran.Rollback();
						}
					}
				}
			}
			catch (Exception ex)
			{
				if (mTran != null)
				{
					mTran.Rollback();
				}
				throw ex;
			}
			finally
			{
				if (mCon != null)
				{
					mCon.Close();
				}
			}
			return count;
		}
		#endregion
		#region[Delete_Item]
		public string DeleteItem(string id)
		{
			string count = "0";
			SqlTransaction mTran;
			SqlConnection mCon;
			SqlCommand cmdSelect;
			SqlCommand cmdUpdate;
			SqlCommand cmdDelete;
			string sSQL;
			mCon = GetConnection();
			mTran = mCon.BeginTransaction();
			try
			{
				sSQL = "Select * from Order_Detail where Id=@Id";
				cmdSelect = new SqlCommand(sSQL, mCon, mTran);
				cmdSelect.Parameters.Add("@Id", SqlDbType.Int).Value = id;
				DataTable dt = GetData(cmdSelect, false);
				if (dt.Rows.Count > 0)
				{
					cmdDelete = new SqlCommand("sp_OrderDetail_Delete", mCon, mTran);
					cmdDelete.CommandType = CommandType.StoredProcedure;
					cmdDelete.Parameters.Add("@Id", SqlDbType.Int).Value = id;
					if (cmdDelete.ExecuteNonQuery() == 0)
					{
						if (mTran != null)
						{
							mTran.Rollback();
						}
						return "0";
					}
					int price;
					if (int.TryParse(dt.Rows[0]["Price"].ToString(),out price) == false)
					{
						if (mTran != null)
						{
							mTran.Rollback();
						}
						return "0";
					}
					sSQL = "Update Orders set Price = CONVERT(Int,Price) - " + price + " Where Id=@OrderId";
					cmdUpdate = new SqlCommand(sSQL, mCon, mTran);
					cmdUpdate.Parameters.Add("@OrderId", SqlDbType.Int).Value = dt.Rows[0]["OrderId"].ToString();
					if (cmdUpdate.ExecuteNonQuery() == 1)
					{
						count = "1";
						mTran.Commit();
					}
					else
					{
						mTran.Rollback();
					}
				}
			}
			catch (Exception ex)
			{
				if (mTran != null)
				{
					mTran.Rollback();
				}
				throw ex;
			}
			finally
			{
				if (mCon != null)
				{
					mCon.Close();
				}
			}
			return count;
		}
		#endregion

		#region[PurchaseProduct]
		public bool PurchaseProduct(Orders order, Hashtable htData)
		{
			SqlTransaction mTran;
			SqlConnection mCon;
			SqlCommand cmdSelect;
			SqlCommand cmdUpdate;
			string sSQL;
			int totalprice = 0;
			mCon = GetConnection();
			mTran = mCon.BeginTransaction();
			try
			{
				foreach( string key in htData.Keys )
				{
					int quantity = 0;
					int price = 0;
					sSQL = "Select * From Order_Detail Where Id=@Id";
					cmdSelect = new SqlCommand(sSQL, mCon, mTran);
					cmdSelect.Parameters.Add("@Id", SqlDbType.Int).Value = key;
					DataTable dtItem = GetData(cmdSelect, false);
					if (dtItem.Rows.Count > 0)
					{
						quantity = int.Parse(dtItem.Rows[0]["Quantity"].ToString());
						price = int.Parse(dtItem.Rows[0]["Price"].ToString());
						price = price / quantity;
						price = int.Parse(htData[key].ToString()) * price;
						totalprice = totalprice + price;
					}

					sSQL = "Update Order_Detail Set Quantity=@Quantity, Price=@Price Where Id=@Id";
					cmdUpdate = new SqlCommand(sSQL, mCon, mTran);
					cmdUpdate.Parameters.Add("@Quantity", SqlDbType.Int).Value = htData[key].ToString();
					cmdUpdate.Parameters.Add("@Price", SqlDbType.VarChar).Value = price;
					cmdUpdate.Parameters.Add("@Id", SqlDbType.Int).Value = key;
					cmdUpdate.ExecuteNonQuery();
				}
				order.Price = totalprice.ToString();
				Orders_Update(order, mCon, mTran);
				mTran.Commit();
				return true;
			}
			catch (Exception ex)
			{
				if (mTran != null)
				{
					mTran.Rollback();
				}
				throw ex;
			}
			finally
			{
				if (mCon != null)
				{
					mCon.Close();
				}
			}
		}
		#endregion
	}
}
