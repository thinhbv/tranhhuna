using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class AdvertiseService
	{
		private static AdvertiseDAL db = new AdvertiseDAL();
		#region[Advertise_GetById]
		public static DataTable Advertise_GetById(string Id)
		{
			return db.Advertise_GetById(Id);
		}
		#endregion
		#region[Advertise_GetByTop]
		public static DataTable Advertise_GetByTop(string Top, string Where, string Order)
		{
			return db.Advertise_GetByTop(Top, Where, Order);
		}
		#endregion
		#region[Advertise_GetByAll]
		public static List<Data.Advertise> Advertise_GetByAll()
		{
			return db.Advertise_GetByAll();
		}
		#endregion
		#region[Advertise_Insert]
		public static bool Advertise_Insert(Advertise data)
		{
			return db.Advertise_Insert(data);
		}
		#endregion
		#region[Advertise_Update]
		public static bool Advertise_Update(Advertise data)
		{
			return db.Advertise_Update(data);
		}
		#endregion
		#region[Advertise_Delete]
		public static bool Advertise_Delete(string Id)
		{
			return db.Advertise_Delete(Id);
		}
		#endregion
        #region[Advertise_GetByPosition]
        public static List<Advertise> Advertise_GetByPosition(string position)
        {
            List<Advertise> list = new List<Advertise>();
            list = db.Advertise_GetByAll();
            return list.FindAll(delegate(Advertise obj)
            {
                return obj.Position == position && obj.Active == "1";
            });
        }
        public static List<Advertise> Advertise_GetByPositionPage(string position, string page)
        {
            List<Advertise> list = new List<Advertise>();
            list = db.Advertise_GetByAll();
            return list.FindAll(delegate(Advertise obj)
            {
                return (obj.Position == position && obj.PageId == page && obj.Active == "1") || (obj.Position == position && (obj.PageId == null || obj.PageId == "") && obj.Active == "1");
            });
        }
        #endregion
	}
}