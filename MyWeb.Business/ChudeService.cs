using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class ChudeService
	{
		private static ChudeDAL db = new ChudeDAL();
		#region[Chude_GetById]
		public static DataTable Chude_GetById(string Id)
		{
			return db.Chude_GetById(Id);
		}
		#endregion
		#region[Chude_GetByTop]
		public static DataTable Chude_GetByTop(string Top, string Where, string Order)
		{
			return db.Chude_GetByTop(Top, Where, Order);
		}
		#endregion
		#region[Chude_GetByAll]
		public static DataTable Chude_GetByAll()
		{
			return db.Chude_GetByAll();
		}
		#endregion
		#region[Chude_Insert]
		public static bool Chude_Insert(Chude data)
		{
			return db.Chude_Insert(data);
		}
		#endregion
		#region[Chude_Update]
		public static bool Chude_Update(Chude data)
		{
			return db.Chude_Update(data);
		}
		#endregion
		#region[Chude_Delete]
		public static bool Chude_Delete(string Id)
		{
			return db.Chude_Delete(Id);
		}
		#endregion
	}
}
