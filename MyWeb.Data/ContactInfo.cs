using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class Contact	{		#region[Declare variables]		private string  _Id;		private string  _Name;		private string  _Company;		private string  _Email;		private string  _Phone;		private string  _Website;		private string  _Title;		private string  _Detail;		private string  _Date;		#endregion		#region[Public Properties]		public string Id{ get { return _Id; } set { _Id = value; } }		public string Name{ get { return _Name; } set { _Name = value; } }		public string Company{ get { return _Company; } set { _Company = value; } }		public string Email{ get { return _Email; } set { _Email = value; } }		public string Phone{ get { return _Phone; } set { _Phone = value; } }		public string Website{ get { return _Website; } set { _Website = value; } }		public string Title{ get { return _Title; } set { _Title = value; } }		public string Detail{ get { return _Detail; } set { _Detail = value; } }		public string Date{ get { return _Date; } set { _Date = value; } }		#endregion
        #region[Contact IDataReader]
        public Contact ContactIDataReader(IDataReader dr)
        {
            Data.Contact obj = new Data.Contact();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Company = (dr["Company"] is DBNull) ? string.Empty : dr["Company"].ToString();
            obj.Email = (dr["Email"] is DBNull) ? string.Empty : dr["Email"].ToString();
            obj.Phone = (dr["Phone"] is DBNull) ? string.Empty : dr["Phone"].ToString();
            obj.Website = (dr["Website"] is DBNull) ? string.Empty : dr["Website"].ToString();
            obj.Title = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
            obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
            obj.Date = (dr["Date"] is DBNull) ? string.Empty : dr["Date"].ToString();
            return obj;
        }
        #endregion	}}