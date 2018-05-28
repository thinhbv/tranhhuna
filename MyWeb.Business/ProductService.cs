using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MyWeb.Data;

namespace MyWeb.Business
{
    public class ProductService
    {
        private static ProductDAL db = new ProductDAL();
        #region[Product_GetById]
        public static List<Data.Product> Product_GetById(string Id)
        {
            return db.Product_GetById(Id);
        }
        #endregion
        #region[Product_GetByTop]
        public static DataTable Product_GetByTop(string Top, string Where, string Order)
        {
            return db.Product_GetByTop(Top, Where, Order);
        }
        #endregion
        #region[Product_GetByAll]
        public static List<Data.Product> Product_GetByAll()
        {
            return db.Product_GetByAll();
        }
        #endregion
        #region[Product_Insert]
        public static bool Product_Insert(Product data)
        {
            return db.Product_Insert(data);
        }
        #endregion
        #region[Product_Update]
        public static bool Product_Update(Product data)
        {
            return db.Product_Update(data);
        }
        #endregion
        #region[Product_Delete]
        public static bool Product_Delete(string Id)
        {
            return db.Product_Delete(Id);
        }
        #endregion
        #region[Product_GetCount]
        public static int Product_GetCount(string level)
        {
            return db.Product_GetCount(level);
        }
        #endregion
        #region[spProduct_PhanTrang]
        public static DataTable Product_Pagination(string currPage, string perpage, string level)
        {
            return db.Product_Pagination(currPage, perpage, level);
        }
        #endregion
    }
}