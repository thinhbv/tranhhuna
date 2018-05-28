using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
    public class Images
    {
        #region[Declare variables]
        private string _Id;
		private string _Thumbnail;
		private string _Image;
        private string _GroupId;
        private string _Priority;
        private string _Ord;
        private string _Active;
        #endregion
        #region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string Thumbnail { get { return _Thumbnail; } set { _Thumbnail = value; } }
        public string Image { get { return _Image; } set { _Image = value; } }
        public string GroupId { get { return _GroupId; } set { _GroupId = value; } }
        public string Priority { get { return _Priority; } set { _Priority = value; } }
        public string Ord { get { return _Ord; } set { _Ord = value; } }
        public string Active { get { return _Active; } set { _Active = value; } }
        #endregion
        #region[Images IDataReader]
        public Images ImagesIDataReader(IDataReader dr)
        {
            Data.Images obj = new Data.Images();
			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
			obj.Thumbnail = (dr["Thumbnail"] is DBNull) ? string.Empty : dr["Thumbnail"].ToString();
            obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
            obj.GroupId = (dr["GroupId"] is DBNull) ? string.Empty : dr["GroupId"].ToString();
            obj.Priority = (dr["Priority"] is DBNull) ? string.Empty : dr["Priority"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            return obj;
        }
        #endregion
    }
}