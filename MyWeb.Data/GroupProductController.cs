using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class GroupProductDAL : SqlDataProvider	{		#region[GroupProduct_GetById]		public List<GroupProduct> GroupProduct_GetById(string Id)		{			List<Data.GroupProduct> list = new List<Data.GroupProduct>();			Data.GroupProduct obj = new Data.GroupProduct();			SqlDataReader dr = null;			try			{				using (SqlCommand dbCmd = new SqlCommand("sp_GroupProduct_GetById", GetConnection()))				{					dbCmd.CommandType = CommandType.StoredProcedure;					dbCmd.Parameters.Add(new SqlParameter("@Id", Id));					dr = dbCmd.ExecuteReader();					if (dr.HasRows)					{						while (dr.Read())						{							list.Add(obj.GroupProductIDataReader(dr));							}						//conn.Close();					}				}			}			catch (Exception ex)			{
				throw ex;			}			finally			{
                if (dr != null)
                {
                    dr.Close();
                }				obj = null;			}			return list;		}		#endregion		#region[GroupProduct_GetByTop]		public DataTable GroupProduct_GetByTop(string Top, string Where, string Order)		{
			DataTable dt = new DataTable();
			try
			{
				SqlCommand dbCmd;
				dbCmd = new SqlCommand("sp_GroupProduct_GetByTop");
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
			return dt;		}		#endregion		#region[GroupProduct_GetByAll]		public List<GroupProduct> GroupProduct_GetByAll()		{			List<Data.GroupProduct> list = new List<Data.GroupProduct>();			Data.GroupProduct obj = new Data.GroupProduct();			SqlDataReader dr = null;			try			{				using (SqlCommand dbCmd = new SqlCommand("sp_GroupProduct_GetByAll", GetConnection()))			{				dbCmd.CommandType = CommandType.StoredProcedure;					dr = dbCmd.ExecuteReader();					if (dr.HasRows)					{						while (dr.Read())						{							list.Add(obj.GroupProductIDataReader(dr));						}						//conn.Close();					}				}			}			catch (Exception ex)			{
				throw ex;			}			finally			{
                if (dr != null)
                {
                    dr.Close();
                }				obj = null;			}			return list;		}		#endregion		#region[GroupProduct_Insert]		public bool GroupProduct_Insert(GroupProduct data)		{			using (SqlCommand dbCmd = new SqlCommand("sp_GroupProduct_Insert", GetConnection()))			{				dbCmd.CommandType = CommandType.StoredProcedure;				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
				dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@Items", data.Items));				dbCmd.ExecuteNonQuery();			}			//Clear cache			System.Web.HttpContext.Current.Cache.Remove("GroupProduct");			return true;		}		#endregion		#region[GroupProduct_Update]		public bool GroupProduct_Update(GroupProduct data)		{			using (SqlCommand dbCmd = new SqlCommand("sp_GroupProduct_Update", GetConnection()))			{				dbCmd.CommandType = CommandType.StoredProcedure;				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
				dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@Items", data.Items));				dbCmd.ExecuteNonQuery();			}			//Clear cache			System.Web.HttpContext.Current.Cache.Remove("GroupProduct");			return true;		}		#endregion		#region[GroupProduct_Delete]		public bool GroupProduct_Delete(string Id)		{			using (SqlCommand dbCmd = new SqlCommand("sp_GroupProduct_Delete", GetConnection()))			{				dbCmd.CommandType = CommandType.StoredProcedure;				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));				dbCmd.ExecuteNonQuery();			}			//Clear cache			System.Web.HttpContext.Current.Cache.Remove("GroupProduct");			return true;		}		#endregion			}}