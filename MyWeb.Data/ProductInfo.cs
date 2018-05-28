using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
    public class Product
    {
        #region[Declare variables]
        private string _Id;
        private string _Name;
        private string _Image1;
        private string _Image2;
        private string _Image3;
        private string _Image4;
        private string _Image5;
        private string _Content;
        private string _Detail;
        private string _GroupId;
        private string _IsHot;
        private string _IsPopular;
        private string _IsSpecial;
        private string _IsNew;
        private string _Ord;
        private string _Active;
        #endregion
        #region[Public Properties]
        public string Id { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Image1 { get { return _Image1; } set { _Image1 = value; } }
        public string Image2 { get { return _Image2; } set { _Image2 = value; } }
        public string Image3 { get { return _Image3; } set { _Image3 = value; } }
        public string Image4 { get { return _Image4; } set { _Image4 = value; } }
        public string Image5 { get { return _Image5; } set { _Image5 = value; } }
        public string Content { get { return _Content; } set { _Content = value; } }
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        public string GroupId { get { return _GroupId; } set { _GroupId = value; } }
        public string IsHot { get { return _IsHot; } set { _IsHot = value; } }
        public string IsPopular { get { return _IsPopular; } set { _IsPopular = value; } }
        public string IsSpecial { get { return _IsSpecial; } set { _IsSpecial = value; } }
        public string IsNew { get { return _IsNew; } set { _IsNew = value; } }
        public string Ord { get { return _Ord; } set { _Ord = value; } }
        public string Active { get { return _Active; } set { _Active = value; } }
        #endregion
        #region[Product IDataReader]
        public Product ProductIDataReader(IDataReader dr)
        {
            Data.Product obj = new Data.Product();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Image1 = (dr["Image1"] is DBNull) ? string.Empty : dr["Image1"].ToString();
            obj.Image2 = (dr["Image2"] is DBNull) ? string.Empty : dr["Image2"].ToString();
            obj.Image3 = (dr["Image3"] is DBNull) ? string.Empty : dr["Image3"].ToString();
            obj.Image4 = (dr["Image4"] is DBNull) ? string.Empty : dr["Image4"].ToString();
            obj.Image5 = (dr["Image5"] is DBNull) ? string.Empty : dr["Image5"].ToString();
            obj.Content = (dr["Content"] is DBNull) ? string.Empty : dr["Content"].ToString();
            obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
            obj.GroupId = (dr["GroupId"] is DBNull) ? string.Empty : dr["GroupId"].ToString();
            obj.IsHot = (dr["IsHot"] is DBNull) ? string.Empty : dr["IsHot"].ToString();
            obj.IsPopular = (dr["IsPopular"] is DBNull) ? string.Empty : dr["IsPopular"].ToString();
            obj.IsSpecial = (dr["IsSpecial"] is DBNull) ? string.Empty : dr["IsSpecial"].ToString();
            obj.IsNew = (dr["IsNew"] is DBNull) ? string.Empty : dr["IsNew"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            return obj;
        }
        #endregion
    }
}