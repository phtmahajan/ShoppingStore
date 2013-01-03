using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Models;

namespace ProductStore.Interface
{
    interface IProductRepository
    {
        #region Save,Upadate,Delete,Dispose Method.
        void Save();
        void RemoveProduct(Product product);
        void Dispose();
        #endregion

        #region Get Method.
        IQueryable<ProductDTO> MapProducts();
        void PutProduct(int id, Product product);
        void PostProduct(Product product);
        Product FindProduct(int id);
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetAllProduct(int id);
        ProductDTO GetProduct(int id);
        #endregion
   
    }
}
