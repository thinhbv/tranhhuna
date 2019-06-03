using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Data
{
	public class ChudeDAL : SqlDataProvider
	{
		static SqlCommand dbCmd;
		#region[Chude_GetById]
		public DataTable Chude_GetById(string Id)
		{
			dbCmd = new SqlCommand("sp_Chude_GetById");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			return GetData(dbCmd);
		}
		#endregion
		#region[Chude_GetByTop]
		public DataTable Chude_GetByTop(string Top, string Where, string Order)
		{
			dbCmd = new SqlCommand("sp_Chude_GetByTop");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
			dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
			dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
			return GetData(dbCmd);
		}
		#endregion
		#region[Chude_GetByAll]
		public DataTable Chude_GetByAll()
		{
			dbCmd = new SqlCommand("sp_Chude_GetByAll");
			dbCmd.CommandType = CommandType.StoredProcedure;
			return GetData(dbCmd);
		}
		#endregion
		#region[Chude_Insert]
		public bool Chude_Insert(Chude data)
		{
			dbCmd = new SqlCommand("sp_Chude_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Chude");
			return true;
		}
		#endregion
		#region[Chude_Update]
		public bool Chude_Update(Chude data)
		{
			dbCmd = new SqlCommand("sp_Chude_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Chude");
			return true;
		}
		#endregion
		#region[Chude_Delete]
		public bool Chude_Delete(string Id)
		{
			dbCmd = new SqlCommand("sp_Chude_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Chude");
			return true;
		}
		#endregion
	}
}
