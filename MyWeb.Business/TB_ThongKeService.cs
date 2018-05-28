using System;using System.Collections.Generic;using System.Text;using MyWeb.Data;
using System.Data;namespace MyWeb.Business{	public class TB_ThongKeService	{		private static TB_ThongKeDAL db = new TB_ThongKeDAL();
        #region[spThongKe_Edit]
        public static DataTable spThongKe_Edit()
        {
            return db.spThongKe_Edit();
        }
        #endregion	}}