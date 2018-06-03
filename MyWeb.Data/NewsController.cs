using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class NewsDAL : SqlDataProvider	{
        SqlCommand dbCmd = new SqlCommand();		#region[News_GetById]		public DataTable News_GetById(string Id)		{
            dbCmd = new SqlCommand("sp_News_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            return GetData(dbCmd);		}		#endregion		#region[News_GetByTop]		public DataTable News_GetByTop(string Top, string Where, string Order)		{		    dbCmd = new SqlCommand("sp_News_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            return GetData(dbCmd);		}		#endregion		#region[News_GetByAll]		public DataTable News_GetByAll()		{
            dbCmd = new SqlCommand("sp_News_GetByAll");
            dbCmd.CommandType = CommandType.StoredProcedure;
            return GetData(dbCmd);		}		#endregion		#region[News_Insert]
        public bool News_Insert(News data)
        {
            dbCmd = new SqlCommand("sp_News_Insert");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
            dbCmd.Parameters.Add(new SqlParameter("@File", data.File));
            dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@Date", data.Date));
            dbCmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
            dbCmd.Parameters.Add(new SqlParameter("@Index", data.Index));
            dbCmd.Parameters.Add(new SqlParameter("@Views", data.Views));
			dbCmd.Parameters.Add(new SqlParameter("@GroupNewsId", data.GroupNewsId));
			dbCmd.Parameters.Add(new SqlParameter("@GroupName", data.GroupName));
            dbCmd.Parameters.Add(new SqlParameter("@LinkDemo", data.LinkDemo));
            dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
            dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("News");
            return true;
        }		#endregion		#region[News_Update]
        public bool News_Update(News data)
        {
            dbCmd = new SqlCommand("sp_News_Update");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
            dbCmd.Parameters.Add(new SqlParameter("@File", data.File));
            dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@Date", data.Date));
            dbCmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
            dbCmd.Parameters.Add(new SqlParameter("@Index", data.Index));
            dbCmd.Parameters.Add(new SqlParameter("@Views", data.Views));
			dbCmd.Parameters.Add(new SqlParameter("@GroupNewsId", data.GroupNewsId));
			dbCmd.Parameters.Add(new SqlParameter("@GroupName", data.GroupName));
            dbCmd.Parameters.Add(new SqlParameter("@LinkDemo", data.LinkDemo));
            dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
            dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("News");
            return true;
        }		#endregion		#region[News_Delete]
        public bool News_Delete(string Id)
        {
            dbCmd = new SqlCommand("sp_News_Delete");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("News");
            return true;
        }		#endregion	
		#region[News_GetCount]
		public int News_GetCount(string level)
		{
			int total = 0;
			Data.Product obj = new Data.Product();
			SqlDataReader dr = null;
			try
			{
				using (SqlCommand dbCmd = new SqlCommand("sp_News_GetCount", GetConnection()))
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
		#region[spNews_PhanTrang]
		public DataTable News_Pagination(string currPage, string perpage, string level)
		{
			SqlCommand dbCmd;
			dbCmd = new SqlCommand("spNews_PhanTrang");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@currPage", currPage));
			dbCmd.Parameters.Add(new SqlParameter("@recodperpage", perpage));
			dbCmd.Parameters.Add(new SqlParameter("@Level", level));
			return GetData(dbCmd);
		}
		#endregion	}}