using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class GroupProduct	{		#region[Declare variables]		private string  _Id;		private string  _Name;
		private string _Level;
		private string _Position;		private string  _Ord;
		private string _Active;
		private string _Items;		#endregion		#region[Public Properties]		public string Id{ get { return _Id; } set { _Id = value; } }		public string Name{ get { return _Name; } set { _Name = value; } }
		public string Level { get { return _Level; } set { _Level = value; } }
		public string Position { get { return _Position; } set { _Position = value; } }
		public string Ord { get { return _Ord; } set { _Ord = value; } }
		public string Active { get { return _Active; } set { _Active = value; } }
		public string Items { get { return _Items; } set { _Items = value; } }		#endregion		#region[GroupProduct IDataReader]		public GroupProduct GroupProductIDataReader(IDataReader dr)		{			Data.GroupProduct obj = new Data.GroupProduct();			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Level = (dr["Level"] is DBNull) ? string.Empty : dr["Level"].ToString();
			obj.Position = (dr["Position"] is DBNull) ? string.Empty : dr["Position"].ToString();			obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
			obj.Items = (dr["Items"] is DBNull) ? string.Empty : dr["Items"].ToString();			return obj;		}		#endregion	}}