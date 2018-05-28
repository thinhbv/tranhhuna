using System;
        SqlCommand dbCmd;
            dbCmd = new SqlCommand("sp_Config_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            return GetData(dbCmd);
            dbCmd = new SqlCommand("sp_Config_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            return GetData(dbCmd);
            dbCmd = new SqlCommand("sp_Config_GetByAll");
            dbCmd.CommandType = CommandType.StoredProcedure;
            return GetData(dbCmd);
        public bool Config_Insert(Config data)
        {
            dbCmd = new SqlCommand("sp_Config_Insert");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Smtp", data.Mail_Smtp));
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Port", data.Mail_Port));
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Info", data.Mail_Info));
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Noreply", data.Mail_Noreply));
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Password", data.Mail_Password));
            dbCmd.Parameters.Add(new SqlParameter("@Contact", data.Contact));
            dbCmd.Parameters.Add(new SqlParameter("@Copyright", data.Copyright));
            dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
            dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
            dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Config");
            return true;
        }
        public bool Config_Update(Config data)
        {
            dbCmd = new SqlCommand("sp_Config_Update");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Smtp", data.Mail_Smtp));
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Port", data.Mail_Port));
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Info", data.Mail_Info));
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Noreply", data.Mail_Noreply));
            dbCmd.Parameters.Add(new SqlParameter("@Mail_Password", data.Mail_Password));
            dbCmd.Parameters.Add(new SqlParameter("@Contact", data.Contact));
            dbCmd.Parameters.Add(new SqlParameter("@Copyright", data.Copyright));
            dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
            dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
            dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Config");
            return true;
        }
        public bool Config_Delete(string Id)
        {
            dbCmd = new SqlCommand("sp_Config_Delete");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Config");
            return true;
        }