using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Data
{
	public class CustomersDAL : SqlDataProvider
	{

		static SqlCommand dbCmd;
		#region[Customers_GetById]
		public DataTable Customers_GetById(string Id)
		{
			DataTable list = new DataTable();
			dbCmd = new SqlCommand("sp_Customers_GetById");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			list = GetData(dbCmd);
			return list;
		}
		#endregion
		#region[Customers_GetByTop]
		public DataTable Customers_GetByTop(string Top, string Where, string Order)
		{
			DataTable list = new DataTable();
			dbCmd = new SqlCommand("sp_Customers_GetByTop");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
			dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
			dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
			list = GetData(dbCmd);
			return list;
		}
		#endregion
		#region[Customers_GetByAll]
		public DataTable Customers_GetByAll()
		{
			DataTable list = new DataTable();
			dbCmd = new SqlCommand("sp_Customers_GetByAll");
			dbCmd.CommandType = CommandType.StoredProcedure;
			list = GetData(dbCmd);
			return list;
		}
		#endregion
		#region[Customers_Insert]
		public bool Customers_Insert(Customers data)
		{
			dbCmd = new SqlCommand("sp_Customers_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@FullName", data.FullName));
			dbCmd.Parameters.Add(new SqlParameter("@UserName", data.UserName));
			dbCmd.Parameters.Add(new SqlParameter("@Password", data.Password));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
			dbCmd.Parameters.Add(new SqlParameter("@Birthday", data.Birthday));
			dbCmd.Parameters.Add(new SqlParameter("@CreatedDate", data.CreatedDate));
			dbCmd.Parameters.Add(new SqlParameter("@Gender", data.Gender));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Customers");
			return true;
		}
		#endregion
		#region[Customers_Update]
		public bool Customers_Update(Customers data)
		{
			dbCmd = new SqlCommand("sp_Customers_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@FullName", data.FullName));
			dbCmd.Parameters.Add(new SqlParameter("@UserName", data.UserName));
			dbCmd.Parameters.Add(new SqlParameter("@Password", data.Password));
			dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
			dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
			dbCmd.Parameters.Add(new SqlParameter("@Birthday", data.Birthday));
			dbCmd.Parameters.Add(new SqlParameter("@CreatedDate", data.CreatedDate));
			dbCmd.Parameters.Add(new SqlParameter("@Gender", data.Gender));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Customers");
			return true;
		}
		#endregion
		#region[Customers_Delete]
		public bool Customers_Delete(string Id)
		{
			dbCmd = new SqlCommand("sp_Customers_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Customers");
			return true;
		}
		#endregion
		#region[Customers_Login]
		public DataTable Customers_Login(string UserName,string Password)
		{
			string strReturn = "Select Top 1 * From Customers Where Email=@Email And Password=@Password And Active = 1";
			SqlCommand cmd = GetCommand(strReturn);
			cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = UserName;
			cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
			return GetData(cmd);
		}
		#endregion
		#region[Customers_GetByName]
		public DataTable Customers_GetByName(string UserName)
		{
			string strReturn = "Select Top 1 * From Customers Where Email=@Email And Active = 1";
			SqlCommand cmd = GetCommand(strReturn);
			cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = UserName;
			return GetData(cmd);
		}
		#endregion
	}
}
