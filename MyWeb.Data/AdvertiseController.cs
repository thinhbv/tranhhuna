using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class AdvertiseDAL : SqlDataProvider
	{
        static SqlCommand dbCmd;
		#region[Advertise_GetById]
		public DataTable Advertise_GetById(string Id)
		{
            dbCmd = new SqlCommand("sp_Advertise_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			return GetData(dbCmd);
		}
		#endregion
		#region[Advertise_GetByTop]
		public DataTable Advertise_GetByTop(string Top, string Where, string Order)
		{
            dbCmd = new SqlCommand("sp_Advertise_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            return GetData(dbCmd);
		}
		#endregion
		#region[Advertise_GetByAll]
		public List<Advertise> Advertise_GetByAll()
		{
			List<Data.Advertise> list = new List<Data.Advertise>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_GetByAll", GetConnection()))
			{
				Data.Advertise obj = new Data.Advertise();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
                try
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            list.Add(obj.AdvertiseIDataReader(dr));
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
                finally
                {
                    if (dr != null)
                    {
                        dr.Close();
                    }
                    obj = null;
                }
			}
			return list;
		}
		#endregion
		#region[Advertise_Insert]
        public bool Advertise_Insert(Advertise data)
        {
            dbCmd = new SqlCommand("sp_Advertise_Insert");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
            dbCmd.Parameters.Add(new SqlParameter("@Width", data.Width));
            dbCmd.Parameters.Add(new SqlParameter("@Height", data.Height));
            dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
            dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
            dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
            dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
            dbCmd.Parameters.Add(new SqlParameter("@PageId", data.PageId));
            dbCmd.Parameters.Add(new SqlParameter("@Click", data.Click));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Advertise");
            return true;
        }
		#endregion
		#region[Advertise_Update]
        public bool Advertise_Update(Advertise data)
        {
            dbCmd = new SqlCommand("sp_Advertise_Update");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
            dbCmd.Parameters.Add(new SqlParameter("@Width", data.Width));
            dbCmd.Parameters.Add(new SqlParameter("@Height", data.Height));
            dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
            dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
            dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
            dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
            dbCmd.Parameters.Add(new SqlParameter("@PageId", data.PageId));
            dbCmd.Parameters.Add(new SqlParameter("@Click", data.Click));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Advertise");
            return true;
        }
		#endregion
		#region[Advertise_Delete]
        public bool Advertise_Delete(string Id)
        {
            dbCmd = new SqlCommand("sp_Advertise_Delete");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Advertise");
            return true;
        }
		#endregion
		
	}
}