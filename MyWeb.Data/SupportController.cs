using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class SupportDAL : SqlDataProvider
    {
        static SqlCommand dbCmd;

		#region[Support_GetById]
		public DataTable Support_GetById(string Id)
		{
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_Support_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            list = GetData(dbCmd);
            return list;
		}
		#endregion
		#region[Support_GetByTop]
        public DataTable Support_GetByTop(string Top, string Where, string Order)
		{
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_Support_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            list = GetData(dbCmd);
            return list;
		}
		#endregion
		#region[Support_GetByAll]
        public DataTable Support_GetByAll()
		{
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_Support_GetByAll");
            dbCmd.CommandType = CommandType.StoredProcedure;
            list = GetData(dbCmd);
            return list;
		}
		#endregion
		#region[Support_Insert]
		public bool Support_Insert(Support data)
		{
            dbCmd = new SqlCommand("sp_Support_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
            dbCmd.Parameters.Add(new SqlParameter("@Nick", data.Nick));
            dbCmd.Parameters.Add(new SqlParameter("@Skype", data.Skype));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Support");
			return true;
		}
		#endregion
		#region[Support_Update]
		public bool Support_Update(Support data)
		{
            dbCmd = new SqlCommand("sp_Support_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
            dbCmd.Parameters.Add(new SqlParameter("@Nick", data.Nick));
            dbCmd.Parameters.Add(new SqlParameter("@Skype", data.Skype));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Support");
			return true;
		}
		#endregion
		#region[Support_Delete]
		public bool Support_Delete(string Id)
		{
            dbCmd = new SqlCommand("sp_Support_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Support");
			return true;
		}
		#endregion
		
	}
}