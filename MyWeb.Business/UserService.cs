using System;
using System.Collections.Generic;
using System.Text;
using MyWeb.Data;
using System.Data;
using System.Data.SqlClient;

namespace MyWeb.Business
{
	public class UserService
	{
		private static UserDAL db = new UserDAL();
		#region[User_GetById]
        public static DataTable User_GetById(string Id)
		{
			return db.User_GetById(Id);
		}
		#endregion
		#region[User_GetByTop]
        public static DataTable User_GetByTop(string Top, string Where, string Order)
		{
			return db.User_GetByTop(Top, Where, Order);
		}
		#endregion
		#region[User_GetByAll]
        public static DataTable User_GetByAll()
		{
			return db.User_GetByAll();
		}
		#endregion
		#region[User_Insert]
		public static bool User_Insert(User data)
		{
			return db.User_Insert(data);
		}
		#endregion
		#region[User_Update]
		public static bool User_Update(User data)
		{
			return db.User_Update(data);
		}
		#endregion
		#region[User_Delete]
		public static bool User_Delete(string Id)
		{
			return db.User_Delete(Id);
		}
		#endregion
        #region[User_Validate]
        public static DataTable User_Validate(string UserName, string Password)
        {
            DataTable list = new DataTable();
            //list = db.User_GetByTop();
            //dbCmd.CommandType = CommandType.StoredProcedure;
            //dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            return list;
        }
        #endregion
        #region[User_GetByUsername]
        public static DataTable User_GetByUsername(string UserName)
        {
            DataTable list = new DataTable();
            //list = db.User_GetByTop();
            //dbCmd.CommandType = CommandType.StoredProcedure;
            //dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            return list;
        }
        #endregion
	}
}