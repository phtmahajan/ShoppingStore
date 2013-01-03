using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductStore.Interface;
using ProductStore.Models;
using ProductStore.Repository;

namespace ProductStore.Controllers
{
    public class ProductCategoryController : ApiController
    {
     

        // Project products to product DTOs.
        private readonly IProuctCategoryRepository repository = new ProductCategoryRepository();
        // GET api/ProductCategory
        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return repository.GetProductCategories();
        }

        // GET api/ProductCategory/5
        public ProductCategory GetProductCategory(int id)
        {
            ProductCategory productcategory = repository.GetProductCategory(id);
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
               

                try
                {
                    repository.PutProductCategory(id, productcategory);
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
                repository.PostProductCategory(productcategory);

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
            ProductCategory productcategory = repository.FindProductCategories(id);
            if (productcategory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            repository.RemoveProductCategories(productcategory);

            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, productcategory);
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}