using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class News	{		#region[Declare variables]		private string  _Id;		private string  _Name;		private string  _Image;		private string  _File;		private string  _Content;		private string  _Detail;		private string  _Date;		private string  _Priority;		private string  _Index;		private string  _Views;
		private string _GroupNewsId;
		private string _GroupName;		private string  _LinkDemo;		private string  _Description;		private string  _Keyword;		private string  _Ord;		private string  _Active;		#endregion		#region[Public Properties]		public string Id{ get { return _Id; } set { _Id = value; } }		public string Name{ get { return _Name; } set { _Name = value; } }		public string Image{ get { return _Image; } set { _Image = value; } }		public string File{ get { return _File; } set { _File = value; } }		public string Content{ get { return _Content; } set { _Content = value; } }		public string Detail{ get { return _Detail; } set { _Detail = value; } }		public string Date{ get { return _Date; } set { _Date = value; } }		public string Priority{ get { return _Priority; } set { _Priority = value; } }		public string Index{ get { return _Index; } set { _Index = value; } }		public string Views{ get { return _Views; } set { _Views = value; } }
		public string GroupNewsId { get { return _GroupNewsId; } set { _GroupNewsId = value; } }
		public string GroupName { get { return _GroupName; } set { _GroupName = value; } }		public string LinkDemo{ get { return _LinkDemo; } set { _LinkDemo = value; } }		public string Description{ get { return _Description; } set { _Description = value; } }		public string Keyword{ get { return _Keyword; } set { _Keyword = value; } }		public string Ord{ get { return _Ord; } set { _Ord = value; } }		public string Active{ get { return _Active; } set { _Active = value; } }		#endregion		#region[News IDataReader]		public News NewsIDataReader(IDataReader dr)		{			Data.News obj = new Data.News();			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();			obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();			obj.File = (dr["File"] is DBNull) ? string.Empty : dr["File"].ToString();			obj.Content = (dr["Content"] is DBNull) ? string.Empty : dr["Content"].ToString();			obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();			obj.Date = (dr["Date"] is DBNull) ? string.Empty : dr["Date"].ToString();			obj.Priority = (dr["Priority"] is DBNull) ? string.Empty : dr["Priority"].ToString();			obj.Index = (dr["Index"] is DBNull) ? string.Empty : dr["Index"].ToString();			obj.Views = (dr["Views"] is DBNull) ? string.Empty : dr["Views"].ToString();
			obj.GroupNewsId = (dr["GroupNewsId"] is DBNull) ? string.Empty : dr["GroupNewsId"].ToString();
			obj.GroupName = (dr["GroupName"] is DBNull) ? string.Empty : dr["GroupName"].ToString();			obj.LinkDemo = (dr["LinkDemo"] is DBNull) ? string.Empty : dr["LinkDemo"].ToString();			obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();			obj.Keyword = (dr["Keyword"] is DBNull) ? string.Empty : dr["Keyword"].ToString();			obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();			return obj;		}		#endregion	}}