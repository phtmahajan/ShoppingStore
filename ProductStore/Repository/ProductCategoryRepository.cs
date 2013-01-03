using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using ProductStore.Interface;
using ProductStore.Models;
using ProductStore.DataContext;

namespace ProductStore.Repository
{
    public class ProductCategoryRepository : IProuctCategoryRepository
    {
        private OrdersContext db = new OrdersContext();

        public void Save()
        {
            db.SaveChanges();
        }

        public void PutProductCategory(int id, ProductCategory productcategory)
        {
            db.Entry(productcategory).State = EntityState.Modified;
            Save();
        }

        public void PostProductCategory(ProductCategory productcategory)
        {
            db.ProductCategories.Add(productcategory);
            db.SaveChanges();
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return db.ProductCategories.AsEnumerable();
        }

        public ProductCategory GetProductCategory(int id)
        {
            return db.ProductCategories.Find(id);
        }

        public ProductCategory FindProductCategories(int id)
        {
            return db.ProductCategories.Find(id);
        }

        public void RemoveProductCategories(ProductCategory product)
        {
            db.ProductCategories.Remove(product);
        }

        public void Dispose()
        {
            db.Dispose();

        }

    }
}