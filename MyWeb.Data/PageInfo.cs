using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
    public class Page
    {
        #region[Declare variables]
        private string _Id;
        private string _Name;
        private string _Image;
        private string _Detail;
        private string _Level;
        private string _Description;
        private string _Keyword;
        private string _Type;
        private string _Link;
        private string _Target;
        private string _Position;
        private string _Ord;
        private string _Active;
        #endregion
        #region[Public Properties]
        public string Id { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Image { get { return _Image; } set { _Image = value; } }
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        public string Level { get { return _Level; } set { _Level = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public string Keyword { get { return _Keyword; } set { _Keyword = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }
        public string Link { get { return _Link; } set { _Link = value; } }
        public string Target { get { return _Target; } set { _Target = value; } }
        public string Position { get { return _Position; } set { _Position = value; } }
        public string Ord { get { return _Ord; } set { _Ord = value; } }
        public string Active { get { return _Active; } set { _Active = value; } }
        #endregion
        #region[Page IDataReader]
        public Page PageIDataReader(IDataReader dr)
        {
            Data.Page obj = new Data.Page();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
            obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
            obj.Level = (dr["Level"] is DBNull) ? string.Empty : dr["Level"].ToString();
            obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
            obj.Keyword = (dr["Keyword"] is DBNull) ? string.Empty : dr["Keyword"].ToString();
            obj.Type = (dr["Type"] is DBNull) ? string.Empty : dr["Type"].ToString();
            obj.Link = (dr["Link"] is DBNull) ? string.Empty : dr["Link"].ToString();
            obj.Target = (dr["Target"] is DBNull) ? string.Empty : dr["Target"].ToString();
            obj.Position = (dr["Position"] is DBNull) ? string.Empty : dr["Position"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            return obj;
        }
        #endregion
    }
}