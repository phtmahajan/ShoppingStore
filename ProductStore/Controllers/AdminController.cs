using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ProductStore.Models;

namespace ProductStore.Controllers
{
    public class AdminController : ApiController
    {
        private OrdersContext db = new OrdersContext();
        
        /// <summary>
        // GET api/Admin
        //Gets all products.
        //UrI:api/products
        //HTTP Method:GET
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            return db.Products.AsEnumerable();
        }
        
        /// <summary>
        // GET api/Admin/5
        //Finds a product by ID.
        //UrI:api/products/id
        //HTTP Method:GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProduct(int id)
        {
            return db.Products.Where(o => o.CategoryID == id);
            
        }
        
        /// <summary>
        // PUT api/Admin/5
        //Updates a product.
        //UrI:api/products/id
        //HTTP Method:PUT 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public HttpResponseMessage PutProduct(int id, Product product)
        {
            if (ModelState.IsValid && id == product.Id)
            {
                db.Entry(product).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        // POST api/Admin
        //Creates a new product.
        //UrI:api/products
        //HTTP Method:POST 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public HttpResponseMessage PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, product);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = product.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
               
        /// <summary>
        // DELETE api/Admin/5
        //Deletes a product.
        //UrI:api/products/id
        //HTTP Method:DELETE 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Products.Remove(product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}