using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class GroupNews	{		#region[Declare variables]		private string  _Id;		private string  _Name;		private string  _Image;		private string  _Level;		private string  _Description;		private string  _Keyword;		private string  _Ord;		private string  _Active;		private string  _Index;		#endregion		#region[Public Properties]		public string Id{ get { return _Id; } set { _Id = value; } }		public string Name{ get { return _Name; } set { _Name = value; } }		public string Image{ get { return _Image; } set { _Image = value; } }		public string Level{ get { return _Level; } set { _Level = value; } }		public string Description{ get { return _Description; } set { _Description = value; } }		public string Keyword{ get { return _Keyword; } set { _Keyword = value; } }		public string Ord{ get { return _Ord; } set { _Ord = value; } }		public string Active{ get { return _Active; } set { _Active = value; } }		public string Index{ get { return _Index; } set { _Index = value; } }		#endregion
        #region[GroupNews IDataReader]
        public GroupNews GroupNewsIDataReader(IDataReader dr)
        {
            Data.GroupNews obj = new Data.GroupNews();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
            obj.Level = (dr["Level"] is DBNull) ? string.Empty : dr["Level"].ToString();
            obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
            obj.Keyword = (dr["Keyword"] is DBNull) ? string.Empty : dr["Keyword"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            obj.Index = (dr["Index"] is DBNull) ? string.Empty : dr["Index"].ToString();
            return obj;
        }
        #endregion	}}