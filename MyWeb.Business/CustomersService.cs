using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class CustomersService
	{

		private static CustomersDAL db = new CustomersDAL();
		#region[Customers_GetById]
		public static DataTable Customers_GetById(string Id)
		{
			return db.Customers_GetById(Id);
		}
		#endregion
		#region[Customers_GetByTop]
		public static DataTable Customers_GetByTop(string Top, string Where, string Order)
		{
			return db.Customers_GetByTop(Top, Where, Order);
		}
		#endregion
		#region[Customers_GetByAll]
		public static DataTable Customers_GetByAll()
		{
			return db.Customers_GetByAll();
		}
		#endregion
		#region[Customers_Insert]
		public static int Customers_Insert(Customers data)
		{
			return db.Customers_Insert(data);
		}
		#endregion
		#region[Customers_Update]
		public static bool Customers_Update(Customers data)
		{
			return db.Customers_Update(data);
		}
		#endregion
		#region[Customers_Delete]
		public static bool Customers_Delete(string Id)
		{
			return db.Customers_Delete(Id);
		}
		#endregion
		#region[Customers_Login]
		public static DataTable Customers_Login(string UserName, string Password)
		{
			return db.Customers_Login(UserName, Password);
		}
		#endregion
		#region[Customers_GetByName]
		public static DataTable Customers_GetByName(string UserName)
		{
			return db.Customers_GetByName(UserName);
		}
		#endregion
		#region[Customers_GetByAppId]
		public static DataTable Customers_GetByAppId(string appId)
		{
			return db.Customers_GetByAppId(appId);
		}
		#endregion
	}
}
