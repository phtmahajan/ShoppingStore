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
    public class ProductRepository : IProductRepository
    {
        private OrdersContext db = new OrdersContext();

        #region Product
        public IQueryable<ProductDTO> MapProducts()
        {
            return from p in db.Products
                   select new ProductDTO() { Id = p.Id, Name = p.Name, Price = p.Price, Quantity = p.Quantity };
        }
        public ProductDTO GetProduct(int id)
        {
            var product = (from p in MapProducts()
                           where p.Id == 1
                           select p).FirstOrDefault();
           
            return product;
        }
        #endregion

#region admin

        public IEnumerable<Product> GetProducts()
        {
            return db.Products.AsEnumerable();
        }


        public IEnumerable<Product> GetAllProduct(int id)
        {
            return db.Products.Where(o => o.CategoryID == id);

        }
        public void  PutProduct(int id, Product product)
        {
          
                db.Entry(product).State = EntityState.Modified;
                Save();
                 
                
        }
        public void PostProduct(Product product)
        {

            db.Products.Add(product);
            Save();
        }


        public void RemoveProduct(Product product)
        {
            db.Products.Remove(product);
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public Product FindProduct(int id)
        {
            return db.Products.Find(id);
        }

#endregion



        public void Dispose()
        {
            db.Dispose();
           
        }




       
    }



}