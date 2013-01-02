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
    public class ProductCategoryController : ApiController
    {
        private OrdersContext db = new OrdersContext();

        // GET api/ProductCategory
        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return db.ProductCategories.AsEnumerable();
        }

        // GET api/ProductCategory/5
        public ProductCategory GetProductCategory(int id)
        {
            ProductCategory productcategory = db.ProductCategories.Find(id);
            if (productcategory == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return productcategory;
        }

        // PUT api/ProductCategory/5
        public HttpResponseMessage PutProductCategory(int id, ProductCategory productcategory)
        {
            if (ModelState.IsValid && id == productcategory.Id)
            {
                db.Entry(productcategory).State = EntityState.Modified;

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

        // POST api/ProductCategory
        public HttpResponseMessage PostProductCategory(ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(productcategory);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, productcategory);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = productcategory.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/ProductCategory/5
        public HttpResponseMessage DeleteProductCategory(int id)
        {
            ProductCategory productcategory = db.ProductCategories.Find(id);
            if (productcategory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ProductCategories.Remove(productcategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, productcategory);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}