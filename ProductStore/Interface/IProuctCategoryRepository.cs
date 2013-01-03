using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Models;

namespace ProductStore.Interface
{
    interface IProuctCategoryRepository
    {
        #region Save,Upadate,Delete,Dispose Method.
        void Save();
        void PutProductCategory(int id, ProductCategory productcategory);
        void PostProductCategory(ProductCategory productcategory);
        ProductCategory FindProductCategories(int id);
        void RemoveProductCategories(ProductCategory product);
        void Dispose();
        #endregion

        #region Get Method.
        IEnumerable<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategory(int id);
        #endregion
    
    }
}
