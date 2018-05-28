using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
    public class PageDAL : SqlDataProvider
    {
        static SqlCommand dbCmd;

        #region[Page_GetById]
        public DataTable Page_GetById(string Id)
        {
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_Page_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            list = GetData(dbCmd);
            return list;
        }
        #endregion
        #region[Page_GetByTop]
        public DataTable Page_GetByTop(string Top, string Where, string Order)
        {
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_Page_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            list = GetData(dbCmd);
            return list;
        }
        #endregion
        #region[Page_GetByAll]
        public DataTable Page_GetByAll()
        {
            DataTable list = new DataTable();
            dbCmd = new SqlCommand("sp_Page_GetByAll");
            dbCmd.CommandType = CommandType.StoredProcedure;
            list = GetData(dbCmd);
            return list;
        }
        #endregion
        #region[Page_Insert]
        public bool Page_Insert(Page data)
        {
            dbCmd = new SqlCommand("sp_Page_Insert");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
            dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
            dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
            dbCmd.Parameters.Add(new SqlParameter("@Type", data.Type));
            dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
            dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
            dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Page");
            return true;
        }
        #endregion
        #region[Page_Update]
        public bool Page_Update(Page data)
        {
            dbCmd = new SqlCommand("sp_Page_Update");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
            dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
            dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
            dbCmd.Parameters.Add(new SqlParameter("@Type", data.Type));
            dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
            dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
            dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Page");
            return true;
        }
        #endregion
        #region[Page_Delete]
        public bool Page_Delete(string Id)
        {
            dbCmd = new SqlCommand("sp_Page_Delete");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Page");
            return true;
        }
        #endregion

    }
}