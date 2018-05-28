using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
    public class ImagesDAL : SqlDataProvider
    {
        #region[Images_GetById]
        public List<Images> Images_GetById(string Id)
        {
            List<Data.Images> list = new List<Data.Images>();
            Data.Images obj = new Data.Images();
            SqlDataReader dr = null;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_Images_GetById", GetConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                    dr = dbCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            list.Add(obj.ImagesIDataReader(dr));
                        }
                        //conn.Close();
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
            return list;
        }
        #endregion
        #region[Images_GetByTop]
        public List<Images> Images_GetByTop(string Top, string Where, string Order)
        {
            List<Data.Images> list = new List<Data.Images>();
            Data.Images obj = new Data.Images();
            SqlDataReader dr = null;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_Images_GetByTop", GetConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                    dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                    dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                    dr = dbCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            list.Add(obj.ImagesIDataReader(dr));
                        }
                        //conn.Close();
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
            return list;
        }
        #endregion
        #region[Images_GetByAll]
        public List<Images> Images_GetByAll()
        {
            List<Data.Images> list = new List<Data.Images>();
            Data.Images obj = new Data.Images();
            SqlDataReader dr = null;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_Images_GetByAll", GetConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dr = dbCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            list.Add(obj.ImagesIDataReader(dr));
                        }
                        //conn.Close();
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
            return list;
        }
        #endregion
        #region[Images_Insert]
        public bool Images_Insert(Images data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Images_Insert", GetConnection()))
            {
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Thumbnail", data.Thumbnail));
                dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                dbCmd.Parameters.Add(new SqlParameter("@GroupId", data.GroupId));
                dbCmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
                dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
                dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Images");
            return true;
        }
        #endregion
        #region[Images_Update]
        public bool Images_Update(Images data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Images_Update", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@Thumbnail", data.Thumbnail));
                dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                dbCmd.Parameters.Add(new SqlParameter("@GroupId", data.GroupId));
                dbCmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
                dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
                dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Images");
            return true;
        }
        #endregion
        #region[Images_Delete]
        public bool Images_Delete(string Id)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Images_Delete", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Images");
            return true;
        }
        #endregion

    }
}