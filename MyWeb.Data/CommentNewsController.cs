using System;
        SqlCommand dbCmd = new SqlCommand();
            dbCmd = new SqlCommand("sp_CommentNews_GetById");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            return GetData(dbCmd);
            dbCmd = new SqlCommand("sp_CommentNews_GetByTop");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
            dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
            dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
            return GetData(dbCmd);
            dbCmd = new SqlCommand("sp_CommentNews_GetByAll");
            dbCmd.CommandType = CommandType.StoredProcedure;
            return GetData(dbCmd);
        public bool CommentNews_Insert(CommentNews data)
        {
            dbCmd = new SqlCommand("sp_CommentNews_Insert");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Address", data.Address));
            dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
            dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@NewsID", data.NewsID));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("CommentNews");
            return true;
        }
        public bool CommentNews_Update(CommentNews data)
        {
            dbCmd = new SqlCommand("sp_CommentNews_Update");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
            dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
            dbCmd.Parameters.Add(new SqlParameter("@Address", data.Address));
            dbCmd.Parameters.Add(new SqlParameter("@Email", data.Email));
            dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
            dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
            dbCmd.Parameters.Add(new SqlParameter("@NewsID", data.NewsID));
            dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
            dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("CommentNews");
            return true;
        }
        public bool CommentNews_Delete(string Id)
        {
            dbCmd = new SqlCommand("sp_CommentNews_Delete");
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
            ExecuteNonQuery(dbCmd);
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("CommentNews");
            return true;
        }