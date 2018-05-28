using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class TagsDAL : SqlDataProvider
    {
        static SqlCommand dbCmd;

		#region[Tags_GetById]
        public DataTable Tags_GetById(string Id)
		{
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_Tags_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            list = GetData(dbCmd);
            return list;
		}
		#endregion
		#region[Tags_GetByTop]
        public DataTable Tags_GetByTop(string Top, string Where, string Order)
		{
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_Tags_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            list = GetData(dbCmd);
            return list;
		}
		#endregion
		#region[Tags_GetByAll]
        public DataTable Tags_GetByAll()
		{
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_Tags_GetByAll");
            dbCmd.CommandType = CommandType.StoredProcedure;
            list = GetData(dbCmd);
            return list;
		}
		#endregion
		#region[Tags_Insert]
		public bool Tags_Insert(Tags data)
		{
            dbCmd = new SqlCommand("sp_Tags_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
			dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Tags");
			return true;
		}
		#endregion
		#region[Tags_Update]
		public bool Tags_Update(Tags data)
		{
            dbCmd = new SqlCommand("sp_Tags_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
			dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Tags");
			return true;
		}
		#endregion
		#region[Tags_Delete]
		public bool Tags_Delete(string Id)
		{
            dbCmd = new SqlCommand("sp_Tags_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Tags");
			return true;
		}
		#endregion
		
	}
}