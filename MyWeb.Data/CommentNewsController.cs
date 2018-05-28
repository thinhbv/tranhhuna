using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class CommentNewsDAL : SqlDataProvider	{
        SqlCommand dbCmd = new SqlCommand();		#region[CommentNews_GetById]		public DataTable CommentNews_GetById(string Id)		{
            dbCmd = new SqlCommand("sp_CommentNews_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            return GetData(dbCmd);		}		#endregion		#region[CommentNews_GetByTop]		public DataTable CommentNews_GetByTop(string Top, string Where, string Order)		{
            dbCmd = new SqlCommand("sp_CommentNews_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            return GetData(dbCmd);		}		#endregion		#region[CommentNews_GetByAll]		public DataTable CommentNews_GetByAll()		{
            dbCmd = new SqlCommand("sp_CommentNews_GetByAll");
            dbCmd.CommandType = CommandType.StoredProcedure;
            return GetData(dbCmd);		}		#endregion		#region[CommentNews_Insert]
        public bool CommentNews_Insert(CommentNews data)
        {
            dbCmd = new SqlCommand("sp_CommentNews_Insert");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Address", data.Address));
            dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
            dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@NewsID", data.NewsID));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("CommentNews");
            return true;
        }		#endregion		#region[CommentNews_Update]
        public bool CommentNews_Update(CommentNews data)
        {
            dbCmd = new SqlCommand("sp_CommentNews_Update");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Address", data.Address));
            dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
            dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@NewsID", data.NewsID));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("CommentNews");
            return true;
        }		#endregion		#region[CommentNews_Delete]
        public bool CommentNews_Delete(string Id)
        {
            dbCmd = new SqlCommand("sp_CommentNews_Delete");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("CommentNews");
            return true;
        }		#endregion			}}