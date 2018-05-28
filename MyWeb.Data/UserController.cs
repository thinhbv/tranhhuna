using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class UserDAL : SqlDataProvider
    {
        static SqlCommand dbCmd;
		#region[User_GetById]
        public DataTable User_GetById(string Id)
		{
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_User_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            list = GetData(dbCmd);
            return list;
		}
		#endregion
		#region[User_GetByTop]
		public DataTable User_GetByTop(string Top, string Where, string Order)
		{
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_User_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            list = GetData(dbCmd);
            return list;
		}
		#endregion
		#region[User_GetByAll]
        public DataTable User_GetByAll()
		{
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_User_GetByAll");
            dbCmd.CommandType = CommandType.StoredProcedure;
            list = GetData(dbCmd);
            return list;
		}
		#endregion
		#region[User_Insert]
		public bool User_Insert(User data)
		{
            dbCmd = new SqlCommand("sp_User_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@UserName", data.UserName));
			dbCmd.Parameters.Add(new SqlParameter("@Password", data.Password));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
			dbCmd.Parameters.Add(new SqlParameter("@Date", data.Date));
			dbCmd.Parameters.Add(new SqlParameter("@Admin", data.Admin));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("User");
			return true;
		}
		#endregion
		#region[User_Update]
		public bool User_Update(User data)
		{
            dbCmd = new SqlCommand("sp_User_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@UserName", data.UserName));
			dbCmd.Parameters.Add(new SqlParameter("@Password", data.Password));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
			dbCmd.Parameters.Add(new SqlParameter("@Date", data.Date));
			dbCmd.Parameters.Add(new SqlParameter("@Admin", data.Admin));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("User");
			return true;
		}
		#endregion
		#region[User_Delete]
		public bool User_Delete(string Id)
		{
            dbCmd = new SqlCommand("sp_User_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("User");
			return true;
		}
		#endregion
		
	}
}