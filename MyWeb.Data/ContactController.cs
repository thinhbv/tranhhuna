using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class ContactDAL : SqlDataProvider	{
        SqlCommand dbCmd;		#region[Contact_GetById]		public DataTable Contact_GetById(string Id)		{
            dbCmd = new SqlCommand("sp_Contact_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            return GetData(dbCmd);		}		#endregion		#region[Contact_GetByTop]		public DataTable Contact_GetByTop(string Top, string Where, string Order)		{
            dbCmd = new SqlCommand("sp_Contact_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            return GetData(dbCmd);		}		#endregion		#region[Contact_GetByAll]		public DataTable Contact_GetByAll()		{
            dbCmd = new SqlCommand("sp_Contact_GetByAll");
            dbCmd.CommandType = CommandType.StoredProcedure;
            return GetData(dbCmd);		}		#endregion		#region[Contact_Insert]
        public bool Contact_Insert(Contact data)
        {
            dbCmd = new SqlCommand("sp_Contact_Insert");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Company", data.Company));
            dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
            dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
            dbCmd.Parameters.Add(new SqlParameter("@Website", data.Website));
            dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@Date", data.Date));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Contact");
            return true;
        }		#endregion		#region[Contact_Update]
        public bool Contact_Update(Contact data)
        {
            dbCmd = new SqlCommand("sp_Contact_Update");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Company", data.Company));
            dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
            dbCmd.Parameters.Add(new SqlParameter("@Phone", data.Phone));
            dbCmd.Parameters.Add(new SqlParameter("@Website", data.Website));
            dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@Date", data.Date));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Contact");
            return true;
        }		#endregion		#region[Contact_Delete]
        public bool Contact_Delete(string Id)
        {
            dbCmd = new SqlCommand("sp_Contact_Delete");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Contact");
            return true;
        }		#endregion			}}