using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class TB_ThongKeDAL : SqlDataProvider	{
        static SqlCommand dbCmd;
        #region[spThongKe_Edit]
        public DataTable spThongKe_Edit()
        {
            dbCmd = new SqlCommand("spThongKe_Edit");
            dbCmd.CommandType = CommandType.StoredProcedure;
            return GetData(dbCmd);
        }
        #endregion	}}