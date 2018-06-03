﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyWeb.Data
{
    /// <summary>
    /// Used this class for Sql database provider
    /// </summary>
    public class SqlDataProvider
    {
        /// <summary>
        /// SQL server connection string
		/// </summary>
#if DEBUG
		static string strConStr = @"Data Source=THINHBV-PC\MSSQLSERVER_2008;Initial Catalog=tranhhuna;User ID=sa;Password=Thinh!@#123;Pooling=true;Max Pool Size=256;Min Pool Size=16;";
#else
		static string strConStr = @"Data Source=.;Initial Catalog=damyngh1_ht;User ID=damyngh1_ht;Password=oEir595~;Pooling=true;Max Pool Size=256;Min Pool Size=16;";
#endif
		/// <summary>
        /// Global SQL server connection
        /// </summary>
        public static SqlConnection connection;
        public SqlDataProvider() {
            if (connection == null) { connection = new SqlConnection(strConStr); }
            //if (connection.State != ConnectionState.Open) { connection.Open(); }
        }
        public static SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                //connection.Close();
                connection.Open();
                return connection;
            }
            else
                return connection;
        }
        #region DB Access Functions
        public DataTable GetData(string sql) 
        {
            return GetData(GetCommand(sql));
        }

        public DataTable GetData(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection == null) { cmd.Connection = GetConnection(); }
                using (DataSet ds = new DataSet())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }
		public DataTable GetData(SqlCommand cmd, bool isClose)
		{
			try
			{
				if (cmd.Connection == null) { cmd.Connection = GetConnection(); }
				using (DataSet ds = new DataSet())
				{
					using (SqlDataAdapter da = new SqlDataAdapter())
					{
						da.SelectCommand = cmd;
						da.Fill(ds);
						return ds.Tables[0];
					}
				}
			}
			finally
			{
				if (cmd.Connection != null && isClose)
				{
					cmd.Connection.Close();
				}
			}
		}

        public void ExecuteNonQuery(string sql) 
        {
            ExecuteNonQuery(GetCommand(sql));
        }

        public void ExecuteNonQuery(SqlCommand cmd)
        {
			SqlTransaction mTran;
			SqlConnection mCon;
			mCon = GetConnection();
			mTran = mCon.BeginTransaction();
            try
            {
				cmd.Connection = mCon;
				cmd.Transaction = mTran;
				cmd.ExecuteNonQuery();
				mTran.Commit();
            }
			catch (Exception ex)
			{
				if (mTran != null)
				{
					mTran.Rollback();
				}
				throw ex;
			}
            finally
            {
				if (mCon != null)
				{
					mCon.Close();
				}
            }
        }

        public object ExecuteScalar(string sql) 
        {
            return ExecuteScalar(GetCommand(sql));
        }
        public object ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection == null) { cmd.Connection = GetConnection(); }
                return cmd.ExecuteScalar();
            }
            finally
            {
				if (cmd.Connection != null)
				{
					cmd.Connection.Close();
				}
            }
        }

        private SqlCommand GetCommand(string sql) 
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            return cmd;
        }

        public string MaxId(string Table, string ColId)
        {
            string strReturn = "";
            strReturn = ExecuteScalar("SELECT max(" + ColId + ") as maxid FROM " + Table).ToString();
            return strReturn;
        }
        public int DBSize()
        {
            using (SqlCommand cmd = new SqlCommand("select sum(size) * 8 * 1024 from sysfiles"))
            {
                cmd.CommandType = CommandType.Text;
                return (int)ExecuteScalar(cmd);
            }
        }
        #endregion
    }
}
