using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class ProductDAL : SqlDataProvider
	{
		#region[Product_GetById]
		public DataTable Product_GetById(string Id)
		{
			SqlCommand dbCmd;
			dbCmd = new SqlCommand("sp_Product_GetById");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			return GetData(dbCmd);
		}
		#endregion
		#region[Product_GetCount]
		public int Product_GetCount(string level)
		{
			int total = 0;
			Data.Product obj = new Data.Product();
			SqlDataReader dr = null;
			try
			{
				using (SqlCommand dbCmd = new SqlCommand("sp_Product_GetCount", GetConnection()))
				{
					dbCmd.CommandType = CommandType.StoredProcedure;
					dbCmd.Parameters.Add(new SqlParameter("@Level", level));
					dr = dbCmd.ExecuteReader();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							total = dr.GetInt32(0);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null)
				{
					dr.Close();
				}
				obj = null;
			}
			return total;
		}
		#endregion
		#region[spProduct_PhanTrang]
		public DataTable Product_Pagination(string currPage, string perpage, string level)
		{
			SqlCommand dbCmd;
			dbCmd = new SqlCommand("spProduct_PhanTrang");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@currPage", currPage));
			dbCmd.Parameters.Add(new SqlParameter("@recodperpage", perpage));
			dbCmd.Parameters.Add(new SqlParameter("@Level", level));
			return GetData(dbCmd);
		}
		#endregion
		#region[Product_GetByTop]
		public DataTable Product_GetByTop(string Top, string Where, string Order)
		{
			DataTable dt = new DataTable();
			try
			{
				SqlCommand dbCmd;
				dbCmd = new SqlCommand("sp_Product_GetByTop");
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				dt = GetData(dbCmd);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return dt;
		}
		#endregion
		#region[Product_GetByAll]
		public List<Product> Product_GetByAll()
		{
			List<Data.Product> list = new List<Data.Product>();
			Data.Product obj = new Data.Product();
			SqlDataReader dr = null;
			try
			{
				using (SqlCommand dbCmd = new SqlCommand("sp_Product_GetByAll", GetConnection()))
				{
					dbCmd.CommandType = CommandType.StoredProcedure;
					dr = dbCmd.ExecuteReader();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							list.Add(obj.ProductIDataReader(dr));
						}
						//conn.Close();
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null)
				{
					dr.Close();
				}
				obj = null;
			}
			return list;
		}
		#endregion
		#region[Product_Insert]
		public bool Product_Insert(Product data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Image1", data.Image1));
				dbCmd.Parameters.Add(new SqlParameter("@Image2", data.Image2));
				dbCmd.Parameters.Add(new SqlParameter("@Image3", data.Image3));
				dbCmd.Parameters.Add(new SqlParameter("@Image4", data.Image4));
				dbCmd.Parameters.Add(new SqlParameter("@Image5", data.Image5));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
				dbCmd.Parameters.Add(new SqlParameter("@Price", data.Price));
				dbCmd.Parameters.Add(new SqlParameter("@GroupId", data.GroupId));
				dbCmd.Parameters.Add(new SqlParameter("@GroupName", data.GroupName));
				dbCmd.Parameters.Add(new SqlParameter("@IsHot", data.IsHot));
				dbCmd.Parameters.Add(new SqlParameter("@IsPopular", data.IsPopular));
				dbCmd.Parameters.Add(new SqlParameter("@IsSpecial", data.IsSpecial));
				dbCmd.Parameters.Add(new SqlParameter("@IsNew", data.IsNew));
				dbCmd.Parameters.Add(new SqlParameter("@ChudeId", data.ChudeId));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Product");
			return true;
		}
		#endregion
		#region[Product_Update]
		public bool Product_Update(Product data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Image1", data.Image1));
				dbCmd.Parameters.Add(new SqlParameter("@Image2", data.Image2));
				dbCmd.Parameters.Add(new SqlParameter("@Image3", data.Image3));
				dbCmd.Parameters.Add(new SqlParameter("@Image4", data.Image4));
				dbCmd.Parameters.Add(new SqlParameter("@Image5", data.Image5));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
				dbCmd.Parameters.Add(new SqlParameter("@Price", data.Price));
				dbCmd.Parameters.Add(new SqlParameter("@GroupId", data.GroupId));
				dbCmd.Parameters.Add(new SqlParameter("@GroupName", data.GroupName));
				dbCmd.Parameters.Add(new SqlParameter("@IsHot", data.IsHot));
				dbCmd.Parameters.Add(new SqlParameter("@IsPopular", data.IsPopular));
				dbCmd.Parameters.Add(new SqlParameter("@IsSpecial", data.IsSpecial));
				dbCmd.Parameters.Add(new SqlParameter("@IsNew", data.IsNew));
				dbCmd.Parameters.Add(new SqlParameter("@ChudeId", data.ChudeId));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Product");
			return true;
		}
		#endregion
		#region[Product_Delete]
		public bool Product_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Product");
			return true;
		}
		#endregion
		#region[Product_SetupPrice]
		public bool Product_SetupPrice(string Id, string size, string price)
		{
			try
			{
				string sSQL = "Update Product Set Image5=Image5 + @size, Price=Price + @price Where Id=@Id";
				using (SqlCommand dbCmd = new SqlCommand(sSQL, GetConnection()))
				{
					dbCmd.CommandType = CommandType.Text;
					dbCmd.Parameters.Add(new SqlParameter("@size", SqlDbType.VarChar)).Value = "," + size;
					dbCmd.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar)).Value = "," + price.Replace(".", string.Empty); ;
					dbCmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = Id;
					dbCmd.ExecuteNonQuery();
				}
				//Clear cache
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion
	}
}