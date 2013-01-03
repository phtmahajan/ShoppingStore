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
        IQueryable<ProductDTO> MapProducts();
        ProductDTO GetProduct(int id);
        void Dispose();
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetAllProduct(int id);
        void PutProduct(int id, Product product);
        void PostProduct(Product product);
        void Save();
        Product FindProduct(int id);
        void RemoveProduct(Product product);
    }
}
